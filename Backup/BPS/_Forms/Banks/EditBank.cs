using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using AM_Controls;

namespace BPS.Forms.Bank
{
	/// <summary>
	/// Summary description for EditBanks.
	/// </summary>
	public class EditBank : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.TextBox tbName;
	
		private System.Windows.Forms.Button bnOK;
		private System.Windows.Forms.Button bnCancel;
		internal System.Windows.Forms.ComboBox cmbCity;
		internal AM_Controls.TextBoxBIK tbBIK;
		internal AM_Controls.TextBoxV tbKAccount;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private System.Data.DataView dvCities;
		private BPS.BLL.City.DataSets.dsCities dsCities1;
	
		private BPS.BLL.City.coCities bllCity;
		private System.Windows.Forms.Button button1;
		BPS.BLL.Bank.DataSets.dsBanks.BanksRow drowBank;

		public EditBank(BPS.BLL.Bank.DataSets.dsBanks.BanksRow rw, BPS.BLL.City.coCities bll)
		{
			drowBank = rw;
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			bllCity = bll;
			
			this.dsCities1= bllCity.DataSet;
			this.dvCities.Table = this.dsCities1.Cities;
			this.dvCities.Sort="CityName";


		}

		public static bool AddBankDialog(BPS.BLL.Bank.coBanks bll, BPS.BLL.City.coCities bllC, string sBankName, string sBIK )
		{
			BPS.BLL.Bank.DataSets.dsBanks.BanksRow rw = bll.DataSet.Banks.NewBanksRow();
			EditBank eb = new EditBank(rw, bllC);
			eb.tbName.Text = sBankName;
			eb.tbBIK.Text = sBIK;
			eb.ShowDialog();
			if(eb.DialogResult == DialogResult.OK)
			{
				bll.DataSet.Banks.AddBanksRow(rw);
				bll.Update();
				return true;
			}
			return false;
		}

