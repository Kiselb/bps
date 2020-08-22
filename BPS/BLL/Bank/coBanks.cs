using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;
using System.Data;
using AM_Controls;

namespace BPS.BLL.Bank
{
	/// <summary>
	/// Summary description for coBanks.
	/// </summary>
	public class coBanks : System.ComponentModel.Component
	{
		public delegate void DataGridStyleEventHandler(DataGridTableStyle GridStyle);
		private System.Data.SqlClient.SqlDataAdapter sqldaBanks;
		private System.Data.SqlClient.SqlConnection sqlConnection1;
		private BPS.BLL.Bank.DataSets.dsBanks dsBanks1;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		private System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
		private System.Data.SqlClient.SqlCommand sqlDeleteCommand1;

		private int UpdatedRowID = -1;
		/// <summary>
		/// Required designer variable.
		/// </summary>

		public coBanks(System.Data.SqlClient.SqlConnection Conn)
		{
			InitializeComponent();
			this.Connection = Conn;
		}

		public coBanks()
		{
			InitializeComponent();
			this.Connection = App.Connection;
		}

		public System.Data.SqlClient.SqlConnection Connection
		{
			set
			{
				this.sqldaBanks.SelectCommand.Connection = 
					this.sqldaBanks.InsertCommand.Connection = 
					this.sqldaBanks.UpdateCommand.Connection = 
					this.sqldaBanks.DeleteCommand.Connection = 
					this.sqlConnection1=
					value;
			}
			get 
			{
				return this.sqlConnection1;
			}
		}



		public BPS.BLL.Bank.DataSets.dsBanks DataSet
		{
			get
			{
				return this.dsBanks1;
			}
		}


		public int Fill()
		{
			this.dsBanks1.Clear();
			return this.sqldaBanks.Fill(this.dsBanks1);
		}


		public bool Update()
		{
			try
			{
				this.sqldaBanks.Update(this.dsBanks1);
				return true;
			}
			catch(Exception ex)
			{
				AM_Controls.MsgBoxX.Show("Ошибка:\n" + ex.Message,"BPS",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				this.dsBanks1.RejectChanges();
				return false;
			}
		}

		public int AddBank(DataSets.dsBanks.BanksRow rw )
		{
			this.dsBanks1.Banks.AddBanksRow(rw);
			if ( Update() )
				return this.UpdatedRowID;
			else
				throw new Exception("Ошибка сохранения нового банка.");
		}



		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
			this.sqldaBanks = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
			this.dsBanks1 = new BPS.BLL.Bank.DataSets.dsBanks();
			((System.ComponentModel.ISupportInitialize)(this.dsBanks1)).BeginInit();
			// 
			// sqldaBanks
			// 
			this.sqldaBanks.DeleteCommand = this.sqlDeleteCommand1;
			this.sqldaBanks.InsertCommand = this.sqlInsertCommand1;
			this.sqldaBanks.SelectCommand = this.sqlSelectCommand1;
			this.sqldaBanks.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																								 new System.Data.Common.DataTableMapping("Table", "Banks", new System.Data.Common.DataColumnMapping[] {
																																																		  new System.Data.Common.DataColumnMapping("BankID", "BankID"),
																																																		  new System.Data.Common.DataColumnMapping("BankName", "BankName"),
																																																		  new System.Data.Common.DataColumnMapping("CityID", "CityID"),
																																																		  new System.Data.Common.DataColumnMapping("CodeBIK", "CodeBIK"),
																																																		  new System.Data.Common.DataColumnMapping("KAccount", "KAccount")})});
			this.sqldaBanks.UpdateCommand = this.sqlUpdateCommand1;
			this.sqldaBanks.RowUpdated += new System.Data.SqlClient.SqlRowUpdatedEventHandler(this.sqldaBanks_RowUpdated);
			// 
			// sqlDeleteCommand1
			// 
			this.sqlDeleteCommand1.CommandText = "DELETE FROM Banks WHERE (BankID = @Original_BankID)";
			this.sqlDeleteCommand1.Connection = this.sqlConnection1;
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_BankID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BankID", System.Data.DataRowVersion.Original, null));
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = ((string)(configurationAppSettings.GetValue("ConnectionString", typeof(string))));
			// 
			// sqlInsertCommand1
			// 
			this.sqlInsertCommand1.CommandText = "INSERT INTO Banks(BankName, CityID, CodeBIK, KAccount) VALUES (@BankName, @CityID" +
				", @CodeBIK, @KAccount); SELECT BankID, BankName, CityID, CodeBIK, KAccount FROM " +
				"Banks WHERE (BankID = @@IDENTITY)";
			this.sqlInsertCommand1.Connection = this.sqlConnection1;
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BankName", System.Data.SqlDbType.NVarChar, 128, "BankName"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CityID", System.Data.SqlDbType.Int, 4, "CityID"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CodeBIK", System.Data.SqlDbType.NVarChar, 50, "CodeBIK"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@KAccount", System.Data.SqlDbType.NVarChar, 50, "KAccount"));
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT Banks.BankID, Banks.BankName, Banks.CityID, Banks.CodeBIK, Banks.KAccount," +
				" Cities.CityName FROM Banks LEFT OUTER JOIN Cities ON Banks.CityID = Cities.City" +
				"ID ORDER BY Banks.BankName";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlUpdateCommand1
			// 
			this.sqlUpdateCommand1.CommandText = @"UPDATE Banks SET BankName = @BankName, CityID = @CityID, CodeBIK = @CodeBIK, KAccount = @KAccount WHERE (BankID = @Original_BankID) AND (BankName = @Original_BankName) AND (CityID = @Original_CityID) AND (CodeBIK = @Original_CodeBIK) AND (KAccount = @Original_KAccount); SELECT BankID, BankName, CityID, CodeBIK, KAccount FROM Banks WHERE (BankID = @BankID)";
			this.sqlUpdateCommand1.Connection = this.sqlConnection1;
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BankName", System.Data.SqlDbType.NVarChar, 128, "BankName"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CityID", System.Data.SqlDbType.Int, 4, "CityID"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CodeBIK", System.Data.SqlDbType.NVarChar, 50, "CodeBIK"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@KAccount", System.Data.SqlDbType.NVarChar, 50, "KAccount"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_BankID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BankID", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_BankName", System.Data.SqlDbType.NVarChar, 128, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "BankName", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CityID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CityID", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CodeBIK", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CodeBIK", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_KAccount", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "KAccount", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BankID", System.Data.SqlDbType.Int, 4, "BankID"));
			// 
			// dsBanks1
			// 
			this.dsBanks1.DataSetName = "dsBanks";
			this.dsBanks1.Locale = new System.Globalization.CultureInfo("ru-RU");
			((System.ComponentModel.ISupportInitialize)(this.dsBanks1)).EndInit();

		}
		#endregion

		private void sqldaBanks_RowUpdated(object sender, System.Data.SqlClient.SqlRowUpdatedEventArgs e)
		{
			if(e.StatementType == StatementType.Insert)
			{
				UpdatedRowID = (int)e.Row["BankID"];
			}
		}
	}
}
