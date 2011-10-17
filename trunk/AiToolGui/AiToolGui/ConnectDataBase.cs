﻿/*
 * Created by SharpDevelop.
 * User: Oleg V. Kozintsev
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
        public void CloseConnectDataBaseLocal()
        {
            if (connLocal != null)
                connLocal.Close();
        }
        public void CloseConnectDataBaseServ()
        {
            if (connServ != null)
                connServ.Close();
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
        public bool EmpfyDataBase()// проверка на пустую БД пока оставлю не тронутым тут
        {
            return true;
        }
        public bool Authorization(string login, string pwd)
        {
            object scal;
            int userCount = 0;
            OleDbCommand command = connLocal.CreateCommand();
            command.CommandText = "SELECT id_user, fullname, id_role FROM Users WHERE username=@username AND Password=@password";
            command.Parameters.Add("@username", OleDbType.VarChar).Value = login;
            command.Parameters.Add("@password", OleDbType.VarChar).Value = pwd;
            scal = command.ExecuteScalar();
            if (scal != null)
                userCount = (int)scal;
            else
                return false;
            if (userCount != 1)
                return false;
            OleDbDataReader reader = command.ExecuteReader();
            reader.Read();
            UserParam.UserId = reader.GetInt32(0);
            UserParam.Username = login; // reader["username"].ToString().TrimEnd();
            UserParam.Password = pwd; // reader["password"].ToString().TrimEnd();
            UserParam.Fullname = reader["fullname"].ToString().TrimEnd();
            UserParam.Role = reader.GetInt32(2);
            reader.Close();
            return true;
        }

	}
}