		private void EditBank_Load(object sender, System.EventArgs e)
		{
			if (!drowBank.IsCityIDNull())
				this.cmbCity.SelectedValue = drowBank.CityID;
			if (!drowBank.IsKAccountNull())
				this.tbKAccount.Text = drowBank.KAccount;
			if (!drowBank.IsCodeBIKNull())
				this.tbBIK.Text = drowBank.CodeBIK;
			if (!drowBank.IsBankNameNull())
				this.tbName.Text = drowBank.BankName;

			if (drowBank.RowState == DataRowState.Detached)	// новая запись
			{
				if(this.cmbCity.Items.Count>0 && this.cmbCity.SelectedIndex==-1 )
					this.cmbCity.SelectedIndex = 0;
				this.Text += " [Новый]";

			}
			else	// Редактируемая запись
			{
				this.Text += " [Редактирование]";
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(EditBank));
			this.tbName = new System.Windows.Forms.TextBox();
			this.bnOK = new System.Windows.Forms.Button();
			this.bnCancel = new System.Windows.Forms.Button();
			this.cmbCity = new System.Windows.Forms.ComboBox();
			this.dvCities = new System.Data.DataView();
			this.dsCities1 = new BPS.BLL.City.DataSets.dsCities();
			this.tbBIK = new AM_Controls.TextBoxBIK();
			this.tbKAccount = new AM_Controls.TextBoxV();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dvCities)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsCities1)).BeginInit();
			this.SuspendLayout();
			// 
			// tbName
			// 
			this.tbName.Location = new System.Drawing.Point(90, 2);
			this.tbName.MaxLength = 128;
			this.tbName.Name = "tbName";
			this.tbName.Size = new System.Drawing.Size(194, 21);
			this.tbName.TabIndex = 1;
			this.tbName.Text = "";
			// 
			// bnOK
			// 
			this.bnOK.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.bnOK.Location = new System.Drawing.Point(122, 108);
			this.bnOK.Name = "bnOK";
			this.bnOK.Size = new System.Drawing.Size(80, 26);
			this.bnOK.TabIndex = 9;
			this.bnOK.Text = "Сохранить";
			this.bnOK.Click += new System.EventHandler(this.bnOK_Click);
			// 
			// bnCancel
			// 
			this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.bnCancel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.bnCancel.Location = new System.Drawing.Point(204, 108);
			this.bnCancel.Name = "bnCancel";
			this.bnCancel.Size = new System.Drawing.Size(80, 26);
			this.bnCancel.TabIndex = 10;
			this.bnCancel.Text = "Отменить";
			this.bnCancel.Click += new System.EventHandler(this.bnCancel_Click);
			// 
			// cmbCity
			// 
			this.cmbCity.DataSource = this.dvCities;
			this.cmbCity.DisplayMember = "CityName";
			this.cmbCity.Location = new System.Drawing.Point(90, 24);
			this.cmbCity.MaxDropDownItems = 20;
			this.cmbCity.Name = "cmbCity";
			this.cmbCity.Size = new System.Drawing.Size(168, 21);
			this.cmbCity.TabIndex = 3;
			this.cmbCity.ValueMember = "CityID";
			this.cmbCity.Leave += new System.EventHandler(this.cmbCity_Leave);
			// 
			// dvCities
			// 
			this.dvCities.Sort = "CityName";
			this.dvCities.Table = this.dsCities1.Cities;
			// 
			// dsCities1
			// 
			this.dsCities1.DataSetName = "dsCities";
			this.dsCities1.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// tbBIK
			// 
			this.tbBIK.AllowDrop = true;
			this.tbBIK.dValue = 0;
			this.tbBIK.IsPcnt = false;
			this.tbBIK.Location = new System.Drawing.Point(90, 46);
			this.tbBIK.MaxDecPos = 0;
			this.tbBIK.MaxLength = 9;
			this.tbBIK.MaxPos = 9;
			this.tbBIK.Name = "tbBIK";
			this.tbBIK.Negative = System.Drawing.Color.Empty;
			this.tbBIK.nValue = ((long)(0));
			this.tbBIK.Positive = System.Drawing.Color.Empty;
			this.tbBIK.Size = new System.Drawing.Size(194, 21);
			this.tbBIK.TabIndex = 6;
			this.tbBIK.Text = "";
			this.tbBIK.TextMode = true;
			this.tbBIK.Zero = System.Drawing.Color.Empty;
			// 
			// tbKAccount
			// 
			this.tbKAccount.AllowDrop = true;
			this.tbKAccount.dValue = 0;
			this.tbKAccount.IsPcnt = false;
			this.tbKAccount.Location = new System.Drawing.Point(90, 68);
			this.tbKAccount.MaxDecPos = 0;
			this.tbKAccount.MaxLength = 20;
			this.tbKAccount.MaxPos = 20;
			this.tbKAccount.Name = "tbKAccount";
			this.tbKAccount.Negative = System.Drawing.Color.Empty;
			this.tbKAccount.nValue = ((long)(0));
			this.tbKAccount.Positive = System.Drawing.Color.Empty;
			this.tbKAccount.Size = new System.Drawing.Size(194, 21);
			this.tbKAccount.TabIndex = 8;
			this.tbKAccount.Text = "";
			this.tbKAccount.TextMode = true;
			this.tbKAccount.Zero = System.Drawing.Color.Empty;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(84, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Наименование:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(6, 22);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Город:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(6, 44);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(40, 23);
			this.label3.TabIndex = 5;
			this.label3.Text = "БИК:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(6, 68);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 23);
			this.label4.TabIndex = 7;
			this.label4.Text = "Кор. счёт:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// button1
			// 
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
			this.button1.Location = new System.Drawing.Point(260, 24);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(24, 21);
			this.button1.TabIndex = 4;
			this.button1.TabStop = false;
			this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// EditBank
			// 
			this.AcceptButton = this.bnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.CancelButton = this.bnCancel;
			this.ClientSize = new System.Drawing.Size(298, 137);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tbKAccount);
			this.Controls.Add(this.tbBIK);
			this.Controls.Add(this.tbName);
			this.Controls.Add(this.cmbCity);
			this.Controls.Add(this.bnCancel);
			this.Controls.Add(this.bnOK);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "EditBank";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Банк";
			this.Load += new System.EventHandler(this.EditBank_Load);
			((System.ComponentModel.ISupportInitialize)(this.dvCities)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsCities1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		

		private void cmbCity_Leave(object sender, System.EventArgs e)
		{
			this.cmbCity.SelectedIndex = this.cmbCity.FindStringExact(this.cmbCity.Text);
			if(this.cmbCity.SelectedIndex == -1)
			{
				this.AddCity();
			}
		}

		private bool validateBank()
		{
			this.tbName.Text = AM_Lib.TrimSpec.Trim(this.tbName.Text);
			if(this.tbName.Text.Length == 0)
			{
				MsgBoxX.Show("Заполните поле НАЗВАНИЕ","BPS",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				this.tbName.Focus();
				return false;
			}
			
			if(this.cmbCity.SelectedIndex == -1)
			{
				MsgBoxX.Show("Правильно выберите ГОРОД","BPS",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				this.cmbCity.Focus();
				return false;
			}
			
			if(this.tbBIK.Text.Length == 0)
			{
				MsgBoxX.Show("Заполните поле БИК","BPS",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				this.tbBIK.Focus();
				return false;
			}
			if(this.tbBIK.Text.Length != 9)
			{
				MsgBoxX.Show("Поле БИК должно содержать 9 цифр!","BPS",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				this.tbBIK.Focus();
				return false;
			}
			else 
			{
				DataRow [] dr = this.drowBank.Table.Select("CodeBIK='" + this.tbBIK.Text + "'");
				if(dr.Length>0 && drowBank.RowState==DataRowState.Detached)
				{
					AM_Controls.MsgBoxX.Show("Банк с БИК " + this.tbBIK.Text + " уже существует", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					this.tbBIK.Focus();
					return false;
				}

			}
			if(this.tbKAccount.Text.Length == 0)
			{
				MsgBoxX.Show("Заполните поле КОР. СЧЁТ","BPS",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				this.tbKAccount.Focus();
				return false;
			}
			if(this.tbKAccount.Text.Length != 20)
			{
				MsgBoxX.Show("Поле КОР. СЧЁТ должно содержать 20 цифр!","BPS",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				this.tbKAccount.Focus();
				return false;				
			}
			return true;
		}

		private void bnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void bnOK_Click(object sender, System.EventArgs e)
		{
			if(!this.validateBank())
				return;

			drowBank.BankName = this.tbName.Text;
			drowBank.CodeBIK = this.tbBIK.Text;
			drowBank.KAccount = this.tbKAccount.Text;
			drowBank.CityID = Convert.ToInt32(this.cmbCity.SelectedValue);
			drowBank.CityName = this.cmbCity.Text;
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void AddCity()
		{
			BPS.Forms.City.CityEdit CityEditForm = new BPS.Forms.City.CityEdit(this.bllCity, this.cmbCity.Text);
			if(CityEditForm.ShowDialog() == DialogResult.OK)
			{
				if (
					this.bllCity.DataSet.Cities.Select("CityName=\'"+CityEditForm.strCityName+"\'").Length !=0 )
				{
					MsgBoxX.Show("Такой город уже существует в справочнике","BPS",MessageBoxButtons.OK,MessageBoxIcon.Warning);
					return;
				}
				BPS.BLL.City.DataSets.dsCities.CitiesRow rw = this.bllCity.DataSet.Cities.NewCitiesRow();
				rw.CityName = CityEditForm.strCityName;
				this.bllCity.DataSet.Cities.AddCitiesRow(rw);
				this.bllCity.Update();
			}
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			int iCount = this.dvCities.Table.Rows.Count;
			this.AddCity();
			if(iCount < this.dvCities.Table.Rows.Count)
				this.cmbCity.SelectedValue = this.dvCities.Table.Rows[iCount]["CityID"];
		}


	}
}
