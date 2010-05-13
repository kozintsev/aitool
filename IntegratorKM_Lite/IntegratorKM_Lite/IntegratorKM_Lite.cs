using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

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

namespace IntegratorKM_Lite
{
    public partial class IntegratorKM_Lite : Form
    {
        public IntegratorKM_Lite()
        {
            InitializeComponent();
        }

        #region Custom declarations

        private KompasObject kompas;
        private ksDocument3D doc3D;
        private string LastPathKompas = "";
        private string LastMathCadPath = "";

        private Mathcad.Application MC;
        private Mathcad.Worksheets WK;
        private Mathcad.Worksheet WS;

        #endregion

        
        #region Custom functions
        

        private void InitKompas()
        {
            if (kompas == null)
            {

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
                }
            }
            
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
            // Очищаем таблицу внешних переменных Компас-3D от предыдущих результатов
            this.TableKompas3D.Rows.Clear();           

            // Очищаем комбо-бокс-столбцы в таблице внешних переменных Компас-3D
            this.MathCadName_ComboBox_IN.Items.Clear();
            this.MathCadName_ComboBox_OUT.Items.Clear();


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


        private void InitMathCad()
        {
            if (MC == null)
            {

                try
                {
                    MC = new Mathcad.Application();
                }
                catch
                {
                    MessageBox.Show("MathCAD не установлен.", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            
        }               
        private void OpenFileMathCad(string filename)
        {
            if (MC != null)
            {
                WK = MC.Worksheets;
                for (int i = 0; i < WK.Count; i++)
                {
                    WS = WK.Item(i);
                    if (WS.FullName == filename)
                        WS.Close(MCSaveOption.mcSaveChanges);
                }
                if (WK != null) WS = WK.Open(filename);
                MC.Visible = true;                
     
            }
            else
            {
            	MessageBox.Show(this, "Объект не захвачен", "Сообщение");
            }
            
        }
        private void MathCadRefresh()
        {            

            // Очищаем таблицы внешних переменных Маткада от предыдущих результатов
            this.TableMathCad_IN.Rows.Clear();
            this.TableMathCad_OUT.Rows.Clear();

            // Очищаем комбо-бокс-столбцы в таблице внешних переменных Компас-3D
            this.MathCadName_ComboBox_IN.Items.Clear();
            this.MathCadName_ComboBox_OUT.Items.Clear();


            if (MC != null)
                if (WS != null)
                {                   
                    
                    for (int j = 0; j < 50; j++)
                    {                        
                        {
                            string name;
                            name = "in" + j;
                            string value;
                            try
                            {
                                value = (WS.GetValue(name) as NumericValue).Real.ToString();
                                this.TableMathCad_IN.Rows.Add(name, value);
                            }

                            catch(Exception)
                            {
                                continue;
                            }
                        }

                    }

                    for (int j = 0; j < 50; j++)
                    {
                            string name;
                            name = "out" + j;
                            string value;
                            try 
                            {
                                value = (WS.GetValue(name) as NumericValue).Real.ToString();
                                this.TableMathCad_OUT.Rows.Add(name, value); 
                            }
                            catch(Exception)
                            {
                                continue;
                            }

                             
                    }
            }
            else
            {
                MessageBox.Show(this, "Объект не захвачен", "Сообщение");
            }
        }

        
        private void Clear_All()
        {
            // Очищаем таблицу внешних переменных Компас-3D от предыдущих результатов
            this.TableKompas3D.Rows.Clear();

            // Очищаем таблицы внешних переменных Маткада от предыдущих результатов
            this.TableMathCad_IN.Rows.Clear();
            this.TableMathCad_OUT.Rows.Clear();            

            // Очищаем комбо-бокс-столбцы в таблице внешних переменных Компас-3D
            this.MathCadName_ComboBox_IN.Items.Clear();
            this.MathCadName_ComboBox_OUT.Items.Clear();
            
        }                         
        private void AddKompasCombo()
        {
            //Очищаем и добавляем нулевой элемент в комбобоксы у нижней таблице TableKompas3D
            this.MathCadName_ComboBox_IN.Items.Clear();
        	this.MathCadName_ComboBox_IN.Items.Add("пусто");
            this.MathCadName_ComboBox_OUT.Items.Clear();
            this.MathCadName_ComboBox_OUT.Items.Add("пусто");

            //заполняем комбобокс IN у нижней таблице TableKompas3D
        	for (int j = 0; j < TableMathCad_IN.Rows.Count; j++)
        	{
        		this.MathCadName_ComboBox_IN.Items.Add(this.TableMathCad_IN.Rows[j].Cells[0].Value.ToString());
        	}            

            //заполняем комбобокс OUT у нижней таблице TableKompas3D
            for (int j = 0; j < TableMathCad_OUT.Rows.Count; j++)
            {
                this.MathCadName_ComboBox_OUT.Items.Add(this.TableMathCad_OUT.Rows[j].Cells[0].Value.ToString());
            }

            // Выбираем нулевой элемент для каждой ячейки в комбо-бокс-столбце IN 
            // в таблице внешних переменных Компас-3D
            for (int i = 0; i < TableKompas3D.Rows.Count; i++)
            {
                this.MathCadName_ComboBox_IN.DataGridView.Rows[i].Cells[3].Value = this.MathCadName_ComboBox_IN.Items[0];
            }

        	// Выбираем нулевой элемент для каждой ячейки в комбо-бокс-столбце OUT
            // в таблице внешних переменных Компас-3D
            for (int i = 0; i < TableKompas3D.Rows.Count; i++)
            {
                this.MathCadName_ComboBox_OUT.DataGridView.Rows[i].Cells[4].Value = this.MathCadName_ComboBox_OUT.Items[0];
            }
        }       
        private double ConverToDouble(string s)
        {
          	 string ns = "";
			 int j = 0;
			 bool start = false;
        	 double d;           	 
         	 
			for (int i = 0; i< s.Length; i++)
			{
				if ( (s[i] == '.') || (s[i] == ',') ) start = true;
				if (start) j++;
				if (j > 3) break;
				if (s[i] == '.' ) ns = Name + ',';
					else ns = ns + s[i];
			}
			d = Convert.ToDouble(ns);			
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
                    DialogResult reply = DialogResult.No;
                    if (kompas.Visible == true) reply = MessageBox.Show("Закрыть Kompas?",
                         "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    else kompas.Quit();
            		if (reply == DialogResult.Yes) kompas.Quit();
            	}
            	catch
            	{
            		MessageBox.Show("Kompas уже закрыт или не может быть закрыт", "Сообщение",
                   				 MessageBoxButtons.OK, MessageBoxIcon.Information);
            	}
            	finally
            	{            	 
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
        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Exit_Kompas();
            Exit_MathCad();           
        }      

        #endregion
  		


        private void AddKompas_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.Filter = "КОМПАС-3D Документы (*.m3d;*.a3d)|*.m3d;*.a3d";
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {                
                // Активируем Компас-3D
            	InitKompas();
                if (doc3D != null) doc3D.close();
            	KompasPath.Text = OpenFileDialog.FileName;
                LastPathKompas = KompasPath.Text;
                // Открываем файл Компас-3D
                OpenFileKompas(LastPathKompas);


                KompasRefresh();
                AddKompasCombo();
                
            }

        }

        private void AddMathCad_Click(object sender, EventArgs e)
        {
        	// Открываем файл Маткада
            OpenFileDialog OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.Filter = "Файлы MathCAD 14 (*.xmcd)|*.xmcd";
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Активируем Маткад
                InitMathCad();  
                
                MathCadPath.Text = OpenFileDialog.FileName;
                LastMathCadPath = MathCadPath.Text;
                // Открываем файл Компас-3D
                OpenFileMathCad(LastMathCadPath);                

                MathCadRefresh();                
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
                                    g = ConverToDouble(d);                            
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

        private void Apply_MathCad_Click(object sender, EventArgs e)
        {
            if (MC != null)
                if (WS != null)
                {
                    for (int j = 0; j < this.TableMathCad_IN.Rows.Count; j++)
                    {
                        
                        try
                        {
                            string name;
                            name = this.TableMathCad_IN.Rows[j].Cells[0].Value.ToString();
                            string value;
                            value = this.TableMathCad_IN.Rows[j].Cells[1].Value.ToString();
                            double var;
                            var = ConverToDouble(value);
                            WS.SetValue(name, var);
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                    }

                    WS.Recalculate();

                    WS.Save();
                        

                        for (int i = 0; i < this.TableMathCad_OUT.Rows.Count; i++)
                        {  
                            try
                            {
                                string name1;
                                name1 = this.TableMathCad_OUT.Rows[i].Cells[0].Value.ToString();
                                string value1;
                                value1 = (WS.GetValue(name1) as NumericValue).Real.ToString();                                
                                this.TableMathCad_OUT.Rows[i].Cells[1].Value = value1;
                            }

                            catch (Exception)
                            {
                                continue;
                            }
                            
                        }

                      
                    //Очищаем комбо-бокс-столбцы в таблице внешних переменных Компас-3D                        
                    this.MathCadName_ComboBox_OUT.Items.Clear();
                    AddKompasCombo();



                        
                    }

            else
                {
                    MessageBox.Show(this, "Объект не захвачен", "Сообщение");
                }
            
        }         

        

    
        private void Refresh_All_Click(object sender, EventArgs e)
        {
   			
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

            // Обновляем таблицы Маткада
            MathCadRefresh();

            // Обновляем таблицу Маткада            
            AddKompasCombo();           

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
                {                  

                    
                        this.TableKompas3D.Rows[e.RowIndex].Cells[1].Value =
                            this.TableMathCad_IN.Rows[MathCadName_ComboBox_IN.Items.IndexOf(
                                this.TableKompas3D.Rows[e.RowIndex].Cells[3].Value) - 1].Cells[1].Value;

                        this.MathCadName_ComboBox_OUT.DataGridView.Rows[e.RowIndex].Cells[4].Value = this.MathCadName_ComboBox_OUT.Items[0];
                    
                }

                if (e.ColumnIndex == 4)
                {


                    this.TableKompas3D.Rows[e.RowIndex].Cells[1].Value =
                        this.TableMathCad_OUT.Rows[MathCadName_ComboBox_OUT.Items.IndexOf(
                            this.TableKompas3D.Rows[e.RowIndex].Cells[4].Value) - 1].Cells[1].Value;

                    this.MathCadName_ComboBox_IN.DataGridView.Rows[e.RowIndex].Cells[3].Value = this.MathCadName_ComboBox_IN.Items[0];
                }
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
  

