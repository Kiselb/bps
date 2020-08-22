using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using BPS.BLL.Credits.DataSets;

namespace BPS._Forms
{
	/// <summary>
	/// Summary description for CreditOnGrantEdit.
	/// </summary>
	public class CreditOnGrantEdit : System.Windows.Forms.Form
	{
		private AM_Controls.TextBoxV tbServiceChargeExtra;
		private System.Windows.Forms.Label label7;
		private AM_Controls.TextBoxV tbServiceCharge;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.DateTimePicker dtEndDate;
		private System.Windows.Forms.DateTimePicker dtStartDate;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnCancel;
		private dsCredits.CreditsRow m_row;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Label label10;
		private AM_Controls.TextBoxV tbPeriod;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cmbCreditType;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CreditOnGrantEdit(dsCredits.CreditsRow rw)
		{
			//
			// Required for Windows Form Designer support
			//
			m_row = rw;
			InitializeComponent();
			
			this.cmbCreditType.Text = m_row.CreditType;
			this.dtStartDate.Value = m_row.StartDate.Date;
			this.dtEndDate.Value = m_row.EndDate.Date;

			this.tbServiceCharge.dValue = m_row.ServiceCharge;
			this.tbServiceChargeExtra.dValue = m_row.ServiceChargeExtra;

			if(m_row.IsGranted)
			{
				this.Text += " [ВЫДАЧА]";
				this.btnSave.Text = "Выдать";
			}
			else
			{
				this.Text += " [ПОЛУЧЕНИЕ]";
				this.btnSave.Text = "Получить";
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(CreditOnGrantEdit));
			this.tbServiceChargeExtra = new AM_Controls.TextBoxV();
			this.label7 = new System.Windows.Forms.Label();
			this.tbServiceCharge = new AM_Controls.TextBoxV();
			this.label6 = new System.Windows.Forms.Label();
			this.dtEndDate = new System.Windows.Forms.DateTimePicker();
			this.dtStartDate = new System.Windows.Forms.DateTimePicker();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.label10 = new System.Windows.Forms.Label();
			this.tbPeriod = new AM_Controls.TextBoxV();
			this.label9 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.cmbCreditType = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// tbServiceChargeExtra
			// 
			this.tbServiceChargeExtra.AllowDrop = true;
			this.tbServiceChargeExtra.dValue = 0;
			this.tbServiceChargeExtra.Enabled = false;
			this.tbServiceChargeExtra.IsPcnt = true;
			this.tbServiceChargeExtra.Location = new System.Drawing.Point(128, 132);
			this.tbServiceChargeExtra.MaxDecPos = 2;
			this.tbServiceChargeExtra.MaxPos = 8;
			this.tbServiceChargeExtra.Name = "tbServiceChargeExtra";
			this.tbServiceChargeExtra.nValue = ((long)(0));
			this.tbServiceChargeExtra.ReadOnly = true;
			this.tbServiceChargeExtra.Size = new System.Drawing.Size(154, 21);
			this.tbServiceChargeExtra.TabIndex = 21;
			this.tbServiceChargeExtra.Text = "";
			this.tbServiceChargeExtra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbServiceChargeExtra.TextMode = false;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(6, 134);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(116, 16);
			this.label7.TabIndex = 20;
			this.label7.Text = "Ставка за просрочку:";
			// 
			// tbServiceCharge
			// 
			this.tbServiceCharge.AllowDrop = true;
			this.tbServiceCharge.dValue = 0;
			this.tbServiceCharge.Enabled = false;
			this.tbServiceCharge.IsPcnt = true;
			this.tbServiceCharge.Location = new System.Drawing.Point(128, 108);
			this.tbServiceCharge.MaxDecPos = 2;
			this.tbServiceCharge.MaxPos = 8;
			this.tbServiceCharge.Name = "tbServiceCharge";
			this.tbServiceCharge.nValue = ((long)(0));
			this.tbServiceCharge.ReadOnly = true;
			this.tbServiceCharge.Size = new System.Drawing.Size(154, 21);
			this.tbServiceCharge.TabIndex = 19;
			this.tbServiceCharge.Text = "";
			this.tbServiceCharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbServiceCharge.TextMode = false;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(6, 110);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(110, 16);
			this.label6.TabIndex = 18;
			this.label6.Text = "Процентная ставка:";
			// 
			// dtEndDate
			// 
			this.dtEndDate.Enabled = false;
			this.dtEndDate.Location = new System.Drawing.Point(128, 84);
			this.dtEndDate.Name = "dtEndDate";
			this.dtEndDate.Size = new System.Drawing.Size(154, 21);
			this.dtEndDate.TabIndex = 17;
			this.dtEndDate.ValueChanged += new System.EventHandler(this.dtEndDate_ValueChanged);
			// 
			// dtStartDate
			// 
			this.dtStartDate.Enabled = false;
			this.dtStartDate.Location = new System.Drawing.Point(128, 36);
			this.dtStartDate.Name = "dtStartDate";
			this.dtStartDate.Size = new System.Drawing.Size(154, 21);
			this.dtStartDate.TabIndex = 16;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 84);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 18);
			this.label5.TabIndex = 15;
			this.label5.Text = "Дата возврата:";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 38);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 18);
			this.label4.TabIndex = 14;
			this.label4.Text = "Дата выдачи:";
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.btnCancel.Location = new System.Drawing.Point(202, 164);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(80, 26);
			this.btnCancel.TabIndex = 23;
			this.btnCancel.Text = "Отменить";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnSave
			// 
			this.btnSave.Font = new System.Drawing.Font("Tahoma", 9.25F);
			this.btnSave.Location = new System.Drawing.Point(118, 164);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(80, 26);
			this.btnSave.TabIndex = 22;
			this.btnSave.Text = "Сохранить";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(249, 64);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(34, 18);
			this.label10.TabIndex = 26;
			this.label10.Text = "дней";
			// 
			// tbPeriod
			// 
			this.tbPeriod.AllowDrop = true;
			this.tbPeriod.dValue = 0;
			this.tbPeriod.Enabled = false;
			this.tbPeriod.IsPcnt = false;
			this.tbPeriod.Location = new System.Drawing.Point(128, 60);
			this.tbPeriod.MaxDecPos = 2;
			this.tbPeriod.MaxPos = 8;
			this.tbPeriod.Name = "tbPeriod";
			this.tbPeriod.nValue = ((long)(0));
			this.tbPeriod.ReadOnly = true;
			this.tbPeriod.Size = new System.Drawing.Size(114, 21);
			this.tbPeriod.TabIndex = 25;
			this.tbPeriod.Text = "";
			this.tbPeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbPeriod.TextMode = false;
			this.tbPeriod.Leave += new System.EventHandler(this.tbPeriod_Leave);
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(7, 60);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(100, 18);
			this.label9.TabIndex = 24;
			this.label9.Text = "Сроком на:";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 16);
			this.label1.TabIndex = 27;
			this.label1.Text = "Тип кредита:";
			// 
			// cmbCreditType
			// 
			this.cmbCreditType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCreditType.Enabled = false;
			this.cmbCreditType.Items.AddRange(new object[] {
															   "Краткосрочный",
															   "Долгосрочный",
															   "С планом погашения"});
			this.cmbCreditType.Location = new System.Drawing.Point(128, 12);
			this.cmbCreditType.Name = "cmbCreditType";
			this.cmbCreditType.Size = new System.Drawing.Size(154, 21);
			this.cmbCreditType.TabIndex = 28;
			// 
			// CreditOnGrantEdit
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(290, 197);
			this.Controls.Add(this.cmbCreditType);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.tbPeriod);
			this.Controls.Add(this.tbServiceChargeExtra);
			this.Controls.Add(this.tbServiceCharge);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.dtEndDate);
			this.Controls.Add(this.dtStartDate);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CreditOnGrantEdit";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Кредит";
			this.ResumeLayout(false);

		}
		#endregion

		private void btnSave_Click(object sender, System.EventArgs e)
		{
//			this.m_row.ServiceCharge = this.tbServiceCharge.dValue;
//			this.m_row.ServiceChargeExtra = this.tbServiceChargeExtra.dValue;
//			this.m_row.StartDate = this.dtStartDate.Value.Date;
//			this.m_row.EndDate = this.dtEndDate.Value.Date;

			DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		private void tbPeriod_Leave(object sender, System.EventArgs e)
		{
			//this.dtEndDate.Value = this.dtStartDate.Value.Date.AddDays(this.tbPeriod.nValue);
		}

		private void dtEndDate_ValueChanged(object sender, System.EventArgs e)
		{
			TimeSpan diff = this.dtEndDate.Value.Date.Subtract(this.dtStartDate.Value.Date);
			this.tbPeriod.nValue = diff.Days;
		}
	}
}
