using System;
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
	/// Summary description for Paym.
	/// </summary>
	public class AccountStatementPaymentEdit : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ComboBox cmbOrgFrom;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private AM_Controls.TextBoxV tbSum;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox cmbOrgAccount;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button bnOK;
		private System.Windows.Forms.Button bnCancel;
		private bool bIsLoaded = false;
		private System.Data.DataView dataView1;
		private System.Data.DataView dvOrgsFrom;
        private BPS.BLL.PaymentOrders.DataSets.dsPaymentOrderListX.AccountsStatementsRow rwe;
        private BPS.BLL.PaymentOrders.DataSets.dsPaymentOrderListX dsPaymList;
		private System.Windows.Forms.TextBox tbPurpose;
		private System.Windows.Forms.TextBox tbRemarks;
		private System.Windows.Forms.Label label11;
		private bool isAdding;
		private bool isInPaym;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox tbCurr;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
		private AM_Controls.TextBoxV tbINN;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button bnSelPurp;
		private System.Windows.Forms.TextBox tbBankName;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox tbKAccount;
		private System.Windows.Forms.TextBox tbBIK;
		private AM_Controls.TextBoxV tbVATSum;
		private AM_Controls.TextBoxV tbVAT;
		private System.Windows.Forms.Label label12;
		private System.Data.SqlClient.SqlCommand sqlCmdGetLastPurpose;
		private System.Data.SqlClient.SqlConnection sqlConnection1;
		private int m_OwnerOrgID		=0;
		private int m_OwnerOrgAccountID	=0;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox tbPOOrgName;
		private System.Windows.Forms.TextBox tbCodeKPP;
		private System.Windows.Forms.ComboBox cmbVAT;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AccountStatementPaymentEdit()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			
			this.isAdding = true;
			//App.FillOrgsAccount();
			
			this.dvOrgsFrom.Table	=App.DsOrgs.Orgs;
			this.dataView1.Table	=App.DsOrgsAccount.OrgsAccounts;
		
			//OrgFrom
			this.cmbOrgFrom.DataSource		=this.dvOrgsFrom;
			this.cmbOrgFrom.DisplayMember	="OrgName";
			this.cmbOrgFrom.ValueMember		="OrgID";
			
			//AccFrom
			this.cmbOrgAccount.DataSource		=this.dataView1;
			this.cmbOrgAccount.DisplayMember	="RAccount";
			this.cmbOrgAccount.ValueMember		="AccountID";

			this.cmbOrgAccount.SelectedIndex = -1;
			
			/*if(this.cmbOrgFrom.SelectedIndex > -1)
				this.dataView1.RowFilter = "OrgID=" + this.cmbOrgFrom.SelectedValue.ToString();*/
			
			if(this.cmbOrgAccount.SelectedIndex>-1)
				this.drawBankString(this.dataView1, this.cmbOrgAccount.SelectedIndex);
		}

        public AccountStatementPaymentEdit(BPS.BLL.PaymentOrders.DataSets.dsPaymentOrderListX.AccountsStatementsRow rw, bool isAdding, bool isInPaym)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			
			rwe = rw;
			this.isAdding = isAdding;
			this.isInPaym = isInPaym;
			
			//App.FillOrgsAccount();
			this.dvOrgsFrom.Table	=App.DsOrgs.Orgs;
			this.dataView1.Table	=App.DsOrgsAccount.OrgsAccounts;		
			
			//OrgFrom
			this.cmbOrgFrom.DataSource		=this.dvOrgsFrom;
			this.cmbOrgFrom.DisplayMember	="OrgName";
			this.cmbOrgFrom.ValueMember		="OrgID";
			
			//AccFrom
			this.cmbOrgAccount.DataSource		=this.dataView1;
			this.cmbOrgAccount.DisplayMember	="RAccount";
			this.cmbOrgAccount.ValueMember		="AccountID";
			this.cmbOrgAccount.SelectedIndex	=-1;
			
			if (this.cmbOrgAccount.SelectedIndex >-1)
				this.drawBankString(this.dataView1, this.cmbOrgAccount.SelectedIndex);
			
			if ( !this.isAdding)
			{				
				this.textBox1.Text			=rw.PaymentNo;
				this.dateTimePicker1.Value	=rw.PaymentOrderDate;
				this.tbSum.dValue		=rw.PaymentOrderSum;
				if ( !rw.IsPaymentOrderPurposeNull())
				{
					this.tbPurpose.Text = rw.PaymentOrderPurpose;
				}
				if ( !rw.IsRemarksNull())
					this.tbRemarks.Text = rw.Remarks;

				if ( !rw.Direction)
					this.radioButton2.Checked = true;
				else
					this.radioButton1.Checked = true;

				this.cmbOrgFrom.SelectedValue		=rw.OrgID;
				this.cmbOrgAccount.SelectedValue	=rw.AccountID;

				if ( !rw.Direction || isInPaym)
				{
					this.textBox1.ReadOnly			=true;
					this.dateTimePicker1.Enabled	=false;
					this.tbSum.ReadOnly			=true;
					this.groupBox1.Enabled			=false;
					this.tbPurpose.ReadOnly			=true;
				}
			}
			else
				this.dvOrgsFrom.RowFilter = "IsInner=false and IsRemoved=false";
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(AccountStatementPaymentEdit));
			System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
			this.cmbOrgFrom = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.tbSum = new AM_Controls.TextBoxV();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.tbCurr = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.tbVATSum = new AM_Controls.TextBoxV();
			this.cmbVAT = new System.Windows.Forms.ComboBox();
			this.tbVAT = new AM_Controls.TextBoxV();
			this.label6 = new System.Windows.Forms.Label();
			this.cmbOrgAccount = new System.Windows.Forms.ComboBox();
			this.label9 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.bnOK = new System.Windows.Forms.Button();
			this.bnCancel = new System.Windows.Forms.Button();
			this.dataView1 = new System.Data.DataView();
			this.dvOrgsFrom = new System.Data.DataView();
			this.tbPurpose = new System.Windows.Forms.TextBox();
			this.tbRemarks = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tbCodeKPP = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.tbPOOrgName = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.tbBIK = new System.Windows.Forms.TextBox();
			this.tbKAccount = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.tbBankName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tbINN = new AM_Controls.TextBoxV();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.bnSelPurp = new System.Windows.Forms.Button();
			this.sqlCmdGetLastPurpose = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvOrgsFrom)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmbOrgFrom
			// 
			this.cmbOrgFrom.Location = new System.Drawing.Point(76, 71);
			this.cmbOrgFrom.Name = "cmbOrgFrom";
			this.cmbOrgFrom.Size = new System.Drawing.Size(236, 22);
			this.cmbOrgFrom.TabIndex = 0;
			this.cmbOrgFrom.SelectedIndexChanged += new System.EventHandler(this.cmbOrgFrom_SelectedIndexChanged);
			this.cmbOrgFrom.Leave += new System.EventHandler(this.cmbOrgFrom_Leave);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 73);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(66, 18);
			this.label1.TabIndex = 1;
			this.label1.Text = "Орг-я:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dateTimePicker1.Location = new System.Drawing.Point(254, 3);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(96, 22);
			this.dateTimePicker1.TabIndex = 2;
			// 
			// tbSum
			// 
			this.tbSum.AllowDrop = true;
			this.tbSum.dValue = 0;
			this.tbSum.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbSum.IsPcnt = false;
			this.tbSum.Location = new System.Drawing.Point(138, 32);
			this.tbSum.MaxDecPos = 2;
			this.tbSum.MaxPos = 12;
			this.tbSum.Name = "tbSum";
			this.tbSum.nValue = ((long)(0));
			this.tbSum.Size = new System.Drawing.Size(160, 22);
			this.tbSum.TabIndex = 3;
			this.tbSum.Text = "";
			this.tbSum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbSum.TextMode = false;
			this.tbSum.Leave += new System.EventHandler(this.tbVAT_Leave);
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(227, 5);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(24, 18);
			this.label3.TabIndex = 4;
			this.label3.Text = "от:";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.Location = new System.Drawing.Point(8, 34);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(128, 18);
			this.label4.TabIndex = 4;
			this.label4.Text = "Сумма:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label5.Location = new System.Drawing.Point(8, 5);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(126, 18);
			this.label5.TabIndex = 4;
			this.label5.Text = "№ Пл. Поручения:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBox1
			// 
			this.textBox1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.textBox1.Location = new System.Drawing.Point(138, 3);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(86, 22);
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "";
			// 
			// panel1
			// 
			this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.tbCurr,
																				 this.textBox1,
																				 this.tbSum,
																				 this.label3,
																				 this.label5,
																				 this.dateTimePicker1,
																				 this.label4,
																				 this.label12,
																				 this.tbVATSum,
																				 this.cmbVAT});
			this.panel1.Location = new System.Drawing.Point(0, 62);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(370, 83);
			this.panel1.TabIndex = 0;
			// 
			// tbCurr
			// 
			this.tbCurr.Enabled = false;
			this.tbCurr.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbCurr.Location = new System.Drawing.Point(299, 32);
			this.tbCurr.Name = "tbCurr";
			this.tbCurr.ReadOnly = true;
			this.tbCurr.Size = new System.Drawing.Size(50, 22);
			this.tbCurr.TabIndex = 4;
			this.tbCurr.Text = "";
			this.tbCurr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(8, 58);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(128, 18);
			this.label12.TabIndex = 38;
			this.label12.Text = "НДС (Ставка/Сумма):";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbVATSum
			// 
			this.tbVATSum.AllowDrop = true;
			this.tbVATSum.dValue = 0;
			this.tbVATSum.IsPcnt = false;
			this.tbVATSum.Location = new System.Drawing.Point(254, 56);
			this.tbVATSum.MaxDecPos = 2;
			this.tbVATSum.MaxPos = 8;
			this.tbVATSum.Name = "tbVATSum";
			this.tbVATSum.nValue = ((long)(0));
			this.tbVATSum.ReadOnly = true;
			this.tbVATSum.Size = new System.Drawing.Size(96, 22);
			this.tbVATSum.TabIndex = 37;
			this.tbVATSum.Text = "";
			this.tbVATSum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbVATSum.TextMode = false;
			// 
			// cmbVAT
			// 
			this.cmbVAT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbVAT.Items.AddRange(new object[] {
														"0.00%",
														"10.00%",
														"20.00%",
														"Не облагается"});
			this.cmbVAT.Location = new System.Drawing.Point(138, 56);
			this.cmbVAT.Name = "cmbVAT";
			this.cmbVAT.Size = new System.Drawing.Size(114, 22);
			this.cmbVAT.TabIndex = 5;
			this.cmbVAT.SelectedIndexChanged += new System.EventHandler(this.cmbVAT_SelectedIndexChanged);
			// 
			// tbVAT
			// 
			this.tbVAT.AllowDrop = true;
			this.tbVAT.dValue = 0;
			this.tbVAT.IsPcnt = true;
			this.tbVAT.Location = new System.Drawing.Point(282, 14);
			this.tbVAT.MaxDecPos = 2;
			this.tbVAT.MaxPos = 8;
			this.tbVAT.Name = "tbVAT";
			this.tbVAT.nValue = ((long)(0));
			this.tbVAT.Size = new System.Drawing.Size(58, 22);
			this.tbVAT.TabIndex = 36;
			this.tbVAT.Text = "";
			this.tbVAT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbVAT.TextMode = false;
			this.tbVAT.Visible = false;
			this.tbVAT.Leave += new System.EventHandler(this.tbVAT_Leave);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 118);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(66, 18);
			this.label6.TabIndex = 7;
			this.label6.Text = "Р/С:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cmbOrgAccount
			// 
			this.cmbOrgAccount.Location = new System.Drawing.Point(76, 117);
			this.cmbOrgAccount.MaxLength = 20;
			this.cmbOrgAccount.Name = "cmbOrgAccount";
			this.cmbOrgAccount.Size = new System.Drawing.Size(236, 22);
			this.cmbOrgAccount.TabIndex = 2;
			this.cmbOrgAccount.SelectedIndexChanged += new System.EventHandler(this.cmbOrgAccount_SelectedIndexChanged);
			this.cmbOrgAccount.Leave += new System.EventHandler(this.cmbOrgAccount_Leave);
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(8, 141);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(66, 18);
			this.label9.TabIndex = 7;
			this.label9.Text = "Банк:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// button1
			// 
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button1.Image = ((System.Drawing.Bitmap)(resources.GetObject("button1.Image")));
			this.button1.Location = new System.Drawing.Point(313, 72);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(23, 20);
			this.button1.TabIndex = 1;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button2.Image = ((System.Drawing.Bitmap)(resources.GetObject("button2.Image")));
			this.button2.Location = new System.Drawing.Point(313, 118);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(23, 20);
			this.button2.TabIndex = 3;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// bnOK
			// 
			this.bnOK.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.bnOK.Location = new System.Drawing.Point(192, 496);
			this.bnOK.Name = "bnOK";
			this.bnOK.Size = new System.Drawing.Size(80, 26);
			this.bnOK.TabIndex = 4;
			this.bnOK.Text = "Сохранить";
			this.bnOK.Click += new System.EventHandler(this.bnOK_Click);
			// 
			// bnCancel
			// 
			this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.bnCancel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.bnCancel.Location = new System.Drawing.Point(274, 496);
			this.bnCancel.Name = "bnCancel";
			this.bnCancel.Size = new System.Drawing.Size(80, 26);
			this.bnCancel.TabIndex = 5;
			this.bnCancel.Text = "Отменить";
			this.bnCancel.Click += new System.EventHandler(this.bnCancel_Click);
			// 
			// tbPurpose
			// 
			this.tbPurpose.Location = new System.Drawing.Point(85, 394);
			this.tbPurpose.MaxLength = 256;
			this.tbPurpose.Multiline = true;
			this.tbPurpose.Name = "tbPurpose";
			this.tbPurpose.Size = new System.Drawing.Size(265, 45);
			this.tbPurpose.TabIndex = 2;
			this.tbPurpose.Text = "";
			// 
			// tbRemarks
			// 
			this.tbRemarks.Location = new System.Drawing.Point(85, 440);
			this.tbRemarks.Multiline = true;
			this.tbRemarks.Name = "tbRemarks";
			this.tbRemarks.Size = new System.Drawing.Size(265, 45);
			this.tbRemarks.TabIndex = 3;
			this.tbRemarks.Text = "";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(5, 442);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(79, 18);
			this.label11.TabIndex = 18;
			this.label11.Text = "Примечание:";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.tbCodeKPP,
																					this.label15,
																					this.tbPOOrgName,
																					this.label14,
																					this.tbBIK,
																					this.tbKAccount,
																					this.label8,
																					this.label7,
																					this.tbBankName,
																					this.label2,
																					this.tbINN,
																					this.cmbOrgFrom,
																					this.button1,
																					this.button2,
																					this.cmbOrgAccount,
																					this.label1,
																					this.label6,
																					this.label9});
			this.groupBox1.Location = new System.Drawing.Point(5, 146);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(344, 241);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Корреспондент";
			// 
			// tbCodeKPP
			// 
			this.tbCodeKPP.Location = new System.Drawing.Point(76, 48);
			this.tbCodeKPP.Name = "tbCodeKPP";
			this.tbCodeKPP.ReadOnly = true;
			this.tbCodeKPP.Size = new System.Drawing.Size(260, 22);
			this.tbCodeKPP.TabIndex = 20;
			this.tbCodeKPP.Text = "";
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(8, 51);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(66, 18);
			this.label15.TabIndex = 19;
			this.label15.Text = "КПП:";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbPOOrgName
			// 
			this.tbPOOrgName.Location = new System.Drawing.Point(76, 94);
			this.tbPOOrgName.Name = "tbPOOrgName";
			this.tbPOOrgName.ReadOnly = true;
			this.tbPOOrgName.Size = new System.Drawing.Size(260, 22);
			this.tbPOOrgName.TabIndex = 18;
			this.tbPOOrgName.Text = "";
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(8, 96);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(66, 18);
			this.label14.TabIndex = 17;
			this.label14.Text = "Орг-я П/П:";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbBIK
			// 
			this.tbBIK.Location = new System.Drawing.Point(76, 186);
			this.tbBIK.MaxLength = 20;
			this.tbBIK.Name = "tbBIK";
			this.tbBIK.ReadOnly = true;
			this.tbBIK.Size = new System.Drawing.Size(260, 22);
			this.tbBIK.TabIndex = 15;
			this.tbBIK.Text = "";
			// 
			// tbKAccount
			// 
			this.tbKAccount.Location = new System.Drawing.Point(76, 209);
			this.tbKAccount.MaxLength = 20;
			this.tbKAccount.Name = "tbKAccount";
			this.tbKAccount.ReadOnly = true;
			this.tbKAccount.Size = new System.Drawing.Size(260, 22);
			this.tbKAccount.TabIndex = 14;
			this.tbKAccount.Text = "";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(8, 188);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(66, 18);
			this.label8.TabIndex = 13;
			this.label8.Text = "БИК:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(8, 210);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(66, 18);
			this.label7.TabIndex = 11;
			this.label7.Text = "К/С:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbBankName
			// 
			this.tbBankName.Location = new System.Drawing.Point(76, 140);
			this.tbBankName.Multiline = true;
			this.tbBankName.Name = "tbBankName";
			this.tbBankName.ReadOnly = true;
			this.tbBankName.Size = new System.Drawing.Size(260, 45);
			this.tbBankName.TabIndex = 10;
			this.tbBankName.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 27);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(66, 18);
			this.label2.TabIndex = 9;
			this.label2.Text = "ИНН:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbINN
			// 
			this.tbINN.AllowDrop = true;
			this.tbINN.dValue = 0;
			this.tbINN.IsPcnt = false;
			this.tbINN.Location = new System.Drawing.Point(76, 25);
			this.tbINN.MaxDecPos = 0;
			this.tbINN.MaxLength = 12;
			this.tbINN.MaxPos = 12;
			this.tbINN.Name = "tbINN";
			this.tbINN.nValue = ((long)(0));
			this.tbINN.Size = new System.Drawing.Size(260, 22);
			this.tbINN.TabIndex = 8;
			this.tbINN.Text = "";
			this.tbINN.TextMode = true;
			this.tbINN.Leave += new System.EventHandler(this.tbINN_Leave);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.radioButton2,
																					this.radioButton1,
																					this.tbVAT});
			this.groupBox2.Location = new System.Drawing.Point(5, 7);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(344, 47);
			this.groupBox2.TabIndex = 6;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Направление Платежа";
			// 
			// radioButton2
			// 
			this.radioButton2.Location = new System.Drawing.Point(180, 22);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(104, 16);
			this.radioButton2.TabIndex = 1;
			this.radioButton2.Text = "Расход";
			// 
			// radioButton1
			// 
			this.radioButton1.Checked = true;
			this.radioButton1.Location = new System.Drawing.Point(76, 22);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(104, 16);
			this.radioButton1.TabIndex = 0;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "Приход";
			// 
			// bnSelPurp
			// 
			this.bnSelPurp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.bnSelPurp.Location = new System.Drawing.Point(5, 394);
			this.bnSelPurp.Name = "bnSelPurp";
			this.bnSelPurp.Size = new System.Drawing.Size(79, 22);
			this.bnSelPurp.TabIndex = 20;
			this.bnSelPurp.Text = "Основание:";
			this.bnSelPurp.Click += new System.EventHandler(this.bnSelPurp_Click);
			// 
			// sqlCmdGetLastPurpose
			// 
			this.sqlCmdGetLastPurpose.CommandText = "[GetLastPaymentOrderPurpose]";
			this.sqlCmdGetLastPurpose.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCmdGetLastPurpose.Connection = this.sqlConnection1;
			this.sqlCmdGetLastPurpose.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdGetLastPurpose.Parameters.Add(new System.Data.SqlClient.SqlParameter("@nOrgAccountIDFrom", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdGetLastPurpose.Parameters.Add(new System.Data.SqlClient.SqlParameter("@nOrgAccountIDTo", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdGetLastPurpose.Parameters.Add(new System.Data.SqlClient.SqlParameter("@szPurpose", System.Data.SqlDbType.NVarChar, 256, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = ((string)(configurationAppSettings.GetValue("ConnectionString", typeof(string))));
			// 
			// AccountStatementPaymentEdit
			// 
			this.AcceptButton = this.bnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
			this.CancelButton = this.bnCancel;
			this.ClientSize = new System.Drawing.Size(356, 523);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.bnSelPurp,
																		  this.groupBox2,
																		  this.groupBox1,
																		  this.label11,
																		  this.tbRemarks,
																		  this.tbPurpose,
																		  this.bnCancel,
																		  this.bnOK,
																		  this.panel1});
			this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AccountStatementPaymentEdit";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Платёжное поручение";
			this.Load += new System.EventHandler(this.Paym_Load);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvOrgsFrom)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		public int OwnerOrgID 
		{
			set { this.m_OwnerOrgID =value; }
		}

		public int OwnerOrgAccountID 
		{
			set { this.m_OwnerOrgAccountID =value; }
		}

		public string Currency
		{
			set { this.tbCurr.Text = value; }
		}
        public BPS.BLL.PaymentOrders.DataSets.dsPaymentOrderListX DsPaymsList
		{
			set { this.dsPaymList = value; }
		}

		private void NewOrg()
		{
			int nNewOrgID = BPS._Forms.Orgs.EditOrgs.AddOrgDialog(App.bllOrgs,this.cmbOrgFrom.Text,"");

//			if ((this.cmbOrgFrom.SelectedValue = App.ShowAddOrg(this.cmbOrgFrom.Text)) == null)
			if ((this.cmbOrgFrom.SelectedValue = nNewOrgID ) == null)
				this.cmbOrgFrom.Focus();
			else 
			{
				App.FillOrgsAccount();
				selectAccount();
			}
		}
		
		private void NewOrg(string szINN)
		{
			int nNewOrgID = BPS._Forms.Orgs.EditOrgs.AddOrgDialog(App.bllOrgs,"", szINN);
//			if ((this.cmbOrgFrom.SelectedValue = App.ShowAddOrg("", szINN)) == null)
			if ((this.cmbOrgFrom.SelectedValue = nNewOrgID) == null)
				this.cmbOrgFrom.Focus();
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			NewOrg();
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			int iOrgAccCount = App.DsOrgsAccount.OrgsAccounts.Count;
			insOrgAccount(this.cmbOrgFrom.SelectedValue);
			if(iOrgAccCount < App.DsOrgsAccount.OrgsAccounts.Count)
				this.cmbOrgAccount.SelectedValue = App.DsOrgsAccount.OrgsAccounts[iOrgAccCount].AccountID;
			this.drawBankString(this.dataView1, this.cmbOrgAccount.SelectedIndex);
		}
		private void insOrgAccount(object oOrgID)
		{
			BPS._Forms.OrgAccountEdit oa = new _Forms.OrgAccountEdit();
			if(this.cmbOrgAccount.FindString(this.cmbOrgAccount.Text)>-1)
			{
				oa.RAccount = "";
			}
			else
				oa.RAccount = this.cmbOrgAccount.Text;
			oa.OrgName = this.cmbOrgFrom.Text;			
			oa.ShowDialog();
			if(oa.DialogResult == DialogResult.OK)
			{
				SqlConnection conn = new SqlConnection(App.Connection.ConnectionString);
				//conn.ConnectionString = ;
				if(conn.State == ConnectionState.Closed)
					conn.Open();
				SqlCommand cmdInsAccount = new SqlCommand("", conn);
				SqlCommand cmdInsOrgsAccount = new SqlCommand("", conn);
				SqlCommand cmdGetAccountID = new SqlCommand("SELECT @@IDENTITY", conn);
				
				SqlTransaction tr = conn.BeginTransaction();
				cmdInsAccount.Transaction = tr;
				cmdInsOrgsAccount.Transaction = tr;
				cmdGetAccountID.Transaction = tr;
				try
				{
					
					cmdInsAccount.CommandText = "INSERT INTO Accounts (AccountTypeID,CurrencyID) VALUES (1,'" + oa.CurrID.ToString() + "')";
					cmdInsAccount.ExecuteNonQuery();
					//object oAccountID = cmdGetAccountID.ExecuteScalar();
					int iAccountID = Convert.ToInt32(cmdGetAccountID.ExecuteScalar());
					cmdInsOrgsAccount.CommandText = "INSERT INTO OrgsAccounts (AccountID, OrgID,RAccount,BankID) VALUES " +
						"(" + iAccountID.ToString() + "," + oOrgID + ",'" + oa.RAccount + "'," + oa.BankID.ToString() + ")";
					cmdInsOrgsAccount.ExecuteNonQuery();
					tr.Commit();
					App.FillOrgsAccount();
					
				}
				catch(Exception ex)
				{
					tr.Rollback();
					AM_Controls.MsgBoxX.Show(ex.Message,"BPS",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				}
				finally
				{
					if(conn.State == ConnectionState.Open)
						conn.Close();
				}
			}
		}
		
		private void bnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void Paym_Load(object sender, System.EventArgs e)
		{
			this.selectAccount();
			this.bIsLoaded = true;	
			if(this.isAdding)
				this.selectAccount();
			this.getINN();
			this.getCodeKPP();
			this.getPOOrgName();
		}

		private void cmbOrgFrom_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(!this.bIsLoaded)
				this.tbINN.Text = "";
			else 
			{
				this.selectAccount();
				this.getINN();
				this.getPOOrgName();
				this.getCodeKPP();
			}
		}

		private void getPOOrgName()
		{
			if(this.cmbOrgFrom.SelectedIndex == -1 || this.cmbOrgAccount.SelectedIndex == -1)
			{
				this.tbPOOrgName.Text = "";
				return;
			}
			BPS.dsOrgsAccount ds = (BPS.dsOrgsAccount)App.DsOrgsAccount.Copy();
			int iAccID = (int)this.dataView1[this.cmbOrgAccount.SelectedIndex]["AccountID"];
			string filter = "AccountID = " + iAccID.ToString() + 
					" AND OrgID = " + this.cmbOrgFrom.SelectedValue.ToString();
			DataRow[] dr = ds.Tables[0].Select(filter);
			if(dr.Length > 0)
			{
				this.tbPOOrgName.Text = dr[0]["OrgName"].ToString();
			}
			else
			{
				this.tbPOOrgName.Text = "";
			}
		}

		private void drawBankString(DataView dv, int iNdex)
		{
			if(iNdex>-1)
			{
				if(dv[iNdex]["BankID"]==Convert.DBNull)
					return;
				DataRow [] dr = App.DsBanks.Banks.Select("BankID=" + dv[iNdex]["BankID"].ToString());//.cmbOrgAccount.SelectedValue);
//				DataRow [] dr = App.bllBank.DataSet.Banks.Select("BankID=" + dv[iNdex]["BankID"].ToString());//.cmbOrgAccount.SelectedValue);
				if(dr.Length>0)
				{
					//		tb.Text = dr[0]["BankName"] + ", " + dr[0]["CityName"] + ", БИК: " + dr[0]["CodeBIK"] + ", К/С: " + dr[0]["KAccount"];
					this.tbBankName.Text = dr[0]["BankName"].ToString() + ", г. " + dr[0]["CityName"].ToString();
					this.tbBIK.Text = dr[0]["CodeBIK"].ToString();
					this.tbKAccount.Text = dr[0]["KAccount"].ToString();
				}
			}
			else 
			{
			//	tb.Text = "";
				this.tbBankName.Text = "";
				this.tbBIK.Text = "";
				this.tbKAccount.Text = "";
			}
		}
		private void bnOK_Click(object sender, System.EventArgs e)
		{
			if(!this.validatePaym())
				return;
			if(this.isAdding)
			{
				//BPS._Forms.dsPaymentOrderListX.AccountsStatementsRow rw = (BPS._Forms.dsPaymentOrderListX.AccountsStatementsRow) this.dsPaymList.AccountsStatements.NewRow();
				this.ins_updPayment(rwe);
				//this.dsPaymList.AccountsStatements.AddAccountsStatementsRow(rwe);
			}
			else
				this.ins_updPayment(rwe);
			
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
        private void ins_updPayment(BPS.BLL.PaymentOrders.DataSets.dsPaymentOrderListX.AccountsStatementsRow rw)
		{
			BindingManagerBase bm = (BindingManagerBase)this.BindingContext[this.dataView1];
			BPS.dsOrgsAccount.OrgsAccountsRow rowOrg = (BPS.dsOrgsAccount.OrgsAccountsRow)((DataRowView)bm.Current).Row;
			
			rw.CurrencyID = this.tbCurr.Text;
			if(this.radioButton1.Checked)
			{
				rw.Direct = "Приход";
				rw.Direction = true;
			}
			else
			{
				rw.Direct = "Расход";
				rw.Direction = false;
			}
			if(this.isAdding)
				rw.HeaderID = 0;
			rw.OrgAccountIDCorr = rowOrg.OrgsAccountsID;
			rw.OrgName = this.cmbOrgFrom.Text;
			rw.PaymentNo = this.textBox1.Text;
			rw.PaymentOrderDate = this.dateTimePicker1.Value;
			if(this.tbPurpose.Text.Length>0)
				rw.PaymentOrderPurpose = this.tbPurpose.Text;
			if(this.tbRemarks.Text.Length>0)
				rw.Remarks = this.tbRemarks.Text;
			rw.PaymentOrderSum = this.tbSum.dValue;
			rw.RAccount = this.cmbOrgAccount.Text;
			rw.AccountID = (int) this.cmbOrgAccount.SelectedValue;
			rw.OrgID = (int) this.cmbOrgFrom.SelectedValue;
		}
		private void cmbOrgAccount_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.cmbOrgAccount.SelectedIndex>-1)
			{
				this.getPOOrgName();
				this.drawBankString(this.dataView1,this.cmbOrgAccount.SelectedIndex);
			}
		}
		private void cmbOrgFrom_Leave(object sender, System.EventArgs e)
		{
			this.cmbOrgFrom.SelectedIndex = this.cmbOrgFrom.FindStringExact(this.cmbOrgFrom.Text);
			if(this.cmbOrgFrom.SelectedIndex == -1)
			{
				this.dataView1.RowFilter = "OrgID=-1";
				this.cmbOrgAccount.Text = "";
//				this.cmbOrgFrom.Text = "";
				this.tbINN.Text = "";
				NewOrg();
			}
		}
		private void cmbOrgAccount_Leave(object sender, System.EventArgs e)
		{
			this.cmbOrgAccount.SelectedIndex = this.cmbOrgAccount.FindStringExact(this.cmbOrgAccount.Text);
			if(this.cmbOrgAccount.SelectedIndex == -1)
			{
				insOrgAccount(this.cmbOrgFrom.SelectedValue);
				this.drawBankString(this.dataView1, this.cmbOrgAccount.SelectedIndex);
			}
				
		}
		private bool validatePaym()
		{
			if(this.textBox1.Text.Length == 0)
			{
				MsgBoxX.Show("Заполните поле Пл.поручение №", "BPS", MessageBoxButtons.OK,MessageBoxIcon.Warning);
				this.textBox1.Focus();
				return false;
			}
			
			if(this.tbSum.dValue == 0)
			{
				MsgBoxX.Show("Сумма платежа равна нулю", "BPS", MessageBoxButtons.OK,MessageBoxIcon.Warning);
				this.tbSum.Focus();
				return false;
			}
			if(this.cmbOrgAccount.SelectedIndex == -1)
			{
				MsgBoxX.Show("Правильно выберите Р./СЧЁТ плательщика", "BPS", MessageBoxButtons.OK,MessageBoxIcon.Warning);
				this.cmbOrgAccount.Focus();
				return false;
			}
			
			if(this.cmbOrgFrom.SelectedIndex == -1)
			{
				MsgBoxX.Show("Правильно выберите ПЛАТЕЛЬЩИКА", "BPS", MessageBoxButtons.OK,MessageBoxIcon.Warning);
				this.cmbOrgFrom.Focus();
				return false;
			}
			
			else
				return true;
		}
		private void selectAccount()
		{
			if(bIsLoaded)
			{	
				int iorgFromID;
				if(this.cmbOrgFrom.SelectedIndex == -1)
				{
					iorgFromID = -1;
				}
				else
					iorgFromID =(int) this.cmbOrgFrom.SelectedValue;
				this.dataView1.RowFilter = "OrgID=" + iorgFromID.ToString() + " and CurrencyID='" + this.tbCurr.Text + "'";
				drawBankString(this.dataView1, this.cmbOrgAccount.SelectedIndex);			
				
				if(this.dataView1.Count == 0)
				{
					this.cmbOrgAccount.Text = "";
					this.tbBankName.Text = "";
					this.tbBIK.Text = "";
					this.tbKAccount.Text = "";
				}
			}
			else if(!this.isAdding)
			{
				int iorgFromID;
				if(this.cmbOrgFrom.SelectedIndex == -1)
				{
					iorgFromID = -1;
				}
				else
					iorgFromID =(int) this.cmbOrgFrom.SelectedValue;
				object o = this.cmbOrgAccount.SelectedValue;
				this.dataView1.RowFilter = "OrgID=" + iorgFromID.ToString() + " and CurrencyID='" + this.tbCurr.Text + "'";
				this.cmbOrgAccount.SelectedValue = o;
				drawBankString(this.dataView1, this.cmbOrgAccount.SelectedIndex);			
				
				if(this.dataView1.Count == 0)
				{
					this.cmbOrgAccount.Text = "";
					this.tbBankName.Text = "";
					this.tbBIK.Text = "";
					this.tbKAccount.Text = "";
				}
			}
		}
		
		private void getINN()
		{
			if(this.cmbOrgFrom.SelectedIndex == -1)
			{
				this.tbINN.Text = "";
				return;
			}
			DataRow [] dr = this.dvOrgsFrom.Table.Select("OrgID=" + this.cmbOrgFrom.SelectedValue.ToString());
			if(dr.Length != 1)
				this.tbINN.Text = "";
			else
				this.tbINN.Text = dr[0]["CodeINN"].ToString();
		}

		private void getCodeKPP()
		{
			if(this.cmbOrgFrom.SelectedIndex == -1)
			{
				this.tbCodeKPP.Text = "";
				return;
			}
			//BPS.BLL.Orgs.DataSets.dsOrgs ds = (BPS.BLL.Orgs.DataSets.dsOrgs)App.DsOrgs.Copy();
			//DataRow dr = ds.Orgs.FindByOrgID((int)this.cmbOrgFrom.SelectedValue);
			//if(dr != null)
			//{
			//	this.tbCodeKPP.Text = dr["CodeKPP"].ToString();
			//}
			//else
			//{
			//	this.tbCodeKPP.Text = "";
			//}
			DataRow [] dr = this.dvOrgsFrom.Table.Select("OrgID=" + this.cmbOrgFrom.SelectedValue.ToString());
			if(dr.Length != 1)
				this.tbCodeKPP.Text = "";
			else
				this.tbCodeKPP.Text = dr[0]["CodeKPP"].ToString();

		}

		private void tbINN_Leave(object sender, System.EventArgs e)
		{
			if((this.tbINN.Text.Length > 0) && (this.tbINN.Text.Length < 10))
			{
				AM_Controls.MsgBoxX.Show("ИНН должен содержать 10-12 цифр.");
				this.tbINN.Focus();
				return;
			}
			DataRow [] dr = this.dvOrgsFrom.Table.Select("CodeINN='" + this.tbINN.Text + "'");
			if(dr.Length != 1)
			{
				NewOrg(this.tbINN.Text);
				return;
			}
			this.cmbOrgFrom.SelectedValue = dr[0]["OrgID"];
		}

		private void bnSelPurp_Click(object sender, System.EventArgs e)
		{
			// Changed by MIKE 31.05.03
			int nOrgAccountIDFrom	=0;

			//if (this.cmbOrgAccount.SelectedIndex == -1 || this.cmbOrgFrom.SelectedIndex == -1)
			//	return;
			if ( !this.radioButton1.Checked) //Только для приходных платёжных поручений
				return;

			if ( this.cmbOrgAccount.SelectedIndex == -1)
				return;

			nOrgAccountIDFrom =(int)this.dataView1[this.cmbOrgAccount.SelectedIndex]["OrgsAccountsID"];

			this.sqlCmdGetLastPurpose.Parameters["@nOrgAccountIDFrom"].Value	=nOrgAccountIDFrom;
			this.sqlCmdGetLastPurpose.Parameters["@nOrgAccountIDTo"].Value		=m_OwnerOrgAccountID;
			if ( App.ExecSql( this.sqlCmdGetLastPurpose)) 
			{
				this.tbPurpose.Text =(string)this.sqlCmdGetLastPurpose.Parameters["@szPurpose"].Value;
			}
			//SelectPurpose sp = new SelectPurpose();
			//sp.AccountID = (int)this.cmbOrgAccount.SelectedValue;
			//sp.OrgID = (int) this.cmbOrgFrom.SelectedValue;
			//sp.ShowDialog();
			//if(sp.DialogResult == DialogResult.OK)
			//{
			//	this.tbPurpose.Text = sp.Purpose;
			//}
		}

		private void tbVAT_Leave(object sender, System.EventArgs e)
		{
			if(this.tbVAT.dValue>0)
				this.tbVATSum.dValue = this.tbSum.dValue /(1 +this.tbVAT.dValue) * this.tbVAT.dValue;
			else
				this.tbVATSum.dValue = 0;
		}

		private void cmbVAT_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (cmbVAT.Text.StartsWith("Не") )
			{
				this.tbVAT.Text = "";
				this.tbVATSum.Text = "";
			}
			else
			{
				int nPcntPos = cmbVAT.Text.IndexOf("%");
				this.tbVAT.Text = cmbVAT.Text.Substring(0,nPcntPos);
				if(this.tbVAT.dValue>0)
					this.tbVATSum.dValue = this.tbSum.dValue /(1 +this.tbVAT.dValue) * this.tbVAT.dValue;
				else
					this.tbVATSum.dValue = 0;
			}
		
		}

	}
}
