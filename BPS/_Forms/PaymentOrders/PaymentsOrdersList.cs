using System;
using System.IO;
using System.Xml;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using AM_Controls;


namespace BPS._Forms
{
	/// <summary>
	/// Summary description for PaymsList.
	/// </summary>
	public class PaymentsOrdersList : System.Windows.Forms.Form
	{
		private BPS.BLL.Orgs.UsersOrgsAndAccounts bll = new BPS.BLL.Orgs.UsersOrgsAndAccounts();

		private AM_Controls.ucPeriodSimple cPeriod;
		private AM_Controls.DataGridV dataGrid1;
		private System.Data.DataView dataView1;
		private System.Windows.Forms.ComboBox cmbOrgTo;
		private System.Windows.Forms.Label label2;
		private AM_Controls.TextBoxV textBoxV1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label4;
		private System.Data.DataView dvOrgFrom;
		private System.Data.DataView dvOrgTo;
		private System.ComponentModel.IContainer components;
		private System.Data.SqlClient.SqlDataAdapter daUseProc;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cmbDirect;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn PaymentOrderID;
		private System.Windows.Forms.DataGridTextBoxColumn PaymentNo;
		private System.Windows.Forms.DataGridTextBoxColumn OrgName;
		private System.Windows.Forms.DataGridTextBoxColumn RAccount;
		private System.Windows.Forms.DataGridTextBoxColumn HeaderDate;
		private System.Windows.Forms.DataGridTextBoxColumn PaymentOrderDate;
		private System.Windows.Forms.DataGridTextBoxColumn OrsNameCorr;
		private System.Windows.Forms.DataGridTextBoxColumn RAccountIDCorr;
		private System.Windows.Forms.DataGridTextBoxColumn PaymentOrderPurpose;
		private System.Windows.Forms.DataGridTextBoxColumn Remarks;
		private BPS.BLL.PaymentOrders.DataSets.dsPaymentOrderList dsPaymentOrderList1;
		private System.Windows.Forms.DataGridTextBoxColumn PaymentOrderStatusName;
		private System.Windows.Forms.DataGridTextBoxColumn ClientName;
		private System.Windows.Forms.DataGridTextBoxColumn colDebit;
		private System.Windows.Forms.DataGridTextBoxColumn colCredit;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem mnuEdit;
		private System.Windows.Forms.MenuItem mnuOpen;
		private System.Windows.Forms.MenuItem mnuDel;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private bool bIsLoaded = false;
		private System.Data.SqlClient.SqlCommand sqlSendPO;
		private System.Windows.Forms.CheckBox cbPrepared;
		private System.Windows.Forms.CheckBox cbSent;
		private System.Windows.Forms.CheckBox cbConfirmed;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem mnuRefresh;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem mnuApplyFilter;
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.ToolBarButton tbbNew;
		private System.Windows.Forms.ToolBarButton tbbEdit;
		private System.Windows.Forms.ToolBarButton tbbDel;
		private System.Windows.Forms.ToolBarButton toolBarButton10;
		private System.Windows.Forms.ToolBarButton tbbExec;
		private System.Windows.Forms.ToolBarButton tbbConfirm;
		private System.Windows.Forms.ToolBarButton toolBarButton4;
		private System.Windows.Forms.ToolBarButton tbbRefresh;
		private System.Windows.Forms.ToolBarButton toolBarButton7;
		private System.Windows.Forms.ToolBarButton tbbApply;
		private System.Windows.Forms.ToolBarButton tbbClear;
		private System.Windows.Forms.MenuItem mnuSend;
		private System.Windows.Forms.MenuItem mnuClearFilter;
		private System.Windows.Forms.MenuItem mnuConfirm;
		private System.Windows.Forms.ImageList imageList1;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		private System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
		private System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
		private System.Windows.Forms.MenuItem mnuUndoBank;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem mnuFilter;
		private System.Windows.Forms.MenuItem mnuPrint;
		private System.Windows.Forms.ToolBarButton tbbPrint;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.GroupBox grpAgents;
		private System.Windows.Forms.GroupBox grpStatus;
		private System.Windows.Forms.GroupBox grpPeriod;
		private System.Windows.Forms.GroupBox grpSum;
		private System.Windows.Forms.DateTimePicker dtpDateFrom;
		private System.Windows.Forms.DateTimePicker dtpDateTill;
		private System.Windows.Forms.CheckBox cbDateFrom;
		private System.Windows.Forms.CheckBox cbDateTill;
		private System.Windows.Forms.DataGridTextBoxColumn POOrgName;
		private System.Windows.Forms.DataGridTextBoxColumn POOrgNameCorr;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Data.SqlClient.SqlCommand sqlCmdGetAccountExportSchemaName;
		private System.Data.SqlClient.SqlCommand sqlCmdGetAccountExportPath;
		private BPS._Controls.OrgsAndAccounts ucOrgsAndAccounts;
		private System.Data.SqlClient.SqlCommand sqlCheckOrgAccountSaldo;
		private AM_Controls.MenuItemImageProvider MenuItemImageProvider1;
		private System.Windows.Forms.Label label10;
		private AM_Controls.TextBoxV tbShowDigitsNumber;
		private System.Data.SqlClient.SqlConnection sqlConnection1;
		
		BPS.BLL.PaymentOrders.DataSets.dsPaymentOrderList.PaymentsOrdersListRow rwCurrent;

		void OnCurrentChanged(object sender, EventArgs e)
		{
			BindingManagerBase bm = (BindingManagerBase)this.BindingContext[this.dataView1];
			rwCurrent = (BPS.BLL.PaymentOrders.DataSets.dsPaymentOrderList.PaymentsOrdersListRow)((DataRowView)bm.Current).Row;
		}

