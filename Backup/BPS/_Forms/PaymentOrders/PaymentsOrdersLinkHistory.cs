using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace BPS._Forms
{
	/// <summary>
	/// Summary description for PaymentsOrdersLinkHistory.
	/// </summary>
	public class PaymentsOrdersLinkHistory : System.Windows.Forms.Form
	{
		public delegate void SelectClientEventHandler(int ClientID);
		public event SelectClientEventHandler SelectClient;
		private System.Data.SqlClient.SqlConnection sqlConnection1;
		private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private BPS._Forms.dsPaymentsOrdersLinkHistory dsPaymentsOrdersLinkHistory1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnClientID;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnClientName;
		private System.Data.DataView dvPaymentsOrdersLinkHistory;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.Button btnSelect;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnChargeMin;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnChargeMax;
		private System.Windows.Forms.Button btnCancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public PaymentsOrdersLinkHistory()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			App.SetDataGridTableStyle(this.dataGridTableStyle1);
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
			System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(PaymentsOrdersLinkHistory));
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.dsPaymentsOrdersLinkHistory1 = new BPS._Forms.dsPaymentsOrdersLinkHistory();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.btnSelect = new System.Windows.Forms.Button();
			this.panel3 = new System.Windows.Forms.Panel();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.dvPaymentsOrdersLinkHistory = new System.Data.DataView();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.ColumnClientID = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnClientName = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnChargeMin = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnChargeMax = new System.Windows.Forms.DataGridTextBoxColumn();
			this.btnCancel = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dsPaymentsOrdersLinkHistory1)).BeginInit();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvPaymentsOrdersLinkHistory)).BeginInit();
			this.SuspendLayout();
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = ((string)(configurationAppSettings.GetValue("ConnectionString", typeof(string))));
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "Clients", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("ClientID", "ClientID"),
																																																				 new System.Data.Common.DataColumnMapping("ClientName", "ClientName"),
																																																				 new System.Data.Common.DataColumnMapping("TransactionTypeID", "TransactionTypeID"),
																																																				 new System.Data.Common.DataColumnMapping("RAccount", "RAccount"),
																																																				 new System.Data.Common.DataColumnMapping("OrgName", "OrgName"),
																																																				 new System.Data.Common.DataColumnMapping("CodeINN", "CodeINN")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT Clients.ClientID, Clients.ClientName, MIN(Transactions.ServiceCharge) AS MinCharge, MAX(Transactions.ServiceCharge) AS MaxCharge, AVG(Transactions.ServiceCharge) AS AvgCharge FROM Clients INNER JOIN Transactions ON Clients.ClientID = Transactions.ClientID INNER JOIN PaymentsOrders ON Transactions.DocumentID = PaymentsOrders.PaymentOrderID INNER JOIN OrgsAccounts ON PaymentsOrders.OrgAccountIDCorr = OrgsAccounts.OrgsAccountsID INNER JOIN Orgs ON OrgsAccounts.OrgID = Orgs.OrgID WHERE (OrgsAccounts.RAccount = @RAccountFrom) AND (Transactions.TransactionTypeID = 1) AND (Transactions.TransactionCommited = 1) AND (Transactions.TransactionPosted = 1) OR (Transactions.TransactionTypeID = 1) AND (Transactions.TransactionCommited = 1) AND (Transactions.TransactionPosted = 1) AND (Orgs.OrgName = @OrgNamefrom) OR (Transactions.TransactionTypeID = 1) AND (Transactions.TransactionCommited = 1) AND (Transactions.TransactionPosted = 1) AND (Orgs.CodeINN = @CodeINNFrom) GROUP BY Clients.ClientID, Clients.ClientName ORDER BY Clients.ClientName";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RAccountFrom", System.Data.SqlDbType.NVarChar, 50, "RAccount"));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrgNamefrom", System.Data.SqlDbType.NVarChar, 256, "OrgName"));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CodeINNFrom", System.Data.SqlDbType.NVarChar, 16, "CodeINN"));
			// 
			// dsPaymentsOrdersLinkHistory1
			// 
			this.dsPaymentsOrdersLinkHistory1.DataSetName = "dsPaymentsOrdersLinkHistory";
			this.dsPaymentsOrdersLinkHistory1.Locale = new System.Globalization.CultureInfo("ru-RU");
			this.dsPaymentsOrdersLinkHistory1.Namespace = "http://www.tempuri.org/dsPaymentsOrdersLinkHistory.xsd";
			// 
			// panel1
			// 
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(476, 8);
			this.panel1.TabIndex = 0;
			// 
			// panel2
			// 
			this.panel2.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.btnSelect,
																				 this.btnCancel});
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 158);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(476, 25);
			this.panel2.TabIndex = 1;
			// 
			// btnSelect
			// 
			this.btnSelect.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSelect.Location = new System.Drawing.Point(272, 2);
			this.btnSelect.Name = "btnSelect";
			this.btnSelect.Size = new System.Drawing.Size(100, 22);
			this.btnSelect.TabIndex = 0;
			this.btnSelect.Text = "Выбрать";
			this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
			// 
			// panel3
			// 
			this.panel3.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.dataGrid1});
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(0, 8);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(476, 150);
			this.panel3.TabIndex = 2;
			// 
			// dataGrid1
			// 
			this.dataGrid1.AllowSorting = false;
			this.dataGrid1.CaptionVisible = false;
			this.dataGrid1.ContextMenu = this.contextMenu1;
			this.dataGrid1.DataMember = "";
			this.dataGrid1.DataSource = this.dvPaymentsOrdersLinkHistory;
			this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGrid1.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.ReadOnly = true;
			this.dataGrid1.Size = new System.Drawing.Size(476, 150);
			this.dataGrid1.TabIndex = 0;
			this.dataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																								  this.dataGridTableStyle1});
			this.dataGrid1.DoubleClick += new System.EventHandler(this.dataGrid1_DoubleClick);
			// 
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.menuItem1});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.Text = "Выбрать";
			this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
			// 
			// dvPaymentsOrdersLinkHistory
			// 
			this.dvPaymentsOrdersLinkHistory.Table = this.dsPaymentsOrdersLinkHistory1.Clients;
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.DataGrid = this.dataGrid1;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.ColumnClientID,
																												  this.ColumnClientName,
																												  this.ColumnChargeMin,
																												  this.ColumnChargeMax});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "Clients";
			// 
			// ColumnClientID
			// 
			this.ColumnClientID.Format = "000000";
			this.ColumnClientID.FormatInfo = null;
			this.ColumnClientID.HeaderText = "ID Клиента";
			this.ColumnClientID.MappingName = "ClientID";
			this.ColumnClientID.ReadOnly = true;
			this.ColumnClientID.Width = 75;
			// 
			// ColumnClientName
			// 
			this.ColumnClientName.Format = "";
			this.ColumnClientName.FormatInfo = null;
			this.ColumnClientName.HeaderText = "Имя Клиента";
			this.ColumnClientName.MappingName = "ClientName";
			this.ColumnClientName.ReadOnly = true;
			this.ColumnClientName.Width = 250;
			// 
			// ColumnChargeMin
			// 
			this.ColumnChargeMin.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.ColumnChargeMin.Format = "0.00%";
			this.ColumnChargeMin.FormatInfo = null;
			this.ColumnChargeMin.HeaderText = "Мин.";
			this.ColumnChargeMin.MappingName = "MinCharge";
			this.ColumnChargeMin.NullText = "-";
			this.ColumnChargeMin.Width = 55;
			// 
			// ColumnChargeMax
			// 
			this.ColumnChargeMax.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.ColumnChargeMax.Format = "0.00%";
			this.ColumnChargeMax.FormatInfo = null;
			this.ColumnChargeMax.HeaderText = "Макс.";
			this.ColumnChargeMax.MappingName = "MaxCharge";
			this.ColumnChargeMax.NullText = "-";
			this.ColumnChargeMax.Width = 55;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(374, 2);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(100, 22);
			this.btnCancel.TabIndex = 0;
			this.btnCancel.Text = "Закрыть";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// PaymentsOrdersLinkHistory
			// 
			this.AcceptButton = this.btnSelect;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(476, 183);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.panel3,
																		  this.panel2,
																		  this.panel1});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PaymentsOrdersLinkHistory";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "История связывания";
			((System.ComponentModel.ISupportInitialize)(this.dsPaymentsOrdersLinkHistory1)).EndInit();
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvPaymentsOrdersLinkHistory)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public void UpdateList(string szRAccountFrom, string szOrgNameFrom, string szCodeINNFrom) 
		{
			this.sqlDataAdapter1.SelectCommand.Parameters["@OrgNamefrom"].Value = szOrgNameFrom;
			this.sqlDataAdapter1.SelectCommand.Parameters["@CodeINNFrom"].Value = szCodeINNFrom;
			this.sqlDataAdapter1.SelectCommand.Parameters["@RAccountFrom"].Value = szRAccountFrom;
			this.dsPaymentsOrdersLinkHistory1.Clients.Clear();
			try
			{
				this.sqlDataAdapter1.Fill(this.dsPaymentsOrdersLinkHistory1.Clients);
				this.dataGrid1.CurrentRowIndex =0; 
			}
			catch(Exception ex)
			{
				AM_Controls.MsgBoxX.Show(ex.Message);
			}
		}

		private void dataGrid1_DoubleClick(object sender, System.EventArgs e)
		{
			this.getClientID();
			this.Close();
		}

		private void menuItem1_Click(object sender, System.EventArgs e)
		{
			this.getClientID();
			this.Close();
		}
		private void getClientID()
		{
			if (this.dvPaymentsOrdersLinkHistory.Count == 0) return;
			
			BindingManagerBase bm = this.BindingContext[this.dvPaymentsOrdersLinkHistory];
			BPS._Forms.dsPaymentsOrdersLinkHistory.ClientsRow rw = (BPS._Forms.dsPaymentsOrdersLinkHistory.ClientsRow) ((DataRowView) bm.Current).Row;
			
			if (this.SelectClient !=null) this.SelectClient(rw.ClientID);
		}

		private void btnSelect_Click(object sender, System.EventArgs e)
		{
			this.getClientID();
			this.Close();
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

	}
}
