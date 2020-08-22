using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using AM_Controls;

namespace BPS._Forms.Currency
{
	/// <summary>
	/// Summary description for EditCurr.
	/// </summary>
	public class EditCurr : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.TextBox tbCurrID;
		internal System.Windows.Forms.TextBox tbCurrName;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private BPS.BLL.Currency.DataSets.dsCurr dsCurr1;
		private System.Data.DataView dataView1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		internal AM_Controls.TextBoxV tbvRate;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private BPS.BLL.Currency.DataSets.dsCurr.CurrenciesRow drowCurrency;

		public EditCurr(BPS.BLL.Currency.DataSets.dsCurr.CurrenciesRow rw)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			drowCurrency = rw;
			
			if (drowCurrency .RowState == DataRowState.Detached) // Новая
			{
				this.tbCurrID.ReadOnly		=false;
				this.tbCurrName.ReadOnly	=false; 
				this.tbvRate.ReadOnly		=false; 
				this.Text += " [Новая]";
			}
			else	// Редактируемая
			{
				this.tbCurrID.Text		=drowCurrency.CurrencyID;
				this.tbCurrName.Text	=drowCurrency.CurrencyName;
				this.tbvRate.dValue		=drowCurrency.CurrencyRate;
				this.tbCurrID.ReadOnly		=true;
				this.tbCurrName.ReadOnly	=false; 
				this.tbvRate.ReadOnly		=true; 
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(EditCurr));
			this.tbCurrID = new System.Windows.Forms.TextBox();
			this.dataView1 = new System.Data.DataView();
			this.dsCurr1 = new BPS.BLL.Currency.DataSets.dsCurr();
			this.tbCurrName = new System.Windows.Forms.TextBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.tbvRate = new AM_Controls.TextBoxV();
			((System.ComponentModel.ISupportInitialize)(this.dataView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsCurr1)).BeginInit();
			this.SuspendLayout();
			// 
			// tbCurrID
			// 
			this.tbCurrID.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbCurrID.Location = new System.Drawing.Point(70, 0);
			this.tbCurrID.MaxLength = 3;
			this.tbCurrID.Name = "tbCurrID";
			this.tbCurrID.Size = new System.Drawing.Size(50, 21);
			this.tbCurrID.TabIndex = 1;
			this.tbCurrID.Text = "";
			// 
			// dataView1
			// 
			this.dataView1.Table = this.dsCurr1.Currencies;
			// 
			// dsCurr1
			// 
			this.dsCurr1.DataSetName = "dsCurr";
			this.dsCurr1.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// tbCurrName
			// 
			this.tbCurrName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbCurrName.Location = new System.Drawing.Point(70, 22);
			this.tbCurrName.MaxLength = 50;
			this.tbCurrName.Name = "tbCurrName";
			this.tbCurrName.Size = new System.Drawing.Size(192, 21);
			this.tbCurrName.TabIndex = 3;
			this.tbCurrName.Text = "";
			// 
			// btnOK
			// 
			this.btnOK.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.btnOK.Location = new System.Drawing.Point(100, 90);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(80, 22);
			this.btnOK.TabIndex = 6;
			this.btnOK.Text = "Сохранить";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.btnCancel.Location = new System.Drawing.Point(182, 90);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(80, 22);
			this.btnCancel.TabIndex = 7;
			this.btnCancel.Text = "Отменить";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(4, 3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Код:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(4, 25);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Название:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(4, 48);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 16);
			this.label3.TabIndex = 4;
			this.label3.Text = "Курс:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbvRate
			// 
			this.tbvRate.AllowDrop = true;
			this.tbvRate.dValue = 0;
			this.tbvRate.IsPcnt = false;
			this.tbvRate.Location = new System.Drawing.Point(70, 44);
			this.tbvRate.MaxDecPos = 2;
			this.tbvRate.MaxPos = 8;
			this.tbvRate.Name = "tbvRate";
			this.tbvRate.nValue = ((long)(0));
			this.tbvRate.TabIndex = 5;
			this.tbvRate.Text = "0";
			this.tbvRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbvRate.TextMode = false;
			// 
			// EditCurr
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(268, 117);
			this.Controls.Add(this.tbvRate);
			this.Controls.Add(this.tbCurrID);
			this.Controls.Add(this.tbCurrName);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.label3);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "EditCurr";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Валюта";
			((System.ComponentModel.ISupportInitialize)(this.dataView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsCurr1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if(!this.validateCurr())
			    return;

			drowCurrency.CurrencyID   = this.tbCurrID.Text;
			drowCurrency.CurrencyName = this.tbCurrName.Text;
			drowCurrency.CurrencyRate = this.tbvRate.dValue;
			this.DialogResult = DialogResult.OK ;
			this.Close();
		}



		private bool validateCurr()
		{
			this.tbCurrID.Text = this.tbCurrID.Text.Trim();
			if ( this.tbCurrID.Text.Length == 0)
			{
				MsgBoxX.Show("Заполните поле КОД","BPS", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				this.tbCurrID.Focus();
				return false;
			}
			else 
			{
				if ( drowCurrency .RowState == DataRowState.Detached && drowCurrency.Table.Select("CurrencyID=\'" +this.tbCurrID.Text +"\'").Length!=0) 
				{
					MsgBoxX.Show("Валюта с таким кодом уже существует в системе");
					this.tbCurrID.Focus();
					return false;
				}
			}

			this.tbCurrName.Text = this.tbCurrName.Text.Trim();
			if ( this.tbCurrName.Text.Length == 0)
			{
				MsgBoxX.Show("Заполните поле НАЗВАНИЕ","BPS", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				this.tbCurrName.Focus();
				return false;
			}

			if ( this.tbvRate.dValue <=0)
			{
				MsgBoxX.Show("Заполните поле КУРС","BPS", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				this.tbvRate.Focus();
				return false;
			}
			return true;
		}

	}
}
