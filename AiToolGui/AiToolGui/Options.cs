using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

namespace AiToolGui
{
    public partial class Options : Form
    {
        private string optionspath = Application.StartupPath + "\\options2.xml";
        public Options()
        {
            InitializeComponent();
            FileStream fsin = new FileStream(Global.OptionsPath, FileMode.Open, FileAccess.Read);
            XmlSerializer serializerin = new XmlSerializer(typeof(Settings), new Type[] { typeof(Settings) });
            Settings setting = new Settings();
            setting = (Settings)serializerin.Deserialize(fsin);
            txtBoxHost.Text = setting.Host;
            numericPort.Value = Convert.ToDecimal(setting.Port);
            txtBoxBaseName.Text = setting.BaseName;
            txtUserName.Text = setting.UserName;
            txtBoxPwd.Text = setting.Password;
            checkWindowsUser.Checked = setting.WindowsUser;
            checkSavePass.Checked = setting.SavePass;
            fsin.Close();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            //Сохранить настройки
            Settings setting = new Settings();
            setting.Host = txtBoxHost.Text;
            setting.Port = numericPort.Value.ToString();
            setting.BaseName = txtBoxBaseName.Text;
            setting.UserName = txtUserName.Text;
            setting.Password = txtBoxPwd.Text;
            setting.WindowsUser = checkWindowsUser.Checked;
            setting.SavePass = checkSavePass.Checked;

            FileStream fsout = new FileStream(Global.OptionsPath, FileMode.Create, FileAccess.Write);
            XmlSerializer serializerout = new XmlSerializer(typeof(Settings), new Type[] { typeof(Settings) });
            serializerout.Serialize(fsout, setting);
            fsout.Close();

        }

        private void Options_FormClosed(object sender, FormClosedEventArgs e)
        {
       
        }

        //private void AddAccess_Click(object sender, EventArgs e)
        //{
            
        //}

        //private void LocalBaseType_SelectedIndexChanged(object sender, EventArgs e)
        //{
            //Microsoft.Jet.OLEDB.4.0
            //
        //}
    }
}
