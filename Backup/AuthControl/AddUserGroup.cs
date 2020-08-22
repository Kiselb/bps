using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace AuthControl
{
	/// <summary>
	/// Summary description for AddUserGroup.
	/// </summary>
	internal class AddUserGroup : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.TextBox tbName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button bnOK;
		private System.Windows.Forms.Button bnCancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AddUserGroup()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(AddUserGroup));
			this.tbName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.bnOK = new System.Windows.Forms.Button();
			this.bnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// tbName
			// 
			this.tbName.Location = new System.Drawing.Point(86, 4);
			this.tbName.Name = "tbName";
			this.tbName.Size = new System.Drawing.Size(260, 21);
			this.tbName.TabIndex = 0;
			this.tbName.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 4);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(74, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Имя группы:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// bnOK
			// 
			this.bnOK.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.bnOK.Location = new System.Drawing.Point(182, 34);
			this.bnOK.Name = "bnOK";
			this.bnOK.Size = new System.Drawing.Size(80, 26);
			this.bnOK.TabIndex = 2;
			this.bnOK.Text = "Записать";
			this.bnOK.Click += new System.EventHandler(this.bnOK_Click);
			// 
			// bnCancel
			// 
			this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.bnCancel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.bnCancel.Location = new System.Drawing.Point(264, 34);
			this.bnCancel.Name = "bnCancel";
			this.bnCancel.Size = new System.Drawing.Size(80, 26);
			this.bnCancel.TabIndex = 3;
			this.bnCancel.Text = "Отменить";
			this.bnCancel.Click += new System.EventHandler(this.bnCancel_Click);
			// 
			// AddUserGroup
			// 
			this.AcceptButton = this.bnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.CancelButton = this.bnCancel;
			this.ClientSize = new System.Drawing.Size(352, 67);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.bnCancel,
																		  this.bnOK,
																		  this.label1,
																		  this.tbName});
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AddUserGroup";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Новая группа пользователей";
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
