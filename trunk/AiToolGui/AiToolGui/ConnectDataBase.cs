/*
 * Created by SharpDevelop.
 * User: Oleg
 * Date: 13.03.2011
 * Time: 13:49
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Windows.Forms;
using System.Data.OleDb;// пространство имён для подключение к БД 
using System.Collections.Generic;

namespace AiToolGui
{
	/// <summary>
    /// Description of ConnectDataBase.
	/// </summary>
	public class ConnectDataBase
	{
        private Settings sett;

        private OleDbConnection connLocal;
        public OleDbConnection ConnLocal
        {
            get
            {
                return connLocal;
            }
        }

        private OleDbConnection connServ;
        public OleDbConnection ConnServ
        {
            get
            {
                return connServ;
            }
        }
        public ConnectDataBase()
		{
            sett = new Settings();
		}

		public bool CreateConnectDataBase()
		{
            string ConnectionString;
            string FileBD = sett.GetDataBaseLocal();
            if (!File.Exists(FileBD))
            {
                MessageBox.Show("Файл базы данных отсутствует", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + FileBD;
            try
            {
                connLocal = new OleDbConnection();
                connLocal.ConnectionString = ConnectionString;
                connLocal.Open();
            }
            catch
            {
                MessageBox.Show("Ошибка подключения к локальной базе данных", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
   
                ConnectionString = @"Data Source=MSSQL1;Initial Catalog=AdventureWorks;"
        + "Integrated Security=true;";

			return true;
		}
        // ввод имени пользователя и пароля
        public bool CreateConnectDataBase(string serv, string dbname, string login, string password)
        {
            string ConnectionString = String.Format(@"Data Source={0};Initial Catalog={0};"
                 + "Integrated Security=false;User ID={0};Password={0}", serv, dbname, login, password);
            try
            {
                connServ = new OleDbConnection();
                connServ.ConnectionString = ConnectionString;
                connServ.Open();
            }
            catch
            {
                MessageBox.Show("Ошибка подключения к База данных", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        public bool CreateConnectDataBase(string serv, string dbname) // соединение если учётная запись Windows
        {
            string ConnectionString = String.Format(@"Data Source={0};Initial Catalog={0};"
                + "Integrated Security=true;", serv, dbname);
            try
            {
                connServ = new OleDbConnection();
                connServ.ConnectionString = ConnectionString;
                connServ.Open();
            }
            catch
            {
                MessageBox.Show("Ошибка подключения к База данных", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
      
            
        public void CloseConnectDataBase()
        {
            if (connLocal != null)
                connLocal.Close();
        }
        public void GetRoleName()
        {
            string str = String.Empty;
            OleDbCommand command = connLocal.CreateCommand();
            command.CommandText = "SELECT * FROM Roles WHERE id_role=" + UserParam.Role.ToString();
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                UserParam.Rolename = reader["role"].ToString().TrimEnd();
            }
            reader.Close();
        }
        public bool Authorization(string login, string pwd)
        {
            bool auth = false;
            string idrole = String.Empty; ;
            //UserParam usrPrm = new UserParam() ;
            //List<UserParam> userList = List<UserParam>();
            OleDbCommand command = connLocal.CreateCommand();
            command.CommandText = "SELECT * FROM Users WHERE username='" + login.TrimEnd() + "'";
            OleDbDataReader reader = command.ExecuteReader();
            do
            {
                while (reader.Read())
                {
                    
                    UserParam.Username = reader["username"].ToString().TrimEnd();
                    UserParam.Password = reader["password"].ToString().TrimEnd();
                    UserParam.Fullname = reader["fullname"].ToString().TrimEnd();
                    idrole = reader["id_role"].ToString().Trim();
                    UserParam.Role = Convert.ToInt16(idrole);
                    
                    if (login == UserParam.Username && pwd == UserParam.Password)
                        auth = true;
                    //userList.Add(usrPrm);
                    //ListViewItem item = listView1.Items.Add(reader["username"].ToString().TrimEnd());
                    //item.SubItems.Add(reader.GetValue(NAME_INDEX).ToString().TrimEnd());
                    //item.SubItems.Add(reader.GetDateTime(3).ToLongDateString());
                    //item.SubItems.Add(reader.GetValue(4).ToString());
                }
            } while (reader.NextResult());
            reader.Close();
            return auth;
        }

	}
}
