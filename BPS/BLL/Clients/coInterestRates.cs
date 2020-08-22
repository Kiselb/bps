using System;
using System.Data;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

namespace BPS.BLL.Clients
{
	/// <summary>
	/// Summary description for coInterestRates.
	/// </summary>
	public class coInterestRates : System.ComponentModel.Component
	{
		private BPS.BLL.Clients.DataSets.dsInterestRate dsInterestRate1;
        private BPS.BLL.ClientsRequests.DataSets.dsReqTypes dsReqTypes1;
		private System.Data.SqlClient.SqlCommand sqlSelectClientsOrgs;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		private System.Data.SqlClient.SqlConnection sqlConnection1;
		private System.Data.SqlClient.SqlDataAdapter daInterestRateList;
		private System.Data.SqlClient.SqlDataAdapter daReqTypes;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		private BPS.BLL.Clients.DataSets.dsInterestRateList dsInterestRateList1;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		private System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
		private System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		//private System.ComponentModel.Container components = null;

		public coInterestRates(System.ComponentModel.IContainer container)
		{
			/// <summary>
			/// Required for Windows.Forms Class Composition Designer support
			/// </summary>
			container.Add(this);
			InitializeComponent();
			this.daInterestRateList.SelectCommand.Connection = 
			this.daInterestRateList.InsertCommand.Connection = 
			this.daInterestRateList.DeleteCommand.Connection = 
			this.daInterestRateList.UpdateCommand.Connection = 
			this.daReqTypes.SelectCommand.Connection = App.Connection;
		}

