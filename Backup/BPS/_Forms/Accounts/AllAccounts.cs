using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace BPS._Forms.Accounts
{
	/// <summary>
	/// Summary description for AllAccounts.
	/// </summary>
	public class AllAccounts : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Splitter splitter2;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Panel panel9;
		private AM_Controls.DataGridV dataGridV1;
		private System.Windows.Forms.Panel panel10;
		private System.Windows.Forms.Panel panel11;
		private AM_Controls.DataGridV dataGridV2;
		private System.Data.SqlClient.SqlConnection sqlConnection1;
		private System.Data.SqlClient.SqlDataAdapter daSelAllAccounts;
		private BPS.BLL.Accounts.DataSets.dsAllAccounts dsAllAccounts1;
		private System.Data.DataView dvAllAccounts;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn AccountID;
		private System.Windows.Forms.DataGridTextBoxColumn ClientGroupName;
		private System.Windows.Forms.DataGridTextBoxColumn ClientName;
		private System.Windows.Forms.DataGridTextBoxColumn OrgName;
		private System.Windows.Forms.DataGridTextBoxColumn RAccount;
		private System.Windows.Forms.DataGridTextBoxColumn TypeName;
		private System.Windows.Forms.DataGridTextBoxColumn Saldo;
		private System.Windows.Forms.DataGridTextBoxColumn SumReserved;
		private System.Windows.Forms.DataGridTextBoxColumn SumWaited;
		private System.Windows.Forms.DataGridTextBoxColumn BankName;
		private System.Windows.Forms.DataGridTextBoxColumn CodeBIK;
		private System.Windows.Forms.DataGridTextBoxColumn CityName;
		private System.Windows.Forms.DataGridTextBoxColumn CurrencyID;
		private System.Data.SqlClient.SqlDataAdapter daSelectAccountsOperations;
		private BindingManagerBase bmAccounts;
		private BindingManagerBase bmAccountsOperations;
		private System.Data.DataView dvAccOper;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
		private System.Windows.Forms.DataGridTextBoxColumn OperationID;
		private System.Windows.Forms.DataGridTextBoxColumn InSum;
		private System.Windows.Forms.DataGridTextBoxColumn OutSum;
		private AM_Controls.TextBoxV tbSaldo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Label label2;
		private AM_Controls.TextBoxV tbReserv;
		private AM_Controls.TextBoxV tbWait;
		private AM_Controls.TextBoxV tbFree;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ImageList imageList2;
		private AM_Controls.ucPeriodSimple ucMovementPeriod;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.DataGridTextBoxColumn TransactionTypeName;
		private System.Windows.Forms.DataGridTextBoxColumn InitDate;
		private System.Windows.Forms.DataGridTextBoxColumn TransactionOperationID;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem mnuRefresh;
		private System.Windows.Forms.DataGridTextBoxColumn SumDisposable;
		private System.Windows.Forms.Button bnUpdOper;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.Windows.Forms.DataGridTextBoxColumn CompleteDate;
		private System.Windows.Forms.DataGridTextBoxColumn PaymentNo;
		private System.Windows.Forms.DataGridTextBoxColumn PaymentOrderDate;
		private System.Windows.Forms.DataGridTextBoxColumn Payer;
		private System.Windows.Forms.DataGridTextBoxColumn Recipient;
		private System.Windows.Forms.Button bnPrint;
		private System.Windows.Forms.Button bnPrintAccount;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnClientName;
		private AM_Controls.TextBoxV tbCredit;
		private AM_Controls.TextBoxV tbSaldoNetto;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Data.SqlClient.SqlCommand sqlCmdGetSaldo;
		private System.Windows.Forms.DataGridTextBoxColumn Currency;
		private System.Windows.Forms.CheckBox cbShowAllOperations;
		private System.Windows.Forms.DataGridBoolColumn ColumnTransactionCompleted;
		private System.Windows.Forms.Label label8;
		private AM_Controls.TextBoxV tbOpQty;
		private System.Windows.Forms.Button bnUpdAcc;
		private System.Windows.Forms.ToolBarButton tbbUpdt;
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.DataGridTextBoxColumn FinishDate;
		private System.Data.SqlClient.SqlConnection sqlConnection2;
		private System.Data.SqlClient.SqlDataAdapter daCreditsClientsList;
		private System.Data.SqlClient.SqlConnection sqlConnection3;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		private BPS.BLL.Clients.DataSets.dsClients dsClientsInCredits;
		private BPS.BLL.Clients.DataSets.dsClients dsClientsOutCredits;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox cbOrgsRemoved;
		private System.Windows.Forms.CheckBox cbShowZeroSaldo;
		private System.Windows.Forms.GroupBox groupBox2;
		private AM_Controls.TextBoxV tbShowDigitsNumber;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		private System.Data.SqlClient.SqlDataAdapter daGrantsClientsList;
		private BPS.BLL.Clients.DataSets.dsClients dsClientsGrants;
		private AM_Controls.TextBoxV tbFreeWait;
		private System.ComponentModel.IContainer components;

		public AllAccounts()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			
			App.SetDataGridTableStyle(this.dataGridTableStyle1);
			App.SetDataGridTableStyle(this.dataGridTableStyle2);
			
//			DateTime dt = new DateTime((DateTime.Now.Month==1)? DateTime.Now.AddYears(-1).Year:DateTime.Now.Year,DateTime.Now.AddMonths(-1).Month,1);
//			this.ucMovementPeriod._DateFrom = dt;
			
			//this.fillDsAccOper();
			this.fillDsAllAccounts();
			this.CreditsClientsListFill();
			this.fillTree();
			
			this.bmAccounts = this.BindingContext[this.dataGridV2.DataSource];
			this.bmAccountsOperations = this.BindingContext[this.dataGridV1.DataSource];
			this.bmAccounts.CurrentChanged += new EventHandler(bmAccounts_CurrentChanged);
			//this.bmAccountsOperations.CurrentChanged += new EventHandler(bmAccountsOper_CurrentChanged);
		}

		private void bmAccounts_CurrentChanged(object sender, EventArgs e)
		{			
			if(this.bmAccounts.Position < 0)
				return;
			BLL.Accounts.DataSets.dsAllAccounts.SelectAllAccountsRow rw = (BLL.Accounts.DataSets.dsAllAccounts.SelectAllAccountsRow) ((DataRowView) this.bmAccounts.Current).Row;
			fillDsAccOper(rw.AccountID, this.cbShowAllOperations.Checked ? 1 : 0);
			if (this.dvAccOper.Count >0)
				this.dataGridV1.CurrentRowIndex =0;
			else
				this.dataGridV1.CurrentRowIndex =-1;
			tbOpQty.nValue = this.dvAccOper.Count;
		}

		private void bmAccountsOper_CurrentChanged(object sender, EventArgs e)
		{
		}

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(AllAccounts));
			System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
			this.panel1 = new System.Windows.Forms.Panel();
			this.imageList2 = new System.Windows.Forms.ImageList(this.components);
			this.panel2 = new System.Windows.Forms.Panel();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.panel5 = new System.Windows.Forms.Panel();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.tbShowDigitsNumber = new AM_Controls.TextBoxV();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cbShowZeroSaldo = new System.Windows.Forms.CheckBox();
			this.cbOrgsRemoved = new System.Windows.Forms.CheckBox();
			this.panel4 = new System.Windows.Forms.Panel();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.panel3 = new System.Windows.Forms.Panel();
			this.panel6 = new System.Windows.Forms.Panel();
			this.dataGridV2 = new AM_Controls.DataGridV();
			this.dvAllAccounts = new System.Data.DataView();
			this.dsAllAccounts1 = new BPS.BLL.Accounts.DataSets.dsAllAccounts();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.AccountID = new System.Windows.Forms.DataGridTextBoxColumn();
			this.TypeName = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ClientGroupName = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ClientName = new System.Windows.Forms.DataGridTextBoxColumn();
			this.OrgName = new System.Windows.Forms.DataGridTextBoxColumn();
			this.RAccount = new System.Windows.Forms.DataGridTextBoxColumn();
			this.CurrencyID = new System.Windows.Forms.DataGridTextBoxColumn();
			this.Saldo = new System.Windows.Forms.DataGridTextBoxColumn();
			this.SumReserved = new System.Windows.Forms.DataGridTextBoxColumn();
			this.SumWaited = new System.Windows.Forms.DataGridTextBoxColumn();
			this.SumDisposable = new System.Windows.Forms.DataGridTextBoxColumn();
			this.BankName = new System.Windows.Forms.DataGridTextBoxColumn();
			this.CodeBIK = new System.Windows.Forms.DataGridTextBoxColumn();
			this.CityName = new System.Windows.Forms.DataGridTextBoxColumn();
			this.panel11 = new System.Windows.Forms.Panel();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.tbFree = new AM_Controls.TextBoxV();
			this.tbWait = new AM_Controls.TextBoxV();
			this.tbReserv = new AM_Controls.TextBoxV();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.tbSaldo = new AM_Controls.TextBoxV();
			this.tbCredit = new AM_Controls.TextBoxV();
			this.tbSaldoNetto = new AM_Controls.TextBoxV();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.tbFreeWait = new AM_Controls.TextBoxV();
			this.panel10 = new System.Windows.Forms.Panel();
			this.bnPrintAccount = new System.Windows.Forms.Button();
			this.bnUpdAcc = new System.Windows.Forms.Button();
			this.splitter2 = new System.Windows.Forms.Splitter();
			this.panel7 = new System.Windows.Forms.Panel();
			this.dataGridV1 = new AM_Controls.DataGridV();
			this.dvAccOper = new System.Data.DataView();
			this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
			this.OperationID = new System.Windows.Forms.DataGridTextBoxColumn();
			this.TransactionOperationID = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnTransactionCompleted = new System.Windows.Forms.DataGridBoolColumn();
			this.InitDate = new System.Windows.Forms.DataGridTextBoxColumn();
			this.CompleteDate = new System.Windows.Forms.DataGridTextBoxColumn();
			this.FinishDate = new System.Windows.Forms.DataGridTextBoxColumn();
			this.InSum = new System.Windows.Forms.DataGridTextBoxColumn();
			this.OutSum = new System.Windows.Forms.DataGridTextBoxColumn();
			this.Currency = new System.Windows.Forms.DataGridTextBoxColumn();
			this.TransactionTypeName = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnClientName = new System.Windows.Forms.DataGridTextBoxColumn();
			this.PaymentNo = new System.Windows.Forms.DataGridTextBoxColumn();
			this.PaymentOrderDate = new System.Windows.Forms.DataGridTextBoxColumn();
			this.Payer = new System.Windows.Forms.DataGridTextBoxColumn();
			this.Recipient = new System.Windows.Forms.DataGridTextBoxColumn();
			this.panel9 = new System.Windows.Forms.Panel();
			this.label8 = new System.Windows.Forms.Label();
			this.tbOpQty = new AM_Controls.TextBoxV();
			this.panel8 = new System.Windows.Forms.Panel();
			this.cbShowAllOperations = new System.Windows.Forms.CheckBox();
			this.bnPrint = new System.Windows.Forms.Button();
			this.bnUpdOper = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.ucMovementPeriod = new AM_Controls.ucPeriodSimple();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.daSelAllAccounts = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.daSelectAccountsOperations = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection2 = new System.Data.SqlClient.SqlConnection();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.mnuRefresh = new System.Windows.Forms.MenuItem();
			this.sqlCmdGetSaldo = new System.Data.SqlClient.SqlCommand();
			this.tbbUpdt = new System.Windows.Forms.ToolBarButton();
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.daCreditsClientsList = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection3 = new System.Data.SqlClient.SqlConnection();
			this.dsClientsInCredits = new BPS.BLL.Clients.DataSets.dsClients();
			this.dsClientsOutCredits = new BPS.BLL.Clients.DataSets.dsClients();
			this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
			this.daGrantsClientsList = new System.Data.SqlClient.SqlDataAdapter();
			this.dsClientsGrants = new BPS.BLL.Clients.DataSets.dsClients();
			this.panel2.SuspendLayout();
			this.panel5.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridV2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvAllAccounts)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsAllAccounts1)).BeginInit();
			this.panel11.SuspendLayout();
			this.panel10.SuspendLayout();
			this.panel7.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridV1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvAccOper)).BeginInit();
			this.panel9.SuspendLayout();
			this.panel8.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dsClientsInCredits)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsClientsOutCredits)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsClientsGrants)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.TabIndex = 0;
			// 
			// imageList2
			// 
			this.imageList2.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
			this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.treeView1);
			this.panel2.Controls.Add(this.panel5);
			this.panel2.Controls.Add(this.panel4);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel2.Location = new System.Drawing.Point(0, 28);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(270, 615);
			this.panel2.TabIndex = 1;
			// 
			// treeView1
			// 
			this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeView1.HideSelection = false;
			this.treeView1.ImageIndex = 1;
			this.treeView1.ImageList = this.imageList1;
			this.treeView1.Location = new System.Drawing.Point(0, 24);
			this.treeView1.Name = "treeView1";
			this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
																				  new System.Windows.Forms.TreeNode("Баланс", 1, 1, new System.Windows.Forms.TreeNode[] {
																																											new System.Windows.Forms.TreeNode("Активы", 1, 1, new System.Windows.Forms.TreeNode[] {
																																																																	  new System.Windows.Forms.TreeNode("Расчётные счета", 1, 1, new System.Windows.Forms.TreeNode[] {
																																																																																										 new System.Windows.Forms.TreeNode("Расчётные счета нормальные", 1, 1),
																																																																																										 new System.Windows.Forms.TreeNode("Расчётные счета специальные", 1, 1)}),
																																																																	  new System.Windows.Forms.TreeNode("Кассовые счета", 1, 1),
																																																																	  new System.Windows.Forms.TreeNode("Внешние лицевые счета", 1, 1),
																																																																	  new System.Windows.Forms.TreeNode("Кредиты Выданные", 1, 1),
																																																																	  new System.Windows.Forms.TreeNode("Кредиты (Ссуды)", 1, 1)}),
																																											new System.Windows.Forms.TreeNode("Пассивы", 1, 1, new System.Windows.Forms.TreeNode[] {
																																																																	   new System.Windows.Forms.TreeNode("Свой лицевой счет", 1, 1),
																																																																	   new System.Windows.Forms.TreeNode("Счета клиентов", 1, 1),
																																																																	   new System.Windows.Forms.TreeNode("Кредиты Полученные", 1, 1)})})});
			this.treeView1.Size = new System.Drawing.Size(270, 479);
			this.treeView1.TabIndex = 2;
			this.treeView1.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterExpand);
			this.treeView1.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCollapse);
			this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.groupBox2);
			this.panel5.Controls.Add(this.groupBox1);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel5.Location = new System.Drawing.Point(0, 503);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(270, 112);
			this.panel5.TabIndex = 1;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label11);
			this.groupBox2.Controls.Add(this.label10);
			this.groupBox2.Controls.Add(this.tbShowDigitsNumber);
			this.groupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupBox2.Location = new System.Drawing.Point(6, 68);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(260, 40);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Режим просмотра дерева счетов";
			// 
			// label11
			// 
			this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label11.Location = new System.Drawing.Point(176, 19);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(82, 14);
			this.label11.TabIndex = 3;
			this.label11.Text = "цифр(ы) счета";
			// 
			// label10
			// 
			this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label10.Location = new System.Drawing.Point(10, 19);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(126, 14);
			this.label10.TabIndex = 2;
			this.label10.Text = "Отображать последние";
			// 
			// tbShowDigitsNumber
			// 
			this.tbShowDigitsNumber.AllowDrop = true;
			this.tbShowDigitsNumber.dValue = 3;
			this.tbShowDigitsNumber.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbShowDigitsNumber.IsPcnt = false;
			this.tbShowDigitsNumber.Location = new System.Drawing.Point(140, 16);
			this.tbShowDigitsNumber.MaxDecPos = 0;
			this.tbShowDigitsNumber.MaxLength = 2;
			this.tbShowDigitsNumber.MaxPos = 2;
			this.tbShowDigitsNumber.Name = "tbShowDigitsNumber";
			this.tbShowDigitsNumber.Negative = System.Drawing.Color.Empty;
			this.tbShowDigitsNumber.nValue = ((long)(3));
			this.tbShowDigitsNumber.Positive = System.Drawing.Color.Empty;
			this.tbShowDigitsNumber.Size = new System.Drawing.Size(30, 21);
			this.tbShowDigitsNumber.TabIndex = 1;
			this.tbShowDigitsNumber.Text = "3";
			this.tbShowDigitsNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbShowDigitsNumber.TextMode = false;
			this.tbShowDigitsNumber.Zero = System.Drawing.Color.Empty;
			this.tbShowDigitsNumber.Validating += new System.ComponentModel.CancelEventHandler(this.tbShowDigitsNumber_Validating);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.cbShowZeroSaldo);
			this.groupBox1.Controls.Add(this.cbOrgsRemoved);
			this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(6, 6);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(260, 56);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Режим просмотра счетов";
			// 
			// cbShowZeroSaldo
			// 
			this.cbShowZeroSaldo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cbShowZeroSaldo.Location = new System.Drawing.Point(8, 38);
			this.cbShowZeroSaldo.Name = "cbShowZeroSaldo";
			this.cbShowZeroSaldo.Size = new System.Drawing.Size(218, 14);
			this.cbShowZeroSaldo.TabIndex = 2;
			this.cbShowZeroSaldo.Text = "Показывать счета с нулевым сальдо";
			this.cbShowZeroSaldo.CheckedChanged += new System.EventHandler(this.cbShowZeroSaldo_CheckedChanged);
			// 
			// cbOrgsRemoved
			// 
			this.cbOrgsRemoved.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cbOrgsRemoved.Location = new System.Drawing.Point(8, 20);
			this.cbOrgsRemoved.Name = "cbOrgsRemoved";
			this.cbOrgsRemoved.Size = new System.Drawing.Size(246, 14);
			this.cbOrgsRemoved.TabIndex = 1;
			this.cbOrgsRemoved.Text = "Показывать счета удалённых организаций";
			this.cbOrgsRemoved.CheckedChanged += new System.EventHandler(this.cbOrgsRemoved_CheckedChanged);
			// 
			// panel4
			// 
			this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new System.Drawing.Point(0, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(270, 24);
			this.panel4.TabIndex = 0;
			this.panel4.Visible = false;
			// 
			// splitter1
			// 
			this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.splitter1.Location = new System.Drawing.Point(270, 28);
			this.splitter1.MinSize = 270;
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(6, 615);
			this.splitter1.TabIndex = 2;
			this.splitter1.TabStop = false;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.panel6);
			this.panel3.Controls.Add(this.splitter2);
			this.panel3.Controls.Add(this.panel7);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(276, 28);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(752, 615);
			this.panel3.TabIndex = 2;
			// 
			// panel6
			// 
			this.panel6.Controls.Add(this.dataGridV2);
			this.panel6.Controls.Add(this.panel11);
			this.panel6.Controls.Add(this.panel10);
			this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel6.Location = new System.Drawing.Point(0, 0);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(752, 376);
			this.panel6.TabIndex = 0;
			// 
			// dataGridV2
			// 
			this.dataGridV2._CanEdit = false;
			this.dataGridV2._InvisibleColumn = 0;
			this.dataGridV2.CaptionBackColor = System.Drawing.SystemColors.Control;
			this.dataGridV2.CaptionForeColor = System.Drawing.SystemColors.WindowText;
			this.dataGridV2.CaptionText = "Счета";
			this.dataGridV2.DataMember = "";
			this.dataGridV2.DataSource = this.dvAllAccounts;
			this.dataGridV2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridV2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridV2.Location = new System.Drawing.Point(0, 26);
			this.dataGridV2.Name = "dataGridV2";
			this.dataGridV2.ReadOnly = true;
			this.dataGridV2.Size = new System.Drawing.Size(752, 310);
			this.dataGridV2.TabIndex = 2;
			this.dataGridV2.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																								   this.dataGridTableStyle1});
			// 
			// dvAllAccounts
			// 
			this.dvAllAccounts.AllowDelete = false;
			this.dvAllAccounts.AllowEdit = false;
			this.dvAllAccounts.AllowNew = false;
			this.dvAllAccounts.Sort = "ClientID, OrgID, AccountTypeID, CurrencyID";
			this.dvAllAccounts.Table = this.dsAllAccounts1.SelectAllAccounts;
			this.dvAllAccounts.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.dvAllAccounts_ListChanged);
			// 
			// dsAllAccounts1
			// 
			this.dsAllAccounts1.DataSetName = "dsAllAccounts";
			this.dsAllAccounts1.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.DataGrid = this.dataGridV2;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.AccountID,
																												  this.TypeName,
																												  this.ClientGroupName,
																												  this.ClientName,
																												  this.OrgName,
																												  this.RAccount,
																												  this.CurrencyID,
																												  this.Saldo,
																												  this.SumReserved,
																												  this.SumWaited,
																												  this.SumDisposable,
																												  this.BankName,
																												  this.CodeBIK,
																												  this.CityName});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "SelectAllAccounts";
			// 
			// AccountID
			// 
			this.AccountID.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.AccountID.Format = "00000";
			this.AccountID.FormatInfo = null;
			this.AccountID.HeaderText = "ID";
			this.AccountID.MappingName = "AccountID";
			this.AccountID.NullText = "-";
			this.AccountID.Width = 40;
			// 
			// TypeName
			// 
			this.TypeName.Format = "";
			this.TypeName.FormatInfo = null;
			this.TypeName.HeaderText = "Тип счёта";
			this.TypeName.MappingName = "TypeName";
			this.TypeName.NullText = "-";
			this.TypeName.Width = 90;
			// 
			// ClientGroupName
			// 
			this.ClientGroupName.Format = "";
			this.ClientGroupName.FormatInfo = null;
			this.ClientGroupName.HeaderText = "Группа";
			this.ClientGroupName.MappingName = "ClientGroupName";
			this.ClientGroupName.NullText = "-";
			this.ClientGroupName.Width = 120;
			// 
			// ClientName
			// 
			this.ClientName.Format = "";
			this.ClientName.FormatInfo = null;
			this.ClientName.HeaderText = "Владелец";
			this.ClientName.MappingName = "ClientName";
			this.ClientName.NullText = "-";
			this.ClientName.Width = 120;
			// 
			// OrgName
			// 
			this.OrgName.Format = "";
			this.OrgName.FormatInfo = null;
			this.OrgName.HeaderText = "Организация";
			this.OrgName.MappingName = "OrgName";
			this.OrgName.NullText = "-";
			this.OrgName.Width = 120;
			// 
			// RAccount
			// 
			this.RAccount.Format = "";
			this.RAccount.FormatInfo = null;
			this.RAccount.HeaderText = "Р. счёт";
			this.RAccount.MappingName = "RAccount";
			this.RAccount.NullText = "-";
			this.RAccount.Width = 135;
			// 
			// CurrencyID
			// 
			this.CurrencyID.Format = "";
			this.CurrencyID.FormatInfo = null;
			this.CurrencyID.HeaderText = "Валюта";
			this.CurrencyID.MappingName = "CurrencyID";
			this.CurrencyID.NullText = "-";
			this.CurrencyID.Width = 45;
			// 
			// Saldo
			// 
			this.Saldo.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.Saldo.Format = "#,##0.00";
			this.Saldo.FormatInfo = null;
			this.Saldo.HeaderText = "Сальдо .";
			this.Saldo.MappingName = "Saldo";
			this.Saldo.NullText = "-";
			this.Saldo.Width = 75;
			// 
			// SumReserved
			// 
			this.SumReserved.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.SumReserved.Format = "#,##0.00";
			this.SumReserved.FormatInfo = null;
			this.SumReserved.HeaderText = "Зарезервировано .";
			this.SumReserved.MappingName = "SumReserved";
			this.SumReserved.NullText = "-";
			this.SumReserved.Width = 75;
			// 
			// SumWaited
			// 
			this.SumWaited.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.SumWaited.Format = "#,##0.00";
			this.SumWaited.FormatInfo = null;
			this.SumWaited.HeaderText = "Ожидается .";
			this.SumWaited.MappingName = "SumWaited";
			this.SumWaited.NullText = "-";
			this.SumWaited.Width = 75;
			// 
			// SumDisposable
			// 
			this.SumDisposable.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.SumDisposable.Format = "#,##0.00";
			this.SumDisposable.FormatInfo = null;
			this.SumDisposable.HeaderText = "Свободно";
			this.SumDisposable.MappingName = "DisposableSum ";
			this.SumDisposable.NullText = "-";
			this.SumDisposable.Width = 75;
			// 
			// BankName
			// 
			this.BankName.Format = "";
			this.BankName.FormatInfo = null;
			this.BankName.HeaderText = "Банк";
			this.BankName.MappingName = "BankName";
			this.BankName.NullText = "-";
			this.BankName.Width = 120;
			// 
			// CodeBIK
			// 
			this.CodeBIK.Format = "";
			this.CodeBIK.FormatInfo = null;
			this.CodeBIK.HeaderText = "БИК";
			this.CodeBIK.MappingName = "CodeBIK";
			this.CodeBIK.NullText = "-";
			this.CodeBIK.Width = 120;
			// 
			// CityName
			// 
			this.CityName.Format = "";
			this.CityName.FormatInfo = null;
			this.CityName.HeaderText = "Город";
			this.CityName.MappingName = "CityName";
			this.CityName.NullText = "-";
			this.CityName.Width = 120;
			// 
			// panel11
			// 
			this.panel11.Controls.Add(this.label4);
			this.panel11.Controls.Add(this.label3);
			this.panel11.Controls.Add(this.tbFree);
			this.panel11.Controls.Add(this.tbWait);
			this.panel11.Controls.Add(this.tbReserv);
			this.panel11.Controls.Add(this.label2);
			this.panel11.Controls.Add(this.label1);
			this.panel11.Controls.Add(this.tbSaldo);
			this.panel11.Controls.Add(this.tbCredit);
			this.panel11.Controls.Add(this.tbSaldoNetto);
			this.panel11.Controls.Add(this.label6);
			this.panel11.Controls.Add(this.label7);
			this.panel11.Controls.Add(this.label9);
			this.panel11.Controls.Add(this.tbFreeWait);
			this.panel11.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel11.Location = new System.Drawing.Point(0, 336);
			this.panel11.Name = "panel11";
			this.panel11.Size = new System.Drawing.Size(752, 40);
			this.panel11.TabIndex = 1;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(490, 2);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 13);
			this.label4.TabIndex = 7;
			this.label4.Text = "Свободно:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(400, 2);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(68, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Ожидается:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbFree
			// 
			this.tbFree.AllowDrop = true;
			this.tbFree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbFree.CausesValidation = false;
			this.tbFree.dValue = 0;
			this.tbFree.IsPcnt = false;
			this.tbFree.Location = new System.Drawing.Point(496, 16);
			this.tbFree.MaxDecPos = 2;
			this.tbFree.MaxPos = 12;
			this.tbFree.Name = "tbFree";
			this.tbFree.Negative = System.Drawing.Color.Empty;
			this.tbFree.nValue = ((long)(0));
			this.tbFree.Positive = System.Drawing.Color.Empty;
			this.tbFree.ReadOnly = true;
			this.tbFree.Size = new System.Drawing.Size(90, 21);
			this.tbFree.TabIndex = 5;
			this.tbFree.Text = "";
			this.tbFree.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbFree.TextMode = false;
			this.tbFree.Zero = System.Drawing.Color.Empty;
			this.tbFree.TextChanged += new System.EventHandler(this.tbFree_TextChanged);
			// 
			// tbWait
			// 
			this.tbWait.AllowDrop = true;
			this.tbWait.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbWait.CausesValidation = false;
			this.tbWait.dValue = 0;
			this.tbWait.IsPcnt = false;
			this.tbWait.Location = new System.Drawing.Point(404, 16);
			this.tbWait.MaxDecPos = 2;
			this.tbWait.MaxPos = 12;
			this.tbWait.Name = "tbWait";
			this.tbWait.Negative = System.Drawing.Color.Empty;
			this.tbWait.nValue = ((long)(0));
			this.tbWait.Positive = System.Drawing.Color.Empty;
			this.tbWait.ReadOnly = true;
			this.tbWait.Size = new System.Drawing.Size(90, 21);
			this.tbWait.TabIndex = 4;
			this.tbWait.Text = "";
			this.tbWait.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbWait.TextMode = false;
			this.tbWait.Zero = System.Drawing.Color.Empty;
			this.tbWait.TextChanged += new System.EventHandler(this.tbWait_TextChanged);
			// 
			// tbReserv
			// 
			this.tbReserv.AllowDrop = true;
			this.tbReserv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbReserv.CausesValidation = false;
			this.tbReserv.dValue = 0;
			this.tbReserv.IsPcnt = false;
			this.tbReserv.Location = new System.Drawing.Point(312, 16);
			this.tbReserv.MaxDecPos = 2;
			this.tbReserv.MaxPos = 12;
			this.tbReserv.Name = "tbReserv";
			this.tbReserv.Negative = System.Drawing.Color.Empty;
			this.tbReserv.nValue = ((long)(0));
			this.tbReserv.Positive = System.Drawing.Color.Empty;
			this.tbReserv.ReadOnly = true;
			this.tbReserv.Size = new System.Drawing.Size(90, 21);
			this.tbReserv.TabIndex = 3;
			this.tbReserv.Text = "";
			this.tbReserv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbReserv.TextMode = false;
			this.tbReserv.Zero = System.Drawing.Color.Empty;
			this.tbReserv.TextChanged += new System.EventHandler(this.tbReserv_TextChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(312, 2);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Резервировано:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 2);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(52, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Сальдо:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbSaldo
			// 
			this.tbSaldo.AllowDrop = true;
			this.tbSaldo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbSaldo.CausesValidation = false;
			this.tbSaldo.dValue = 0;
			this.tbSaldo.IsPcnt = false;
			this.tbSaldo.Location = new System.Drawing.Point(4, 16);
			this.tbSaldo.MaxDecPos = 2;
			this.tbSaldo.MaxPos = 12;
			this.tbSaldo.Name = "tbSaldo";
			this.tbSaldo.Negative = System.Drawing.Color.Empty;
			this.tbSaldo.nValue = ((long)(0));
			this.tbSaldo.Positive = System.Drawing.Color.Empty;
			this.tbSaldo.ReadOnly = true;
			this.tbSaldo.Size = new System.Drawing.Size(90, 21);
			this.tbSaldo.TabIndex = 0;
			this.tbSaldo.Text = "";
			this.tbSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbSaldo.TextMode = false;
			this.tbSaldo.Zero = System.Drawing.Color.Empty;
			this.tbSaldo.TextChanged += new System.EventHandler(this.tbSaldo_TextChanged);
			// 
			// tbCredit
			// 
			this.tbCredit.AllowDrop = true;
			this.tbCredit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbCredit.CausesValidation = false;
			this.tbCredit.dValue = 0;
			this.tbCredit.IsPcnt = false;
			this.tbCredit.Location = new System.Drawing.Point(96, 16);
			this.tbCredit.MaxDecPos = 2;
			this.tbCredit.MaxPos = 12;
			this.tbCredit.Name = "tbCredit";
			this.tbCredit.Negative = System.Drawing.Color.Empty;
			this.tbCredit.nValue = ((long)(0));
			this.tbCredit.Positive = System.Drawing.Color.Empty;
			this.tbCredit.ReadOnly = true;
			this.tbCredit.Size = new System.Drawing.Size(90, 21);
			this.tbCredit.TabIndex = 0;
			this.tbCredit.Text = "";
			this.tbCredit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbCredit.TextMode = false;
			this.tbCredit.Zero = System.Drawing.Color.Empty;
			// 
			// tbSaldoNetto
			// 
			this.tbSaldoNetto.AllowDrop = true;
			this.tbSaldoNetto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbSaldoNetto.CausesValidation = false;
			this.tbSaldoNetto.dValue = 0;
			this.tbSaldoNetto.IsPcnt = false;
			this.tbSaldoNetto.Location = new System.Drawing.Point(188, 16);
			this.tbSaldoNetto.MaxDecPos = 2;
			this.tbSaldoNetto.MaxPos = 12;
			this.tbSaldoNetto.Name = "tbSaldoNetto";
			this.tbSaldoNetto.Negative = System.Drawing.Color.Empty;
			this.tbSaldoNetto.nValue = ((long)(0));
			this.tbSaldoNetto.Positive = System.Drawing.Color.Empty;
			this.tbSaldoNetto.ReadOnly = true;
			this.tbSaldoNetto.Size = new System.Drawing.Size(90, 21);
			this.tbSaldoNetto.TabIndex = 0;
			this.tbSaldoNetto.Text = "";
			this.tbSaldoNetto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbSaldoNetto.TextMode = false;
			this.tbSaldoNetto.Zero = System.Drawing.Color.Empty;
			this.tbSaldoNetto.TextChanged += new System.EventHandler(this.tbSaldoNetto_TextChanged);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(92, 2);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(52, 13);
			this.label6.TabIndex = 1;
			this.label6.Text = "Кредит:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(182, 2);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(90, 13);
			this.label7.TabIndex = 1;
			this.label7.Text = "Сальдо-Кредит:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(584, 2);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(132, 13);
			this.label9.TabIndex = 7;
			this.label9.Text = "Свободно+Ожидается:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbFreeWait
			// 
			this.tbFreeWait.AllowDrop = true;
			this.tbFreeWait.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbFreeWait.CausesValidation = false;
			this.tbFreeWait.dValue = 0;
			this.tbFreeWait.IsPcnt = false;
			this.tbFreeWait.Location = new System.Drawing.Point(588, 16);
			this.tbFreeWait.MaxDecPos = 2;
			this.tbFreeWait.MaxPos = 12;
			this.tbFreeWait.Name = "tbFreeWait";
			this.tbFreeWait.Negative = System.Drawing.Color.Empty;
			this.tbFreeWait.nValue = ((long)(0));
			this.tbFreeWait.Positive = System.Drawing.Color.Empty;
			this.tbFreeWait.ReadOnly = true;
			this.tbFreeWait.Size = new System.Drawing.Size(90, 21);
			this.tbFreeWait.TabIndex = 5;
			this.tbFreeWait.Text = "";
			this.tbFreeWait.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbFreeWait.TextMode = false;
			this.tbFreeWait.Zero = System.Drawing.Color.Empty;
			this.tbFreeWait.TextChanged += new System.EventHandler(this.tbFreeNetto_TextChanged);
			// 
			// panel10
			// 
			this.panel10.Controls.Add(this.bnPrintAccount);
			this.panel10.Controls.Add(this.bnUpdAcc);
			this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel10.Location = new System.Drawing.Point(0, 0);
			this.panel10.Name = "panel10";
			this.panel10.Size = new System.Drawing.Size(752, 26);
			this.panel10.TabIndex = 0;
			// 
			// bnPrintAccount
			// 
			this.bnPrintAccount.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.bnPrintAccount.Image = ((System.Drawing.Image)(resources.GetObject("bnPrintAccount.Image")));
			this.bnPrintAccount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bnPrintAccount.Location = new System.Drawing.Point(668, 1);
			this.bnPrintAccount.Name = "bnPrintAccount";
			this.bnPrintAccount.Size = new System.Drawing.Size(82, 23);
			this.bnPrintAccount.TabIndex = 4;
			this.bnPrintAccount.Text = "Печать";
			this.bnPrintAccount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.bnPrintAccount.Click += new System.EventHandler(this.bnPrintAccount_Click);
			// 
			// bnUpdAcc
			// 
			this.bnUpdAcc.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.bnUpdAcc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bnUpdAcc.ImageIndex = 0;
			this.bnUpdAcc.ImageList = this.imageList2;
			this.bnUpdAcc.Location = new System.Drawing.Point(584, 1);
			this.bnUpdAcc.Name = "bnUpdAcc";
			this.bnUpdAcc.Size = new System.Drawing.Size(82, 23);
			this.bnUpdAcc.TabIndex = 5;
			this.bnUpdAcc.Text = "Обновить";
			this.bnUpdAcc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.bnUpdAcc.Click += new System.EventHandler(this.bnUpdAcc_Click);
			// 
			// splitter2
			// 
			this.splitter2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.splitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.splitter2.Location = new System.Drawing.Point(0, 376);
			this.splitter2.Name = "splitter2";
			this.splitter2.Size = new System.Drawing.Size(752, 7);
			this.splitter2.TabIndex = 2;
			this.splitter2.TabStop = false;
			// 
			// panel7
			// 
			this.panel7.Controls.Add(this.dataGridV1);
			this.panel7.Controls.Add(this.panel9);
			this.panel7.Controls.Add(this.panel8);
			this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel7.Location = new System.Drawing.Point(0, 383);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(752, 232);
			this.panel7.TabIndex = 1;
			// 
			// dataGridV1
			// 
			this.dataGridV1._CanEdit = false;
			this.dataGridV1._InvisibleColumn = 0;
			this.dataGridV1.AllowSorting = false;
			this.dataGridV1.CaptionBackColor = System.Drawing.SystemColors.Control;
			this.dataGridV1.CaptionForeColor = System.Drawing.SystemColors.WindowText;
			this.dataGridV1.CaptionText = "Движение по счёту";
			this.dataGridV1.CaptionVisible = false;
			this.dataGridV1.DataMember = "";
			this.dataGridV1.DataSource = this.dvAccOper;
			this.dataGridV1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridV1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridV1.Location = new System.Drawing.Point(0, 28);
			this.dataGridV1.Name = "dataGridV1";
			this.dataGridV1.ReadOnly = true;
			this.dataGridV1.Size = new System.Drawing.Size(752, 186);
			this.dataGridV1.TabIndex = 2;
			this.dataGridV1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																								   this.dataGridTableStyle2});
			// 
			// dvAccOper
			// 
			this.dvAccOper.Table = this.dsAllAccounts1.SelectAccountsOperations;
			this.dvAccOper.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.dvAccOper_ListChanged);
			// 
			// dataGridTableStyle2
			// 
			this.dataGridTableStyle2.AllowSorting = false;
			this.dataGridTableStyle2.DataGrid = this.dataGridV1;
			this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.OperationID,
																												  this.TransactionOperationID,
																												  this.ColumnTransactionCompleted,
																												  this.InitDate,
																												  this.CompleteDate,
																												  this.FinishDate,
																												  this.InSum,
																												  this.OutSum,
																												  this.Currency,
																												  this.TransactionTypeName,
																												  this.ColumnClientName,
																												  this.PaymentNo,
																												  this.PaymentOrderDate,
																												  this.Payer,
																												  this.Recipient});
			this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle2.MappingName = "SelectAccountsOperations";
			this.dataGridTableStyle2.ReadOnly = true;
			// 
			// OperationID
			// 
			this.OperationID.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.OperationID.Format = "";
			this.OperationID.FormatInfo = null;
			this.OperationID.HeaderText = "ID";
			this.OperationID.MappingName = "OperationID";
			this.OperationID.NullText = "-";
			this.OperationID.Width = 40;
			// 
			// TransactionOperationID
			// 
			this.TransactionOperationID.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.TransactionOperationID.Format = "";
			this.TransactionOperationID.FormatInfo = null;
			this.TransactionOperationID.HeaderText = "Транзакция";
			this.TransactionOperationID.MappingName = "TransactionOperationID";
			this.TransactionOperationID.NullText = "-";
			this.TransactionOperationID.Width = 40;
			// 
			// ColumnTransactionCompleted
			// 
			this.ColumnTransactionCompleted.FalseValue = false;
			this.ColumnTransactionCompleted.HeaderText = "Вып";
			this.ColumnTransactionCompleted.MappingName = "TransactionCompleted";
			this.ColumnTransactionCompleted.NullText = "-";
			this.ColumnTransactionCompleted.NullValue = ((object)(resources.GetObject("ColumnTransactionCompleted.NullValue")));
			this.ColumnTransactionCompleted.TrueValue = true;
			this.ColumnTransactionCompleted.Width = 25;
			// 
			// InitDate
			// 
			this.InitDate.Format = "dd/MM/yy";
			this.InitDate.FormatInfo = null;
			this.InitDate.HeaderText = "Начата";
			this.InitDate.MappingName = "InitDate";
			this.InitDate.NullText = "-";
			this.InitDate.Width = 50;
			// 
			// CompleteDate
			// 
			this.CompleteDate.Format = "dd/MM/yy";
			this.CompleteDate.FormatInfo = null;
			this.CompleteDate.HeaderText = "Завершена";
			this.CompleteDate.MappingName = "CompleteDate";
			this.CompleteDate.NullText = "-";
			this.CompleteDate.Width = 50;
			// 
			// FinishDate
			// 
			this.FinishDate.Format = "dd/MM/yy";
			this.FinishDate.FormatInfo = null;
			this.FinishDate.HeaderText = "Проведена";
			this.FinishDate.MappingName = "FinishDate";
			this.FinishDate.NullText = "-";
			this.FinishDate.Width = 75;
			// 
			// InSum
			// 
			this.InSum.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.InSum.Format = "#,##0.00";
			this.InSum.FormatInfo = null;
			this.InSum.HeaderText = "Приход .";
			this.InSum.MappingName = "Приход ";
			this.InSum.NullText = "-";
			this.InSum.Width = 90;
			// 
			// OutSum
			// 
			this.OutSum.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.OutSum.Format = "#,##0.00";
			this.OutSum.FormatInfo = null;
			this.OutSum.HeaderText = "Расход .";
			this.OutSum.MappingName = "Расход ";
			this.OutSum.NullText = "-";
			this.OutSum.Width = 90;
			// 
			// Currency
			// 
			this.Currency.Format = "";
			this.Currency.FormatInfo = null;
			this.Currency.HeaderText = "Валюта";
			this.Currency.MappingName = "CurrencyID";
			this.Currency.NullText = "-";
			this.Currency.Width = 50;
			// 
			// TransactionTypeName
			// 
			this.TransactionTypeName.Format = "";
			this.TransactionTypeName.FormatInfo = null;
			this.TransactionTypeName.HeaderText = "Тип транзакции";
			this.TransactionTypeName.MappingName = "TransactionTypeNameX ";
			this.TransactionTypeName.NullText = "-";
			this.TransactionTypeName.Width = 120;
			// 
			// ColumnClientName
			// 
			this.ColumnClientName.Format = "";
			this.ColumnClientName.FormatInfo = null;
			this.ColumnClientName.HeaderText = "Клиент";
			this.ColumnClientName.MappingName = "ClientName";
			this.ColumnClientName.NullText = "-";
			this.ColumnClientName.Width = 75;
			// 
			// PaymentNo
			// 
			this.PaymentNo.Format = "";
			this.PaymentNo.FormatInfo = null;
			this.PaymentNo.HeaderText = "№ п.п";
			this.PaymentNo.MappingName = "PaymentNo";
			this.PaymentNo.NullText = "-";
			this.PaymentNo.Width = 50;
			// 
			// PaymentOrderDate
			// 
			this.PaymentOrderDate.Format = "dd/MM/yy";
			this.PaymentOrderDate.FormatInfo = null;
			this.PaymentOrderDate.HeaderText = "Дата п.п";
			this.PaymentOrderDate.MappingName = "PaymentOrderDate";
			this.PaymentOrderDate.NullText = "-";
			this.PaymentOrderDate.Width = 50;
			// 
			// Payer
			// 
			this.Payer.Format = "";
			this.Payer.FormatInfo = null;
			this.Payer.HeaderText = "Плательщик";
			this.Payer.MappingName = "Плательщик";
			this.Payer.NullText = "-";
			this.Payer.Width = 120;
			// 
			// Recipient
			// 
			this.Recipient.Format = "";
			this.Recipient.FormatInfo = null;
			this.Recipient.HeaderText = "Получатель";
			this.Recipient.MappingName = "Получатель";
			this.Recipient.NullText = "-";
			this.Recipient.Width = 120;
			// 
			// panel9
			// 
			this.panel9.Controls.Add(this.label8);
			this.panel9.Controls.Add(this.tbOpQty);
			this.panel9.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel9.Location = new System.Drawing.Point(0, 214);
			this.panel9.Name = "panel9";
			this.panel9.Size = new System.Drawing.Size(752, 18);
			this.panel9.TabIndex = 1;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(34, 2);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(136, 13);
			this.label8.TabIndex = 3;
			this.label8.Text = "К-во операций по счету:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbOpQty
			// 
			this.tbOpQty.AllowDrop = true;
			this.tbOpQty.BackColor = System.Drawing.SystemColors.Control;
			this.tbOpQty.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbOpQty.dValue = 0;
			this.tbOpQty.IsPcnt = false;
			this.tbOpQty.Location = new System.Drawing.Point(172, 2);
			this.tbOpQty.MaxDecPos = 2;
			this.tbOpQty.MaxPos = 12;
			this.tbOpQty.Name = "tbOpQty";
			this.tbOpQty.Negative = System.Drawing.Color.Empty;
			this.tbOpQty.nValue = ((long)(0));
			this.tbOpQty.Positive = System.Drawing.Color.Empty;
			this.tbOpQty.ReadOnly = true;
			this.tbOpQty.Size = new System.Drawing.Size(54, 14);
			this.tbOpQty.TabIndex = 2;
			this.tbOpQty.Text = "";
			this.tbOpQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbOpQty.TextMode = false;
			this.tbOpQty.Zero = System.Drawing.Color.Empty;
			// 
			// panel8
			// 
			this.panel8.Controls.Add(this.cbShowAllOperations);
			this.panel8.Controls.Add(this.bnPrint);
			this.panel8.Controls.Add(this.bnUpdOper);
			this.panel8.Controls.Add(this.label5);
			this.panel8.Controls.Add(this.ucMovementPeriod);
			this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel8.Location = new System.Drawing.Point(0, 0);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(752, 28);
			this.panel8.TabIndex = 0;
			// 
			// cbShowAllOperations
			// 
			this.cbShowAllOperations.Checked = true;
			this.cbShowAllOperations.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbShowAllOperations.Location = new System.Drawing.Point(371, 5);
			this.cbShowAllOperations.Name = "cbShowAllOperations";
			this.cbShowAllOperations.Size = new System.Drawing.Size(212, 17);
			this.cbShowAllOperations.TabIndex = 4;
			this.cbShowAllOperations.Text = "Показать незавершённые операции";
			this.cbShowAllOperations.CheckedChanged += new System.EventHandler(this.cbShowAllOperations_CheckedChanged);
			// 
			// bnPrint
			// 
			this.bnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.bnPrint.Image = ((System.Drawing.Image)(resources.GetObject("bnPrint.Image")));
			this.bnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bnPrint.Location = new System.Drawing.Point(668, 2);
			this.bnPrint.Name = "bnPrint";
			this.bnPrint.Size = new System.Drawing.Size(82, 23);
			this.bnPrint.TabIndex = 3;
			this.bnPrint.Text = "Печать";
			this.bnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.bnPrint.Click += new System.EventHandler(this.bnPrint_Click);
			// 
			// bnUpdOper
			// 
			this.bnUpdOper.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.bnUpdOper.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bnUpdOper.ImageIndex = 0;
			this.bnUpdOper.ImageList = this.imageList2;
			this.bnUpdOper.Location = new System.Drawing.Point(584, 2);
			this.bnUpdOper.Name = "bnUpdOper";
			this.bnUpdOper.Size = new System.Drawing.Size(82, 23);
			this.bnUpdOper.TabIndex = 2;
			this.bnUpdOper.Text = "Обновить";
			this.bnUpdOper.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.bnUpdOper.Click += new System.EventHandler(this.bnUpdOper_Click);
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label5.Location = new System.Drawing.Point(6, 5);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(124, 15);
			this.label5.TabIndex = 1;
			this.label5.Text = "Движение по счёту:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ucMovementPeriod
			// 
			this.ucMovementPeriod._cbDateFrom = true;
			this.ucMovementPeriod._cbDateFromUse = false;
			this.ucMovementPeriod._cbDateTill = true;
			this.ucMovementPeriod._cbDateTillUse = false;
			this.ucMovementPeriod._DateFrom = new System.DateTime(2003, 12, 11, 0, 0, 0, 0);
			this.ucMovementPeriod._DateTill = new System.DateTime(2003, 12, 18, 0, 0, 0, 0);
			this.ucMovementPeriod._PeriodType = AM_Controls.Span.OneWeekAgo;
			this.ucMovementPeriod.Location = new System.Drawing.Point(131, 2);
			this.ucMovementPeriod.Modified = true;
			this.ucMovementPeriod.Name = "ucMovementPeriod";
			this.ucMovementPeriod.Size = new System.Drawing.Size(238, 22);
			this.ucMovementPeriod.TabIndex = 0;
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = ((string)(configurationAppSettings.GetValue("ConnectionString", typeof(string))));
			// 
			// daSelAllAccounts
			// 
			this.daSelAllAccounts.SelectCommand = this.sqlSelectCommand1;
			this.daSelAllAccounts.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									   new System.Data.Common.DataTableMapping("Table", "SelectAllAccounts", new System.Data.Common.DataColumnMapping[] {
																																																							new System.Data.Common.DataColumnMapping("ClientID", "ClientID"),
																																																							new System.Data.Common.DataColumnMapping("Saldo", "Saldo"),
																																																							new System.Data.Common.DataColumnMapping("SumSent", "SumSent"),
																																																							new System.Data.Common.DataColumnMapping("SumReserved", "SumReserved"),
																																																							new System.Data.Common.DataColumnMapping("SumWaited", "SumWaited"),
																																																							new System.Data.Common.DataColumnMapping("IsDebit", "IsDebit"),
																																																							new System.Data.Common.DataColumnMapping("CurrencyID", "CurrencyID"),
																																																							new System.Data.Common.DataColumnMapping("IsInner", "IsInner"),
																																																							new System.Data.Common.DataColumnMapping("AccountID", "AccountID"),
																																																							new System.Data.Common.DataColumnMapping("RAccount", "RAccount"),
																																																							new System.Data.Common.DataColumnMapping("OrgName", "OrgName"),
																																																							new System.Data.Common.DataColumnMapping("CodeINN", "CodeINN"),
																																																							new System.Data.Common.DataColumnMapping("ClientGroupID", "ClientGroupID"),
																																																							new System.Data.Common.DataColumnMapping("ClientName", "ClientName"),
																																																							new System.Data.Common.DataColumnMapping("ClientsIsInner", "ClientsIsInner"),
																																																							new System.Data.Common.DataColumnMapping("IsSpecial", "IsSpecial"),
																																																							new System.Data.Common.DataColumnMapping("TypeName", "TypeName"),
																																																							new System.Data.Common.DataColumnMapping("ForInnerOnly", "ForInnerOnly"),
																																																							new System.Data.Common.DataColumnMapping("AccountTypeID", "AccountTypeID"),
																																																							new System.Data.Common.DataColumnMapping("OrgID", "OrgID"),
																																																							new System.Data.Common.DataColumnMapping("OrgsIsSpecial", "OrgsIsSpecial"),
																																																							new System.Data.Common.DataColumnMapping("ClientGroupName", "ClientGroupName"),
																																																							new System.Data.Common.DataColumnMapping("BankID", "BankID"),
																																																							new System.Data.Common.DataColumnMapping("BankName", "BankName"),
																																																							new System.Data.Common.DataColumnMapping("CityID", "CityID"),
																																																							new System.Data.Common.DataColumnMapping("CityName", "CityName"),
																																																							new System.Data.Common.DataColumnMapping("CodeBIK", "CodeBIK"),
																																																							new System.Data.Common.DataColumnMapping("KAccount", "KAccount"),
																																																							new System.Data.Common.DataColumnMapping("CurrencyRate", "CurrencyRate"),
																																																							new System.Data.Common.DataColumnMapping("IsBase", "IsBase"),
																																																							new System.Data.Common.DataColumnMapping("IsNormal", "IsNormal")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "[SelectAllAccounts]";
			this.sqlSelectCommand1.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsRemoved", System.Data.SqlDbType.Bit, 1));
			// 
			// daSelectAccountsOperations
			// 
			this.daSelectAccountsOperations.SelectCommand = this.sqlSelectCommand2;
			this.daSelectAccountsOperations.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																												 new System.Data.Common.DataTableMapping("Table", "SelectAccountsOperations", new System.Data.Common.DataColumnMapping[] {
																																																											 new System.Data.Common.DataColumnMapping("InitDate", "InitDate"),
																																																											 new System.Data.Common.DataColumnMapping("CompleteDate", "CompleteDate"),
																																																											 new System.Data.Common.DataColumnMapping("OperationID", "OperationID"),
																																																											 new System.Data.Common.DataColumnMapping("TransactionOperationID", "TransactionOperationID"),
																																																											 new System.Data.Common.DataColumnMapping("OperationIsPrimary", "OperationIsPrimary"),
																																																											 new System.Data.Common.DataColumnMapping("OperationSum", "OperationSum"),
																																																											 new System.Data.Common.DataColumnMapping("OperationDir", "OperationDir"),
																																																											 new System.Data.Common.DataColumnMapping("AccountID", "AccountID"),
																																																											 new System.Data.Common.DataColumnMapping("TransactionTypeName", "TransactionTypeName"),
																																																											 new System.Data.Common.DataColumnMapping("PostedDate", "PostedDate"),
																																																											 new System.Data.Common.DataColumnMapping("CommitedDate", "CommitedDate"),
																																																											 new System.Data.Common.DataColumnMapping("OperationTypeID", "OperationTypeID"),
																																																											 new System.Data.Common.DataColumnMapping("PaymentNo", "PaymentNo"),
																																																											 new System.Data.Common.DataColumnMapping("PaymentOrderDate", "PaymentOrderDate"),
																																																											 new System.Data.Common.DataColumnMapping("PaymentsOrdersDirection", "PaymentsOrdersDirection"),
																																																											 new System.Data.Common.DataColumnMapping("OrgName", "OrgName"),
																																																											 new System.Data.Common.DataColumnMapping("OrgNameCorr", "OrgNameCorr"),
																																																											 new System.Data.Common.DataColumnMapping("OrgID", "OrgID"),
																																																											 new System.Data.Common.DataColumnMapping("OrgIDCorr", "OrgIDCorr"),
																																																											 new System.Data.Common.DataColumnMapping("AccountTypeID", "AccountTypeID"),
																																																											 new System.Data.Common.DataColumnMapping("ClientGroupID", "ClientGroupID"),
																																																											 new System.Data.Common.DataColumnMapping("ClientName", "ClientName"),
																																																											 new System.Data.Common.DataColumnMapping("ClientGroupName", "ClientGroupName"),
																																																											 new System.Data.Common.DataColumnMapping("CurrencyID", "CurrencyID"),
																																																											 new System.Data.Common.DataColumnMapping("RAccount", "RAccount"),
																																																											 new System.Data.Common.DataColumnMapping("PaymentOrderPurpose", "PaymentOrderPurpose")}),
																												 new System.Data.Common.DataTableMapping("Table1", "Table1", new System.Data.Common.DataColumnMapping[] {
																																																							new System.Data.Common.DataColumnMapping("InitDate", "InitDate"),
																																																							new System.Data.Common.DataColumnMapping("CompleteDate", "CompleteDate"),
																																																							new System.Data.Common.DataColumnMapping("OperationID", "OperationID"),
																																																							new System.Data.Common.DataColumnMapping("TransactionOperationID", "TransactionOperationID"),
																																																							new System.Data.Common.DataColumnMapping("OperationIsPrimary", "OperationIsPrimary"),
																																																							new System.Data.Common.DataColumnMapping("OperationSum", "OperationSum"),
																																																							new System.Data.Common.DataColumnMapping("OperationDir", "OperationDir"),
																																																							new System.Data.Common.DataColumnMapping("AccountID", "AccountID"),
																																																							new System.Data.Common.DataColumnMapping("TransactionTypeName", "TransactionTypeName"),
																																																							new System.Data.Common.DataColumnMapping("PostedDate", "PostedDate"),
																																																							new System.Data.Common.DataColumnMapping("CommitedDate", "CommitedDate"),
																																																							new System.Data.Common.DataColumnMapping("OperationTypeID", "OperationTypeID"),
																																																							new System.Data.Common.DataColumnMapping("PaymentNo", "PaymentNo"),
																																																							new System.Data.Common.DataColumnMapping("PaymentOrderDate", "PaymentOrderDate"),
																																																							new System.Data.Common.DataColumnMapping("PaymentsOrdersDirection", "PaymentsOrdersDirection"),
																																																							new System.Data.Common.DataColumnMapping("OrgName", "OrgName"),
																																																							new System.Data.Common.DataColumnMapping("OrgNameCorr", "OrgNameCorr"),
																																																							new System.Data.Common.DataColumnMapping("OrgID", "OrgID"),
																																																							new System.Data.Common.DataColumnMapping("OrgIDCorr", "OrgIDCorr"),
																																																							new System.Data.Common.DataColumnMapping("AccountTypeID", "AccountTypeID"),
																																																							new System.Data.Common.DataColumnMapping("ClientID", "ClientID"),
																																																							new System.Data.Common.DataColumnMapping("ClientGroupID", "ClientGroupID"),
																																																							new System.Data.Common.DataColumnMapping("ClientName", "ClientName"),
																																																							new System.Data.Common.DataColumnMapping("ClientGroupName", "ClientGroupName"),
																																																							new System.Data.Common.DataColumnMapping("CurrencyID", "CurrencyID"),
																																																							new System.Data.Common.DataColumnMapping("RAccount", "RAccount")}),
																												 new System.Data.Common.DataTableMapping("Table2", "Table2", new System.Data.Common.DataColumnMapping[] {
																																																							new System.Data.Common.DataColumnMapping("InitDate", "InitDate"),
																																																							new System.Data.Common.DataColumnMapping("CompleteDate", "CompleteDate"),
																																																							new System.Data.Common.DataColumnMapping("OperationID", "OperationID"),
																																																							new System.Data.Common.DataColumnMapping("TransactionOperationID", "TransactionOperationID"),
																																																							new System.Data.Common.DataColumnMapping("OperationIsPrimary", "OperationIsPrimary"),
																																																							new System.Data.Common.DataColumnMapping("OperationSum", "OperationSum"),
																																																							new System.Data.Common.DataColumnMapping("OperationDir", "OperationDir"),
																																																							new System.Data.Common.DataColumnMapping("AccountID", "AccountID"),
																																																							new System.Data.Common.DataColumnMapping("TransactionTypeName", "TransactionTypeName"),
																																																							new System.Data.Common.DataColumnMapping("PostedDate", "PostedDate"),
																																																							new System.Data.Common.DataColumnMapping("CommitedDate", "CommitedDate"),
																																																							new System.Data.Common.DataColumnMapping("OperationTypeID", "OperationTypeID"),
																																																							new System.Data.Common.DataColumnMapping("PaymentNo", "PaymentNo"),
																																																							new System.Data.Common.DataColumnMapping("PaymentOrderDate", "PaymentOrderDate"),
																																																							new System.Data.Common.DataColumnMapping("PaymentsOrdersDirection", "PaymentsOrdersDirection"),
																																																							new System.Data.Common.DataColumnMapping("OrgName", "OrgName"),
																																																							new System.Data.Common.DataColumnMapping("OrgNameCorr", "OrgNameCorr"),
																																																							new System.Data.Common.DataColumnMapping("OrgID", "OrgID"),
																																																							new System.Data.Common.DataColumnMapping("OrgIDCorr", "OrgIDCorr"),
																																																							new System.Data.Common.DataColumnMapping("AccountTypeID", "AccountTypeID"),
																																																							new System.Data.Common.DataColumnMapping("ClientID", "ClientID"),
																																																							new System.Data.Common.DataColumnMapping("ClientGroupID", "ClientGroupID"),
																																																							new System.Data.Common.DataColumnMapping("ClientName", "ClientName"),
																																																							new System.Data.Common.DataColumnMapping("ClientGroupName", "ClientGroupName"),
																																																							new System.Data.Common.DataColumnMapping("CurrencyID", "CurrencyID"),
																																																							new System.Data.Common.DataColumnMapping("RAccount", "RAccount")}),
																												 new System.Data.Common.DataTableMapping("Table3", "Table3", new System.Data.Common.DataColumnMapping[] {
																																																							new System.Data.Common.DataColumnMapping("InitDate", "InitDate"),
																																																							new System.Data.Common.DataColumnMapping("CompleteDate", "CompleteDate"),
																																																							new System.Data.Common.DataColumnMapping("OperationID", "OperationID"),
																																																							new System.Data.Common.DataColumnMapping("TransactionOperationID", "TransactionOperationID"),
																																																							new System.Data.Common.DataColumnMapping("OperationIsPrimary", "OperationIsPrimary"),
																																																							new System.Data.Common.DataColumnMapping("OperationSum", "OperationSum"),
																																																							new System.Data.Common.DataColumnMapping("OperationDir", "OperationDir"),
																																																							new System.Data.Common.DataColumnMapping("AccountID", "AccountID"),
																																																							new System.Data.Common.DataColumnMapping("TransactionTypeName", "TransactionTypeName"),
																																																							new System.Data.Common.DataColumnMapping("PostedDate", "PostedDate"),
																																																							new System.Data.Common.DataColumnMapping("CommitedDate", "CommitedDate"),
																																																							new System.Data.Common.DataColumnMapping("OperationTypeID", "OperationTypeID"),
																																																							new System.Data.Common.DataColumnMapping("PaymentNo", "PaymentNo"),
																																																							new System.Data.Common.DataColumnMapping("PaymentOrderDate", "PaymentOrderDate"),
																																																							new System.Data.Common.DataColumnMapping("PaymentsOrdersDirection", "PaymentsOrdersDirection"),
																																																							new System.Data.Common.DataColumnMapping("OrgName", "OrgName"),
																																																							new System.Data.Common.DataColumnMapping("OrgNameCorr", "OrgNameCorr"),
																																																							new System.Data.Common.DataColumnMapping("OrgID", "OrgID"),
																																																							new System.Data.Common.DataColumnMapping("OrgIDCorr", "OrgIDCorr"),
																																																							new System.Data.Common.DataColumnMapping("AccountTypeID", "AccountTypeID"),
																																																							new System.Data.Common.DataColumnMapping("ClientID", "ClientID"),
																																																							new System.Data.Common.DataColumnMapping("ClientGroupID", "ClientGroupID"),
																																																							new System.Data.Common.DataColumnMapping("ClientName", "ClientName"),
																																																							new System.Data.Common.DataColumnMapping("ClientGroupName", "ClientGroupName"),
																																																							new System.Data.Common.DataColumnMapping("CurrencyID", "CurrencyID"),
																																																							new System.Data.Common.DataColumnMapping("RAccount", "RAccount")}),
																												 new System.Data.Common.DataTableMapping("Table4", "Table4", new System.Data.Common.DataColumnMapping[] {
																																																							new System.Data.Common.DataColumnMapping("InitDate", "InitDate"),
																																																							new System.Data.Common.DataColumnMapping("CompleteDate", "CompleteDate"),
																																																							new System.Data.Common.DataColumnMapping("OperationID", "OperationID"),
																																																							new System.Data.Common.DataColumnMapping("TransactionOperationID", "TransactionOperationID"),
																																																							new System.Data.Common.DataColumnMapping("OperationIsPrimary", "OperationIsPrimary"),
																																																							new System.Data.Common.DataColumnMapping("OperationSum", "OperationSum"),
																																																							new System.Data.Common.DataColumnMapping("OperationDir", "OperationDir"),
																																																							new System.Data.Common.DataColumnMapping("AccountID", "AccountID"),
																																																							new System.Data.Common.DataColumnMapping("TransactionTypeName", "TransactionTypeName"),
																																																							new System.Data.Common.DataColumnMapping("PostedDate", "PostedDate"),
																																																							new System.Data.Common.DataColumnMapping("CommitedDate", "CommitedDate"),
																																																							new System.Data.Common.DataColumnMapping("OperationTypeID", "OperationTypeID"),
																																																							new System.Data.Common.DataColumnMapping("PaymentNo", "PaymentNo"),
																																																							new System.Data.Common.DataColumnMapping("PaymentOrderDate", "PaymentOrderDate"),
																																																							new System.Data.Common.DataColumnMapping("PaymentsOrdersDirection", "PaymentsOrdersDirection"),
																																																							new System.Data.Common.DataColumnMapping("OrgName", "OrgName"),
																																																							new System.Data.Common.DataColumnMapping("OrgNameCorr", "OrgNameCorr"),
																																																							new System.Data.Common.DataColumnMapping("OrgID", "OrgID"),
																																																							new System.Data.Common.DataColumnMapping("OrgIDCorr", "OrgIDCorr"),
																																																							new System.Data.Common.DataColumnMapping("AccountTypeID", "AccountTypeID"),
																																																							new System.Data.Common.DataColumnMapping("ClientGroupID", "ClientGroupID"),
																																																							new System.Data.Common.DataColumnMapping("ClientName", "ClientName"),
																																																							new System.Data.Common.DataColumnMapping("ClientGroupName", "ClientGroupName"),
																																																							new System.Data.Common.DataColumnMapping("CurrencyID", "CurrencyID"),
																																																							new System.Data.Common.DataColumnMapping("RAccount", "RAccount")}),
																												 new System.Data.Common.DataTableMapping("Table5", "Table5", new System.Data.Common.DataColumnMapping[] {
																																																							new System.Data.Common.DataColumnMapping("InitDate", "InitDate"),
																																																							new System.Data.Common.DataColumnMapping("CompleteDate", "CompleteDate"),
																																																							new System.Data.Common.DataColumnMapping("OperationID", "OperationID"),
																																																							new System.Data.Common.DataColumnMapping("TransactionOperationID", "TransactionOperationID"),
																																																							new System.Data.Common.DataColumnMapping("OperationIsPrimary", "OperationIsPrimary"),
																																																							new System.Data.Common.DataColumnMapping("OperationSum", "OperationSum"),
																																																							new System.Data.Common.DataColumnMapping("OperationDir", "OperationDir"),
																																																							new System.Data.Common.DataColumnMapping("AccountID", "AccountID"),
																																																							new System.Data.Common.DataColumnMapping("TransactionTypeName", "TransactionTypeName"),
																																																							new System.Data.Common.DataColumnMapping("PostedDate", "PostedDate"),
																																																							new System.Data.Common.DataColumnMapping("CommitedDate", "CommitedDate"),
																																																							new System.Data.Common.DataColumnMapping("OperationTypeID", "OperationTypeID"),
																																																							new System.Data.Common.DataColumnMapping("PaymentNo", "PaymentNo"),
																																																							new System.Data.Common.DataColumnMapping("PaymentOrderDate", "PaymentOrderDate"),
																																																							new System.Data.Common.DataColumnMapping("PaymentsOrdersDirection", "PaymentsOrdersDirection"),
																																																							new System.Data.Common.DataColumnMapping("OrgName", "OrgName"),
																																																							new System.Data.Common.DataColumnMapping("OrgNameCorr", "OrgNameCorr"),
																																																							new System.Data.Common.DataColumnMapping("OrgID", "OrgID"),
																																																							new System.Data.Common.DataColumnMapping("OrgIDCorr", "OrgIDCorr"),
																																																							new System.Data.Common.DataColumnMapping("AccountTypeID", "AccountTypeID"),
																																																							new System.Data.Common.DataColumnMapping("ClientID", "ClientID"),
																																																							new System.Data.Common.DataColumnMapping("ClientGroupID", "ClientGroupID"),
																																																							new System.Data.Common.DataColumnMapping("ClientName", "ClientName"),
																																																							new System.Data.Common.DataColumnMapping("ClientGroupName", "ClientGroupName"),
																																																							new System.Data.Common.DataColumnMapping("CurrencyID", "CurrencyID"),
																																																							new System.Data.Common.DataColumnMapping("RAccount", "RAccount")}),
																												 new System.Data.Common.DataTableMapping("Table6", "Table6", new System.Data.Common.DataColumnMapping[] {
																																																							new System.Data.Common.DataColumnMapping("InitDate", "InitDate"),
																																																							new System.Data.Common.DataColumnMapping("CompleteDate", "CompleteDate"),
																																																							new System.Data.Common.DataColumnMapping("OperationID", "OperationID"),
																																																							new System.Data.Common.DataColumnMapping("TransactionOperationID", "TransactionOperationID"),
																																																							new System.Data.Common.DataColumnMapping("OperationIsPrimary", "OperationIsPrimary"),
																																																							new System.Data.Common.DataColumnMapping("OperationSum", "OperationSum"),
																																																							new System.Data.Common.DataColumnMapping("OperationDir", "OperationDir"),
																																																							new System.Data.Common.DataColumnMapping("AccountID", "AccountID"),
																																																							new System.Data.Common.DataColumnMapping("TransactionTypeName", "TransactionTypeName"),
																																																							new System.Data.Common.DataColumnMapping("PostedDate", "PostedDate"),
																																																							new System.Data.Common.DataColumnMapping("CommitedDate", "CommitedDate"),
																																																							new System.Data.Common.DataColumnMapping("OperationTypeID", "OperationTypeID"),
																																																							new System.Data.Common.DataColumnMapping("PaymentNo", "PaymentNo"),
																																																							new System.Data.Common.DataColumnMapping("PaymentOrderDate", "PaymentOrderDate"),
																																																							new System.Data.Common.DataColumnMapping("PaymentsOrdersDirection", "PaymentsOrdersDirection"),
																																																							new System.Data.Common.DataColumnMapping("OrgName", "OrgName"),
																																																							new System.Data.Common.DataColumnMapping("OrgNameCorr", "OrgNameCorr"),
																																																							new System.Data.Common.DataColumnMapping("OrgID", "OrgID"),
																																																							new System.Data.Common.DataColumnMapping("OrgIDCorr", "OrgIDCorr"),
																																																							new System.Data.Common.DataColumnMapping("AccountTypeID", "AccountTypeID"),
																																																							new System.Data.Common.DataColumnMapping("ClientGroupID", "ClientGroupID"),
																																																							new System.Data.Common.DataColumnMapping("ClientName", "ClientName"),
																																																							new System.Data.Common.DataColumnMapping("ClientGroupName", "ClientGroupName"),
																																																							new System.Data.Common.DataColumnMapping("CurrencyID", "CurrencyID"),
																																																							new System.Data.Common.DataColumnMapping("RAccount", "RAccount")})});
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "[SelectAccountsOperations]";
			this.sqlSelectCommand2.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectCommand2.Connection = this.sqlConnection2;
			this.sqlSelectCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DateFrom", System.Data.SqlDbType.DateTime, 8));
			this.sqlSelectCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DateTo", System.Data.SqlDbType.DateTime, 8));
			this.sqlSelectCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ClientGroupID", System.Data.SqlDbType.Int, 4));
			this.sqlSelectCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AccountID", System.Data.SqlDbType.Int, 4));
			this.sqlSelectCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Mode", System.Data.SqlDbType.Bit, 1));
			// 
			// sqlConnection2
			// 
			this.sqlConnection2.ConnectionString = ((string)(configurationAppSettings.GetValue("ConnectionString", typeof(string))));
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.mnuRefresh});
			this.menuItem1.Text = "Редактировать";
			// 
			// mnuRefresh
			// 
			this.mnuRefresh.Index = 0;
			this.mnuRefresh.Shortcut = System.Windows.Forms.Shortcut.F5;
			this.mnuRefresh.Text = "Обновить";
			this.mnuRefresh.Click += new System.EventHandler(this.mnuRefresh_Click);
			// 
			// sqlCmdGetSaldo
			// 
			this.sqlCmdGetSaldo.CommandText = "dbo.[GetSaldo]";
			this.sqlCmdGetSaldo.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCmdGetSaldo.Connection = this.sqlConnection1;
			this.sqlCmdGetSaldo.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdGetSaldo.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DateTo", System.Data.SqlDbType.DateTime, 8));
			this.sqlCmdGetSaldo.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AccountID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdGetSaldo.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Mode", System.Data.SqlDbType.Bit, 1));
			// 
			// tbbUpdt
			// 
			this.tbbUpdt.ImageIndex = 0;
			this.tbbUpdt.Text = "Обновить";
			// 
			// toolBar1
			// 
			this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.tbbUpdt});
			this.toolBar1.ButtonSize = new System.Drawing.Size(90, 22);
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.toolBar1.ImageList = this.imageList2;
			this.toolBar1.Location = new System.Drawing.Point(0, 0);
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(1028, 28);
			this.toolBar1.TabIndex = 0;
			this.toolBar1.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right;
			this.toolBar1.Visible = false;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			// 
			// daCreditsClientsList
			// 
			this.daCreditsClientsList.SelectCommand = this.sqlSelectCommand3;
			this.daCreditsClientsList.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										   new System.Data.Common.DataTableMapping("Table", "Clients", new System.Data.Common.DataColumnMapping[] {
																																																					  new System.Data.Common.DataColumnMapping("ClientID", "ClientID"),
																																																					  new System.Data.Common.DataColumnMapping("ClientGroupID", "ClientGroupID"),
																																																					  new System.Data.Common.DataColumnMapping("ClientName", "ClientName"),
																																																					  new System.Data.Common.DataColumnMapping("ClientRemarks", "ClientRemarks"),
																																																					  new System.Data.Common.DataColumnMapping("IsInner", "IsInner"),
																																																					  new System.Data.Common.DataColumnMapping("IsSpecial", "IsSpecial"),
																																																					  new System.Data.Common.DataColumnMapping("Password", "Password")})});
			// 
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = @"SELECT DISTINCT Clients.ClientID, Clients.ClientGroupID, Clients.ClientName, Clients.ClientRemarks, Clients.IsInner, Clients.IsSpecial, Clients.Password FROM Clients INNER JOIN Credits ON Clients.ClientID = Credits.ClientID WHERE (Credits.IsGranted = @CreditDirection) ORDER BY Clients.ClientName";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			this.sqlSelectCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CreditDirection", System.Data.SqlDbType.Bit, 1, "IsGranted"));
			// 
			// sqlConnection3
			// 
			this.sqlConnection3.ConnectionString = ((string)(configurationAppSettings.GetValue("ConnectionString", typeof(string))));
			// 
			// dsClientsInCredits
			// 
			this.dsClientsInCredits.DataSetName = "dsClients";
			this.dsClientsInCredits.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// dsClientsOutCredits
			// 
			this.dsClientsOutCredits.DataSetName = "dsClients";
			this.dsClientsOutCredits.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// sqlSelectCommand4
			// 
			this.sqlSelectCommand4.CommandText = @"SELECT DISTINCT Transactions.ClientID, Clients.ClientName, Clients.ClientRemarks, Clients.IsInner, Clients.IsSpecial, Clients.Password, Clients.ClientGroupID FROM Clients RIGHT OUTER JOIN Transactions ON Clients.ClientID = Transactions.ClientID WHERE (Transactions.TransactionTypeID = 17) ORDER BY Clients.ClientName";
			this.sqlSelectCommand4.Connection = this.sqlConnection1;
			// 
			// daGrantsClientsList
			// 
			this.daGrantsClientsList.SelectCommand = this.sqlSelectCommand4;
			this.daGrantsClientsList.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										  new System.Data.Common.DataTableMapping("Table", "Transactions", new System.Data.Common.DataColumnMapping[] {
																																																						  new System.Data.Common.DataColumnMapping("TransactionID", "TransactionID"),
																																																						  new System.Data.Common.DataColumnMapping("TransactionTypeID", "TransactionTypeID"),
																																																						  new System.Data.Common.DataColumnMapping("TransactionCommited", "TransactionCommited"),
																																																						  new System.Data.Common.DataColumnMapping("TransactionPosted", "TransactionPosted"),
																																																						  new System.Data.Common.DataColumnMapping("ClientID", "ClientID"),
																																																						  new System.Data.Common.DataColumnMapping("SumFrom", "SumFrom"),
																																																						  new System.Data.Common.DataColumnMapping("SumTo", "SumTo"),
																																																						  new System.Data.Common.DataColumnMapping("CurrencyRate", "CurrencyRate"),
																																																						  new System.Data.Common.DataColumnMapping("AccountIDFrom", "AccountIDFrom"),
																																																						  new System.Data.Common.DataColumnMapping("AccountIDTo", "AccountIDTo"),
																																																						  new System.Data.Common.DataColumnMapping("ServiceCharge", "ServiceCharge"),
																																																						  new System.Data.Common.DataColumnMapping("DocumentID", "DocumentID"),
																																																						  new System.Data.Common.DataColumnMapping("CreateDate", "CreateDate"),
																																																						  new System.Data.Common.DataColumnMapping("PostedDate", "PostedDate"),
																																																						  new System.Data.Common.DataColumnMapping("CommitedDate", "CommitedDate"),
																																																						  new System.Data.Common.DataColumnMapping("TransactionIDParent", "TransactionIDParent"),
																																																						  new System.Data.Common.DataColumnMapping("ClientRequestID", "ClientRequestID"),
																																																						  new System.Data.Common.DataColumnMapping("Purpose", "Purpose"),
																																																						  new System.Data.Common.DataColumnMapping("Remarks", "Remarks")})});
			// 
			// dsClientsGrants
			// 
			this.dsClientsGrants.DataSetName = "dsClients";
			this.dsClientsGrants.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// AllAccounts
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(1028, 643);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.toolBar1);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Menu = this.mainMenu1;
			this.Name = "AllAccounts";
			this.Text = "Все счета";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.panel2.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel6.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridV2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvAllAccounts)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsAllAccounts1)).EndInit();
			this.panel11.ResumeLayout(false);
			this.panel10.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridV1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvAccOper)).EndInit();
			this.panel9.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dsClientsInCredits)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsClientsOutCredits)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsClientsGrants)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		
		private void fillDsAllAccounts()
		{
			try
			{
				this.dsAllAccounts1.SelectAllAccounts.Clear();
				this.daSelAllAccounts.SelectCommand.Parameters["@IsRemoved"].Value = this.cbOrgsRemoved.Checked;
				this.daSelAllAccounts.Fill(this.dsAllAccounts1.SelectAllAccounts);
			}
			catch(Exception ex)
			{
				AM_Controls.MsgBoxX.Show(ex.Message);
			}
		}
		
		private void fillDsAccOper(int AccountID, int Mode)
		{
			this.Cursor = Cursors.WaitCursor;
			System.DateTime dtFrom = this.ucMovementPeriod._DateFrom;
			dtFrom =dtFrom.AddHours		( -dtFrom.Hour	);
			dtFrom =dtFrom.AddMinutes	( -dtFrom.Minute);
			dtFrom =dtFrom.AddSeconds	( -dtFrom.Second);

			System.DateTime dtTill = this.ucMovementPeriod._DateTill;
			dtTill =dtTill.AddHours		( -dtTill.Hour	);
			dtTill =dtTill.AddMinutes	( -dtTill.Minute);
			dtTill =dtTill.AddSeconds	( -dtTill.Second);
			dtTill =dtTill.AddDays		(  1);
			dtTill =dtTill.AddSeconds	( -1);

			try
			{
				this.dsAllAccounts1.SelectAccountsOperations.Clear();
				this.daSelectAccountsOperations.SelectCommand.Parameters["@DateFrom"].Value = dtFrom;
				this.daSelectAccountsOperations.SelectCommand.Parameters["@DateTo"].Value	= dtTill;
				this.daSelectAccountsOperations.SelectCommand.Parameters["@AccountID"].Value	= AccountID;
				this.daSelectAccountsOperations.SelectCommand.Parameters["@Mode"].Value	= Mode;
				this.daSelectAccountsOperations.Fill(this.dsAllAccounts1.SelectAccountsOperations);
		
				tbOpQty.nValue = this.dvAccOper.Count;
				if(this.dataGridV1.CurrentRowIndex != 0)
				{
					this.dataGridV1.CurrentRowIndex = 0; 
				}
				//this.dvAccOper.Sort="FinishDate,OperationDir DESC,TransactionOperationID";
			}
			catch(Exception ex)
			{
				AM_Controls.MsgBoxX.Show(ex.Message);
			}
			this.Cursor = Cursors.Default;
		}
		
		private void CreditsClientsListFill()
		{
			try
			{
				this.dsClientsInCredits.Clear();
				this.daCreditsClientsList.SelectCommand.Parameters["@CreditDirection"].Value =0;
				this.daCreditsClientsList.Fill(this.dsClientsInCredits.Clients);

				this.dsClientsOutCredits.Clear();
				this.daCreditsClientsList.SelectCommand.Parameters["@CreditDirection"].Value =1;
				this.daCreditsClientsList.Fill(this.dsClientsOutCredits.Clients);

				this.dsClientsGrants.Clear();
				this.daGrantsClientsList.Fill(this.dsClientsGrants.Clients);
			}
			catch(Exception ex)
			{
				MessageBox.Show("Ошибка формирования кредитодателей/кредитополучателей: " +ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Stop);
			}
		}

		private void fillTree()
		{
			int iGroupID	= 0;
			int iGroupCount =-1;
			
			DataView dv = new DataView();
			
			dv.Table		= App.DsClients.Clients;
			dv.Sort			= "ClientGroupName, ClientName";
			dv.RowFilter	= "IsInner = false AND IsSpecial = false";
			
			for(int i=0; i< dv.Count; i++)
			{
				BPS.BLL.Clients.DataSets.dsClients.ClientsRow rw = (BPS.BLL.Clients.DataSets.dsClients.ClientsRow) dv[i].Row;
				if(rw.ClientGroupID != iGroupID)
				{
					iGroupID = rw.ClientGroupID;
					TreeNode trGroup = new TreeNode(rw.ClientGroupName);
					trGroup.Tag = rw.ClientGroupID;
					trGroup.ImageIndex = 1;
					trGroup.SelectedImageIndex = 1;
					this.treeView1.Nodes[0].Nodes[1].Nodes[1].Nodes.Add(trGroup);
					iGroupCount++;
				}
				TreeNode trClient = new TreeNode(rw.ClientName);
				trClient.Tag = rw.ClientID;
				trClient.ImageIndex = 0;
				trClient.SelectedImageIndex = 0;
				this.treeView1.Nodes[0].Nodes[1].Nodes[1].Nodes[iGroupCount].Nodes.Add(trClient);				
			}
			
			for ( int i =0; i <this.dsClientsOutCredits.Clients.Count; i++ ) 
			{
				BPS.BLL.Clients.DataSets.dsClients.ClientsRow rw =(BPS.BLL.Clients.DataSets.dsClients.ClientsRow)this.dsClientsOutCredits.Clients.Rows[i];
				TreeNode trClient = new TreeNode(rw.ClientName);
				trClient.Tag = rw.ClientID;
				trClient.ImageIndex = 0;
				trClient.SelectedImageIndex = 0;
				this.treeView1.Nodes[0].Nodes[0].Nodes[3].Nodes.Add(trClient);
			}

			for ( int i =0; i <this.dsClientsInCredits.Clients.Count; i++ ) 
			{
				BPS.BLL.Clients.DataSets.dsClients.ClientsRow rw =(BPS.BLL.Clients.DataSets.dsClients.ClientsRow)this.dsClientsInCredits.Clients.Rows[i];
				TreeNode trClient = new TreeNode(rw.ClientName);
				trClient.Tag = rw.ClientID;
				trClient.ImageIndex = 0;
				trClient.SelectedImageIndex = 0;
				this.treeView1.Nodes[0].Nodes[1].Nodes[2].Nodes.Add(trClient);
			}

			for(int counter = 0; counter < this.dsClientsGrants.Clients.Count; counter ++)
			{
				BPS.BLL.Clients.DataSets.dsClients.ClientsRow rw =(BPS.BLL.Clients.DataSets.dsClients.ClientsRow)this.dsClientsGrants.Clients.Rows[counter];
				TreeNode trClient = new TreeNode(rw.ClientName);
				trClient.Tag = rw.ClientID;
				trClient.ImageIndex = 0;
				trClient.SelectedImageIndex = 0;
				this.treeView1.Nodes[0].Nodes[0].Nodes[4].Nodes.Add(trClient);
			}

			dv.RowFilter = "IsSpecial = true";
			for(int i=0; i< dv.Count; i++)
			{
				BPS.BLL.Clients.DataSets.dsClients.ClientsRow rw = (BPS.BLL.Clients.DataSets.dsClients.ClientsRow) dv[i].Row;
				TreeNode trSpecClient = new TreeNode(rw.ClientName);
				trSpecClient.Tag = rw.ClientID;
				trSpecClient.ImageIndex = 0;
				trSpecClient.SelectedImageIndex = 0;
				this.treeView1.Nodes[0].Nodes[0].Nodes[2].Nodes.Add(trSpecClient);
			}
			
			// Кассовые счета
			for( int i =0; i <App.DsCurr.Currencies.Count; i++) 
			{
				string szCurrencyID =((BPS.BLL.Currency.DataSets.dsCurr.CurrenciesRow)App.DsCurr.Currencies.Rows[i]).CurrencyID;
				
				TreeNode trCurrency = new TreeNode(szCurrencyID);
				trCurrency.Tag					=szCurrencyID;
				trCurrency.ImageIndex			=0;
				trCurrency.SelectedImageIndex	=0;
				this.treeView1.Nodes[0].Nodes[0].Nodes[1].Nodes.Add(trCurrency);
			}

			// Свой лицевой счёт
			for( int i =0; i <App.DsCurr.Currencies.Count; i++) 
			{
				string szCurrencyID =((BPS.BLL.Currency.DataSets.dsCurr.CurrenciesRow)App.DsCurr.Currencies.Rows[i]).CurrencyID;
				
				TreeNode trCurrency = new TreeNode(szCurrencyID);
				trCurrency.Tag					=szCurrencyID;
				trCurrency.ImageIndex			=0;
				trCurrency.SelectedImageIndex	=0;
				this.treeView1.Nodes[0].Nodes[1].Nodes[0].Nodes.Add(trCurrency);
			}

			SetTreeRAccountDigits(3);
			this.treeView1.Nodes[0].Expand();
			this.treeView1.Nodes[0].Nodes[0].Expand();
			this.treeView1.Nodes[0].Nodes[1].Expand();
			this.treeView1.SelectedNode = this.treeView1.Nodes[0];
		}
		private void setStyleMap(StyleMapType smt)
		{
			switch(smt)
			{
				case StyleMapType.Clients:
					ClientGroupName.Width	=0;
					ClientName.Width		=120;
					OrgName.Width			=0;
					RAccount.Width			=0;
					BankName.Width			=0;
					CodeBIK.Width			=0;
					CityName.Width			=0;
					break;
				case StyleMapType.Orgs:
					ClientGroupName.Width	=0;
					ClientName.Width		=0;
					OrgName.Width			=120;
					RAccount.Width			=135;
					BankName.Width			=120;
					CodeBIK.Width			=120;
					CityName.Width			=120;
					break;
				case StyleMapType.Empty:
					ClientGroupName.Width	=0;
					ClientName.Width		=120;
					OrgName.Width			=120;
					RAccount.Width			=135;
					BankName.Width			=120;
					CodeBIK.Width			=120;
					CityName.Width			=120;
					break;
			}
		}

		private void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			this.updateTreeView();
		}
		
		private void updateTreeView()
		{
			if(this.treeView1.SelectedNode.Parent == null)		//Узел Баланс - Root
			{
				this.dvAllAccounts.RowFilter = "AccountTypeID=-1";
				this.setStyleMap(StyleMapType.Empty);
			}
			else if(this.treeView1.SelectedNode.Parent.Text == "Баланс") //L1
			{
				if(this.treeView1.SelectedNode.Index == 0)		//Узел Активы
				{	
					// Р/С Своих организаций	(IsInner =TRUE)
					// Кассовые Счета Свои		(ClientsIsInner =TRUE AND AccountTypeID =3)
					// Внешние Л/С				(IsSpecial =TRUE AND AccountTypeID =6)
					// Кредитные Л/С			(ClientsIsInner =FALSE AND AccountTypeID =14)
					//this.dvAllAccounts.RowFilter = "((ClientsIsInner=true) OR (IsInner=true) OR (IsSpecial=true AND AccountTypeID=6))";
					this.dvAllAccounts.RowFilter = "((ClientsIsInner =TRUE AND AccountTypeID =3) OR (IsInner =TRUE) OR (IsSpecial =TRUE AND AccountTypeID =6) OR (ClientsIsInner =FALSE AND AccountTypeID =14) OR (IsSpecial=FALSE AND AccountTypeID =13))";
					this.setStyleMap(StyleMapType.Empty);
				}
				else if(this.treeView1.SelectedNode.Index == 1)	//Узел Пассивы
				{
					this.dvAllAccounts.RowFilter = "(IsSpecial=false and (AccountTypeID=2 OR (ClientsIsInner =FALSE AND AccountTypeID =17)))" ;// ";
					this.setStyleMap(StyleMapType.Clients);
				}
			}
			else if(this.treeView1.SelectedNode.Parent.Text == "Активы") //L2
			{
				
				switch(this.treeView1.SelectedNode.Index)
				{
					case 0:
						this.dvAllAccounts.RowFilter = "IsInner=true  and AccountTypeID=1";
						this.setStyleMap(StyleMapType.Orgs);
						break;
					case 1:
						this.dvAllAccounts.RowFilter = "ClientsIsInner=true and IsSpecial=false and AccountTypeID=3 ";
						this.setStyleMap(StyleMapType.Clients);
						break;
					case 2:
						this.dvAllAccounts.RowFilter = "IsSpecial=true  and AccountTypeID=6";
						this.setStyleMap(StyleMapType.Clients);
						break;
					case 3:
						this.dvAllAccounts.RowFilter = "[ClientsIsInner] =false AND [IsSpecial] =false AND [AccountTypeID] =14";
						this.setStyleMap(StyleMapType.Clients);
						break;
					case 4:
						this.dvAllAccounts.RowFilter = "AccountTypeID=13 AND ClientsIsInner=false";
						this.setStyleMap(StyleMapType.Clients);
						break;
				}
			}
			else if(this.treeView1.SelectedNode.Parent.Text == "Расчётные счета")
			{
				switch(this.treeView1.SelectedNode.Index)
				{
					case 0:
						this.dvAllAccounts.RowFilter = "IsInner=true  and AccountTypeID=1 and IsNormal=true";
						this.setStyleMap(StyleMapType.Orgs);
						break;
					case 1:
						this.dvAllAccounts.RowFilter = "IsInner=true  and AccountTypeID=1 and IsNormal=false";
						this.setStyleMap(StyleMapType.Orgs);
						break;
				}
			}
			else if(this.treeView1.SelectedNode.Parent.Text == "Расчётные счета нормальные")
			{
				this.dvAllAccounts.RowFilter = "RAccount = '" + this.treeView1.SelectedNode.Tag + "'";
				this.setStyleMap(StyleMapType.Orgs);
			}
			else if(this.treeView1.SelectedNode.Parent.Text == "Расчётные счета специальные")
			{
				this.dvAllAccounts.RowFilter = "RAccount = '" + this.treeView1.SelectedNode.Tag + "'";
				this.setStyleMap(StyleMapType.Orgs);
			}
			else if(this.treeView1.SelectedNode.Parent.Text == "Внешние лицевые счета")
			{
				int ClientID = (int) this.treeView1.SelectedNode.Tag;
				this.dvAllAccounts.RowFilter = "AccountTypeID=6  and ClientID = " + ClientID.ToString();
				this.setStyleMap(StyleMapType.Clients);
			}
			else if(this.treeView1.SelectedNode.Parent.Text == "Пассивы")
			{
				if (this.treeView1.SelectedNode.Index == 0)
				{
					this.dvAllAccounts.RowFilter = "ClientsIsInner=true  and AccountTypeID=2";
				}
				else if (this.treeView1.SelectedNode.Index == 1)
				{
					this.dvAllAccounts.RowFilter = "ClientsIsInner=false  and (AccountTypeID=2 OR AccountTypeID=13)";
				}
				else 
				{
					this.dvAllAccounts.RowFilter = "ClientsIsInner=false  and (AccountTypeID=17)";
				}
				this.setStyleMap(StyleMapType.Clients);
			}
			else if(this.treeView1.SelectedNode.Parent.Text == "Счета клиентов")
			{
				int iGroupID =(int)this.treeView1.SelectedNode.Tag;
				this.dvAllAccounts.RowFilter = "ClientsIsInner=false and IsSpecial=false and (AccountTypeID=2 OR AccountTypeID=13)  and ClientGroupID=" + iGroupID.ToString();
				this.setStyleMap(StyleMapType.Clients);
			}
			else if(this.treeView1.SelectedNode.Parent.Text == "Кредиты Выданные") 
			{
				int ClientID = (int) this.treeView1.SelectedNode.Tag;
				this.dvAllAccounts.RowFilter = "ClientsIsInner=false and IsSpecial=false AND (AccountTypeID=14) AND ClientID=" + ClientID.ToString();
				this.setStyleMap(StyleMapType.Clients);
			}
			else if(this.treeView1.SelectedNode.Parent.Text == "Кредиты (Ссуды)")
			{
				this.dvAllAccounts.RowFilter = "ClientID = " + this.treeView1.SelectedNode.Tag + " AND AccountTypeID = 13";
				this.setStyleMap(StyleMapType.Clients);
			}
			else if(this.treeView1.SelectedNode.Parent.Text == "Кредиты Полученные") 
			{
				int ClientID = (int) this.treeView1.SelectedNode.Tag;
				this.dvAllAccounts.RowFilter = "ClientsIsInner=false and IsSpecial=false AND (AccountTypeID=17) AND ClientID=" + ClientID.ToString();
				this.setStyleMap(StyleMapType.Clients);
			}
			else if(this.treeView1.SelectedNode.Parent.Text == "Кассовые счета") 
			{
				string szCurrencyID = (string) this.treeView1.SelectedNode.Tag;
				this.dvAllAccounts.RowFilter = "ClientsIsInner=true and IsSpecial=false and AccountTypeID=3 AND CurrencyID='" + szCurrencyID +"'";
				this.setStyleMap(StyleMapType.Clients);
			}
			else if(this.treeView1.SelectedNode.Parent.Text == "Свой лицевой счет") 
			{
				string szCurrencyID = (string) this.treeView1.SelectedNode.Tag;
				this.dvAllAccounts.RowFilter = "ClientsIsInner=true  and AccountTypeID=2 AND CurrencyID='" + szCurrencyID +"'";
				this.setStyleMap(StyleMapType.Clients);
			}
			else
			{
				int ClientID = (int) this.treeView1.SelectedNode.Tag;
				this.dvAllAccounts.RowFilter = "ClientsIsInner=false and IsSpecial=false and (AccountTypeID=2 OR AccountTypeID=13)  and ClientID=" + ClientID.ToString();
				this.setStyleMap(StyleMapType.Clients);
			}
			
			if ( !this.cbShowZeroSaldo.Checked)
				this.dvAllAccounts.RowFilter += " and (Saldo>0.005 or Saldo<-0.005 or SumReserved>0.005 or SumReserved < -0.005 or SumWaited > 0.005 or SumWaited < -0.005)";
			
			this.dataGridV2.CurrentRowIndex =(this.dvAllAccounts.Count >0)? 0 :-1;
						
//			this.bnPrint.Enabled =false;
//			if (this.treeView1.SelectedNode.Parent != null) 
//			{
//				if (this.treeView1.SelectedNode.Parent.Text == "Счета клиентов" || this.treeView1.SelectedNode.Parent.Text == "Расчётные счета") //Selected Clients Group
//					this.bnPrint.Enabled =true;
//				else
//					if (this.treeView1.SelectedNode.Parent.Parent != null) //Selected Client
//					{
//						if (this.treeView1.SelectedNode.Parent.Parent.Text == "Счета клиентов")
//							this.bnPrint.Enabled =true;				
//					}
//			}
		}

		private void dvAllAccounts_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		{
			//if(this.dvAllAccounts.Count == 0)
			//	this.dvAccOper.RowFilter = "AccountID=0";
			double dSumSaldo	= 0;
			double dSumRes		= 0;
			double dSumWait		= 0;
			double dSumCredit	= 0;

			for(int i=0; i<this.dvAllAccounts.Count; i++)
			{
				BLL.Accounts.DataSets.dsAllAccounts.SelectAllAccountsRow rw = (BLL.Accounts.DataSets.dsAllAccounts.SelectAllAccountsRow) this.dvAllAccounts[i].Row;
				if ((rw.AccountTypeID == 13) && (this.treeView1.SelectedNode.Text != "Кредиты")) 
				{
					//continue;
					dSumCredit	+= rw.Saldo * rw.CurrencyRate;
				}
				else
					dSumSaldo	+= rw.Saldo			* rw.CurrencyRate;

				dSumRes		+= rw.SumReserved	*rw.CurrencyRate;
				dSumWait	+= rw.SumWaited		*rw.CurrencyRate;
			}
			this.tbSaldo.dValue		=Math.Round(dSumSaldo, 2);
			this.tbCredit.dValue	=Math.Round(dSumCredit, 2); 
			this.tbSaldoNetto.dValue=Math.Round(this.tbSaldo.dValue - this.tbCredit.dValue, 2);
			this.tbReserv.dValue	=Math.Round(dSumRes, 2);
			this.tbWait.dValue		=Math.Round(dSumWait, 2);
			this.tbFree.dValue		=Math.Round(this.tbSaldo.dValue - this.tbReserv.dValue, 2);
			this.tbFreeWait.dValue	=Math.Round(this.tbFree.dValue + this.tbWait.dValue, 2);
		}

		private void dvAccOper_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		{
			
		}

		private void treeView1_AfterExpand(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if (e.Node ==null) return;

			if(e.Action == TreeViewAction.Expand)
			{
				if(e.Node.Parent == null)
				{
					e.Node.ImageIndex = 2;
					e.Node.SelectedImageIndex = 2;
				}
				else if(
					(e.Node.Parent.Text == "Баланс")											 ||
					(e.Node.Parent.Text == "Счета клиентов")									 ||
					(e.Node.Parent.Text == "Пассивы" && (e.Node.Index == 0 || e.Node.Index == 1 || e.Node.Index == 2))||
					(e.Node.Parent.Text == "Активы" && (e.Node.Index == 2 || e.Node.Index == 0)) ||
					(e.Node.Parent.Text == "Расчётные счета")									 ||
					(e.Node.Parent.Text == "Активы")
					)
				{
					e.Node.ImageIndex = 2;
					e.Node.SelectedImageIndex = 2;
				}
			}
		}

		private void treeView1_AfterCollapse(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if(e.Node == null)
				return;
			if(e.Action == TreeViewAction.Collapse)
			{
				if(e.Node.Parent == null)
				{
					e.Node.ImageIndex = 1;
					e.Node.SelectedImageIndex = 1;
				}
				else if (
					(e.Node.Parent.Text == "Баланс")											 || 
					(e.Node.Parent.Text == "Счета клиентов")									 ||
					(e.Node.Parent.Text == "Пассивы" && (e.Node.Index == 0 || e.Node.Index == 1 || e.Node.Index == 2))||
					(e.Node.Parent.Text == "Активы" && (e.Node.Index == 2 || e.Node.Index == 0)) ||
					(e.Node.Parent.Text == "Расчётные счета")									 ||
					(e.Node.Parent.Text == "Активы")											 
					)
				{
					e.Node.ImageIndex = 1;
					e.Node.SelectedImageIndex = 1;
				}
			}
		}

		private void RefreshAcc()
		{
			Cursor.Current = Cursors.WaitCursor;
			this.fillDsAllAccounts();
			//this.fillDsAccOper();
			this.bmAccounts.Position=0;
			this.bmAccounts_CurrentChanged( null, null);
			Cursor.Current = Cursors.Default;
		}

		private void mnuRefresh_Click(object sender, System.EventArgs e)
		{
			RefreshAcc();
		}

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if(e.Button == this.tbbUpdt)
			{
				RefreshAcc();
			}
		}

		private void valueChange(AM_Controls.TextBoxV tb)
		{
			if(tb.dValue < 0)
				tb.ForeColor = Color.Red;
			else
				tb.ForeColor = SystemColors.WindowText;
		}

		private void tbSaldo_TextChanged(object sender, System.EventArgs e)
		{
			this.valueChange(this.tbSaldo);
		}

		private void tbReserv_TextChanged(object sender, System.EventArgs e)
		{
			this.valueChange(this.tbReserv);
		}

		private void tbWait_TextChanged(object sender, System.EventArgs e)
		{
			this.valueChange(this.tbWait);
		}

		private void tbFree_TextChanged(object sender, System.EventArgs e)
		{
			this.valueChange(this.tbFree);
		}
		private void tbSaldoNetto_TextChanged(object sender, System.EventArgs e)
		{
			this.valueChange(this.tbSaldoNetto);
		}

		private void tbFreeNetto_TextChanged(object sender, System.EventArgs e)
		{
			this.valueChange(this.tbFreeWait);
		}
		private void bnUpdOper_Click(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			bmAccounts_CurrentChanged(null, null);
			Cursor.Current = Cursors.Default;
		}

		private void cbShowZeroSaldo_CheckedChanged(object sender, System.EventArgs e)
		{
			this.updateTreeView();
		}

		private void cbOrgsRemoved_CheckedChanged(object sender, System.EventArgs e)
		{
			this.fillDsAllAccounts();
			//this.fillDsAccOper();
			this.dataGridV2.CurrentRowIndex = 0;
		}

		private void bnPrint_Click(object sender, System.EventArgs e)
		{
			if(bmAccounts.Position == -1)
				return;
			DateTime datetime1 = this.ucMovementPeriod._DateFrom;
			DateTime datetime2 = this.ucMovementPeriod._DateTill;
			if(this.treeView1.SelectedNode.Parent == null)
				return;
			this.showReport(0, (int)((DataRowView)bmAccounts.Current).Row["AccountID"], "AccountsOperationsMovie.rpt", "", datetime1, datetime2, true, false);
		}

		private void SetCountTotals(bool NeedRefresh, RepDoc rd, BLL.Accounts.DataSets.dsAllAccounts ds, ref double Income, ref double Outcome)
		{
			for(int counter = 0; counter < ds.SelectAccountsOperations.Rows.Count; counter ++)
			{
				if(!((BLL.Accounts.DataSets.dsAllAccounts.SelectAccountsOperationsRow)ds.SelectAccountsOperations.Rows[counter]).IsПриход_Null())
					Income += ((double)((BLL.Accounts.DataSets.dsAllAccounts.SelectAccountsOperationsRow)ds.SelectAccountsOperations.Rows[counter]).Приход_);// * ((double)((dsAllAccounts.SelectAccountsOperationsRow)ds.SelectAccountsOperations.Rows[counter]).CurrencyRate);
				if(!((BLL.Accounts.DataSets.dsAllAccounts.SelectAccountsOperationsRow)ds.SelectAccountsOperations.Rows[counter]).IsРасход_Null())
					Outcome += ((double)((BLL.Accounts.DataSets.dsAllAccounts.SelectAccountsOperationsRow)ds.SelectAccountsOperations.Rows[counter]).Расход_);// * ((double)((dsAllAccounts.SelectAccountsOperationsRow)ds.SelectAccountsOperations.Rows[counter]).CurrencyRate);
			}
			if(NeedRefresh)
			{
				rd.DataDefinition.FormulaFields["ПриходTotalEx"].Text = "'" + Income.ToString("0.00") + "'";
				rd.DataDefinition.FormulaFields["РасходTotalEx"].Text = "'" + Outcome.ToString("0.00") + "'";
			}
		}

		private void showReport(int iGroupID, int iAccountID, string szReportName, string szTypeName, DateTime dtFrom, DateTime dtTill, bool bNeedSaldo, bool bNeedRecountTotalCounters)
		{
			double BeginSaldo = 0, FinalSaldo = 0;
			
			Cursor = Cursors.WaitCursor;
			
			System.DateTime dt1 =dtFrom;
			dt1 =dt1.AddHours	( -dt1.Hour	 );
			dt1 =dt1.AddMinutes	( -dt1.Minute);
			dt1 =dt1.AddSeconds	( -dt1.Second);

			System.DateTime dt2 =dtTill;
			dt2 =dt2.AddHours	( -dt2.Hour	);
			dt2 =dt2.AddMinutes	( -dt2.Minute);
			dt2 =dt2.AddSeconds	( -dt2.Second);
			dt2 =dt2.AddDays	(  1);
			dt2 =dt2.AddSeconds	( -1);
			
			BLL.Accounts.DataSets.dsAllAccounts ds = new BLL.Accounts.DataSets.dsAllAccounts();
			try
			{
				ds.SelectAccountsOperations.Clear();
				
				this.daSelectAccountsOperations.SelectCommand.Parameters["@DateFrom"].Value =dt1;
				this.daSelectAccountsOperations.SelectCommand.Parameters["@DateTo"].Value	=dt2; //DateTime.Now.AddDays(1).Date;
				if(iAccountID>0)
					this.daSelectAccountsOperations.SelectCommand.Parameters["@AccountID"].Value = iAccountID;
				if(iGroupID>0)
					this.daSelectAccountsOperations.SelectCommand.Parameters["@ClientGroupID"].Value = iGroupID;
				if(!this.cbShowAllOperations.Checked)
				{
					this.daSelectAccountsOperations.SelectCommand.Parameters["@Mode"].Value = 0;
				}
				else
				{
					this.daSelectAccountsOperations.SelectCommand.Parameters["@Mode"].Value = 1;
				}
				this.daSelectAccountsOperations.Fill(ds.SelectAccountsOperations);
			}
			catch(Exception ex)
			{
				AM_Controls.MsgBoxX.Show(ex.Message);
				Cursor = Cursors.Default;
				return;
			}
			
			this.daSelectAccountsOperations.SelectCommand.Parameters["@AccountID"].Value = null;
			this.daSelectAccountsOperations.SelectCommand.Parameters["@ClientGroupID"].Value = null;
			
			if(bNeedSaldo)
			{
				/* получаем начальное и конечное сальдо */
				System.DateTime dtBeginSaldoDate =dt1;
				dtBeginSaldoDate =dtBeginSaldoDate.AddSeconds( -1);
 
				this.sqlCmdGetSaldo.Parameters["@AccountID"].Value = iAccountID;
				this.sqlCmdGetSaldo.Parameters["@DateTo"].Value = dtBeginSaldoDate; //dt1.AddSeconds(-1);
				if(!this.cbShowAllOperations.Checked)
				{
					this.sqlCmdGetSaldo.Parameters["@Mode"].Value = 0;
				}
				else
				{
					this.sqlCmdGetSaldo.Parameters["@Mode"].Value = 1;
				}
				if (this.sqlCmdGetSaldo.Connection.State ==ConnectionState.Closed) 
					this.sqlCmdGetSaldo.Connection.Open();
				try
				{
					BeginSaldo = Math.Round(System.Convert.ToDouble(this.sqlCmdGetSaldo.ExecuteScalar()), 2);
					this.sqlCmdGetSaldo.Parameters["@DateTo"].Value = dt2;
					FinalSaldo = Math.Round(System.Convert.ToDouble(this.sqlCmdGetSaldo.ExecuteScalar()), 2);
				}
				catch(Exception ex)
				{
					AM_Controls.MsgBoxX.Show(ex.Message);
					Cursor = Cursors.Default;
					return;
				}
				finally
				{
					if (this.sqlCmdGetSaldo.Connection.State ==ConnectionState.Open) 
						this.sqlCmdGetSaldo.Connection.Close();
				}
			}
			RepDoc rd = new RepDoc();
			rd.LoadForDataSet(szReportName);
			rd.SetDataSource(ds);
			rd.DataDefinition.FormulaFields["HeaderText"].Text="Local StringVar s:='Отчёт о движении денежных средств с '& CDate("+
				dt1.Year + "," + dt1.Month + "," + dt1.Day + ") & ' по '& CDate("+	dt2.Year + "," + dt2.Month + "," + dt2.Day + ")";
			if(bNeedSaldo)
			{
				rd.DataDefinition.FormulaFields["FooterText"].Text = "Local StringVar s:='Начальное сальдо = ' & '" + ((Math.Round(BeginSaldo, 2) == 0) ? "0.00" : Math.Round(BeginSaldo, 2).ToString("0.00")) + "' &     '         Конечное сальдо = ' & '" + ((Math.Round(FinalSaldo, 2) == 0) ? "0.00" : Math.Round(FinalSaldo, 2).ToString("0.00")) + "';";
			}
			rd.DataDefinition.FormulaFields["HeaderText"].Text += "&'" + szTypeName + "';";
			if(szReportName.CompareTo("SettlementAccountsOperationsMovie.rpt") == 0)
			{
				rd.DataDefinition.FormulaFields["SecondHeader"].Text = "Local StringVar s:='" + ((BLL.Accounts.DataSets.dsAllAccounts.SelectAllAccountsRow)((DataRowView)bmAccounts.Current).Row).OrgName + "  " + ((BLL.Accounts.DataSets.dsAllAccounts.SelectAllAccountsRow)((DataRowView)bmAccounts.Current).Row).TypeName + " № " + ((BLL.Accounts.DataSets.dsAllAccounts.SelectAllAccountsRow)((DataRowView)bmAccounts.Current).Row).RAccount + "  " + ((BLL.Accounts.DataSets.dsAllAccounts.SelectAllAccountsRow)((DataRowView)bmAccounts.Current).Row).CurrencyID.ToString() + "  ( ID " + ((BLL.Accounts.DataSets.dsAllAccounts.SelectAllAccountsRow)((DataRowView)bmAccounts.Current).Row).AccountID.ToString() + " )'";
			}
			else
			{
				rd.DataDefinition.FormulaFields["SecondHeader"].Text = "Local StringVar s:='" + ((BLL.Accounts.DataSets.dsAllAccounts.SelectAllAccountsRow)((DataRowView)bmAccounts.Current).Row).TypeName + "  " + ((BLL.Accounts.DataSets.dsAllAccounts.SelectAllAccountsRow)((DataRowView)bmAccounts.Current).Row).CurrencyID.ToString() + "  ( ID " + ((BLL.Accounts.DataSets.dsAllAccounts.SelectAllAccountsRow)((DataRowView)bmAccounts.Current).Row).AccountID.ToString() + " )'";
			}
			if(((BLL.Accounts.DataSets.dsAllAccounts.SelectAllAccountsRow)((DataRowView)bmAccounts.Current).Row).AccountTypeID == 1)
			{
				rd.DataDefinition.FormulaFields["OwnerName"].Text = "Local StringVar s:='Организация: " + ((BLL.Accounts.DataSets.dsAllAccounts.SelectAllAccountsRow)((DataRowView)bmAccounts.Current).Row).OrgName + " р/с " + ((BLL.Accounts.DataSets.dsAllAccounts.SelectAllAccountsRow)((DataRowView)bmAccounts.Current).Row).RAccount + "'";
			}
			else
			{
				rd.DataDefinition.FormulaFields["OwnerName"].Text = "Local StringVar s:='Клиент: " + ((BLL.Accounts.DataSets.dsAllAccounts.SelectAllAccountsRow)((DataRowView)bmAccounts.Current).Row).ClientName + " ( " + ((BLL.Accounts.DataSets.dsAllAccounts.SelectAllAccountsRow)((DataRowView)bmAccounts.Current).Row).ClientGroupName + " )'";
			}
			double Income = 0, Outcome = 0;
			SetCountTotals(bNeedRecountTotalCounters, rd, ds, ref Income, ref Outcome);
			rd.DataDefinition.FormulaFields["TestBalans"].Text = "Local StringVar s:='Итого : ' & '" + (Math.Round(BeginSaldo, 2) + Math.Round(Income, 2) - Math.Round(Outcome, 2) - Math.Round(FinalSaldo, 2)).ToString("0.00")  + "'";
			RepPreview rprv = new RepPreview();
			Cursor = Cursors.Default;
			rprv.ShowDialog(rd);
		}

		private void bnPrintAccount_Click(object sender, System.EventArgs e)
		{
			this.printAccountsStates();			
		}
		
		private void printAccountsStates()
		{
			DataRow [] dr = this.dvAllAccounts.Table.Select(this.dvAllAccounts.RowFilter,this.dvAllAccounts.Sort);
			BLL.Accounts.DataSets.dsAllAccounts ds = new BLL.Accounts.DataSets.dsAllAccounts();
			for(int i = 0; i<dr.Length;i++)
			{
				BLL.Accounts.DataSets.dsAllAccounts.SelectAllAccountsRow rw = ds.SelectAllAccounts.NewSelectAllAccountsRow();
				rw.ItemArray = dr[i].ItemArray;
				ds.SelectAllAccounts.AddSelectAllAccountsRow(rw);
			}
			RepDoc rd = new RepDoc();
			rd.LoadForDataSet("AccountsStates.rpt");
			rd.SetDataSource(ds);
			RepPreview rprv = new RepPreview();
			rprv.ShowDialog(rd);
		}

		private void cbShowAllOperations_CheckedChanged(object sender, System.EventArgs e)
		{
			//if (this.cbShowAllOperations.Checked)
			//{
			//	this.dvAccOper.RowFilter = "AccountTypeID=2 AND ClientGroupID=" + this.treeView1.SelectedNode.Tag.ToString();
			//}
			this.bmAccounts_CurrentChanged( null, null);
		}

		private void bnUpdAcc_Click(object sender, System.EventArgs e)
		{
			RefreshAcc();
		}

		private void tbShowDigitsNumber_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(this.tbShowDigitsNumber.nValue > 20 || this.tbShowDigitsNumber.nValue < 1)
			{
				MessageBox.Show("Количество показываемых цифр расчетного счета должно находиться в диапазоне от 1 до 20", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				this.tbShowDigitsNumber.Undo();
				return;
			}
			SetTreeRAccountDigits((int)this.tbShowDigitsNumber.nValue);
		}

		private void SetTreeRAccountDigits(int DigitsNumber)
		{
			this.treeView1.Nodes[0].Nodes[0].Nodes[0].Nodes[0].Nodes.Clear();
			this.treeView1.Nodes[0].Nodes[0].Nodes[0].Nodes[1].Nodes.Clear();
			DataView dv = new DataView();
			dv.Table		= this.dsAllAccounts1.SelectAllAccounts;
			dv.Sort			= "OrgName ASC";
			dv.RowFilter	= "IsInner=true  and AccountTypeID=1 and IsNormal=true";
			for(int counter = 0; counter < dv.Count; counter ++)
			{
				BPS.BLL.Accounts.DataSets.dsAllAccounts.SelectAllAccountsRow rw = (BPS.BLL.Accounts.DataSets.dsAllAccounts.SelectAllAccountsRow)dv[counter].Row;
				TreeNode trn = new TreeNode(rw.OrgName + " [" + rw.RAccount.Remove(0, rw.RAccount.Length - DigitsNumber) + "]");
				trn.Tag = rw.RAccount;
				trn.ImageIndex = 0;
				trn.SelectedImageIndex = 0;
				this.treeView1.Nodes[0].Nodes[0].Nodes[0].Nodes[0].Nodes.Add(trn);
			}
			dv.RowFilter = "IsInner=true  and AccountTypeID=1 and IsNormal=false";
			for(int counter = 0; counter < dv.Count; counter ++)
			{
				BPS.BLL.Accounts.DataSets.dsAllAccounts.SelectAllAccountsRow rw = (BPS.BLL.Accounts.DataSets.dsAllAccounts.SelectAllAccountsRow)dv[counter].Row;
				TreeNode trn = new TreeNode(rw.OrgName + " [" + rw.RAccount.Remove(0, rw.RAccount.Length - DigitsNumber) + "]");
				trn.Tag = rw.RAccount;
				trn.ImageIndex = 0;
				trn.SelectedImageIndex = 0;
				this.treeView1.Nodes[0].Nodes[0].Nodes[0].Nodes[1].Nodes.Add(trn);
			}
		}
	}

	public enum StyleMapType
	{
		Orgs,
		Clients,
		Empty
	}
}
