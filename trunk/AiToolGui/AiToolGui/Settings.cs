using System;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
using System.Data;
using System.Xml;

namespace AiToolGui
{
    [Serializable]
    public class Settings
    {
        // Настройки
        public string Host { get; set; }
        public string Port { get; set; }
        public string BaseName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Language { get; set; }
        public bool WindowsUser { get; set; }
        public bool SavePass { get; set; }        
        // Настройки

        private string appath = Application.StartupPath;
        private string optionspath = Application.StartupPath + "\\options.xml";

        public Settings()
        {
            if (!File.Exists(optionspath)) CreateSetting();            
        }

        public string GetLngText(string lng, string nameform)
        {
            return ParsingLangFile(lng, nameform);
        }
        public string GetLngText(string lng, string nameform, string name)
        {
            return ParsingLangFile(lng, nameform, name);
        }
        public void SetLanguage(string lng)
        {
            ParsingSetting("Language", lng, true);
        }

        public string GetLanguage()
        {
            return ParsingSetting("Language", "", false);
        }

        public string GetDataBaseLocal()
        {
            string pathbd = ParsingSetting("pathbd", "", false);
            if(File.Exists(pathbd))
                return pathbd;
            pathbd = appath + pathbd;
            if(File.Exists(pathbd))
                return pathbd;
            else pathbd = "";
            UserParam.LocalBDPath = pathbd;
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
                    ParsingSetting("pathbd", path, true);
                else
                    ParsingSetting("pathbd", pathdb, true);
            }
        }
        public string GetDataBaseType()
        {
            return ParsingSetting("dblocal", "", false);
        }
        public void SetDataBaseType(string typedblocal)
        {
                    ParsingSetting("dblocal", typedblocal, true);           
        }

        public string GetLogin()
        {
            return ParsingSetting("login", "", false);

        }

        public void SetLogin(string login)
        {
            ParsingSetting("login", login, true);
        }

        private string ParsingLangFile(string lng, string nameform)
        {
            XmlDocument doc = new XmlDocument();
            string temp = "";
            try
            {
                doc.Load(lng);
                XmlNodeList list = doc.DocumentElement.ChildNodes;
                foreach (XmlNode node in list)
                {
                    if (node.Name == nameform)
                    {
                        temp = node.Attributes["name"].Value;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!");
            }
            return temp;
        }
        private string ParsingLangFile(string lng, string nameform, string control)
        {
            XmlDocument doc = new XmlDocument();
            string temp = "";
            try
            {
                doc.Load(lng);
                XmlNodeList list = doc.DocumentElement.ChildNodes;
                foreach (XmlNode node in list)
                {
                    if (node.Name == nameform)
                    {                         
                        foreach(XmlNode n in node.ChildNodes)
                        {
                            if (control == n.Name) temp = n.InnerText;
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
        private string ParsingSetting(string str, string text, bool save)
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
                    writer.WriteStartElement("Language");
                    writer.WriteString("Russia");
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
