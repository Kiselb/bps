using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using AM_Controls;
using System.Reflection;

namespace BPS._Forms
{
	/// <summary>
	/// Summary description for About.
	/// </summary>
	public class About : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label lbVersion;
		private System.Windows.Forms.Label lbIssueDate;
		private System.Windows.Forms.Label label5;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public About()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			Assembly asm =Assembly.GetExecutingAssembly();
			
			this.lbVersion.Text =asm.FullName; 
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(About));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.lbVersion = new System.Windows.Forms.Label();
			this.lbIssueDate = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Arial Black", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
			this.label1.Location = new System.Drawing.Point(167, 98);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(204, 26);
			this.label1.TabIndex = 0;
			this.label1.Text = "AM Software";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label1.UseMnemonic = false;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
			this.label2.Location = new System.Drawing.Point(167, 122);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(204, 16);
			this.label2.TabIndex = 0;
			this.label2.Text = "Developers Group";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label2.UseMnemonic = false;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label3.Location = new System.Drawing.Point(2, 76);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(334, 16);
			this.label3.TabIndex = 1;
			this.label3.Text = "Copyright © 2003   AM Software.  All rights reserved.";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.Location = new System.Drawing.Point(5, 39);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(190, 16);
			this.label4.TabIndex = 1;
			this.label4.Text = "Boris Petrovich Special Service";
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button1.Location = new System.Drawing.Point(2, 74);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(3, 3);
			this.button1.TabIndex = 2;
			this.button1.Text = "Закрыть";
			this.button1.Visible = false;
			// 
			// lbVersion
			// 
			this.lbVersion.Location = new System.Drawing.Point(197, 1);
			this.lbVersion.Name = "lbVersion";
			this.lbVersion.Size = new System.Drawing.Size(174, 53);
			this.lbVersion.TabIndex = 3;
			// 
			// lbIssueDate
			// 
			this.lbIssueDate.Location = new System.Drawing.Point(197, 55);
			this.lbIssueDate.Name = "lbIssueDate";
			this.lbIssueDate.Size = new System.Drawing.Size(174, 15);
			this.lbIssueDate.TabIndex = 4;
			this.lbIssueDate.Text = "20.12.2003";
			this.lbIssueDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label5
			// 
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.Font = new System.Drawing.Font("Times New Roman", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label5.Location = new System.Drawing.Point(5, 2);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(109, 36);
			this.label5.TabIndex = 5;
			this.label5.Text = "BPSS";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// About
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.Cornsilk;
			this.CancelButton = this.button1;
			this.ClientSize = new System.Drawing.Size(378, 155);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.lbIssueDate);
			this.Controls.Add(this.lbVersion);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label4);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "About";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "About BPS";
			this.ResumeLayout(false);

		}
		#endregion
	}
}
