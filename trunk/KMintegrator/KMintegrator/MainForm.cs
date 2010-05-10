using System;
using System.Globalization;
//using System.Collections.Generic;
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
        bool Save = false;
       
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
     
        private Mathcad.Application InitMathCad()
        {
        	try
        	{
                if (MC == null ) MC = new Mathcad.Application();
        	}
            catch
            {
            	MessageBox.Show("MathCAD не установлен. Пересчёт не возможен.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            	MC = null;
            }
            return MC;
            
        }
        private void OpenMathCad(string Path, bool recal)
        {
            if (MC != null)
            {
                WK = MC.Worksheets;
                //WK.Count
                for(int i = 0; i < WK.Count; i++)
                {
                	WS = WK.Item(i);
                	if (WS.FullName == Path)
                		WS.Close(MCSaveOption.mcSaveChanges);
                }
                WS = WK.Open(Path);
                MC.Visible = true;//recal;
                if (recal == true)
                {
                    WS.Recalculate();
					WS.Save();

                    for (int j = 0; j < TableMathCad.Rows.Count; j++)
                    {
                        if (this.TableMathCad.Rows[j].Cells[4].Value.ToString() == "eval")
                        {
                            this.TableMathCad.Rows[j].Cells[1].Value =
                            	(WS.GetValue(this.TableMathCad.Rows[j].Cells[0].Value.ToString()) as NumericValue).Real.ToString();
                            //ConverToDouble((WS.GetValue(this.TableMathCad.Rows[j].Cells[0].Value.ToString()) as NumericValue).Real.ToString()).ToString();
                        }

                    }
                    WS.Save();

                    WS.Close(MCSaveOption.mcSaveChanges);
                }
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
            try{
            xd.Load(MathPath);
            }
            catch{
            	return;
            }
            XmlNodeList xnl = xd.DocumentElement.ChildNodes;
            XmlNode ml_id, ml_real;
            if (save == false) this.TableMathCad.Rows.Clear();
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
                                        if (save == true)
                                            ml_real.InnerText = this.TableMathCad.Rows[i].Cells[1].Value.ToString();
                                        else
                                            this.TableMathCad.Rows.Add(ml_id.InnerText, ml_real.InnerText, "Присвоенная", region_id, "define");
                                        
                                        i++;
                                    }
                                }
                                if (ml_define.Name == "ml:eval") // вычисления
                                {
                                    ml_id = ml_define.FirstChild;
                                        foreach (XmlNode result in ml_define.ChildNodes)
                                            if (result.Name == "result")
                                            {
                                                ml_real = result.FirstChild;
												if (save == true)
													ml_real.InnerText = this.TableMathCad.Rows[i].Cells[1].Value.ToString();
												else
												   this.TableMathCad.Rows.Add(ml_id.InnerText, ml_real.InnerText, "Вычисленная", region_id, "eval");
                                            }

                                    i++;
                                }

                            }
                    }
            try
            {
                if (save) xd.Save(MathPath);
            }
            catch
            {
                MessageBox.Show("Не могу сохранить! Возможно файл открыт только для чтения!", "Ошибка",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } // end MathCadParse
        
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
            
        }    
        private void AddMathCadCombo()
        {
            //заполняем комбобокс у верхней таблицы
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
        private void AddKompasCombo()
        {
            //заполняем комбобокс у нижней таблице
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
           	 //NumberFormatInfo provider = new NumberFormatInfo( );
    	  	 //provider.NumberDecimalSeparator = ".";
    	 	 //provider.NumberGroupSeparator = ".";
         	 //provider.NumberGroupSizes = new int[ ] { 2 };
         	 
			for (int i = 0; i< s.Length; i++)
			{
				if ( (s[i] == '.') || (s[i] == ',') ) start = true;
				if (start) j++;
				if (j > 3) break;
				if (s[i] == '.' ) ns = Name + ',';
					else ns = ns + s[i];
			}
			d = Convert.ToDouble(ns);
			//d = Convert.ToDouble(ns , provider);
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
        		try
            	{
            		//MC.Visible = true;
            		DialogResult reply = DialogResult.No;
            		if (MC.Visible == true) reply = MessageBox.Show("Закрыть MathCAD?",
           				 "Вопрос",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            		else MC.Quit(MCSaveOption.mcSaveChanges);
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
        	try{
            xd.Load(path);
            XmlNodeList xnl = xd.DocumentElement.ChildNodes;
            XmlNodeList xnf;
            //XmlNode ml_id, ml_real, result;
            foreach (XmlNode xn in xnl)
            {
            	//tLastPathKompas
            	//this.LastPathKompas
					xnf = xn.ChildNodes;
            		foreach (XmlNode xnc in xnf)
					{
            			//switch (xnc.Name) 
            			switch(xnc.Name){
            				case "kompas":
            					this.LastPathKompas = xnc.InnerText;
            					break;
            				case "mcad":
            					this.LastMathCadPath = xnc.InnerText;
            					break;
            			}
					}
            	//s1 = xn.SelectSingleNode("kompas").InnerText;
				//this.LastMathCadPath
				//s2 = xn.SelectSingleNode("mcad").InnerText;
				
            }
        	}
        	catch
        	{
        		MessageBox.Show("Ошибка в файле проекта", "Ошибка",
                   				 MessageBoxButtons.OK, MessageBoxIcon.Error);
        		return false;
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
        } // end OpenProject
        
        private bool SaveProject()
        {
        	string str1, str2, str3;
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
				 writer.WriteString(LastPathKompas);
				 writer.WriteEndElement(); // end kompas
				
				 
				 writer.WriteStartElement("mcad");
				 writer.WriteString(LastMathCadPath);
				 writer.WriteEndElement(); // end mathcad
				
				 writer.WriteEndElement(); // Конец file
			
				
				
				writer.WriteStartElement("table");
					for (int i = 0; i < this.TableMathCad.Rows.Count; i++)
                    {
                        str1 = this.TableMathCad.Rows[i].Cells[0].Value.ToString();
                        str2 = this.TableMathCad.Rows[i].Cells[4].Value.ToString();
                        str3 = this.TableMathCad.Rows[i].Cells[3].Value.ToString();
                        writer.WriteStartElement("TableTop");
						writer.WriteAttributeString("id", Convert.ToString(i + 1));
						writer.WriteAttributeString("name", str1);
						writer.WriteAttributeString("type", str3);
						writer.WriteString(str2);
						writer.WriteEndElement(); // конец тега TableTop
					}
				
					for (int j = 0; j < this.TableKompas3D.Rows.Count; j++)
					{
						str1 = this.TableKompas3D.Rows[j].Cells[0].Value.ToString();
						str2 = this.TableKompas3D.Rows[j].Cells[3].Value.ToString();
						writer.WriteStartElement("TableBottom");
						writer.WriteAttributeString("id", Convert.ToString(j + 1));
						writer.WriteAttributeString("name", str1);
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
        	Save = true;
			return Save;
        } // end SaveProject()

        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Exit_Kompas();
            Exit_MathCad();
            //(this.LastPathKompas.Count == 1) & (this.LastMathCadPath.Count == 1)
            if ((this.LastPathKompas.Length > 2) && (this.LastMathCadPath.Length > 2) && Save == false)
            {
                DialogResult reply = MessageBox.Show("Сохранить проект?",
                            "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (reply == DialogResult.Yes)
                    SaveProject();
            }
        }      

        #endregion
  		


        private void AddKompas_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.Filter = "КОМПАС-3D Документы (*.m3d;*.a3d)|*.m3d;*.a3d";
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                Save = false;
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
                Save = false;
                MathCadPath.Text = OpenFileDialog.FileName;
                LastMathCadPath = MathCadPath.Text;
                MathCadParser(LastMathCadPath, false);
                AddKompasCombo();
            }
            
        }

        private void Apply_Kompas_Click(object sender, EventArgs e)
        {
        	Save = false;
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

        private void Apply_MathCadClick(object sender, EventArgs e)
        {
            Save = false;
            if (LastMathCadPath == "")
                return;
            // Заносим значения переменных маткада из таблицы в файл
            MathCadParser(LastMathCadPath, true);
            // Инициализация маткада выполняется если маткад еще не запущен
            // Это функциия возвражает значение, ты упорно это игнорируешь
			if (InitMathCad() == null) return;

            // Открываем файл маткада, пересчитываем, заносим в таблицу вычисленные, закрываем
            OpenMathCad(LastMathCadPath, true);

            // Считываем значение из файла маткада в таблицу
            MathCadParser(LastMathCadPath, true);
            MathCadParser(LastMathCadPath, false);

            AddKompasCombo();
            // Просто открываем файл маткада
            OpenMathCad(LastMathCadPath, false);
        }

    
        private void Refresh_All_Click(object sender, EventArgs e)
        {
   			Save = false;
        	// Проверяеме открыт ли файл Маткада
            if (LastMathCadPath == "")
            {                
                MessageBox.Show("Откройте файл Маткада", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;            
            }

            // Проверяеме открыт ли файл Маткада
            if (LastPathKompas == "")
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
        
        void Save_ProjectClick(object sender, EventArgs e)
        {
        	if (  (this.LastPathKompas.Length > 2) && (this.LastMathCadPath.Length > 2) )
        	 	SaveProject();
        	else
        		MessageBox.Show("Нет данных для сохранения", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        	
        }       

        
        
        void LinkLabel1LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        	try{
        	 System.Diagnostics.Process.Start("mailto:o.kozintsev@googlemail.com");
        	}
        	catch{};
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
