using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BPS._CS
{
	/// <summary>
	/// Summary description for TransactionsOperations.
	/// </summary>
	public class TransactionsOperations
	{
		public TransactionsOperations()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		//создание транзакции и операции типа 1 или 7
/*
 * 		public void CreateTransactionIn(int iTransType, BPS.AddTransaction at, BPS._Forms.dsPaymentOrderList.PaymListRow rw)
		{
			System.Globalization.NumberFormatInfo nfi = new System.Globalization.NumberFormatInfo();
			nfi.NumberDecimalSeparator = ".";
			SqlCommand cmdUpdPayment                 = new SqlCommand("",App.Connection);
			SqlCommand cmdInsTransactions            = new SqlCommand("", App.Connection);
			SqlCommand cmdGetTransactionID           = new SqlCommand("SELECT @@IDENTITY", App.Connection);
			SqlCommand cmdInsTransactionsOperation   = new SqlCommand("", App.Connection); 
			SqlCommand cmdGetTransactionsOperationID = new SqlCommand("SELECT @@IDENTITY", App.Connection);
			SqlCommand cmdAccountOperation           = new SqlCommand("", App.Connection);
			SqlCommand cmdUpdAccount                 = new SqlCommand("", App.Connection);
			
			int iTransactionID = 0;
			int iTransactionsOperationID = 0;
			App.Connection.Open();
			SqlTransaction tr = App.Connection.BeginTransaction();
			cmdUpdPayment.Transaction                      = tr;
			cmdInsTransactions.Transaction                 = tr;
			cmdGetTransactionID.Transaction                = tr;
			cmdInsTransactionsOperation.Transaction        = tr;
			cmdGetTransactionsOperationID.Transaction      = tr;
			cmdAccountOperation.Transaction                = tr;
			cmdUpdAccount.Transaction                      = tr;
			try
			{
				cmdUpdPayment.CommandText = "UPDATE PaymentOrder SET ModifiedAt=@ModifiedDate,OperConfirmed=" + App.UserLogonID + ",OperModified=" + App.UserLogonID + ",ClientID=" + at.ClientID +  " WHERE PaymentOrderID=" + rw.PaymentOrderID; 
				cmdUpdPayment.Parameters.Add(new SqlParameter("@ModifiedDate",SqlDbType.DateTime));
				cmdUpdPayment.Parameters["@ModifiedDate"].Value = rw.ModifiedAt = DateTime.Now;
				cmdUpdPayment.ExecuteNonQuery();
				////
				cmdInsTransactions.CommandText = "INSERT INTO Transactions (TransactionTypeID, TransactionDate, TransactionSum, TransactionCurrencyID, TransactionCurrencyRate,TransactionModified, OperCreated, OperModified, ServiceCharge, ClientID)" +
					" VALUES (" + iTransType + ",@Date ," + rw.PaymentOrderSum.ToString(nfi) + ",'" + rw.CurrencyID + "', 1.00,@TransactionModified," + App.UserLogonID + "," + App.UserLogonID + "," + at.Charge.ToString(nfi) + "," + at.ClientID + ")";
			
				cmdInsTransactions.Parameters.Add(new SqlParameter("@Date",SqlDbType.DateTime));
				cmdInsTransactions.Parameters["@Date"].Value = DateTime.Now;
				cmdInsTransactions.Parameters.Add(new SqlParameter("@TransactionModified",SqlDbType.DateTime));
				cmdInsTransactions.Parameters["@TransactionModified"].Value = DateTime.Now;
				cmdInsTransactions.ExecuteNonQuery();
				object o = cmdGetTransactionID.ExecuteScalar();
				if( o != Convert.DBNull)
					iTransactionID = Convert.ToInt32(o);
				else
				{
					tr.Rollback();
					return;
				}
				cmdInsTransactionsOperation.CommandText = "INSERT INTO TransactionsOperations (TransactionID, SumFrom, SumTo, AccountIDFrom, AccountIDTo, DocumentIDFrom, DocumentIDTo)" + 
					" VALUES (" + iTransactionID.ToString() + "," + rw.PaymentOrderSum.ToString(nfi) + "," + rw.PaymentOrderSum.ToString(nfi) + "," + rw.AccountIDCorr + "," + rw.AccountID + "," + rw.PaymentOrderID + "," + rw.PaymentOrderID + ")";
				cmdInsTransactionsOperation.ExecuteNonQuery();
				o = cmdGetTransactionsOperationID.ExecuteScalar();
				if( o != Convert.DBNull)
					iTransactionsOperationID = Convert.ToInt32(o);
				else
				{
					tr.Rollback();
					return;
				}
				//////////////////
				cmdAccountOperation.CommandText = "INSERT INTO AccountsOperations (TransactionOperationID, OperationSum, OperationDir, AccountID)" + 
					" VALUES (" + iTransactionsOperationID.ToString() + "," + rw.PaymentOrderSum.ToString(nfi) + ",0," + rw.AccountID + ")";
				cmdAccountOperation.ExecuteNonQuery();
				cmdUpdAccount.CommandText = "UPDATE Accounts SET Saldo=ROUND(Saldo + " + rw.PaymentOrderSum.ToString(nfi) + ",2) WHERE AccountID=" + rw.AccountID;
				cmdUpdAccount.ExecuteNonQuery();
				cmdAccountOperation.CommandText = "INSERT INTO AccountsOperations (TransactionOperationID, OperationSum, OperationDir, AccountID)" + 
					" VALUES (" + iTransactionsOperationID.ToString() + "," + rw.PaymentOrderSum.ToString(nfi) + ",1," + rw.AccountIDCorr + ")";
				cmdAccountOperation.ExecuteNonQuery();
				cmdUpdAccount.CommandText = "UPDATE Accounts SET Saldo=ROUND(Saldo - " + rw.PaymentOrderSum.ToString(nfi) + ",2) WHERE AccountID=" + rw.AccountIDCorr;
				cmdUpdAccount.ExecuteNonQuery();
				//////////////////
				tr.Commit();
			}
			catch(Exception ex)
			{
				tr.Rollback();
				AM_Controls.MsgBoxX.Show("Не удалось создать транзакцию и связать её с платежом" + rw.PaymentNo + ". " + ex.Message,"BPS", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
			}
			finally
			{
				if(App.Connection.State == ConnectionState.Open)
					App.Connection.Close();
			}
		}
*/		
		public void CreateTransactionOut( BLL.Transactions.DataSets.dsTransactionList.TransactionsRow rw)
		{
/*			System.Globalization.NumberFormatInfo nfi = new System.Globalization.NumberFormatInfo();
			nfi.NumberDecimalSeparator = ".";
			SqlCommand cmdInsTransactions            = new SqlCommand("", App.Connection);
			SqlCommand cmdGetTransactionID           = new SqlCommand("SELECT @@IDENTITY", App.Connection);
			SqlCommand cmdInsTransactionsOperation   = new SqlCommand("", App.Connection); 
			SqlCommand cmdGetTransactionsOperationID = new SqlCommand("SELECT @@IDENTITY", App.Connection);
			int iTransactionID = 0;
			int iTransactionsOperationID = 0;
			App.Connection.Open();
			SqlTransaction tr = App.Connection.BeginTransaction();
			cmdInsTransactions.Transaction  = tr;
			cmdGetTransactionID.Transaction = tr;
			cmdInsTransactionsOperation.Transaction = tr;
			cmdGetTransactionsOperationID.Transaction = tr;
			try
			{
				cmdInsTransactions.CommandText = "INSERT INTO Transactions (TransactionTypeID, TransactionDate, TransactionSum, TransactionCurrencyID, TransactionCurrencyRate,TransactionModified, OperCreated, OperModified, ServiceCharge, ClientID)" +
					" VALUES (" + rw.TransactionTypeID + ",@Date ," + rw.SumFrom.ToString(nfi) + ",'" + rw.TransactionCurrencyID + "', 1.00,@TransactionModified," + App.UserLogonID + "," + App.UserLogonID + "," + rw.ServiceCharge.ToString(nfi) + "," + rw.ClientID + ")";
			
				cmdInsTransactions.Parameters.Add(new SqlParameter("@Date",SqlDbType.DateTime));
				cmdInsTransactions.Parameters["@Date"].Value = DateTime.Now;
				cmdInsTransactions.Parameters.Add(new SqlParameter("@TransactionModified",SqlDbType.DateTime));
				cmdInsTransactions.Parameters["@TransactionModified"].Value = DateTime.Now;
				cmdInsTransactions.ExecuteNonQuery();
				object o = cmdGetTransactionID.ExecuteScalar();
				if( o != Convert.DBNull)
					iTransactionID = Convert.ToInt32(o);
				else
				{
					tr.Rollback();
					return;
				}
				cmdInsTransactionsOperation.CommandText = "INSERT INTO TransactionsOperations (TransactionID, SumFrom, SumTo)" + 
					" VALUES (" + iTransactionID.ToString() + "," + rw.SumFrom.ToString(nfi) + "," + rw.TransactionSum.ToString(nfi) + ")";
				cmdInsTransactionsOperation.ExecuteNonQuery();
				o = cmdGetTransactionsOperationID.ExecuteScalar();
				if( o != Convert.DBNull)
					iTransactionsOperationID = Convert.ToInt32(o);
				else
				{
					tr.Rollback();
					return;
				}
				tr.Commit();
				rw.OperationID = iTransactionsOperationID;
			}
			catch(Exception ex)
			{
				tr.Rollback();
				AM_Controls.MsgBoxX.Show("Не удалось создать транзакцию и связать её с платежом" + rw.PaymentNo + ". " + ex.Message,"BPS", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
			}
			finally
			{
				if(App.Connection.State == ConnectionState.Open)
					App.Connection.Close();
			}
*/		}
	}
}
