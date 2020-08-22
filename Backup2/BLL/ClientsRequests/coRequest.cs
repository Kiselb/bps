using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

namespace BPS.BLL.ClientsRequests
{
	/// <summary>
	/// Summary description for coRequest.
	/// </summary>
	public class coRequest : System.ComponentModel.Component
	{
		private  BPS.BLL.ClientRequest.DataSets.dsReqTypes dsReqTypes1;
		private  BPS.BLL.ClientRequest.DataSets.dsReqState dsReqState1;
		private  System.Data.SqlClient.SqlDataAdapter sqldaReqStates;
		private   System.Data.SqlClient.SqlDataAdapter sqldaReqTypes;
		private  System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		private  System.Data.SqlClient.SqlCommand sqlSelectCommand1;

		private System.Data.SqlClient.SqlConnection sqlConnection1;
		private System.Data.SqlClient.SqlDataAdapter sqldaRequests;
		private System.Data.SqlClient.SqlCommand sqlCommand2;
		private System.Data.SqlClient.SqlCommand sqlCommand3;
		private System.Data.SqlClient.SqlCommand sqlCommand4;
		private System.Data.SqlClient.SqlCommand sqlCommand5;
		private BPS.BLL.ClientsRequests.DataSets.dsClientsRequests dsClientsRequests1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		public coRequest(System.Data.SqlClient.SqlConnection conn)
		{
			InitializeComponent();
			Connection = conn;
		}
		
		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.dsReqTypes1 = new BPS.BLL.ClientRequest.DataSets.dsReqTypes();
			this.dsReqState1 = new BPS.BLL.ClientRequest.DataSets.dsReqState();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqldaReqStates = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqldaReqTypes = new System.Data.SqlClient.SqlDataAdapter();
			this.dsClientsRequests1 = new BPS.BLL.ClientsRequests.DataSets.dsClientsRequests();
			this.sqldaRequests = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlCommand4 = new System.Data.SqlClient.SqlCommand();
			this.sqlCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlCommand5 = new System.Data.SqlClient.SqlCommand();
			((System.ComponentModel.ISupportInitialize)(this.dsReqTypes1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsReqState1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsClientsRequests1)).BeginInit();
			// 
			// dsReqTypes1
			// 
			this.dsReqTypes1.DataSetName = "dsReqTypes";
			this.dsReqTypes1.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// dsReqState1
			// 
			this.dsReqState1.DataSetName = "dsReqState";
			this.dsReqState1.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT RequestStateID, RequestStateName FROM ClientsRequestStates";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = "workstation id=\"B-1-3\";packet size=4096;integrated security=SSPI;data source=\"B-1" +
				"-3-TEST\";persist security info=False;initial catalog=bp2";
			// 
			// sqldaReqStates
			// 
			this.sqldaReqStates.SelectCommand = this.sqlSelectCommand1;
			this.sqldaReqStates.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									 new System.Data.Common.DataTableMapping("Table", "ClientsRequestStates", new System.Data.Common.DataColumnMapping[] {
																																																							 new System.Data.Common.DataColumnMapping("RequestStateID", "RequestStateID"),
																																																							 new System.Data.Common.DataColumnMapping("RequestStateName", "RequestStateName")})});
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "SELECT RequestTypeID, RequestTypeName, IsInner, IsIn, IsOut FROM ClientsRequestTy" +
				"pes";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			// 
			// sqldaReqTypes
			// 
			this.sqldaReqTypes.SelectCommand = this.sqlSelectCommand2;
			this.sqldaReqTypes.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									new System.Data.Common.DataTableMapping("Table", "ClientsRequestTypes", new System.Data.Common.DataColumnMapping[] {
																																																						   new System.Data.Common.DataColumnMapping("RequestTypeID", "RequestTypeID"),
																																																						   new System.Data.Common.DataColumnMapping("RequestTypeName", "RequestTypeName"),
																																																						   new System.Data.Common.DataColumnMapping("IsInner", "IsInner"),
																																																						   new System.Data.Common.DataColumnMapping("IsIn", "IsIn"),
																																																						   new System.Data.Common.DataColumnMapping("IsOut", "IsOut")})});
			// 
			// dsClientsRequests1
			// 
			this.dsClientsRequests1.DataSetName = "dsClientsRequests";
			this.dsClientsRequests1.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// sqldaRequests
			// 
			this.sqldaRequests.DeleteCommand = this.sqlCommand3;
			this.sqldaRequests.InsertCommand = this.sqlCommand4;
			this.sqldaRequests.SelectCommand = this.sqlCommand2;
			this.sqldaRequests.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									new System.Data.Common.DataTableMapping("Table", "ClientsRequests", new System.Data.Common.DataColumnMapping[] {
																																																					   new System.Data.Common.DataColumnMapping("RequestStateName", "RequestStateName"),
																																																					   new System.Data.Common.DataColumnMapping("RequestTypeName", "RequestTypeName"),
																																																					   new System.Data.Common.DataColumnMapping("ClientName", "ClientName"),
																																																					   new System.Data.Common.DataColumnMapping("RequestID", "RequestID"),
																																																					   new System.Data.Common.DataColumnMapping("RequestTypeID", "RequestTypeID"),
																																																					   new System.Data.Common.DataColumnMapping("RequestDate", "RequestDate"),
																																																					   new System.Data.Common.DataColumnMapping("ClientID", "ClientID"),
																																																					   new System.Data.Common.DataColumnMapping("RequestStateID", "RequestStateID"),
																																																					   new System.Data.Common.DataColumnMapping("RequestSum", "RequestSum"),
																																																					   new System.Data.Common.DataColumnMapping("AccountFrom", "AccountFrom"),
																																																					   new System.Data.Common.DataColumnMapping("AccountTo", "AccountTo"),
																																																					   new System.Data.Common.DataColumnMapping("Remarks", "Remarks"),
																																																					   new System.Data.Common.DataColumnMapping("OrgFrom", "OrgFrom"),
																																																					   new System.Data.Common.DataColumnMapping("OrgTo", "OrgTo"),
																																																					   new System.Data.Common.DataColumnMapping("OrgFromINN", "OrgFromINN"),
																																																					   new System.Data.Common.DataColumnMapping("OrgToINN", "OrgToINN"),
																																																					   new System.Data.Common.DataColumnMapping("OrgFromKPP", "OrgFromKPP"),
																																																					   new System.Data.Common.DataColumnMapping("OrgToKPP", "OrgToKPP"),
																																																					   new System.Data.Common.DataColumnMapping("CurrencyFrom", "CurrencyFrom"),
																																																					   new System.Data.Common.DataColumnMapping("CurrencyTo", "CurrencyTo"),
																																																					   new System.Data.Common.DataColumnMapping("BankName", "BankName"),
																																																					   new System.Data.Common.DataColumnMapping("CodeBIK", "CodeBIK"),
																																																					   new System.Data.Common.DataColumnMapping("VAT", "VAT"),
																																																					   new System.Data.Common.DataColumnMapping("Purpose", "Purpose"),
																																																					   new System.Data.Common.DataColumnMapping("ExecutedSum", "ExecutedSum"),
																																																					   new System.Data.Common.DataColumnMapping("ClientGroupID", "ClientGroupID"),
																																																					   new System.Data.Common.DataColumnMapping("ClientGroupName", "ClientGroupName")})});
			this.sqldaRequests.UpdateCommand = this.sqlCommand5;
			// 
			// sqlCommand3
			// 
			this.sqlCommand3.CommandText = "DELETE FROM ClientsRequests WHERE (RequestID = @RequestID)";
			this.sqlCommand3.Connection = this.sqlConnection1;
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RequestID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RequestID", System.Data.DataRowVersion.Original, null));
			// 
			// sqlCommand4
			// 
			this.sqlCommand4.CommandText = @"INSERT INTO ClientsRequests (RequestTypeID, RequestDate, ClientID, RequestStateID, RequestSum, AccountFrom, AccountTo, Remarks, OrgFrom, OrgTo, OrgFromINN, OrgToINN, OrgFromKPP, OrgToKPP, CurrencyFrom, CurrencyTo, BankName, CodeBIK, VAT, Purpose) VALUES (@RequestTypeID, @RequestDate, @ClientID, @RequestStateID, @RequestSum, @AccountFrom, @AccountTo, @Remarks, @OrgFrom, @OrgTo, @OrgFromINN, @OrgToINN, @OrgFromKPP, @OrgToKPP, @CurrencyFrom, @CurrencyTo, @BankName, @CodeBIK, @VAT, @Purpose); SELECT RequestID, RequestTypeID, RequestDate, ClientID, RequestStateID, RequestSum, AccountFrom, AccountTo, Remarks, OrgFrom, OrgTo, OrgFromINN, OrgToINN, CurrencyFrom, CurrencyTo, BankName, CodeBIK, VAT, Purpose FROM ClientsRequests WHERE (RequestID = @@IDENTITY)";
			this.sqlCommand4.Connection = this.sqlConnection1;
			this.sqlCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RequestTypeID", System.Data.SqlDbType.Int, 4, "RequestTypeID"));
			this.sqlCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RequestDate", System.Data.SqlDbType.DateTime, 8, "RequestDate"));
			this.sqlCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ClientID", System.Data.SqlDbType.Int, 4, "ClientID"));
			this.sqlCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RequestStateID", System.Data.SqlDbType.Int, 4, "RequestStateID"));
			this.sqlCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RequestSum", System.Data.SqlDbType.Float, 8, "RequestSum"));
			this.sqlCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AccountFrom", System.Data.SqlDbType.NVarChar, 50, "AccountFrom"));
			this.sqlCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AccountTo", System.Data.SqlDbType.NVarChar, 50, "AccountTo"));
			this.sqlCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Remarks", System.Data.SqlDbType.NVarChar, 256, "Remarks"));
			this.sqlCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrgFrom", System.Data.SqlDbType.NVarChar, 256, "OrgFrom"));
			this.sqlCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrgTo", System.Data.SqlDbType.NVarChar, 256, "OrgTo"));
			this.sqlCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrgFromINN", System.Data.SqlDbType.NVarChar, 12, "OrgFromINN"));
			this.sqlCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrgToINN", System.Data.SqlDbType.NVarChar, 12, "OrgToINN"));
			this.sqlCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrgFromKPP", System.Data.SqlDbType.NVarChar, 16, "OrgFromKPP"));
			this.sqlCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrgToKPP", System.Data.SqlDbType.NVarChar, 16, "OrgToKPP"));
			this.sqlCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CurrencyFrom", System.Data.SqlDbType.NVarChar, 3, "CurrencyFrom"));
			this.sqlCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CurrencyTo", System.Data.SqlDbType.NVarChar, 3, "CurrencyTo"));
			this.sqlCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BankName", System.Data.SqlDbType.NVarChar, 128, "BankName"));
			this.sqlCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CodeBIK", System.Data.SqlDbType.NVarChar, 50, "CodeBIK"));
			this.sqlCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@VAT", System.Data.SqlDbType.Float, 8, "VAT"));
			this.sqlCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Purpose", System.Data.SqlDbType.NVarChar, 256, "Purpose"));
			// 
			// sqlCommand2
			// 
			this.sqlCommand2.CommandText = @"SELECT ClientsRequestStates.RequestStateName, ClientsRequestTypes.RequestTypeName, Clients.ClientName, ClientsRequests.RequestID, ClientsRequests.RequestTypeID, ClientsRequests.RequestDate, ClientsRequests.ClientID, ClientsRequests.RequestStateID, ClientsRequests.RequestSum, ClientsRequests.AccountFrom, ClientsRequests.AccountTo, ClientsRequests.Remarks, ClientsRequests.OrgFrom, ClientsRequests.OrgTo, ClientsRequests.OrgFromINN, ClientsRequests.OrgToINN, ClientsRequests.OrgFromKPP, ClientsRequests.OrgToKPP, ClientsRequests.CurrencyFrom, ClientsRequests.CurrencyTo, ClientsRequests.BankName, ClientsRequests.CodeBIK, ClientsRequests.VAT, ClientsRequests.Purpose, ClientsRequests.ExecutedSum, Clients.ClientGroupID, ClientsGroups.ClientGroupName FROM ClientsRequests INNER JOIN ClientsRequestStates ON ClientsRequests.RequestStateID = ClientsRequestStates.RequestStateID INNER JOIN ClientsRequestTypes ON ClientsRequests.RequestTypeID = ClientsRequestTypes.RequestTypeID INNER JOIN Clients ON ClientsRequests.ClientID = Clients.ClientID INNER JOIN ClientsGroups ON Clients.ClientGroupID = ClientsGroups.ClientGroupID WHERE (ClientsRequests.RequestDate >= @DateFrom) AND (ClientsRequests.RequestDate <= @DateTo)";
			this.sqlCommand2.Connection = this.sqlConnection1;
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DateFrom", System.Data.SqlDbType.DateTime, 8, "RequestDate"));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DateTo", System.Data.SqlDbType.DateTime, 8, "RequestDate"));
			// 
			// sqlCommand5
			// 
			this.sqlCommand5.CommandText = @"UPDATE ClientsRequests SET RequestTypeID = @RequestTypeID, RequestDate = @RequestDate, ClientID = @ClientID, RequestStateID = @RequestStateID, RequestSum = @RequestSum, AccountFrom = @AccountFrom, AccountTo = @AccountTo, Remarks = @Remarks, OrgFrom = @OrgFrom, OrgTo = @OrgTo, OrgFromINN = @OrgFromINN, OrgToINN = @OrgToINN, CurrencyFrom = @CurrencyFrom, CurrencyTo = @CurrencyTo, BankName = @BankName, CodeBIK = @CodeBIK, VAT = @VAT, Purpose = @Purpose, OrgFromKPP = @OrgFromKPP, OrgToKPP = @OrgToKPP WHERE (RequestID = @Original_RequestID)";
			this.sqlCommand5.Connection = this.sqlConnection1;
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RequestTypeID", System.Data.SqlDbType.Int, 4, "RequestTypeID"));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RequestDate", System.Data.SqlDbType.DateTime, 8, "RequestDate"));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ClientID", System.Data.SqlDbType.Int, 4, "ClientID"));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RequestStateID", System.Data.SqlDbType.Int, 4, "RequestStateID"));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RequestSum", System.Data.SqlDbType.Float, 8, "RequestSum"));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AccountFrom", System.Data.SqlDbType.NVarChar, 50, "AccountFrom"));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AccountTo", System.Data.SqlDbType.NVarChar, 50, "AccountTo"));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Remarks", System.Data.SqlDbType.NVarChar, 256, "Remarks"));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrgFrom", System.Data.SqlDbType.NVarChar, 256, "OrgFrom"));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrgTo", System.Data.SqlDbType.NVarChar, 256, "OrgTo"));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrgFromINN", System.Data.SqlDbType.NVarChar, 12, "OrgFromINN"));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrgToINN", System.Data.SqlDbType.NVarChar, 12, "OrgToINN"));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CurrencyFrom", System.Data.SqlDbType.NVarChar, 3, "CurrencyFrom"));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CurrencyTo", System.Data.SqlDbType.NVarChar, 3, "CurrencyTo"));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BankName", System.Data.SqlDbType.NVarChar, 128, "BankName"));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CodeBIK", System.Data.SqlDbType.NVarChar, 50, "CodeBIK"));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@VAT", System.Data.SqlDbType.Float, 8, "VAT"));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Purpose", System.Data.SqlDbType.NVarChar, 256, "Purpose"));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrgFromKPP", System.Data.SqlDbType.NVarChar, 16, "OrgFromKPP"));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrgToKPP", System.Data.SqlDbType.NVarChar, 16, "OrgToKPP"));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RequestID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RequestID", System.Data.DataRowVersion.Original, null));
			((System.ComponentModel.ISupportInitialize)(this.dsReqTypes1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsReqState1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsClientsRequests1)).EndInit();

		}
		#endregion
		
		#region Properties

		public  System.Data.SqlClient.SqlConnection Connection 
		{
			set 
			{
				this.sqldaReqStates.SelectCommand.Connection = 
					this.sqldaReqTypes.SelectCommand.Connection = 
					this.sqldaRequests.SelectCommand.Connection = 
					this.sqldaRequests.InsertCommand.Connection = 
					this.sqldaRequests.UpdateCommand.Connection = 
					this.sqldaRequests.DeleteCommand.Connection = 
					this.sqlConnection1=
					value;
			}

			get 
			{
				return sqlConnection1;
			}
		}

		
		public  BPS.BLL.ClientRequest.DataSets.dsReqTypes ReqTypesDirectory
		{	get { return dsReqTypes1; }	}

		public BPS.BLL.ClientRequest.DataSets.dsReqState ReqStatesDirectory
		{	get { return dsReqState1; }	}
		
		public BPS.BLL.ClientsRequests.DataSets.dsClientsRequests DataSet
		{
			get { return  dsClientsRequests1;}
		}


		#endregion


		public  void FillDirectories()
		{
			sqldaReqTypes.Fill(dsReqTypes1);
			sqldaReqStates.Fill(dsReqState1);
		}

		public  int Fill(DateTime dtFrom, DateTime dtTill )
		{
			System.DateTime dtFromLocal =dtFrom.Date;
			System.DateTime dtTillLocal =dtTill.Date;

			dtFromLocal =dtFromLocal.AddHours		( -dtFromLocal.Hour		  );
			dtFromLocal =dtFromLocal.AddMinutes		( -dtFromLocal.Minute	  );
			dtFromLocal =dtFromLocal.AddSeconds		( -dtFromLocal.Second	  );
			dtFromLocal =dtFromLocal.AddMilliseconds( -dtFromLocal.Millisecond);
				
			dtTillLocal = dtTillLocal.AddHours		 ( -dtTillLocal.Hour		 );
			dtTillLocal = dtTillLocal.AddMinutes	 ( -dtTillLocal.Minute	 );
			dtTillLocal = dtTillLocal.AddSeconds	 ( -dtTillLocal.Second	 );
			dtTillLocal = dtTillLocal.AddMilliseconds( -dtTillLocal.Millisecond);
			dtTillLocal = dtTillLocal.AddDays		 ( 1 );
			dtTillLocal = dtTillLocal.AddMilliseconds( -1);

			this.dsClientsRequests1.Clear();

			this.sqldaRequests.SelectCommand.Parameters["@DateFrom"].Value = dtFromLocal.Date; //dtFrom;
			this.sqldaRequests.SelectCommand.Parameters["@DateTo"].Value   = dtTillLocal.Date; //dtTill.AddDays(1);

			return this.sqldaRequests.Fill(this.dsClientsRequests1);
		}

		public bool Update()
		{
			try
			{
				this.sqldaRequests.Update(this.dsClientsRequests1);
				return true;
			}
			catch(Exception ex)
			{
				AM_Controls.MsgBoxX.Show("Îøèáêà:\n" + ex.Message);
				this.dsClientsRequests1.RejectChanges();
				return false;
			}

		}


	}
}
