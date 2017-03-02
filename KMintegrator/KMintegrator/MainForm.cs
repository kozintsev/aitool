using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using System.Xml;

using System.IO;
using Mathcad;

using Kompas6Constants;
using Kompas6API5;

namespace KMintegrator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

        }

        #region Custom declarations
        private KompasObject _kompas;
        private ksDocument3D _doc3D;
        private string _lastPathKompas = "";
        private string _lastMathCadPath = "";
        private string _lastProjectPath = "";

        Mathcad.Application _mc;
        Worksheets _wk;
        Worksheet _ws;
        bool _save = false;

        class VarTopTable
        {
            public string name;
            public string nameval;
            public string type;
            public string val;

        }

        class VarBotTable
        {
            public string name;
            public string nameval;
            public string val;
        }

        List<VarTopTable> VarTop;
        List<VarBotTable> VarBot;
        #endregion

        #region Custom functions
        private bool InitKompas()
        {
            var err = true;
            try
            {
                var t = System.Type.GetTypeFromProgID("KOMPAS.Application.5");
                _kompas = (KompasObject)Activator.CreateInstance(t);
            }
            catch
            {
                MessageBox.Show(@"Компас не установлен", @"Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                err = false;
            }
            return err;
        }

        private bool OpenFileKompas(string filename)
        {
            var fileopen = false;
            if (_kompas != null)
            {
                _doc3D = (ksDocument3D)_kompas.Document3D();

                if (_doc3D != null) fileopen = _doc3D.Open(filename, false);
                if (!fileopen)
                {
                    MessageBox.Show(@"Не могу открыть файл", @"Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                _kompas.Visible = true;


                var err = _kompas.ksReturnResult();
                if (err != 0) _kompas.ksResultNULL();

            }
            else
            {
                MessageBox.Show(this, @"Объект не захвачен", @"Сообщение");
                return false;
            }
            return true;
        }
        private void KompasRefresh()
        {
            // Обновляем таблицу Компас-3D
            if (_kompas == null) return;
            // Делаем Компас-3D видимым
            _kompas.Visible = true;
            if (_doc3D == null) return;
            if (_doc3D.IsDetail())
            {
                _kompas.ksError("Текущий документ должен быть сборкой");
                return;
            }
            //doc3D.GetPart
            var part = (ksPart)_doc3D.GetPart(-1);	// Выбор компонента: -1 главный(сборка), 0 первый(деталь)
            if (part == null) return;
            // Работа с массивом внешних переменных
            var varCol = (ksVariableCollection)part.VariableCollection();
            if (varCol == null) return;
            var var = (ksVariable)_kompas.GetParamStruct((short)StructType2DEnum.ko_VariableParam);
            if (var == null) return;
            for (var i = 0; i < varCol.GetCount(); i++)
            {
                // Считывание внешних переменных Компас-3D с записью в таблицу
                var = (ksVariable)varCol.GetByIndex(i);
                TableKompas3D.Rows.Add(var.name, var.value, var.note);
            }
        }

        private Mathcad.Application InitMathCad()
        {
            try
            {
                if (_mc == null) _mc = new Mathcad.Application();
            }
            catch
            {
                MessageBox.Show(@"MathCAD не установлен. Пересчёт не возможен.", @"Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _mc = null;
            }
            return _mc;

        }
        private bool OpenMathCad(string path, bool recal)
        {
            if (_mc != null)
            {
                _wk = _mc.Worksheets;
                //WK.Count
                for (var i = 0; i < _wk.Count; i++)
                {
                    _ws = _wk.Item(i);
                    if (_ws.FullName == path)
                        _ws.Close(MCSaveOption.mcSaveChanges);
                }
                _ws = _wk.Open(path);
                _mc.Visible = true;//recal;
                if (recal == true)
                {
                    _ws.Recalculate();
                    _ws.Save();

                    for (var j = 0; j < TableMathCad.Rows.Count; j++)
                    {
                        if (TableMathCad.Rows[j].Cells[4].Value.ToString() == "eval")
                        {
                            var numericValue = _ws.GetValue(TableMathCad.Rows[j].Cells[0].Value.ToString()) as NumericValue;
                            if (numericValue != null)
                                TableMathCad.Rows[j].Cells[1].Value =
                                    numericValue.Real.ToString(CultureInfo.CurrentCulture);
                        }
                    }
                    _ws.Save();

                    _ws.Close(MCSaveOption.mcSaveChanges);
                }
            }
            else
            {
                MessageBox.Show(this, @"Объект не захвачен", @"Сообщение");
                return false;
            }
            return true;
        }
        // удалось распарсить файл SMathStudio версии 0.89
        // пока только чтение
        private void SMathStudioParser(string mathPath, bool save)
        {
            var xd = new XmlDocument();
            try
            {
                xd.Load(mathPath);
            }
            catch
            {

                MessageBox.Show(@"Ошибка открытия файла SMathStudio", @"Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                //XmlNodeList xnl = xd.DocumentElement.ChildNodes;
                if (save == false) TableMathCad.Rows.Clear();
                var list = xd.GetElementsByTagName("math");
                var s1 = "";
                var s2 = "";
                foreach (XmlNode xn in list)
                {
                    var xnl = xn.ChildNodes;

                    for (var i = 0; i < xnl.Count; i++)
                    {
                        if (xnl[i].Name == "input")
                        {
                            var inputs = xnl[i].ChildNodes;
                            XmlNode e;
                            for (var j = 0; j < inputs.Count; j++)
                            {
                                e = inputs[j];
                                if (j == 0 && e.Attributes[0].Value == "operand")
                                {
                                    s1 = e.InnerText;
                                }
                                if (j == 1 && e.Attributes[0].Value == "operand")
                                {
                                    s2 = e.InnerText;
                                    var a = s2.Replace('.', ',');
                                    double n;
                                    if (!double.TryParse(a, out n))
                                    {
                                        //обработка, если не число
                                        break;
                                        //MessageBox.Show(s2 + "не число");
                                    }
                                }
                                if (e.Attributes != null && (j == inputs.Count - 1 && e.Attributes[0].Value == "operator"))
                                {
                                    var s3 = e.InnerText;
                                    if (inputs.Count == 3 && s3 == "←")
                                        TableMathCad.Rows.Add(s1, s2, "Присвоенная", "1", "define");
                                    if (inputs.Count == 3 && s3 == "=")
                                        TableMathCad.Rows.Add(s1, s2, "Вычисленная", "1", "eval");
                                }

                            }
                        }
                        if (xnl[i].Name == "result")
                        {
                            var e = xnl[i].ChildNodes[0];
                            if (e.Attributes != null && e.Attributes[0].Value == "operand")
                                s2 = e.InnerText;
                            TableMathCad.Rows.Add(s1, s2, "Вычисленная", "1", "eval");

                        }

                    }// for end
                } // end foreach
            }
            catch
            {
                MessageBox.Show(@"Ошибка при работе с файлом расчёта", @"Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool MathCadParser(string mathPath, bool save)
        {
            // Обновляем таблицу Маткада
            var i = 0;
            var xd = new XmlDocument();
            try
            {
                xd.Load(mathPath);
            }
            catch
            {
                return false;
            }
            if (xd.DocumentElement != null)
            {
                var xnl = xd.DocumentElement.ChildNodes;
                if (save == false) TableMathCad.Rows.Clear();
                foreach (XmlNode xn in xnl)
                    if (xn.Name == "regions")
                        foreach (XmlNode region in xn.ChildNodes)
                        {
                            if (region.Attributes != null)
                            {
                                var regionId = region.Attributes[0].Value;
                                foreach (XmlNode math in region.ChildNodes)
                                    foreach (XmlNode mlDefine in math.ChildNodes)
                                    {
                                        XmlNode mlId;
                                        XmlNode mlReal;
                                        if (mlDefine.Name == "ml:define") // определения
                                        {
                                            mlId = mlDefine.FirstChild;
                                            mlReal = mlDefine.LastChild;
                                            if (mlReal.Name == "ml:real")
                                            {
                                                if (save == true)
                                                    mlReal.InnerText = TableMathCad.Rows[i].Cells[1].Value.ToString();
                                                else
                                                    TableMathCad.Rows.Add(mlId.InnerText, mlReal.InnerText, "Присвоенная", regionId, "define");

                                                i++;
                                            }
                                        }
                                        if (mlDefine.Name == "ml:eval") // вычисления
                                        {
                                            mlId = mlDefine.FirstChild;
                                            foreach (XmlNode result in mlDefine.ChildNodes)
                                                if (result.Name == "result")
                                                {
                                                    mlReal = result.FirstChild;
                                                    if (save == true)
                                                        mlReal.InnerText = TableMathCad.Rows[i].Cells[1].Value.ToString();
                                                    else
                                                        TableMathCad.Rows.Add(mlId.InnerText, mlReal.InnerText, "Вычисленная", regionId, "eval");
                                                }

                                            i++;
                                        }

                                    }
                            }
                        }
            }
            try
            {
                if (save) xd.Save(mathPath);
            }
            catch
            {
                MessageBox.Show(@"Не могу сохранить! Возможно файл открыт только для чтения!", @"Ошибка",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        } // end MathCadParse

        private void Clear_All()
        {
            // Очищаем таблицу внешних переменных Компас-3D от предыдущих результатов
            TableKompas3D.Rows.Clear();

            // Очищаем таблицу внешних переменных Маткада от предыдущих результатов
            TableMathCad.Rows.Clear();

            // Очищаем комбо-бокс-столбец в таблице внешних переменных Маткада
            KompasName_ComboBox.Items.Clear();

            // Очищаем комбо-бокс-столбец в таблице внешних переменных Компас-3D
            MathCadName_ComboBox.Items.Clear();

        }
        private void AddMathCadCombo()
        {
            //заполняем комбобокс у верхней таблицы
            KompasName_ComboBox.Items.Clear();
            KompasName_ComboBox.Items.Add("empty");

            for (var j = 0; j < TableKompas3D.Rows.Count; j++)
            {
                KompasName_ComboBox.Items.Add(TableKompas3D.Rows[j].Cells[0].Value.ToString());
            }
            // Выбираем нулевой элемент для каждой ячейки в комбо-бокс-столбце в таблице внешних переменных Маткада
            for (var i = 0; i < TableMathCad.Rows.Count; i++)
            {
                KompasName_ComboBox.DataGridView.Rows[i].Cells[5].Value = KompasName_ComboBox.Items[0];
            }
        }
        private void AddKompasCombo()
        {
            //заполняем комбобокс у нижней таблице
            MathCadName_ComboBox.Items.Clear();
            MathCadName_ComboBox.Items.Add("empty");
            for (var j = 0; j < TableMathCad.Rows.Count; j++)
            {
                MathCadName_ComboBox.Items.Add(TableMathCad.Rows[j].Cells[0].Value.ToString());
            }

            // Выбираем нулевой элемент для каждой ячейки в комбо-бокс-столбце в таблице внешних переменных Компас-3D
            for (var i = 0; i < TableKompas3D.Rows.Count; i++)
            {
                MathCadName_ComboBox.DataGridView.Rows[i].Cells[3].Value = MathCadName_ComboBox.Items[0];
            }
        }

        private static double ConverToDouble(string s)
        {
            var a = s.Replace('.', ',');
            double d;
            try
            {
                d = Convert.ToDouble(a);
            }
            catch (Exception)
            {
                d = 0;
            }
            return d;
        }

        #endregion

        #region Exit_Close functions

        private void Exit_Kompas()
        {
            if (_kompas == null) return;
            try
            {
                _kompas.Visible = true;
            }
            catch
            {
                return;
            }
            var reply = MessageBox.Show(@"Закрыть Kompas?",
                @"Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            try
            {

                if (reply == DialogResult.Yes) _kompas.Quit();
            }
            catch
            {
                MessageBox.Show(@"Kompas уже закрыт или не может быть закрыт", @"Сообщение",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Marshal.ReleaseComObject(_kompas);
            }
        }

        private void Exit_MathCad()
        {
            if (_mc == null) return;
            try
            {
                var reply = DialogResult.No;
                if (_mc.Visible) reply = MessageBox.Show(@"Закрыть MathCAD?",
                    @"Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                else
                {
                    _mc.Quit(MCSaveOption.mcDiscardChanges);
                    Marshal.ReleaseComObject(_mc);
                }
                if (reply == DialogResult.Yes)
                {
                    _mc.Quit(MCSaveOption.mcSaveChanges);
                    Marshal.ReleaseComObject(_mc);
                }
            }
            catch
            {
                MessageBox.Show(@"MathCAD уже закрыт или не может быть закрыт", @"Сообщение",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool OpenProject(string path)
        {
            var fileproject = new FileInfo(path);
            var dirpath = fileproject.DirectoryName + "\\";
            VarTop = new List<VarTopTable>();
            VarBot = new List<VarBotTable>();
            VarTop.Clear();
            VarBot.Clear();
            var xd = new XmlDocument();
            try
            {
                xd.Load(path);
                if (xd.DocumentElement != null)
                {
                    var xnl = xd.DocumentElement.ChildNodes;
                    foreach (XmlNode xn in xnl)
                    {
                        var xnf = xn.ChildNodes;
                        foreach (XmlNode xnc in xnf)
                        {
                            switch (xnc.Name)
                            {
                                case "kompas":
                                    _lastPathKompas = dirpath + xnc.InnerText;
                                    break;
                                case "mcad":
                                    _lastMathCadPath = dirpath + xnc.InnerText;
                                    break;
                                case "TableTop":
                                    if (xnc.Attributes != null)
                                    {
                                        var varT = new VarTopTable
                                        {
                                            name = xnc.Attributes[1].Value,
                                            type = xnc.Attributes[2].Value,
                                            nameval = xnc.Attributes[3].Value,
                                            val = xnc.InnerText
                                        };
                                        VarTop.Add(varT);
                                    }
                                    break;
                                case "TableBottom":
                                    if (xnc.Attributes != null)
                                    {
                                        var varB = new VarBotTable
                                        {
                                            name = xnc.Attributes[1].Value,
                                            nameval = xnc.Attributes[2].Value,
                                            val = xnc.InnerText
                                        };
                                        VarBot.Add(varB);
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show(@"Ошибка в файле проекта", @"Ошибка",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!File.Exists(_lastPathKompas))
            {
                MessageBox.Show(@"Файл Компаса не найден", @"Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!File.Exists(_lastPathKompas))
            {
                MessageBox.Show(@"Файл MathCAD не найден", @"Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            KompasPath.Text = _lastPathKompas;
            MathCadPath.Text = _lastMathCadPath;
            return true;
        } // end OpenProject

        private bool SaveProject(string path)
        {
            string str1, str2, str3, str4;
            if (!File.Exists(path))
            {
                var saveFileDialog = new SaveFileDialog { Filter = @"Документ XML (*.xml)|*.xml;" };
                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    return false;
                _lastProjectPath = saveFileDialog.FileName;
                ProjectPath.Text = _lastProjectPath;
            }
            path = _lastProjectPath;
            var filekompas = new FileInfo(_lastPathKompas);
            var filemcad = new FileInfo(_lastMathCadPath);
            // начинаем сохранять
            XmlTextWriter writer = null;
            try
            {
                // создаем класс для сохранения XML
                writer = new XmlTextWriter(path, System.Text.Encoding.UTF8);
                // форматирование, чтобы файл не был вытянут в одну линию
                writer.Formatting = Formatting.Indented;
                // пишем заголовок и корневой элемент
                writer.WriteStartDocument();
                writer.WriteStartElement("project");

                writer.WriteStartElement("file");

                writer.WriteStartElement("kompas");

                writer.WriteString(filekompas.Name);
                writer.WriteEndElement(); // end kompas


                writer.WriteStartElement("mcad");
                writer.WriteString(filemcad.Name);
                writer.WriteEndElement(); // end mathcad

                writer.WriteEndElement(); // Конец file

                writer.WriteStartElement("table");
                for (var i = 0; i < TableMathCad.Rows.Count; i++)
                {
                    str1 = TableMathCad.Rows[i].Cells[0].Value.ToString();
                    str2 = TableMathCad.Rows[i].Cells[5].Value.ToString();
                    str3 = TableMathCad.Rows[i].Cells[4].Value.ToString();
                    str4 = TableMathCad.Rows[i].Cells[1].Value.ToString();
                    writer.WriteStartElement("TableTop");
                    writer.WriteAttributeString("id", Convert.ToString(i + 1));
                    writer.WriteAttributeString("name", str1);
                    writer.WriteAttributeString("type", str3);
                    writer.WriteAttributeString("val", str4);
                    writer.WriteString(str2);
                    writer.WriteEndElement(); // конец тега TableTop
                }

                for (var j = 0; j < TableKompas3D.Rows.Count; j++)
                {
                    str1 = TableKompas3D.Rows[j].Cells[0].Value.ToString();
                    str2 = TableKompas3D.Rows[j].Cells[3].Value.ToString();
                    str3 = TableKompas3D.Rows[j].Cells[1].Value.ToString();
                    writer.WriteStartElement("TableBottom");
                    writer.WriteAttributeString("id", Convert.ToString(j + 1));
                    writer.WriteAttributeString("name", str1);
                    writer.WriteAttributeString("val", str3);
                    writer.WriteString(str2);
                    writer.WriteEndElement(); // конец тега TableBottom
                }

                writer.WriteEndElement(); // конец table

                writer.WriteEndElement(); // конец project
                // закрываем корневой элемент и завершаем работу с документом
                writer.WriteEndDocument();

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error!");
                MessageBox.Show(@"Проект не сохранён! " + ex.Message, @"Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                // закрываем файл
                if (writer != null) writer.Close();
            }
            _save = true;
            MessageBox.Show(@"Проект сохранён!",
                            @"Проект", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return _save;
        } // end SaveProject()

        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_lastPathKompas.Length > 2) Exit_Kompas();
            if (_lastMathCadPath.Length > 2) Exit_MathCad();
            //(this.LastPathKompas.Count == 1) & (this.LastMathCadPath.Count == 1)
            if ((_lastPathKompas.Length > 2) && (_lastMathCadPath.Length > 2) && _save == false)
            {
                var reply = MessageBox.Show(@"Сохранить проект?",
                            @"Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (reply == DialogResult.Yes)
                    SaveProject(_lastProjectPath);
            }
        }   // MainForm_FormClosing   

        #endregion

        private void AddKompas_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = @"КОМПАС-3D Сборки (*.a3d)|*.a3d"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _save = false;
                // Активируем Компас-3D
                if (!InitKompas()) return;
                KompasPath.Text = openFileDialog.FileName;
                _lastPathKompas = KompasPath.Text;
                // Открываем файл Компас-3D
                if (!OpenFileKompas(_lastPathKompas))
                    return;
                KompasRefresh();
                AddMathCadCombo();
                AddKompasCombo();
            }

        }

        private void AddMathCad_Click(object sender, EventArgs e)
        {
            // Открываем файл Маткада
            var openFileDialog = new OpenFileDialog
            {
                Filter =
                    @"All supported(*.xmcd;*.sm)|*.xmcd;*.sm|Файлы MathCAD 14 (*.xmcd)|*.xmcd|Файлы SMath Studio (*.sm)|*.sm|All Files|*.*"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _save = false;
                MathCadPath.Text = openFileDialog.FileName;
                _lastMathCadPath = MathCadPath.Text;
                var s = Path.GetExtension(openFileDialog.SafeFileName);
                switch (s)
                {
                    case ".xmcd":
                        MathCadParser(_lastMathCadPath, false);
                        break;
                    case ".sm":
                        SMathStudioParser(_lastMathCadPath, false);
                        var st = new Settings();
                        var programstart = st.GetSMathPath();
                        if (programstart != "")
                            //programstart +=   "\"" + LastMathCadPath + "\"";
                            System.Diagnostics.Process.Start(programstart, _lastMathCadPath);
                        else
                            MessageBox.Show(@"Не указан путь к SMathStudio Запуск не возможен", @"Информация",
                                 MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }

                AddMathCadCombo();
                AddKompasCombo();
            }

        }

        private void Apply_Kompas_Click(object sender, EventArgs e)
        {
            _save = false;
            TableKompas3D.Update();

            // Записываем изменения из таблицы в файл Компас-3D, перестраиваем сборку
            if (_kompas != null)
            {
                if (_doc3D != null)
                {
                    if (_doc3D.IsDetail())
                    {
                        _kompas.ksError("Текущий документ должен быть сборкой");
                        return;
                    }
                    var part = (ksPart)_doc3D.GetPart(-1);    // Выбор компонента: -1 главный(сборка), 0 первый(деталь)
                    if (part != null)
                    {
                        // Работа с массивом внешних переменных
                        var varCol = (ksVariableCollection)part.VariableCollection();
                        if (varCol != null)
                        {
                            // Запись внешних переменных в Компас-3D
                            var variable = (ksVariable)_kompas.GetParamStruct((short)StructType2DEnum.ko_VariableParam);
                            if (variable == null) return;
                            double g;
                            for (var i = 0; i < varCol.GetCount(); i++)
                            {
                                variable = (ksVariable)varCol.GetByIndex(i);
                                var d = TableKompas3D.Rows[i].Cells[1].Value.ToString();
                                g = ConverToDouble(d);
                                variable.value = g;
                                // Запись комментария в Компас-3D, проблемы с конвертацией форматов, на данный момент не работает
                                //variable.note = this.TableKompas3D.Rows[i].Cells[2].Value.ToString();
                            }

                            // Простое перестроение сборки, на данный момент не работает
                            part.RebuildModel();
                            // Перестроение сборки хитрым способом
                            //_doc3D.Save();
                            //_doc3D.close();
                            //_doc3D = (ksDocument3D)_kompas.Document3D();
                            //if (_doc3D != null) _doc3D.Open(_lastPathKompas);

                        }
                    }
                }
            }
        }

        private void Apply_MathCadClick(object sender, EventArgs e)
        {
            _save = false;
            if (_lastMathCadPath == "")
                return;
            if (Path.GetExtension(_lastMathCadPath) != ".xmcd")
            {
                MessageBox.Show(@"Пересчёт возможен только для файлов MathCAD", @"Сообщение",
                                 MessageBoxButtons.OK, MessageBoxIcon.Information);
                return; // для не маткад файла пересчёт не возможен
            }
            // Заносим значения переменных маткада из таблицы в файл
            if (TableMathCad.RowCount == 0)
            {
                MessageBox.Show(@"Нет данных для сохранения", @"Сообщение",
                                 MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!MathCadParser(_lastMathCadPath, true))
                return;
            // Инициализация маткада выполняется если маткад еще не запущен
            // Это функциия возвражает значение
            if (InitMathCad() == null) return;

            // Открываем файл маткада, пересчитываем, заносим в таблицу вычисленные, закрываем
            if (!OpenMathCad(_lastMathCadPath, true))
                return;

            // Считываем значение из файла маткада в таблицу
            if (!MathCadParser(_lastMathCadPath, true)) return;
            if (!MathCadParser(_lastMathCadPath, false)) return;

            AddKompasCombo();
            // Просто открываем файл маткада
            OpenMathCad(_lastMathCadPath, false);
        }


        private void Refresh_All_Click(object sender, EventArgs e)
        {
            _save = false;
            // Проверяеме открыт ли файл Маткада
            if (_lastMathCadPath == "")
            {
                MessageBox.Show("Откройте файл Маткада", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Проверяеме открыт ли файл Маткада
            if (_lastPathKompas == "")
            {
                MessageBox.Show("Откройте файл Компас-3D", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Полностью очищаем таблицы от предыдущих результатов
            Clear_All();

            // Обновляем таблицу Компас-3D
            KompasRefresh();
            // Обновляем таблицу Маткада
            MathCadParser(MathCadPath.Text, false);

            AddMathCadCombo();
            AddKompasCombo();

        }



        void Open_ProjectClick(object sender, EventArgs e)
        {
            var OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.Filter = "Документ XML (*.xml)|*.xml;";
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                _lastProjectPath = OpenFileDialog.FileName;
                var file = new FileInfo(_lastProjectPath);
                var filepath = file.DirectoryName;
                ProjectPath.Text = _lastProjectPath;
                if (!OpenProject(_lastProjectPath)) return;

                // Активируем Компас-3D
                if (!InitKompas()) return;
                // Открываем файл Компас-3D
                if (!OpenFileKompas(_lastPathKompas))
                    return;
                KompasRefresh();
                if (!MathCadParser(_lastMathCadPath, false))
                    return;
                AddMathCadCombo();
                AddKompasCombo();
                _save = true;
                // устанавливаем значения в верхней таблицы
                if (TableMathCad.RowCount != VarTop.Count)
                    return;
                if (TableKompas3D.RowCount != VarBot.Count)
                    return;
                try
                {
                    //верхная таблица
                    for (var i = 0; i < TableMathCad.RowCount; i++)
                    {
                        TableMathCad.Rows[i].Cells[1].Value = VarTop[i].nameval;
                        KompasName_ComboBox.DataGridView.Rows[i].Cells[5].Value = VarTop[i].val;
                    }
                    //нижная таблица
                    for (var j = 0; j < TableKompas3D.RowCount; j++)
                    {
                        //if (this.TableKompas3D.Rows[j].Cells[1].Value.ToString() == VarBot[j].name) // если имена совпадают
                        //{
                        TableKompas3D.Rows[j].Cells[1].Value = VarBot[j].nameval;
                        MathCadName_ComboBox.DataGridView.Rows[j].Cells[3].Value = VarBot[j].val;
                        //}
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка при востановлении связей", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        void Save_ProjectClick(object sender, EventArgs e)
        {
            if ((_lastPathKompas.Length > 2) && (_lastMathCadPath.Length > 2))
            {
                SaveProject(_lastProjectPath);
            }
            else
                MessageBox.Show("Нет данных для сохранения", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

        } //     Save_ProjectClick  

        void SaveAsClick(object sender, EventArgs e)
        {
            if ((_lastPathKompas.Length > 2) && (_lastMathCadPath.Length > 2))
            {
                SaveProject("");
            }
            else
                MessageBox.Show("Нет данных для сохранения", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        void LinkLabel1LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("mailto:o.kozintsev@googlemail.com");
            }
            catch { };
        }

        private void EndEdit_TableKompas3D(object sender, DataGridViewCellEventArgs e)
        {
            object obj;
            int i;

            if (e.ColumnIndex == 3)
            {
                obj = TableKompas3D.Rows[e.RowIndex].Cells[3].Value;
                if (obj == null)
                    return;
                i = MathCadName_ComboBox.Items.IndexOf(obj) - 1;
                if (i == -1)
                    return;
                TableKompas3D.Rows[e.RowIndex].Cells[1].Value =
                    TableMathCad.Rows[i].Cells[1].Value;
            }
            TableKompas3D.Update();
        }

        void TableMathCadCellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            object obj;
            int i;
            if (e.ColumnIndex == 5)
            {
                obj = TableMathCad.Rows[e.RowIndex].Cells[5].Value;
                if (obj == null)
                    return;
                i = KompasName_ComboBox.Items.IndexOf(obj) - 1;
                if (i == -1)
                    return;
                TableMathCad.Rows[e.RowIndex].Cells[1].Value =
                    TableKompas3D.Rows[i].Cells[1].Value;
            }
            TableMathCad.Update();
        }

    }
}
