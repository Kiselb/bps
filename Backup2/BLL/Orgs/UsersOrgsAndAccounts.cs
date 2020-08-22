using System;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

namespace BPS.BLL.Orgs
{
	/// <summary>
	/// Summary description for UsersOrgsAndAccounts.
	/// </summary>
	public class UsersOrgsAndAccounts : System.ComponentModel.Component
	{
		private BPS.BLL.Orgs.DataSets.dsUsersOrgsAndAccounts dsUsersOrgsAndAccounts1;

		private System.Data.SqlClient.SqlConnection sqlConnection1;
		private System.Data.SqlClient.SqlDataAdapter dadUsersOrgs;
		private System.Data.SqlClient.SqlDataAdapter dadUsersOrgsAccounts;
		private System.Data.SqlClient.SqlCommand sqlOrgs_SelectAvailableForUser;
		private System.Data.SqlClient.SqlCommand sqlOrgsAccounts_SelectAvailableForUser;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		public UsersOrgsAndAccounts()
		{
			InitializeComponent();
			this.sqlConnection1 = 
				this.sqlOrgs_SelectAvailableForUser.Connection =
				this.sqlOrgsAccounts_SelectAvailableForUser.Connection =  App.Connection;
			
		}

		public UsersOrgsAndAccounts(System.Data.SqlClient.SqlConnection Conn)
		{
			InitializeComponent();
			this.sqlConnection1 = 
				this.sqlOrgs_SelectAvailableForUser.Connection =
				this.sqlOrgsAccounts_SelectAvailableForUser.Connection =  Conn;
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
			this.dadUsersOrgsAccounts = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlOrgsAccounts_SelectAvailableForUser = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.dsUsersOrgsAndAccounts1 = new BPS.BLL.Orgs.DataSets.dsUsersOrgsAndAccounts();
			this.dadUsersOrgs = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlOrgs_SelectAvailableForUser = new System.Data.SqlClient.SqlCommand();
			((System.ComponentModel.ISupportInitialize)(this.dsUsersOrgsAndAccounts1)).BeginInit();
			// 
			// dadUsersOrgsAccounts
			// 
			this.dadUsersOrgsAccounts.SelectCommand = this.sqlOrgsAccounts_SelectAvailableForUser;
			this.dadUsersOrgsAccounts.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										   new System.Data.Common.DataTableMapping("Table", "OrgsAccounts", new System.Data.Common.DataColumnMapping[] {
																																																						   new System.Data.Common.DataColumnMapping("RAccount", "RAccount"),
																																																						   new System.Data.Common.DataColumnMapping("OrgID", "OrgID"),
																																																						   new System.Data.Common.DataColumnMapping("AccountID", "AccountID"),
																																																						   new System.Data.Common.DataColumnMapping("OrgsAccountsID", "OrgsAccountsID")})});
			// 
			// sqlOrgsAccounts_SelectAvailableForUser
			// 
			this.sqlOrgsAccounts_SelectAvailableForUser.CommandText = "[OrgsAccounts_SelectAvailableForUser]";
			this.sqlOrgsAccounts_SelectAvailableForUser.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlOrgsAccounts_SelectAvailableForUser.Connection = this.sqlConnection1;
			this.sqlOrgsAccounts_SelectAvailableForUser.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlOrgsAccounts_SelectAvailableForUser.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UserID", System.Data.SqlDbType.Int, 4));
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = ((string)(configurationAppSettings.GetValue("ConnectionString", typeof(string))));
			// 
			// dsUsersOrgsAndAccounts1
			// 
			this.dsUsersOrgsAndAccounts1.DataSetName = "dsUsersOrgsAndAccounts";
			this.dsUsersOrgsAndAccounts1.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// dadUsersOrgs
			// 
			this.dadUsersOrgs.SelectCommand = this.sqlOrgs_SelectAvailableForUser;
			this.dadUsersOrgs.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																								   new System.Data.Common.DataTableMapping("Table", "Orgs", new System.Data.Common.DataColumnMapping[] {
																																																		   new System.Data.Common.DataColumnMapping("OrgID", "OrgID"),
																																																		   new System.Data.Common.DataColumnMapping("OrgName", "OrgName"),
																																																		   new System.Data.Common.DataColumnMapping("OrgName2", "OrgName2")})});
			// 
			// sqlOrgs_SelectAvailableForUser
			// 
			this.sqlOrgs_SelectAvailableForUser.CommandText = "[Orgs_SelectAvailableForUser]";
			this.sqlOrgs_SelectAvailableForUser.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlOrgs_SelectAvailableForUser.Connection = this.sqlConnection1;
			this.sqlOrgs_SelectAvailableForUser.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlOrgs_SelectAvailableForUser.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UserID", System.Data.SqlDbType.Int, 4));
			((System.ComponentModel.ISupportInitialize)(this.dsUsersOrgsAndAccounts1)).EndInit();

		}
		#endregion

		public BPS.BLL.Orgs.DataSets.dsUsersOrgsAndAccounts DataSet
		{
			 get { return dsUsersOrgsAndAccounts1; }
		}

		/// <summary>
		/// Заполняет DataSet компонента списком р.счетов и соответствующих организаций,
		/// доступных для указанного пользователя
		/// </summary>
		/// <param name="nUserID"></param>
		public void Fill(int nUserID)
		{
			this.dsUsersOrgsAndAccounts1.Clear();
			this.sqlOrgs_SelectAvailableForUser.Parameters["@UserID"].Value = nUserID;
			this.sqlOrgsAccounts_SelectAvailableForUser.Parameters["@UserID"].Value = nUserID;
			this.dadUsersOrgsAccounts.Fill(this.dsUsersOrgsAndAccounts1, "OrgsAccounts");
			this.dadUsersOrgs.Fill(this.dsUsersOrgsAndAccounts1, "Orgs");
		}

	}
}