		public PaymentsOrdersList()
		{
			App.FillOrgsAccount();
			InitializeComponent();

			bll.Fill( App.UserLogonID );
			this.ucOrgsAndAccounts.Init(bll);
			
			this.BindingContext[this.dataView1].CurrentChanged += new EventHandler( OnCurrentChanged );
			this.daUseProc.SelectCommand.Connection = App.Connection;
			App.SetDataGridTableStyle(this.dataGridTableStyle1);
			this.sqlConnection1 = App.Connection;
			
/*			this.dvOrgFrom.Table = App.DsOrgs.Orgs.Copy();
			DataRow dr = this.dvOrgFrom.Table.NewRow();
			dr["OrgID"] = 0;
			dr["OrgName"] = " <Все>";
			dr["IsInner"] = true;
			dr["IsNormal"] = false;
			dr["DefaultServiceCharge"] = 0;
			dr["IsSpecial"] = false;
			dr["CodeINN"] = " ";
			this.dvOrgFrom.Table.Rows.Add(dr);
			this.dvOrgFrom.Sort = "OrgName";
*/			
			this.dvOrgTo.Table = App.DsOrgs.Orgs.Copy();
			DataRow dr1 = this.dvOrgTo.Table.NewRow();
			dr1["OrgID"] = 0;
			dr1["OrgName"] = "<Все>";
			dr1["IsInner"] = true;
			dr1["IsNormal"] = false;
			dr1["DefaultServiceCharge"] = 0;
			dr1["IsSpecial"] = false;
			dr1["CodeINN"] = " ";
			this.dvOrgTo.Table.Rows.Add(dr1);
			this.dvOrgTo.Sort = "OrgName";
			
/*
  			this.cmbInnerOrg.DataSource = this.dvOrgFrom;
			this.cmbInnerOrg.ValueMember = "OrgID";
			this.cmbInnerOrg.DisplayMember = "OrgName";			
*/			
			this.cmbOrgTo.DataSource = this.dvOrgTo;
			this.cmbOrgTo.DisplayMember = "OrgName";
			this.cmbOrgTo.ValueMember = "OrgID";
			
//			this.dvOrgFrom.RowFilter = "IsInner=true";
			
			this.fillDs();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(PaymentsOrdersList));
			System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
			this.cPeriod = new AM_Controls.ucPeriodSimple();
			this.grpAgents = new System.Windows.Forms.GroupBox();
			this.label10 = new System.Windows.Forms.Label();
			this.tbShowDigitsNumber = new AM_Controls.TextBoxV();
			this.label2 = new System.Windows.Forms.Label();
			this.cmbOrgTo = new System.Windows.Forms.ComboBox();
			this.ucOrgsAndAccounts = new BPS._Controls.OrgsAndAccounts();
			this.cbPrepared = new System.Windows.Forms.CheckBox();
			this.cmbDirect = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.textBoxV1 = new AM_Controls.TextBoxV();
			this.cbSent = new System.Windows.Forms.CheckBox();
			this.cbConfirmed = new System.Windows.Forms.CheckBox();
			this.dataGrid1 = new AM_Controls.DataGridV();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.mnuOpen = new System.Windows.Forms.MenuItem();
			this.mnuDel = new System.Windows.Forms.MenuItem();
			this.mnuSend = new System.Windows.Forms.MenuItem();
			this.mnuConfirm = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.mnuUndoBank = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.mnuRefresh = new System.Windows.Forms.MenuItem();
			this.mnuPrint = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.mnuApplyFilter = new System.Windows.Forms.MenuItem();
			this.mnuClearFilter = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.dataView1 = new System.Data.DataView();
			this.dsPaymentOrderList1 = new BPS.BLL.PaymentOrders.DataSets.dsPaymentOrderList();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.PaymentOrderID = new System.Windows.Forms.DataGridTextBoxColumn();
			this.PaymentOrderStatusName = new System.Windows.Forms.DataGridTextBoxColumn();
			this.HeaderDate = new System.Windows.Forms.DataGridTextBoxColumn();
			this.OrgName = new System.Windows.Forms.DataGridTextBoxColumn();
			this.POOrgName = new System.Windows.Forms.DataGridTextBoxColumn();
			this.RAccount = new System.Windows.Forms.DataGridTextBoxColumn();
			this.PaymentNo = new System.Windows.Forms.DataGridTextBoxColumn();
			this.PaymentOrderDate = new System.Windows.Forms.DataGridTextBoxColumn();
			this.colDebit = new System.Windows.Forms.DataGridTextBoxColumn();
			this.OrsNameCorr = new System.Windows.Forms.DataGridTextBoxColumn();
			this.POOrgNameCorr = new System.Windows.Forms.DataGridTextBoxColumn();
			this.PaymentOrderPurpose = new System.Windows.Forms.DataGridTextBoxColumn();
			this.RAccountIDCorr = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ClientName = new System.Windows.Forms.DataGridTextBoxColumn();
			this.Remarks = new System.Windows.Forms.DataGridTextBoxColumn();
			this.colCredit = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dvOrgFrom = new System.Data.DataView();
			this.dvOrgTo = new System.Data.DataView();
			this.daUseProc = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.mnuEdit = new System.Windows.Forms.MenuItem();
			this.mnuFilter = new System.Windows.Forms.MenuItem();
			this.sqlSendPO = new System.Data.SqlClient.SqlCommand();
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.tbbNew = new System.Windows.Forms.ToolBarButton();
			this.tbbEdit = new System.Windows.Forms.ToolBarButton();
			this.tbbDel = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton10 = new System.Windows.Forms.ToolBarButton();
			this.tbbExec = new System.Windows.Forms.ToolBarButton();
			this.tbbConfirm = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton4 = new System.Windows.Forms.ToolBarButton();
			this.tbbRefresh = new System.Windows.Forms.ToolBarButton();
			this.tbbPrint = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton7 = new System.Windows.Forms.ToolBarButton();
			this.tbbApply = new System.Windows.Forms.ToolBarButton();
			this.tbbClear = new System.Windows.Forms.ToolBarButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.panel1 = new System.Windows.Forms.Panel();
			this.grpSum = new System.Windows.Forms.GroupBox();
			this.grpPeriod = new System.Windows.Forms.GroupBox();
			this.cbDateFrom = new System.Windows.Forms.CheckBox();
			this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
			this.dtpDateTill = new System.Windows.Forms.DateTimePicker();
			this.cbDateTill = new System.Windows.Forms.CheckBox();
			this.grpStatus = new System.Windows.Forms.GroupBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.sqlCmdGetAccountExportPath = new System.Data.SqlClient.SqlCommand();
			this.sqlCmdGetAccountExportSchemaName = new System.Data.SqlClient.SqlCommand();
			this.sqlCheckOrgAccountSaldo = new System.Data.SqlClient.SqlCommand();
			this.MenuItemImageProvider1 = new AM_Controls.MenuItemImageProvider();
			this.grpAgents.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsPaymentOrderList1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvOrgFrom)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvOrgTo)).BeginInit();
			this.panel1.SuspendLayout();
			this.grpSum.SuspendLayout();
			this.grpPeriod.SuspendLayout();
			this.grpStatus.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// cPeriod
			// 
			this.cPeriod._cbDateFrom = true;
			this.cPeriod._cbDateFromUse = true;
			this.cPeriod._cbDateTill = true;
			this.cPeriod._cbDateTillUse = true;
			this.cPeriod._DateFrom = new System.DateTime(2004, 1, 24, 0, 0, 0, 0);
			this.cPeriod._DateTill = new System.DateTime(2004, 1, 24, 0, 0, 0, 0);
			this.cPeriod._PeriodType = AM_Controls.Span.Today;
			this.cPeriod.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cPeriod.Location = new System.Drawing.Point(948, 16);
			this.cPeriod.Modified = true;
			this.cPeriod.Name = "cPeriod";
			this.cPeriod.Size = new System.Drawing.Size(30, 40);
			this.cPeriod.TabIndex = 4;
			this.cPeriod.Visible = false;
			// 
			// grpAgents
			// 
			this.grpAgents.Controls.Add(this.label10);
			this.grpAgents.Controls.Add(this.tbShowDigitsNumber);
			this.grpAgents.Controls.Add(this.label2);
			this.grpAgents.Controls.Add(this.cmbOrgTo);
			this.grpAgents.Controls.Add(this.ucOrgsAndAccounts);
			this.grpAgents.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.grpAgents.Location = new System.Drawing.Point(0, 6);
			this.grpAgents.Name = "grpAgents";
			this.grpAgents.Size = new System.Drawing.Size(450, 72);
			this.grpAgents.TabIndex = 0;
			this.grpAgents.TabStop = false;
			this.grpAgents.Text = "Контрагенты";
			// 
			// label10
			// 
			this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label10.Location = new System.Drawing.Point(268, 45);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(135, 14);
			this.label10.TabIndex = 5;
			this.label10.Text = "Отображать цифр счета:";
			// 
			// tbShowDigitsNumber
			// 
			this.tbShowDigitsNumber.AllowDrop = true;
			this.tbShowDigitsNumber.dValue = 3;
			this.tbShowDigitsNumber.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbShowDigitsNumber.IsPcnt = false;
			this.tbShowDigitsNumber.Location = new System.Drawing.Point(408, 41);
			this.tbShowDigitsNumber.MaxDecPos = 0;
			this.tbShowDigitsNumber.MaxLength = 2;
			this.tbShowDigitsNumber.MaxPos = 2;
			this.tbShowDigitsNumber.Name = "tbShowDigitsNumber";
			this.tbShowDigitsNumber.Negative = System.Drawing.Color.Empty;
			this.tbShowDigitsNumber.nValue = ((long)(3));
			this.tbShowDigitsNumber.Positive = System.Drawing.Color.Empty;
			this.tbShowDigitsNumber.Size = new System.Drawing.Size(30, 21);
			this.tbShowDigitsNumber.TabIndex = 4;
			this.tbShowDigitsNumber.Text = "3";
			this.tbShowDigitsNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbShowDigitsNumber.TextMode = false;
			this.tbShowDigitsNumber.Zero = System.Drawing.Color.Empty;
			this.tbShowDigitsNumber.Validating += new System.ComponentModel.CancelEventHandler(this.tbShowDigitsNumber_Validating);
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(6, 42);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(70, 18);
			this.label2.TabIndex = 3;
			this.label2.Text = "Корр-т:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cmbOrgTo
			// 
			this.cmbOrgTo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cmbOrgTo.Location = new System.Drawing.Point(83, 41);
			this.cmbOrgTo.Name = "cmbOrgTo";
			this.cmbOrgTo.Size = new System.Drawing.Size(151, 21);
			this.cmbOrgTo.TabIndex = 1;
			// 
			// ucOrgsAndAccounts
			// 
			this.ucOrgsAndAccounts.Location = new System.Drawing.Point(6, 14);
			this.ucOrgsAndAccounts.Name = "ucOrgsAndAccounts";
			this.ucOrgsAndAccounts.OrgAccountID = 0;
			this.ucOrgsAndAccounts.OrgID = 0;
			this.ucOrgsAndAccounts.Size = new System.Drawing.Size(436, 26);
			this.ucOrgsAndAccounts.TabIndex = 0;
			// 
			// cbPrepared
			// 
			this.cbPrepared.Checked = true;
			this.cbPrepared.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbPrepared.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cbPrepared.Location = new System.Drawing.Point(14, 19);
			this.cbPrepared.Name = "cbPrepared";
			this.cbPrepared.Size = new System.Drawing.Size(111, 16);
			this.cbPrepared.TabIndex = 16;
			this.cbPrepared.Text = "Подготовленные";
			// 
			// cmbDirect
			// 
			this.cmbDirect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbDirect.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cmbDirect.Items.AddRange(new object[] {
														   "<Все>",
														   "Приход",
														   "Расход"});
			this.cmbDirect.Location = new System.Drawing.Point(88, 42);
			this.cmbDirect.Name = "cmbDirect";
			this.cmbDirect.Size = new System.Drawing.Size(126, 21);
			this.cmbDirect.TabIndex = 3;
			this.cmbDirect.Visible = false;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(8, 45);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(78, 18);
			this.label3.TabIndex = 12;
			this.label3.Text = "Направление:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label3.Visible = false;
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.Location = new System.Drawing.Point(8, 21);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 18);
			this.label4.TabIndex = 9;
			this.label4.Text = "Знак/Сумма:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboBox1
			// 
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.comboBox1.Items.AddRange(new object[] {
														   "",
														   ">",
														   "<",
														   "="});
			this.comboBox1.Location = new System.Drawing.Point(88, 19);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(48, 21);
			this.comboBox1.TabIndex = 7;
			// 
			// textBoxV1
			// 
			this.textBoxV1.AllowDrop = true;
			this.textBoxV1.dValue = 0;
			this.textBoxV1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.textBoxV1.IsPcnt = false;
			this.textBoxV1.Location = new System.Drawing.Point(136, 19);
			this.textBoxV1.MaxDecPos = 2;
			this.textBoxV1.MaxPos = 10;
			this.textBoxV1.Name = "textBoxV1";
			this.textBoxV1.Negative = System.Drawing.Color.Empty;
			this.textBoxV1.nValue = ((long)(0));
			this.textBoxV1.Positive = System.Drawing.Color.Empty;
			this.textBoxV1.Size = new System.Drawing.Size(78, 21);
			this.textBoxV1.TabIndex = 8;
			this.textBoxV1.Text = "";
			this.textBoxV1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.textBoxV1.TextMode = false;
			this.textBoxV1.Zero = System.Drawing.Color.Empty;
			// 
			// cbSent
			// 
			this.cbSent.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cbSent.Location = new System.Drawing.Point(14, 35);
			this.cbSent.Name = "cbSent";
			this.cbSent.Size = new System.Drawing.Size(111, 16);
			this.cbSent.TabIndex = 16;
			this.cbSent.Text = "Отправленные";
			// 
			// cbConfirmed
			// 
			this.cbConfirmed.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cbConfirmed.Location = new System.Drawing.Point(14, 51);
			this.cbConfirmed.Name = "cbConfirmed";
			this.cbConfirmed.Size = new System.Drawing.Size(111, 16);
			this.cbConfirmed.TabIndex = 16;
			this.cbConfirmed.Text = "Проведенные";
			this.cbConfirmed.CheckedChanged += new System.EventHandler(this.cbConfirmed_CheckedChanged);
			// 
			// dataGrid1
			// 
			this.dataGrid1._CanEdit = false;
			this.dataGrid1._InvisibleColumn = 0;
			this.dataGrid1.CaptionVisible = false;
			this.dataGrid1.ContextMenu = this.contextMenu1;
			this.dataGrid1.DataMember = "";
			this.dataGrid1.DataSource = this.dataView1;
			this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(0, 0);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.ReadOnly = true;
			this.dataGrid1.Size = new System.Drawing.Size(992, 384);
			this.dataGrid1.TabIndex = 1;
			this.dataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																								  this.dataGridTableStyle1});
			this.dataGrid1.DoubleClick += new System.EventHandler(this.dataGrid1_DoubleClick);
			// 
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.mnuOpen,
																						 this.mnuDel,
																						 this.mnuSend,
																						 this.mnuConfirm,
																						 this.menuItem4,
																						 this.mnuUndoBank,
																						 this.menuItem1,
																						 this.mnuRefresh,
																						 this.mnuPrint,
																						 this.menuItem2,
																						 this.mnuApplyFilter,
																						 this.mnuClearFilter,
																						 this.menuItem5,
																						 this.menuItem3,
																						 this.menuItem6});
			// 
			// mnuOpen
			// 
			this.mnuOpen.DefaultItem = true;
			this.mnuOpen.Index = 0;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuOpen, ((System.Drawing.Icon)(resources.GetObject("mnuOpen.MenuItemImage"))));
			this.mnuOpen.OwnerDraw = true;
			this.mnuOpen.Shortcut = System.Windows.Forms.Shortcut.F10;
			this.mnuOpen.Text = "Открыть";
			this.mnuOpen.Click += new System.EventHandler(this.mnuOpen_Click);
			// 
			// mnuDel
			// 
			this.mnuDel.Index = 1;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuDel, ((System.Drawing.Icon)(resources.GetObject("mnuDel.MenuItemImage"))));
			this.mnuDel.OwnerDraw = true;
			this.mnuDel.Shortcut = System.Windows.Forms.Shortcut.CtrlDel;
			this.mnuDel.Text = "Удалить";
			this.mnuDel.Click += new System.EventHandler(this.mnuDel_Click);
			// 
			// mnuSend
			// 
			this.mnuSend.Index = 2;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuSend, ((System.Drawing.Icon)(resources.GetObject("mnuSend.MenuItemImage"))));
			this.mnuSend.OwnerDraw = true;
			this.mnuSend.Shortcut = System.Windows.Forms.Shortcut.F8;
			this.mnuSend.Text = "Отправить";
			this.mnuSend.Click += new System.EventHandler(this.mnuSend_Click);
			// 
			// mnuConfirm
			// 
			this.mnuConfirm.Index = 3;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuConfirm, ((System.Drawing.Icon)(resources.GetObject("mnuConfirm.MenuItemImage"))));
			this.mnuConfirm.OwnerDraw = true;
			this.mnuConfirm.Shortcut = System.Windows.Forms.Shortcut.F9;
			this.mnuConfirm.Text = "Подтвердить";
			this.mnuConfirm.Click += new System.EventHandler(this.mnuConfirm_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 4;
			this.MenuItemImageProvider1.SetMenuItemImage(this.menuItem4, null);
			this.menuItem4.OwnerDraw = true;
			this.menuItem4.Text = "-";
			// 
			// mnuUndoBank
			// 
			this.mnuUndoBank.Index = 5;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuUndoBank, ((System.Drawing.Icon)(resources.GetObject("mnuUndoBank.MenuItemImage"))));
			this.mnuUndoBank.OwnerDraw = true;
			this.mnuUndoBank.Shortcut = System.Windows.Forms.Shortcut.CtrlF8;
			this.mnuUndoBank.Text = "Отменить отправку";
			this.mnuUndoBank.Click += new System.EventHandler(this.mnuUndoBank_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 6;
			this.MenuItemImageProvider1.SetMenuItemImage(this.menuItem1, null);
			this.menuItem1.OwnerDraw = true;
			this.menuItem1.Text = "-";
			// 
			// mnuRefresh
			// 
			this.mnuRefresh.Index = 7;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuRefresh, null);
			this.mnuRefresh.OwnerDraw = true;
			this.mnuRefresh.Shortcut = System.Windows.Forms.Shortcut.F5;
			this.mnuRefresh.Text = "Обновить";
			this.mnuRefresh.Visible = false;
			this.mnuRefresh.Click += new System.EventHandler(this.mnuRefresh_Click);
			// 
			// mnuPrint
			// 
			this.mnuPrint.Index = 8;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuPrint, ((System.Drawing.Icon)(resources.GetObject("mnuPrint.MenuItemImage"))));
			this.mnuPrint.OwnerDraw = true;
			this.mnuPrint.Text = "Печатать п.п";
			this.mnuPrint.Click += new System.EventHandler(this.mnuPrint_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 9;
			this.MenuItemImageProvider1.SetMenuItemImage(this.menuItem2, null);
			this.menuItem2.OwnerDraw = true;
			this.menuItem2.Text = "-";
			// 
			// mnuApplyFilter
			// 
			this.mnuApplyFilter.Index = 10;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuApplyFilter, ((System.Drawing.Icon)(resources.GetObject("mnuApplyFilter.MenuItemImage"))));
			this.mnuApplyFilter.OwnerDraw = true;
			this.mnuApplyFilter.Shortcut = System.Windows.Forms.Shortcut.F12;
			this.mnuApplyFilter.Text = "Выбрать по фильтру";
			this.mnuApplyFilter.Click += new System.EventHandler(this.mnuApplyFilter_Click);
			// 
			// mnuClearFilter
			// 
			this.mnuClearFilter.Index = 11;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuClearFilter, ((System.Drawing.Icon)(resources.GetObject("mnuClearFilter.MenuItemImage"))));
			this.mnuClearFilter.OwnerDraw = true;
			this.mnuClearFilter.Shortcut = System.Windows.Forms.Shortcut.ShiftF12;
			this.mnuClearFilter.Text = "Очистить фильтр";
			this.mnuClearFilter.Click += new System.EventHandler(this.mnuClearFilter_Click);
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 12;
			this.MenuItemImageProvider1.SetMenuItemImage(this.menuItem5, null);
			this.menuItem5.OwnerDraw = true;
			this.menuItem5.Text = "-";
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 13;
			this.MenuItemImageProvider1.SetMenuItemImage(this.menuItem3, null);
			this.menuItem3.OwnerDraw = true;
			this.menuItem3.Text = "Импорт";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 14;
			this.MenuItemImageProvider1.SetMenuItemImage(this.menuItem6, null);
			this.menuItem6.OwnerDraw = true;
			this.menuItem6.Text = "Экспорт";
			// 
			// dataView1
			// 
			this.dataView1.ApplyDefaultSort = true;
			this.dataView1.Sort = "PaymentOrderID";
			this.dataView1.Table = this.dsPaymentOrderList1.PaymentsOrdersList;
			// 
			// dsPaymentOrderList1
			// 
			this.dsPaymentOrderList1.DataSetName = "dsPaymentOrderList";
			this.dsPaymentOrderList1.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.DataGrid = this.dataGrid1;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.PaymentOrderID,
																												  this.PaymentOrderStatusName,
																												  this.HeaderDate,
																												  this.OrgName,
																												  this.POOrgName,
																												  this.RAccount,
																												  this.PaymentNo,
																												  this.PaymentOrderDate,
																												  this.colDebit,
																												  this.OrsNameCorr,
																												  this.POOrgNameCorr,
																												  this.PaymentOrderPurpose,
																												  this.RAccountIDCorr,
																												  this.ClientName,
																												  this.Remarks,
																												  this.colCredit});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "PaymentsOrdersList";
			// 
			// PaymentOrderID
			// 
			this.PaymentOrderID.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.PaymentOrderID.Format = "";
			this.PaymentOrderID.FormatInfo = null;
			this.PaymentOrderID.HeaderText = "ID";
			this.PaymentOrderID.MappingName = "PaymentOrderID";
			this.PaymentOrderID.NullText = "-";
			this.PaymentOrderID.Width = 30;
			// 
			// PaymentOrderStatusName
			// 
			this.PaymentOrderStatusName.Format = "";
			this.PaymentOrderStatusName.FormatInfo = null;
			this.PaymentOrderStatusName.HeaderText = "Статус";
			this.PaymentOrderStatusName.MappingName = "PaymentOrderStatusName";
			this.PaymentOrderStatusName.NullText = "-";
			this.PaymentOrderStatusName.Width = 60;
			// 
			// HeaderDate
			// 
			this.HeaderDate.Format = "dd/MM/yy";
			this.HeaderDate.FormatInfo = null;
			this.HeaderDate.HeaderText = "Выписка";
			this.HeaderDate.MappingName = "HeaderDate";
			this.HeaderDate.NullText = "-";
			this.HeaderDate.Width = 50;
			// 
			// OrgName
			// 
			this.OrgName.Format = "";
			this.OrgName.FormatInfo = null;
			this.OrgName.HeaderText = "Организация";
			this.OrgName.MappingName = "OrgName";
			this.OrgName.NullText = "-";
			this.OrgName.Width = 0;
			// 
			// POOrgName
			// 
			this.POOrgName.Format = "";
			this.POOrgName.FormatInfo = null;
			this.POOrgName.HeaderText = "Организация п/п";
			this.POOrgName.MappingName = "POOrgName";
			this.POOrgName.Width = 75;
			// 
			// RAccount
			// 
			this.RAccount.Format = "0,5";
			this.RAccount.FormatInfo = null;
			this.RAccount.HeaderText = "Р/счёт";
			this.RAccount.MappingName = "RAccountCutted";
			this.RAccount.NullText = "-";
			this.RAccount.Width = 130;
			// 
			// PaymentNo
			// 
			this.PaymentNo.Format = "";
			this.PaymentNo.FormatInfo = null;
			this.PaymentNo.HeaderText = "Номер";
			this.PaymentNo.MappingName = "PaymentNo";
			this.PaymentNo.NullText = "-";
			this.PaymentNo.Width = 50;
			// 
			// PaymentOrderDate
			// 
			this.PaymentOrderDate.Format = "dd/MM/yy";
			this.PaymentOrderDate.FormatInfo = null;
			this.PaymentOrderDate.HeaderText = "Дата";
			this.PaymentOrderDate.MappingName = "PaymentOrderDate";
			this.PaymentOrderDate.NullText = "-";
			this.PaymentOrderDate.Width = 50;
			// 
			// colDebit
			// 
			this.colDebit.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.colDebit.Format = "0.00";
			this.colDebit.FormatInfo = null;
			this.colDebit.HeaderText = "Сумма";
			this.colDebit.MappingName = "PaymentOrderSum";
			this.colDebit.NullText = "-";
			this.colDebit.Width = 75;
			// 
			// OrsNameCorr
			// 
			this.OrsNameCorr.Format = "";
			this.OrsNameCorr.FormatInfo = null;
			this.OrsNameCorr.HeaderText = "Корреспондент";
			this.OrsNameCorr.MappingName = "OrgNameCorr";
			this.OrsNameCorr.NullText = "-";
			this.OrsNameCorr.Width = 0;
			// 
			// POOrgNameCorr
			// 
			this.POOrgNameCorr.Format = "";
			this.POOrgNameCorr.FormatInfo = null;
			this.POOrgNameCorr.HeaderText = "Корреспондент п/п";
			this.POOrgNameCorr.MappingName = "POOrgNameCorr";
			this.POOrgNameCorr.Width = 75;
			// 
			// PaymentOrderPurpose
			// 
			this.PaymentOrderPurpose.Format = "";
			this.PaymentOrderPurpose.FormatInfo = null;
			this.PaymentOrderPurpose.HeaderText = "Основание";
			this.PaymentOrderPurpose.MappingName = "PaymentOrderPurpose";
			this.PaymentOrderPurpose.NullText = "-";
			this.PaymentOrderPurpose.Width = 150;
			// 
			// RAccountIDCorr
			// 
			this.RAccountIDCorr.Format = "";
			this.RAccountIDCorr.FormatInfo = null;
			this.RAccountIDCorr.HeaderText = "Р/счёт";
			this.RAccountIDCorr.MappingName = "RAccountCorr";
			this.RAccountIDCorr.NullText = "-";
			this.RAccountIDCorr.Width = 130;
			// 
			// ClientName
			// 
			this.ClientName.Format = "";
			this.ClientName.FormatInfo = null;
			this.ClientName.HeaderText = "Клиент";
			this.ClientName.MappingName = "ClientName";
			this.ClientName.NullText = "-";
			this.ClientName.Width = 75;
			// 
			// Remarks
			// 
			this.Remarks.Format = "";
			this.Remarks.FormatInfo = null;
			this.Remarks.HeaderText = "Примечание";
			this.Remarks.MappingName = "Remarks";
			this.Remarks.NullText = "-";
			this.Remarks.Width = 150;
			// 
			// colCredit
			// 
			this.colCredit.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.colCredit.Format = "0.00";
			this.colCredit.FormatInfo = null;
			this.colCredit.HeaderText = "Кредит";
			this.colCredit.MappingName = "Credit";
			this.colCredit.NullText = "-";
			this.colCredit.Width = 75;
			// 
			// daUseProc
			// 
			this.daUseProc.DeleteCommand = this.sqlDeleteCommand1;
			this.daUseProc.SelectCommand = this.sqlSelectCommand2;
			this.daUseProc.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																								new System.Data.Common.DataTableMapping("Table", "PaymentsOrdersList", new System.Data.Common.DataColumnMapping[] {
																																																					  new System.Data.Common.DataColumnMapping("PaymentOrderID", "PaymentOrderID"),
																																																					  new System.Data.Common.DataColumnMapping("PaymentOrderDate", "PaymentOrderDate"),
																																																					  new System.Data.Common.DataColumnMapping("PaymentNo", "PaymentNo"),
																																																					  new System.Data.Common.DataColumnMapping("OrgAccountID", "OrgAccountID"),
																																																					  new System.Data.Common.DataColumnMapping("OrgAccountIDCorr", "OrgAccountIDCorr"),
																																																					  new System.Data.Common.DataColumnMapping("Direction", "Direction"),
																																																					  new System.Data.Common.DataColumnMapping("PaymentOrderSum", "PaymentOrderSum"),
																																																					  new System.Data.Common.DataColumnMapping("PaymentOrderPurpose", "PaymentOrderPurpose"),
																																																					  new System.Data.Common.DataColumnMapping("Remarks", "Remarks"),
																																																					  new System.Data.Common.DataColumnMapping("PaymentOrderStatusID", "PaymentOrderStatusID"),
																																																					  new System.Data.Common.DataColumnMapping("IsPrinted", "IsPrinted"),
																																																					  new System.Data.Common.DataColumnMapping("HeaderDate", "HeaderDate"),
																																																					  new System.Data.Common.DataColumnMapping("OrgID", "OrgID"),
																																																					  new System.Data.Common.DataColumnMapping("RAccount", "RAccount"),
																																																					  new System.Data.Common.DataColumnMapping("AccountID", "AccountID"),
																																																					  new System.Data.Common.DataColumnMapping("CurrencyID", "CurrencyID"),
																																																					  new System.Data.Common.DataColumnMapping("OrgName", "OrgName"),
																																																					  new System.Data.Common.DataColumnMapping("IsInner", "IsInner"),
																																																					  new System.Data.Common.DataColumnMapping("IsSpecial", "IsSpecial"),
																																																					  new System.Data.Common.DataColumnMapping("IsNormal", "IsNormal"),
																																																					  new System.Data.Common.DataColumnMapping("RAccountCorr", "RAccountCorr"),
																																																					  new System.Data.Common.DataColumnMapping("OrgIDCorr", "OrgIDCorr"),
																																																					  new System.Data.Common.DataColumnMapping("OrgNameCorr", "OrgNameCorr"),
																																																					  new System.Data.Common.DataColumnMapping("IsNormalCorr", "IsNormalCorr"),
																																																					  new System.Data.Common.DataColumnMapping("IsInnerCorr", "IsInnerCorr"),
																																																					  new System.Data.Common.DataColumnMapping("IsSpecialCorr", "IsSpecialCorr"),
																																																					  new System.Data.Common.DataColumnMapping("CurrencyIDCorr", "CurrencyIDCorr"),
																																																					  new System.Data.Common.DataColumnMapping("AccountIDCorr", "AccountIDCorr"),
																																																					  new System.Data.Common.DataColumnMapping("HeaderID", "HeaderID"),
																																																					  new System.Data.Common.DataColumnMapping("PaymentOrderStatusName", "PaymentOrderStatusName"),
																																																					  new System.Data.Common.DataColumnMapping("ClientName", "ClientName"),
																																																					  new System.Data.Common.DataColumnMapping("IsInnerClient", "IsInnerClient"),
																																																					  new System.Data.Common.DataColumnMapping("AccountStatementID", "AccountStatementID"),
																																																					  new System.Data.Common.DataColumnMapping("BankName", "BankName"),
																																																					  new System.Data.Common.DataColumnMapping("CodeBIK", "CodeBIK"),
																																																					  new System.Data.Common.DataColumnMapping("KAccount", "KAccount"),
																																																					  new System.Data.Common.DataColumnMapping("CityName", "CityName"),
																																																					  new System.Data.Common.DataColumnMapping("BankNameCorr", "BankNameCorr"),
																																																					  new System.Data.Common.DataColumnMapping("CodeBIKCorr", "CodeBIKCorr"),
																																																					  new System.Data.Common.DataColumnMapping("KAccountCorr", "KAccountCorr"),
																																																					  new System.Data.Common.DataColumnMapping("CityNameCorr", "CityNameCorr"),
																																																					  new System.Data.Common.DataColumnMapping("OrgName2", "OrgName2"),
																																																					  new System.Data.Common.DataColumnMapping("OrgName2Corr", "OrgName2Corr"),
																																																					  new System.Data.Common.DataColumnMapping("CodeINN", "CodeINN"),
																																																					  new System.Data.Common.DataColumnMapping("CodeKPP", "CodeKPP"),
																																																					  new System.Data.Common.DataColumnMapping("CodeINNCorr", "CodeINNCorr"),
																																																					  new System.Data.Common.DataColumnMapping("CodeKPPCorr", "CodeKPPCorr"),
																																																					  new System.Data.Common.DataColumnMapping("RAccountCutted", "RAccountCutted")})});
			this.daUseProc.UpdateCommand = this.sqlUpdateCommand1;
			// 
			// sqlDeleteCommand1
			// 
			this.sqlDeleteCommand1.CommandText = "[PaymentOrdersDelete]";
			this.sqlDeleteCommand1.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlDeleteCommand1.Connection = this.sqlConnection1;
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_PaymentOrderID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "PaymentOrderID", System.Data.DataRowVersion.Current, null));
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = ((string)(configurationAppSettings.GetValue("ConnectionString", typeof(string))));
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "[PaymentsOrdersSelectEx]";
			this.sqlSelectCommand2.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			this.sqlSelectCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UserID", System.Data.SqlDbType.Int, 4));
			this.sqlSelectCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DateFrom", System.Data.SqlDbType.DateTime, 8));
			this.sqlSelectCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DateTill", System.Data.SqlDbType.DateTime, 8));
			this.sqlSelectCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UseDateFrom", System.Data.SqlDbType.Bit, 1));
			this.sqlSelectCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UseDateTill", System.Data.SqlDbType.Bit, 1));
			this.sqlSelectCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrgID", System.Data.SqlDbType.Int, 4));
			this.sqlSelectCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrgAccountID", System.Data.SqlDbType.Int, 4));
			this.sqlSelectCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrgNameContra", System.Data.SqlDbType.NVarChar, 256));
			this.sqlSelectCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsPrepared", System.Data.SqlDbType.Bit, 1));
			this.sqlSelectCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsConfirmed", System.Data.SqlDbType.Bit, 1));
			this.sqlSelectCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsSent", System.Data.SqlDbType.Bit, 1));
			this.sqlSelectCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrderSumLow", System.Data.SqlDbType.Float, 8));
			this.sqlSelectCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrderSumHigh", System.Data.SqlDbType.Float, 8));
			this.sqlSelectCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UseSumLow", System.Data.SqlDbType.Bit, 1));
			this.sqlSelectCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UseSumHigh", System.Data.SqlDbType.Bit, 1));
			this.sqlSelectCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RAccountLength", System.Data.SqlDbType.Int, 4));
			// 
			// sqlUpdateCommand1
			// 
			this.sqlUpdateCommand1.CommandText = "[PaymentOrdersUpdate]";
			this.sqlUpdateCommand1.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlUpdateCommand1.Connection = this.sqlConnection1;
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PaymentOrderStatusID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "PaymentOrderStatusID", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PaymentOrderDate", System.Data.SqlDbType.DateTime, 8, "PaymentOrderDate"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PaymentNo", System.Data.SqlDbType.NVarChar, 16, "PaymentNo"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PaymentOrderPurpose", System.Data.SqlDbType.NVarChar, 256, "PaymentOrderPurpose"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Remarks", System.Data.SqlDbType.NVarChar, 256, "Remarks"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PaymentOrderID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "PaymentOrderID", System.Data.DataRowVersion.Current, null));
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.mnuEdit,
																					  this.mnuFilter});
			// 
			// mnuEdit
			// 
			this.mnuEdit.Index = 0;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuEdit, null);
			this.mnuEdit.MergeOrder = 1;
			this.mnuEdit.OwnerDraw = true;
			this.mnuEdit.Text = "Редактирование";
			// 
			// mnuFilter
			// 
			this.mnuFilter.Index = 1;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuFilter, null);
			this.mnuFilter.MergeOrder = 2;
			this.mnuFilter.OwnerDraw = true;
			this.mnuFilter.Text = "Фильтр";
			// 
			// sqlSendPO
			// 
			this.sqlSendPO.CommandText = "[xPaymOrderToBank]";
			this.sqlSendPO.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSendPO.Connection = this.sqlConnection1;
			this.sqlSendPO.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSendPO.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PaymentOrderID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// toolBar1
			// 
			this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.tbbNew,
																						this.tbbEdit,
																						this.tbbDel,
																						this.toolBarButton10,
																						this.tbbExec,
																						this.tbbConfirm,
																						this.toolBarButton4,
																						this.tbbRefresh,
																						this.tbbPrint,
																						this.toolBarButton7,
																						this.tbbApply,
																						this.tbbClear});
			this.toolBar1.ButtonSize = new System.Drawing.Size(85, 22);
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.ImageList = this.imageList1;
			this.toolBar1.Location = new System.Drawing.Point(0, 0);
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(992, 28);
			this.toolBar1.TabIndex = 18;
			this.toolBar1.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			// 
			// tbbNew
			// 
			this.tbbNew.Enabled = false;
			this.tbbNew.ImageIndex = 0;
			this.tbbNew.Text = "Новое";
			// 
			// tbbEdit
			// 
			this.tbbEdit.ImageIndex = 1;
			this.tbbEdit.Text = "Открыть";
			// 
			// tbbDel
			// 
			this.tbbDel.ImageIndex = 3;
			this.tbbDel.Text = "Удалить";
			// 
			// toolBarButton10
			// 
			this.toolBarButton10.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbbExec
			// 
			this.tbbExec.ImageIndex = 8;
			this.tbbExec.Text = "Отправить";
			// 
			// tbbConfirm
			// 
			this.tbbConfirm.ImageIndex = 4;
			this.tbbConfirm.Text = "Подтв.";
			// 
			// toolBarButton4
			// 
			this.toolBarButton4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbbRefresh
			// 
			this.tbbRefresh.ImageIndex = 2;
			this.tbbRefresh.Text = "Обновить";
			this.tbbRefresh.Visible = false;
			// 
			// tbbPrint
			// 
			this.tbbPrint.ImageIndex = 10;
			this.tbbPrint.Text = "Печать";
			// 
			// toolBarButton7
			// 
			this.toolBarButton7.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbbApply
			// 
			this.tbbApply.ImageIndex = 6;
			this.tbbApply.Text = "Выбрать";
			// 
			// tbbClear
			// 
			this.tbbClear.ImageIndex = 5;
			this.tbbClear.Text = "Очистить";
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.grpSum);
			this.panel1.Controls.Add(this.grpPeriod);
			this.panel1.Controls.Add(this.grpStatus);
			this.panel1.Controls.Add(this.grpAgents);
			this.panel1.Controls.Add(this.cPeriod);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.panel1.Location = new System.Drawing.Point(0, 28);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(992, 77);
			this.panel1.TabIndex = 19;
			// 
			// grpSum
			// 
			this.grpSum.Controls.Add(this.label3);
			this.grpSum.Controls.Add(this.label4);
			this.grpSum.Controls.Add(this.cmbDirect);
			this.grpSum.Controls.Add(this.comboBox1);
			this.grpSum.Controls.Add(this.textBoxV1);
			this.grpSum.Location = new System.Drawing.Point(718, 6);
			this.grpSum.Name = "grpSum";
			this.grpSum.Size = new System.Drawing.Size(222, 72);
			this.grpSum.TabIndex = 19;
			this.grpSum.TabStop = false;
			this.grpSum.Text = "Сумма Платёжного Поручения";
			// 
			// grpPeriod
			// 
			this.grpPeriod.Controls.Add(this.cbDateFrom);
			this.grpPeriod.Controls.Add(this.dtpDateFrom);
			this.grpPeriod.Controls.Add(this.dtpDateTill);
			this.grpPeriod.Controls.Add(this.cbDateTill);
			this.grpPeriod.Enabled = false;
			this.grpPeriod.Location = new System.Drawing.Point(580, 6);
			this.grpPeriod.Name = "grpPeriod";
			this.grpPeriod.Size = new System.Drawing.Size(141, 72);
			this.grpPeriod.TabIndex = 18;
			this.grpPeriod.TabStop = false;
			this.grpPeriod.Text = "Проведенные";
			// 
			// cbDateFrom
			// 
			this.cbDateFrom.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.cbDateFrom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cbDateFrom.Location = new System.Drawing.Point(8, 20);
			this.cbDateFrom.Name = "cbDateFrom";
			this.cbDateFrom.Size = new System.Drawing.Size(42, 21);
			this.cbDateFrom.TabIndex = 1;
			this.cbDateFrom.Text = "С:";
			this.cbDateFrom.CheckedChanged += new System.EventHandler(this.cbDateFrom_CheckedChanged);
			// 
			// dtpDateFrom
			// 
			this.dtpDateFrom.CustomFormat = "dd-MMM-yy";
			this.dtpDateFrom.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
			this.dtpDateFrom.Enabled = false;
			this.dtpDateFrom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpDateFrom.Location = new System.Drawing.Point(54, 20);
			this.dtpDateFrom.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
			this.dtpDateFrom.Name = "dtpDateFrom";
			this.dtpDateFrom.Size = new System.Drawing.Size(79, 21);
			this.dtpDateFrom.TabIndex = 0;
			// 
			// dtpDateTill
			// 
			this.dtpDateTill.CustomFormat = "dd-MMM-yy";
			this.dtpDateTill.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
			this.dtpDateTill.Enabled = false;
			this.dtpDateTill.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dtpDateTill.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpDateTill.Location = new System.Drawing.Point(54, 42);
			this.dtpDateTill.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
			this.dtpDateTill.Name = "dtpDateTill";
			this.dtpDateTill.Size = new System.Drawing.Size(79, 21);
			this.dtpDateTill.TabIndex = 0;
			// 
			// cbDateTill
			// 
			this.cbDateTill.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.cbDateTill.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cbDateTill.Location = new System.Drawing.Point(8, 46);
			this.cbDateTill.Name = "cbDateTill";
			this.cbDateTill.Size = new System.Drawing.Size(42, 21);
			this.cbDateTill.TabIndex = 1;
			this.cbDateTill.Text = "По:";
			this.cbDateTill.CheckedChanged += new System.EventHandler(this.cbDateTill_CheckedChanged);
			// 
			// grpStatus
			// 
			this.grpStatus.Controls.Add(this.cbConfirmed);
			this.grpStatus.Controls.Add(this.cbSent);
			this.grpStatus.Controls.Add(this.cbPrepared);
			this.grpStatus.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.grpStatus.Location = new System.Drawing.Point(448, 6);
			this.grpStatus.Name = "grpStatus";
			this.grpStatus.Size = new System.Drawing.Size(134, 72);
			this.grpStatus.TabIndex = 17;
			this.grpStatus.TabStop = false;
			this.grpStatus.Text = "Состояние";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.dataGrid1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 105);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(992, 384);
			this.panel2.TabIndex = 20;
			// 
			// sqlCmdGetAccountExportPath
			// 
			this.sqlCmdGetAccountExportPath.CommandText = "SELECT ExportSchemaName FROM OrgsAccounts WHERE (OrgsAccountsID = @OrgAccountID)";
			this.sqlCmdGetAccountExportPath.Connection = this.sqlConnection1;
			this.sqlCmdGetAccountExportPath.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrgAccountID", System.Data.SqlDbType.Int, 4, "OrgsAccountsID"));
			// 
			// sqlCmdGetAccountExportSchemaName
			// 
			this.sqlCmdGetAccountExportSchemaName.CommandText = "SELECT ExportDirectory FROM OrgsAccounts WHERE (OrgsAccountsID = @OrgAccountID)";
			this.sqlCmdGetAccountExportSchemaName.Connection = this.sqlConnection1;
			this.sqlCmdGetAccountExportSchemaName.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrgAccountID", System.Data.SqlDbType.Int, 4, "OrgsAccountsID"));
			// 
			// sqlCheckOrgAccountSaldo
			// 
			this.sqlCheckOrgAccountSaldo.CommandText = "xCheckOrgAccountSaldoForPaymentOrder";
			this.sqlCheckOrgAccountSaldo.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCheckOrgAccountSaldo.Connection = this.sqlConnection1;
			this.sqlCheckOrgAccountSaldo.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCheckOrgAccountSaldo.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PaymentOrderID", System.Data.SqlDbType.Int, 4));
			this.sqlCheckOrgAccountSaldo.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SumRemainder", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// MenuItemImageProvider1
			// 
			this.MenuItemImageProvider1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.MenuItemImageProvider1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.MenuItemImageProvider1.HighliteColor = System.Drawing.Color.Lavender;
			this.MenuItemImageProvider1.SelectionColor = System.Drawing.Color.Lavender;
			this.MenuItemImageProvider1.SideColor = System.Drawing.Color.Gainsboro;
			// 
			// PaymentsOrdersList
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(992, 489);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.toolBar1);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Menu = this.mainMenu1;
			this.Name = "PaymentsOrdersList";
			this.Text = "Платежные поручения";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.PaymsList_Load);
			this.grpAgents.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsPaymentOrderList1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvOrgFrom)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvOrgTo)).EndInit();
			this.panel1.ResumeLayout(false);
			this.grpSum.ResumeLayout(false);
			this.grpPeriod.ResumeLayout(false);
			this.grpStatus.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		
		private void fillDs()
		{
			this.daUseProc.SelectCommand.Parameters["@UserID"].Value = App.UserLogonID;
			try
			{
				this.dsPaymentOrderList1.Clear();
				
				this.daUseProc.SelectCommand.Parameters["@RAccountLength"].Value = this.tbShowDigitsNumber.nValue;		
				this.daUseProc.SelectCommand.Parameters["@UseDateFrom"].Value	=0; 
				this.daUseProc.SelectCommand.Parameters["@DateFrom"].Value		=DateTime.Now;						
				this.daUseProc.SelectCommand.Parameters["@UseDateTill"].Value	=0; 
				this.daUseProc.SelectCommand.Parameters["@DateTill"].Value		=DateTime.Now;
				
				if ( this.cbConfirmed.Checked) 
				{
					if ( this.cbDateFrom.Checked) 
					{
						this.daUseProc.SelectCommand.Parameters["@UseDateFrom"].Value	=1;
						this.daUseProc.SelectCommand.Parameters["@DateFrom"].Value		= AM_Lib.DateBuilder.ClearTime(this.dtpDateFrom.Value);

					}
					if ( this.cbDateTill.Checked) 
					{
						this.daUseProc.SelectCommand.Parameters["@UseDateTill"].Value	=1; 
						DateTime dt = AM_Lib.DateBuilder.ClearTime(this.dtpDateTill.Value);
						this.daUseProc.SelectCommand.Parameters["@DateTill"].Value		=dt.AddDays(1);
					}
				}
				
				this.daUseProc.SelectCommand.Parameters["@IsPrepared"].Value	=0;
				this.daUseProc.SelectCommand.Parameters["@IsConfirmed"].Value	=0;
				this.daUseProc.SelectCommand.Parameters["@IsSent"].Value		=0;
				
				if ( this.cbPrepared.Checked)	this.daUseProc.SelectCommand.Parameters["@IsPrepared"].Value	=1;
				if ( this.cbConfirmed.Checked)	this.daUseProc.SelectCommand.Parameters["@IsConfirmed"].Value	=1;
				if ( this.cbSent.Checked)		this.daUseProc.SelectCommand.Parameters["@IsSent"].Value		=1;

				switch( this.comboBox1.SelectedIndex) 
				{
					case 1: // >=
						this.daUseProc.SelectCommand.Parameters["@UseSumLow"].Value		=1;
						this.daUseProc.SelectCommand.Parameters["@UseSumHigh"].Value	=0;
						this.daUseProc.SelectCommand.Parameters["@OrderSumLow"].Value	=this.textBoxV1.dValue;
						this.daUseProc.SelectCommand.Parameters["@OrderSumHigh"].Value	=0;
						break;
					case 2: // <=
						this.daUseProc.SelectCommand.Parameters["@UseSumLow"].Value		=0;
						this.daUseProc.SelectCommand.Parameters["@UseSumHigh"].Value	=1;
						this.daUseProc.SelectCommand.Parameters["@OrderSumLow"].Value	=0;
						this.daUseProc.SelectCommand.Parameters["@OrderSumHigh"].Value	=this.textBoxV1.dValue;
						break;
					case 3: // ==
						this.daUseProc.SelectCommand.Parameters["@UseSumLow"].Value		=1;
						this.daUseProc.SelectCommand.Parameters["@UseSumHigh"].Value	=1;
						this.daUseProc.SelectCommand.Parameters["@OrderSumLow"].Value	=this.textBoxV1.dValue;
						this.daUseProc.SelectCommand.Parameters["@OrderSumHigh"].Value	=this.textBoxV1.dValue;
						break;
					case  0: 
					case -1: 
					default:// Any
						this.daUseProc.SelectCommand.Parameters["@UseSumLow"].Value		=0;
						this.daUseProc.SelectCommand.Parameters["@UseSumHigh"].Value	=0;
						this.daUseProc.SelectCommand.Parameters["@OrderSumLow"].Value	=0;
						this.daUseProc.SelectCommand.Parameters["@OrderSumHigh"].Value	=0;
						break;
				}

				this.daUseProc.SelectCommand.Parameters["@OrgID"].Value	=this.ucOrgsAndAccounts.OrgID;
				this.daUseProc.SelectCommand.Parameters["@OrgAccountID"].Value	=this.ucOrgsAndAccounts.OrgAccountID;

				//				this.daUseProc.SelectCommand.Parameters["@OrgNameOwner"].Value	="%";
//				if ( this.cmbInnerOrg.SelectedIndex !=0) 
//					this.daUseProc.SelectCommand.Parameters["@OrgNameOwner"].Value	=this.cmbInnerOrg.Text + "%";

				this.daUseProc.SelectCommand.Parameters["@OrgNameContra"].Value	="%";
				if ( this.cmbOrgTo.SelectedIndex !=0)
					this.daUseProc.SelectCommand.Parameters["@OrgNameContra"].Value	=this.cmbOrgTo.Text + "%";

				this.daUseProc.Fill(this.dsPaymentOrderList1.PaymentsOrdersList);

				if ( this.dataView1.Count >0)
					this.dataGrid1.CurrentRowIndex = 0;
				else
					this.dataGrid1.CurrentRowIndex = -1;
				
				BindingManagerBase bm = (BindingManagerBase)this.BindingContext[this.dataView1];
				if ( bm.Count >0) bm.Position =bm.Count-1;
			}
			catch(Exception ex)
			{
				MsgBoxX.Show("Ошибка чтения данных: " +ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		private void mnuApplyFilter_Click(object sender, System.EventArgs e)
		{
			fillDs();
		}
		private void mnuClearFilter_Click(object sender, System.EventArgs e)
		{
			clearFilter();
		}

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if ( e.Button ==this.tbbApply) 
			{
				fillDs();
			}
			else if ( e.Button ==this.tbbClear) 
			{
				clearFilter();
			}
			else if ( e.Button ==this.tbbDel) 
			{
				PaymDelete();
			}
			else if ( e.Button ==this.tbbExec) 
			{
				PaymToBank();
			}
			else if ( e.Button ==this.tbbConfirm) 
			{
				PaymConfirm();
			}
			else if ( e.Button ==this.tbbEdit) 
			{
				PaymEdit();
			}
			else if ( e.Button ==this.tbbPrint) 
			{
				printPaymentOrder();
			}
		}

		private void printPaymentOrder()
		{

		}

		private bool ProcessPaymOrder(string ProcName)
		{
			bool bRet;
			
			this.sqlSendPO.Parameters["@PaymentOrderID"].Value = rwCurrent.PaymentOrderID;
			this.sqlSendPO.CommandText = "[" + ProcName + "]";
			
			if ( bRet =AM_Lib.sqlData.ExecuteNonQuery(sqlSendPO))
				this.fillDs();

			return bRet;
		}

		private void PaymConfirm()
		{
			if ( !App.AllowPaymentsOrdersSending)	return;
			if ( rwCurrent ==null)					return;

			if( rwCurrent.PaymentOrderStatusID == 3) 
			{
				MsgBoxX.Show("Действие отменено: Платёжное поручение уже проведено.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			int LockedPaymentOrderID =this.rwCurrent.PaymentOrderID;

			if ( !App.LockStatusChange(5, LockedPaymentOrderID, true))
			{
				MessageBox.Show("Проведение платёжного поручения невозможно: платежное поручение редактируется другим пользователем системы.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}				

			ProcessPaymOrder("xPaymOrderConfirm");

			App.LockStatusChange(5, LockedPaymentOrderID, false);
		}


		//Отправка платёжного поручения  в банк
		private void PaymToBank()
		{
			
			if (!App.AllowPaymentsOrdersSending)	return; //
			if ( rwCurrent ==null)					return; //
			if ( rwCurrent.Direction ==true)		return; //не отправка
				
			if( rwCurrent.PaymentOrderStatusID >= 2) 
			{
				MsgBoxX.Show("Действие отменено: Платёжное поручение уже отправлено.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			//ExportPaymentOrder();

			sqlCheckOrgAccountSaldo.Parameters["@PaymentOrderID"].Value = rwCurrent.PaymentOrderID;	
			if (!AM_Lib.sqlData.ExecuteNonQuery(sqlCheckOrgAccountSaldo) )	// Ошибка исполнения команды
				return ;
			if ( (int)sqlCheckOrgAccountSaldo.Parameters["@RETURN_VALUE"].Value == 0) 
			{
				double dRemainder= (double)sqlCheckOrgAccountSaldo.Parameters["@SumRemainder"].Value;
				if ( AM_Controls.MsgBoxX.Show("Недостаточно средств на расчетном счете.\n Не хватает " + dRemainder.ToString("0.00 руб..\n") +
					"Выполнить отправку платежного поручения в банк?",
					"BPS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
					return ;
			}
			
			int LockedPaymentOrderID =this.rwCurrent.PaymentOrderID;
			if ( !App.LockStatusChange(5, LockedPaymentOrderID, true))
			{
				MessageBox.Show("Выполнить отправку платёжного поручения невозможно: платежное поручение редактируется другим пользователем системы.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}				
			
			ProcessPaymOrder("xPaymOrderToBank");

			App.LockStatusChange(5, LockedPaymentOrderID, false);
		}

		private string GenerateDateString(string settings_name, DateTime date)
		{
			ConfigLoader cl = new ConfigLoader(App.POFormatSettingsFileName);
			return cl.GetDateStringFromDate(settings_name, date);
		}

		private string SetStringAlign(string str, int length, int align, string filler)
		{
			string AlignedString = string.Empty;
			if(length == -1)
			{
				return str;
			}
			if(str.Length > length)
			{
				return null;
			}
			switch(align)
			{
				case 0:
					for(int counter = 0; counter < (length - str.Length) / 2; counter ++)
					{
						AlignedString += filler;
					}
					if((length - str.Length) % 2 == 1)
					{
						AlignedString += filler;
					}
					AlignedString += str;
					for(int counter = 0; counter < (length - str.Length) / 2; counter ++)
					{
						AlignedString += filler;
					}
					return AlignedString;
				case 1:
					AlignedString += str;
					for(int counter = 0; counter < length - str.Length; counter ++)
					{
						AlignedString += filler;
					}
					return AlignedString;
				case 2:
					for(int counter = 0; counter < length - str.Length; counter ++)
					{
						AlignedString += filler;
					}
					AlignedString += str;
					return AlignedString;
				default:
					break;
			}
			return null;
		}

		private void ExportPaymentOrder()
		{
			string SchemaName = string.Empty, ExportPath = string.Empty;
			this.sqlCmdGetAccountExportPath.Parameters["@OrgAccountID"].Value = 
				 this.sqlCmdGetAccountExportSchemaName.Parameters["@OrgAccountID"].Value = rwCurrent.OrgAccountID;
			this.sqlCmdGetAccountExportPath.Connection.Open();
			try
			{
				ExportPath = this.sqlCmdGetAccountExportSchemaName.ExecuteScalar().ToString();
				SchemaName = this.sqlCmdGetAccountExportPath.ExecuteScalar().ToString();
			}
			catch(Exception ex)
			{
				AM_Controls.MsgBoxX.Show(ex.Message);
			}
			finally
			{
				this.sqlCmdGetAccountExportPath.Connection.Close();
			}

			ConfigLoader cl = new ConfigLoader(App.POFormatSettingsFileName);
			XmlNode node = cl.GetSpecifiedNode(SchemaName);
			string[] names = cl.GetSpecifiedNodeFields(node);
			string[] types = cl.GetSpecifiedNodeFieldAttributes("type", node);
			string[] headers = cl.GetSpecifiedNodeFieldAttributes("header", node);
			string[] aligns = cl.GetSpecifiedNodeFieldAttributes("align", node);
			string[] length = cl.GetSpecifiedNodeFieldAttributes("length", node);
			string[] delimiters = cl.GetSpecifiedNodeFieldAttributes("delimiter", node);
			string[] fillers = cl.GetSpecifiedNodeFieldAttributes("filler", node);
			string DefaultDelimiter = cl.GetSpecifiedNodeFieldsSplitter(SchemaName);
			string DecimalDelimiter = cl.GetSpecifiedNodeDecimalSplitter(SchemaName);
			string PaymentOrderString = string.Empty;
			string CurrentDelimiter = string.Empty;
			for(int counter = 0; counter < names.Length; counter ++)
			{
				if(delimiters[counter].CompareTo("") == 0)
				{
					CurrentDelimiter = DefaultDelimiter;
				}
				else
				{
					CurrentDelimiter = delimiters[counter];
				}
				if(types[counter].CompareTo("DBField") == 0)
				{
					switch(names[counter])
					{
						case "Номер документа":
							PaymentOrderString += headers[counter] + SetStringAlign(rwCurrent.PaymentNo, System.Convert.ToInt32(length[counter]), System.Convert.ToInt32(aligns[counter]), fillers[counter]) + CurrentDelimiter;
							break;
						case "Дата документа":
							PaymentOrderString += headers[counter] + SetStringAlign(GenerateDateString(SchemaName, rwCurrent.PaymentOrderDate), System.Convert.ToInt32(length[counter]), System.Convert.ToInt32(aligns[counter]), fillers[counter]) + CurrentDelimiter;
							break;
						case "Сумма":
							string number = System.Math.Round(System.Convert.ToDouble(rwCurrent.PaymentOrderSum), 0).ToString("0000000000") + 
								DecimalDelimiter +
								System.Math.Round((System.Convert.ToDouble(rwCurrent.PaymentOrderSum) - System.Math.Round(System.Convert.ToDouble(rwCurrent.PaymentOrderSum), 0)) * 100, 0).ToString("00");
							SetStringAlign(number, System.Convert.ToInt32(length[counter]), System.Convert.ToInt32(aligns[counter]), fillers[counter]);
							PaymentOrderString += headers[counter] + 
								SetStringAlign(number, System.Convert.ToInt32(length[counter]), System.Convert.ToInt32(aligns[counter]), fillers[counter]) +
								CurrentDelimiter;
							break;
						case "Наименование плательщика":
							PaymentOrderString += headers[counter] + SetStringAlign(rwCurrent.OrgName, System.Convert.ToInt32(length[counter]), System.Convert.ToInt32(aligns[counter]), fillers[counter]) + CurrentDelimiter;
							break;
						case "ИНН плательщика":
							PaymentOrderString += headers[counter] + SetStringAlign(rwCurrent.CodeINN, System.Convert.ToInt32(length[counter]), System.Convert.ToInt32(aligns[counter]), fillers[counter]) + CurrentDelimiter;
							break;
						case "КПП плательщика":
							if(rwCurrent.IsCodeKPPNull())
							{
								PaymentOrderString += headers[counter] + CurrentDelimiter;
							}
							else
							{
								PaymentOrderString += headers[counter] + SetStringAlign(rwCurrent.CodeKPP, System.Convert.ToInt32(length[counter]), System.Convert.ToInt32(aligns[counter]), fillers[counter]) + CurrentDelimiter;
							}
							break;
						case "Расчетный счет плательщика":
							PaymentOrderString += headers[counter] + SetStringAlign(rwCurrent.AccountID.ToString(), System.Convert.ToInt32(length[counter]), System.Convert.ToInt32(aligns[counter]), fillers[counter]) + CurrentDelimiter;
							break;
						case "БИК банка плательщика":
							PaymentOrderString += headers[counter] + SetStringAlign(rwCurrent.CodeBIK, System.Convert.ToInt32(length[counter]), System.Convert.ToInt32(aligns[counter]), fillers[counter]) + CurrentDelimiter;
							break;
						case "Наименование банка плательщика":
							PaymentOrderString += headers[counter] + SetStringAlign(rwCurrent.BankName, System.Convert.ToInt32(length[counter]), System.Convert.ToInt32(aligns[counter]), fillers[counter]) + CurrentDelimiter;
							break;
						case "Корреспондентский счет банка плательщика":
							PaymentOrderString += headers[counter] + SetStringAlign(rwCurrent.KAccount, System.Convert.ToInt32(length[counter]), System.Convert.ToInt32(aligns[counter]), fillers[counter]) + CurrentDelimiter;
							break;
						case "Наименование получателя":
							PaymentOrderString += headers[counter] + SetStringAlign(rwCurrent.OrgNameCorr, System.Convert.ToInt32(length[counter]), System.Convert.ToInt32(aligns[counter]), fillers[counter]) + CurrentDelimiter;
							break;
						case "ИНН получателя":
							PaymentOrderString += headers[counter] + SetStringAlign(rwCurrent.CodeINNCorr, System.Convert.ToInt32(length[counter]), System.Convert.ToInt32(aligns[counter]), fillers[counter]) + CurrentDelimiter;
							break;
						case "КПП получателя":
							if(rwCurrent.IsCodeKPPCorrNull())
							{
								PaymentOrderString += headers[counter] + CurrentDelimiter;
							}
							else
							{
								PaymentOrderString += headers[counter] + SetStringAlign(rwCurrent.CodeKPPCorr, System.Convert.ToInt32(length[counter]), System.Convert.ToInt32(aligns[counter]), fillers[counter]) + CurrentDelimiter;
							}
							break;
						case "Расчетный счет получателя":
							PaymentOrderString += headers[counter] + SetStringAlign(rwCurrent.AccountIDCorr.ToString(), System.Convert.ToInt32(length[counter]), System.Convert.ToInt32(aligns[counter]), fillers[counter]) + CurrentDelimiter;
							break;
						case "БИК банка получателя":
							PaymentOrderString += headers[counter] + SetStringAlign(rwCurrent.CodeBIKCorr, System.Convert.ToInt32(length[counter]), System.Convert.ToInt32(aligns[counter]), fillers[counter]) + CurrentDelimiter;
							break;
						case "Наименование банка получателя":
							PaymentOrderString += headers[counter] + SetStringAlign(rwCurrent.BankNameCorr, System.Convert.ToInt32(length[counter]), System.Convert.ToInt32(aligns[counter]), fillers[counter]) + CurrentDelimiter;
							break;
						case "Корреспондентский счет банка получателя":
							PaymentOrderString += headers[counter] + SetStringAlign(rwCurrent.KAccountCorr, System.Convert.ToInt32(length[counter]), System.Convert.ToInt32(aligns[counter]), fillers[counter]) + CurrentDelimiter;
							break;
						case "Основание":
							PaymentOrderString += headers[counter] + SetStringAlign(rwCurrent.PaymentOrderPurpose, System.Convert.ToInt32(length[counter]), System.Convert.ToInt32(aligns[counter]), fillers[counter]) + CurrentDelimiter;
							break;
						default:
							AM_Controls.MsgBoxX.Show("Неопознанное поле БД");
							break;
					}
				}
				else if(types[counter].CompareTo("ExtField") == 0)
				{
					PaymentOrderString += headers[counter] ;
				}
			}
			FileInfo m_Exportfile = new FileInfo(ExportPath);
			try
			{
				StreamWriter fileWriteStream = m_Exportfile.AppendText();
				fileWriteStream.Write(PaymentOrderString);
				fileWriteStream.Close();
			}
			catch(Exception)
			{
				return;
			}	
		}
		
		private void PaymUndoBank()
		{
			if ( !App.AllowPaymentsOrdersSending)	return;
			if ( rwCurrent==null)					return;

			if ( rwCurrent.PaymentOrderStatusID >= 3) 
			{
				MsgBoxX.Show("Действие отменено: Операция невозможна для проведенного платежа.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			
			int LockedPaymentOrderID =this.rwCurrent.PaymentOrderID;
			
			if ( !App.LockStatusChange(5, LockedPaymentOrderID, true))
			{
				MessageBox.Show("Удаление платёжного поручения невозможно: платежное поручение редактируется другим пользователем системы.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}				

			ProcessPaymOrder("xPaymOrderUndoBank");

			App.LockStatusChange(5, LockedPaymentOrderID, false);
		}

		private void PaymDelete()
		{
			if ( !App.AllowPaymentsOrdersEdit)	return;
			if ( rwCurrent ==null)				return;

			if ( rwCurrent.Direction==true)	// не отправка
			{
				MessageBox.Show("Действие отменено: приходное платёжное поручение удалить нельзя.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			if ( rwCurrent.PaymentOrderStatusID != 1) 
			{
				MessageBox.Show("Действие отменено: удалить можно только подготовленное платёжное поручение.", "BPS",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			if ( DialogResult.Yes ==MessageBox.Show("Вы действительно хотите удалить платёжное поручение?", "BPS", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
			{
				//ProcessPaymOrder("xPaymOrderDelete");
				int LockedPaymentOrderID =this.rwCurrent.PaymentOrderID;
				
				if ( !App.LockStatusChange(5, LockedPaymentOrderID, true))
				{
					MessageBox.Show("Удаление платёжного поручения невозможно: платежное поручение редактируется другим пользователем системы.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}				
				rwCurrent.Delete();
				this.updatePaymList();

				App.LockStatusChange(5, LockedPaymentOrderID, false);
			}
		}

		private void updatePaymList()
		{
			try
			{
				int n =this.daUseProc.Update(this.dsPaymentOrderList1);
				this.fillDs();
			}
			catch(Exception ex)
			{
				this.dsPaymentOrderList1.RejectChanges();
				AM_Controls.MsgBoxX.Show(ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
		
		private string getDate(DateTime dt, string szTime)
		{
			return "#" + dt.Month.ToString() + "/" + dt.Day.ToString() + "/" + dt.Year.ToString() + " " + szTime + "#";
		}

		private void btnFilterReset_Click(object sender, System.EventArgs e)
		{
			resetFilter();
		}
		
		private void resetFilter()
		{
//			this.cmbInnerOrg.SelectedIndex	=0;
			this.cmbOrgTo.SelectedIndex		=0;
			
			this.comboBox1.SelectedIndex	=0;
			this.textBoxV1.dValue 			=0;

			this.cbConfirmed.Checked		=false;
			this.cbPrepared.Checked			=true;
			this.cbSent.Checked				=false;

			this.cPeriod._PeriodType	=(AM_Controls.Span) 0;
			this.cPeriod._PeriodType	=(AM_Controls.Span) 1;
			this.cPeriod._cbDateFromUse =false;
			this.cPeriod._cbDateTillUse =false;
		}
		
		private void clearFilter()
		{
//			this.cmbInnerOrg.SelectedIndex	=0;
			this.cmbOrgTo.SelectedIndex		=0;
			
			this.comboBox1.SelectedIndex	=0;
			this.textBoxV1.dValue 			=0;

			this.cbConfirmed.Checked		=false;
			this.cbPrepared.Checked			=true;
			this.cbSent.Checked				=false;

			this.cPeriod._PeriodType	=(AM_Controls.Span) 0;
			this.cPeriod._PeriodType	=(AM_Controls.Span) 1;
			this.cPeriod._cbDateFromUse =false;
			this.cPeriod._cbDateTillUse =false;
		}

		private void PaymsList_Load(object sender, System.EventArgs e)
		{
			this.setPermissions();
//			App.Clone(mnuEdit.MenuItems, this.contextMenu1);
			App.Clone(contextMenu1.MenuItems, this.mnuEdit);
			this.bIsLoaded = true;
			this.resetFilter();			
			this.fillDs();
		}

		private void setPermissions()
		{
			this.tbbEdit.Enabled = this.tbbDel.Enabled = this.mnuOpen.Enabled = this.mnuDel.Enabled = App.AllowPaymentsOrdersEdit;
			this.tbbExec.Enabled = this.tbbConfirm.Enabled = this.mnuSend.Enabled = this.mnuConfirm.Enabled = this.mnuUndoBank.Enabled = App.AllowPaymentsOrdersSending;
		}
		
		private void dataGrid1_DoubleClick(object sender, System.EventArgs e)
		{
			this.PaymEdit();
		}


		private void mnuSend_Click(object sender, System.EventArgs e)
		{
			PaymToBank();
		}

		private void mnuConfirm_Click(object sender, System.EventArgs e)
		{
			PaymConfirm();
		}

		private void mnuDel_Click(object sender, System.EventArgs e)
		{
			PaymDelete();
		}

		private void PaymEdit()
		{
			if ( this.rwCurrent == null)		return;
			if ( !App.AllowPaymentsOrdersEdit)	return;

			BPS._Forms.PaymentsOrdersEdit pe;
			if(this.rwCurrent.PaymentOrderStatusID == 1)
			{
				pe = new BPS._Forms.PaymentsOrdersEdit(this.rwCurrent, false);
			}
			else if(this.rwCurrent.PaymentOrderStatusID == 2)
			{
				pe = new BPS._Forms.PaymentsOrdersEdit(this.rwCurrent, true);
			}
			else
			{
				AM_Controls.MsgBoxX.Show("Редактирование запрещено: Данное платёжное поручение уже проведено.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			if ( !App.LockStatusChange(5, this.rwCurrent.PaymentOrderID, true))
			{
				MessageBox.Show("Редактирование платёжного поручения невозможно: платежное поручение редактируется другим пользователем системы.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			
			pe.ShowDialog();
			
			if(pe.DialogResult == DialogResult.OK)
			{
				try
				{
					this.daUseProc.Update(this.dsPaymentOrderList1.PaymentsOrdersList);
				}
				catch(Exception ex)
				{
					AM_Controls.MsgBoxX.Show(ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
		}

		private void mnuOpen_Click(object sender, System.EventArgs e)
		{
			PaymEdit();
		}

		private void mnuUndoBank_Click(object sender, System.EventArgs e)
		{
			PaymUndoBank();
		}

		private void mnuRefresh_Click(object sender, System.EventArgs e)
		{
			fillDs();
		}

		private void cbConfirmed_CheckedChanged(object sender, System.EventArgs e)
		{
			this.grpPeriod.Enabled =this.cbConfirmed.Checked;   
		}

		private void cbDateFrom_CheckedChanged(object sender, System.EventArgs e)
		{
			this.dtpDateFrom.Enabled =this.cbDateFrom.Checked;  
		}

		private void cbDateTill_CheckedChanged(object sender, System.EventArgs e)
		{
			this.dtpDateTill.Enabled =this.cbDateTill.Checked;  
		}

		private void mnuPrint_Click(object sender, System.EventArgs e)
		{
			printPaymentOrder();
		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			PaymentOrdersImport PaymentOrdersImportForm = new PaymentOrdersImport();
			PaymentOrdersImportForm.Show();
		}

		private void tbShowDigitsNumber_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			fillDs();
		}

	}
}
