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

namespace AiToolGui
{
	/// <summary>
    /// Description of ConnectDataBase.
	/// </summary>
	public class ConnectDataBase
	{
        Setting sett;
        OleDbConnection conn;

        public ConnectDataBase()
		{
            sett = new Setting();
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
	}
}
