using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;

namespace AM_Lib
{
	/// <summary>
	/// Summary description for Lock.
	/// </summary>
	public class Lock : System.ComponentModel.Component
	{

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.Data.SqlClient.SqlConnection Connection1;

		public Lock(SqlConnection  conn)
		{
			InitializeComponent();
			Connection1 = conn;
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{

		}
		#endregion


		public static bool StatusChange(int nUserLogonID, int nEntityTypeID, int nEntityID, bool bLock) 
		{
			SqlCommand sqlCmdLockChange;
			sqlCmdLockChange = new SqlCommand("[LockStateChange]");
			sqlCmdLockChange.CommandType = System.Data.CommandType.StoredProcedure;
			sqlCmdLockChange.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE",	System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue,	false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			sqlCmdLockChange.Parameters.Add(new System.Data.SqlClient.SqlParameter("@nEntityTypeID",System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input,			false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			sqlCmdLockChange.Parameters.Add(new System.Data.SqlClient.SqlParameter("@nEntityID",	System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input,			false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			sqlCmdLockChange.Parameters.Add(new System.Data.SqlClient.SqlParameter("@nUserID",		System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input,			false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			sqlCmdLockChange.Parameters.Add(new System.Data.SqlClient.SqlParameter("@bLockState",	System.Data.SqlDbType.Bit, 1));
			sqlCmdLockChange.Parameters.Add(new System.Data.SqlClient.SqlParameter("@nErrorCode",	System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Output,		false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			sqlCmdLockChange.Parameters["@nUserID"].Value			=nUserLogonID;
			sqlCmdLockChange.Parameters["@nEntityTypeID"].Value		=nEntityTypeID;
			sqlCmdLockChange.Parameters["@nEntityID"].Value			=nEntityID;
			sqlCmdLockChange.Parameters["@bLockState"].Value		=bLock;
			return sqlData.ExecuteNonQuery(sqlCmdLockChange);
		}

		
		
		public static void СlearAll(int nUserLogonID)
		{
			SqlCommand cmdClearLocks = new SqlCommand();
			cmdClearLocks.CommandText = "[LockStateDropAll]";
			cmdClearLocks.CommandType = System.Data.CommandType.StoredProcedure;
			cmdClearLocks.Parameters.Add(new System.Data.SqlClient.SqlParameter("@nUserID",		System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input,			false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));		
			cmdClearLocks.Parameters["@nUserID"].Value			= nUserLogonID;
			sqlData.ExecuteNonQuery(cmdClearLocks);
		}

	}
}
/*
 
ALTER PROCEDURE dbo.LockStateChange
	
	@nEntityTypeID	int,
	@nEntityID		int,
	@nUserID		int,
	@bLockState		bit,
	@nErrorCode		int OUTPUT
	
AS
	-- SET NOCOUNT ON

	DECLARE @lock_error int
	
	IF @bLockState =1 
	BEGIN
		INSERT INTO Locks (EntityTypeID, EntityID, UserID) VALUES (@nEntityTypeID, @nEntityID, @nUserID)
		SELECT @lock_error = @@ERROR
		IF @lock_error <>0 
		BEGIN
			SET @nErrorCode =@lock_error
			IF @lock_error =2627
			BEGIN
				RAISERROR('Ошибка блокирования: Блокировка установлена другим пользователем.', 16, 1)
			END
			ELSE
			BEGIN
				RAISERROR('Ошибка блокирования (Error Code= %).', 16, 1, @lock_error)
			END
			RETURN
		END
	END
	ELSE
	BEGIN
		DELETE FROM Locks WHERE (EntityTypeID = @nEntityTypeID) AND (EntityID = @nEntityID)
		SELECT @lock_error = @@ERROR
		IF @lock_error <>0 
		BEGIN
			RAISERROR('Ошибка разблокирования (Error Code= %).', 16, 1, @lock_error)
			RETURN
		END
	END

	RETURN 


ALTER PROCEDURE dbo.LockStateDropAll
	@nUserID int
AS
	-- SET NOCOUNT ON 
	DECLARE @lock_error int
	
	DELETE FROM Locks WHERE (UserID = @nUserID)
	SELECT @lock_error = @@ERROR
	IF @lock_error <>0 
	BEGIN
		RAISERROR('Ошибка разблокирования (Error Code= %).', 16, 1, @lock_error)
		RETURN
	END

	RETURN 

*/