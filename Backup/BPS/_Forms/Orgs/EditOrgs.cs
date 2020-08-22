using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using AM_Controls;
using System.Data;
using System.Data.SqlClient;

namespace BPS._Forms.Orgs
{
	/// <summary>
	/// Summary description for EditOrgs.
	/// </summary>
	public class EditOrgs : System.Windows.Forms.Form
	{
		public string OrgName {set {this.tbName.Text = value;} get {return this.tbName.Text;}}
		public string INN { set {this.tbINN.Text = value;}}
		public int OrgID { get {return this.drowOrg.OrgID;} }

		internal System.Windows.Forms.TextBox tbName;
		internal System.Windows.Forms.CheckBox cbInner;
		internal System.Windows.Forms.CheckBox cbNormal;
		internal AM_Controls.TextBoxV tbCharge;
		internal AM_Controls.TextBoxV tbINN;
		internal AM_Controls.TextBoxV tbKPP;
		internal System.Windows.Forms.TextBox tbAdrReg;
		internal System.Windows.Forms.TextBox tbAdrFact;
		private System.Windows.Forms.Label label1;
		internal AM_Controls.TextBoxV tbOKPO;
		internal AM_Controls.TextBoxV tbOKONH;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		internal System.Windows.Forms.TextBox tbCPerson;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		internal System.Windows.Forms.TextBox tbPhone1;
		internal System.Windows.Forms.TextBox tbPhone2;
		internal System.Windows.Forms.TextBox tbFax1;
		internal System.Windows.Forms.TextBox tbFax2;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		internal System.Windows.Forms.CheckBox cbIsSpecial;
		private System.ComponentModel.IContainer components;
		private bool bIsEdit;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		internal System.Windows.Forms.TextBox tbName2;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Panel pnlOrgAcc;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.ToolBarButton tbbNew;
		private System.Windows.Forms.ToolBarButton tbbEdit;
		private System.Windows.Forms.ToolBarButton tbbDel;
		private System.Windows.Forms.GroupBox gbOrgType;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem mnuNew;
		private System.Windows.Forms.MenuItem mnuEdit;
		private System.Windows.Forms.MenuItem mnuDel;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem mnuAcc;
		internal int iClientID = -1;
		private System.Windows.Forms.ErrorProvider err;
		private System.Windows.Forms.Button bnLink;
		private System.Windows.Forms.TextBox tbClientName;
		private System.Windows.Forms.Button bnClose;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lblAccounts;

		private BPS.BLL.Orgs.DataSets.dsOrgsAccounts.OrgsAccountsRow rwCurrentAccRow;
		private BLL.Orgs.DataSets.dsOrgs.OrgsRow drowOrg;

		private BPS.BLL.Orgs.DataSets.dsOrgsAccounts dsOrgsAccounts1;
		private BPS.BLL.Orgs.coOrgAccount coOrgAccount1;
		private AM_Controls.MenuItemImageProvider MenuItemImageProvider1;
		private BPS.BLL.Orgs.coOrgs bllOrgs;
		

		public EditOrgs(BLL.Orgs.DataSets.dsOrgs.OrgsRow rw)
		{
			bllOrgs = App.bllOrgs;
			this.drowOrg = rw;
			this.bIsEdit = (rw.RowState != DataRowState.Detached);
			
			if (rw.RowState == DataRowState.Detached) this.drowOrg.OrgID =0; // Mike 07.10.03

			InitializeComponent();
			if(drowOrg.IsSpecial)
			{
				this.bnLink.Visible = true;			
				this.tbClientName.Visible = true;
//				this.lbClient.Visible = true;
			}
			this.tbName.Text = drowOrg.OrgName;
			if(!drowOrg.IsOrgName2Null())
				this.tbName2.Text = drowOrg.OrgName2;
			if(!drowOrg.IsAddrRegNull())
				this.tbAdrReg.Text = drowOrg.AddrReg;
			if(!drowOrg.IsAddrFactNull())
				this.tbAdrFact.Text = drowOrg.AddrFact;
			if (!drowOrg.IsDefaultServiceChargeNull())
				this.tbCharge.dValue = drowOrg.DefaultServiceCharge;
			if(!drowOrg.IsContactPersonNull())
				this.tbCPerson.Text = drowOrg.ContactPerson;
			if(!drowOrg.IsFax1Null())
				this.tbFax1.Text = drowOrg.Fax1;
			if(!drowOrg.IsFax2Null())
				this.tbFax2.Text = drowOrg.Fax2;
			
			this.tbINN.Text = drowOrg.CodeINN;
			if(!drowOrg.IsCodeKPPNull())
				this.tbKPP.Text = drowOrg.CodeKPP;
			if(!drowOrg.IsOKONHNull())
				this.tbOKONH.Text = drowOrg.OKONH;
			if(!drowOrg.IsOKPONull())
				this.tbOKPO.Text = drowOrg.OKPO;
			if(!drowOrg.IsPhone1Null())
				this.tbPhone1.Text = drowOrg.Phone1;
			if(!drowOrg.IsPhone2Null())
				this.tbPhone2.Text = drowOrg.Phone2;
			if(!drowOrg.IsClientNameNull())
				this.tbClientName.Text = drowOrg.ClientName;
			this.cbInner.Checked = drowOrg.IsInner;
			this.cbNormal.Checked = drowOrg.IsNormal;
			this.cbIsSpecial.Checked = drowOrg.IsSpecial;

			this.tbCharge.Enabled = this.cbIsSpecial.Checked ;

			App.SetDataGridTableStyle(this.dataGridTableStyle1);
			App.Clone(this.mnuAcc.MenuItems, this.contextMenu1);

			coOrgAccount1 = App.bllOrgs.Accounts;
			coOrgAccount1.Fill(drowOrg.OrgID);
			this.dsOrgsAccounts1 = coOrgAccount1.DataSet;
			this.dataGrid1.DataSource = this.dsOrgsAccounts1;

			this.BindingContext[this.dsOrgsAccounts1, "OrgsAccounts"].CurrentChanged += new EventHandler(OnChangeOrgAcc);
			BindingManagerBase bm = (BindingManagerBase)this.BindingContext[this.dsOrgsAccounts1, "OrgsAccounts"];
			if (bm.Count>0)
				rwCurrentAccRow = (BPS.BLL.Orgs.DataSets.dsOrgsAccounts.OrgsAccountsRow)((DataRowView)bm.Current).Row;
			else
				rwCurrentAccRow = null;

		}

