using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Kompas6Constants;
using Kompas6Constants3D;

//Alternative Type - Full or LT
#if (__LIGHT_VERSION__)
using Kompas6LTAPI5;
#else
using Kompas6API5;
#endif

using KAPITypes;




namespace CC_Cdiez

{
   
    
    public partial class ExVarCompass3D : Form
    {
        public ExVarCompass3D()
        {
            InitializeComponent();
        }

        #region Custom declarations
		private KompasObject kompas;
        private ksDocument3D doc3D;
        private string LastPathCompass;
        #endregion

        // Активируем Компас-3D
        private void ActiveCompass()
        {
            if (kompas == null)
            {
                #region Alternative Type
                #if __LIGHT_VERSION__
			    Type t = Type.GetTypeFromProgID("KOMPASLT.Application.5");
                #else
                Type t = Type.GetTypeFromProgID("KOMPAS.Application.5");
                #endif
                #endregion

                kompas = (KompasObject)Activator.CreateInstance(t);
            }

        }        

        // Открываем файл Компас-3D
        private void OpenFileCompass()
        {
            if (kompas != null)
            {
                OpenFileDialog OpenFileDialog = new OpenFileDialog();

                OpenFileDialog.Filter = "КОМПАС-3D Документы (*.m3d;*.a3d)|*.m3d;*.a3d";
                if (OpenFileDialog.ShowDialog() == DialogResult.OK)
                {

                    CompassPath.Text = OpenFileDialog.FileName;
                    LastPathCompass = CompassPath.Text;

                    doc3D = (ksDocument3D)kompas.Document3D();
                    if (doc3D != null) doc3D.Open(OpenFileDialog.FileName, false);

                    // Делаем Компас-3D видимым
                    kompas.Visible = true;


                    int err = kompas.ksReturnResult();
                    if (err != 0) kompas.ksResultNULL();
                }
            }
            else
            {
                MessageBox.Show(this, "Объект не захвачен", "Сообщение");
            }
        }       

        private void StartCompass_Click(object sender, EventArgs e)
        {
            ActiveCompass();

            OpenFileCompass();            

        }

        // Закрываем Компас-3D, закрываем форму
        private void Exit_Click(object sender, EventArgs e)
        {
            if (kompas != null)
            {
                kompas.Quit();
                Marshal.ReleaseComObject(kompas);
            }

            Close();

        }       

        private void Compass_EV_Read_Click(object sender, EventArgs e)
        {           

            if (kompas != null)
            {
                kompas.Visible = true;
                if (doc3D != null)
                {

                    if (doc3D.IsDetail())
                    {
                        kompas.ksError("Текущий документ должен быть сборкой");
                        return;
                    }
                    ksPart part = (ksPart)doc3D.GetPart(-1);	// Выбор компонента -1 главный, 0 первый
                    if (part != null)
                    {
                        // Работа с массивом внешних переменных
                        ksVariableCollection varCol = (ksVariableCollection)part.VariableCollection();
                        if (varCol != null)
                        {
                            ksVariable var = (ksVariable)kompas.GetParamStruct((short)StructType2DEnum.ko_VariableParam);
                            if (var == null) return;

                            this.TableCompassEV.Rows.Clear();

                            for (int j = 0; j < varCol.GetCount(); j++)
                            {
                                // Считывание переменных с записью в таблицу
                                var = (ksVariable)varCol.GetByIndex(j);
                                this.TableCompassEV.Rows.Add(var.name, var.value, var.note);
                            }

                        }
                    }
                }

            }
        }

        private void Compass_EV_Write_Click(object sender, EventArgs e)
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
                    ksPart part = (ksPart)doc3D.GetPart(-1);    // Выбор компонента -1 главный, 0 первый
                    if (part != null)
                    {
                        // Работа с массивом внешних переменных
                        ksVariableCollection varCol = (ksVariableCollection)part.VariableCollection();
                        if (varCol != null)
                        {
                            // Запись внешних переменных в компас
                            ksVariable var = (ksVariable)kompas.GetParamStruct((short)StructType2DEnum.ko_VariableParam);
                            if (var == null) return;

                            string d;
                            double g;

                            for (int i = 0; i < varCol.GetCount(); i++)
                            {

                                var = (ksVariable)varCol.GetByIndex(i);

                                d = (string)(this.TableCompassEV.Rows[i].Cells[1].Value.ToString());
                                g = Convert.ToDouble(d);
                                var.value = g;
                            }

                            //Перестроение сборки, почемуто не работает
                            part.RebuildModel();

                        }
                    }
                }
            }
        }

        // Перестроение с подвыпердовертом - сохраняем файл сборки, подтверждаем перестроение,
        // сохраняем, открываем файл - видим перестроенную сборку.
        private void RebuildCompass_Click(object sender, EventArgs e)
        {
            if (kompas != null)
            {
                
                if (doc3D != null)
                {
                    doc3D.Save();
                    doc3D.close();
                    doc3D = (ksDocument3D)kompas.Document3D();
                    if (doc3D != null) doc3D.Open(LastPathCompass, false);
                }

            }
        }

        

              

       

        

        






  }
}

        

        

        

