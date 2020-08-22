using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace AuthControl
{
	/// <summary>
	/// Summary description for AddUser.
	/// </summary>
	internal class AddUser : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox tbGroup;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbUserName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbPwd;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button bnOk;
		private System.Windows.Forms.Button bnCancel;
		private System.Windows.Forms.TextBox tbConfirmPwd;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AddUser(bool IsChangePwd)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			if(IsChangePwd)
				this.tbUserName.ReadOnly = true;

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(AddUser));
			this.tbGroup = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tbUserName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tbPwd = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tbConfirmPwd = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.bnOk = new System.Windows.Forms.Button();
			this.bnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// tbGroup
			// 
			this.tbGroup.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbGroup.Location = new System.Drawing.Point(62, 8);
			this.tbGroup.Name = "tbGroup";
			this.tbGroup.ReadOnly = true;
			this.tbGroup.Size = new System.Drawing.Size(250, 21);
			this.tbGroup.TabIndex = 0;
			this.tbGroup.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(52, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Группа:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbUserName
			// 
			this.tbUserName.Location = new System.Drawing.Point(62, 30);
			this.tbUserName.Name = "tbUserName";
			this.tbUserName.Size = new System.Drawing.Size(250, 21);
			this.tbUserName.TabIndex = 2;
			this.tbUserName.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(6, 26);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(36, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "Имя:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbPwd
			// 
			this.tbPwd.Location = new System.Drawing.Point(126, 52);
			this.tbPwd.Name = "tbPwd";
			this.tbPwd.PasswordChar = '*';
			this.tbPwd.Size = new System.Drawing.Size(186, 21);
			this.tbPwd.TabIndex = 4;
			this.tbPwd.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(6, 50);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(50, 23);
			this.label3.TabIndex = 5;
			this.label3.Text = "Пароль:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbConfirmPwd
			// 
			this.tbConfirmPwd.Location = new System.Drawing.Point(126, 74);
			this.tbConfirmPwd.Name = "tbConfirmPwd";
			this.tbConfirmPwd.PasswordChar = '*';
			this.tbConfirmPwd.Size = new System.Drawing.Size(186, 21);
			this.tbConfirmPwd.TabIndex = 6;
			this.tbConfirmPwd.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(6, 74);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(118, 23);
			this.label4.TabIndex = 7;
			this.label4.Text = "Подтвердить пароль:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// bnOk
			// 
			this.bnOk.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.bnOk.Location = new System.Drawing.Point(148, 102);
			this.bnOk.Name = "bnOk";
			this.bnOk.Size = new System.Drawing.Size(80, 26);
			this.bnOk.TabIndex = 8;
			this.bnOk.Text = "Записать";
			this.bnOk.Click += new System.EventHandler(this.bnOk_Click);
			// 
			// bnCancel
			// 
			this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.bnCancel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.bnCancel.Location = new System.Drawing.Point(230, 102);
			this.bnCancel.Name = "bnCancel";
			this.bnCancel.Size = new System.Drawing.Size(80, 26);
			this.bnCancel.TabIndex = 9;
			this.bnCancel.Text = "Отменить";
			this.bnCancel.Click += new System.EventHandler(this.bnCancel_Click);
			// 
			// AddUser
			// 
			this.AcceptButton = this.bnOk;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.CancelButton = this.bnCancel;
			this.ClientSize = new System.Drawing.Size(318, 133);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.bnCancel,
																		  this.bnOk,
																		  this.label4,
																		  this.tbConfirmPwd,
																		  this.label3,
																		  this.tbPwd,
																		  this.label2,
																		  this.tbUserName,
																		  this.label1,
																		  this.tbGroup});
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AddUser";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Новый пользователь";
			this.ResumeLayout(false);

		}
		#endregion
		public string UserName
		{
			get
			{
				return this.tbUserName.Text;
			}
			set
			{
				this.tbUserName.Text = value;
			}
		}
		public string UserPwd
		{
			get
			{
				return this.tbPwd.Text;
			}
		}
		public string GroupName
		{
			set
			{
				this.tbGroup.Text = value;
			}
		}
		private void bnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void bnOk_Click(object sender, System.EventArgs e)
		{
			if(!this.validateUser())
				return;
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
		private bool validateUser()
		{
			if(this.tbUserName.Text.Length == 0)
			{
				AM_Controls.MsgBoxX.Show("Введите имя пользователя.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				this.tbUserName.Focus();
				return false;
			}
			if(this.tbPwd.Text.Length == 0)
			{
				AM_Controls.MsgBoxX.Show("Введите пароль.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				this.tbPwd.Focus();
				return false;
			}
			if(this.tbConfirmPwd.Text.Length == 0)
			{
				AM_Controls.MsgBoxX.Show("Введите подтверждение пароля.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				this.tbConfirmPwd.Focus();
				return false;
			}
			if(this.tbPwd.Text != this.tbConfirmPwd.Text)
			{
				AM_Controls.MsgBoxX.Show("Неправильно введён пароль. Повторите ввод снова.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				this.tbPwd.Text = "";
				this.tbConfirmPwd.Text = "";
				this.tbPwd.Focus();
				return false;
			}
			return true;
		}
	}
}
