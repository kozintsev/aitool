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

        private OleDbConnection conn;
        public OleDbConnection Conn
        {
            get
            {
                return conn;
            }
        }
        public ConnectDataBase()
		{
            sett = new Settings();
		}

		public bool CreateConnectDataBase()
		{
            string FileBD = sett.GetDataBase();
            if (!File.Exists(FileBD))
            {
                MessageBox.Show("Файл базы данных отсутствует", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            string ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + FileBD;
			try{
			 conn = new OleDbConnection();
             conn.ConnectionString = ConnectionString;
             conn.Open();
			}
			catch{
				MessageBox.Show("Ошибка подключения к База данных", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			return true;
		}

        public void CloseConnectDataBase()
        {
            if (conn != null)
                conn.Close();
        }

        public bool Authorization(string login, string pwd)
        {
            bool auth = false;
            //UserParam usrPrm = new UserParam() ;
            //List<UserParam> userList = List<UserParam>();
            OleDbCommand command = conn.CreateCommand();
            command.CommandText = "SELECT * FROM Users WHERE username='" + login.TrimEnd() + "'";
            OleDbDataReader reader = command.ExecuteReader();
            do
            {
                while (reader.Read())
                {
                    
                    UserParam.Username = reader["username"].ToString().TrimEnd();
                    UserParam.Password = reader["password"].ToString().TrimEnd();
                    UserParam.Fullname = reader["fullname"].ToString().TrimEnd();
                    if (login == UserParam.Username && pwd == UserParam.Password)
                        auth = true;
                    //userList.Add(usrPrm);
                    //ListViewItem item = listView1.Items.Add(reader["username"].ToString().TrimEnd());
                    //item.SubItems.Add(reader.GetValue(NAME_INDEX).ToString().TrimEnd());
                    //item.SubItems.Add(reader.GetDateTime(3).ToLongDateString());
                    //item.SubItems.Add(reader.GetValue(4).ToString());
                }
            } while (reader.NextResult());
            return auth;
        }

	}
}
