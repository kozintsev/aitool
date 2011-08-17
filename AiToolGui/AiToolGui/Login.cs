using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace AiToolGui
{
    public partial class Login : Form
    {
        private Settings sett;
        private ConnectDataBase cdb;
        private bool conn = false;
        public event EventHandler Status;
        public Login()
        {
            InitializeComponent();
            sett = new Settings();
            textBoxLogin.Text = sett.GetLogin();
            cdb = new ConnectDataBase();
            conn = cdb.CreateConnectDataBase(); // подключились или нет?
            if (textBoxLogin.Text != "")
            {
                textBoxPwd.Focus();
                textBoxPwd.Select();
            }
        }

        private bool openProgram = false;
        public bool OpenProgram
        {
            get
            {
                return openProgram;
            }
            set
            {
                openProgram = value;
            }
        }

        protected virtual void OnStatus(string s)
        {
            object Obj = s;
            if (Status != null)
                Status(Obj, EventArgs.Empty);
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            openProgram = false;
            Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            Go();
        }
        private bool Go()
        {
            if (textBoxLogin.Text == "" || textBoxPwd.Text == "")
                return false;
            if (!conn) return false;
            string pass = MD5Hash(textBoxPwd.Text.Trim());
            if (cdb.Authorization(textBoxLogin.Text, pass))
            {
                openProgram = true; // если пароль и логин верны
                sett.SetLogin(textBoxLogin.Text); // если всё окей сохраняем имя пользователя
                cdb.GetRoleName();
                cdb.CloseConnectDataBase(); // закрыть соединение с базой данных
                UserParam.StatusText = String.Format("Имя пользователя:{0}, Полное имя: {1} , Роль: {2}, База данных подключена",
                    UserParam.Username, UserParam.Fullname, UserParam.Rolename);
                OnStatus(UserParam.StatusText);
                Close();
            }
            return true;
        }
        private void textBoxPwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                Go();
            }
        }

        private void textBoxLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                textBoxPwd.Focus();
                textBoxPwd.Select();
            }
        }
        private string MD5Hash(string instr)
        {
            string strHash = string.Empty;

            foreach (byte b in new MD5CryptoServiceProvider().ComputeHash(Encoding.Default.GetBytes(instr)))
            {
                strHash += b.ToString("X2");
            }
            return strHash;
        } 

    }
}
