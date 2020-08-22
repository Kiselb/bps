using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace BPS._Forms
{
	/// <summary>
	/// Summary description for PaymentsOrdersEdit.
	/// </summary>
	public class PaymentsOrdersEdit : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox tbCurr;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Button bnCancel;
		private System.Windows.Forms.TextBox tbRemarks;
		private System.Windows.Forms.TextBox tbPurpose;
		private System.Windows.Forms.Button bnOK;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tbOrg;
		private System.Windows.Forms.TextBox tbRaccount;
		private System.Windows.Forms.TextBox tbNo;
		private AM_Controls.TextBoxV tbSum;
		private BPS.BLL.PaymentOrders.DataSets.dsPaymentOrderList.PaymentsOrdersListRow rw;
		private bool bIsSend;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbBankName;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox tbKAccount;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox tbBIK;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox tbINN;
		private System.Windows.Forms.Label label9;
		private AM_Controls.TextBoxV tbVAT;
		private AM_Controls.TextBoxV tbVATSum;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox tbOrgPO;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox tbCodeKPP;
		private System.Windows.Forms.ComboBox cmbVAT;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public PaymentsOrdersEdit(BPS.BLL.PaymentOrders.DataSets.dsPaymentOrderList.PaymentsOrdersListRow rw, bool bIsSend)
		{
			this.rw = rw;
			this.bIsSend = bIsSend;
			App.FillOrgsAccount();
			InitializeComponent();
            this.tbNo.Text = rw.PaymentNo;
			this.dateTimePicker1.Value = rw.PaymentOrderDate;
			this.tbSum.dValue = rw.PaymentOrderSum;
			this.tbCurr.Text = rw.CurrencyID;
			this.tbOrg.Text = rw.OrgNameCorr;
			this.tbOrgPO.Text = rw.POOrgNameCorr;
			BPS.BLL.Orgs.DataSets.dsOrgs ds = (BPS.BLL.Orgs.DataSets.dsOrgs)App.DsOrgs.Copy();
			BPS.BLL.Orgs.DataSets.dsOrgs.OrgsRow row = ds.Orgs.FindByOrgID(rw.OrgIDCorr);
			this.tbCodeKPP.Text = "";
			if(row != null && !row.IsCodeKPPNull())
			{
				this.tbCodeKPP.Text = row.CodeKPP.ToString();
			}
			this.tbRaccount.Text = rw.RAccountCorr;
			this.tbBankName.Text = rw.BankNameCorr;
			if ( !rw.IsCityNameCorrNull()) 
				this.tbBankName.Text += ", г. " + rw.CityNameCorr;

			this.tbBIK.Text = rw.CodeBIKCorr;
			this.tbKAccount.Text = rw.KAccountCorr;
			this.tbINN.Text = rw.CodeINNCorr;
			if(!rw.IsPaymentOrderPurposeNull())
				this.tbPurpose.Text = rw.PaymentOrderPurpose;
			if(!rw.IsRemarksNull())
				this.tbRemarks.Text = rw.Remarks;
			if(bIsSend)
			{
				this.tbNo.ReadOnly = true;
				this.dateTimePicker1.Enabled = false;
				this.tbPurpose.ReadOnly = true;
			}
	//		this.drawBankString(rw.OrgAccountIDCorr);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(PaymentsOrdersEdit));
			this.tbCurr = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tbCodeKPP = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.tbOrgPO = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.tbBIK = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.tbKAccount = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.tbBankName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tbRaccount = new System.Windows.Forms.TextBox();
			this.tbOrg = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.tbINN = new System.Windows.Forms.TextBox();
			this.tbVAT = new AM_Controls.TextBoxV();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.bnCancel = new System.Windows.Forms.Button();
			this.tbNo = new System.Windows.Forms.TextBox();
			this.tbSum = new AM_Controls.TextBoxV();
			this.tbRemarks = new System.Windows.Forms.TextBox();
			this.tbPurpose = new System.Windows.Forms.TextBox();
			this.bnOK = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.label4 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.tbVATSum = new AM_Controls.TextBoxV();
			this.cmbVAT = new System.Windows.Forms.ComboBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbCurr
			// 
			this.tbCurr.BackColor = System.Drawing.SystemColors.Control;
			this.tbCurr.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.tbCurr.ForeColor = System.Drawing.Color.Black;
			this.tbCurr.Location = new System.Drawing.Point(318, 36);
			this.tbCurr.Name = "tbCurr";
			this.tbCurr.ReadOnly = true;
			this.tbCurr.Size = new System.Drawing.Size(38, 22);
			this.tbCurr.TabIndex = 3;
			this.tbCurr.Text = "RUR";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.tbCodeKPP);
			this.groupBox1.Controls.Add(this.label15);
			this.groupBox1.Controls.Add(this.tbOrgPO);
			this.groupBox1.Controls.Add(this.label14);
			this.groupBox1.Controls.Add(this.tbBIK);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.tbKAccount);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.tbBankName);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.tbRaccount);
			this.groupBox1.Controls.Add(this.tbOrg);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label12);
			this.groupBox1.Controls.Add(this.tbINN);
			this.groupBox1.Controls.Add(this.tbVAT);
			this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.groupBox1.Location = new System.Drawing.Point(5, 89);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(353, 257);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Корреспондент";
			// 
			// tbCodeKPP
			// 
			this.tbCodeKPP.BackColor = System.Drawing.SystemColors.Control;
			this.tbCodeKPP.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.tbCodeKPP.Location = new System.Drawing.Point(66, 47);
			this.tbCodeKPP.MaxLength = 20;
			this.tbCodeKPP.Name = "tbCodeKPP";
			this.tbCodeKPP.ReadOnly = true;
			this.tbCodeKPP.Size = new System.Drawing.Size(110, 22);
			this.tbCodeKPP.TabIndex = 17;
			this.tbCodeKPP.Text = "";
			// 
			// label15
			// 
			this.label15.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label15.Location = new System.Drawing.Point(8, 49);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(56, 18);
			this.label15.TabIndex = 18;
			this.label15.Text = "КПП:";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbOrgPO
			// 
			this.tbOrgPO.BackColor = System.Drawing.SystemColors.Control;
			this.tbOrgPO.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.tbOrgPO.Location = new System.Drawing.Point(66, 97);
			this.tbOrgPO.Multiline = true;
			this.tbOrgPO.Name = "tbOrgPO";
			this.tbOrgPO.ReadOnly = true;
			this.tbOrgPO.Size = new System.Drawing.Size(278, 50);
			this.tbOrgPO.TabIndex = 15;
			this.tbOrgPO.Text = "";
			// 
			// label14
			// 
			this.label14.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label14.Location = new System.Drawing.Point(8, 98);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(56, 32);
			this.label14.TabIndex = 16;
			this.label14.Text = "Наим. в П/П:";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbBIK
			// 
			this.tbBIK.BackColor = System.Drawing.SystemColors.Control;
			this.tbBIK.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.tbBIK.Location = new System.Drawing.Point(66, 200);
			this.tbBIK.MaxLength = 20;
			this.tbBIK.Name = "tbBIK";
			this.tbBIK.ReadOnly = true;
			this.tbBIK.Size = new System.Drawing.Size(110, 22);
			this.tbBIK.TabIndex = 5;
			this.tbBIK.Text = "1234567890";
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label8.Location = new System.Drawing.Point(8, 202);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(56, 18);
			this.label8.TabIndex = 12;
			this.label8.Text = "БИК:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbKAccount
			// 
			this.tbKAccount.BackColor = System.Drawing.SystemColors.Control;
			this.tbKAccount.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.tbKAccount.Location = new System.Drawing.Point(66, 225);
			this.tbKAccount.MaxLength = 20;
			this.tbKAccount.Name = "tbKAccount";
			this.tbKAccount.ReadOnly = true;
			this.tbKAccount.Size = new System.Drawing.Size(278, 22);
			this.tbKAccount.TabIndex = 4;
			this.tbKAccount.Text = "12345678901234567890";
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label7.Location = new System.Drawing.Point(8, 227);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(56, 16);
			this.label7.TabIndex = 10;
			this.label7.Text = "К/С:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbBankName
			// 
			this.tbBankName.BackColor = System.Drawing.SystemColors.Control;
			this.tbBankName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.tbBankName.Location = new System.Drawing.Point(66, 175);
			this.tbBankName.Name = "tbBankName";
			this.tbBankName.ReadOnly = true;
			this.tbBankName.Size = new System.Drawing.Size(278, 22);
			this.tbBankName.TabIndex = 2;
			this.tbBankName.Text = "";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label2.Location = new System.Drawing.Point(8, 178);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 18);
			this.label2.TabIndex = 8;
			this.label2.Text = "Банк:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbRaccount
			// 
			this.tbRaccount.BackColor = System.Drawing.SystemColors.Control;
			this.tbRaccount.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.tbRaccount.Location = new System.Drawing.Point(66, 150);
			this.tbRaccount.MaxLength = 20;
			this.tbRaccount.Name = "tbRaccount";
			this.tbRaccount.ReadOnly = true;
			this.tbRaccount.Size = new System.Drawing.Size(278, 22);
			this.tbRaccount.TabIndex = 3;
			this.tbRaccount.Text = "";
			// 
			// tbOrg
			// 
			this.tbOrg.BackColor = System.Drawing.SystemColors.Control;
			this.tbOrg.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.tbOrg.Location = new System.Drawing.Point(66, 72);
			this.tbOrg.Name = "tbOrg";
			this.tbOrg.ReadOnly = true;
			this.tbOrg.Size = new System.Drawing.Size(278, 22);
			this.tbOrg.TabIndex = 0;
			this.tbOrg.Text = "";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label1.Location = new System.Drawing.Point(8, 73);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 20);
			this.label1.TabIndex = 1;
			this.label1.Text = "Орг-я:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label6.Location = new System.Drawing.Point(8, 153);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(56, 18);
			this.label6.TabIndex = 7;
			this.label6.Text = "Р/С:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label12
			// 
			this.label12.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label12.Location = new System.Drawing.Point(8, 25);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(56, 18);
			this.label12.TabIndex = 14;
			this.label12.Text = "ИНН:";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbINN
			// 
			this.tbINN.BackColor = System.Drawing.SystemColors.Control;
			this.tbINN.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.tbINN.Location = new System.Drawing.Point(66, 22);
			this.tbINN.MaxLength = 20;
			this.tbINN.Name = "tbINN";
			this.tbINN.ReadOnly = true;
			this.tbINN.Size = new System.Drawing.Size(110, 22);
			this.tbINN.TabIndex = 1;
			this.tbINN.Text = "123456789012";
			// 
			// tbVAT
			// 
			this.tbVAT.AllowDrop = true;
			this.tbVAT.BackColor = System.Drawing.SystemColors.Window;
			this.tbVAT.dValue = 0;
			this.tbVAT.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.tbVAT.IsPcnt = true;
			this.tbVAT.Location = new System.Drawing.Point(220, 30);
			this.tbVAT.MaxDecPos = 2;
			this.tbVAT.MaxPos = 8;
			this.tbVAT.Name = "tbVAT";
			this.tbVAT.Negative = System.Drawing.Color.Empty;
			this.tbVAT.nValue = ((long)(0));
			this.tbVAT.Positive = System.Drawing.Color.Empty;
			this.tbVAT.Size = new System.Drawing.Size(70, 22);
			this.tbVAT.TabIndex = 4;
			this.tbVAT.Text = "";
			this.tbVAT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbVAT.TextMode = false;
			this.tbVAT.Visible = false;
			this.tbVAT.Zero = System.Drawing.Color.Empty;
			this.tbVAT.Leave += new System.EventHandler(this.tbVAT_Leave);
			// 
			// label11
			// 
			this.label11.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label11.Location = new System.Drawing.Point(5, 426);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(80, 16);
			this.label11.TabIndex = 32;
			this.label11.Text = "Примечание:";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label10
			// 
			this.label10.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label10.Location = new System.Drawing.Point(5, 350);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(72, 14);
			this.label10.TabIndex = 31;
			this.label10.Text = "Основание:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// bnCancel
			// 
			this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.bnCancel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.bnCancel.Location = new System.Drawing.Point(279, 501);
			this.bnCancel.Name = "bnCancel";
			this.bnCancel.Size = new System.Drawing.Size(80, 25);
			this.bnCancel.TabIndex = 10;
			this.bnCancel.TabStop = false;
			this.bnCancel.Text = "Отменить";
			this.bnCancel.Click += new System.EventHandler(this.bnCancel_Click);
			// 
			// tbNo
			// 
			this.tbNo.BackColor = System.Drawing.SystemColors.Window;
			this.tbNo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.tbNo.Location = new System.Drawing.Point(136, 6);
			this.tbNo.Name = "tbNo";
			this.tbNo.TabIndex = 0;
			this.tbNo.Text = "";
			// 
			// tbSum
			// 
			this.tbSum.AllowDrop = true;
			this.tbSum.BackColor = System.Drawing.SystemColors.Control;
			this.tbSum.dValue = 0;
			this.tbSum.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.tbSum.IsPcnt = false;
			this.tbSum.Location = new System.Drawing.Point(136, 36);
			this.tbSum.MaxDecPos = 2;
			this.tbSum.MaxPos = 10;
			this.tbSum.Name = "tbSum";
			this.tbSum.Negative = System.Drawing.Color.Empty;
			this.tbSum.nValue = ((long)(0));
			this.tbSum.Positive = System.Drawing.Color.Empty;
			this.tbSum.ReadOnly = true;
			this.tbSum.Size = new System.Drawing.Size(181, 22);
			this.tbSum.TabIndex = 2;
			this.tbSum.Text = "";
			this.tbSum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbSum.TextMode = false;
			this.tbSum.Zero = System.Drawing.Color.Empty;
			// 
			// tbRemarks
			// 
			this.tbRemarks.BackColor = System.Drawing.SystemColors.Window;
			this.tbRemarks.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.tbRemarks.Location = new System.Drawing.Point(5, 444);
			this.tbRemarks.MaxLength = 256;
			this.tbRemarks.Multiline = true;
			this.tbRemarks.Name = "tbRemarks";
			this.tbRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbRemarks.Size = new System.Drawing.Size(353, 52);
			this.tbRemarks.TabIndex = 8;
			this.tbRemarks.Text = "";
			// 
			// tbPurpose
			// 
			this.tbPurpose.BackColor = System.Drawing.SystemColors.Window;
			this.tbPurpose.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.tbPurpose.Location = new System.Drawing.Point(5, 366);
			this.tbPurpose.Multiline = true;
			this.tbPurpose.Name = "tbPurpose";
			this.tbPurpose.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbPurpose.Size = new System.Drawing.Size(353, 52);
			this.tbPurpose.TabIndex = 7;
			this.tbPurpose.Text = "";
			// 
			// bnOK
			// 
			this.bnOK.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.bnOK.Location = new System.Drawing.Point(197, 501);
			this.bnOK.Name = "bnOK";
			this.bnOK.Size = new System.Drawing.Size(80, 25);
			this.bnOK.TabIndex = 9;
			this.bnOK.TabStop = false;
			this.bnOK.Text = "Сохранить";
			this.bnOK.Click += new System.EventHandler(this.bnOK_Click);
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label3.Location = new System.Drawing.Point(242, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(20, 16);
			this.label3.TabIndex = 26;
			this.label3.Text = "от:";
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label5.Location = new System.Drawing.Point(8, 8);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(126, 18);
			this.label5.TabIndex = 25;
			this.label5.Text = "Пл. Поручение №:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dateTimePicker1.Location = new System.Drawing.Point(266, 6);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(90, 22);
			this.dateTimePicker1.TabIndex = 1;
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label4.Location = new System.Drawing.Point(8, 37);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(126, 18);
			this.label4.TabIndex = 27;
			this.label4.Text = "Сумма:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label9
			// 
			this.label9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label9.Location = new System.Drawing.Point(8, 61);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(126, 18);
			this.label9.TabIndex = 33;
			this.label9.Text = "НДС (Ставка/Сумма):";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbVATSum
			// 
			this.tbVATSum.AllowDrop = true;
			this.tbVATSum.BackColor = System.Drawing.SystemColors.Window;
			this.tbVATSum.dValue = 0;
			this.tbVATSum.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.tbVATSum.IsPcnt = false;
			this.tbVATSum.Location = new System.Drawing.Point(266, 60);
			this.tbVATSum.MaxDecPos = 2;
			this.tbVATSum.MaxPos = 10;
			this.tbVATSum.Name = "tbVATSum";
			this.tbVATSum.Negative = System.Drawing.Color.Empty;
			this.tbVATSum.nValue = ((long)(0));
			this.tbVATSum.Positive = System.Drawing.Color.Empty;
			this.tbVATSum.ReadOnly = true;
			this.tbVATSum.Size = new System.Drawing.Size(90, 22);
			this.tbVATSum.TabIndex = 5;
			this.tbVATSum.Text = "";
			this.tbVATSum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbVATSum.TextMode = false;
			this.tbVATSum.Zero = System.Drawing.Color.Empty;
			// 
			// cmbVAT
			// 
			this.cmbVAT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbVAT.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cmbVAT.Items.AddRange(new object[] {
														"0.00%",
														"10.00%",
														"18.00%",
														"20.00%",
														"Не облагается"});
			this.cmbVAT.Location = new System.Drawing.Point(136, 60);
			this.cmbVAT.Name = "cmbVAT";
			this.cmbVAT.Size = new System.Drawing.Size(128, 22);
			this.cmbVAT.TabIndex = 34;
			this.cmbVAT.SelectedIndexChanged += new System.EventHandler(this.cmbVAT_SelectedIndexChanged);
			// 
			// PaymentsOrdersEdit
			// 
			this.AcceptButton = this.bnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.CancelButton = this.bnCancel;
			this.ClientSize = new System.Drawing.Size(364, 529);
			this.Controls.Add(this.cmbVAT);
			this.Controls.Add(this.tbVATSum);
			this.Controls.Add(this.tbCurr);
			this.Controls.Add(this.tbNo);
			this.Controls.Add(this.tbSum);
			this.Controls.Add(this.tbRemarks);
			this.Controls.Add(this.tbPurpose);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.bnCancel);
			this.Controls.Add(this.bnOK);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.dateTimePicker1);
			this.Controls.Add(this.label4);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PaymentsOrdersEdit";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Платёжное поручение [Редактирование]";
			this.Closed += new System.EventHandler(this.PaymentsOrdersEdit_Closed);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		private void drawBankString(int iOrgAccID)
		{
	/*		DataRow [] drOrg = App.DsOrgsAccount._Table.Select("OrgsAccountsID=" + iOrgAccID.ToString());
			if(drOrg.Length == 0)
				return;
			if(drOrg[0]["BankID"] == Convert.DBNull)
				return;
			int iBankID = Convert.ToInt32(drOrg[0]["BankID"]);
				DataRow [] dr = App.DsBanks.Banks.Select("BankID=" + iBankID.ToString());
				if(dr.Length>0)
				{
					this.tbBank.Text = dr[0]["BankName"] + ", " + dr[0]["CityName"] + ", БИК: " + dr[0]["CodeBIK"] + ", К/С: " + dr[0]["KAccount"];
				}
		*/	
		}
		private void bnOK_Click(object sender, System.EventArgs e)
		{
			if(!bIsSend)
			{
				if(this.tbNo.Text.Length == 0)
				{
					AM_Controls.MsgBoxX.Show("Введите номер п/п.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					this.tbNo.Focus();
					return;
				}
				this.rw.PaymentNo = this.tbNo.Text;
				this.rw.PaymentOrderDate = this.dateTimePicker1.Value;
				if(this.tbPurpose.Text.Length == 0)
					this.rw.SetPaymentOrderPurposeNull();
				else
					this.rw.PaymentOrderPurpose = this.tbPurpose.Text;
			}
			if(this.tbRemarks.Text.Length == 0)
				this.rw.SetRemarksNull();
			else
				this.rw.Remarks = this.tbRemarks.Text;
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void bnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void tbVAT_Leave(object sender, System.EventArgs e)
		{
			if(this.tbVAT.dValue>0 && this.tbVAT.Changed )
				this.tbVATSum.dValue  = Math.Round(rw.PaymentOrderSum *this.tbVAT.dValue /(1+this.tbVAT.dValue),2);
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

		private void PaymentsOrdersEdit_Closed(object sender, System.EventArgs e)
		{
			App.LockStatusChange(5, this.rw.PaymentOrderID, false);
		}

	}
}
