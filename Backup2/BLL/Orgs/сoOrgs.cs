using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;
using System.Data;

namespace BPS.BLL.Orgs
{
	/// <summary>
	/// Summary description for ñoOrgs.
	/// </summary>
	public class coOrgs : System.ComponentModel.Component
	{
		private BLL.Orgs.DataSets.dsOrgs dsOrgs1;
		private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		private System.Data.SqlClient.SqlConnection sqlConnection1;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		private System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
		private BPS.BLL.Orgs.DataSets.dsOrgsAccount dsOrgsAccount1;
		private System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
		private BPS.BLL.Orgs.coOrgAccount bllAccounts;


		/// <summary>
		/// Required designer variable.
		/// </summary>

		public BLL.Orgs.DataSets.dsOrgs DataSet
		{
			get
			{
				return this.dsOrgs1;
			}
		}
		
		public BPS.BLL.Orgs.coOrgAccount Accounts
		{
			get
			{
				return bllAccounts;
			}
		}


		public coOrgs(System.Data.SqlClient.SqlConnection conn)
		{
			/// <summary>
			/// Required for Windows.Forms Class Composition Designer support
			/// </summary>
			InitializeComponent();
			this.Connection = conn;
			bllAccounts = new BPS.BLL.Orgs.coOrgAccount(conn);
		}

		
		
		public System.Data.SqlClient.SqlConnection Connection
		{
			set
			{
				this.sqlDataAdapter1.SelectCommand.Connection = 
					this.sqlDataAdapter1.InsertCommand.Connection = 
					this.sqlDataAdapter1.UpdateCommand.Connection = 
					this.sqlDataAdapter1.DeleteCommand.Connection = 
					this.sqlConnection1 = value;
			}
			get
			{
				return this.sqlConnection1;
			}

		}

		
		
		public int Fill()
		{
			this.dsOrgs1.Clear();
			return this.sqlDataAdapter1.Fill(this.dsOrgs1);
		}

