using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
 
namespace BPS._Forms
{
	/// <summary>
	/// Summary description for PaymsOrdersUnknownList.
	/// </summary>
	public class PaymsOrdersUnknownList : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Data.SqlClient.SqlConnection sqlConnection1;
		private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private BPS._Forms.dsPaymentsOrdersUnknownList dsPaymentsOrdersUnknownList1;
		private System.Data.DataView dvUnknownList;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnHeaderID;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnHeaderDate;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnPaymentOrderID;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnPaymentOrderDate;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnPaymentOrderSum;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnPaymentNo;
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnOrgName;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnRAccount;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnCodeINN;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnOrgNameContra;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnRAccountContra;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnCodeINNContra;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnPaymentOrderPurpose;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnRemarks;
		private System.Windows.Forms.ToolBarButton tbtnRefresh;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ToolBarButton tbtnClentSetLink;
		private System.Data.SqlClient.SqlCommand sqlCmdSetLinkByClient;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cmbClients;
		private System.Data.DataView dvClients;
		private AM_Controls.TextBoxV tbServiceCharge;
		private System.Windows.Forms.ToolBarButton tbbHistory;
		private System.Windows.Forms.Label label2;

		public PaymsOrdersUnknownList()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			this.dvClients.Table = App.DsClients.Clients;
			this.cmbClients.DataSource = this.dvClients;
			this.cmbClients.DisplayMember = "ClientName";
			this.cmbClients.ValueMember = "ClientID";
			this.dvClients.RowFilter = "IsInner=false and IsSpecial=false";

