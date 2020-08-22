using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

namespace BPS.BLL.Orgs
{
	/// <summary>
	/// Summary description for coOrgAccount.
	/// </summary>
	public class coOrgAccount : System.ComponentModel.Component
	{
		private BPS.BLL.Orgs.DataSets.dsOrgsAccounts dsOrgsAccounts1;
		private System.Data.SqlClient.SqlConnection sqlConnection1;
		private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.Data.SqlClient.SqlCommand sqlCmdInsert;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdate;
		private System.Data.SqlClient.SqlCommand sqlCmdDelete;
		/// <summary>
		/// Required designer variable.
		/// </summary>

		public BLL.Orgs.DataSets.dsOrgsAccounts DataSet
		{
			get
			{
				return this.dsOrgsAccounts1;
			}
		}

		public coOrgAccount(System.Data.SqlClient.SqlConnection conn)
		{
			InitializeComponent();
			this.Connection = conn;
		}

		public System.Data.SqlClient.SqlConnection Connection
		{
			set
			{
				this.sqlDataAdapter1.SelectCommand.Connection = 
					sqlCmdInsert.Connection = 
					sqlCmdUpdate.Connection = 
					sqlCmdDelete.Connection = 
					this.sqlConnection1 = value;
			}
			get
			{
				return this.sqlConnection1;
			}

		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.dsOrgsAccounts1 = new BPS.BLL.Orgs.DataSets.dsOrgsAccounts();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlCmdInsert = new System.Data.SqlClient.SqlCommand();
			this.sqlCmdUpdate = new System.Data.SqlClient.SqlCommand();
			this.sqlCmdDelete = new System.Data.SqlClient.SqlCommand();
			((System.ComponentModel.ISupportInitialize)(this.dsOrgsAccounts1)).BeginInit();
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = ((string)(configurationAppSettings.GetValue("ConnectionString", typeof(string))));
			// 
			// dsOrgsAccounts1
			// 
			this.dsOrgsAccounts1.DataSetName = "dsOrgsAccounts";
			this.dsOrgsAccounts1.Locale = new System.Globalization.CultureInfo("ru-RU");
			this.dsOrgsAccounts1.Namespace = "http://www.tempuri.org/dsOrgsAccounts.xsd";
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "OrgsAccounts", new System.Data.Common.DataColumnMapping[] {
																																																					  new System.Data.Common.DataColumnMapping("RAccount", "RAccount"),
																																																					  new System.Data.Common.DataColumnMapping("CodeBIK", "CodeBIK"),
																																																					  new System.Data.Common.DataColumnMapping("BankName", "BankName"),
																																																					  new System.Data.Common.DataColumnMapping("KAccount", "KAccount"),
																																																					  new System.Data.Common.DataColumnMapping("CityName", "CityName"),
																																																					  new System.Data.Common.DataColumnMapping("OrgID", "OrgID"),
																																																					  new System.Data.Common.DataColumnMapping("LastPaymentOrderNo", "LastPaymentOrderNo")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "[OrgAccountSelect]";
			this.sqlSelectCommand1.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrgID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// sqlCmdInsert
			// 
			this.sqlCmdInsert.CommandText = "[OrgAccountInsert]";
			this.sqlCmdInsert.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCmdInsert.Connection = this.sqlConnection1;
			this.sqlCmdInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrgID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RAccount", System.Data.SqlDbType.NVarChar, 50));
			this.sqlCmdInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BankID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CurrencyID", System.Data.SqlDbType.NVarChar, 3));
			this.sqlCmdInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrgName", System.Data.SqlDbType.NVarChar, 256));
			// 
			// sqlCmdUpdate
			// 
			this.sqlCmdUpdate.CommandText = "[OrgAccountUpdate]";
			this.sqlCmdUpdate.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCmdUpdate.Connection = this.sqlConnection1;
			this.sqlCmdUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrgAccountID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RAccount", System.Data.SqlDbType.NVarChar, 50));
			this.sqlCmdUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BankID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrgName", System.Data.SqlDbType.NVarChar, 256));
			// 
			// sqlCmdDelete
			// 
			this.sqlCmdDelete.CommandText = "[OrgAccountDelete]";
			this.sqlCmdDelete.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCmdDelete.Connection = this.sqlConnection1;
			this.sqlCmdDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrgAccountID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			((System.ComponentModel.ISupportInitialize)(this.dsOrgsAccounts1)).EndInit();

		}
		#endregion

		private int m_nOrgID;

		public int Fill(int nOrgID)
		{
			m_nOrgID = nOrgID;
			dsOrgsAccounts1.Clear();
			this.sqlDataAdapter1.SelectCommand.Parameters["@OrgID"].Value = nOrgID;
			return this.sqlDataAdapter1.Fill(this.dsOrgsAccounts1);
		}


		public bool Add(int OrgID, string RAccount, int BankID, string CurrencyID, string OrgName)
		{
			this.sqlCmdInsert.Parameters["@OrgID"].Value=OrgID;
			if(OrgName == "")
			{
				this.sqlCmdInsert.Parameters["@OrgName"].Value = DBNull.Value;
			}
			else
			{
				this.sqlCmdInsert.Parameters["@OrgName"].Value = OrgName;
			}
			this.sqlCmdInsert.Parameters["@RAccount"].Value = RAccount;
			this.sqlCmdInsert.Parameters["@BankID"].Value = BankID;
			this.sqlCmdInsert.Parameters["@CurrencyID"].Value = CurrencyID;
			return AM_Lib.sqlData.ExecuteNonQuery(this.sqlCmdInsert);
		}

		public bool Update(	int OrgAccountID, string RAccount, int BankID, string  OrgName)
		{
			this.sqlCmdUpdate.Parameters["@OrgAccountID"].Value=OrgAccountID;
			this.sqlCmdUpdate.Parameters["@RAccount"].Value = RAccount;
			this.sqlCmdUpdate.Parameters["@BankID"].Value = BankID;
			if(OrgName == "")
			{
				this.sqlCmdUpdate.Parameters["@OrgName"].Value = DBNull.Value;
			}
			else
			{
				this.sqlCmdUpdate.Parameters["@OrgName"].Value = OrgName;
			}

			return AM_Lib.sqlData.ExecuteNonQuery(this.sqlCmdUpdate);
		}

		public bool Delete(	int OrgAccountID )
		{
			this.sqlCmdDelete.Parameters["@OrgAccountID"].Value=OrgAccountID;
			return AM_Lib.sqlData.ExecuteNonQuery(this.sqlCmdDelete);
		}

	}
}
