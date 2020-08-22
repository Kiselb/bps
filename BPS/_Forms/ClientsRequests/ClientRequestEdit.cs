using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace BPS._Forms
{
	/// <summary>
	/// Summary description for ClientRequestEdit.
	/// </summary>
	public class ClientRequestEdit : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button bnOk;
		private System.Windows.Forms.Button bnCancel;
		private System.Windows.Forms.ComboBox cmbReqTypes;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.GroupBox gbCorr;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.GroupBox gbInner;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tbRemarks;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private AM_Controls.TextBoxV tbSum;
		private System.Windows.Forms.Label label12;
		private System.Data.DataView dvReqTypes;
		private System.Data.DataView dvOrgInner;
		private System.Data.DataView dvOrgAccountInner;
		private AM_Controls.TextBoxINN tbINNCorr;
		private System.Windows.Forms.TextBox tbINNInner;
		private System.Windows.Forms.ComboBox cmbOrgInner;
		private System.Windows.Forms.ComboBox cmbOrgAccountInner;
		private System.Windows.Forms.ComboBox cmbOrgCorr;
		private AM_Controls.ComboRAccount  cmbOrgAccountCorr;
		private System.Windows.Forms.ComboBox cmbCurrencyFrom;
		private System.Windows.Forms.TextBox tbPurpose;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private AM_Controls.TextBoxV tbVAT;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.TextBox tbBankCorr;
		private AM_Controls.TextBoxBIK tbBIKCorr;
		private System.Windows.Forms.TextBox tbBankInner;
		private System.Windows.Forms.TextBox tbBIKInner;
		private System.Data.SqlClient.SqlConnection sqlConnection1;
		private System.Data.DataView dvPrevOrg;
		private System.Data.DataView dvPrevOrgAccount;
		private System.Data.SqlClient.SqlDataAdapter daPrevOrg;
        private BPS.BLL.ClientsRequests.DataSets.dsPrevClientRequest dsPrevClientRequest1;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.Data.SqlClient.SqlDataAdapter daPrevOrgAccount;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		private System.ComponentModel.IContainer components;
	
		public delegate void MemorizeEventHandler();
		public event MemorizeEventHandler Memorize;
		private System.Data.SqlClient.SqlCommand cmdCheckRequest;
		private System.Windows.Forms.Button btnPlusVAT;
		private System.Windows.Forms.MainMenu mnuMain;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem mnuVAT;
		private System.Windows.Forms.Button btnLastPurpose;
		private BPS.BLL.Clients.DataSets.dsOrgsClients dsOrgsClients1;
		private System.Windows.Forms.Panel pnlVAT;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.ComboBox cmbVAT;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Panel panel1;
		//		private bool bIsShowAllAccounts = false;
		private System.Drawing.Point p1,p2;
		private System.Windows.Forms.Label label2;
		private AM_Controls.TextBoxKPP tbKPPCorr;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label22;
		private AM_Controls.TextBoxV tbKPPInner;
		private System.Data.SqlClient.SqlCommand sqlSelLastPurpose;
		private System.Windows.Forms.Panel pnlPurpose;
		private BPS.BLL.ClientsRequests.DataSets.dsReqTypes dsReqTypes1;
		private BPS.BLL.Orgs.DataSets.dsOrgsAccounts dsOrgsAccount1;

		private bool bIsLoaded = false;
		private bool bIsEdit;
		private BLL.ClientsRequests.DataSets.dsClientsRequests.ClientsRequestsRow rwClRq;
		private BPS._Forms.Clients.GroupClients groupClients;
		private System.Windows.Forms.Panel pnlCurrencyTo;
		private System.Windows.Forms.ComboBox cmbCurrencyTo;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ErrorProvider err;
		private bool bDontEdit;

		public ClientRequestEdit(BLL.ClientsRequests.DataSets.dsClientsRequests.ClientsRequestsRow rw)
		{

			this.rwClRq = rw;
			this.bIsEdit = (rw.RowState != DataRowState.Detached);

			App.FillOrgsAccount();

			InitializeComponent();

			p1 = new System.Drawing.Point (this.gbCorr.Location.X, this.gbCorr.Location.Y);
			p2 = new System.Drawing.Point (this.gbInner.Location.X, this.gbInner.Location.Y);
			this.cmbVAT.SelectedIndex = 2;
			
			((System.ComponentModel.ISupportInitialize)(this.dvReqTypes)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvOrgInner)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvOrgAccountInner)).BeginInit();

			this.dvReqTypes.Table = App.bllRequests.ReqTypesDirectory.ClientsRequestTypes;

			this.groupClients._MembersFilter = "IsInner=false AND IsSpecial=false";

			this.dvOrgInner.Table = this.dsOrgsClients1.OrgsClients;
			this.dvOrgAccountInner.Table = App.DsOrgsAccount.OrgsAccounts;

			//
			this.cmbCurrencyFrom.DataSource =  App.DsCurr.Currencies.Copy();
			this.cmbCurrencyFrom.DisplayMember = "CurrencyID";
			this.cmbCurrencyFrom.ValueMember = "CurrencyID";

			this.cmbCurrencyTo.DataSource =  App.DsCurr.Currencies.Copy();
			this.cmbCurrencyTo.DisplayMember = "CurrencyID";
			this.cmbCurrencyTo.ValueMember = "CurrencyID";

			((System.ComponentModel.ISupportInitialize)(this.dvReqTypes)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvOrgInner)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvOrgAccountInner)).EndInit();

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
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ClientRequestEdit));
			this.tbSum = new AM_Controls.TextBoxV();
			this.tbVAT = new AM_Controls.TextBoxV();
			this.bnOk = new System.Windows.Forms.Button();
			this.bnCancel = new System.Windows.Forms.Button();
			this.cmbReqTypes = new System.Windows.Forms.ComboBox();
			this.dvReqTypes = new System.Data.DataView();
            this.dsReqTypes1 = new BPS.BLL.ClientsRequests.DataSets.dsReqTypes();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.gbCorr = new System.Windows.Forms.GroupBox();
			this.tbKPPCorr = new AM_Controls.TextBoxKPP();
			this.label14 = new System.Windows.Forms.Label();
			this.tbBIKCorr = new AM_Controls.TextBoxBIK();
			this.label20 = new System.Windows.Forms.Label();
			this.tbBankCorr = new System.Windows.Forms.TextBox();
			this.label19 = new System.Windows.Forms.Label();
			this.cmbOrgAccountCorr = new AM_Controls.ComboRAccount();
			this.dvPrevOrgAccount = new System.Data.DataView();
			this.dsPrevClientRequest1 = new BPS.BLL.ClientsRequests.DataSets.dsPrevClientRequest();
			this.cmbOrgCorr = new System.Windows.Forms.ComboBox();
			this.dvPrevOrg = new System.Data.DataView();
			this.tbINNCorr = new AM_Controls.TextBoxINN();
			this.label1 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.gbInner = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tbINNInner = new System.Windows.Forms.TextBox();
			this.cmbOrgInner = new System.Windows.Forms.ComboBox();
			this.dvOrgInner = new System.Data.DataView();
			this.dsOrgsClients1 = new BPS.BLL.Clients.DataSets.dsOrgsClients();
			this.cmbOrgAccountInner = new System.Windows.Forms.ComboBox();
			this.dvOrgAccountInner = new System.Data.DataView();
			this.dsOrgsAccount1 = new BPS.BLL.Orgs.DataSets.dsOrgsAccounts();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.tbBankInner = new System.Windows.Forms.TextBox();
			this.label18 = new System.Windows.Forms.Label();
			this.tbBIKInner = new System.Windows.Forms.TextBox();
			this.label22 = new System.Windows.Forms.Label();
			this.tbKPPInner = new AM_Controls.TextBoxV();
			this.tbRemarks = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.cmbCurrencyFrom = new System.Windows.Forms.ComboBox();
			this.tbPurpose = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.daPrevOrg = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.daPrevOrgAccount = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.cmdCheckRequest = new System.Data.SqlClient.SqlCommand();
			this.btnPlusVAT = new System.Windows.Forms.Button();
			this.mnuMain = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.mnuVAT = new System.Windows.Forms.MenuItem();
			this.btnLastPurpose = new System.Windows.Forms.Button();
			this.pnlVAT = new System.Windows.Forms.Panel();
			this.label21 = new System.Windows.Forms.Label();
			this.cmbVAT = new System.Windows.Forms.ComboBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.panel1 = new System.Windows.Forms.Panel();
			this.pnlPurpose = new System.Windows.Forms.Panel();
			this.sqlSelLastPurpose = new System.Data.SqlClient.SqlCommand();
			this.groupClients = new BPS._Forms.Clients.GroupClients();
			this.pnlCurrencyTo = new System.Windows.Forms.Panel();
			this.cmbCurrencyTo = new System.Windows.Forms.ComboBox();
			this.label8 = new System.Windows.Forms.Label();
			this.err = new System.Windows.Forms.ErrorProvider();
			((System.ComponentModel.ISupportInitialize)(this.dvReqTypes)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsReqTypes1)).BeginInit();
			this.gbCorr.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dvPrevOrgAccount)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsPrevClientRequest1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvPrevOrg)).BeginInit();
			this.gbInner.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dvOrgInner)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsOrgsClients1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvOrgAccountInner)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsOrgsAccount1)).BeginInit();
			this.pnlVAT.SuspendLayout();
			this.pnlPurpose.SuspendLayout();
			this.pnlCurrencyTo.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbSum
			// 
			this.tbSum.AllowDrop = true;
			this.tbSum.dValue = 0;
			this.tbSum.IsPcnt = false;
			this.tbSum.Location = new System.Drawing.Point(260, 54);
			this.tbSum.MaxDecPos = 2;
			this.tbSum.MaxPos = 12;
			this.tbSum.Name = "tbSum";
			this.tbSum.Negative = System.Drawing.Color.Empty;
			this.tbSum.nValue = ((long)(0));
			this.tbSum.Positive = System.Drawing.Color.Empty;
			this.tbSum.Size = new System.Drawing.Size(94, 21);
			this.tbSum.TabIndex = 6;
			this.tbSum.Text = "";
			this.tbSum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbSum.TextMode = false;
			this.tbSum.Zero = System.Drawing.Color.Empty;
			// 
			// tbVAT
			// 
			this.tbVAT.AllowDrop = true;
			this.tbVAT.dValue = 0;
			this.tbVAT.IsPcnt = true;
			this.tbVAT.Location = new System.Drawing.Point(500, 30);
			this.tbVAT.MaxDecPos = 2;
			this.tbVAT.MaxPos = 8;
			this.tbVAT.Name = "tbVAT";
			this.tbVAT.Negative = System.Drawing.Color.Empty;
			this.tbVAT.nValue = ((long)(0));
			this.tbVAT.Positive = System.Drawing.Color.Empty;
			this.tbVAT.Size = new System.Drawing.Size(38, 21);
			this.tbVAT.TabIndex = 9;
			this.tbVAT.Text = "";
			this.tbVAT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbVAT.TextMode = false;
			this.tbVAT.Visible = false;
			this.tbVAT.Zero = System.Drawing.Color.Empty;
			this.tbVAT.TextChanged += new System.EventHandler(this.tbVAT_TextChanged);
			// 
			// bnOk
			// 
			this.bnOk.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.bnOk.Location = new System.Drawing.Point(376, 398);
			this.bnOk.Name = "bnOk";
			this.bnOk.Size = new System.Drawing.Size(80, 26);
			this.bnOk.TabIndex = 14;
			this.bnOk.Text = "Сохранить";
			this.bnOk.Click += new System.EventHandler(this.bnOk_Click);
			// 
			// bnCancel
			// 
			this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.bnCancel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.bnCancel.Location = new System.Drawing.Point(458, 398);
			this.bnCancel.Name = "bnCancel";
			this.bnCancel.Size = new System.Drawing.Size(80, 26);
			this.bnCancel.TabIndex = 15;
			this.bnCancel.Text = "Отменить";
			this.bnCancel.Click += new System.EventHandler(this.bnCancel_Click);
			// 
			// cmbReqTypes
			// 
			this.cmbReqTypes.DataSource = this.dvReqTypes;
			this.cmbReqTypes.DisplayMember = "RequestTypeName";
			this.cmbReqTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbReqTypes.Location = new System.Drawing.Point(76, 54);
			this.cmbReqTypes.Name = "cmbReqTypes";
			this.cmbReqTypes.Size = new System.Drawing.Size(120, 21);
			this.cmbReqTypes.TabIndex = 4;
			this.cmbReqTypes.ValueMember = "RequestTypeID";
			this.cmbReqTypes.SelectedIndexChanged += new System.EventHandler(this.cmbReqTypes_SelectedIndexChanged);
			// 
			// dvReqTypes
			// 
			this.dvReqTypes.Table = this.dsReqTypes1.ClientsRequestTypes;
			// 
			// dsReqTypes1
			// 
			this.dsReqTypes1.DataSetName = "dsReqTypes";
			this.dsReqTypes1.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dateTimePicker1.Location = new System.Drawing.Point(76, 2);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(82, 21);
			this.dateTimePicker1.TabIndex = 1;
			// 
			// gbCorr
			// 
			this.gbCorr.Controls.Add(this.tbKPPCorr);
			this.gbCorr.Controls.Add(this.label14);
			this.gbCorr.Controls.Add(this.tbBIKCorr);
			this.gbCorr.Controls.Add(this.label20);
			this.gbCorr.Controls.Add(this.tbBankCorr);
			this.gbCorr.Controls.Add(this.label19);
			this.gbCorr.Controls.Add(this.cmbOrgAccountCorr);
			this.gbCorr.Controls.Add(this.cmbOrgCorr);
			this.gbCorr.Controls.Add(this.tbINNCorr);
			this.gbCorr.Controls.Add(this.label1);
			this.gbCorr.Controls.Add(this.label6);
			this.gbCorr.Controls.Add(this.label9);
			this.gbCorr.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.gbCorr.Location = new System.Drawing.Point(2, 86);
			this.gbCorr.Name = "gbCorr";
			this.gbCorr.Size = new System.Drawing.Size(532, 110);
			this.gbCorr.TabIndex = 9;
			this.gbCorr.TabStop = false;
			this.gbCorr.Text = "Плательщик";
			// 
			// tbKPPCorr
			// 
			this.tbKPPCorr.AllowDrop = true;
			this.tbKPPCorr.dValue = 0;
			this.tbKPPCorr.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbKPPCorr.IsPcnt = false;
			this.tbKPPCorr.Location = new System.Drawing.Point(286, 18);
			this.tbKPPCorr.MaxDecPos = -1;
			this.tbKPPCorr.MaxLength = 9;
			this.tbKPPCorr.MaxPos = 9;
			this.tbKPPCorr.Name = "tbKPPCorr";
			this.tbKPPCorr.Negative = System.Drawing.Color.Empty;
			this.tbKPPCorr.nValue = ((long)(0));
			this.tbKPPCorr.Positive = System.Drawing.Color.Empty;
			this.tbKPPCorr.Size = new System.Drawing.Size(82, 21);
			this.tbKPPCorr.TabIndex = 2;
			this.tbKPPCorr.Text = "";
			this.tbKPPCorr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbKPPCorr.TextMode = false;
			this.tbKPPCorr.Zero = System.Drawing.Color.Empty;
			// 
			// label14
			// 
			this.label14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label14.Location = new System.Drawing.Point(248, 22);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(32, 16);
			this.label14.TabIndex = 33;
			this.label14.Text = "КПП:";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbBIKCorr
			// 
			this.tbBIKCorr.AllowDrop = true;
			this.tbBIKCorr.dValue = 0;
			this.tbBIKCorr.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbBIKCorr.IsPcnt = false;
			this.tbBIKCorr.Location = new System.Drawing.Point(90, 84);
			this.tbBIKCorr.MaxDecPos = 0;
			this.tbBIKCorr.MaxLength = 9;
			this.tbBIKCorr.MaxPos = 9;
			this.tbBIKCorr.Name = "tbBIKCorr";
			this.tbBIKCorr.Negative = System.Drawing.Color.Empty;
			this.tbBIKCorr.nValue = ((long)(0));
			this.tbBIKCorr.Positive = System.Drawing.Color.Empty;
			this.tbBIKCorr.Size = new System.Drawing.Size(150, 21);
			this.tbBIKCorr.TabIndex = 7;
			this.tbBIKCorr.Text = "";
			this.tbBIKCorr.TextMode = true;
			this.tbBIKCorr.Zero = System.Drawing.Color.Empty;
			// 
			// label20
			// 
			this.label20.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label20.Location = new System.Drawing.Point(6, 82);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(32, 23);
			this.label20.TabIndex = 6;
			this.label20.Text = "БИК:";
			this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbBankCorr
			// 
			this.tbBankCorr.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbBankCorr.Location = new System.Drawing.Point(286, 84);
			this.tbBankCorr.MaxLength = 256;
			this.tbBankCorr.Name = "tbBankCorr";
			this.tbBankCorr.Size = new System.Drawing.Size(242, 21);
			this.tbBankCorr.TabIndex = 9;
			this.tbBankCorr.Text = "";
			// 
			// label19
			// 
			this.label19.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label19.Location = new System.Drawing.Point(246, 86);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(38, 18);
			this.label19.TabIndex = 8;
			this.label19.Text = "Банк:";
			this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cmbOrgAccountCorr
			// 
			this.cmbOrgAccountCorr.AllowZeroLength = false;
			this.cmbOrgAccountCorr.DataSource = this.dvPrevOrgAccount;
			this.cmbOrgAccountCorr.DisplayMember = "Account";
			this.cmbOrgAccountCorr.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cmbOrgAccountCorr.Location = new System.Drawing.Point(90, 62);
			this.cmbOrgAccountCorr.MaxLength = 20;
			this.cmbOrgAccountCorr.Name = "cmbOrgAccountCorr";
			this.cmbOrgAccountCorr.ReadOnly = false;
			this.cmbOrgAccountCorr.Size = new System.Drawing.Size(150, 21);
			this.cmbOrgAccountCorr.TabIndex = 5;
			this.cmbOrgAccountCorr.ValueMember = "Account";
			this.cmbOrgAccountCorr.Leave += new System.EventHandler(this.cmbOrgAccountCorr_Leave);
			this.cmbOrgAccountCorr.SelectedIndexChanged += new System.EventHandler(this.cmbOrgAccountCorr_SelectedIndexChanged);
			// 
			// dvPrevOrgAccount
			// 
			this.dvPrevOrgAccount.Table = this.dsPrevClientRequest1.GetPrevOrgAccount;
			// 
			// dsPrevClientRequest1
			// 
			this.dsPrevClientRequest1.DataSetName = "dsPrevClientRequest";
			this.dsPrevClientRequest1.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// cmbOrgCorr
			// 
			this.cmbOrgCorr.DataSource = this.dvPrevOrg;
			this.cmbOrgCorr.DisplayMember = "Org";
			this.cmbOrgCorr.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cmbOrgCorr.Location = new System.Drawing.Point(90, 40);
			this.cmbOrgCorr.MaxLength = 256;
			this.cmbOrgCorr.Name = "cmbOrgCorr";
			this.cmbOrgCorr.Size = new System.Drawing.Size(438, 21);
			this.cmbOrgCorr.TabIndex = 3;
			this.cmbOrgCorr.ValueMember = "INN";
			this.cmbOrgCorr.TextChanged += new System.EventHandler(this.cmbOrgCorr_TextChanged);
			this.cmbOrgCorr.SelectedIndexChanged += new System.EventHandler(this.cmbOrgCorr_SelectedIndexChanged);
			this.cmbOrgCorr.Leave += new System.EventHandler(this.cmbOrgCorr_Leave);
			this.cmbOrgCorr.Enter += new System.EventHandler(this.cmbOrgCorr_Enter);
			// 
			// dvPrevOrg
			// 
			this.dvPrevOrg.Table = this.dsPrevClientRequest1.GetPrevOrg;
			// 
			// tbINNCorr
			// 
			this.tbINNCorr.AllowDrop = true;
			this.tbINNCorr.dValue = 123456789102;
			this.tbINNCorr.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbINNCorr.IsPcnt = false;
			this.tbINNCorr.Location = new System.Drawing.Point(90, 18);
			this.tbINNCorr.MaxDecPos = -1;
			this.tbINNCorr.MaxLength = 12;
			this.tbINNCorr.MaxPos = 12;
			this.tbINNCorr.Name = "tbINNCorr";
			this.tbINNCorr.Negative = System.Drawing.Color.Empty;
			this.tbINNCorr.nValue = ((long)(123456789102));
			this.tbINNCorr.Positive = System.Drawing.Color.Empty;
			this.tbINNCorr.Size = new System.Drawing.Size(82, 21);
			this.tbINNCorr.TabIndex = 1;
			this.tbINNCorr.Text = "123456789102";
			this.tbINNCorr.TextMode = true;
			this.tbINNCorr.Zero = System.Drawing.Color.Empty;
			this.tbINNCorr.Leave += new System.EventHandler(this.tbINNCorr_Leave);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(6, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(84, 20);
			this.label1.TabIndex = 2;
			this.label1.Text = "Наименование:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label6.Location = new System.Drawing.Point(6, 62);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(48, 18);
			this.label6.TabIndex = 4;
			this.label6.Text = "Р/cчет:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label9
			// 
			this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label9.Location = new System.Drawing.Point(6, 20);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(36, 18);
			this.label9.TabIndex = 0;
			this.label9.Text = "ИНН:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// gbInner
			// 
			this.gbInner.Controls.Add(this.label2);
			this.gbInner.Controls.Add(this.tbINNInner);
			this.gbInner.Controls.Add(this.cmbOrgInner);
			this.gbInner.Controls.Add(this.cmbOrgAccountInner);
			this.gbInner.Controls.Add(this.label3);
			this.gbInner.Controls.Add(this.label4);
			this.gbInner.Controls.Add(this.label17);
			this.gbInner.Controls.Add(this.tbBankInner);
			this.gbInner.Controls.Add(this.label18);
			this.gbInner.Controls.Add(this.tbBIKInner);
			this.gbInner.Controls.Add(this.label22);
			this.gbInner.Controls.Add(this.tbKPPInner);
			this.gbInner.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.gbInner.Location = new System.Drawing.Point(2, 206);
			this.gbInner.Name = "gbInner";
			this.gbInner.Size = new System.Drawing.Size(532, 110);
			this.gbInner.TabIndex = 10;
			this.gbInner.TabStop = false;
			this.gbInner.Text = "Получатель";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(6, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(84, 20);
			this.label2.TabIndex = 4;
			this.label2.Text = "Наименование:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbINNInner
			// 
			this.tbINNInner.BackColor = System.Drawing.Color.Gainsboro;
			this.tbINNInner.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbINNInner.Location = new System.Drawing.Point(90, 18);
			this.tbINNInner.Name = "tbINNInner";
			this.tbINNInner.ReadOnly = true;
			this.tbINNInner.Size = new System.Drawing.Size(82, 21);
			this.tbINNInner.TabIndex = 1;
			this.tbINNInner.TabStop = false;
			this.tbINNInner.Text = "";
			// 
			// cmbOrgInner
			// 
			this.cmbOrgInner.DataSource = this.dvOrgInner;
			this.cmbOrgInner.DisplayMember = "OrgName";
			this.cmbOrgInner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbOrgInner.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cmbOrgInner.Location = new System.Drawing.Point(90, 40);
			this.cmbOrgInner.MaxLength = 256;
			this.cmbOrgInner.Name = "cmbOrgInner";
			this.cmbOrgInner.Size = new System.Drawing.Size(438, 21);
			this.cmbOrgInner.TabIndex = 5;
			this.cmbOrgInner.ValueMember = "OrgID";
			this.cmbOrgInner.SelectedIndexChanged += new System.EventHandler(this.cmbOrgInner_SelectedIndexChanged);
			// 
			// dvOrgInner
			// 
			this.dvOrgInner.Table = this.dsOrgsClients1.OrgsClients;
			// 
			// dsOrgsClients1
			// 
			this.dsOrgsClients1.DataSetName = "dsOrgsClients";
			this.dsOrgsClients1.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// cmbOrgAccountInner
			// 
			this.cmbOrgAccountInner.DataSource = this.dvOrgAccountInner;
			this.cmbOrgAccountInner.DisplayMember = "RAccount";
			this.cmbOrgAccountInner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbOrgAccountInner.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cmbOrgAccountInner.Location = new System.Drawing.Point(90, 62);
			this.cmbOrgAccountInner.MaxLength = 20;
			this.cmbOrgAccountInner.Name = "cmbOrgAccountInner";
			this.cmbOrgAccountInner.Size = new System.Drawing.Size(150, 21);
			this.cmbOrgAccountInner.TabIndex = 7;
			this.cmbOrgAccountInner.ValueMember = "RAccount";
			this.cmbOrgAccountInner.SelectedIndexChanged += new System.EventHandler(this.cmbOrgAccountIn_SelectedIndexChanged);
			// 
			// dvOrgAccountInner
			// 
			this.dvOrgAccountInner.Table = this.dsOrgsAccount1.OrgsAccounts;
			// 
			// dsOrgsAccount1
			// 
			this.dsOrgsAccount1.DataSetName = "dsOrgsAccounts";
			this.dsOrgsAccount1.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(6, 62);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 18);
			this.label3.TabIndex = 6;
			this.label3.Text = "Р/cчет:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.Location = new System.Drawing.Point(6, 20);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(34, 18);
			this.label4.TabIndex = 0;
			this.label4.Text = "ИНН:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label17
			// 
			this.label17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label17.Location = new System.Drawing.Point(246, 86);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(36, 16);
			this.label17.TabIndex = 10;
			this.label17.Text = "Банк:";
			this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbBankInner
			// 
			this.tbBankInner.BackColor = System.Drawing.Color.Gainsboro;
			this.tbBankInner.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbBankInner.Location = new System.Drawing.Point(286, 84);
			this.tbBankInner.Name = "tbBankInner";
			this.tbBankInner.ReadOnly = true;
			this.tbBankInner.Size = new System.Drawing.Size(242, 21);
			this.tbBankInner.TabIndex = 11;
			this.tbBankInner.TabStop = false;
			this.tbBankInner.Text = "";
			// 
			// label18
			// 
			this.label18.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label18.Location = new System.Drawing.Point(6, 82);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(32, 23);
			this.label18.TabIndex = 8;
			this.label18.Text = "БИК:";
			this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbBIKInner
			// 
			this.tbBIKInner.BackColor = System.Drawing.Color.Gainsboro;
			this.tbBIKInner.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbBIKInner.Location = new System.Drawing.Point(90, 84);
			this.tbBIKInner.Name = "tbBIKInner";
			this.tbBIKInner.ReadOnly = true;
			this.tbBIKInner.Size = new System.Drawing.Size(150, 21);
			this.tbBIKInner.TabIndex = 9;
			this.tbBIKInner.TabStop = false;
			this.tbBIKInner.Text = "";
			// 
			// label22
			// 
			this.label22.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label22.Location = new System.Drawing.Point(248, 22);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(32, 16);
			this.label22.TabIndex = 2;
			this.label22.Text = "КПП:";
			this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbKPPInner
			// 
			this.tbKPPInner.AllowDrop = true;
			this.tbKPPInner.BackColor = System.Drawing.Color.Gainsboro;
			this.tbKPPInner.dValue = 0;
			this.tbKPPInner.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbKPPInner.IsPcnt = false;
			this.tbKPPInner.Location = new System.Drawing.Point(286, 18);
			this.tbKPPInner.MaxDecPos = -1;
			this.tbKPPInner.MaxLength = 9;
			this.tbKPPInner.MaxPos = 9;
			this.tbKPPInner.Name = "tbKPPInner";
			this.tbKPPInner.Negative = System.Drawing.Color.Empty;
			this.tbKPPInner.nValue = ((long)(0));
			this.tbKPPInner.Positive = System.Drawing.Color.Empty;
			this.tbKPPInner.Size = new System.Drawing.Size(82, 21);
			this.tbKPPInner.TabIndex = 3;
			this.tbKPPInner.TabStop = false;
			this.tbKPPInner.Text = "";
			this.tbKPPInner.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbKPPInner.TextMode = false;
			this.tbKPPInner.Zero = System.Drawing.Color.Empty;
			// 
			// tbRemarks
			// 
			this.tbRemarks.Location = new System.Drawing.Point(90, 358);
			this.tbRemarks.MaxLength = 256;
			this.tbRemarks.Name = "tbRemarks";
			this.tbRemarks.Size = new System.Drawing.Size(444, 21);
			this.tbRemarks.TabIndex = 13;
			this.tbRemarks.Text = "";
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label5.Location = new System.Drawing.Point(4, 54);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(34, 18);
			this.label5.TabIndex = 3;
			this.label5.Text = "Тип:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label10
			// 
			this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label10.Location = new System.Drawing.Point(6, 2);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(36, 23);
			this.label10.TabIndex = 0;
			this.label10.Text = "Дата:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label11
			// 
			this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label11.Location = new System.Drawing.Point(4, 362);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(82, 18);
			this.label11.TabIndex = 12;
			this.label11.Text = "Примечание:";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label12
			// 
			this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label12.Location = new System.Drawing.Point(214, 54);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(46, 23);
			this.label12.TabIndex = 5;
			this.label12.Text = "Сумма:";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cmbCurrencyFrom
			// 
			this.cmbCurrencyFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCurrencyFrom.Location = new System.Drawing.Point(356, 54);
			this.cmbCurrencyFrom.Name = "cmbCurrencyFrom";
			this.cmbCurrencyFrom.Size = new System.Drawing.Size(54, 21);
			this.cmbCurrencyFrom.TabIndex = 7;
			// 
			// tbPurpose
			// 
			this.tbPurpose.Location = new System.Drawing.Point(88, 2);
			this.tbPurpose.MaxLength = 256;
			this.tbPurpose.Name = "tbPurpose";
			this.tbPurpose.Size = new System.Drawing.Size(394, 21);
			this.tbPurpose.TabIndex = 15;
			this.tbPurpose.Text = "";
			// 
			// label15
			// 
			this.label15.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label15.Location = new System.Drawing.Point(4, 4);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(80, 18);
			this.label15.TabIndex = 14;
			this.label15.Text = "Основание:";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(456, 30);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(44, 23);
			this.label16.TabIndex = 8;
			this.label16.Text = "НДС%:";
			this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label16.Visible = false;
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = ((string)(configurationAppSettings.GetValue("ConnectionString", typeof(string))));
			// 
			// daPrevOrg
			// 
			this.daPrevOrg.SelectCommand = this.sqlSelectCommand1;
			this.daPrevOrg.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																								new System.Data.Common.DataTableMapping("Table1", "Table1", new System.Data.Common.DataColumnMapping[] {
																																																		   new System.Data.Common.DataColumnMapping("Org", "Org"),
																																																		   new System.Data.Common.DataColumnMapping("INN", "INN"),
																																																		   new System.Data.Common.DataColumnMapping("RequestTypeID", "RequestTypeID")}),
																								new System.Data.Common.DataTableMapping("Table", "GetPrevOrg", new System.Data.Common.DataColumnMapping[] {
																																																			  new System.Data.Common.DataColumnMapping("Org", "Org"),
																																																			  new System.Data.Common.DataColumnMapping("INN", "INN"),
																																																			  new System.Data.Common.DataColumnMapping("KPP", "KPP"),
																																																			  new System.Data.Common.DataColumnMapping("RequestTypeID", "RequestTypeID")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "[GetPrevOrg]";
			this.sqlSelectCommand1.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ClientID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// daPrevOrgAccount
			// 
			this.daPrevOrgAccount.SelectCommand = this.sqlSelectCommand2;
			this.daPrevOrgAccount.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									   new System.Data.Common.DataTableMapping("Table", "GetPrevOrgAccount", new System.Data.Common.DataColumnMapping[] {
																																																							new System.Data.Common.DataColumnMapping("Org", "Org"),
																																																							new System.Data.Common.DataColumnMapping("INN", "INN"),
																																																							new System.Data.Common.DataColumnMapping("KPP", "KPP"),
																																																							new System.Data.Common.DataColumnMapping("RequestTypeID", "RequestTypeID"),
																																																							new System.Data.Common.DataColumnMapping("Account", "Account"),
																																																							new System.Data.Common.DataColumnMapping("BankName", "BankName"),
																																																							new System.Data.Common.DataColumnMapping("CodeBIK", "CodeBIK"),
																																																							new System.Data.Common.DataColumnMapping("Purpose", "Purpose"),
																																																							new System.Data.Common.DataColumnMapping("OrgIn", "OrgIn")})});
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "[GetPrevOrgAccount]";
			this.sqlSelectCommand2.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			this.sqlSelectCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ClientID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// cmdCheckRequest
			// 
			this.cmdCheckRequest.CommandText = "SELECT RequestStateID FROM ClientsRequests WHERE (RequestID = @ReqID)";
			this.cmdCheckRequest.Connection = this.sqlConnection1;
			this.cmdCheckRequest.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ReqID", System.Data.SqlDbType.Int, 4, "RequestID"));
			// 
			// btnPlusVAT
			// 
			this.btnPlusVAT.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnPlusVAT.Image = ((System.Drawing.Image)(resources.GetObject("btnPlusVAT.Image")));
			this.btnPlusVAT.Location = new System.Drawing.Point(482, 2);
			this.btnPlusVAT.Name = "btnPlusVAT";
			this.btnPlusVAT.Size = new System.Drawing.Size(24, 21);
			this.btnPlusVAT.TabIndex = 20;
			this.btnPlusVAT.TabStop = false;
			this.toolTip1.SetToolTip(this.btnPlusVAT, "Добавить к тексту основания \"в т.ч.НДС\"");
			this.btnPlusVAT.Click += new System.EventHandler(this.btnPlusVAT_Click);
			// 
			// mnuMain
			// 
			this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.menuItem1});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.mnuVAT});
			this.menuItem1.Text = "Редактировать";
			this.menuItem1.Visible = false;
			// 
			// mnuVAT
			// 
			this.mnuVAT.Index = 0;
			this.mnuVAT.Shortcut = System.Windows.Forms.Shortcut.ShiftIns;
			this.mnuVAT.Text = "НДС";
			this.mnuVAT.Click += new System.EventHandler(this.mnuVAT_Click);
			// 
			// btnLastPurpose
			// 
			this.btnLastPurpose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnLastPurpose.Image = ((System.Drawing.Image)(resources.GetObject("btnLastPurpose.Image")));
			this.btnLastPurpose.Location = new System.Drawing.Point(508, 2);
			this.btnLastPurpose.Name = "btnLastPurpose";
			this.btnLastPurpose.Size = new System.Drawing.Size(24, 21);
			this.btnLastPurpose.TabIndex = 20;
			this.btnLastPurpose.TabStop = false;
			this.toolTip1.SetToolTip(this.btnLastPurpose, "Выбрать последнее основание");
			this.btnLastPurpose.Click += new System.EventHandler(this.btnLastPurpose_Click);
			// 
			// pnlVAT
			// 
			this.pnlVAT.Controls.Add(this.label21);
			this.pnlVAT.Controls.Add(this.cmbVAT);
			this.pnlVAT.Location = new System.Drawing.Point(424, 54);
			this.pnlVAT.Name = "pnlVAT";
			this.pnlVAT.Size = new System.Drawing.Size(116, 24);
			this.pnlVAT.TabIndex = 9;
			// 
			// label21
			// 
			this.label21.Location = new System.Drawing.Point(0, 2);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(30, 18);
			this.label21.TabIndex = 0;
			this.label21.Text = "НДС:";
			this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cmbVAT
			// 
			this.cmbVAT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbVAT.Items.AddRange(new object[] {
														"0.00%",
														"10.00%",
														"18.00%",
														"20.00%",
														"Не облагается"});
			this.cmbVAT.Location = new System.Drawing.Point(32, 0);
			this.cmbVAT.Name = "cmbVAT";
			this.cmbVAT.Size = new System.Drawing.Size(82, 21);
			this.cmbVAT.TabIndex = 0;
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Location = new System.Drawing.Point(2, 350);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(534, 4);
			this.panel1.TabIndex = 22;
			// 
			// pnlPurpose
			// 
			this.pnlPurpose.Controls.Add(this.tbPurpose);
			this.pnlPurpose.Controls.Add(this.btnPlusVAT);
			this.pnlPurpose.Controls.Add(this.btnLastPurpose);
			this.pnlPurpose.Controls.Add(this.label15);
			this.pnlPurpose.Location = new System.Drawing.Point(2, 318);
			this.pnlPurpose.Name = "pnlPurpose";
			this.pnlPurpose.Size = new System.Drawing.Size(536, 26);
			this.pnlPurpose.TabIndex = 11;
			// 
			// sqlSelLastPurpose
			// 
			this.sqlSelLastPurpose.CommandText = "[GetPrevOrgPurpose]";
			this.sqlSelLastPurpose.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelLastPurpose.Connection = this.sqlConnection1;
			this.sqlSelLastPurpose.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelLastPurpose.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ClientID", System.Data.SqlDbType.Int, 4));
			this.sqlSelLastPurpose.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RequestID", System.Data.SqlDbType.Int, 4));
			this.sqlSelLastPurpose.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AccountFrom", System.Data.SqlDbType.NVarChar, 20));
			this.sqlSelLastPurpose.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AccountTo", System.Data.SqlDbType.NVarChar, 20));
			this.sqlSelLastPurpose.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Purpose", System.Data.SqlDbType.NVarChar, 256, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// groupClients
			// 
			this.groupClients.__UsageForFilter = false;
			this.groupClients._FirstSpaceWidth = 24;
			this.groupClients._FourthSpaceWidth = 3;
			this.groupClients._GroupID = -1;
			this.groupClients._GroupIDColunmName = null;
			this.groupClients._GroupLabelText = "Группа";
			this.groupClients._GroupNameColumnName = null;
			this.groupClients._GroupsLabelWidth = 46;
			this.groupClients._GroupsTable = null;
			this.groupClients._MemberID = -1;
			this.groupClients._MemberIDColumnName = null;
			this.groupClients._MemberNameColumnName = null;
			this.groupClients._MembersFilter = "";
			this.groupClients._MembersGroupColumnName = null;
			this.groupClients._MembersLabelText = "Клиент";
			this.groupClients._MembersLabelWidth = 48;
			this.groupClients._MembersTable = null;
			this.groupClients._SecondSpaceWidth = 12;
			this.groupClients._ThirdSpaceWidth = 5;
			this.groupClients._Vertical = false;
			this.groupClients.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupClients.Location = new System.Drawing.Point(2, 26);
			this.groupClients.Name = "groupClients";
			this.groupClients.Size = new System.Drawing.Size(418, 24);
			this.groupClients.TabIndex = 2;
			this.groupClients.ClientIDChanged += new BPS._Forms.Clients.ClientIDChangedEventHandler(this.groupClients_ClientIDChanged);
			// 
			// pnlCurrencyTo
			// 
			this.pnlCurrencyTo.Controls.Add(this.cmbCurrencyTo);
			this.pnlCurrencyTo.Controls.Add(this.label8);
			this.pnlCurrencyTo.Location = new System.Drawing.Point(420, 52);
			this.pnlCurrencyTo.Name = "pnlCurrencyTo";
			this.pnlCurrencyTo.Size = new System.Drawing.Size(118, 26);
			this.pnlCurrencyTo.TabIndex = 8;
			// 
			// cmbCurrencyTo
			// 
			this.cmbCurrencyTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCurrencyTo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cmbCurrencyTo.Location = new System.Drawing.Point(58, 2);
			this.cmbCurrencyTo.MaxLength = 3;
			this.cmbCurrencyTo.Name = "cmbCurrencyTo";
			this.cmbCurrencyTo.Size = new System.Drawing.Size(58, 21);
			this.cmbCurrencyTo.TabIndex = 9;
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label8.Location = new System.Drawing.Point(2, 6);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(56, 16);
			this.label8.TabIndex = 8;
			this.label8.Text = "в валюту:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// err
			// 
			this.err.ContainerControl = this;
			// 
			// ClientRequestEdit
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(544, 429);
			this.Controls.Add(this.pnlCurrencyTo);
			this.Controls.Add(this.groupClients);
			this.Controls.Add(this.pnlPurpose);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.pnlVAT);
			this.Controls.Add(this.tbSum);
			this.Controls.Add(this.tbVAT);
			this.Controls.Add(this.tbRemarks);
			this.Controls.Add(this.label16);
			this.Controls.Add(this.cmbCurrencyFrom);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.gbInner);
			this.Controls.Add(this.gbCorr);
			this.Controls.Add(this.dateTimePicker1);
			this.Controls.Add(this.cmbReqTypes);
			this.Controls.Add(this.bnCancel);
			this.Controls.Add(this.bnOk);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Menu = this.mnuMain;
			this.Name = "ClientRequestEdit";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Заявка";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.ClientRequestEdit_Closing);
			this.Load += new System.EventHandler(this.ClientRequestEdt_Load);
			this.Closed += new System.EventHandler(this.ClientRequestEdit_Closed);
			((System.ComponentModel.ISupportInitialize)(this.dvReqTypes)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsReqTypes1)).EndInit();
			this.gbCorr.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dvPrevOrgAccount)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsPrevClientRequest1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvPrevOrg)).EndInit();
			this.gbInner.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dvOrgInner)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsOrgsClients1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvOrgAccountInner)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsOrgsAccount1)).EndInit();
			this.pnlVAT.ResumeLayout(false);
			this.pnlPurpose.ResumeLayout(false);
			this.pnlCurrencyTo.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void ClientRequestEdt_Load(object sender, System.EventArgs e)
		{
			this.groupClients._MembersFilter = "IsInner=false AND IsSpecial=false";
			bDontEdit=false;
			this.bIsLoaded = true;
			if(bIsEdit)
			{				
				this.FillControls();
				if ( bDontEdit=(this.rwClRq.RequestStateID >1 || !this.checkRequest(this.rwClRq.RequestID)) )
				{
					this.Text += " [Только чтение]";
					this.dateTimePicker1.Enabled =
					this.cmbReqTypes.Enabled =
					this.groupClients.Enabled = 
						this.gbCorr.Enabled = 
						this.gbInner.Enabled = 
						this.pnlPurpose.Enabled = 
						this.pnlVAT.Enabled = 
						this.pnlCurrencyTo.Enabled = 
						this.cmbCurrencyFrom.Enabled = 
						false;
					this.tbSum.ReadOnly = true;

				}

			}
			else  
			{
				this.groupClients._MemberID = -1;
				SelectClientHistory(this.groupClients._MemberID);
				cmbReqTypes.SelectedIndex=0;
				SetViewStyleForReqType(1);
				this.cmbCurrencyFrom.SelectedValue = "RUR";
					this.cmbCurrencyTo.SelectedValue = "USD";
				OnClientChange();
			}
		}

		private bool bNotAsk=false;

		private void bnCancel_Click(object sender, System.EventArgs e)
		{
			if(MessageBox.Show("Вы действительно хотите отменить редактирование?", "BPS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
			{
				return;
			}
			bNotAsk=true;
			this.Close();
		}

		private void bnOk_Click(object sender, System.EventArgs e)
		{
			if (Store()) 
			{
				bNotAsk=true;
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}

		private bool Store()
		{
			if(!this.validateRequest())
				return false;
			this.setRow();
			if (!this.bIsEdit) 
			{
				rwClRq.ExecutedSum=0;
				rwClRq.ClientGroupID = 0;
				rwClRq.ClientGroupName="";
				rwClRq.Table.Rows.Add(rwClRq);
			}
			this.Memorize();
			return true;
		}

		private bool checkRequest(int iReqID)
		{
			cmdCheckRequest.Parameters["@ReqID"].Value = iReqID;
			object o = AM_Lib.sqlData.ExecuteScalar(cmdCheckRequest);;
			if ( o ==Convert.DBNull)	return false;
			if ((int) o > 1)			return false;
			return true;
		}

		private void setRow()
		{
			if(this.tbRemarks.Text.Trim().Length>0)
				this.rwClRq.Remarks = this.tbRemarks.Text.Trim();
			else
				this.rwClRq.SetRemarksNull();

			if (!this.bIsEdit) 
			{
				this.rwClRq.RequestStateID = 1;
				this.rwClRq.RequestStateName = "Принята";
			}

			if (!bDontEdit)	// Изменения не допускаются
			{
				this.rwClRq.ClientID = groupClients._MemberID;
				this.rwClRq.RequestTypeID = Convert.ToInt32(this.cmbReqTypes.SelectedValue);
				
				this.rwClRq.RequestTypeName = this.cmbReqTypes.Text;
				this.rwClRq.ClientName = this.groupClients._MemberName;

				this.rwClRq.RequestDate =AM_Lib.DateBuilder.ClearTime(this.dateTimePicker1.Value);
				this.rwClRq.RequestSum = this.tbSum.dValue;

				if(this.tbPurpose.Text.Length>0)
					this.rwClRq.Purpose = this.tbPurpose.Text.Trim();
				else
					this.rwClRq.SetPurposeNull();

				if(this.tbBankCorr.Text.Length >0)
					this.rwClRq.BankName = this.tbBankCorr.Text;
				if(this.tbBIKCorr.Text.Length>0)
					this.rwClRq.CodeBIK = this.tbBIKCorr.Text;
				if(this.tbVAT.Text.Length >0)
					this.rwClRq.VAT = this.tbVAT.dValue;

				if( rwClRq.RequestTypeID == 1)
				{
					this.rwClRq.OrgToINN = this.tbINNInner.Text;
					this.rwClRq.OrgToKPP = this.tbKPPInner.Text;
					this.rwClRq.OrgTo = this.cmbOrgInner.Text;
					this.rwClRq.AccountTo = this.cmbOrgAccountInner.Text;
					this.rwClRq.CurrencyTo = "RUR";


					this.rwClRq.OrgFromINN = this.tbINNCorr.Text;
					this.rwClRq.OrgFromKPP = this.tbKPPCorr.Text;
					this.rwClRq.OrgFrom = this.cmbOrgCorr.Text;
					this.rwClRq.AccountFrom = this.cmbOrgAccountCorr.Text;
					this.rwClRq.CurrencyFrom = "RUR";
				}
				else if( rwClRq.RequestTypeID == 2)
				{
					this.rwClRq.OrgToINN = this.tbINNCorr.Text;
					this.rwClRq.OrgToKPP = this.tbKPPCorr.Text;
					this.rwClRq.OrgTo = this.cmbOrgCorr.Text;
					this.rwClRq.AccountTo = this.cmbOrgAccountCorr.Text;
					this.rwClRq.CurrencyTo = "RUR";


					this.rwClRq.OrgFromINN = this.tbINNInner.Text;
					this.rwClRq.OrgFromKPP = this.tbKPPInner.Text;
					this.rwClRq.OrgFrom = this.cmbOrgInner.Text;
					this.rwClRq.AccountFrom = this.cmbOrgAccountInner.Text;
					this.rwClRq.CurrencyFrom = "RUR";
				}
				else if(rwClRq.RequestTypeID == 3)
				{
					this.rwClRq.CurrencyFrom = 
						this.rwClRq.CurrencyTo = this.cmbCurrencyFrom.Text;
				}
				else if(rwClRq.RequestTypeID == 4)
				{
					this.rwClRq.CurrencyFrom = this.cmbCurrencyFrom.Text;
					this.rwClRq.CurrencyTo = this.cmbCurrencyTo.Text;
				}
			}

		}


		private bool ShowErr( Control c, string s)
		{
			if (s.Length>0) 
			{
				AM_Controls.MsgBoxX.Show(s);
				c.Focus();
				this.err.SetError(c,s);
				return false;
			}
			else
			{
				this.err.SetError(c,"");
				return true;
			}
		}


		private bool ValidateCorr()
		{
			if(!this.cmbOrgAccountCorr.Validate())
			{
				return false;
			}

			if (!this.tbINNCorr.Validate())
			{
				return false;
			}

			if (!this.tbKPPCorr.Validate())
			{
				return false;
			}
			
			if (!this.tbBIKCorr.Validate())
			{
				return false;
			}

			return 
				ShowErr(this.cmbOrgCorr, this.cmbOrgCorr.Text.Trim().Length==0?"Введите или выберите название огранизации":"")

			&&	ShowErr(this.tbBankCorr, this.tbBankCorr.Text.Trim().Length==0?"Введите название банка":"")
			
			&&	ShowErr(this.cmbOrgInner, this.cmbOrgInner.SelectedIndex<0?"Выберите название огранизации":"")
			
			&&	ShowErr(this.cmbOrgAccountInner,this.cmbOrgAccountInner.SelectedIndex<0?"Укажите р.счет огранизации":"");
			
			//return true;
		}


		private bool validateRequest()
		{
			if (this.groupClients._MemberID <=0) 
			{
				AM_Controls.MsgBoxX.Show("Выберите клиента","BPS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				this.groupClients.Focus();
				return false;
			}

			if(this.tbSum.dValue <= 0)
			{
				AM_Controls.MsgBoxX.Show("Введите сумму.","BPS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				this.tbSum.Focus();
				return false;
			}
			switch(Convert.ToInt32(this.cmbReqTypes.SelectedValue))
			{
				case 1:
				case 2:
					if (!ValidateCorr())
							return false;
				  break;
				case 3:
					if(this.cmbCurrencyFrom.SelectedIndex == -1)
					{
						AM_Controls.MsgBoxX.Show("Укажите валюту.", "BPS", MessageBoxButtons.OK,MessageBoxIcon.Warning);
						this.cmbCurrencyFrom.Focus();
						return false;
					}
					break;
				case 4:
					DataRow [] dr = App.DsCurr.Currencies.Select("IsBase=true");
					if(dr.Length == 1)
					{
						if(((this.cmbCurrencyTo.Text != dr[0]["CurrencyID"].ToString()) && (this.cmbCurrencyFrom.Text != dr[0]["CurrencyID"].ToString())) || 
						   ((this.cmbCurrencyTo.Text == dr[0]["CurrencyID"].ToString()) && (this.cmbCurrencyFrom.Text == dr[0]["CurrencyID"].ToString())))
						{
							AM_Controls.MsgBoxX.Show("Конвертация может производиться или из базовой валюты, или в базовую валюту. Базовая валюта - " + dr[0]["CurrencyID"].ToString(), "BPS", MessageBoxButtons.OK,MessageBoxIcon.Warning);
							this.cmbCurrencyFrom.Focus();
							return false;
						}
					}
					if(this.cmbCurrencyTo.SelectedIndex == -1)
					{
						AM_Controls.MsgBoxX.Show("Укажите валюту.", "BPS", MessageBoxButtons.OK,MessageBoxIcon.Warning);
						this.cmbCurrencyTo.Focus();
						return false;
					}
					if(this.cmbCurrencyFrom.SelectedIndex == -1)
					{
						AM_Controls.MsgBoxX.Show("Укажите валюту.", "BPS", MessageBoxButtons.OK,MessageBoxIcon.Warning);
						this.cmbCurrencyFrom.Focus();
						return false;
					}
					break;
			}
			return true;
		}
		

		private void FillControls()
		{
			this.groupClients._MemberID = rwClRq.ClientID;
			this.cmbReqTypes.SelectedValue = rwClRq.RequestTypeID;

			FillOrgsClient(rwClRq.ClientID);		// Выбрать огранизации конторы, доступные клиенту
			SelectClientHistory(rwClRq.ClientID);	// Выбрать историю корреспондентов для данного клиента
			SetFiltersForReqType(rwClRq.RequestTypeID);
			SetViewStyleForReqType(rwClRq.RequestTypeID);

			this.dateTimePicker1.Value = rwClRq.RequestDate;

			this.tbSum.dValue = rwClRq.RequestSum;

			if(!rwClRq.IsRemarksNull())
				this.tbRemarks.Text = rwClRq.Remarks;
			if(!rwClRq.IsPurposeNull())
				this.tbPurpose.Text = rwClRq.Purpose;
			if(!rwClRq.IsBankNameNull())
				this.tbBankCorr.Text = rwClRq.BankName;
			if(!rwClRq.IsCodeBIKNull())
				this.tbBIKCorr.Text = rwClRq.CodeBIK;
			if(!rwClRq.IsVATNull())
				this.tbVAT.dValue = rwClRq.VAT;

			if(rwClRq.RequestTypeID == 1)		// Принять
			{
				if(!rwClRq.IsOrgFromKPPNull())
					this.tbKPPCorr.Text = rwClRq.OrgFromKPP;
				if(!rwClRq.IsOrgFromINNNull()) 
				{
					this.cmbOrgCorr.SelectedValue = rwClRq.OrgFromINN;
					this.tbINNCorr.Text = rwClRq.OrgFromINN;
						
				}
				if(!rwClRq.IsOrgFromNull())
					this.cmbOrgCorr.Text = rwClRq.OrgFrom;
				if(!rwClRq.IsAccountFromNull()) 
				{
					this.cmbOrgAccountCorr.SelectedValue = rwClRq.AccountFrom;
					this.cmbOrgAccountCorr.Text = rwClRq.AccountFrom;
				}
				

				if(!rwClRq.IsOrgToNull())
					this.cmbOrgInner.SelectedIndex = this.cmbOrgInner.FindString(rwClRq.OrgTo);

				this.setOrgAccountIn();
				if(!rwClRq.IsAccountToNull())
					this.cmbOrgAccountInner.SelectedValue =rwClRq.AccountTo;
			}
			else if (rwClRq.RequestTypeID == 2) // Отправить
			{
				if(!rwClRq.IsOrgToKPPNull())
					this.tbKPPCorr.Text = rwClRq.OrgToKPP;
				if(!rwClRq.IsOrgToINNNull()) 
				{
					this.cmbOrgCorr.SelectedValue =rwClRq.OrgToINN;
					this.tbINNCorr.Text = rwClRq.OrgToINN;

				}
				if(!rwClRq.IsOrgToNull())
					this.cmbOrgCorr.Text = rwClRq.OrgTo;
				if(!rwClRq.IsAccountToNull()) 
				{
					this.cmbOrgAccountCorr.SelectedValue = rwClRq.AccountTo;
					this.cmbOrgAccountCorr.Text = rwClRq.AccountTo;
				}
				
				if(!rwClRq.IsOrgFromNull())
					this.cmbOrgInner.SelectedIndex = this.cmbOrgInner.FindString(rwClRq.OrgFrom);

				this.setOrgAccountIn();
				if(!rwClRq.IsAccountFromNull())
					this.cmbOrgAccountInner.SelectedValue = rwClRq.AccountFrom;

			}

			else if(rwClRq.RequestTypeID == 3)
			{
				if(!rwClRq.IsCurrencyToNull()) 
				{
					this.cmbCurrencyTo.SelectedValue = 
					this.cmbCurrencyFrom.SelectedValue = rwClRq.CurrencyFrom;
				}
			}
			else if(rwClRq.RequestTypeID == 4)
			{
				if(!rwClRq.IsCurrencyFromNull())
					this.cmbCurrencyFrom.SelectedValue = rwClRq.CurrencyFrom;
				if(!rwClRq.IsCurrencyToNull())
					this.cmbCurrencyTo.SelectedValue = rwClRq.CurrencyTo;
			}

		}



		private void cmbOrgInner_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.setOrgAccountIn();
		}

		private void setOrgAccountIn()
		{
			if(this.cmbOrgInner.SelectedIndex>-1)
			{
				this.dvOrgAccountInner.RowFilter = "OrgID=" + this.cmbOrgInner.SelectedValue.ToString();
				cmbOrgAccountIn_SelectedIndexChanged(null, null);
				this.tbINNInner.Text = this.dvOrgInner[this.cmbOrgInner.SelectedIndex]["CodeINN"].ToString();
				this.tbKPPInner.Text = this.dvOrgInner[this.cmbOrgInner.SelectedIndex]["CodeKPP"].ToString();
				if(this.cmbOrgAccountInner.SelectedIndex>-1)
				{
//					this.tbCurrInner.Text = this.dvOrgAccountInner[this.cmbOrgAccountInner.SelectedIndex]["CurrencyID"].ToString();
				}
			}
			else
			{
				this.tbINNInner.Text = "";
				this.tbKPPInner.Text = "";
				this.cmbOrgAccountInner.SelectedIndex= -1;
				if ( this.dsOrgsAccount1.OrgsAccounts.Count>0)
					this.dvOrgAccountInner.RowFilter = " OrgID= -1";
//				this.tbCurrInner.Text = "";
				this.tbBankInner.Text = "";
				this.tbBIKInner.Text = "";
			}
		}

		private void cmbOrgAccountIn_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.cmbOrgAccountInner.SelectedIndex>-1)
			{
//				this.tbCurrInner.Text = this.dvOrgAccountInner[this.cmbOrgAccountInner.SelectedIndex]["CurrencyID"].ToString();
				object oBank = this.dvOrgAccountInner[this.cmbOrgAccountInner.SelectedIndex]["BankID"];
				if(oBank == Convert.DBNull)
				{
					this.tbBankInner.Text = "";
					this.tbBIKInner.Text = "";
					return;
				}
				DataRow [] dr = App.DsBanks.Banks.Select("BankID=" + oBank.ToString());
				if(dr.Length>0)
				{
					this.tbBankInner.Text = dr[0]["BankName"].ToString();
					this.tbBIKInner.Text = dr[0]["CodeBIK"].ToString();
				}
			}
		}

		private void FillOrgsClient(int nClientID)
		{
			App.bllClients.GetAvailableOrgs(nClientID,this.dsOrgsClients1);
		}

		private void SetInnerOrgsFilter(int nReqType)
		{
			string sFilter="";
			if (nReqType==1) 
				sFilter = "Direction=0";
			else if (nReqType==2) 
				sFilter = "Direction=1";
			if (sFilter.Length>0)
				 sFilter += (!this.bIsEdit ? " AND IsAvailable=true AND IsRemoved=false":"");

			this.dvOrgInner.RowFilter = sFilter;
			if (this.dvOrgInner.Count>0)
				this.cmbOrgInner.SelectedIndex=0;
			else
				this.cmbOrgInner.SelectedIndex=-1;
			this.cmbOrgInner_SelectedIndexChanged(null,null);
		}	
	

		private void ShowClientsHistory(int nReqType)
		{
			if( nReqType < 3)
			{
				//				this.SelectClientHistory();
				this.dvPrevOrg.RowFilter = "RequestTypeID=" + nReqType.ToString();
				if(this.dvPrevOrg.Count == 0)
				{
					this.cmbOrgCorr.Text = "";
					this.cmbOrgAccountCorr.Text = "";
					this.tbBankCorr.Text = "";
					this.tbBIKCorr.Text = "";
					this.tbINNCorr.Text = "";
					this.tbKPPCorr.Text = "";
					this.cmbOrgCorr.SelectedIndex=-1;
				}
				else
					this.cmbOrgCorr.SelectedIndex=0;
				this.cmbOrgCorr_SelectedIndexChanged(null,null);
			}
			else 
			{
				this.cmbOrgCorr.Text = "";
				this.cmbOrgAccountCorr.Text = "";
				this.tbBankCorr.Text = "";
				this.tbBIKCorr.Text = "";
				this.tbINNCorr.Text = "";
				this.tbKPPCorr.Text = "";
			}
		}
		

		private void SelectClientHistory(int nClientID)
		{
			try
			{
				this.dsPrevClientRequest1.GetPrevOrg.Clear();
				this.dsPrevClientRequest1.GetPrevOrgAccount.Clear();
				this.daPrevOrg.SelectCommand.Parameters["@ClientID"].Value = nClientID;
				this.daPrevOrg.Fill(this.dsPrevClientRequest1.GetPrevOrg);
				this.daPrevOrgAccount.SelectCommand.Parameters["@ClientID"].Value = nClientID;
				this.daPrevOrgAccount.Fill(this.dsPrevClientRequest1.GetPrevOrgAccount);
			}
			catch(Exception ex)
			{
				AM_Controls.MsgBoxX.Show(ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}


		private bool bOrgChanged;
		private bool bAccChanged;

		private void cmbOrgCorr_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (bOrgClientInnerChanging)
				return;
			if ( bAccChanged ) 
			{
				if(this.cmbOrgCorr.SelectedValue != null)
				{
					this.tbINNCorr.Text = this.cmbOrgCorr.SelectedValue.ToString();
					this.tbINNCorr.ResetChanged();
					BindingManagerBase bm = this.BindingContext[dvPrevOrg];
					this.tbKPPCorr.Text = ((DataRowView)bm.Current).Row["KPP"].ToString();
				}
				return;
			}
			
			if(this.cmbOrgCorr.SelectedIndex>-1 )
			{
				bOrgChanged = true;
				this.dvPrevOrgAccount.RowFilter = 
					"RequestTypeID=" + this.cmbReqTypes.SelectedValue.ToString() +
					" AND (Org='" + this.cmbOrgCorr.Text + "' OR INN='"+ 
					(this.cmbOrgCorr.SelectedValue!=null?this.cmbOrgCorr.SelectedValue.ToString():"")+"')";
				bOrgChanged = false;
				if (this.dvPrevOrgAccount.Count>0)
					cmbOrgAccountCorr.SelectedIndex=0;
				else 
				{
					cmbOrgAccountCorr.SelectedIndex=-1;
					this.cmbOrgAccountCorr.Text = "";
				}
				cmbOrgAccountCorr_SelectedIndexChanged(null, null);
				if(this.cmbOrgCorr.SelectedValue != null)
				{
					this.tbINNCorr.Text = this.cmbOrgCorr.SelectedValue.ToString();
					this.tbINNCorr.ResetChanged();
					this.tbKPPCorr.Text = ((DataRowView)this.cmbOrgCorr.SelectedItem).Row["KPP"].ToString();
				}
				
			}
			else 
			{
				this.dvPrevOrgAccount.RowFilter = "Org='?'";
			}
		}

		private void cmbOrgAccountCorr_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.tbBankCorr.Text = "";
			this.tbBIKCorr.Text = "";
			if(this.cmbOrgAccountCorr.SelectedIndex > -1)
			{
				if (!bOrgChanged)
				{
					int i = this.cmbOrgCorr.FindString(this.dvPrevOrgAccount[this.cmbOrgAccountCorr.SelectedIndex]["Org"].ToString());
					bAccChanged = true;
					this.cmbOrgCorr.SelectedIndex = this.cmbOrgCorr.FindString(this.dvPrevOrgAccount[this.cmbOrgAccountCorr.SelectedIndex]["Org"].ToString());
					bAccChanged = false;
					this.tbINNCorr.Text = this.dvPrevOrg[this.cmbOrgCorr.SelectedIndex]["INN"].ToString();
				}
					cmbOrgAccountCorr.Text=cmbOrgAccountCorr.SelectedValue.ToString();
					if(this.dvPrevOrgAccount[this.cmbOrgAccountCorr.SelectedIndex]["BankName"] != Convert.DBNull)
						this.tbBankCorr.Text = this.dvPrevOrgAccount[this.cmbOrgAccountCorr.SelectedIndex]["BankName"].ToString();
					if(this.dvPrevOrgAccount[this.cmbOrgAccountCorr.SelectedIndex]["CodeBIK"] != Convert.DBNull)
						this.tbBIKCorr.Text = this.dvPrevOrgAccount[this.cmbOrgAccountCorr.SelectedIndex]["CodeBIK"].ToString();
			}
		}

		private bool bOrgTextChanged;
		private bool bOrgClientInnerChanging;
		private void tbINNCorr_Leave(object sender, System.EventArgs e)
		{
			if (!this.tbINNCorr.Changed)	// Changed сбрасывается при входе в TextBoxV
				return;
			if(this.tbINNCorr.Text.Length == 0)
			{
				return;
			}
			if (!bOrgTextChanged) 
			{
				bOrgClientInnerChanging = true;
				this.cmbOrgCorr.SelectedValue = this.tbINNCorr.Text;
				if(this.dvPrevOrg.Table.Select("INN = '" + this.tbINNCorr.Text + "'").Length > 0)
				{
					bOrgClientInnerChanging = false;
					this.cmbOrgCorr_SelectedIndexChanged(this, null);
				}
				else
				{
					clearCorrAccount();
					this.cmbOrgCorr.Text = "";
					bOrgClientInnerChanging = false;
					bOrgChanged = true;	
					this.dvPrevOrgAccount.RowFilter = "RequestTypeID=" + this.cmbReqTypes.SelectedValue.ToString() + " AND Org = '" + this.cmbOrgCorr.Text + "'";
				}
			}
		}
		
		private void cmbOrgCorr_TextChanged(object sender, System.EventArgs e)
		{
			bOrgTextChanged=true;
		}

		private void cmbOrgCorr_Enter(object sender, System.EventArgs e)
		{
			bOrgTextChanged=false;
		}

		private void cmbOrgCorr_Leave(object sender, System.EventArgs e)
		{
			if(this.cmbOrgCorr.SelectedIndex == -1 && bOrgTextChanged )
			{
				if (!this.tbINNCorr.Changed)
					this.tbINNCorr.Text = "";
				this.clearCorrAccount();
				bOrgChanged = true;	
//				this.dvPrevOrgAccount.RowFilter = "RequestTypeID=" + this.cmbReqTypes.SelectedValue.ToString();
				bOrgChanged = false;	
//				this.bIsShowAllAccounts = true;
			}
		}
		private void clearCorrAccount()
		{
//			this.tbINNCorr.Text = "";
		//	this.cmbOrgAccountCorr.Text = "";
			this.dvPrevOrgAccount.RowFilter = 
				"RequestTypeID=" + this.cmbReqTypes.SelectedValue.ToString() +
				" and Org='" + this.cmbOrgCorr.Text + "'";
			this.cmbOrgAccountCorr.SelectedIndex = -1;
			this.cmbOrgAccountCorr.Text="";
			this.tbBankCorr.Text = "";
			this.tbBIKCorr.Text = "";
//			this.tbPurpose.Text = "";
		}

		private void cmbOrgAccountCorr_Leave(object sender, System.EventArgs e)
		{
			if(this.cmbOrgAccountCorr.SelectedIndex == -1)
			{
				this.tbBankCorr.Text = "";
				this.tbBIKCorr.Text = "";
			}
		}


		private void ClientRequestEdit_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (bNotAsk)// || (rwClRq.RequestStateID > 1))
				return;
			if(this.bIsEdit && (rwClRq.RequestStateID > 1))
				return;
			DialogResult res = AM_Controls.MsgBoxX.Show("Сохранить изменения?", "BPS", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
			if ( res == DialogResult.Yes) 
			{
				if (!Store())
					e.Cancel = true;
			}
			else if (res == DialogResult.Cancel)
				e.Cancel = true;
			
		}

		private void ClientRequestEdit_Closed(object sender, System.EventArgs e)
		{
			if(this.bIsEdit)
				App.LockStatusChange(4, this.rwClRq.RequestID, false);
		}

		private string removeVAT(string szPurpose )
		{
			string szPP = szPurpose.ToUpper();
			int iLastIndex = szPP.LastIndexOf("В Т.Ч. НДС");
			if(iLastIndex < 0)
				iLastIndex = szPP.LastIndexOf("НДС НЕ");
			if(iLastIndex >= 0)
				szPurpose = szPurpose.Substring(0, iLastIndex);
			return szPurpose ;
		}

		private void AddVATText()
		{
//			if (this.tbVAT.dValue>0) 
			{
				if (this.tbSum.dValue<0.005) 
				{
					AM_Controls.MsgBoxX.Show("Введите сумму");
					this.tbSum.Focus();
					return;
				}
//				double dVATSum = Math.Round(this.tbSum.dValue *this.tbVAT.dValue /(1+this.tbVAT.dValue),2);
//				this.tbPurpose.Text = this.tbPurpose.Text + " НДС " + dVATSum.ToString("0.00")+"руб.";


				if (cmbVAT.Text=="Не облагается") 
				{
					this.tbPurpose.Text += "НДС не облагается.";
				}
				else
				{
					int nPcntPos = cmbVAT.Text.IndexOf("%");
					this.tbVAT.Text = cmbVAT.Text.Substring(0,nPcntPos);
					double dVATSum = Math.Round(this.tbSum.dValue *this.tbVAT.dValue /(1+this.tbVAT.dValue),2);
					this.tbPurpose.Text = this.tbPurpose.Text + "В т.ч. НДС (" + tbVAT.Text + "%) " + dVATSum.ToString("0.00")+"руб.";
				}

			}
		}

		private void mnuVAT_Click(object sender, System.EventArgs e)
		{
			this.tbPurpose.Text = removeVAT(this.tbPurpose.Text);
				AddVATText();		
		}

		private void btnPlusVAT_Click(object sender, System.EventArgs e)
		{
			this.tbPurpose.Text = removeVAT(this.tbPurpose.Text);
				AddVATText();		
		}

		private void tbVAT_TextChanged(object sender, System.EventArgs e)
		{
			if(this.tbVAT.dValue>1)
				this.tbVAT.dValue = 0.2;
		}

		private void btnLastPurpose_Click(object sender, System.EventArgs e)
		{
			if ( this.cmbOrgAccountCorr.SelectedIndex <0) 
			{
				AM_Controls.MsgBoxX.Show("Не указан р.счет");
				this.cmbOrgAccountCorr.Focus();
				return;
			}
			if ( this.cmbOrgAccountInner.SelectedIndex <0) 
			{
				AM_Controls.MsgBoxX.Show("Не указан р.счет");
				this.cmbOrgAccountInner.Focus();
				return;
			}
			int nRqType = Convert.ToInt32(this.cmbReqTypes.SelectedValue);
			sqlSelLastPurpose.Parameters["@ClientID"].Value = (int)groupClients._MemberID;
			sqlSelLastPurpose.Parameters["@RequestID"].Value = this.rwClRq.RequestID;
			sqlSelLastPurpose.Parameters["@AccountFrom"].Value = nRqType==1? this.cmbOrgAccountCorr.Text : this.cmbOrgAccountInner.Text;
			sqlSelLastPurpose.Parameters["@AccountTo"].Value   = nRqType==1? this.cmbOrgAccountInner.Text: this.cmbOrgAccountCorr.Text;
			if ( AM_Lib.sqlData.ExecuteNonQuery(sqlSelLastPurpose ) ) 
			{
				this.tbPurpose.Text = sqlSelLastPurpose.Parameters["@Purpose"].Value.ToString();
				string sz = this.removeVAT(this.tbPurpose.Text);
				if (sz!=this.tbPurpose.Text) 
					if (this.tbSum.dValue>0.005) 
					{
						this.tbPurpose.Text = sz;
						AddVATText();		
					}
			}
		}


		
		////////////////////////////////////////////////////////////////////////////////////////////////////////

		private void SetViewStyleForReqType(int iReqType)
		{
			switch(iReqType)
			{
				case 1:	
					this.gbCorr.Visible = true;
					this.gbCorr.Location = p1;
					this.gbCorr.Text = "Плательщик";

					this.gbInner.Visible = true;
					this.gbInner.Location = p2;
					this.gbInner.Text = "Получатель";

					this.pnlVAT.Visible = true;
					this.pnlPurpose.Visible = true;

					this.cmbCurrencyFrom.SelectedValue = "RUR";
					this.cmbCurrencyFrom.Enabled = false;

					this.pnlCurrencyTo.Visible = false;
					
					break;
				case 2:
					this.gbInner.Visible = true;
					this.gbInner.Location = p1;
					this.gbInner.Text = "Плательщик";

					this.gbCorr.Visible = true;
					this.gbCorr.Location = p2;
					this.gbCorr.Text = "Получатель";

					this.pnlVAT.Visible = true;
					this.pnlPurpose.Visible = true;

					this.cmbCurrencyFrom.SelectedValue = "RUR";
					this.cmbCurrencyFrom.Enabled = false;
					this.pnlCurrencyTo.Visible = false;
					break;
				case 3:
					this.gbInner.Visible = false;
					this.gbInner.Location = p1;
					this.gbInner.Text = "Плательщик";

					this.gbCorr.Visible = false;
					this.gbCorr.Location = p2;
					this.gbCorr.Text = "Получатель";

					this.pnlVAT.Visible = false;
					this.pnlPurpose.Visible = false;

					this.cmbCurrencyFrom.Enabled = true;
					this.cmbCurrencyFrom.SelectedValue = "RUR";

					this.pnlCurrencyTo.Visible = false;
					break;
				case 4:
					this.gbInner.Visible = false;
					this.gbInner.Location = p1;
					this.gbInner.Text = "Плательщик";

					this.gbCorr.Visible = false;
					this.gbCorr.Location = p2;
					this.gbCorr.Text = "Получатель";

					this.pnlVAT.Visible = false;
					this.pnlPurpose.Visible = false;

					this.cmbCurrencyFrom.Enabled = true;
					this.cmbCurrencyFrom.SelectedValue = "RUR";

					this.pnlCurrencyTo.Visible = true;
					break;
			}

		}


		private void groupClients_ClientIDChanged(object sender, System.EventArgs e)
		{
			if(this.bIsLoaded)
			{
				OnClientChange();
			}
		}

		private void OnClientChange()
		{
			if(this.bIsLoaded)
			{
//				if (this.groupClients._MemberID != -1) 
				FillOrgsClient(groupClients._MemberID);		// Выбрать огранизации конторы, доступные клиенту
				
				SelectClientHistory(this.groupClients._MemberID);	// Выбрать историю корреспондентов для данного клиента
				SetFiltersForReqType((int)cmbReqTypes.SelectedValue);
				}
		}

		private void SetFiltersForReqType(int nReqType)
		{
			SetInnerOrgsFilter(nReqType);
			
			this.ShowClientsHistory(nReqType);
		}


		private void cmbReqTypes_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.bIsLoaded)
			{
				int nReqType = (int)cmbReqTypes.SelectedValue;
				SetViewStyleForReqType(nReqType);
				SetFiltersForReqType(nReqType);
			}
		}

	}
}
