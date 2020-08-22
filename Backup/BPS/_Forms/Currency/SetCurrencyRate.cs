using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace BPS._Forms.Currency
{
	/// <summary>
	/// Summary description for SetCurrencyRate.
	/// </summary>
	public class SetCurrencyRate : System.Windows.Forms.Form
	{
		internal AM_Controls.TextBoxV tbvNewRate;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SetCurrencyRate()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(SetCurrencyRate));
			this.tbvNewRate = new AM_Controls.TextBoxV();
			this.label1 = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// tbvNewRate
			// 
			this.tbvNewRate.dValue = 0;
			this.tbvNewRate.IsPcnt = false;
			this.tbvNewRate.Location = new System.Drawing.Point(134, 9);
			this.tbvNewRate.MaxDecPos = 2;
			this.tbvNewRate.MaxPos = 8;
			this.tbvNewRate.Name = "tbvNewRate";
			this.tbvNewRate.nValue = ((long)(0));
			this.tbvNewRate.TabIndex = 0;
			this.tbvNewRate.Text = "0";
			this.tbvNewRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbvNewRate.TextMode = false;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(11, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(119, 20);
			this.label1.TabIndex = 1;
			this.label1.Text = "¬ведите новый курс:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(47, 66);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 2;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(123, 66);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "ќтменить";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// SetCurrencyRate
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(242, 93);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnOK,
																		  this.label1,
																		  this.tbvNewRate,
																		  this.btnCancel});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "SetCurrencyRate";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = " урс";
			this.ResumeLayout(false);

		}
		#endregion

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if ( this.tbvNewRate.dValue >0 ) 
			{
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();		
		}
	}
}
