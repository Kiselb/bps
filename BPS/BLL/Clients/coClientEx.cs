using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BPS.BLL.Clients
{
	/// <summary>
	/// Summary description for coClientEx.
	/// </summary>
	public class coClientEx : System.ComponentModel.Component
	{
		public delegate void DataGridStyleEventHandler(DataGridTableStyle GridStyle);
		public event DataGridStyleEventHandler DataGridStyle;
		public delegate void AddClientEventHandler(int iClientID);
		public event AddClientEventHandler AddClient;
		private System.Data.SqlClient.SqlConnection sqlConnection1;
		private BPS.BLL.Clients.DataSets.dsClients dsClients1;
		private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		private BPS.BLL.Clients.DataSets.dsGroups dsGroups1;
		private BPS.BLL.Currency.DataSets.dsCurr dsCurr1;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.Data.SqlClient.SqlCommand sqlInsertCommand2;
		private System.Data.SqlClient.SqlCommand sqlUpdateCommand2;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		private System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		private System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
		private System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
		private System.Data.SqlClient.SqlCommand sqlDeleteCommand2;
		private System.Data.SqlClient.SqlDataAdapter sqldaClients;
		private System.Data.SqlClient.SqlDataAdapter sqldaSelOrgsClients;
		private System.Data.SqlClient.SqlCommand sqlCommand2;
		private System.Data.SqlClient.SqlCommand sqlSelectClientsOrgs;
		private System.Data.SqlClient.SqlCommand sqlCommand1;
		private BPS.BLL.Clients.DataSets.dsOrgsClients dsOrgsClients1;
		private System.Data.SqlClient.SqlDataAdapter sqldaGetAvailableOrgs;
		private System.Data.SqlClient.SqlCommand sqlCommand3;
		private System.Data.SqlClient.SqlCommand sqlCommand4;
		private System.Data.SqlClient.SqlCommand sqlCommand5;
		//private DataView dvCurr;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		//private System.ComponentModel.Container components = null;

		public coClientEx(System.ComponentModel.IContainer container)
		{
			/// <summary>
			/// Required for Windows.Forms Class Composition Designer support
			/// </summary>
			container.Add(this);
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
		public BPS.BLL.Clients.DataSets.dsClients DsClients
		{
			get
			{
				return this.dsClients1;
			}
		}

		public BPS.BLL.Clients.DataSets.dsGroups DsGroups
		{
			get
			{
				return this.dsGroups1;
			}
		}

		public coClientEx(System.Data.SqlClient.SqlConnection conn)
		{
			/// <summary>
			/// Required for Windows.Forms Class Composition Designer support
			/// </summary>
			InitializeComponent();
			this.sqldaClients.SelectCommand.Connection = 
			this.sqldaClients.InsertCommand.Connection = 
			this.sqldaClients.UpdateCommand.Connection = 
			this.sqldaClients.DeleteCommand.Connection = 
			this.sqlDataAdapter2.SelectCommand.Connection = 
			this.sqlDataAdapter2.InsertCommand.Connection = 
			this.sqlDataAdapter2.UpdateCommand.Connection = 
			this.sqlDataAdapter2.DeleteCommand.Connection = 
			this.sqlConnection1 = conn;
			this.FillClients();
			this.FillGroups();
			this.dsClients1.Clients.ClientsRowChanged += new BPS.BLL.Clients.DataSets.dsClients.ClientsRowChangeEventHandler(OnDeleteClientRow);
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
		private void OnDeleteClientRow(object sender, BPS.BLL.Clients.DataSets.dsClients.ClientsRowChangeEvent e)
		{
			if(e.Row.RowState == DataRowState.Unchanged)
			   e.Row.ClearErrors();
		}
		public BPS.BLL.Currency.DataSets.dsCurr CurrDataSet
		{
			set
			{
				this.dsCurr1 = value;
			}
		}

		public int FillClients()
		{
			try
			{
				this.dsClients1.Clear();
				return this.sqldaClients.Fill(this.dsClients1);
			}
			catch
			{
				return 0;
			}
		}
		public int FillGroups()
		{
			try
			{
				this.dsGroups1.Clear();
				return this.sqlDataAdapter2.Fill(this.dsGroups1);
			}
			catch
			{
				return 0;
			}
		}

		public int GetAvailableOrgs(int ClientID, BPS.BLL.Clients.DataSets.dsOrgsClients dsOrgsClients)
		{
			dsOrgsClients.Clear();
			sqldaGetAvailableOrgs.SelectCommand.Connection= this.sqlConnection1;
			sqldaGetAvailableOrgs.SelectCommand.Parameters["@ClientID"].Value = ClientID;
			return sqldaGetAvailableOrgs.Fill(dsOrgsClients);
		}

		private void OnFillOrgsClients(int ClientID)
		{
			this.sqldaSelOrgsClients.SelectCommand = this.sqlSelectClientsOrgs;
			this.sqlSelectClientsOrgs.Parameters["@ClientID"].Value = ClientID;
			try
			{
				this.dsOrgsClients1.Clear();
				this.sqldaSelOrgsClients.Fill(this.dsOrgsClients1);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		private void OnUpdateOrgsClients()
		{
			if (this.dsOrgsClients1.HasChanges()) 
			{
				this.sqldaSelOrgsClients.Update(this.dsOrgsClients1);
			}
		}
		
		public void ShowList(System.Windows.Forms.Form parent )
		{
			if ( App.FindWindow(parent, typeof(BPS._Forms.Clients.ClientView )) )
				return;

			BPS._Forms.Clients.ClientView dlg = new BPS._Forms.Clients.ClientView(this.dsClients1, this.dsGroups1);
			dlg.MdiParent = parent;
			dlg.AddGroup += new BPS._Forms.Clients.ClientView.UpdateGroupEventHandler(OnUpdateGroup);
			dlg.UpdateDs += new BPS._Forms.Clients.ClientView.UpdateDsEventHandler(OnUpdateDs);
			dlg.DataGridStyle += new BPS._Forms.Clients.ClientView.DataGridStyleEventHandler(OnSetStyle);
			dlg.RefreshDs += new BPS._Forms.Clients.ClientView.RefreshEventHandler(OnRefreshDs);
			dlg.FillDSOrgsClients += new BPS._Forms.Clients.ClientView.FillDSOrgsClientsEventHandler(OnFillOrgsClients);
			dlg.UpdateDSOrgsClients += new BPS._Forms.Clients.ClientView.UpdateDSOrgsClientsEventHandler(OnUpdateOrgsClients);
			dlg.DSOrgsClients = this.dsOrgsClients1;
			dlg.Show();
		}
		private void OnRefreshDs()
		{
			this.FillClients();
			this.FillGroups();
		}
		private void OnSetStyle(DataGridTableStyle GridStyle)
		{
			this.DataGridStyle(GridStyle);
		}
		private bool OnUpdateDs(bool isAdding)
		{
			if(isAdding)
			{
				try
				{
					UpdateClients();
					int iClientID = ((BPS.BLL.Clients.DataSets.dsClients.ClientsRow)this.dsClients1.Clients.Rows[this.dsClients1.Clients.Rows.Count-1]).ClientID;
					this.AddClient(iClientID);
				}
				catch(Exception ex)
				{
					AM_Controls.MsgBoxX.Show(ex.Message,"BPS",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
					return false;
				}
			}
			else
				UpdateClients();
			return true;
		}

		
		private void OnUpdateGroup()
		{
			UpdateGroups();
		}

		
		public void UpdateGroups()
		{
			try
			{
				this.sqlDataAdapter2.Update(this.dsGroups1);
			}
			catch(Exception ex)
			{
				AM_Controls.MsgBoxX.Show(ex.Message,"BPS",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				this.dsGroups1.RejectChanges();
			}
		}

		public void UpdateClients()
		{
			try
			{
					this.sqldaClients.Update(this.dsClients1);
			}
			catch(Exception ex)
			{
				AM_Controls.MsgBoxX.Show(ex.Message,"BPS",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				this.dsClients1.RejectChanges();
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
			this.sqldaClients = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDeleteCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlInsertCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand2 = new System.Data.SqlClient.SqlCommand();
			this.dsClients1 = new BPS.BLL.Clients.DataSets.dsClients();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
			this.dsGroups1 = new BPS.BLL.Clients.DataSets.dsGroups();
			this.dsCurr1 = new BPS.BLL.Currency.DataSets.dsCurr();
			this.sqldaSelOrgsClients = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectClientsOrgs = new System.Data.SqlClient.SqlCommand();
			this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
			this.dsOrgsClients1 = new BPS.BLL.Clients.DataSets.dsOrgsClients();
			this.sqldaGetAvailableOrgs = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlCommand4 = new System.Data.SqlClient.SqlCommand();
			this.sqlCommand5 = new System.Data.SqlClient.SqlCommand();
			((System.ComponentModel.ISupportInitialize)(this.dsClients1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsGroups1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsCurr1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsOrgsClients1)).BeginInit();
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = ((string)(configurationAppSettings.GetValue("ConnectionString", typeof(string))));
			// 
			// sqldaClients
			// 
			this.sqldaClients.DeleteCommand = this.sqlDeleteCommand2;
			this.sqldaClients.InsertCommand = this.sqlInsertCommand2;
			this.sqldaClients.SelectCommand = this.sqlSelectCommand1;
			this.sqldaClients.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																								   new System.Data.Common.DataTableMapping("Table", "Clients", new System.Data.Common.DataColumnMapping[] {
																																																			  new System.Data.Common.DataColumnMapping("ClientID", "ClientID"),
																																																			  new System.Data.Common.DataColumnMapping("ClientGroupID", "ClientGroupID"),
																																																			  new System.Data.Common.DataColumnMapping("ClientName", "ClientName"),
																																																			  new System.Data.Common.DataColumnMapping("ClientRemarks", "ClientRemarks"),
																																																			  new System.Data.Common.DataColumnMapping("IsInner", "IsInner"),
																																																			  new System.Data.Common.DataColumnMapping("IsSpecial", "IsSpecial"),
																																																			  new System.Data.Common.DataColumnMapping("Password", "Password")})});
			this.sqldaClients.UpdateCommand = this.sqlUpdateCommand2;
			// 
			// sqlDeleteCommand2
			// 
			this.sqlDeleteCommand2.CommandText = "[ClientDelete]";
			this.sqlDeleteCommand2.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlDeleteCommand2.Connection = this.sqlConnection1;
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ClientID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "ClientID", System.Data.DataRowVersion.Current, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// sqlInsertCommand2
			// 
			this.sqlInsertCommand2.CommandText = @"INSERT INTO Clients (ClientGroupID, ClientName, ClientRemarks, IsInner, IsSpecial, Password) VALUES (@ClientGroupID, @ClientName, @ClientRemarks, @IsInner, @IsSpecial, @Password); SELECT Clients.ClientID, Clients.ClientGroupID, Clients.ClientName, Clients.ClientRemarks, ClientsGroups.ClientGroupName, Clients.IsInner, Clients.IsSpecial, Clients.Password FROM Clients INNER JOIN ClientsGroups ON Clients.ClientGroupID = ClientsGroups.ClientGroupID WHERE (Clients.ClientID = @@IDENTITY)";
			this.sqlInsertCommand2.Connection = this.sqlConnection1;
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ClientGroupID", System.Data.SqlDbType.Int, 4, "ClientGroupID"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ClientName", System.Data.SqlDbType.NVarChar, 50, "ClientName"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ClientRemarks", System.Data.SqlDbType.NVarChar, 255, "ClientRemarks"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsInner", System.Data.SqlDbType.Bit, 1, "IsInner"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsSpecial", System.Data.SqlDbType.Bit, 1, "IsSpecial"));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Password", System.Data.SqlDbType.NVarChar, 48, "Password"));
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT Clients.ClientID, Clients.ClientGroupID, Clients.ClientName, Clients.ClientRemarks, Clients.IsInner, Clients.IsSpecial, Clients.Password, ClientsGroups.ClientGroupName FROM Clients INNER JOIN ClientsGroups ON Clients.ClientGroupID = ClientsGroups.ClientGroupID ORDER BY Clients.ClientName";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlUpdateCommand2
			// 
			this.sqlUpdateCommand2.CommandText = @"UPDATE Clients SET ClientGroupID = @ClientGroupID, ClientName = @ClientName, ClientRemarks = @ClientRemarks, IsInner = @IsInner, IsSpecial = @IsSpecial, Password = @Password WHERE (ClientID = @Original_ClientID) AND (ClientGroupID = @Original_ClientGroupID) AND (ClientName = @Original_ClientName) AND (ClientRemarks = @Original_ClientRemarks) AND (IsInner = @Original_IsInner) AND (IsSpecial = @Original_IsSpecial OR @Original_IsSpecial IS NULL AND IsSpecial IS NULL) AND (Password = @Original_Password OR @Original_Password IS NULL AND Password IS NULL); SELECT ClientID, ClientGroupID, ClientName, ClientRemarks, IsInner, IsSpecial, Password FROM Clients WHERE (ClientID = @ClientID)";
			this.sqlUpdateCommand2.Connection = this.sqlConnection1;
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ClientGroupID", System.Data.SqlDbType.Int, 4, "ClientGroupID"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ClientName", System.Data.SqlDbType.NVarChar, 50, "ClientName"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ClientRemarks", System.Data.SqlDbType.NVarChar, 255, "ClientRemarks"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsInner", System.Data.SqlDbType.Bit, 1, "IsInner"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsSpecial", System.Data.SqlDbType.Bit, 1, "IsSpecial"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Password", System.Data.SqlDbType.NVarChar, 128, "Password"));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ClientID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ClientID", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ClientGroupID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ClientGroupID", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ClientName", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ClientName", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ClientRemarks", System.Data.SqlDbType.NVarChar, 255, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ClientRemarks", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_IsInner", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IsInner", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_IsSpecial", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IsSpecial", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Password", System.Data.SqlDbType.NVarChar, 128, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Password", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ClientID", System.Data.SqlDbType.Int, 4, "ClientID"));
			// 
			// dsClients1
			// 
			this.dsClients1.DataSetName = "dsClients";
			this.dsClients1.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.DeleteCommand = this.sqlDeleteCommand1;
			this.sqlDataAdapter2.InsertCommand = this.sqlInsertCommand1;
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "ClientsGroups", new System.Data.Common.DataColumnMapping[] {
																																																					   new System.Data.Common.DataColumnMapping("ClientGroupID", "ClientGroupID"),
																																																					   new System.Data.Common.DataColumnMapping("ClientGroupName", "ClientGroupName"),
																																																					   new System.Data.Common.DataColumnMapping("ClientGroupRemarks", "ClientGroupRemarks"),
																																																					   new System.Data.Common.DataColumnMapping("IsInner", "IsInner"),
																																																					   new System.Data.Common.DataColumnMapping("IsSpecial", "IsSpecial")})});
			this.sqlDataAdapter2.UpdateCommand = this.sqlUpdateCommand1;
			// 
			// sqlDeleteCommand1
			// 
			this.sqlDeleteCommand1.CommandText = "DELETE FROM ClientsGroups WHERE (ClientGroupID = @Original_ClientGroupID) AND (Cl" +
				"ientGroupName = @Original_ClientGroupName) AND (ClientGroupRemarks = @Original_C" +
				"lientGroupRemarks) AND (IsInner = @Original_IsInner) AND (IsSpecial = @Original_" +
				"IsSpecial)";
			this.sqlDeleteCommand1.Connection = this.sqlConnection1;
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ClientGroupID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ClientGroupID", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ClientGroupName", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ClientGroupName", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ClientGroupRemarks", System.Data.SqlDbType.NVarChar, 512, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ClientGroupRemarks", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_IsInner", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IsInner", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_IsSpecial", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IsSpecial", System.Data.DataRowVersion.Original, null));
			// 
			// sqlInsertCommand1
			// 
			this.sqlInsertCommand1.CommandText = @"INSERT INTO ClientsGroups(ClientGroupName, ClientGroupRemarks, IsInner, IsSpecial) VALUES (@ClientGroupName, @ClientGroupRemarks, @IsInner, @IsSpecial); SELECT ClientGroupID, ClientGroupName, ClientGroupRemarks, IsInner, IsSpecial FROM ClientsGroups WHERE (ClientGroupID = @@IDENTITY)";
			this.sqlInsertCommand1.Connection = this.sqlConnection1;
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ClientGroupName", System.Data.SqlDbType.NVarChar, 50, "ClientGroupName"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ClientGroupRemarks", System.Data.SqlDbType.NVarChar, 512, "ClientGroupRemarks"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsInner", System.Data.SqlDbType.Bit, 1, "IsInner"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsSpecial", System.Data.SqlDbType.Bit, 1, "IsSpecial"));
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "SELECT ClientGroupID, ClientGroupName, ClientGroupRemarks, IsInner, IsSpecial FRO" +
				"M ClientsGroups ORDER BY ClientGroupName";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			// 
			// sqlUpdateCommand1
			// 
			this.sqlUpdateCommand1.CommandText = @"UPDATE ClientsGroups SET ClientGroupName = @ClientGroupName, ClientGroupRemarks = @ClientGroupRemarks, IsInner = @IsInner, IsSpecial = @IsSpecial WHERE (ClientGroupID = @Original_ClientGroupID) AND (ClientGroupName = @Original_ClientGroupName) AND (ClientGroupRemarks = @Original_ClientGroupRemarks) AND (IsInner = @Original_IsInner) AND (IsSpecial = @Original_IsSpecial); SELECT ClientGroupID, ClientGroupName, ClientGroupRemarks, IsInner, IsSpecial FROM ClientsGroups WHERE (ClientGroupID = @ClientGroupID)";
			this.sqlUpdateCommand1.Connection = this.sqlConnection1;
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ClientGroupName", System.Data.SqlDbType.NVarChar, 50, "ClientGroupName"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ClientGroupRemarks", System.Data.SqlDbType.NVarChar, 512, "ClientGroupRemarks"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsInner", System.Data.SqlDbType.Bit, 1, "IsInner"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsSpecial", System.Data.SqlDbType.Bit, 1, "IsSpecial"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ClientGroupID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ClientGroupID", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ClientGroupName", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ClientGroupName", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ClientGroupRemarks", System.Data.SqlDbType.NVarChar, 512, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ClientGroupRemarks", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_IsInner", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IsInner", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_IsSpecial", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IsSpecial", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ClientGroupID", System.Data.SqlDbType.Int, 4, "ClientGroupID"));
			// 
			// dsGroups1
			// 
			this.dsGroups1.DataSetName = "dsGroups";
			this.dsGroups1.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// dsCurr1
			// 
			this.dsCurr1.DataSetName = "dsCurr";
			this.dsCurr1.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// sqldaSelOrgsClients
			// 
			this.sqldaSelOrgsClients.InsertCommand = this.sqlCommand2;
			this.sqldaSelOrgsClients.SelectCommand = this.sqlSelectClientsOrgs;
			this.sqldaSelOrgsClients.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										  new System.Data.Common.DataTableMapping("Table", "OrgsClients", new System.Data.Common.DataColumnMapping[] {
																																																						 new System.Data.Common.DataColumnMapping("ClientID", "ClientID"),
																																																						 new System.Data.Common.DataColumnMapping("OrgID", "OrgID"),
																																																						 new System.Data.Common.DataColumnMapping("Direction", "Direction"),
																																																						 new System.Data.Common.DataColumnMapping("IsAvailable", "IsAvailable"),
																																																						 new System.Data.Common.DataColumnMapping("OrgName", "OrgName"),
																																																						 new System.Data.Common.DataColumnMapping("CodeINN", "CodeINN"),
																																																						 new System.Data.Common.DataColumnMapping("IsRemoved", "IsRemoved")})});
			this.sqldaSelOrgsClients.UpdateCommand = this.sqlCommand1;
			// 
			// sqlCommand2
			// 
			this.sqlCommand2.CommandText = "INSERT INTO OrgsClients (ClientID, OrgID, Direction, IsAvailable) VALUES (@Client" +
				"ID, @OrgID, @Direction, @IsAvailable)";
			this.sqlCommand2.Connection = this.sqlConnection1;
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ClientID", System.Data.SqlDbType.Int, 4, "ClientID"));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrgID", System.Data.SqlDbType.Int, 4, "OrgID"));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Direction", System.Data.SqlDbType.TinyInt, 1, "Direction"));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsAvailable", System.Data.SqlDbType.Bit, 1, "IsAvailable"));
			// 
			// sqlSelectClientsOrgs
			// 
			this.sqlSelectClientsOrgs.CommandText = @"SELECT OrgsClients.ClientID, OrgsClients.OrgID, OrgsClients.Direction, OrgsClients.IsAvailable, Orgs.OrgName, Orgs.CodeINN, Orgs.IsRemoved FROM OrgsClients INNER JOIN Orgs ON OrgsClients.OrgID = Orgs.OrgID WHERE (OrgsClients.ClientID = @ClientID) AND (Orgs.IsRemoved = 0)";
			this.sqlSelectClientsOrgs.Connection = this.sqlConnection1;
			this.sqlSelectClientsOrgs.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ClientID", System.Data.SqlDbType.Int, 4, "ClientID"));
			// 
			// sqlCommand1
			// 
			this.sqlCommand1.CommandText = "UPDATE OrgsClients SET IsAvailable = @IsAvailable WHERE (ClientID = @Original_Cli" +
				"entID) AND (Direction = @Original_Direction) AND (OrgID = @Original_OrgID)";
			this.sqlCommand1.Connection = this.sqlConnection1;
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsAvailable", System.Data.SqlDbType.Bit, 1, "IsAvailable"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ClientID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ClientID", System.Data.DataRowVersion.Original, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Direction", System.Data.SqlDbType.TinyInt, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Direction", System.Data.DataRowVersion.Original, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_OrgID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OrgID", System.Data.DataRowVersion.Original, null));
			// 
			// dsOrgsClients1
			// 
			this.dsOrgsClients1.DataSetName = "dsOrgsClients";
			this.dsOrgsClients1.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// sqldaGetAvailableOrgs
			// 
			this.sqldaGetAvailableOrgs.InsertCommand = this.sqlCommand3;
			this.sqldaGetAvailableOrgs.SelectCommand = this.sqlCommand4;
			this.sqldaGetAvailableOrgs.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																											new System.Data.Common.DataTableMapping("Table", "OrgsClients", new System.Data.Common.DataColumnMapping[] {
																																																						   new System.Data.Common.DataColumnMapping("ClientID", "ClientID"),
																																																						   new System.Data.Common.DataColumnMapping("OrgID", "OrgID"),
																																																						   new System.Data.Common.DataColumnMapping("Direction", "Direction"),
																																																						   new System.Data.Common.DataColumnMapping("IsAvailable", "IsAvailable"),
																																																						   new System.Data.Common.DataColumnMapping("OrgName", "OrgName"),
																																																						   new System.Data.Common.DataColumnMapping("CodeINN", "CodeINN"),
																																																						   new System.Data.Common.DataColumnMapping("IsRemoved", "IsRemoved"),
																																																						   new System.Data.Common.DataColumnMapping("CodeKPP", "CodeKPP")})});
			this.sqldaGetAvailableOrgs.UpdateCommand = this.sqlCommand5;
			// 
			// sqlCommand3
			// 
			this.sqlCommand3.CommandText = "INSERT INTO OrgsClients (ClientID, OrgID, Direction, IsAvailable) VALUES (@Client" +
				"ID, @OrgID, @Direction, @IsAvailable)";
			this.sqlCommand3.Connection = this.sqlConnection1;
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ClientID", System.Data.SqlDbType.Int, 4, "ClientID"));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrgID", System.Data.SqlDbType.Int, 4, "OrgID"));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Direction", System.Data.SqlDbType.TinyInt, 1, "Direction"));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsAvailable", System.Data.SqlDbType.Bit, 1, "IsAvailable"));
			// 
			// sqlCommand4
			// 
			this.sqlCommand4.CommandText = @"SELECT OrgsClients.ClientID, OrgsClients.OrgID, OrgsClients.Direction, OrgsClients.IsAvailable, Orgs.OrgName, Orgs.CodeINN, Orgs.IsRemoved, Orgs.CodeKPP FROM OrgsClients INNER JOIN Orgs ON OrgsClients.OrgID = Orgs.OrgID WHERE (OrgsClients.ClientID = @ClientID) AND (Orgs.IsRemoved = 0) AND (OrgsClients.IsAvailable = 1) ORDER BY Orgs.OrgName";
			this.sqlCommand4.Connection = this.sqlConnection1;
			this.sqlCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ClientID", System.Data.SqlDbType.Int, 4, "ClientID"));
			// 
			// sqlCommand5
			// 
			this.sqlCommand5.CommandText = "UPDATE OrgsClients SET IsAvailable = @IsAvailable WHERE (ClientID = @Original_Cli" +
				"entID) AND (Direction = @Original_Direction) AND (OrgID = @Original_OrgID)";
			this.sqlCommand5.Connection = this.sqlConnection1;
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsAvailable", System.Data.SqlDbType.Bit, 1, "IsAvailable"));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ClientID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ClientID", System.Data.DataRowVersion.Original, null));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Direction", System.Data.SqlDbType.TinyInt, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Direction", System.Data.DataRowVersion.Original, null));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_OrgID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OrgID", System.Data.DataRowVersion.Original, null));
			((System.ComponentModel.ISupportInitialize)(this.dsClients1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsGroups1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsCurr1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsOrgsClients1)).EndInit();

		}
		#endregion
	}
}