		public coInterestRates()
		{
			/// <summary>
			/// Required for Windows.Forms Class Composition Designer support
			/// </summary>
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
			this.dsInterestRate1 = new BPS.BLL.Clients.DataSets.dsInterestRate();
			this.dsReqTypes1 = new BPS.BLL.ClientsRequests.DataSets.dsReqTypes();
			this.sqlSelectClientsOrgs = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.daInterestRateList = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
			this.daReqTypes = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
			this.dsInterestRateList1 = new BPS.BLL.Clients.DataSets.dsInterestRateList();
			((System.ComponentModel.ISupportInitialize)(this.dsInterestRate1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsReqTypes1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsInterestRateList1)).BeginInit();
			// 
			// dsInterestRate1
			// 
			this.dsInterestRate1.DataSetName = "dsInterestRate";
			this.dsInterestRate1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dsReqTypes1
			// 
			this.dsReqTypes1.DataSetName = "dsReqTypes";
			this.dsReqTypes1.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// sqlSelectClientsOrgs
			// 
			this.sqlSelectClientsOrgs.CommandText = @"SELECT OrgsClients.ClientID, OrgsClients.OrgID, OrgsClients.Direction, OrgsClients.IsAvailable, Orgs.OrgName, Orgs.CodeINN, Orgs.IsRemoved FROM OrgsClients INNER JOIN Orgs ON OrgsClients.OrgID = Orgs.OrgID WHERE (OrgsClients.ClientID = @ClientID) AND (Orgs.IsRemoved = 0)";
			this.sqlSelectClientsOrgs.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ClientID", System.Data.SqlDbType.Int, 4, "ClientID"));
			// 
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = "[InterestRatesSelectCommand]";
			this.sqlSelectCommand3.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = ((string)(configurationAppSettings.GetValue("ConnectionString", typeof(string))));
			// 
			// daInterestRateList
			// 
			this.daInterestRateList.DeleteCommand = this.sqlDeleteCommand1;
			this.daInterestRateList.InsertCommand = this.sqlInsertCommand1;
			this.daInterestRateList.SelectCommand = this.sqlSelectCommand1;
			this.daInterestRateList.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										 new System.Data.Common.DataTableMapping("Table", "InterestRates", new System.Data.Common.DataColumnMapping[] {
																																																						  new System.Data.Common.DataColumnMapping("RateID", "RateID"),
																																																						  new System.Data.Common.DataColumnMapping("ClientID", "ClientID"),
																																																						  new System.Data.Common.DataColumnMapping("RequestTypeID", "RequestTypeID"),
																																																						  new System.Data.Common.DataColumnMapping("IsNormal", "IsNormal"),
																																																						  new System.Data.Common.DataColumnMapping("ServiceCharge", "ServiceCharge"),
																																																						  new System.Data.Common.DataColumnMapping("MaxSum", "MaxSum")})});
			this.daInterestRateList.UpdateCommand = this.sqlUpdateCommand1;
			// 
			// sqlDeleteCommand1
			// 
			this.sqlDeleteCommand1.CommandText = "DELETE FROM InterestRates WHERE (RateID = @Original_RateID)";
			this.sqlDeleteCommand1.Connection = this.sqlConnection1;
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RateID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RateID", System.Data.DataRowVersion.Original, null));
			// 
			// sqlInsertCommand1
			// 
			this.sqlInsertCommand1.CommandText = @"INSERT INTO InterestRates(ClientID, RequestTypeID, IsNormal, ServiceCharge, MaxSum) VALUES (@ClientID, @RequestTypeID, @IsNormal, @ServiceCharge, @MaxSum); SELECT RateID, ClientID, RequestTypeID, IsNormal, ServiceCharge, MaxSum FROM InterestRates WHERE (RateID = @@IDENTITY)";
			this.sqlInsertCommand1.Connection = this.sqlConnection1;
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ClientID", System.Data.SqlDbType.Int, 4, "ClientID"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RequestTypeID", System.Data.SqlDbType.Int, 4, "RequestTypeID"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNormal", System.Data.SqlDbType.Bit, 1, "IsNormal"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ServiceCharge", System.Data.SqlDbType.Float, 8, "ServiceCharge"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MaxSum", System.Data.SqlDbType.Float, 8, "MaxSum"));
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT RateID, ClientID, RequestTypeID, IsNormal, ServiceCharge, MaxSum FROM Inte" +
				"restRates";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlUpdateCommand1
			// 
			this.sqlUpdateCommand1.CommandText = @"UPDATE InterestRates SET ClientID = @ClientID, RequestTypeID = @RequestTypeID, IsNormal = @IsNormal, ServiceCharge = @ServiceCharge, MaxSum = @MaxSum WHERE (RateID = @Original_RateID); SELECT RateID, ClientID, RequestTypeID, IsNormal, ServiceCharge, MaxSum FROM InterestRates WHERE (RateID = @RateID)";
			this.sqlUpdateCommand1.Connection = this.sqlConnection1;
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ClientID", System.Data.SqlDbType.Int, 4, "ClientID"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RequestTypeID", System.Data.SqlDbType.Int, 4, "RequestTypeID"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNormal", System.Data.SqlDbType.Bit, 1, "IsNormal"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ServiceCharge", System.Data.SqlDbType.Float, 8, "ServiceCharge"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MaxSum", System.Data.SqlDbType.Float, 8, "MaxSum"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RateID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RateID", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RateID", System.Data.SqlDbType.Int, 4, "RateID"));
			// 
			// daReqTypes
			// 
			this.daReqTypes.SelectCommand = this.sqlSelectCommand4;
			this.daReqTypes.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																								 new System.Data.Common.DataTableMapping("Table", "ClientsRequestTypes", new System.Data.Common.DataColumnMapping[] {
																																																						new System.Data.Common.DataColumnMapping("RequestTypeID", "RequestTypeID"),
																																																						new System.Data.Common.DataColumnMapping("RequestTypeName", "RequestTypeName"),
																																																						new System.Data.Common.DataColumnMapping("IsInner", "IsInner")})});
			// 
			// sqlSelectCommand4
			// 
			this.sqlSelectCommand4.CommandText = "SELECT RequestTypeID, RequestTypeName, IsInner FROM ClientsRequestTypes";
			this.sqlSelectCommand4.Connection = this.sqlConnection1;
			// 
			// dsInterestRateList1
			// 
			this.dsInterestRateList1.DataSetName = "dsInterestRateList";
			this.dsInterestRateList1.Locale = new System.Globalization.CultureInfo("ru-RU");
			((System.ComponentModel.ISupportInitialize)(this.dsInterestRate1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsReqTypes1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsInterestRateList1)).EndInit();

		}
		#endregion

		public BPS.BLL.Clients.DataSets.dsInterestRate DsInterestRates
		{
			get
			{
				return this.dsInterestRate1;
			}
		}

		public BPS.BLL.Clients.DataSets.dsInterestRateList DSInterestRateList
		{
			get
			{
				return this.dsInterestRateList1;
			}
		}

        public BPS.BLL.ClientsRequests.DataSets.dsReqTypes DSReqTypes
		{
			get
			{
				return this.dsReqTypes1;
			}
		}

		public void CreateRateView()
		{
			this.dsInterestRate1.InterestRate.Clear();
			
			for(int i=0; i< this.dsReqTypes1.ClientsRequestTypes.Count; i++)
			{
                BPS.BLL.ClientsRequests.DataSets.dsReqTypes.ClientsRequestTypesRow rw = this.dsReqTypes1.ClientsRequestTypes[i];
				BLL.Clients.DataSets.dsInterestRate.InterestRateRow dr = this.dsInterestRate1.InterestRate.NewInterestRateRow();
				dr.ReqType = rw.RequestTypeID;
				dr.ReqTypeName = rw.RequestTypeName;
				dr.SetRateBlackNull();
				dr.SetRateNormalNull();// = Convert.DBNull;
				this.dsInterestRate1.InterestRate.AddInterestRateRow(dr);//.dtRate.Rows.Add(dr);
			}
			this.dsInterestRate1.InterestRate.AcceptChanges();
		}

		public void createRateView(BPS.BLL.Clients.DataSets.dsClients.ClientsRow rwC)
		{
			this.dsInterestRate1.InterestRate.Clear();
			for(int i = 0; i < this.dsReqTypes1.ClientsRequestTypes.Count; i ++)
			{
                BPS.BLL.ClientsRequests.DataSets.dsReqTypes.ClientsRequestTypesRow rw = DSReqTypes.ClientsRequestTypes[i];
				BLL.Clients.DataSets.dsInterestRate.InterestRateRow dr = this.dsInterestRate1.InterestRate.NewInterestRateRow();
				dr.ReqType = rw.RequestTypeID;
				dr.ReqTypeName = rw.RequestTypeName;
				DataRow [] drCharge = this.dsInterestRateList1.InterestRates.Select("ClientID=" + rwC.ClientID.ToString() +
					" and RequestTypeID=" + rw.RequestTypeID.ToString() + " and IsNormal=false");
				if(drCharge.Length == 0)
					dr.SetRateBlackNull();
				else dr.RateBlack = (double)drCharge[0]["ServiceCharge"]*100;
				DataRow [] drChargeN = this.dsInterestRateList1.InterestRates.Select("ClientID=" + rwC.ClientID.ToString() +
					" and RequestTypeID=" + rw.RequestTypeID.ToString() + " and IsNormal=true");
				if(drChargeN.Length == 0)
					dr.SetRateNormalNull();
				else dr.RateNormal = (double)drChargeN[0]["ServiceCharge"]*100;
				this.dsInterestRate1.InterestRate.AddInterestRateRow(dr);
			}
			this.dsInterestRate1.InterestRate.AcceptChanges();
		}

		public void FillDSInterestRateList()
		{
			try
			{
				this.dsInterestRateList1.Clear();
				this.daInterestRateList.Fill(this.dsInterestRateList1.InterestRates);
			}
			catch(Exception ex)
			{
				AM_Controls.MsgBoxX.Show(ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		public void UpdateInterestRateList()
		{
			try
			{
				this.daInterestRateList.Update(this.dsInterestRateList1.InterestRates);
			}
			catch(Exception ex)
			{
				AM_Controls.MsgBoxX.Show(ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		public void FillDSReqType()
		{
			try
			{
				this.dsReqTypes1.Clear();
				this.daReqTypes.Fill(this.dsReqTypes1);
			}
			catch(Exception ex)
			{
				AM_Controls.MsgBoxX.Show(ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		public void SaveChangesRates(BPS.BLL.Clients.DataSets.dsClients.ClientsRow rw)
		{
			int iClientID = rw.ClientID;
			for(int i = 0; i < this.dsInterestRate1.InterestRate.Rows.Count; i ++)
			{
				BLL.Clients.DataSets.dsInterestRate.InterestRateRow dr = (BLL.Clients.DataSets.dsInterestRate.InterestRateRow)this.dsInterestRate1.InterestRate.Rows[i];
				DataRow [] drInterest = this.dsInterestRateList1.InterestRates.Select("ClientID=" + iClientID.ToString() +
					" and RequestTypeID=" + dr.ReqType.ToString() + " and IsNormal=false");
				if(!dr.IsRateBlackNull())// != Convert.DBNull)
				{
					if(drInterest.Length == 0)
					{
						BPS.BLL.Clients.DataSets.dsInterestRateList.InterestRatesRow newIntRow = (BPS.BLL.Clients.DataSets.dsInterestRateList.InterestRatesRow)this.dsInterestRateList1.InterestRates.NewRow();
						newIntRow.ClientID = iClientID;
						newIntRow.RequestTypeID = dr.ReqType;
						newIntRow.IsNormal = false;
						newIntRow.ServiceCharge = dr.RateBlack/100;
						newIntRow.MaxSum = 0;
						this.dsInterestRateList1.InterestRates.Rows.Add((DataRow) newIntRow);
					}
					else
					{
						drInterest[0]["ServiceCharge"] = ((double)dr.RateBlack/100).ToString();
					}
				}
				else
				{
					if(drInterest.Length == 1)
					{
						drInterest[0].Delete();
					}
				}
				DataRow [] drInterestN = this.dsInterestRateList1.InterestRates.Select("ClientID=" + iClientID.ToString() +
					" and RequestTypeID=" + dr.ReqType.ToString() + " and IsNormal=true");
				if(!dr.IsRateNormalNull())
				{
					if(drInterestN.Length == 0)
					{
						BPS.BLL.Clients.DataSets.dsInterestRateList.InterestRatesRow newIntRow = (BPS.BLL.Clients.DataSets.dsInterestRateList.InterestRatesRow)this.dsInterestRateList1.InterestRates.NewRow();
						newIntRow.ClientID = iClientID;
						newIntRow.RequestTypeID = dr.ReqType;
						newIntRow.IsNormal = true;
						newIntRow.ServiceCharge = dr.RateNormal/100;
						newIntRow.MaxSum = 0;
						this.dsInterestRateList1.InterestRates.Rows.Add((DataRow) newIntRow);
					}
					else
					{
						drInterestN[0]["ServiceCharge"] = (dr.RateNormal/100).ToString();
					}
				}
				else
				{
					if(drInterestN.Length == 1)
					{
						drInterestN[0].Delete();
					}
				}
			}
			UpdateInterestRateList();
		}

	}
}
