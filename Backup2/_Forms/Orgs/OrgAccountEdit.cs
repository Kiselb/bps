using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace BPS._Forms
{
	/// <summary>
	/// Summary description for OrgAccountEdit.
	/// </summary>
	public class OrgAccountEdit : System.Windows.Forms.Form
	{
		private AM_Controls.TextBoxV textBox1;
		private System.Windows.Forms.ComboBox cmbBank;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button bnOK;
		private System.Windows.Forms.Button bnCancel;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox cmbCurr;
		private AM_Controls.TextBoxBIK tbBIK;
		private System.Windows.Forms.Label label5;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Data.DataView dvBank;
		private System.Windows.Forms.ErrorProvider err;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label6;
		private bool bIsLoad = false;
		public OrgAccountEdit()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
//			this.dvBank.Table = ds.Banks;
			this.dvBank.Table  = App.DsBanks.Banks;
			this.dvBank.Sort = "BankName";
			this.cmbBank.DataSource = this.dvBank;//ds.Banks;
			this.cmbBank.DisplayMember = "BankName";
			this.cmbBank.ValueMember = "BankID";
			this.cmbCurr.DataSource = App.DsCurr.Currencies;
			this.cmbCurr.DisplayMember = "CurrencyID";
			this.cmbCurr.ValueMember = "CurrencyID";
			this.cmbCurr.SelectedValue = "RUR";
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
		public string OrgName
		{
			get
			{
				return this.textBox2.Text;
			}
			set
			{
				this.textBox2.Text = value;
			}
		}
		public string RAccount
		{
			get
			{
				return this.textBox1.Text;
			}
			set
			{
				this.textBox1.Text = value;
			}
		}
		
		public string OrgNameStr
		{
			get
			{
				return this.textBox3.Text;
			}
			set
			{
				this.textBox3.Text = value;
			}
		}

		public string CurrID
		{
			get
			{
				return Convert.ToString(this.cmbCurr.SelectedValue);
			}
		}
		public int BankID
		{
			get
			{
				return Convert.ToInt32( this.cmbBank.SelectedValue ) ;
			}
			set
			{
				if (value==-1)
					this.cmbBank.SelectedIndex = -1;
				else
					this.cmbBank.SelectedValue = value;
			}
		}
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OrgAccountEdit));
			this.bnOK = new System.Windows.Forms.Button();
			this.bnCancel = new System.Windows.Forms.Button();
			this.textBox1 = new AM_Controls.TextBoxV();
			this.cmbBank = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.button3 = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.cmbCurr = new System.Windows.Forms.ComboBox();
			this.tbBIK = new AM_Controls.TextBoxBIK();
			this.label5 = new System.Windows.Forms.Label();
			this.dvBank = new System.Data.DataView();
			this.err = new System.Windows.Forms.ErrorProvider();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dvBank)).BeginInit();
			this.SuspendLayout();
			// 
			// bnOK
			// 
			this.bnOK.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.bnOK.Location = new System.Drawing.Point(188, 146);
			this.bnOK.Name = "bnOK";
			this.bnOK.Size = new System.Drawing.Size(80, 26);
			this.bnOK.TabIndex = 13;
			this.bnOK.Text = "Сохранить";
			this.bnOK.Click += new System.EventHandler(this.bnOK_Click);
			// 
			// bnCancel
			// 
			this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.bnCancel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.bnCancel.Location = new System.Drawing.Point(268, 146);
			this.bnCancel.Name = "bnCancel";
			this.bnCancel.Size = new System.Drawing.Size(80, 26);
			this.bnCancel.TabIndex = 14;
			this.bnCancel.Text = "Отменить";
			this.bnCancel.Click += new System.EventHandler(this.bnCancel_Click);
			// 
			// textBox1
			// 
			this.textBox1.AllowDrop = true;
			this.textBox1.dValue = 0;
			this.textBox1.IsPcnt = false;
			this.textBox1.Location = new System.Drawing.Point(86, 66);
			this.textBox1.MaxDecPos = 0;
			this.textBox1.MaxLength = ((int)(configurationAppSettings.GetValue("RAccount.MaxLength", typeof(int))));
			this.textBox1.MaxPos = 20;
			this.textBox1.Name = "textBox1";
			this.textBox1.Negative = System.Drawing.Color.Empty;
			this.textBox1.nValue = ((long)(0));
			this.textBox1.Positive = System.Drawing.Color.Empty;
			this.textBox1.Size = new System.Drawing.Size(136, 21);
			this.textBox1.TabIndex = 5;
			this.textBox1.Text = "";
			this.textBox1.TextMode = true;
			this.textBox1.Zero = System.Drawing.Color.Empty;
			// 
			// cmbBank
			// 
			this.cmbBank.DropDownWidth = 500;
			this.cmbBank.Location = new System.Drawing.Point(86, 110);
			this.cmbBank.MaxDropDownItems = 20;
			this.cmbBank.Name = "cmbBank";
			this.cmbBank.Size = new System.Drawing.Size(236, 21);
			this.cmbBank.TabIndex = 11;
			this.cmbBank.SelectedIndexChanged += new System.EventHandler(this.cmbBank_SelectedIndexChanged);
			this.cmbBank.Leave += new System.EventHandler(this.comboBox1_Leave);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(2, 66);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(52, 23);
			this.label1.TabIndex = 4;
			this.label1.Text = "Р./счёт:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(2, 108);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(44, 23);
			this.label2.TabIndex = 10;
			this.label2.Text = "Банк:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// button3
			// 
			this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
			this.button3.Location = new System.Drawing.Point(322, 110);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(24, 22);
			this.button3.TabIndex = 12;
			this.button3.TabStop = false;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(2, 2);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(76, 23);
			this.label3.TabIndex = 0;
			this.label3.Text = "Организация:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBox2
			// 
			this.textBox2.BackColor = System.Drawing.Color.Gainsboro;
			this.textBox2.Location = new System.Drawing.Point(86, 2);
			this.textBox2.Name = "textBox2";
			this.textBox2.ReadOnly = true;
			this.textBox2.Size = new System.Drawing.Size(262, 21);
			this.textBox2.TabIndex = 1;
			this.textBox2.TabStop = false;
			this.textBox2.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(232, 70);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(48, 16);
			this.label4.TabIndex = 6;
			this.label4.Text = "Валюта:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cmbCurr
			// 
			this.cmbCurr.Enabled = false;
			this.cmbCurr.Location = new System.Drawing.Point(282, 66);
			this.cmbCurr.Name = "cmbCurr";
			this.cmbCurr.Size = new System.Drawing.Size(66, 21);
			this.cmbCurr.TabIndex = 7;
			this.cmbCurr.Leave += new System.EventHandler(this.cmbCurr_Leave);
			// 
			// tbBIK
			// 
			this.tbBIK.AllowDrop = true;
			this.tbBIK.dValue = 0;
			this.tbBIK.IsPcnt = false;
			this.tbBIK.Location = new System.Drawing.Point(86, 88);
			this.tbBIK.MaxDecPos = 0;
			this.tbBIK.MaxLength = 9;
			this.tbBIK.MaxPos = 9;
			this.tbBIK.Name = "tbBIK";
			this.tbBIK.Negative = System.Drawing.Color.Empty;
			this.tbBIK.nValue = ((long)(0));
			this.tbBIK.Positive = System.Drawing.Color.Empty;
			this.tbBIK.Size = new System.Drawing.Size(136, 21);
			this.tbBIK.TabIndex = 9;
			this.tbBIK.Text = "";
			this.tbBIK.TextMode = true;
			this.tbBIK.Zero = System.Drawing.Color.Empty;
			this.tbBIK.Leave += new System.EventHandler(this.tbBIK_Leave);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(2, 88);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(34, 23);
			this.label5.TabIndex = 8;
			this.label5.Text = "БИК:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// err
			// 
			this.err.ContainerControl = this;
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(86, 24);
			this.textBox3.Multiline = true;
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(262, 42);
			this.textBox3.TabIndex = 3;
			this.textBox3.Text = "";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(2, 28);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(82, 34);
			this.label6.TabIndex = 2;
			this.label6.Text = "Наименование в пл.пор.";
			// 
			// OrgAccountEdit
			// 
			this.AcceptButton = this.bnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.CancelButton = this.bnCancel;
			this.ClientSize = new System.Drawing.Size(350, 173);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.tbBIK);
			this.Controls.Add(this.cmbCurr);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cmbBank);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.bnCancel);
			this.Controls.Add(this.bnOK);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "OrgAccountEdit";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Расчетный счёт";
			this.Load += new System.EventHandler(this.OrgAccountEdit_Load);
			((System.ComponentModel.ISupportInitialize)(this.dvBank)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void bnOK_Click(object sender, System.EventArgs e)
		{
			if(!this.validateOrgAccount())
				return;
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void bnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		private bool validateOrgAccount()
		{
			if(this.textBox1.Text.Length == 0)
			{
				AM_Controls.MsgBoxX.Show("Заполните поле Р./СЧЁТ","BPS",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				this.textBox1.Focus();
				return false;
			}
			if(this.textBox1.Text.Length != 20)
			{
				AM_Controls.MsgBoxX.Show("Р.счёт должен содержать 20 цифр!", "BPS", MessageBoxButtons.OK,MessageBoxIcon.Warning);
				err.SetError(textBox1,"Р.счёт должен содержать 20 цифр!");
				this.textBox1.Focus();
				return false;
			}
			err.SetError(textBox1,"");
			if(this.cmbBank.SelectedIndex == -1)
			{
				AM_Controls.MsgBoxX.Show("Выберите БАНК","BPS",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				return false;
			}
			if(this.cmbCurr.SelectedIndex == -1)
			{
				AM_Controls.MsgBoxX.Show("Выберите ВАЛЮТУ","BPS",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				return false;
			}
			return true;
		}
		private void button3_Click(object sender, System.EventArgs e)
		{

 			int iCount = App.DsBanks.Banks.Count;
//			App.ShowAddBank(this.cmbBank.Text, this.tbBIK.Text);
			Forms.Bank.EditBank.AddBankDialog(App.bllBank,App.bllCity, this.cmbBank.Text, this.tbBIK.Text);

			if(iCount < App.DsBanks.Banks.Count)
			{
				this.cmbBank.SelectedValue = App.DsBanks.Banks[iCount].BankID;
			}
		}

		private void comboBox1_Leave(object sender, System.EventArgs e)
		{
			
			this.checkBank();
		}
		private void checkBank()
		{
/*
 * 			this.cmbBank.SelectedIndex = this.cmbBank.FindStringExact(this.cmbBank.Text);
			if(this.cmbBank.SelectedIndex == -1)
			{
				int iCount = App.DsBanks.Banks.Count;
				App.ShowAddBank(this.cmbBank.Text, this.tbBIK.Text);
				if(iCount < App.DsBanks.Banks.Count)
				{
					this.cmbBank.SelectedValue = App.DsBanks.Banks[iCount].BankID;
				}
			}
*/		}
		private void button1_Click(object sender, System.EventArgs e)
		{
			// App.ShowAddCurr();
		}

		private void cmbCurr_Leave(object sender, System.EventArgs e)
		{
			//if(this.cmbCurr.SelectedIndex == -1)
			//App.ShowAddCurr();
		}

		private void cmbBank_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(!bIsLoad)
			{
				this.tbBIK.Text = "";
				return;
			}
			this.getBIK();
		}
		private void getBIK()
		{
			if(this.cmbBank.SelectedIndex == -1)
			{
				//this.tbBIK.Text = "";
				return;
			}
			//----------------------------------------------------------
			DataRow [] dr = this.dvBank.Table.Select("BankID=" + this.cmbBank.SelectedValue.ToString());
			if(dr.Length != 1)
			{
				this.tbBIK.Text = "";
				return;
			}
			this.tbBIK.Text = dr[0]["CodeBIK"].ToString();
		}
		private void OrgAccountEdit_Load(object sender, System.EventArgs e)
		{
			bIsLoad = true;
			this.getBIK();
		}

		private void tbBIK_Leave(object sender, System.EventArgs e)
		{
/*			if((this.tbBIK.Text.Length > 0) && (this.tbBIK.Text.Length < 9))
			{
				AM_Controls.MsgBoxX.Show("БИК должен содержать 9 цифр.");
				err.SetError(this.tbBIK,"БИК должен содержать 9 цифр.");
				this.tbBIK.Focus();
				return;
			}
			err.SetError(this.tbBIK,"");
*/
			if (this.tbBIK.HasError)
				return;

			DataRow [] dr = this.dvBank.Table.Select("CodeBIK='" + this.tbBIK.Text + "'");
			if(dr.Length != 1)
			{
				string szTmp = "";
				szTmp = tbBIK.Text;
				int iCount = App.DsBanks.Banks.Count;

//				App.ShowAddBank("", this.tbBIK.Text);
				this.cmbBank.SelectedIndex = -1;
				Forms.Bank.EditBank.AddBankDialog(App.bllBank,App.bllCity, "", this.tbBIK.Text);
				if(iCount < App.DsBanks.Banks.Count)
				{
					this.cmbBank.SelectedValue = App.DsBanks.Banks[iCount].BankID;
				}
				this.getBIK();
				return;
			}
			this.cmbBank.SelectedValue = dr[0]["BankID"];
		}
	}
}
