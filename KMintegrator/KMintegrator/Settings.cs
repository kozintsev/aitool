using System;
using System.Windows.Forms;
//using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Xml;

namespace KMintegrator
{
    class Settings
    {
        string appath = Application.StartupPath;
        string optionspath = Application.StartupPath + "\\config.xml";
        
        public Settings()
        {
            if (!File.Exists(optionspath)) CreateSetting(); 
        }

        public string GetSMathPath()
        {
            XmlDocument doc = new XmlDocument();
            string path = "";
            try
            {
                doc.Load(optionspath);
                XmlNodeList config = doc.GetElementsByTagName("math");
                //path = config.Item(0).InnerText;
               
                foreach (XmlNode str in config)
                {
                    if (str.Name == "math") path= str.InnerText;
                }
                
                if (File.Exists(appath + path))
                    path = appath + path;
                if (File.Exists(appath + "\\" + path))
                    path = appath + "\\" +  path;
                if (!File.Exists(path)) path = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!");
            }
            return path;
        }


        public void CreateSetting()
        {
            // начинаем сохранять
            XmlTextWriter writer = null;
            try
            {
                // создаем класс для сохранения XML
                writer = new XmlTextWriter(optionspath, Encoding.UTF8);
                // форматирование, чтобы файл не был вытянут в одну линию
                writer.Formatting = Formatting.Indented;

                // пишем заголовок и корневой элемент
                writer.WriteStartDocument();
                writer.WriteStartElement("config");
                writer.WriteStartElement("math");
                writer.WriteString("c:\\Program Files\\SMathStudioDesktop\\SMathStudio_Desktop.exe");
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
