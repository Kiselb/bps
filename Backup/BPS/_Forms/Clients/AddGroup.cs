using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using AM_Controls;

namespace BPS._Forms.Clients
{
	/// <summary>
	/// Summary description for AddGroup.
	/// </summary>
	public class AddGroup : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.TextBox tbName;
		internal System.Windows.Forms.TextBox tbRemarks;
		private System.Windows.Forms.Button btOK;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AddGroup()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(AddGroup));
			this.tbName = new System.Windows.Forms.TextBox();
			this.tbRemarks = new System.Windows.Forms.TextBox();
			this.btOK = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// tbName
			// 
			this.tbName.Location = new System.Drawing.Point(84, 2);
			this.tbName.Name = "tbName";
			this.tbName.Size = new System.Drawing.Size(232, 21);
			this.tbName.TabIndex = 0;
			this.tbName.Text = "";
			// 
			// tbRemarks
			// 
			this.tbRemarks.Location = new System.Drawing.Point(84, 24);
			this.tbRemarks.Name = "tbRemarks";
			this.tbRemarks.Size = new System.Drawing.Size(498, 21);
			this.tbRemarks.TabIndex = 1;
			this.tbRemarks.Text = "";
			// 
			// btOK
			// 
			this.btOK.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btOK.Location = new System.Drawing.Point(418, 52);
			this.btOK.Name = "btOK";
			this.btOK.Size = new System.Drawing.Size(80, 26);
			this.btOK.TabIndex = 2;
			this.btOK.Text = "Записать";
			this.btOK.Click += new System.EventHandler(this.btOK_Click);
			// 
			// button2
			// 
			this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button2.Location = new System.Drawing.Point(504, 52);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(80, 26);
			this.button2.TabIndex = 3;
			this.button2.Text = "Отмена";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 23);
			this.label1.TabIndex = 4;
			this.label1.Text = "Название:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 22);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 23);
			this.label2.TabIndex = 5;
			this.label2.Text = "Примечание:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// AddGroup
			// 
			this.AcceptButton = this.btOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.CancelButton = this.button2;
			this.ClientSize = new System.Drawing.Size(590, 83);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.label2,
																		  this.label1,
																		  this.button2,
																		  this.btOK,
																		  this.tbRemarks,
																		  this.tbName});
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AddGroup";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Группа [Новая]";
			this.ResumeLayout(false);

		}
		#endregion

		private void btOK_Click(object sender, System.EventArgs e)
		{
			if(!validateGroup())
				return;
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
		private void trimGroup()
		{
			this.tbName.Text = this.tbName.Text.Trim(new char[]{'"',' ','<','>','\''});
			this.tbName.Text = this.tbName.Text.TrimStart(new char[]{'"',' ','<','>','\'','.',',','[',']','{','}','(',')',':',';','?','/','!','@','#','$','%','^','&','*'});
		}
		private bool validateGroup()
		{
			this.trimGroup();
			if(this.tbName.Text.Length == 0)
			{
				MsgBoxX.Show("Заполните поле НАЗВАНИЕ", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
			
			return true;
		}
		private void button2_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
