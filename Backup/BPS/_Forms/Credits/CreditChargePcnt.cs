using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace BPS._Forms
{
	/// <summary>
	/// Summary description for CreditChargePcnt.
	/// </summary>
	public class CreditChargePcnt : System.Windows.Forms.Form
	{
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button dtnSave;
		private DateTime m_ChargeDate;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;

		public DateTime ChargeDate
		{
			get
			{
				return m_ChargeDate;
			}
		}
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CreditChargePcnt()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(CreditChargePcnt));
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.dtnSave = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Location = new System.Drawing.Point(156, 8);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(136, 21);
			this.dateTimePicker1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(7, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(147, 18);
			this.label1.TabIndex = 1;
			this.label1.Text = "Дата завершения Кредита:";
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.btnCancel.Location = new System.Drawing.Point(191, 148);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(80, 22);
			this.btnCancel.TabIndex = 19;
			this.btnCancel.Text = "Отменить";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// dtnSave
			// 
			this.dtnSave.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.dtnSave.Location = new System.Drawing.Point(109, 148);
			this.dtnSave.Name = "dtnSave";
			this.dtnSave.Size = new System.Drawing.Size(80, 22);
			this.dtnSave.TabIndex = 18;
			this.dtnSave.Text = "Выполнить";
			this.dtnSave.Click += new System.EventHandler(this.dtnSave_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(58, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(312, 22);
			this.label2.TabIndex = 20;
			this.label2.Text = "Завершение кредита возможно только в том случае, если:";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(10, 40);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(34, 32);
			this.pictureBox1.TabIndex = 21;
			this.pictureBox1.TabStop = false;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(80, 64);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(198, 18);
			this.label3.TabIndex = 22;
			this.label3.Text = " - Погашено тело кредита;";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(80, 84);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(288, 34);
			this.label4.TabIndex = 22;
			this.label4.Text = " - Начислены и Погашены проценты и/или штрафные проценты на указываемую дату заве" +
				"ршения кредита.";
			// 
			// CreditChargePcnt
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(374, 175);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.dtnSave);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dateTimePicker1);
			this.Controls.Add(this.label4);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CreditChargePcnt";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Закрыть кредит";
			this.ResumeLayout(false);

		}
		#endregion

		private void dtnSave_Click(object sender, System.EventArgs e)
		{
			m_ChargeDate = this.dateTimePicker1.Value;
			DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Close();
		}
	}
}
