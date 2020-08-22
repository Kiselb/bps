using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Data;
using AM_Controls;
using System.Windows.Forms;

namespace BPS.BLL.Currency
{
	/// <summary>
	/// Summary description for coCurrency.
	/// </summary>
	public class coCurrency : System.ComponentModel.Component
	{
		public delegate void DataGridStyleEventHandler(DataGridTableStyle GridStyle);
		private BPS.BLL.Currency.DataSets.dsCurr dsDataSet;
		private System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
		private System.Data.SqlClient.SqlConnection sqlConnection1;
		private System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		private System.Data.SqlClient.SqlDataAdapter daCurrHistory;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		private System.Data.SqlClient.SqlCommand sqlInsertCommand3;
		private System.Data.SqlClient.SqlCommand sqlUpdateCommand2;
		private System.Data.SqlClient.SqlCommand sqlDeleteCommand3;
		private BPS.BLL.Currency.DataSets.dsCurrHistory dsCurrHistory1;
		private System.Data.SqlClient.SqlCommand sqlCmdSetRate;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.Data.SqlClient.SqlCommand sqlInsertCommand2;
		private System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
		private System.Data.SqlClient.SqlCommand sqlDeleteCommand2;

		public BPS.BLL.Currency.DataSets.dsCurr DataSet
		{
			get
			{
				return this.dsDataSet;
			}
		}

		public BPS.BLL.Currency.DataSets.dsCurrHistory DataSetHistory
		{
			get
			{
				return this.dsCurrHistory1;
			}
		}

		public coCurrency()
		{
			InitializeComponent();
		}

		public System.Data.SqlClient.SqlConnection Connection
		{
			set
			{
				this.sqlDataAdapter1.SelectCommand.Connection = 
					this.sqlDataAdapter1.InsertCommand.Connection = 
					this.sqlDataAdapter1.UpdateCommand.Connection = 
					this.sqlDataAdapter1.DeleteCommand.Connection = 
					this.daCurrHistory.SelectCommand.Connection = 
					this.daCurrHistory.InsertCommand.Connection = 
					this.daCurrHistory.UpdateCommand.Connection = 
					this.daCurrHistory.DeleteCommand.Connection =
					this.sqlCmdSetRate.Connection =
					sqlConnection1 = value;
			}
			get
			{
				return this.sqlConnection1;
			}

		}


