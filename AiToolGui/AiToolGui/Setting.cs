using System;
using System.Windows.Forms;
using System.IO;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
using System.Data;
using System.Xml;

namespace AiToolGui
{
    public class Setting
    {
        string appath = Application.StartupPath;
        string optionspath = Application.StartupPath + "\\options.xml";

        public Setting()
        {
            if (!File.Exists(optionspath)) CreateSetting();            
        }
        
        public string GetDataBase()
        {
            XmlDocument doc = new XmlDocument();
            string pathbd = "";
            try
            {
                doc.Load(optionspath);
                XmlNodeList setting = doc.DocumentElement.ChildNodes;
                //pathbd = setting.Item(0).InnerText;
                foreach (XmlNode str in setting)
                {
                    if (str.Name == "pathbd") pathbd = appath + str.InnerText;
                    //pathbd = str.SelectSingleNode("pathbd").InnerText;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!");
            }
            return pathbd;
        }

        public void SaveDataBaseType()
        {

        }

        public void SaveDataBasePath()
        {

        }

        public void CreateSetting()
        {
            // начинаем сохранять
            XmlTextWriter writer = null;
            try
            {
                // создаем класс для сохранения XML
                writer = new XmlTextWriter(optionspath, System.Text.Encoding.UTF8);
                // форматирование, чтобы файл не был вытянут в одну линию
                writer.Formatting = Formatting.Indented;

                // пишем заголовок и корневой элемент
                writer.WriteStartDocument();
                writer.WriteStartElement("setting");             
                    writer.WriteStartElement("pathbd");
                    writer.WriteString("\\Base\\aitool.mdb");
                    writer.WriteEndElement();                               
                // закрываем корневой элемент и завершаем работу с документом
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error!");
            }
            finally
            {
                // закрываем файл
                if (writer != null) writer.Close();
            }
        }

    }
}
