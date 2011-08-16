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
    public class Settings
    {
        private string appath = Application.StartupPath;
        private string optionspath = Application.StartupPath + "\\options.xml";

        public Settings()
        {
            if (!File.Exists(optionspath)) CreateSetting();            
        }
        
        public string GetDataBaseLocal()
        {
            string pathbd = DataBase("pathbd", "", false);
            if(File.Exists(pathbd))
                return pathbd;
            pathbd = appath + pathbd;
            if(File.Exists(pathbd))
                return pathbd;
            else pathbd = "";
            return pathbd;
        }

        public void SetDataBaseLocal(string pathdb)
        {
            string str, path;
            if (File.Exists(pathdb))
            {
                path = "\\" + pathdb.TrimStart(appath.ToCharArray());
                str = appath + path;
                if (File.Exists(str))
                    DataBase("pathbd", path, true);
                else
                    DataBase("pathbd", pathdb, true);
            }
        }

        public string GetLogin()
        {
            return DataBase("login", "", false);

        }

        public void SetLogin(string login)
        {
            DataBase("login", login, true);
        }

        private string DataBase(string str, string text ,bool save)
        {
            XmlDocument doc = new XmlDocument();
            string temp = "";
            try
            {
                doc.Load(optionspath);
                XmlNodeList setting = doc.DocumentElement.ChildNodes;
                foreach (XmlNode node in setting)
                {
                    if (node.Name == str)
                    {

                        if (save)
                        {
                            node.InnerText = text;
                            doc.Save(optionspath);
                        }
                        else
                        {
                            temp = node.InnerText;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!");
            }
            return temp;
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
                    writer.WriteStartElement("login");
                    writer.WriteString("");
                    writer.WriteEndElement();
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
