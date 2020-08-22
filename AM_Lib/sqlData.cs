using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AM_Lib
{
	/// <summary>
	///  dbParam
	///  Класс - описание параметра и его значение для SqlCommand. 
	/// </summary>
	public class dbParam
	{
		public string Name;
		public System.Data.SqlDbType Type;
		public object Value;

		public dbParam(string sName, System.Data.SqlDbType dbType, object oValue)
		{
			Name=sName;
			Type = dbType;
			Value = oValue;
		}
	}

	/// <summary>
	///  sqlData
	///  Класс для исполнения различных запросов к БД. 
	///  Все методы - статические.
	///  ConnectionString  к БД передается в конструкторе или 
	///  устанавливается через свойство Connection класса.
	///  Методы, принимающие массивы SQL запросов, выполняют эти запросы в рамках транзакции. 
	///  В случае возникновения ошибки при исполнении любого запроса из массива выполняется откат транзакции.
	///  После успешного выполнения последней команды выполняется подтверждение транзакии.
	/// </summary>

	public class sqlData
	{
		private static System.Data.SqlClient.SqlConnection	Connection1;
		private static System.Data.SqlClient.SqlTransaction Transaction;
		
		public static System.Data.SqlClient.SqlConnection	Connection
		{
			set { Connection1 = value; }
			get { return Connection1 ; }
		}
	

/// <summary>
/// Статический конструктор.
/// Для использования методов класса требуется инициализация ConnectionString свойства Connection класса.
/// </summary>
		static sqlData()
		{
			Connection1 = new System.Data.SqlClient.SqlConnection();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sConnectionString"></param>
		public sqlData( string sConnectionString )
		{
			Connection = new System.Data.SqlClient.SqlConnection(sConnectionString);
		}

		public static void BeginTransaction()
		{
			if ( Connection.State == ConnectionState.Closed ) 
				Connection.Open();
			Transaction = Connection.BeginTransaction();
		}

		public static void CommitTransaction()
		{
			Transaction.Commit();
			Transaction = null;
			if ( Connection.State == ConnectionState.Open ) 
				Connection.Close();
		}

		public static void RollbackTransaction()
		{
			Transaction.Rollback();
			Transaction = null;
			if ( Connection.State == ConnectionState.Open ) 
				Connection.Close();
		}

		public static System.Data.SqlClient.SqlDataReader ExecuteReader(string sSQL)
		{
			return ExecuteReader(new System.Data.SqlClient.SqlCommand(sSQL));
		}


		public static object ExecuteScalar(string sSQL)
		{
			return ExecuteScalar(new System.Data.SqlClient.SqlCommand(sSQL));
		}


		public static bool ExecuteNonQuery(string sSQL)
		{
			return ExecuteNonQuery(new System.Data.SqlClient.SqlCommand(sSQL));
		}


		public static bool ExecuteNonQuery(string[] sSQL)
		{
			System.Data.SqlClient.SqlCommand[] sqlCmdArray= new System.Data.SqlClient.SqlCommand[sSQL.Length];
			for (int i=0; i<sSQL.Length; i++) 
			{
				sqlCmdArray[i]= new System.Data.SqlClient.SqlCommand(sSQL[i]);
			}
			return ExecuteNonQuery(sqlCmdArray);
		}


		public static bool ExecuteNonQuery( System.Data.SqlClient.SqlCommand[] sqlCmdArray )
		{
			if ( Connection1.State == ConnectionState.Closed ) 
				Connection1.Open();
			Transaction = Connection.BeginTransaction();
			for (int i=0; i<sqlCmdArray.Length; i++) 
			{
				if (!ExecuteNonQuery(sqlCmdArray[i]) )
				{
					Transaction.Rollback();
					Connection1.Close();
					return false;
				}
			}
			Transaction.Commit();
			Connection1.Close();
			return true;
		}
		

		public static bool ExecuteNonQuery( System.Data.SqlClient.SqlCommand sqlCmd, AM_Lib.dbParam[] sqlParam)
		{
			for (int i=0; i<sqlParam.Length; i++) 
			{
				sqlCmd.Parameters.Add(sqlParam[i].Name,sqlParam[i].Type);
				sqlCmd.Parameters[sqlParam[i].Name].Value = sqlParam[i].Value;
			}

			bool bCloseConnection = false;
			try 
			{
				sqlCmd.Connection = Connection;
				if (Transaction!=null)
					sqlCmd.Transaction = Transaction;
				Cursor.Current = Cursors.WaitCursor;
				if ( sqlCmd.Connection.State == ConnectionState.Closed ) 
				{
					sqlCmd.Connection.Open();
					bCloseConnection = true;
				}
				sqlCmd.ExecuteNonQuery();
				return true;
			}
			catch(Exception ex)
			{
				Cursor.Current = Cursors.Default;
                AM_Controls.MsgBoxX.Show(ex.Message);
				return false;
			}
			finally
			{
				Cursor.Current = Cursors.Default;
				if (bCloseConnection)
					sqlCmd.Connection.Close();
			}

		}
		

		public static bool ExecuteNonQuery( System.Data.SqlClient.SqlCommand sqlCmd )
		{
			bool bCloseConnection = false;
			try 
			{
				sqlCmd.Connection = Connection;
				if (Transaction!=null)
					sqlCmd.Transaction = Transaction;
				Cursor.Current = Cursors.WaitCursor;
				if ( sqlCmd.Connection.State == ConnectionState.Closed ) 
				{
					sqlCmd.Connection.Open();
					bCloseConnection = true;
				}
				sqlCmd.ExecuteNonQuery();
				return true;
			}
			catch(Exception ex)
			{
				Cursor.Current = Cursors.Default;
                AM_Controls.MsgBoxX.Show(ex.Message);
				return false;
			}
			finally
			{
				Cursor.Current = Cursors.Default;
				if (bCloseConnection)
					sqlCmd.Connection.Close();
			}

		}


		public static  System.Data.SqlClient.SqlDataReader ExecuteReader( System.Data.SqlClient.SqlCommand sqlCmd )
		{
			try 
			{
				sqlCmd.Connection = Connection;
				if ( sqlCmd.Connection.State == ConnectionState.Closed ) 
				{
					sqlCmd.Connection.Open();
				}
				return sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
			}
			catch(Exception ex)
			{
                AM_Controls.MsgBoxX.Show(ex.Message);
				return null;
			}
		}


		public static  object ExecuteScalar( System.Data.SqlClient.SqlCommand sqlCmd )
		{
			try 
			{
				sqlCmd.Connection = Connection;
				if ( sqlCmd.Connection.State == ConnectionState.Closed ) 
				{
					sqlCmd.Connection.Open();
				}
				return sqlCmd.ExecuteScalar();
			}
			catch(Exception ex)
			{
                AM_Controls.MsgBoxX.Show(ex.Message);
				return null;
			}
			finally
			{
				Cursor.Current = Cursors.Default;
				sqlCmd.Connection.Close();
			}
		}

	}

}