			try 
			{
				App.SetDataGridTableStyle( this.dataGridTableStyle1);
				this.sqlDataAdapter1.Fill( this.dsPaymentsOrdersUnknownList1.PaymentsOrders); 
			}
			catch(Exception ex) 
			{
				MessageBox.Show("Ошибка чтения данных: " +ex.Message, "BP2", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(PaymsOrdersUnknownList));
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.dvUnknownList = new System.Data.DataView();
			this.dsPaymentsOrdersUnknownList1 = new BPS._Forms.dsPaymentsOrdersUnknownList();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.ColumnHeaderID = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnHeaderDate = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnPaymentOrderID = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnPaymentNo = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnPaymentOrderDate = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnPaymentOrderSum = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnOrgName = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnRAccount = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnCodeINN = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnOrgNameContra = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnRAccountContra = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnCodeINNContra = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnPaymentOrderPurpose = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnRemarks = new System.Windows.Forms.DataGridTextBoxColumn();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.tbtnRefresh = new System.Windows.Forms.ToolBarButton();
			this.tbtnClentSetLink = new System.Windows.Forms.ToolBarButton();
			this.tbbHistory = new System.Windows.Forms.ToolBarButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.panel1 = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.tbServiceCharge = new AM_Controls.TextBoxV();
			this.label1 = new System.Windows.Forms.Label();
			this.cmbClients = new System.Windows.Forms.ComboBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.sqlCmdSetLinkByClient = new System.Data.SqlClient.SqlCommand();
			this.dvClients = new System.Data.DataView();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvUnknownList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsPaymentsOrdersUnknownList1)).BeginInit();
			this.panel1.SuspendLayout();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dvClients)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGrid1
			// 
			this.dataGrid1.DataMember = "";
			this.dataGrid1.DataSource = this.dvUnknownList;
			this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.ReadOnly = true;
			this.dataGrid1.Size = new System.Drawing.Size(944, 230);
			this.dataGrid1.TabIndex = 0;
			this.dataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																								  this.dataGridTableStyle1});
			// 
			// dvUnknownList
			// 
			this.dvUnknownList.Table = this.dsPaymentsOrdersUnknownList1.PaymentsOrders;
			// 
			// dsPaymentsOrdersUnknownList1
			// 
			this.dsPaymentsOrdersUnknownList1.DataSetName = "dsPaymentsOrdersUnknownList";
			this.dsPaymentsOrdersUnknownList1.Locale = new System.Globalization.CultureInfo("ru-RU");
			this.dsPaymentsOrdersUnknownList1.Namespace = "http://www.tempuri.org/dsPaymentsOrdersUnknownList.xsd";
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.DataGrid = this.dataGrid1;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.ColumnHeaderID,
																												  this.ColumnHeaderDate,
																												  this.ColumnPaymentOrderID,
																												  this.ColumnPaymentNo,
																												  this.ColumnPaymentOrderDate,
																												  this.ColumnPaymentOrderSum,
																												  this.ColumnOrgName,
																												  this.ColumnRAccount,
																												  this.ColumnCodeINN,
																												  this.ColumnOrgNameContra,
																												  this.ColumnRAccountContra,
																												  this.ColumnCodeINNContra,
																												  this.ColumnPaymentOrderPurpose,
																												  this.ColumnRemarks});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "PaymentsOrders";
			// 
			// ColumnHeaderID
			// 
			this.ColumnHeaderID.Format = "00000";
			this.ColumnHeaderID.FormatInfo = null;
			this.ColumnHeaderID.HeaderText = "ID";
			this.ColumnHeaderID.MappingName = "HeaderID";
			this.ColumnHeaderID.Width = 50;
			// 
			// ColumnHeaderDate
			// 
			this.ColumnHeaderDate.Format = "dd-MMM-yy";
			this.ColumnHeaderDate.FormatInfo = null;
			this.ColumnHeaderDate.HeaderText = "Дата Выписки";
			this.ColumnHeaderDate.MappingName = "HeaderDate";
			this.ColumnHeaderDate.NullText = "-";
			this.ColumnHeaderDate.Width = 90;
			// 
			// ColumnPaymentOrderID
			// 
			this.ColumnPaymentOrderID.Format = "000000";
			this.ColumnPaymentOrderID.FormatInfo = null;
			this.ColumnPaymentOrderID.HeaderText = "ID П/П";
			this.ColumnPaymentOrderID.MappingName = "PaymentOrderID";
			this.ColumnPaymentOrderID.Width = 50;
			// 
			// ColumnPaymentNo
			// 
			this.ColumnPaymentNo.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.ColumnPaymentNo.Format = "";
			this.ColumnPaymentNo.FormatInfo = null;
			this.ColumnPaymentNo.HeaderText = "Номер П/П";
			this.ColumnPaymentNo.MappingName = "PaymentNo";
			this.ColumnPaymentNo.NullText = "-";
			this.ColumnPaymentNo.Width = 75;
			// 
			// ColumnPaymentOrderDate
			// 
			this.ColumnPaymentOrderDate.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.ColumnPaymentOrderDate.Format = "dd-MMM-yy";
			this.ColumnPaymentOrderDate.FormatInfo = null;
			this.ColumnPaymentOrderDate.HeaderText = "Дата П/П";
			this.ColumnPaymentOrderDate.MappingName = "PaymentOrderDate";
			this.ColumnPaymentOrderDate.NullText = "-";
			this.ColumnPaymentOrderDate.Width = 90;
			// 
			// ColumnPaymentOrderSum
			// 
			this.ColumnPaymentOrderSum.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.ColumnPaymentOrderSum.Format = "#,##0.00";
			this.ColumnPaymentOrderSum.FormatInfo = null;
			this.ColumnPaymentOrderSum.HeaderText = "Сумма";
			this.ColumnPaymentOrderSum.MappingName = "PaymentOrderSum";
			this.ColumnPaymentOrderSum.NullText = "-";
			this.ColumnPaymentOrderSum.Width = 75;
			// 
			// ColumnOrgName
			// 
			this.ColumnOrgName.Format = "";
			this.ColumnOrgName.FormatInfo = null;
			this.ColumnOrgName.HeaderText = "Получатель";
			this.ColumnOrgName.MappingName = "OrgName";
			this.ColumnOrgName.NullText = "-";
			this.ColumnOrgName.Width = 75;
			// 
			// ColumnRAccount
			// 
			this.ColumnRAccount.Format = "";
			this.ColumnRAccount.FormatInfo = null;
			this.ColumnRAccount.HeaderText = "Получатель-Счёт";
			this.ColumnRAccount.MappingName = "RAccount";
			this.ColumnRAccount.Width = 150;
			// 
			// ColumnCodeINN
			// 
			this.ColumnCodeINN.Format = "";
			this.ColumnCodeINN.FormatInfo = null;
			this.ColumnCodeINN.HeaderText = "Получатель ИНН";
			this.ColumnCodeINN.MappingName = "CodeINN";
			this.ColumnCodeINN.NullText = "-";
			this.ColumnCodeINN.Width = 75;
			// 
			// ColumnOrgNameContra
			// 
			this.ColumnOrgNameContra.Format = "";
			this.ColumnOrgNameContra.FormatInfo = null;
			this.ColumnOrgNameContra.HeaderText = "Плательщик";
			this.ColumnOrgNameContra.MappingName = "OrgNameContra";
			this.ColumnOrgNameContra.NullText = "-";
			this.ColumnOrgNameContra.Width = 75;
			// 
			// ColumnRAccountContra
			// 
			this.ColumnRAccountContra.Format = "";
			this.ColumnRAccountContra.FormatInfo = null;
			this.ColumnRAccountContra.HeaderText = "Плательщик-Счёт";
			this.ColumnRAccountContra.MappingName = "RAccountContra";
			this.ColumnRAccountContra.NullText = "-";
			this.ColumnRAccountContra.Width = 150;
			// 
			// ColumnCodeINNContra
			// 
			this.ColumnCodeINNContra.Format = "";
			this.ColumnCodeINNContra.FormatInfo = null;
			this.ColumnCodeINNContra.HeaderText = "Плательщик-ИНН";
			this.ColumnCodeINNContra.MappingName = "CodeINNContra";
			this.ColumnCodeINNContra.NullText = "-";
			this.ColumnCodeINNContra.Width = 75;
			// 
			// ColumnPaymentOrderPurpose
			// 
			this.ColumnPaymentOrderPurpose.Format = "";
			this.ColumnPaymentOrderPurpose.FormatInfo = null;
			this.ColumnPaymentOrderPurpose.HeaderText = "Основание";
			this.ColumnPaymentOrderPurpose.MappingName = "PaymentOrderPurpose";
			this.ColumnPaymentOrderPurpose.NullText = "-";
			this.ColumnPaymentOrderPurpose.Width = 75;
			// 
			// ColumnRemarks
			// 
			this.ColumnRemarks.Format = "";
			this.ColumnRemarks.FormatInfo = null;
			this.ColumnRemarks.HeaderText = "Примечание";
			this.ColumnRemarks.MappingName = "Remarks";
			this.ColumnRemarks.NullText = "-";
			this.ColumnRemarks.Width = 75;
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = ((string)(configurationAppSettings.GetValue("ConnectionString", typeof(string))));
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "PaymentsOrders", new System.Data.Common.DataColumnMapping[] {
																																																						new System.Data.Common.DataColumnMapping("HeaderID", "HeaderID"),
																																																						new System.Data.Common.DataColumnMapping("HeaderDate", "HeaderDate"),
																																																						new System.Data.Common.DataColumnMapping("PaymentOrderID", "PaymentOrderID"),
																																																						new System.Data.Common.DataColumnMapping("PaymentNo", "PaymentNo"),
																																																						new System.Data.Common.DataColumnMapping("PaymentOrderDate", "PaymentOrderDate"),
																																																						new System.Data.Common.DataColumnMapping("Confirmed", "Confirmed"),
																																																						new System.Data.Common.DataColumnMapping("RAccount", "RAccount"),
																																																						new System.Data.Common.DataColumnMapping("OrgName", "OrgName"),
																																																						new System.Data.Common.DataColumnMapping("CodeINN", "CodeINN"),
																																																						new System.Data.Common.DataColumnMapping("RAccountContra", "RAccountContra"),
																																																						new System.Data.Common.DataColumnMapping("OrgNameContra", "OrgNameContra"),
																																																						new System.Data.Common.DataColumnMapping("PaymentOrderSum", "PaymentOrderSum"),
																																																						new System.Data.Common.DataColumnMapping("PaymentOrderPurpose", "PaymentOrderPurpose"),
																																																						new System.Data.Common.DataColumnMapping("CodeINNContra", "CodeINNContra")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT AccountsStatementsHeaders.HeaderID, AccountsStatementsHeaders.HeaderDate, PaymentsOrders.PaymentOrderID, PaymentsOrders.PaymentNo, PaymentsOrders.PaymentOrderDate, AccountsStatementsHeaders.Confirmed, OrgsAccounts.RAccount, Orgs.OrgName, Orgs.CodeINN, OrgsAccounts_1.RAccount AS RAccountContra, Orgs_1.OrgName AS OrgNameContra, PaymentsOrders.PaymentOrderSum, PaymentsOrders.PaymentOrderPurpose, Orgs_1.CodeINN AS CodeINNContra, OrgsAccounts_1.OrgsAccountsID, Orgs_1.OrgID, OrgsAccounts.OrgsAccountsID AS OrgsAccountsIDContra, Orgs.OrgID AS OrgIDContra, PaymentsOrders.Remarks FROM PaymentsOrders INNER JOIN AccountsStatementsHeaders ON PaymentsOrders.HeaderID = AccountsStatementsHeaders.HeaderID INNER JOIN OrgsAccounts ON AccountsStatementsHeaders.OrgAccountID = OrgsAccounts.OrgsAccountsID INNER JOIN Accounts ON OrgsAccounts.AccountID = Accounts.AccountID INNER JOIN Orgs ON OrgsAccounts.OrgID = Orgs.OrgID INNER JOIN OrgsAccounts OrgsAccounts_1 ON PaymentsOrders.OrgAccountIDCorr = OrgsAccounts_1.OrgsAccountsID INNER JOIN Orgs Orgs_1 ON OrgsAccounts_1.OrgID = Orgs_1.OrgID LEFT OUTER JOIN Transactions ON PaymentsOrders.PaymentOrderID = Transactions.DocumentID WHERE (AccountsStatementsHeaders.Confirmed = 1) AND (PaymentsOrders.Direction = 1) AND (Transactions.TransactionTypeID = 1 OR Transactions.TransactionTypeID = 10) AND (Transactions.ClientRequestID IS NULL) AND (Transactions.TransactionCommited = 1) AND (Transactions.TransactionPosted = 0)";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// toolBar1
			// 
			this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.tbtnRefresh,
																						this.tbtnClentSetLink,
																						this.tbbHistory});
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.ImageList = this.imageList1;
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(944, 25);
			this.toolBar1.TabIndex = 3;
			this.toolBar1.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			// 
			// tbtnRefresh
			// 
			this.tbtnRefresh.ImageIndex = 0;
			this.tbtnRefresh.Text = "Обновить";
			// 
			// tbtnClentSetLink
			// 
			this.tbtnClentSetLink.ImageIndex = 1;
			this.tbtnClentSetLink.Text = "Свзать с Клиентом";
			// 
			// tbbHistory
			// 
			this.tbbHistory.ImageIndex = 2;
			this.tbbHistory.Text = "История";
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// panel1
			// 
			this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.label2,
																				 this.tbServiceCharge,
																				 this.label1,
																				 this.cmbClients});
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 25);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(944, 31);
			this.panel1.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(316, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "% Обслуживания:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbServiceCharge
			// 
			this.tbServiceCharge.AllowDrop = true;
			this.tbServiceCharge.dValue = 0;
			this.tbServiceCharge.IsPcnt = true;
			this.tbServiceCharge.Location = new System.Drawing.Point(418, 5);
			this.tbServiceCharge.MaxDecPos = 2;
			this.tbServiceCharge.MaxPos = 8;
			this.tbServiceCharge.Name = "tbServiceCharge";
			this.tbServiceCharge.nValue = ((long)(0));
			this.tbServiceCharge.Size = new System.Drawing.Size(50, 20);
			this.tbServiceCharge.TabIndex = 2;
			this.tbServiceCharge.Text = "0";
			this.tbServiceCharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbServiceCharge.TextMode = false;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(4, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(50, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Клиент:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cmbClients
			// 
			this.cmbClients.Location = new System.Drawing.Point(56, 5);
			this.cmbClients.Name = "cmbClients";
			this.cmbClients.Size = new System.Drawing.Size(248, 21);
			this.cmbClients.TabIndex = 0;
			// 
			// panel2
			// 
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 286);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(944, 4);
			this.panel2.TabIndex = 5;
			// 
			// panel3
			// 
			this.panel3.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.dataGrid1});
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(0, 56);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(944, 230);
			this.panel3.TabIndex = 6;
			// 
			// sqlCmdSetLinkByClient
			// 
			this.sqlCmdSetLinkByClient.CommandText = "[ClientsRequestLinkToTransactionAuto]";
			this.sqlCmdSetLinkByClient.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCmdSetLinkByClient.Connection = this.sqlConnection1;
			this.sqlCmdSetLinkByClient.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdSetLinkByClient.Parameters.Add(new System.Data.SqlClient.SqlParameter("@nPaymentOrderID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdSetLinkByClient.Parameters.Add(new System.Data.SqlClient.SqlParameter("@nClientID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdSetLinkByClient.Parameters.Add(new System.Data.SqlClient.SqlParameter("@dServiceChargeValue", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(15)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// PaymsOrdersUnknownList
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(944, 290);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.panel3,
																		  this.panel2,
																		  this.panel1,
																		  this.toolBar1});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PaymsOrdersUnknownList";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Неопознанные приходы";
			this.TopMost = true;
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvUnknownList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsPaymentsOrdersUnknownList1)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dvClients)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion


		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if (e.Button == this.tbtnRefresh)
			{
				this.RefreshList();
				return;
			}
			if (e.Button == this.tbtnClentSetLink) 
			{
				this.SetLinkByClient();
				return;
			}
			if(e.Button == this.tbbHistory)
			{
				BindingManagerBase bm = this.BindingContext[this.dvUnknownList];
				dsPaymentsOrdersUnknownList.PaymentsOrdersRow rw = (dsPaymentsOrdersUnknownList.PaymentsOrdersRow) ((DataRowView) bm.Current).Row;
				foreach( Form f in this.MdiParent.MdiChildren) 
				{
					if (f.GetType()==typeof(PaymentsOrdersLinkHistory))
					{
						f.Show();
						f.Activate();
						((PaymentsOrdersLinkHistory) f).SelectClient += new PaymentsOrdersLinkHistory.SelectClientEventHandler(select_Client);
						((PaymentsOrdersLinkHistory) f).UpdateList(rw.RAccountContra,rw.OrgNameContra,rw.CodeINNContra);
						return;
					}
				}
				PaymentsOrdersLinkHistory polh = new PaymentsOrdersLinkHistory();
				polh.MdiParent = this.MdiParent;
				polh.SelectClient += new PaymentsOrdersLinkHistory.SelectClientEventHandler(select_Client);
				polh.Show();
				polh.UpdateList(rw.RAccountContra,rw.OrgNameContra,rw.CodeINNContra);
			}
		}
		private void select_Client(int ClientID)
		{
			this.cmbClients.SelectedValue = ClientID;
		}
		private void RefreshList()
		{
			try 
			{
				this.dsPaymentsOrdersUnknownList1.PaymentsOrders.Clear();
				this.sqlDataAdapter1.Fill( this.dsPaymentsOrdersUnknownList1.PaymentsOrders);
 
				this.dataGrid1.CurrentRowIndex =0;
			}
			catch(Exception ex) 
			{
				MessageBox.Show("Ошибка чтения данных: " +ex.Message, "BP2", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void SetLinkByClient()
		{
			int nClientID			=0;
			int nPaymOrderID		=0;
			double dServiceCharge	=0;

			if (DialogResult.No ==MessageBox.Show("Произвести привязку к Клиенту, Вы уверены?", "BP2", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) 
				return;
			
			BindingManagerBase bmPaymOrder = (BindingManagerBase)this.BindingContext[this.dvUnknownList];
			if ( bmPaymOrder.Position <0) //If DataSet is Empty
			{
				MessageBox.Show("Связывание отменено: Не указан платёжный Документ.", "BP2", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			_Forms.dsPaymentsOrdersUnknownList.PaymentsOrdersRow rwPaymOrder =
				(_Forms.dsPaymentsOrdersUnknownList.PaymentsOrdersRow)((DataRowView)bmPaymOrder.Current).Row;
			
			nPaymOrderID =rwPaymOrder.PaymentOrderID;
			dServiceCharge =this.tbServiceCharge.dValue;
  
			if (dServiceCharge <0) 
			{
				MessageBox.Show("Связывание отменено: Процент обслуживания не может быть отрицательным.", "BP2", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			if (dServiceCharge <0.000001)
			if (DialogResult.No ==MessageBox.Show("Стоимость обслуживания равна 0. Продолжить?", "BP2", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) 
				return;
			
			if (this.cmbClients.SelectedIndex <0) 
			{
				MessageBox.Show("Связывание отменено: Не указан Клиент.", "BP2", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			nClientID =(int)this.cmbClients.SelectedValue;  
			
			try 
			{
				this.sqlCmdSetLinkByClient.Parameters["@nPaymentOrderID"].Value			=nPaymOrderID;
				this.sqlCmdSetLinkByClient.Parameters["@nClientID"].Value				=nClientID;
				this.sqlCmdSetLinkByClient.Parameters["@dServiceChargeValue"].Value		=dServiceCharge;
				App.ExecSql(this.sqlCmdSetLinkByClient);

				this.RefreshList();
			}
			catch(Exception ex) 
			{
				MessageBox.Show("Связывание отменено: При связывании возникла ошибка:" +ex.Message +".", "BP2", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
