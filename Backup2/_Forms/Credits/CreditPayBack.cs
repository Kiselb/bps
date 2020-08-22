using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace BPS._Forms
{
	/// <summary>
	/// Summary description for CreditPayBack.
	/// </summary>
	public class CreditPayBack : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button dtnSave;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.Label label2;
		private double m_CreditPayBackSum = 0;
		private DateTime m_PayBackDateTime;
		private AM_Controls.TextBoxV tbSum;

		public double CreditPayBackSum
		{
			get
			{
				return m_CreditPayBackSum;;
			}
		}

		public DateTime PayBackDateTime
		{
			get
			{
				return m_PayBackDateTime;
			}
		}

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CreditPayBack()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(CreditPayBack));
			this.btnCancel = new System.Windows.Forms.Button();
			this.dtnSave = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.label2 = new System.Windows.Forms.Label();
			this.tbSum = new AM_Controls.TextBoxV();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.btnCancel.Location = new System.Drawing.Point(122, 60);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(80, 26);
			this.btnCancel.TabIndex = 23;
			this.btnCancel.Text = "Отменить";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// dtnSave
			// 
			this.dtnSave.Font = new System.Drawing.Font("Tahoma", 9.25F);
			this.dtnSave.Location = new System.Drawing.Point(38, 60);
			this.dtnSave.Name = "dtnSave";
			this.dtnSave.Size = new System.Drawing.Size(80, 26);
			this.dtnSave.TabIndex = 22;
			this.dtnSave.Text = "Сохранить";
			this.dtnSave.Click += new System.EventHandler(this.dtnSave_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(46, 18);
			this.label1.TabIndex = 21;
			this.label1.Text = "Дата:";
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Location = new System.Drawing.Point(60, 6);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(140, 20);
			this.dateTimePicker1.TabIndex = 20;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(6, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 16);
			this.label2.TabIndex = 24;
			this.label2.Text = "Сумма:";
			// 
			// tbSum
			// 
			this.tbSum.AllowDrop = true;
			this.tbSum.dValue = 0;
			this.tbSum.IsPcnt = false;
			this.tbSum.Location = new System.Drawing.Point(60, 30);
			this.tbSum.MaxDecPos = 2;
			this.tbSum.MaxPos = 8;
			this.tbSum.Name = "tbSum";
			this.tbSum.nValue = ((long)(0));
			this.tbSum.Size = new System.Drawing.Size(140, 20);
			this.tbSum.TabIndex = 25;
			this.tbSum.Text = "";
			this.tbSum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbSum.TextMode = false;
			// 
			// CreditPayBack
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(208, 95);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.tbSum,
																		  this.label2,
																		  this.btnCancel,
																		  this.dtnSave,
																		  this.label1,
																		  this.dateTimePicker1});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "CreditPayBack";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Погашение";
			this.ResumeLayout(false);

		}
		#endregion


		private void dtnSave_Click(object sender, System.EventArgs e)
		{
			m_CreditPayBackSum = this.tbSum.dValue;
			m_PayBackDateTime = this.dateTimePicker1.Value.Date;
			DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Close();
		}
	}
}
