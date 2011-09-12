﻿using System;
using System.Collections;
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
        bool Save = false;
        
        class VarTopTable {
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
        private bool OpenFileKompas(string filename)
        {
            bool fileopen = false;
            if (kompas != null)
            {
                    doc3D = (ksDocument3D)kompas.Document3D();
                    
                    if (doc3D != null) fileopen = doc3D.Open(filename, false);
                    if (!fileopen)
                    {
                        MessageBox.Show("Не могу открыть файл", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    kompas.Visible = true;


                    int err = kompas.ksReturnResult();
                    if (err != 0) kompas.ksResultNULL();
                
            }
            else
            {
                MessageBox.Show(this, "Объект не захвачен", "Сообщение");
                return false;
            }
            return true;
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
                    //doc3D.GetPart
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
        private bool OpenMathCad(string Path, bool recal)
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
                return false;
            }
            return true;
        }
        // удалось распарсить файл SMathStudio версии 0.89
        // пока только чтение
        private void SMathStudioParser(string MathPath, bool save)
        {
            XmlDocument xd = new XmlDocument();
            try
            {
                xd.Load(MathPath);
            }
            catch
            {

                MessageBox.Show("Ошибка открытия файла SMathStudio", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                //XmlNodeList xnl = xd.DocumentElement.ChildNodes;
                if (save == false) this.TableMathCad.Rows.Clear();
                XmlNodeList list = xd.GetElementsByTagName("math");
                XmlNodeList xnl;
                string s1, s2, s3;
                s1 = "";
                s2 = "";
                s3 = "";
                foreach (XmlNode xn in list)
                {
                    //xn.InnerText
                    //if (xn.Name == "result")

                    //if (xn.Name != "input") break;
                    xnl = xn.ChildNodes;

                    for (int i = 0; i < xnl.Count; i++)
                    {
                        string s = xnl[i].Name;
                        if (xnl[i].Name == "input")
                        {
                            XmlNodeList inputs = xnl[i].ChildNodes;
                            XmlNode e;
                            for (int j = 0; j < inputs.Count; j++)
                            {
                                e = inputs[j];
                                if (j == 0 && e.Attributes[0].Value == "operand")
                                {
                                    s1 = e.InnerText;
                                }
                                if (j == 1 && e.Attributes[0].Value == "operand")
                                {
                                    s2 = e.InnerText;
                                    string a = s2.ToString().Replace('.', ',');
                                    Double n;
                                    if (!Double.TryParse(a, out n))
                                    {
                                        //обработка, если не число
                                        break;
                                        //MessageBox.Show(s2 + "не число");
                                    }
                                }
                                if (j == inputs.Count - 1 && e.Attributes[0].Value == "operator")
                                {
                                    s3 = e.InnerText;
                                    if (inputs.Count == 3 && s3 == "←")
                                        this.TableMathCad.Rows.Add(s1, s2, "Присвоенная", "1", "define");
                                    if (inputs.Count == 3 && s3 == "=")
                                        this.TableMathCad.Rows.Add(s1, s2, "Вычисленная", "1", "eval");
                                }

                            }
                        }
                        if (xnl[i].Name == "result")
                        {
                            //XmlNodeList result = xnl[i].ChildNodes[0];
                            XmlNode e = xnl[i].ChildNodes[0];
                            if (e.Attributes[0].Value == "operand")
                                s2 = e.InnerText;
                            this.TableMathCad.Rows.Add(s1, s2, "Вычисленная", "1", "eval");

                        }

                    }// for end

                }// end foreach
            }
            catch
            {
                MessageBox.Show("Ошибка при работе с файлом расчёта", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool MathCadParser(string MathPath, bool save)
        {
            // Обновляем таблицу Маткада
            int i = 0;
            string region_id;
            XmlDocument xd = new XmlDocument();
            try{
            xd.Load(MathPath);
            }
            catch{
            	return false;
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
                return false;
            }
            return true;
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
                this.KompasName_ComboBox.DataGridView.Rows[i].Cells[5].Value = this.KompasName_ComboBox.Items[0];
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
            double d;
            string a = s.ToString().Replace('.', ',');
			d = Convert.ToDouble(a);
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
                         "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    else
                    {
                        MC.Quit(MCSaveOption.mcDiscardChanges);
                        Marshal.ReleaseComObject(MC);
                    }
                    if (reply == DialogResult.Yes)
                    {
                        MC.Quit(MCSaveOption.mcSaveChanges);
                        Marshal.ReleaseComObject(MC);
                    }
            	}
            	catch
            	{
            		MessageBox.Show("MathCAD уже закрыт или не может быть закрыт", "Сообщение",
                   				 MessageBoxButtons.OK, MessageBoxIcon.Information);	
            	}
            	
            	       
            }
        }

        private bool OpenProject(string path)
        {
        	//string s;
        	//int i;
        	
        	FileInfo fileproject = new FileInfo(path);
        	string dirpath = fileproject.DirectoryName + "\\";
        	VarTop = new List<VarTopTable>();
        	VarBot = new List<VarBotTable>();
        	
        	VarTop.Clear();
        	VarBot.Clear();

       
      		
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
            			
            			//s = xnc.InnerText;
            			
            			switch(xnc.Name){
            				case "kompas":
            					this.LastPathKompas = dirpath + xnc.InnerText;
            					break;
            				case "mcad":
            					this.LastMathCadPath = dirpath + xnc.InnerText;
            					break;
            				case "TableTop":
            					VarTopTable VarT = new VarTopTable();
            					VarT.name = xnc.Attributes[1].Value;
            					VarT.type = xnc.Attributes[2].Value;
            					VarT.nameval = xnc.Attributes[3].Value;
            					VarT.val = xnc.InnerText;
            					VarTop.Add(VarT);
            					break;
            				case "TableBottom":
            					VarBotTable VarB = new VarBotTable();
            					VarB.name = xnc.Attributes[1].Value;
            					VarB.nameval = xnc.Attributes[2].Value;
            					VarB.val = xnc.InnerText;
            					VarBot.Add(VarB);
            					break;
            			}
					}				
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
        
        private bool SaveProject(string path)
        {
        	string str1, str2, str3, str4;
        	
        	if (!File.Exists(path))
        	{
        		SaveFileDialog SaveFileDialog = new SaveFileDialog();
        		SaveFileDialog.Filter  = "Документ XML (*.xml)|*.xml;";
        		if (SaveFileDialog.ShowDialog() != DialogResult.OK)
              		return false;
        		LastProjectPath = SaveFileDialog.FileName;
            	ProjectPath.Text = LastProjectPath;
        	}
        	
        	path = LastProjectPath;
        	
            FileInfo filekompas = new FileInfo(LastPathKompas);
            FileInfo filemcad = new FileInfo(LastMathCadPath);
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
					for (int i = 0; i < this.TableMathCad.Rows.Count; i++)
                    {
                        str1 = this.TableMathCad.Rows[i].Cells[0].Value.ToString();
                        str2 = this.TableMathCad.Rows[i].Cells[5].Value.ToString();
                        str3 = this.TableMathCad.Rows[i].Cells[4].Value.ToString();
                        str4 = this.TableMathCad.Rows[i].Cells[1].Value.ToString();
                        writer.WriteStartElement("TableTop");
						writer.WriteAttributeString("id", Convert.ToString(i + 1));
						writer.WriteAttributeString("name", str1);
						writer.WriteAttributeString("type", str3);
						writer.WriteAttributeString("val", str4);
						writer.WriteString(str2);
						writer.WriteEndElement(); // конец тега TableTop
					}
			
					for (int j = 0; j < this.TableKompas3D.Rows.Count; j++)
					{
						str1 = this.TableKompas3D.Rows[j].Cells[0].Value.ToString();
						str2 = this.TableKompas3D.Rows[j].Cells[3].Value.ToString();
						str3 = this.TableKompas3D.Rows[j].Cells[1].Value.ToString();
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
				MessageBox.Show("Проект не сохранён!\n" + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			finally
			{
				// закрываем файл
				if (writer != null) writer.Close();
			}
        	Save = true;
        	MessageBox.Show("Проект сохранён!",
        	                "Проект", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                		SaveProject(LastProjectPath);          
            }
        }   // MainForm_FormClosing   

        #endregion
  		


        private void AddKompas_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.Filter = "КОМПАС-3D Сборки (*.a3d)|*.a3d";
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                Save = false;
                // Активируем Компас-3D
            	if (!InitKompas()) return;
            	KompasPath.Text = OpenFileDialog.FileName;
                LastPathKompas = KompasPath.Text;
                // Открываем файл Компас-3D
                if (!OpenFileKompas(LastPathKompas))
                    return;
                KompasRefresh();
                AddMathCadCombo();
                AddKompasCombo();
            }

        }

        private void AddMathCad_Click(object sender, EventArgs e)
        {
        	// Открываем файл Маткада
            OpenFileDialog OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.Filter = "All supported(*.xmcd;*.sm)|*.xmcd;*.sm|Файлы MathCAD 14 (*.xmcd)|*.xmcd|Файлы SMath Studio (*.sm)|*.sm|All Files|*.*";
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                Save = false;
                MathCadPath.Text = OpenFileDialog.FileName;
                LastMathCadPath = MathCadPath.Text;        
                string s = Path.GetExtension(OpenFileDialog.SafeFileName);
                switch (s)
                {
                    case ".xmcd":
                        MathCadParser(LastMathCadPath, false);
                        break;
                    case ".sm":
                        SMathStudioParser(LastMathCadPath, false);                     
                        Settings st = new Settings();
                        string programstart = st.GetSMathPath();
                        if (programstart != "")
                        //programstart +=   "\"" + LastMathCadPath + "\"";
                        System.Diagnostics.Process.Start(programstart, LastMathCadPath);
                        else
                            MessageBox.Show("Не указан путь к SMathStudio\nЗапуск не возможен", "Информация",
                                 MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }
              
                AddMathCadCombo();
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
            if (Path.GetExtension(LastMathCadPath) != ".xmcd")
            {
                MessageBox.Show("Пересчёт возможен только для файлов MathCAD", "Сообщение",
                                 MessageBoxButtons.OK, MessageBoxIcon.Information);
                return; // для не маткад файла пересчёт не возможен
            }
            // Заносим значения переменных маткада из таблицы в файл
            if (TableMathCad.RowCount == 0)
            {
                MessageBox.Show("Нет данных для сохранения", "Сообщение",
                                 MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!MathCadParser(LastMathCadPath, true))
                return;
            // Инициализация маткада выполняется если маткад еще не запущен
            // Это функциия возвражает значение
			if (InitMathCad() == null) return;

            // Открываем файл маткада, пересчитываем, заносим в таблицу вычисленные, закрываем
            if (!OpenMathCad(LastMathCadPath, true))
                return;

            // Считываем значение из файла маткада в таблицу
            if (!MathCadParser(LastMathCadPath, true)) return;
            if (!MathCadParser(LastMathCadPath, false)) return;

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
            // Обновляем таблицу Маткада
            MathCadParser(MathCadPath.Text, false);
            
            AddMathCadCombo();
            AddKompasCombo();           

        }


        
        void Open_ProjectClick(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.Filter = "Документ XML (*.xml)|*.xml;";
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                LastProjectPath = OpenFileDialog.FileName;
                FileInfo file = new FileInfo(LastProjectPath);
                string filepath = file.DirectoryName;
                ProjectPath.Text = LastProjectPath;
                if ( !OpenProject(LastProjectPath) ) return;
                
                // Активируем Компас-3D
 				if (!InitKompas()) return;
				// Открываем файл Компас-3D
				if (!OpenFileKompas(LastPathKompas))
                    return;
				KompasRefresh();
 				if (!MathCadParser(LastMathCadPath, false))
                    return;
 				AddMathCadCombo();
 				AddKompasCombo();
                Save = true;
 				// устанавливаем значения в верхней таблицы
 				if (TableMathCad.RowCount != VarTop.Count)
 					return;
 				if (TableKompas3D.RowCount != VarBot.Count)
 					return;
 				try{
 				//верхная таблица
 				for (int i = 0; i < TableMathCad.RowCount; i++)
 				{
 					this.TableMathCad.Rows[i].Cells[1].Value = VarTop[i].nameval;
 					this.KompasName_ComboBox.DataGridView.Rows[i].Cells[5].Value = VarTop[i].val;
            	}
 				//нижная таблица
 				for (int j = 0; j < TableKompas3D.RowCount; j++)
 				{
 					//if (this.TableKompas3D.Rows[j].Cells[1].Value.ToString() == VarBot[j].name) // если имена совпадают
 					//{
 						this.TableKompas3D.Rows[j].Cells[1].Value = VarBot[j].nameval;
 						this.MathCadName_ComboBox.DataGridView.Rows[j].Cells[3].Value = VarBot[j].val;
 					//}
 				}
 				}
 				catch{
 					MessageBox.Show("Ошибка при востановлении связей", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
 				}
            }
        	
        }          
        
        void Save_ProjectClick(object sender, EventArgs e)
        {
        	if (  (this.LastPathKompas.Length > 2) && (this.LastMathCadPath.Length > 2) )
        	{
        	 	SaveProject(LastProjectPath);
        	}
        	else
        		MessageBox.Show("Нет данных для сохранения", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        	
        } //     Save_ProjectClick  
        
        void SaveAsClick(object sender, EventArgs e)
        {
        	if (  (this.LastPathKompas.Length > 2) && (this.LastMathCadPath.Length > 2) )
        	{
        	 	SaveProject("");
        	}
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
            object obj;
            int i;

            if (e.ColumnIndex == 3)
            {
                 obj = this.TableKompas3D.Rows[e.RowIndex].Cells[3].Value;
                 if (obj == null)
                     return;
                 i = MathCadName_ComboBox.Items.IndexOf(obj) - 1;
                 if (i == -1)
                     return;
                 this.TableKompas3D.Rows[e.RowIndex].Cells[1].Value =
                     this.TableMathCad.Rows[i].Cells[1].Value;
            }
                this.TableKompas3D.Update();
        }
        
        void TableMathCadCellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            object obj;
            int i;
            if (e.ColumnIndex == 5)
            {
                 obj = this.TableMathCad.Rows[e.RowIndex].Cells[5].Value;
                 if (obj == null)
                      return;
                 i = KompasName_ComboBox.Items.IndexOf(obj) - 1;
                 if (i == -1)
                     return;
                 this.TableMathCad.Rows[e.RowIndex].Cells[1].Value =
                     this.TableKompas3D.Rows[i].Cells[1].Value;
            }          
            this.TableMathCad.Update();
        }
       
    }
}