		public coCurrency(System.Data.SqlClient.SqlConnection conn)
		{
			/// <summary>
			/// Required for Windows.Forms Class Composition Designer support
			/// </summary>
			InitializeComponent();
			this.Connection = conn;
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
			this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
			this.dsDataSet = new BPS.BLL.Currency.DataSets.dsCurr();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDeleteCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlInsertCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
			this.daCurrHistory = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDeleteCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlInsertCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand2 = new System.Data.SqlClient.SqlCommand();
			this.dsCurrHistory1 = new BPS.BLL.Currency.DataSets.dsCurrHistory();
			this.sqlCmdSetRate = new System.Data.SqlClient.SqlCommand();
			((System.ComponentModel.ISupportInitialize)(this.dsDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsCurrHistory1)).BeginInit();
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = ((string)(configurationAppSettings.GetValue("ConnectionString", typeof(string))));
			// 
			// dsDataSet
			// 
			this.dsDataSet.DataSetName = "dsCurr";
			this.dsDataSet.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.DeleteCommand = this.sqlDeleteCommand2;
			this.sqlDataAdapter1.InsertCommand = this.sqlInsertCommand2;
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "Currencies", new System.Data.Common.DataColumnMapping[] {
																																																					new System.Data.Common.DataColumnMapping("CurrencyID", "CurrencyID"),
																																																					new System.Data.Common.DataColumnMapping("CurrencyName", "CurrencyName"),
																																																					new System.Data.Common.DataColumnMapping("CurrencyRate", "CurrencyRate"),
																																																					new System.Data.Common.DataColumnMapping("IsBase", "IsBase")})});
			this.sqlDataAdapter1.UpdateCommand = this.sqlUpdateCommand1;
			// 
			// sqlDeleteCommand2
			// 
			this.sqlDeleteCommand2.CommandText = "DELETE FROM Currencies WHERE (CurrencyID = @Original_CurrencyID) AND (CurrencyNam" +
				"e = @Original_CurrencyName) AND (CurrencyRate = @Original_CurrencyRate) AND (IsB" +
				"ase = @Original_IsBase)";
			this.sqlDeleteCommand2.Connection = this.sqlConnection1;
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CurrencyID", System.Data.SqlDbType.NVarChar, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CurrencyID", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CurrencyName", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CurrencyName", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CurrencyRate", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CurrencyRate", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_IsBase", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IsBase", System.Data.DataRowVersion.Original, null));
			// 
			// sqlInsertCommand2
			// 
			this.sqlInsertCommand2.CommandText = "INSERT INTO Currencies(CurrencyID, CurrencyName, CurrencyRate, IsBase) VALUES (@C" +
				"urrencyID, @CurrencyName, @CurrencyRate, @IsBase); SELECT CurrencyID, CurrencyNa" +
				"me, CurrencyRate, IsBase FROM Currencies WHERE (CurrencyID = @CurrencyID)";
			this.sqlInsertCommand2.Connection = this.sqlConnection1;
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CurrencyID", System.Data.SqlDbType.NVarChar, 3, "CurrencyID"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CurrencyName", System.Data.SqlDbType.NVarChar, 50, "CurrencyName"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CurrencyRate", System.Data.SqlDbType.Float, 8, "CurrencyRate"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsBase", System.Data.SqlDbType.Bit, 1, "IsBase"));
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT CurrencyID, CurrencyName, CurrencyRate, IsBase FROM Currencies";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlUpdateCommand1
			// 
			this.sqlUpdateCommand1.CommandText = @"UPDATE Currencies SET CurrencyID = @CurrencyID, CurrencyName = @CurrencyName, CurrencyRate = @CurrencyRate, IsBase = @IsBase WHERE (CurrencyID = @Original_CurrencyID) AND (CurrencyName = @Original_CurrencyName) AND (CurrencyRate = @Original_CurrencyRate) AND (IsBase = @Original_IsBase); SELECT CurrencyID, CurrencyName, CurrencyRate, IsBase FROM Currencies WHERE (CurrencyID = @CurrencyID)";
			this.sqlUpdateCommand1.Connection = this.sqlConnection1;
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CurrencyID", System.Data.SqlDbType.NVarChar, 3, "CurrencyID"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CurrencyName", System.Data.SqlDbType.NVarChar, 50, "CurrencyName"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CurrencyRate", System.Data.SqlDbType.Float, 8, "CurrencyRate"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsBase", System.Data.SqlDbType.Bit, 1, "IsBase"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CurrencyID", System.Data.SqlDbType.NVarChar, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CurrencyID", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CurrencyName", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CurrencyName", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CurrencyRate", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CurrencyRate", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_IsBase", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IsBase", System.Data.DataRowVersion.Original, null));
			// 
			// daCurrHistory
			// 
			this.daCurrHistory.DeleteCommand = this.sqlDeleteCommand3;
			this.daCurrHistory.InsertCommand = this.sqlInsertCommand3;
			this.daCurrHistory.SelectCommand = this.sqlSelectCommand2;
			this.daCurrHistory.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									new System.Data.Common.DataTableMapping("Table", "CurrenciesHistory", new System.Data.Common.DataColumnMapping[] {
																																																						 new System.Data.Common.DataColumnMapping("ID", "ID"),
																																																						 new System.Data.Common.DataColumnMapping("CurrDate", "CurrDate"),
																																																						 new System.Data.Common.DataColumnMapping("CurrencyID", "CurrencyID"),
																																																						 new System.Data.Common.DataColumnMapping("CurrRate", "CurrRate"),
																																																						 new System.Data.Common.DataColumnMapping("BaseCurrencyID", "BaseCurrencyID")})});
			this.daCurrHistory.UpdateCommand = this.sqlUpdateCommand2;
			// 
			// sqlDeleteCommand3
			// 
			this.sqlDeleteCommand3.CommandText = "DELETE FROM CurrenciesHistory WHERE (ID = @Original_ID) AND (BaseCurrencyID = @Or" +
				"iginal_BaseCurrencyID) AND (CurrDate = @Original_CurrDate) AND (CurrRate = @Orig" +
				"inal_CurrRate) AND (CurrencyID = @Original_CurrencyID)";
			this.sqlDeleteCommand3.Connection = this.sqlConnection1;
			this.sqlDeleteCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ID", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_BaseCurrencyID", System.Data.SqlDbType.NVarChar, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BaseCurrencyID", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CurrDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CurrDate", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CurrRate", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CurrRate", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CurrencyID", System.Data.SqlDbType.NVarChar, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CurrencyID", System.Data.DataRowVersion.Original, null));
			// 
			// sqlInsertCommand3
			// 
			this.sqlInsertCommand3.CommandText = "INSERT INTO CurrenciesHistory(CurrDate, CurrencyID, CurrRate, BaseCurrencyID) VAL" +
				"UES (@CurrDate, @CurrencyID, @CurrRate, @BaseCurrencyID); SELECT ID, CurrDate, C" +
				"urrencyID, CurrRate, BaseCurrencyID FROM CurrenciesHistory WHERE (ID = @@IDENTIT" +
				"Y)";
			this.sqlInsertCommand3.Connection = this.sqlConnection1;
			this.sqlInsertCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CurrDate", System.Data.SqlDbType.DateTime, 8, "CurrDate"));
			this.sqlInsertCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CurrencyID", System.Data.SqlDbType.NVarChar, 3, "CurrencyID"));
			this.sqlInsertCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CurrRate", System.Data.SqlDbType.Float, 8, "CurrRate"));
			this.sqlInsertCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BaseCurrencyID", System.Data.SqlDbType.NVarChar, 3, "BaseCurrencyID"));
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = @"SELECT CurrenciesHistory.ID, CurrenciesHistory.CurrDate, CurrenciesHistory.CurrencyID, CurrenciesHistory.CurrRate, CurrenciesHistory.BaseCurrencyID, Currencies.CurrencyName FROM CurrenciesHistory INNER JOIN Currencies ON CurrenciesHistory.CurrencyID = Currencies.CurrencyID";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			// 
			// sqlUpdateCommand2
			// 
			this.sqlUpdateCommand2.CommandText = @"UPDATE CurrenciesHistory SET CurrDate = @CurrDate, CurrencyID = @CurrencyID, CurrRate = @CurrRate, BaseCurrencyID = @BaseCurrencyID WHERE (ID = @Original_ID) AND (BaseCurrencyID = @Original_BaseCurrencyID) AND (CurrDate = @Original_CurrDate) AND (CurrRate = @Original_CurrRate) AND (CurrencyID = @Original_CurrencyID); SELECT ID, CurrDate, CurrencyID, CurrRate, BaseCurrencyID FROM CurrenciesHistory WHERE (ID = @ID)";
			this.sqlUpdateCommand2.Connection = this.sqlConnection1;
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CurrDate", System.Data.SqlDbType.DateTime, 8, "CurrDate"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CurrencyID", System.Data.SqlDbType.NVarChar, 3, "CurrencyID"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CurrRate", System.Data.SqlDbType.Float, 8, "CurrRate"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BaseCurrencyID", System.Data.SqlDbType.NVarChar, 3, "BaseCurrencyID"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ID", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_BaseCurrencyID", System.Data.SqlDbType.NVarChar, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BaseCurrencyID", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CurrDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CurrDate", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CurrRate", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CurrRate", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CurrencyID", System.Data.SqlDbType.NVarChar, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CurrencyID", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.Int, 4, "ID"));
			// 
			// dsCurrHistory1
			// 
			this.dsCurrHistory1.DataSetName = "dsCurrHistory";
			this.dsCurrHistory1.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// sqlCmdSetRate
			// 
			this.sqlCmdSetRate.CommandText = "[CurrencyChangeRate]";
			this.sqlCmdSetRate.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCmdSetRate.Connection = this.sqlConnection1;
			this.sqlCmdSetRate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdSetRate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sCurrencyID", System.Data.SqlDbType.NVarChar, 3));
			this.sqlCmdSetRate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fRate", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(15)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			((System.ComponentModel.ISupportInitialize)(this.dsDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsCurrHistory1)).EndInit();

		}
		#endregion
		
		public int Fill()
		{
			this.dsDataSet.Currencies.Clear();
			return this.sqlDataAdapter1.Fill(this.dsDataSet.Currencies);
		}

		public int FillHistory()
		{
			this.dsCurrHistory1.CurrenciesHistory.Clear();
			return this.daCurrHistory.Fill(this.dsCurrHistory1.CurrenciesHistory);
		}

		public void Update()
		{
			try
			{
				this.sqlDataAdapter1.Update(this.dsDataSet.Currencies);
			}
			catch(Exception ex)
			{
				AM_Controls.MsgBoxX.Show(ex.Message,"BPS",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
			}
		}
		public void UpdateHistory()
		{
			try
			{
				this.daCurrHistory.Update(this.dsCurrHistory1.CurrenciesHistory);
			}
			catch(Exception ex)
			{
				AM_Controls.MsgBoxX.Show(ex.Message,"BPS",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				this.dsCurrHistory1.RejectChanges();
			}
		}
		
		public void SetCurrencyMainRate(string szCurrencyID, double dRate) 
		{
			//MessageBox.Show("OK!");
			try 
			{
				this.sqlCmdSetRate.Parameters["@sCurrencyID"].Value =szCurrencyID;
				this.sqlCmdSetRate.Parameters["@fRate"].Value =dRate;
				
				if ( this.sqlCmdSetRate.Connection.State !=ConnectionState.Open)
					this.sqlCmdSetRate.Connection.Open();  
				this.sqlCmdSetRate.ExecuteNonQuery();

				this.Fill();
			}
			catch(Exception ex)
			{
				MsgBoxX.Show(ex.Message,"BPS",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
			}
			finally 
			{
				if ( this.sqlCmdSetRate.Connection.State !=ConnectionState.Closed)
					this.sqlCmdSetRate.Connection.Close();
			}
		}

	}
}
