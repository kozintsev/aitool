using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
            if (textBoxLogin.Text == "" || textBoxPwd.Text == "")
                return;
            if (!conn) return;
            if (cdb.Authorization(textBoxLogin.Text, textBoxPwd.Text))
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
        }
    }
}
