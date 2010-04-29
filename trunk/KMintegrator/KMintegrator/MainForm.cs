using System;
using System.Globalization;
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
        private string LastPathKompas = "";
        private string LastMathCadPath = "";
        private string LastProjectPath = "";

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
            return err;
        }
        private void OpenFileKompas(string filename)
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
        private void KompasRefresh()
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
                                this.TableKompas3D.Rows.Add(var.name, var.value, var.note);            
                            }
                                                  
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
            return err;
            
        }
        private void OpenMathCad()
        {
            if (MC != null)
            {
                WK = MC.Worksheets;
                WS = WK.Open(MathCadPath.Text);
                MC.Visible = true;
            }
            else
            {
            	MessageBox.Show(this, "Объект не захвачен", "Сообщение");
            }
            
        }
        private void MathCadParser(string MathPath, bool save)
        {
            // Обновляем таблицу Маткада
            int i = 0;
            string region_id;
            XmlDocument xd = new XmlDocument();
            xd.Load(MathPath);
            XmlNodeList xnl = xd.DocumentElement.ChildNodes;
            XmlNode ml_id, ml_real, result;
            if (!save) this.TableMathCad.Rows.Clear();
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
                                    	if (save) 
                                    		ml_real.InnerText = this.TableMathCad.Rows[i].Cells[1].Value.ToString();
                                    	else
                                        	this.TableMathCad.Rows.Add(ml_id.InnerText, ml_real.InnerText, "Присвоенная", region_id);

                                        // Записываем имена внешних переменных Маткада в комбо-бокс-столбец в таблице внешних переменных Компас-3D
  
                                    }
                                }

                                if (ml_define.Name == "ml:eval") // вычисления
                                {
                                    ml_id = ml_define.FirstChild;
                                    result = ml_define.LastChild;
                                    //ml_real = result.FirstChild;
                                    if (!save) this.TableMathCad.Rows.Add(ml_id.InnerText, result.InnerText, "Вычисленная", region_id);



                                }
								i++;	
                            }
            			}	
            try{
            if (save) xd.Save(MathPath);
            }
            catch{
            	MessageBox.Show("Не могу сохранить! Возможно файл открыт только для чтения!", "Ошибка",
                   				 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        
        private void Clear_All()
        {
            // Очищаем таблицу внешних переменных Компас-3D от предыдущих результатов
            this.TableKompas3D.Rows.Clear();

            // Очищаем таблицу внешних переменных Маткада от предыдущих результатов
            this.TableMathCad.Rows.Clear();

            // Очищаем комбо-бокс-столбец в таблице внешних переменных Маткада
            this.KompasName_ComboBox.Items.Clear();

            // Очищаем комбо-бокс-столбец в таблице внешних переменных Компас-3D
            this.MathCadName_ComboBox.Items.Clear();

            // Добавляем нулевой элемент в комбо-бокс-столбец в таблице внешних переменных Маткада
            this.KompasName_ComboBox.Items.Add("empty");

            // Добавляем нулевой элемент в комбо-бокс-столбец в таблице внешних переменных Компас-3D 
            this.MathCadName_ComboBox.Items.Add("empty");
        }
        
        
		//заполняем комбобокс у верхней таблицы
        private void AddMathCadCombo()
        {
        	this.KompasName_ComboBox.Items.Clear();
        	this.KompasName_ComboBox.Items.Add("empty");
        	
        	for (int j = 0; j < TableKompas3D.Rows.Count; j++)
        	{
        		this.KompasName_ComboBox.Items.Add(this.TableKompas3D.Rows[j].Cells[0].Value.ToString());
        	} 	
        	// Выбираем нулевой элемент для каждой ячейки в комбо-бокс-столбце в таблице внешних переменных Маткада
            for (int i = 0; i < TableMathCad.Rows.Count; i++)
            {
                this.KompasName_ComboBox.DataGridView.Rows[i].Cells[4].Value = this.KompasName_ComboBox.Items[0];
            }
        }
        
        //заполняем комбобокс у нижней таблице
        private void AddKompasCombo()
        {
        	this.MathCadName_ComboBox.Items.Clear();
        	this.MathCadName_ComboBox.Items.Add("empty");
        	for (int j = 0; j < TableMathCad.Rows.Count; j++)
        	{
        		this.MathCadName_ComboBox.Items.Add(this.TableMathCad.Rows[j].Cells[0].Value.ToString());
        	}
        	
        	// Выбираем нулевой элемент для каждой ячейки в комбо-бокс-столбце в таблице внешних переменных Компас-3D
            for (int i = 0; i < TableKompas3D.Rows.Count; i++)
            {
                this.MathCadName_ComboBox.DataGridView.Rows[i].Cells[3].Value = this.MathCadName_ComboBox.Items[0];
            }
        }
       
        private double ConverToDouble(string s)
        {
          	 string ns = "";
			 int j = 0;
			 bool start = false;
        	 double d;
        	 
           	 NumberFormatInfo provider = new NumberFormatInfo( );
    	  	 provider.NumberDecimalSeparator = ".";
    	 	 //provider.NumberGroupSeparator = ".";
         	 provider.NumberGroupSizes = new int[ ] { 2 };
         	 
			for (int i = 0; i< s.Length; i++)
			{
				if ( (s[i] == '.') || (s[i] == ',') ) start = true;
				if (start) j++;
				if (j > 3) break;
				ns = ns + s[i];
			}
			
			d = Convert.ToDouble(ns , provider);
			return d;
        }
        
        #endregion



        #region Exit_Close functions

        private void Exit_Kompas()
        {
            if (kompas != null)
            {
            	try
            	{
            	 kompas.Visible = true;
            	}
            	catch
            	{
            		return;
            	}
            	DialogResult reply = MessageBox.Show("Закрыть Kompas?",
           				 "Вопрос",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            	try
            	{
            		
            		if (reply == DialogResult.Yes) kompas.Quit();
            	}
            	catch
            	{
            		MessageBox.Show("Kompas уже закрыт или не может быть закрыт", "Сообщение",
                   				 MessageBoxButtons.OK, MessageBoxIcon.Information);
            	}
            	finally
            	{
            	 // Вот тут ещё не разобрался !!!
            	 Marshal.ReleaseComObject(kompas);
            	}
            }
        }

        private void Exit_MathCad()
        {
            if (MC != null)
            {
                DialogResult reply = MessageBox.Show("Закрыть MathCAD?",
           				 "Вопрос",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            	try
            	{
            		if (reply == DialogResult.Yes) MC.Quit(MCSaveOption.mcDiscardChanges);
            	}
            	catch
            	{
            		MessageBox.Show("MathCAD уже закрыт или не может быть закрыт", "Сообщение",
                   				 MessageBoxButtons.OK, MessageBoxIcon.Information);	
            	}
            	finally
            	{
            		Marshal.ReleaseComObject(MC);	
            	}
            	       
            }
        }

        private bool OpenProject(string path)
        {
        	XmlDocument xd = new XmlDocument();
            xd.Load(path);
            XmlNodeList xnl = xd.DocumentElement.ChildNodes;
            //XmlNode ml_id, ml_real, result;
            foreach (XmlNode xn in xnl)
            {
            	LastPathKompas = xn.SelectSingleNode("kompas").InnerText;
				LastMathCadPath = xn.SelectSingleNode("mcad").InnerText;
				
            }
            if (!File.Exists(LastPathKompas))
            {
            	MessageBox.Show("Файл Компаса не найден", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            	return false;
            }
            if (!File.Exists(LastPathKompas))
            {
            	MessageBox.Show("Файл MathCAD не найден", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            	return false;
            }
            KompasPath.Text = LastPathKompas;
            MathCadPath.Text = LastMathCadPath;
            return true;
        }
        
        private bool SaveProject()
        {
        	
        	SaveFileDialog SaveFileDialog = new SaveFileDialog();
        	SaveFileDialog.Filter  = "Документ XML (*.xml)|*.xml;";
        	if (SaveFileDialog.ShowDialog() != DialogResult.OK)
              return false;
            ProjectPath.Text = SaveFileDialog.FileName;
            
            // начинаем сохранять
			XmlTextWriter writer = null;
			try
			{
				// создаем класс для сохранения XML
				writer = new XmlTextWriter(SaveFileDialog.FileName, System.Text.Encoding.UTF8);
				// форматирование, чтобы файл не был вытянут в одну линию
				writer.Formatting = Formatting.Indented;

				// пишем заголовок и корневой элемент
				writer.WriteStartDocument();
				writer.WriteStartElement("project");
				
				writer.WriteStartElement("file");
				
				 writer.WriteStartElement("kompas");
			 	 // вложенный элемент first
				
				 writer.WriteString(LastPathKompas);
				 writer.WriteEndElement();
				
				 
				 writer.WriteStartElement("mcad");
				 writer.WriteString(LastMathCadPath);
				 writer.WriteEndElement();
				
				 writer.WriteEndElement();
			
				// закрываем корневой элемент и завершаем работу с документом
				writer.WriteEndElement();
				writer.WriteEndDocument();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error!");
				//MessageBox.Show("Проект не сохранён!", "Ошибка",
                //    MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			finally
			{
				// закрываем файл
				if (writer != null) writer.Close();
			}
        	return true;
        }
  
        
        

        #endregion

  		private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Exit_Kompas();
            Exit_MathCad();
            //(this.LastPathKompas.Count == 1) & (this.LastMathCadPath.Count == 1)
            if (  (this.LastPathKompas.Length > 2) && (this.LastMathCadPath.Length > 2) )
        	{
            	DialogResult reply = MessageBox.Show("Сохранить проект?",
           					"Вопрос",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            	if (reply == DialogResult.Yes) 
       						SaveProject();
            }
        }      


        private void AddKompas_Click(object sender, EventArgs e)
        {
             
            OpenFileDialog OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.Filter = "КОМПАС-3D Документы (*.m3d;*.a3d)|*.m3d;*.a3d";
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {

                // Активируем Компас-3D
            	if (!InitKompas()) return;
            	KompasPath.Text = OpenFileDialog.FileName;
                LastPathKompas = KompasPath.Text;
                // Открываем файл Компас-3D
                OpenFileKompas(LastPathKompas);
                KompasRefresh();
                AddMathCadCombo();
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
                MathCadParser(LastMathCadPath, false);
                AddKompasCombo();
            }
            
        }

        private void Apply_Kompas_Click(object sender, EventArgs e)
        {
        	this.TableKompas3D.Update();
        	
        	// Записываем изменения из таблицы в файл Компас-3D, перестраиваем сборку
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
                              
                                    var = (ksVariable)varCol.GetByIndex(i);

                                    d = (string)(this.TableKompas3D.Rows[i].Cells[1].Value.ToString());
                                    //g = Convert.ToDouble(d);
                                    g = ConverToDouble(d);
                                    //Convert.ToInt32(
                                   
                                    var.value = g;

                                    // Запись комментария в Компас-3D, проблемы с конвертацией форматов, на данный момент не работает
                                    //var.note = this.TableKompas3D.Rows[i].Cells[2].Value.ToString();
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
            KompasRefresh();
            AddMathCadCombo();

            // Обновляем таблицу Маткада
            MathCadParser(MathCadPath.Text, false);
            AddKompasCombo();

            // Заполняем нулевыми элементами все ячейки в комбо-бокс-столбцах
            //Zero_Element();

        }
        
        void Open_ProjectClick(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.Filter = "Документ XML (*.xml)|*.xml;";
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                LastProjectPath = OpenFileDialog.FileName;
                ProjectPath.Text = LastProjectPath;
                if ( !OpenProject(LastProjectPath) ) return;
                
                // Активируем Компас-3D
 				if (!InitKompas()) return;
				// Открываем файл Компас-3D
				OpenFileKompas(LastPathKompas);
				KompasRefresh();
				AddMathCadCombo();

 				MathCadParser(LastMathCadPath, false);
 				AddKompasCombo();
            }
        	
        }
        
        void Apply_MathCadClick(object sender, EventArgs e)
        {
        	MathCadParser(LastMathCadPath, true);
        }
        
        void Save_ProjectClick(object sender, EventArgs e)
        {
        	if (  (this.LastPathKompas.Length > 2) && (this.LastMathCadPath.Length > 2) )
        	 	SaveProject();
        	else
        		MessageBox.Show("Нет данных для сохранения", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        	
        }

        private void EndEdit_TableKompas3D(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
        	if (e.ColumnIndex == 3)
                this.TableKompas3D.Rows[e.RowIndex].Cells[1].Value =
                    this.TableMathCad.Rows[MathCadName_ComboBox.Items.IndexOf(
                        this.TableKompas3D.Rows[e.RowIndex].Cells[3].Value) - 1].Cells[1].Value;
            }
            catch
            {
            	return;
            }
            finally
            {
            	this.TableKompas3D.Update();
            }
        }
        
        
        void LinkLabel1LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        	try{
        	 System.Diagnostics.Process.Start("mailto:o.kozintsev@googlemail.com");
        	}
        	catch{};
        }
        
        void TableMathCadCellEndEdit(object sender, DataGridViewCellEventArgs e)
        {      	
        	try
            {
        	if (e.ColumnIndex == 4)
                this.TableMathCad.Rows[e.RowIndex].Cells[1].Value =
                    this.TableKompas3D.Rows[KompasName_ComboBox.Items.IndexOf(
                        this.TableMathCad.Rows[e.RowIndex].Cells[4].Value) - 1].Cells[1].Value;
            }
            catch
            {
            	return;
            }
            finally
            {
            	this.TableKompas3D.Update();
            }
        }
    }
}
