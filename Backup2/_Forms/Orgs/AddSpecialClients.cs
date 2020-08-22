using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace BPS._Forms.Orgs
{
	/// <summary>
	/// Summary description for AddSpecialClients.
	/// </summary>
	public class AddSpecialClients : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox tbClientName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button bnOK;
		private System.Windows.Forms.Button bnCancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AddSpecialClients()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
		public string ClientName
		{
			get
			{
				return this.tbClientName.Text;
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
			this.tbClientName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.bnOK = new System.Windows.Forms.Button();
			this.bnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// tbClientName
			// 
			this.tbClientName.Location = new System.Drawing.Point(80, 8);
			this.tbClientName.MaxLength = 50;
			this.tbClientName.Name = "tbClientName";
			this.tbClientName.Size = new System.Drawing.Size(302, 21);
			this.tbClientName.TabIndex = 0;
			this.tbClientName.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(4, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(74, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Имя клиента:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// bnOK
			// 
			this.bnOK.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.bnOK.Location = new System.Drawing.Point(224, 40);
			this.bnOK.Name = "bnOK";
			this.bnOK.Size = new System.Drawing.Size(80, 26);
			this.bnOK.TabIndex = 2;
			this.bnOK.Text = "Сохранить";
			this.bnOK.Click += new System.EventHandler(this.bnOK_Click);
			// 
			// bnCancel
			// 
			this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.bnCancel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.bnCancel.Location = new System.Drawing.Point(306, 40);
			this.bnCancel.Name = "bnCancel";
			this.bnCancel.Size = new System.Drawing.Size(80, 26);
			this.bnCancel.TabIndex = 3;
			this.bnCancel.Text = "Отменить";
			this.bnCancel.Click += new System.EventHandler(this.bnCancel_Click);
			// 
			// AddSpecialClients
			// 
			this.AcceptButton = this.bnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.CancelButton = this.bnCancel;
			this.ClientSize = new System.Drawing.Size(392, 71);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.bnCancel,
																		  this.bnOK,
																		  this.label1,
																		  this.tbClientName});
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AddSpecialClients";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Специальный клиент [Новый]";
			this.ResumeLayout(false);

		}
		#endregion

		private void bnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void bnOK_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
	}
}
