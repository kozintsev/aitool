﻿/*
 * Created by SharpDevelop.
 * User: Oleg
 * Date: 13.03.2011
 * Time: 13:49
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;
using System.Data.OleDb;// пространство имён для подключение к БД 

namespace AiToolGui
{
	/// <summary>
	/// Description of Class1.
	/// </summary>
	public class ConnectDB
	{
		public ConnectDB()
		{
		}
		public bool OpenBD()
		{
			string ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=D:\\ВМИ\\For ADO\\BDTur_firm.mdb"; 
			try{
			 OleDbConnection conn = new OleDbConnection();
             conn.ConnectionString = ConnectionString;
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