		public bool Update()
		{
			try
			{
				this.sqlDataAdapter1.Update(this.dsOrgs1);
				return true;
				
			}
			catch(Exception ex)
			{
				AM_Controls.MsgBoxX.Show(ex.Message,"BPS",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				//				this.dsOrgs1.RejectChanges();
				return false;
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
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
			this.dsOrgs1 = new BPS.BLL.Orgs.DataSets.dsOrgs();
			this.dsOrgsAccount1 = new BPS.BLL.Orgs.DataSets.dsOrgsAccount();
			((System.ComponentModel.ISupportInitialize)(this.dsOrgs1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsOrgsAccount1)).BeginInit();
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.DeleteCommand = this.sqlDeleteCommand1;
			this.sqlDataAdapter1.InsertCommand = this.sqlInsertCommand1;
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "Orgs", new System.Data.Common.DataColumnMapping[] {
																																																			  new System.Data.Common.DataColumnMapping("OrgID", "OrgID"),
																																																			  new System.Data.Common.DataColumnMapping("OrgName", "OrgName"),
																																																			  new System.Data.Common.DataColumnMapping("OrgName2", "OrgName2"),
																																																			  new System.Data.Common.DataColumnMapping("IsNormal", "IsNormal"),
																																																			  new System.Data.Common.DataColumnMapping("IsInner", "IsInner"),
																																																			  new System.Data.Common.DataColumnMapping("IsSpecial", "IsSpecial"),
																																																			  new System.Data.Common.DataColumnMapping("DefaultServiceCharge", "DefaultServiceCharge"),
																																																			  new System.Data.Common.DataColumnMapping("CodeINN", "CodeINN"),
																																																			  new System.Data.Common.DataColumnMapping("CodeKPP", "CodeKPP"),
																																																			  new System.Data.Common.DataColumnMapping("AddrReg", "AddrReg"),
																																																			  new System.Data.Common.DataColumnMapping("AddrFact", "AddrFact"),
																																																			  new System.Data.Common.DataColumnMapping("Phone1", "Phone1"),
																																																			  new System.Data.Common.DataColumnMapping("Phone2", "Phone2"),
																																																			  new System.Data.Common.DataColumnMapping("Fax1", "Fax1"),
																																																			  new System.Data.Common.DataColumnMapping("Fax2", "Fax2"),
																																																			  new System.Data.Common.DataColumnMapping("ContactPerson", "ContactPerson"),
																																																			  new System.Data.Common.DataColumnMapping("OKPO", "OKPO"),
																																																			  new System.Data.Common.DataColumnMapping("OKONH", "OKONH"),
																																																			  new System.Data.Common.DataColumnMapping("ClientID", "ClientID")})});
			this.sqlDataAdapter1.UpdateCommand = this.sqlUpdateCommand1;
			// 
			// sqlDeleteCommand1
			// 
			this.sqlDeleteCommand1.CommandText = "[OrgsDeleteCommand]";
			this.sqlDeleteCommand1.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlDeleteCommand1.Connection = this.sqlConnection1;
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_OrgID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "OrgID", System.Data.DataRowVersion.Original, null));
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = ((string)(configurationAppSettings.GetValue("ConnectionString", typeof(string))));
			// 
			// sqlInsertCommand1
			// 
			this.sqlInsertCommand1.CommandText = "[OrgsInsertCommand]";
			this.sqlInsertCommand1.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlInsertCommand1.Connection = this.sqlConnection1;
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrgName", System.Data.SqlDbType.NVarChar, 256, "OrgName"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrgName2", System.Data.SqlDbType.NVarChar, 255, "OrgName2"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNormal", System.Data.SqlDbType.Bit, 1, "IsNormal"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsInner", System.Data.SqlDbType.Bit, 1, "IsInner"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsSpecial", System.Data.SqlDbType.Bit, 1, "IsSpecial"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DefaultServiceCharge", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(15)), ((System.Byte)(0)), "DefaultServiceCharge", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CodeINN", System.Data.SqlDbType.NVarChar, 16, "CodeINN"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CodeKPP", System.Data.SqlDbType.NVarChar, 16, "CodeKPP"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AddrReg", System.Data.SqlDbType.NVarChar, 255, "AddrReg"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AddrFact", System.Data.SqlDbType.NVarChar, 255, "AddrFact"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Phone1", System.Data.SqlDbType.NVarChar, 16, "Phone1"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Phone2", System.Data.SqlDbType.NVarChar, 16, "Phone2"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Fax1", System.Data.SqlDbType.NVarChar, 16, "Fax1"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Fax2", System.Data.SqlDbType.NVarChar, 16, "Fax2"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ContactPerson", System.Data.SqlDbType.NVarChar, 50, "ContactPerson"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OKPO", System.Data.SqlDbType.NVarChar, 50, "OKPO"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OKONH", System.Data.SqlDbType.NVarChar, 50, "OKONH"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ClientID", System.Data.SqlDbType.Int, 0, "ClientID"));
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "[OrgsSelectCommand]";
			this.sqlSelectCommand1.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// sqlUpdateCommand1
			// 
			this.sqlUpdateCommand1.CommandText = "[OrgsUpdateCommand]";
			this.sqlUpdateCommand1.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlUpdateCommand1.Connection = this.sqlConnection1;
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrgName", System.Data.SqlDbType.NVarChar, 256, "OrgName"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrgName2", System.Data.SqlDbType.NVarChar, 255, "OrgName2"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNormal", System.Data.SqlDbType.Bit, 1, "IsNormal"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsInner", System.Data.SqlDbType.Bit, 1, "IsInner"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsSpecial", System.Data.SqlDbType.Bit, 1, "IsSpecial"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsRemoved", System.Data.SqlDbType.Bit, 1, "IsRemoved"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DefaultServiceCharge", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(15)), ((System.Byte)(0)), "DefaultServiceCharge", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CodeINN", System.Data.SqlDbType.NVarChar, 16, "CodeINN"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CodeKPP", System.Data.SqlDbType.NVarChar, 16, "CodeKPP"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AddrReg", System.Data.SqlDbType.NVarChar, 255, "AddrReg"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AddrFact", System.Data.SqlDbType.NVarChar, 255, "AddrFact"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Phone1", System.Data.SqlDbType.NVarChar, 16, "Phone1"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Phone2", System.Data.SqlDbType.NVarChar, 16, "Phone2"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Fax1", System.Data.SqlDbType.NVarChar, 16, "Fax1"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Fax2", System.Data.SqlDbType.NVarChar, 16, "Fax2"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ContactPerson", System.Data.SqlDbType.NVarChar, 50, "ContactPerson"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OKPO", System.Data.SqlDbType.NVarChar, 50, "OKPO"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OKONH", System.Data.SqlDbType.NVarChar, 50, "OKONH"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_OrgID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "OrgID", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrgID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "OrgID", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ClientID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "ClientID", System.Data.DataRowVersion.Current, null));
			// 
			// dsOrgs1
			// 
			this.dsOrgs1.DataSetName = "dsOrgs";
			this.dsOrgs1.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// dsOrgsAccount1
			// 
			this.dsOrgsAccount1.DataSetName = "dsOrgsAccount";
			this.dsOrgsAccount1.Locale = new System.Globalization.CultureInfo("ru-RU");
			((System.ComponentModel.ISupportInitialize)(this.dsOrgs1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsOrgsAccount1)).EndInit();

		}
		#endregion
	}
}