		private void EditOrgs_Load(object sender, System.EventArgs e)
		{
			if (drowOrg.RowState == DataRowState.Detached)	// новая запись
			{
				this.Text += " [Новая]";
				pnlOrgAcc.Enabled = false;
			}
			else	// Редактируемая запись
			{
				this.Text += " [Редактирование]";
				pnlOrgAcc.Enabled = true;
			}
		}

		public static int AddOrgDialog(BPS.BLL.Orgs.coOrgs bll, string sName, string sINN)
		{
			BLL.Orgs.DataSets.dsOrgs.OrgsRow rw = bll.DataSet.Orgs.NewOrgsRow();
			rw.OrgName = sName;
			rw.CodeINN= sINN;
			rw.IsInner =
				rw.IsNormal =
			rw.IsSpecial = false;
			EditOrgs dlg = new EditOrgs(rw);
			dlg.ShowDialog();
			if(dlg.DialogResult == DialogResult.OK)
				return dlg.OrgID;
			else
				return -1;

/*
 			if(dlg.DialogResult == DialogResult.OK)
			{
				bll.DataSet.Orgs.AddOrgsRow(rw);
				bll.Update();
				return true;
			}
			return false;
*/
		}


		public void OnChangeOrgAcc(object sender, EventArgs e)
		{
			BindingManagerBase bm = (BindingManagerBase)this.BindingContext[this.dsOrgsAccounts1, "OrgsAccounts"];
			if (bm.Count>0)
				rwCurrentAccRow = (BPS.BLL.Orgs.DataSets.dsOrgsAccounts.OrgsAccountsRow)((DataRowView)bm.Current).Row;
			else
				rwCurrentAccRow = null;

			this.mnuDel.Enabled = this.mnuEdit.Enabled = 
				this.tbbDel.Enabled = this.tbbEdit.Enabled = 
				rwCurrentAccRow != null;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(EditOrgs));
			this.tbName = new System.Windows.Forms.TextBox();
			this.cbInner = new System.Windows.Forms.CheckBox();
			this.cbNormal = new System.Windows.Forms.CheckBox();
			this.tbCharge = new AM_Controls.TextBoxV();
			this.tbINN = new AM_Controls.TextBoxV();
			this.tbKPP = new AM_Controls.TextBoxV();
			this.tbAdrReg = new System.Windows.Forms.TextBox();
			this.tbAdrFact = new System.Windows.Forms.TextBox();
			this.gbOrgType = new System.Windows.Forms.GroupBox();
			this.cbIsSpecial = new System.Windows.Forms.CheckBox();
			this.label13 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.tbOKPO = new AM_Controls.TextBoxV();
			this.tbOKONH = new AM_Controls.TextBoxV();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.tbFax2 = new System.Windows.Forms.TextBox();
			this.tbFax1 = new System.Windows.Forms.TextBox();
			this.tbPhone2 = new System.Windows.Forms.TextBox();
			this.tbPhone1 = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.tbCPerson = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.tbName2 = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.mnuNew = new System.Windows.Forms.MenuItem();
			this.mnuEdit = new System.Windows.Forms.MenuItem();
			this.mnuDel = new System.Windows.Forms.MenuItem();
			this.dsOrgsAccounts1 = new BPS.BLL.Orgs.DataSets.dsOrgsAccounts();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.pnlOrgAcc = new System.Windows.Forms.Panel();
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.tbbNew = new System.Windows.Forms.ToolBarButton();
			this.tbbEdit = new System.Windows.Forms.ToolBarButton();
			this.tbbDel = new System.Windows.Forms.ToolBarButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.lblAccounts = new System.Windows.Forms.Label();
			this.bnClose = new System.Windows.Forms.Button();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.mnuAcc = new System.Windows.Forms.MenuItem();
			this.err = new System.Windows.Forms.ErrorProvider();
			this.bnLink = new System.Windows.Forms.Button();
			this.tbClientName = new System.Windows.Forms.TextBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.MenuItemImageProvider1 = new AM_Controls.MenuItemImageProvider();
			this.gbOrgType.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsOrgsAccounts1)).BeginInit();
			this.pnlOrgAcc.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbName
			// 
			this.tbName.Location = new System.Drawing.Point(102, 38);
			this.tbName.MaxLength = 256;
			this.tbName.Name = "tbName";
			this.tbName.Size = new System.Drawing.Size(394, 21);
			this.tbName.TabIndex = 2;
			this.tbName.Text = "";
			// 
			// cbInner
			// 
			this.cbInner.Location = new System.Drawing.Point(96, 14);
			this.cbInner.Name = "cbInner";
			this.cbInner.Size = new System.Drawing.Size(56, 14);
			this.cbInner.TabIndex = 1;
			this.cbInner.Text = "Своя";
			// 
			// cbNormal
			// 
			this.cbNormal.Checked = true;
			this.cbNormal.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbNormal.Location = new System.Drawing.Point(8, 14);
			this.cbNormal.Name = "cbNormal";
			this.cbNormal.Size = new System.Drawing.Size(74, 14);
			this.cbNormal.TabIndex = 2;
			this.cbNormal.Text = "IsNormal";
			// 
			// tbCharge
			// 
			this.tbCharge.AllowDrop = true;
			this.tbCharge.dValue = 0;
			this.tbCharge.IsPcnt = true;
			this.tbCharge.Location = new System.Drawing.Point(368, 10);
			this.tbCharge.MaxDecPos = 2;
			this.tbCharge.MaxPos = 8;
			this.tbCharge.Name = "tbCharge";
			this.tbCharge.Negative = System.Drawing.Color.Empty;
			this.tbCharge.nValue = ((long)(0));
			this.tbCharge.Positive = System.Drawing.Color.Empty;
			this.tbCharge.Size = new System.Drawing.Size(58, 21);
			this.tbCharge.TabIndex = 3;
			this.tbCharge.Text = "";
			this.tbCharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbCharge.TextMode = false;
			this.tbCharge.Zero = System.Drawing.Color.Empty;
			// 
			// tbINN
			// 
			this.tbINN.AllowDrop = true;
			this.tbINN.dValue = 0;
			this.tbINN.IsPcnt = false;
			this.tbINN.Location = new System.Drawing.Point(102, 82);
			this.tbINN.MaxDecPos = 0;
			this.tbINN.MaxLength = 12;
			this.tbINN.MaxPos = 12;
			this.tbINN.Name = "tbINN";
			this.tbINN.Negative = System.Drawing.Color.Empty;
			this.tbINN.nValue = ((long)(0));
			this.tbINN.Positive = System.Drawing.Color.Empty;
			this.tbINN.Size = new System.Drawing.Size(132, 21);
			this.tbINN.TabIndex = 6;
			this.tbINN.Text = "";
			this.tbINN.TextMode = true;
			this.tbINN.Zero = System.Drawing.Color.Empty;
			// 
			// tbKPP
			// 
			this.tbKPP.AllowDrop = true;
			this.tbKPP.dValue = 0;
			this.tbKPP.IsPcnt = false;
			this.tbKPP.Location = new System.Drawing.Point(364, 82);
			this.tbKPP.MaxDecPos = 0;
			this.tbKPP.MaxLength = 9;
			this.tbKPP.MaxPos = 9;
			this.tbKPP.Name = "tbKPP";
			this.tbKPP.Negative = System.Drawing.Color.Empty;
			this.tbKPP.nValue = ((long)(0));
			this.tbKPP.Positive = System.Drawing.Color.Empty;
			this.tbKPP.Size = new System.Drawing.Size(132, 21);
			this.tbKPP.TabIndex = 8;
			this.tbKPP.Text = "";
			this.tbKPP.TextMode = true;
			this.tbKPP.Zero = System.Drawing.Color.Empty;
			// 
			// tbAdrReg
			// 
			this.tbAdrReg.Location = new System.Drawing.Point(102, 104);
			this.tbAdrReg.MaxLength = 255;
			this.tbAdrReg.Name = "tbAdrReg";
			this.tbAdrReg.Size = new System.Drawing.Size(394, 21);
			this.tbAdrReg.TabIndex = 10;
			this.tbAdrReg.Text = "";
			// 
			// tbAdrFact
			// 
			this.tbAdrFact.Location = new System.Drawing.Point(102, 126);
			this.tbAdrFact.MaxLength = 255;
			this.tbAdrFact.Name = "tbAdrFact";
			this.tbAdrFact.Size = new System.Drawing.Size(394, 21);
			this.tbAdrFact.TabIndex = 12;
			this.tbAdrFact.Text = "";
			// 
			// gbOrgType
			// 
			this.gbOrgType.Controls.Add(this.cbInner);
			this.gbOrgType.Controls.Add(this.cbNormal);
			this.gbOrgType.Controls.Add(this.cbIsSpecial);
			this.gbOrgType.Controls.Add(this.tbCharge);
			this.gbOrgType.Controls.Add(this.label13);
			this.gbOrgType.Controls.Add(this.label14);
			this.gbOrgType.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbOrgType.Location = new System.Drawing.Point(0, 0);
			this.gbOrgType.Name = "gbOrgType";
			this.gbOrgType.Size = new System.Drawing.Size(630, 34);
			this.gbOrgType.TabIndex = 0;
			this.gbOrgType.TabStop = false;
			// 
			// cbIsSpecial
			// 
			this.cbIsSpecial.Location = new System.Drawing.Point(196, 14);
			this.cbIsSpecial.Name = "cbIsSpecial";
			this.cbIsSpecial.Size = new System.Drawing.Size(72, 14);
			this.cbIsSpecial.TabIndex = 2;
			this.cbIsSpecial.Text = "IsSpecial";
			this.cbIsSpecial.CheckedChanged += new System.EventHandler(this.cbIsSpecial_CheckedChanged);
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(282, 12);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(86, 16);
			this.label13.TabIndex = 2;
			this.label13.Text = "Обслуживание:";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(426, 12);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(20, 18);
			this.label14.TabIndex = 14;
			this.label14.Text = "%";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(10, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(84, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Наименование:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tbOKPO
			// 
			this.tbOKPO.AllowDrop = true;
			this.tbOKPO.dValue = 0;
			this.tbOKPO.IsPcnt = false;
			this.tbOKPO.Location = new System.Drawing.Point(102, 244);
			this.tbOKPO.MaxDecPos = 0;
			this.tbOKPO.MaxLength = 50;
			this.tbOKPO.MaxPos = 50;
			this.tbOKPO.Name = "tbOKPO";
			this.tbOKPO.Negative = System.Drawing.Color.Empty;
			this.tbOKPO.nValue = ((long)(0));
			this.tbOKPO.Positive = System.Drawing.Color.Empty;
			this.tbOKPO.Size = new System.Drawing.Size(134, 21);
			this.tbOKPO.TabIndex = 26;
			this.tbOKPO.Text = "";
			this.tbOKPO.TextMode = true;
			this.tbOKPO.Zero = System.Drawing.Color.Empty;
			// 
			// tbOKONH
			// 
			this.tbOKONH.AllowDrop = true;
			this.tbOKONH.dValue = 0;
			this.tbOKONH.IsPcnt = false;
			this.tbOKONH.Location = new System.Drawing.Point(102, 222);
			this.tbOKONH.MaxDecPos = 0;
			this.tbOKONH.MaxLength = 50;
			this.tbOKONH.MaxPos = 50;
			this.tbOKONH.Name = "tbOKONH";
			this.tbOKONH.Negative = System.Drawing.Color.Empty;
			this.tbOKONH.nValue = ((long)(0));
			this.tbOKONH.Positive = System.Drawing.Color.Empty;
			this.tbOKONH.Size = new System.Drawing.Size(134, 21);
			this.tbOKONH.TabIndex = 24;
			this.tbOKONH.Text = "";
			this.tbOKONH.TextMode = true;
			this.tbOKONH.Zero = System.Drawing.Color.Empty;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(52, 82);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(42, 16);
			this.label2.TabIndex = 5;
			this.label2.Text = "ИНН:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(324, 82);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(36, 23);
			this.label3.TabIndex = 7;
			this.label3.Text = "КПП:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(46, 248);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(46, 16);
			this.label4.TabIndex = 25;
			this.label4.Text = "ОКПО:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(46, 226);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(46, 16);
			this.label5.TabIndex = 23;
			this.label5.Text = "ОКОНХ:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tbFax2
			// 
			this.tbFax2.Location = new System.Drawing.Point(362, 198);
			this.tbFax2.MaxLength = 16;
			this.tbFax2.Name = "tbFax2";
			this.tbFax2.Size = new System.Drawing.Size(134, 21);
			this.tbFax2.TabIndex = 22;
			this.tbFax2.Text = "";
			// 
			// tbFax1
			// 
			this.tbFax1.Location = new System.Drawing.Point(362, 176);
			this.tbFax1.MaxLength = 16;
			this.tbFax1.Name = "tbFax1";
			this.tbFax1.Size = new System.Drawing.Size(134, 21);
			this.tbFax1.TabIndex = 20;
			this.tbFax1.Text = "";
			// 
			// tbPhone2
			// 
			this.tbPhone2.Location = new System.Drawing.Point(102, 198);
			this.tbPhone2.MaxLength = 16;
			this.tbPhone2.Name = "tbPhone2";
			this.tbPhone2.Size = new System.Drawing.Size(134, 21);
			this.tbPhone2.TabIndex = 18;
			this.tbPhone2.Text = "";
			// 
			// tbPhone1
			// 
			this.tbPhone1.Location = new System.Drawing.Point(102, 176);
			this.tbPhone1.MaxLength = 16;
			this.tbPhone1.Name = "tbPhone1";
			this.tbPhone1.Size = new System.Drawing.Size(134, 21);
			this.tbPhone1.TabIndex = 16;
			this.tbPhone1.Text = "";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(312, 202);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(44, 16);
			this.label12.TabIndex = 21;
			this.label12.Text = "Факс2:";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(312, 180);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(44, 16);
			this.label11.TabIndex = 19;
			this.label11.Text = "Факс1:";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(56, 202);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(38, 16);
			this.label10.TabIndex = 17;
			this.label10.Text = "Тел.2:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(54, 180);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(40, 16);
			this.label9.TabIndex = 15;
			this.label9.Text = "Тел.1:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tbCPerson
			// 
			this.tbCPerson.Location = new System.Drawing.Point(102, 154);
			this.tbCPerson.MaxLength = 50;
			this.tbCPerson.Name = "tbCPerson";
			this.tbCPerson.Size = new System.Drawing.Size(394, 21);
			this.tbCPerson.TabIndex = 14;
			this.tbCPerson.Text = "";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(18, 156);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(76, 16);
			this.label8.TabIndex = 13;
			this.label8.Text = "Конт-е лицо:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(14, 122);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(80, 16);
			this.label7.TabIndex = 11;
			this.label7.Text = "Факт-й адрес:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(24, 100);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(70, 16);
			this.label6.TabIndex = 9;
			this.label6.Text = "Юр-й адрес:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button1.Location = new System.Drawing.Point(380, 4);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(80, 26);
			this.button1.TabIndex = 27;
			this.button1.Text = "Сохранить";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button2.Location = new System.Drawing.Point(462, 4);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(80, 26);
			this.button2.TabIndex = 28;
			this.button2.Text = "Отменить";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// tbName2
			// 
			this.tbName2.Location = new System.Drawing.Point(102, 60);
			this.tbName2.MaxLength = 50;
			this.tbName2.Name = "tbName2";
			this.tbName2.Size = new System.Drawing.Size(394, 21);
			this.tbName2.TabIndex = 4;
			this.tbName2.Text = "";
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(4, 60);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(90, 16);
			this.label15.TabIndex = 3;
			this.label15.Text = "Наим. в пл.пор.:";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// dataGrid1
			// 
			this.dataGrid1.CaptionText = "Расчетные счета";
			this.dataGrid1.CaptionVisible = false;
			this.dataGrid1.ContextMenu = this.contextMenu1;
			this.dataGrid1.DataMember = "OrgsAccounts";
			this.dataGrid1.DataSource = this.dsOrgsAccounts1;
			this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(0, 44);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.ReadOnly = true;
			this.dataGrid1.Size = new System.Drawing.Size(626, 132);
			this.dataGrid1.TabIndex = 18;
			this.dataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																								  this.dataGridTableStyle1});
			// 
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.mnuNew,
																						 this.mnuEdit,
																						 this.mnuDel});
			// 
			// mnuNew
			// 
			this.mnuNew.Index = 0;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuNew, ((System.Drawing.Icon)(resources.GetObject("mnuNew.MenuItemImage"))));
			this.mnuNew.OwnerDraw = true;
			this.mnuNew.Shortcut = System.Windows.Forms.Shortcut.F3;
			this.mnuNew.Text = "Новый";
			this.mnuNew.Click += new System.EventHandler(this.mnuNew_Click);
			// 
			// mnuEdit
			// 
			this.mnuEdit.Index = 1;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuEdit, ((System.Drawing.Icon)(resources.GetObject("mnuEdit.MenuItemImage"))));
			this.mnuEdit.OwnerDraw = true;
			this.mnuEdit.Shortcut = System.Windows.Forms.Shortcut.F10;
			this.mnuEdit.Text = "Изменить";
			this.mnuEdit.Click += new System.EventHandler(this.mnuEdit_Click);
			// 
			// mnuDel
			// 
			this.mnuDel.Index = 2;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuDel, ((System.Drawing.Icon)(resources.GetObject("mnuDel.MenuItemImage"))));
			this.mnuDel.OwnerDraw = true;
			this.mnuDel.Shortcut = System.Windows.Forms.Shortcut.CtrlDel;
			this.mnuDel.Text = "Удалить";
			this.mnuDel.Click += new System.EventHandler(this.mnuDel_Click);
			// 
			// dsOrgsAccounts1
			// 
			this.dsOrgsAccounts1.DataSetName = "dsOrgsAccounts";
			this.dsOrgsAccounts1.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.DataGrid = this.dataGrid1;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn1,
																												  this.dataGridTextBoxColumn2,
																												  this.dataGridTextBoxColumn3,
																												  this.dataGridTextBoxColumn4,
																												  this.dataGridTextBoxColumn5});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "OrgsAccounts";
			// 
			// dataGridTextBoxColumn1
			// 
			this.dataGridTextBoxColumn1.Format = "";
			this.dataGridTextBoxColumn1.FormatInfo = null;
			this.dataGridTextBoxColumn1.HeaderText = "Расчетный счет";
			this.dataGridTextBoxColumn1.MappingName = "RAccount";
			this.dataGridTextBoxColumn1.NullText = "-";
			this.dataGridTextBoxColumn1.Width = 130;
			// 
			// dataGridTextBoxColumn2
			// 
			this.dataGridTextBoxColumn2.Format = "";
			this.dataGridTextBoxColumn2.FormatInfo = null;
			this.dataGridTextBoxColumn2.HeaderText = "БИК";
			this.dataGridTextBoxColumn2.MappingName = "CodeBIK";
			this.dataGridTextBoxColumn2.NullText = "-";
			this.dataGridTextBoxColumn2.Width = 65;
			// 
			// dataGridTextBoxColumn3
			// 
			this.dataGridTextBoxColumn3.Format = "";
			this.dataGridTextBoxColumn3.FormatInfo = null;
			this.dataGridTextBoxColumn3.HeaderText = "Банк";
			this.dataGridTextBoxColumn3.MappingName = "BankName";
			this.dataGridTextBoxColumn3.NullText = "-";
			this.dataGridTextBoxColumn3.Width = 150;
			// 
			// dataGridTextBoxColumn4
			// 
			this.dataGridTextBoxColumn4.Format = "";
			this.dataGridTextBoxColumn4.FormatInfo = null;
			this.dataGridTextBoxColumn4.HeaderText = "Город";
			this.dataGridTextBoxColumn4.MappingName = "CityName";
			this.dataGridTextBoxColumn4.NullText = "-";
			this.dataGridTextBoxColumn4.Width = 90;
			// 
			// dataGridTextBoxColumn5
			// 
			this.dataGridTextBoxColumn5.Format = "";
			this.dataGridTextBoxColumn5.FormatInfo = null;
			this.dataGridTextBoxColumn5.HeaderText = "Корр.счет";
			this.dataGridTextBoxColumn5.MappingName = "KAccount";
			this.dataGridTextBoxColumn5.Width = 130;
			// 
			// pnlOrgAcc
			// 
			this.pnlOrgAcc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlOrgAcc.Controls.Add(this.dataGrid1);
			this.pnlOrgAcc.Controls.Add(this.toolBar1);
			this.pnlOrgAcc.Controls.Add(this.lblAccounts);
			this.pnlOrgAcc.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlOrgAcc.Location = new System.Drawing.Point(0, 275);
			this.pnlOrgAcc.Name = "pnlOrgAcc";
			this.pnlOrgAcc.Size = new System.Drawing.Size(630, 180);
			this.pnlOrgAcc.TabIndex = 19;
			// 
			// toolBar1
			// 
			this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.tbbNew,
																						this.tbbEdit,
																						this.tbbDel});
			this.toolBar1.ButtonSize = new System.Drawing.Size(90, 22);
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.ImageList = this.imageList1;
			this.toolBar1.Location = new System.Drawing.Point(0, 16);
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(626, 28);
			this.toolBar1.TabIndex = 19;
			this.toolBar1.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			// 
			// tbbNew
			// 
			this.tbbNew.ImageIndex = 0;
			this.tbbNew.Text = "Новый";
			// 
			// tbbEdit
			// 
			this.tbbEdit.ImageIndex = 1;
			this.tbbEdit.Text = "Изменить";
			// 
			// tbbDel
			// 
			this.tbbDel.ImageIndex = 3;
			this.tbbDel.Text = "Удалить";
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// lblAccounts
			// 
			this.lblAccounts.BackColor = System.Drawing.SystemColors.Highlight;
			this.lblAccounts.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblAccounts.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblAccounts.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.lblAccounts.Location = new System.Drawing.Point(0, 0);
			this.lblAccounts.Name = "lblAccounts";
			this.lblAccounts.Size = new System.Drawing.Size(626, 16);
			this.lblAccounts.TabIndex = 30;
			this.lblAccounts.Text = "Расчетные счета организации";
			// 
			// bnClose
			// 
			this.bnClose.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.bnClose.Location = new System.Drawing.Point(548, 4);
			this.bnClose.Name = "bnClose";
			this.bnClose.Size = new System.Drawing.Size(80, 26);
			this.bnClose.TabIndex = 29;
			this.bnClose.Text = "Закрыть";
			this.bnClose.Click += new System.EventHandler(this.bnClose_Click);
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.mnuAcc});
			// 
			// mnuAcc
			// 
			this.mnuAcc.Index = 0;
			this.MenuItemImageProvider1.SetMenuItemImage(this.mnuAcc, null);
			this.mnuAcc.OwnerDraw = true;
			this.mnuAcc.Text = "Счет";
			this.mnuAcc.Visible = false;
			// 
			// err
			// 
			this.err.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
			this.err.ContainerControl = this;
			// 
			// bnLink
			// 
			this.bnLink.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.bnLink.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.bnLink.Location = new System.Drawing.Point(288, 244);
			this.bnLink.Name = "bnLink";
			this.bnLink.Size = new System.Drawing.Size(70, 22);
			this.bnLink.TabIndex = 29;
			this.bnLink.Text = "Клиент";
			this.bnLink.Visible = false;
			this.bnLink.Click += new System.EventHandler(this.button3_Click);
			// 
			// tbClientName
			// 
			this.tbClientName.BackColor = System.Drawing.Color.Gainsboro;
			this.tbClientName.Location = new System.Drawing.Point(362, 244);
			this.tbClientName.Name = "tbClientName";
			this.tbClientName.ReadOnly = true;
			this.tbClientName.Size = new System.Drawing.Size(134, 21);
			this.tbClientName.TabIndex = 30;
			this.tbClientName.Text = "";
			this.tbClientName.Visible = false;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.bnClose);
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 455);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(630, 32);
			this.panel1.TabIndex = 31;
			// 
			// MenuItemImageProvider1
			// 
			this.MenuItemImageProvider1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.MenuItemImageProvider1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.MenuItemImageProvider1.HighliteColor = System.Drawing.Color.Lavender;
			this.MenuItemImageProvider1.SelectionColor = System.Drawing.Color.Lavender;
			this.MenuItemImageProvider1.SideColor = System.Drawing.Color.Gainsboro;
			// 
			// EditOrgs
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(630, 487);
			this.Controls.Add(this.tbClientName);
			this.Controls.Add(this.bnLink);
			this.Controls.Add(this.pnlOrgAcc);
			this.Controls.Add(this.gbOrgType);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.tbPhone1);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.tbCPerson);
			this.Controls.Add(this.tbPhone2);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.tbFax1);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.tbFax2);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.tbName2);
			this.Controls.Add(this.tbName);
			this.Controls.Add(this.tbAdrReg);
			this.Controls.Add(this.tbAdrFact);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.tbINN);
			this.Controls.Add(this.tbKPP);
			this.Controls.Add(this.tbOKONH);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.tbOKPO);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Menu = this.mainMenu1;
			this.MinimizeBox = false;
			this.Name = "EditOrgs";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Организация";
			this.Load += new System.EventHandler(this.EditOrgs_Load);
			this.gbOrgType.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsOrgsAccounts1)).EndInit();
			this.pnlOrgAcc.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void button1_Click(object sender, System.EventArgs e)
		{
			StoreData();
		}

		private bool StoreData()
		{

			if(!this.validateOrg())
				return false;
			if(this.bIsEdit)
			{
				if(this.cbIsSpecial.Checked && drowOrg.IsClientIDNull())
				{
					AM_Controls.MsgBoxX.Show("Cпециальная организация должна быть связана со специальным клиентом.\n Воспользуйтесь кнопкой <Клиент> для задания связи с клиентом.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return false;
				}
			}
			else
			{
				if(this.cbIsSpecial.Checked && !this.linkedClient())
					return false;
			}
			this.setRW();
			if(!this.bIsEdit)
				bllOrgs.DataSet.Orgs.AddOrgsRow( this.drowOrg );
			this.bllOrgs.Update();

			this.bIsEdit = true;
			this.pnlOrgAcc.Enabled = 
				this.lblAccounts.Enabled = 
				this.toolBar1.Enabled = true;
			return true;
		}


		private void setRW()
		{
			if(tbAdrFact.Text.Length>0)
				drowOrg.AddrFact = tbAdrFact.Text;
			if(tbAdrReg.Text.Length>0)
				drowOrg.AddrReg = tbAdrReg.Text;
			if(tbINN.Text.Length>0)
				drowOrg.CodeINN = tbINN.Text;
			if(tbKPP.Text.Length>0)
				drowOrg.CodeKPP = tbKPP.Text;
			if(tbCPerson.Text.Length>0)
				drowOrg.ContactPerson =tbCPerson.Text;
			drowOrg.DefaultServiceCharge = tbCharge.dValue;
			if(tbFax1.Text.Length>0)
				drowOrg.Fax1 = tbFax1.Text;
			if(tbFax2.Text.Length>0)
				drowOrg.Fax2 = tbFax2.Text;
			drowOrg.IsInner = cbInner.Checked;
			drowOrg.IsNormal = cbNormal.Checked;
			drowOrg.IsSpecial = cbIsSpecial.Checked;
			if(tbOKONH.Text.Length>0)
				drowOrg.OKONH = tbOKONH.Text;
			if(tbOKPO.Text.Length>0)
				drowOrg.OKPO = tbOKPO.Text;
			drowOrg.OrgName = tbName.Text;
			drowOrg.OrgName2 = tbName2.Text;
			if(tbPhone1.Text.Length>0)
				drowOrg.Phone1 = tbPhone1.Text;
			if(tbPhone2.Text.Length>0)
				drowOrg.Phone2 = tbPhone2.Text;
			if(!drowOrg.IsSpecial)
			{
				drowOrg.SetClientIDNull();
				drowOrg.SetClientNameNull();
			}
			else 
				drowOrg.ClientName = getOrgName();
			
			
		}


		private string getOrgName()
		{
			string szName="";
		
			object o = AM_Lib.sqlData.ExecuteScalar("SELECT ClientName From Clients WHERE ClientID=" + drowOrg.ClientID);
			if(o != null && o != Convert.DBNull)
				szName = o.ToString();
			
			return szName;
		}


		private void button2_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}


		private void trimOrgName()
		{
			this.tbName.Text = this.tbName.Text.Trim(new char[]{'"',' ','<','>','\''});
			this.tbName.Text = this.tbName.Text.TrimStart(new char[]{'"',' ','<','>','\'','.',',','[',']','{','}','(',')',':',';','?','/','!','@','#','$','%','^','&','*'});
		}

		private bool validateOrg()
		{
			this.trimOrgName();
			
			this.err.Dispose();
			this.err = new System.Windows.Forms.ErrorProvider();
			this.err.BlinkStyle  = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;

			if(this.tbName.Text.Length == 0)
			{
				MsgBoxX.Show("Заполните поле НАИМЕНОВАНИЕ","BPS", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				this.tbName.Focus();
				this.err.SetError(this.tbName,"Заполните поле");
				return false;
			}
			
			if((this.tbINN.Text.Length < 10) || (this.tbINN.Text.Length >12))
			{
				MsgBoxX.Show("ИНН должен содержать от 10 до 12 цифр.","BPS", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				this.tbINN.Focus();
				this.err.SetError(this.tbINN,"ИНН должен содержать от 10 до 12 цифр.");
				return false;
			}

			if(!this.checkINN())
				return false;
				if (this.tbKPP.Text.Length != 9)
				{
					AM_Controls.MsgBoxX.Show("КПП должен содержать 9 цифр.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					this.tbKPP.Focus();
					this.err.SetError(this.tbKPP,"КПП должен содержать 9 цифр.");
					return false;
				}


			return true;
		}


		private bool checkINN()
		{
			DataRow [] dr = bllOrgs.DataSet.Orgs.Select("CodeINN='" + this.tbINN.Text + "'");
			if(dr.Length>0)
			{
				BLL.Orgs.DataSets.dsOrgs.OrgsRow rwOrg = (BLL.Orgs.DataSets.dsOrgs.OrgsRow) dr[0];
				if(this.bIsEdit)
				{
					if(this.drowOrg.OrgID != rwOrg.OrgID)
					{
						this.err.SetError(this.tbINN,"Такой ИНН уже занят");
						AM_Controls.MsgBoxX.Show("Невозможно изменить ИНН организации на " + this.tbINN.Text + ". Данный ИНН имеет организация <" + rwOrg.OrgName +
							"> c ID=" + rwOrg.OrgID.ToString() + ". Проверьте правильность реквизитов.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return false;
					}
				}
				else
				{
					this.err.SetError(this.tbINN,"Такой ИНН уже занят");
					AM_Controls.MsgBoxX.Show("Невозможно создать организацию с ИНН " + this.tbINN.Text + ". Данный ИНН имеет организация <" + rwOrg.OrgName +
						"> c ID=" + rwOrg.OrgID.ToString() + ". Проверьте правильность реквизитов.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return false;
				}
			}
			return true;
		}

		private void cbIsSpecial_CheckedChanged(object sender, System.EventArgs e)
		{
			this.tbCharge.Enabled = this.cbIsSpecial.Checked;
			if(this.bIsEdit)
			{
				this.bnLink.Visible = this.cbIsSpecial.Checked;
				this.tbClientName.Visible = this.cbIsSpecial.Checked;
//				this.lbClient.Visible = this.cbIsSpecial.Checked;
			}
		}

		private void OrgAccNew()
		{
			BPS._Forms.OrgAccountEdit oa = new _Forms.OrgAccountEdit();
			oa.OrgName = this.drowOrg.OrgName;
			oa.RAccount = "";
			oa.BankID = -1;
			oa.ShowDialog();
			if(oa.DialogResult == DialogResult.OK)
			{
				this.coOrgAccount1.Add(drowOrg.OrgID, oa.RAccount, oa.BankID, oa.CurrID, oa.OrgNameStr);
				coOrgAccount1.Fill(drowOrg.OrgID);
			}
		}

		private void OrgAccEdit()
		{
			BindingManagerBase bm = (BindingManagerBase)this.BindingContext[this.dsOrgsAccounts1, "OrgsAccounts"];
			if (bm.Count>0)
				rwCurrentAccRow = (BPS.BLL.Orgs.DataSets.dsOrgsAccounts.OrgsAccountsRow)((DataRowView)bm.Current).Row;
			else
				rwCurrentAccRow = null;
			if (rwCurrentAccRow == null)
				return;
			BPS._Forms.OrgAccountEdit oa = new _Forms.OrgAccountEdit();
			oa.OrgName = this.drowOrg.OrgName;
			oa.RAccount = rwCurrentAccRow.RAccount;
			oa.BankID = rwCurrentAccRow.BankID;
			if(!rwCurrentAccRow.IsOrgNameNull())
			{
				oa.OrgNameStr = rwCurrentAccRow.OrgName;
			}
			oa.ShowDialog();
			if(oa.DialogResult == DialogResult.OK)
			{
				this.coOrgAccount1.Update(rwCurrentAccRow.OrgsAccountsID, oa.RAccount, oa.BankID, oa.OrgNameStr);
				coOrgAccount1.Fill(drowOrg.OrgID);
			}
		}

		private void OrgAccDel()
		{
			BindingManagerBase bm = (BindingManagerBase)this.BindingContext[this.dsOrgsAccounts1, "OrgsAccounts"];
			if (bm.Count>0)
				rwCurrentAccRow = (BPS.BLL.Orgs.DataSets.dsOrgsAccounts.OrgsAccountsRow)((DataRowView)bm.Current).Row;
			else
				rwCurrentAccRow = null;
			if (rwCurrentAccRow == null)
				return;
			if (AM_Controls.MsgBoxX.Show("Удалить расчетный счет?", "BPS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes ) 
				{
					this.coOrgAccount1.Delete(rwCurrentAccRow.OrgsAccountsID);
					coOrgAccount1.Fill(drowOrg.OrgID);
				}
		}


		
		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if (e.Button == this.tbbNew)
				OrgAccNew();
			else if (e.Button == this.tbbEdit)
				OrgAccEdit();
			else if (e.Button == this.tbbDel)
				OrgAccDel();
		}

		private void mnuNew_Click(object sender, System.EventArgs e)
		{
			OrgAccNew();
		}

		private void mnuEdit_Click(object sender, System.EventArgs e)
		{
			OrgAccEdit();
		
		}

		private void mnuDel_Click(object sender, System.EventArgs e)
		{
			OrgAccDel();		
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			if(this.tbName.Text.Length == 0)
			{
				return;
			}
			this.linkedClient();
		}
		private bool linkedClient()
		{
			SpecialLink sp = new SpecialLink();
	//		sp.MdiParent = this.MdiParent.MdiParent;
			if(!drowOrg.IsClientIDNull())
				sp.ClientID = drowOrg.ClientID;
			sp.OrgName = this.tbName.Text;
			sp.ShowDialog();
			if(sp.DialogResult == DialogResult.OK)
			{
				if(sp.ClientID == -1)
				{
					AM_Controls.MsgBoxX.Show("При связывании организации со специальным клиентом произошла ошибка.");
					return false;
				}
				this.drowOrg.ClientID = sp.ClientID;
				this.drowOrg.ClientName = sp.ClientName;
				this.tbClientName.Text = sp.ClientName;
				return true;
			}else return false;
		}

		private void bnClose_Click(object sender, System.EventArgs e)
		{
			if (StoreData()) 
			{
				DialogResult = DialogResult.OK;
				this.Close();
			}
		}

	}
}
