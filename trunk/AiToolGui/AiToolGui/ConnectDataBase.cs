/*
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
using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;

namespace AiToolGui
{
	/// <summary>
    /// Description of ConnectDataBase.
	/// </summary>
	public class ConnectDataBase
	{
        private Settings sett;
        private string host;
        private string basename;
        private string user;
        private string pass;

        public ConnectDataBase(string Host, string Basename, string User, string Pass)
		{
            sett = new Settings();
            host = Host;
            basename = Basename;
            user = User;
            pass = Pass;
		}
        
        public bool Authorization(string login, string pwd, bool windows)
        {
            string ConnectionString = String.Empty;
            ConnectionString = "Data Source={0};Database={1};User Id={2};Password={3}"; // Data Source - хост
            ConnectionString = String.Format(ConnectionString, host, basename, user, pass);
            MySqlConnection myConnection = new MySqlConnection(ConnectionString);
            string CommandText = String.Empty;
            if (windows)
                CommandText = "SELECT * FROM sdpm.users WHERE username=@username AND windows=True";
            else
                CommandText = "SELECT * FROM sdpm.users WHERE username=@username AND password=@password";
         
            MySqlCommand myCommand = new MySqlCommand(CommandText, myConnection);
            myCommand.Parameters.Add("@username", MySqlDbType.VarChar).Value = login;
            if (!windows)
                myCommand.Parameters.Add("@password", MySqlDbType.VarChar).Value = pwd;
            myConnection.Open(); //Устанавливаем соединение с базой данных.

            MySqlDataReader MyDataReader;
            MyDataReader = myCommand.ExecuteReader();

            while (MyDataReader.Read())
            {
                UserParam.UserId = MyDataReader.GetInt32(0);
                UserParam.Username = login; // reader["username"].ToString().TrimEnd();
                UserParam.Password = pwd; // reader["password"].ToString().TrimEnd();
                UserParam.Fullname = MyDataReader["fullname"].ToString().TrimEnd();
                UserParam.Role = MyDataReader.GetInt32(5);
            }
            MyDataReader.Close();
  
            //Что то делаем...
            CommandText = "SELECT * FROM sdpm.roles WHERE idRoles = @role";
            myCommand = new MySqlCommand(CommandText, myConnection);
            myCommand.Parameters.Add("@role", MySqlDbType.Int32).Value = UserParam.Role;

            MyDataReader = myCommand.ExecuteReader();

            while (MyDataReader.Read())
            {
                UserParam.Rolename = MyDataReader["role"].ToString().TrimEnd();
            }

            MyDataReader.Close();
            myConnection.Close(); //Обязательно закрываем соединение!
            return true;
        }



        public List<CProjectProcedures> GetProjectProcedureList()
        {
            List<CProjectProcedures> list = new List<CProjectProcedures>();
            CProjectProcedures ProjectProcedures;
            /*
            OleDbCommand command;
            command.CommandText = "SELECT * FROM ProjectProcedure";
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ProjectProcedures = new CProjectProcedures();
                ProjectProcedures.idProjectProcedure = reader.GetInt32(0);
                ProjectProcedures.ProcedurName = reader["ProcedurName"].ToString().TrimEnd();
                ProjectProcedures.ProcedurDescription = reader["ProcedurDescription"].ToString().TrimEnd();
                list.Add(ProjectProcedures);
            }
            */
            return list;
            
        }
	}
}
