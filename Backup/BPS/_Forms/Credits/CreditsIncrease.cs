using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace BPS._Forms.Credits
{
	/// <summary>
	/// Summary description for CreditsIncrease.
	/// </summary>
	public class CreditsIncrease : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.DateTimePicker dtpDateInc;
		private AM_Controls.TextBoxV tbSumInc;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private double			m_IncSum =0;
		private System.DateTime m_IncDate;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CreditsIncrease()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(CreditsIncrease));
			this.dtpDateInc = new System.Windows.Forms.DateTimePicker();
			this.tbSumInc = new AM_Controls.TextBoxV();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// dtpDateInc
			// 
			this.dtpDateInc.CustomFormat = "dd-MMM-yy";
			this.dtpDateInc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpDateInc.Location = new System.Drawing.Point(165, 20);
			this.dtpDateInc.Name = "dtpDateInc";
			this.dtpDateInc.Size = new System.Drawing.Size(90, 20);
			this.dtpDateInc.TabIndex = 1;
			// 
			// tbSumInc
			// 
			this.tbSumInc.AllowDrop = true;
			this.tbSumInc.dValue = 0;
			this.tbSumInc.IsPcnt = false;
			this.tbSumInc.Location = new System.Drawing.Point(165, 66);
			this.tbSumInc.MaxDecPos = 2;
			this.tbSumInc.MaxPos = 8;
			this.tbSumInc.Name = "tbSumInc";
			this.tbSumInc.nValue = ((long)(0));
			this.tbSumInc.Size = new System.Drawing.Size(90, 20);
			this.tbSumInc.TabIndex = 2;
			this.tbSumInc.Text = "0";
			this.tbSumInc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbSumInc.TextMode = false;
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(74, 104);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 3;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(154, 104);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "Отменить";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(14, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(148, 30);
			this.label1.TabIndex = 4;
			this.label1.Text = "Фактическая Дата увеличения тела кредита: ";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(14, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(148, 39);
			this.label2.TabIndex = 5;
			this.label2.Text = "Сумма, на которую требуется увеличить тело кредита:";
			// 
			// CreditsIncrease
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(292, 133);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.tbSumInc);
			this.Controls.Add(this.dtpDateInc);
			this.Controls.Add(this.btnCancel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CreditsIncrease";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Увеличение Тела Кредита";
			this.ResumeLayout(false);

		}
		#endregion

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if ( this.tbSumInc.dValue >0) 
			{
				this.m_IncSum	=this.tbSumInc.dValue;
				this.m_IncDate	=this.dtpDateInc.Value;

				this.DialogResult =DialogResult.OK;
				this.Close();
			}
			else 
			{
				this.tbSumInc.Focus();
				MessageBox.Show("Для суммы увеличения тела кредита указано недопустимое значение.", "BPS",MessageBoxButtons.OK, MessageBoxIcon.Stop);
			}
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.DialogResult =DialogResult.Cancel;
			this.Close();		
		}

		public double IncreaseSum 
		{
			get { return this.m_IncSum; }
		}
		public System.DateTime IncreaseDate 
		{
			get { return this.m_IncDate; }
		}
	}
}
