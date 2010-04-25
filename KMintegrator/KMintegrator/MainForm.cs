using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using System.Xml;

using System.IO;
using Mathcad;

using Kompas6Constants;
using Kompas6Constants3D;

//Alternative Type - Full or LT
#if (__LIGHT_VERSION__)
using Kompas6LTAPI5;
#else
using Kompas6API5;
#endif

using KAPITypes;

namespace KMintegrator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent(); 
        }

        #region Custom declarations
        private KompasObject kompas;
        private ksDocument3D doc3D;
        private string LastPathKompas;
        private string LastMathCadPath;
        private bool InKompas;
        private bool InMathcad;

        Mathcad.Application MC;
        Mathcad.Worksheets WK;
        Mathcad.Worksheet WS;
        #endregion



        #region Custom functions


        private bool InitKompas()
        {
            bool err = true;
            try
            {
        	
                #region Alternative Type
                #if __LIGHT_VERSION__
			    Type t = System.Type.GetTypeFromProgID("KOMPASLT.Application.5");
                #else
                Type t = System.Type.GetTypeFromProgID("KOMPAS.Application.5");
                #endif
                #endregion

                kompas = (KompasObject)Activator.CreateInstance(t);
            }
            catch
            {
            	MessageBox.Show("Компас не установлен", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            	err = false;
            }
            InKompas = err;
            return err;
        }
        private void OpenFile_Kompas(string filename)
        {
            if (kompas != null)
            {
                    doc3D = (ksDocument3D)kompas.Document3D();
                    if (doc3D != null) doc3D.Open(filename, false);

                    kompas.Visible = true;


                    int err = kompas.ksReturnResult();
                    if (err != 0) kompas.ksResultNULL();
                
            }
            else
            {
                MessageBox.Show(this, "Объект не захвачен", "Сообщение");
            }
        }
        private void Kompas_Refresh()
        {
            // Обновляем таблицу Компас-3D

            if (kompas != null)
            {
                // Делаем Компас-3D видимым
                kompas.Visible = true;

                if (doc3D != null)
                {
                    if (doc3D.IsDetail())
                    {
                        kompas.ksError("Текущий документ должен быть сборкой");
                        return;
                    }
                    ksPart part = (ksPart)doc3D.GetPart(-1);	// Выбор компонента: -1 главный(сборка), 0 первый(деталь)
                    if (part != null)
                    {
                        // Работа с массивом внешних переменных
                        ksVariableCollection varCol = (ksVariableCollection)part.VariableCollection();
                        if (varCol != null)
                        {
                            ksVariable var = (ksVariable)kompas.GetParamStruct((short)StructType2DEnum.ko_VariableParam);
                            if (var == null) return;

                            for (int i = 0; i < varCol.GetCount(); i++)
                            {
                                // Считывание внешних переменных Компас-3D с записью в таблицу
                                var = (ksVariable)varCol.GetByIndex(i);
                                this.Table_ExVar_Kompas3D.Rows.Add(var.name, var.value, var.note);
                                // Записываем имена внешних переменных Компас-3D в комбо-бокс-столбец в таблице внешних переменных Маткада
                                this.KompasName_ComboBox.Items.Add(var.name);
                            }
                        }
                    }
                }
            }
        }
        private void Write_Kompas()
        {
            if (kompas != null)
            {
                if (doc3D != null)
                {
                    if (doc3D.IsDetail())
                    {
                        kompas.ksError("Текущий документ должен быть сборкой");
                        return;
                    }
                    ksPart part = (ksPart)doc3D.GetPart(-1);    // Выбор компонента: -1 главный(сборка), 0 первый(деталь)
                    if (part != null)
                    {
                        // Работа с массивом внешних переменных
                        ksVariableCollection varCol = (ksVariableCollection)part.VariableCollection();
                        if (varCol != null)
                        {
                            // Запись внешних переменных в Компас-3D
                            ksVariable var = (ksVariable)kompas.GetParamStruct((short)StructType2DEnum.ko_VariableParam);
                            if (var == null) return;

                            string d;
                            double g;



                            for (int i = 0; i < varCol.GetCount(); i++)
                            {
                                if (this.MathCadName_ComboBox.DataGridView.Rows[i].Cells[3].Value.ToString() == "empty")
                                {
                                    var = (ksVariable)varCol.GetByIndex(i);

                                    d = (string)(this.Table_ExVar_Kompas3D.Rows[i].Cells[1].Value.ToString());
                                    g = Convert.ToDouble(d);
                                    var.value = g;

                                    // Запись комментария в Компас-3D, проблемы с конвертацией форматов, на данный момент не работает
                                    var.note = this.Table_ExVar_Kompas3D.Rows[i].Cells[2].Value.ToString();

                                }
                                else
                                {


                                }
                            }

                            // Простое перестроение сборки, на данный момент не работает
                            part.RebuildModel();

                            // Перестроение сборки хитрым способом
                            doc3D.Save();
                            doc3D.close();
                            doc3D = (ksDocument3D)kompas.Document3D();
                            if (doc3D != null) doc3D.Open(LastPathKompas, false);

                        }
                    }
                }
            }
        }


        private bool InitMathCad()
        {
            bool err = true;
        	try
        	{
                MC = new Mathcad.Application();
        	}
            catch
            {
            	MessageBox.Show("MathCAD не установлен", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            	err = false;
            }
            InMathcad = err;
            return err;
            
        }
        private void LoadGraphics_MathCad()
        {
            if (MC != null)
            {
                WK = MC.Worksheets;
                WS = WK.Open(MathCadPath.Text);
                MC.Visible = true;
            }
        }
        private void MathCadParser(string MathPath)
        {
            // Обновляем таблицу Маткада
            string region_id;
            XmlDocument xd = new XmlDocument();
            xd.Load(MathPath);
            XmlNodeList xnl = xd.DocumentElement.ChildNodes;
            XmlNode ml_id, ml_real, result;
            foreach (XmlNode xn in xnl)
                if (xn.Name == "regions")
                    foreach (XmlNode region in xn.ChildNodes)
            		{
            		region_id = region.Attributes[0].Value;
                        foreach (XmlNode math in region.ChildNodes)
                            foreach (XmlNode ml_define in math.ChildNodes)
                            {
                                if (ml_define.Name == "ml:define") // определения 
                                {
                                    ml_id = ml_define.FirstChild;
                                    ml_real = ml_define.LastChild;
                                    if (ml_real.Name == "ml:real")
                                    {

                                        this.Table_ExVar_MathCad.Rows.Add(ml_id.InnerText, ml_real.InnerText, "Присвоенная", region_id);

                                        // Записываем имена внешних переменных Маткада в комбо-бокс-столбец в таблице внешних переменных Компас-3D
                                        this.MathCadName_ComboBox.Items.Add(ml_id.InnerText);
                                    }
                                }

                                if (ml_define.Name == "ml:eval") // вычисления
                                {
                                    ml_id = ml_define.FirstChild;
                                    result = ml_define.LastChild;
                                    //ml_real = result.FirstChild;
                                    this.Table_ExVar_MathCad.Rows.Add(ml_id.InnerText, result.InnerText, "Вычисленная", region_id);

                                    // Записываем имена внешних переменных Маткада в комбо-бокс-столбец в таблице внешних переменных Компас-3D
                                    this.MathCadName_ComboBox.Items.Add(ml_id.InnerText);


                                }

                            }
            			}		

        }

        
        private void Clear_All()
        {
            // Очищаем таблицу внешних переменных Компас-3D от предыдущих результатов
            this.Table_ExVar_Kompas3D.Rows.Clear();

            // Очищаем таблицу внешних переменных Маткада от предыдущих результатов
            this.Table_ExVar_MathCad.Rows.Clear();

            // Очищаем комбо-бокс-столбец в таблице внешних переменных Маткада
            this.KompasName_ComboBox.Items.Clear();

            // Очищаем комбо-бокс-столбец в таблице внешних переменных Компас-3D
            this.MathCadName_ComboBox.Items.Clear();

            // Добавляем нулевой элемент в комбо-бокс-столбец в таблице внешних переменных Маткада
            this.KompasName_ComboBox.Items.Add("empty");

            // Добавляем нулевой элемент в комбо-бокс-столбец в таблице внешних переменных Компас-3D 
            this.MathCadName_ComboBox.Items.Add("empty");
        }
        private void Zero_Element()
        {
            // Выбираем нулевой элемент для каждой ячейки в комбо-бокс-столбце в таблице внешних переменных Маткада
            for (int i = 0; i < Table_ExVar_MathCad.Rows.Count; i++)
            {
                this.KompasName_ComboBox.DataGridView.Rows[i].Cells[3].Value = this.KompasName_ComboBox.Items[0];
            }

            // Выбираем нулевой элемент для каждой ячейки в комбо-бокс-столбце в таблице внешних переменных Компас-3D
            for (int i = 0; i < Table_ExVar_Kompas3D.Rows.Count; i++)
            {
                this.MathCadName_ComboBox.DataGridView.Rows[i].Cells[3].Value = this.MathCadName_ComboBox.Items[0];
            }
        }

        
        #endregion



        #region Exit_Close functions

        private void Exit_Kompas()
        {
            if (kompas != null)
            {
                kompas.Quit();
                Marshal.ReleaseComObject(kompas);
            }
        }

        private void Exit_MathCad()
        {
            if (MC != null)
            {
                MC.Quit(MCSaveOption.mcDiscardChanges);
                Marshal.ReleaseComObject(MC);
            }
        }



        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Exit_Kompas();
        }

        #endregion

        


        private void AddKompas_Click(object sender, EventArgs e)
        {
            // Активируем Компас-3D
            if (!InitKompas()) return; 
            OpenFileDialog OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.Filter = "КОМПАС-3D Документы (*.m3d;*.a3d)|*.m3d;*.a3d";
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {

                KompasPath.Text = OpenFileDialog.FileName;
                LastPathKompas = KompasPath.Text;
                // Открываем файл Компас-3D
                OpenFile_Kompas(LastPathKompas);
            }

        }

        private void AddMathCad_Click(object sender, EventArgs e)
        {
            // Открываем файл Маткада
            OpenFileDialog OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.Filter = "Файлы MathCAD 14 (*.xmcd)|*.xmcd";
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                MathCadPath.Text = OpenFileDialog.FileName;
                LastMathCadPath = MathCadPath.Text;
                MathCadParser(LastMathCadPath);
            }
            
        }

        private void Apply_Kompas_Click(object sender, EventArgs e)
        {
            // Записываем изменения из таблицы в файл Компас-3D, перестраиваем сборку
            Write_Kompas();
        }

        private void Refresh_All_Click(object sender, EventArgs e)
        {
            // Проверяеме открыт ли файл Маткада
            if (MathCadPath.Text == "")
            {                
                MessageBox.Show("Откройте файл Маткада", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;            
            }

            // Проверяеме открыт ли файл Маткада
            if (KompasPath.Text == "")
            {
                MessageBox.Show("Откройте файл Компас-3D", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Полностью очищаем таблицы от предыдущих результатов
            Clear_All();

            // Обновляем таблицу Компас-3D
            Kompas_Refresh();

            // Обновляем таблицу Маткада
            MathCadParser(MathCadPath.Text);

            // Заполняем нулевыми элементами все ячейки в комбо-бокс-столбцах
            Zero_Element();

        }
        
        void Open_ProjectClick(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.Filter = "Документ XML (*.xml)|*.xml;";
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {

                ProjectPath.Text = OpenFileDialog.FileName;
            }
        	
        }
        
        void Apply_MathCadClick(object sender, EventArgs e)
        {
        	//
        }
    }
}
