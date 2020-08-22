using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using AM_Controls;

namespace AM_Lib
{
	public class OleDbData
	{
		private static System.Data.OleDb.OleDbConnection	Connection1;
		private static System.Data.OleDb.OleDbTransaction Transaction;
		
		public static System.Data.OleDb.OleDbConnection	Connection
		{
			set { Connection1 = value; }
			get { return Connection1 ; }
		}
	

/// <summary>
/// —татический конструктор.
/// ƒл€ использовани€ методов класса требуетс€ инициализаци€ ConnectionString свойства Connection класса.
/// </summary>
		static OleDbData()
		{
			Connection1 = new System.Data.OleDb.OleDbConnection();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sConnectionString"></param>
		public OleDbData( string sConnectionString )
		{
			Connection = new System.Data.OleDb.OleDbConnection(sConnectionString);
		}

		public static void BeginTransaction()
		{
			Transaction = Connection.BeginTransaction();
		}

		public static void CommitTransaction()
		{
			Transaction.Commit();
			Transaction = null;
		}

		public static void RollbackTransaction()
		{
			Transaction.Rollback();
			Transaction = null;
		}

		public static System.Data.OleDb.OleDbDataReader ExecuteReader(string sSQL)
		{
			return ExecuteReader(new System.Data.OleDb.OleDbCommand(sSQL));
		}


		public static object ExecuteScalar(string sSQL)
		{
			return ExecuteScalar(new System.Data.OleDb.OleDbCommand(sSQL));
		}


		public static bool ExecuteNonQuery(string sSQL)
		{
			return ExecuteNonQuery(new System.Data.OleDb.OleDbCommand(sSQL));
		}


		public static bool ExecuteNonQuery(string[] sSQL)
		{
			System.Data.OleDb.OleDbCommand[] sqlCmdArray= new System.Data.OleDb.OleDbCommand[sSQL.Length];
			for (int i=0; i<sSQL.Length; i++) 
			{
				sqlCmdArray[i]= new System.Data.OleDb.OleDbCommand(sSQL[i]);
			}
			return ExecuteNonQuery(sqlCmdArray);
		}


		public static bool ExecuteNonQuery( System.Data.OleDb.OleDbCommand[] sqlCmdArray )
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
		

		public static bool ExecuteNonQuery( System.Data.OleDb.OleDbCommand sqlCmd, AM_Lib.dbParam[] sqlParam)
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
				MsgBoxX.Show(ex.Message);
				return false;
			}
			finally
			{
				Cursor.Current = Cursors.Default;
				if (bCloseConnection)
					sqlCmd.Connection.Close();
			}

		}
		

		public static bool ExecuteNonQuery( System.Data.OleDb.OleDbCommand sqlCmd )
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
				MsgBoxX.Show(ex.Message);
				return false;
			}
			finally
			{
				Cursor.Current = Cursors.Default;
				if (bCloseConnection)
					sqlCmd.Connection.Close();
			}

		}


		public static  System.Data.OleDb.OleDbDataReader ExecuteReader( System.Data.OleDb.OleDbCommand sqlCmd )
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
				MsgBoxX.Show(ex.Message);
				return null;
			}
		}


		public static  object ExecuteScalar( System.Data.OleDb.OleDbCommand sqlCmd )
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
				MsgBoxX.Show(ex.Message);
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
