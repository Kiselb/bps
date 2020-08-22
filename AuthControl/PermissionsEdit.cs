using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace AuthControl
{
	/// <summary>
	/// Summary description for PermissionsEdit.
	/// </summary>
	internal class PermissionsEdit : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox tbDescription;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbInternalName;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cmbParent;
		private System.Windows.Forms.Button bnOK;
		private System.Windows.Forms.Button bnCancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Data.DataView dvPermissionsList;
		private XSD.dsPermissionsList.PermissionsDescriptionsRow rw;
		private bool bIsEdit;
		public PermissionsEdit(XSD.dsPermissionsList.PermissionsDescriptionsRow rw, DataView dv, bool bIsEdit)
		{
			this.rw = rw;
			this.bIsEdit = bIsEdit;
			InitializeComponent();
			this.dvPermissionsList.Table = dv.Table.Copy();
			XSD.dsPermissionsList.PermissionsDescriptionsRow dr = (XSD.dsPermissionsList.PermissionsDescriptionsRow) this.dvPermissionsList.Table.NewRow();
			dr.Description = "<Нет>";
			dr.InternalName = "";
			dr.SetParentPermissionIDNull();
			dr.PermissionID = 0;
			dr.PermissionTypeID = 1;
			this.dvPermissionsList.Table.Rows.Add((DataRow) dr);
			this.dvPermissionsList.Sort = "Description";
			this.cmbParent.DataSource = this.dvPermissionsList;
			this.cmbParent.DisplayMember = "Description";
			this.cmbParent.ValueMember = "PermissionID";
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(PermissionsEdit));
			this.tbDescription = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.tbInternalName = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.cmbParent = new System.Windows.Forms.ComboBox();
			this.bnOK = new System.Windows.Forms.Button();
			this.bnCancel = new System.Windows.Forms.Button();
			this.dvPermissionsList = new System.Data.DataView();
			((System.ComponentModel.ISupportInitialize)(this.dvPermissionsList)).BeginInit();
			this.SuspendLayout();
			// 
			// tbDescription
			// 
			this.tbDescription.Location = new System.Drawing.Point(74, 2);
			this.tbDescription.Name = "tbDescription";
			this.tbDescription.Size = new System.Drawing.Size(352, 21);
			this.tbDescription.TabIndex = 0;
			this.tbDescription.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 2);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Описание:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(92, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Внутреннее имя:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbInternalName
			// 
			this.tbInternalName.Location = new System.Drawing.Point(102, 24);
			this.tbInternalName.Name = "tbInternalName";
			this.tbInternalName.Size = new System.Drawing.Size(324, 21);
			this.tbInternalName.TabIndex = 3;
			this.tbInternalName.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 46);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(62, 23);
			this.label3.TabIndex = 4;
			this.label3.Text = "Предок:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cmbParent
			// 
			this.cmbParent.Location = new System.Drawing.Point(102, 46);
			this.cmbParent.Name = "cmbParent";
			this.cmbParent.Size = new System.Drawing.Size(324, 21);
			this.cmbParent.TabIndex = 5;
			// 
			// bnOK
			// 
			this.bnOK.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.bnOK.Location = new System.Drawing.Point(264, 72);
			this.bnOK.Name = "bnOK";
			this.bnOK.Size = new System.Drawing.Size(80, 26);
			this.bnOK.TabIndex = 6;
			this.bnOK.Text = "Сохранить";
			this.bnOK.Click += new System.EventHandler(this.bnOK_Click);
			// 
			// bnCancel
			// 
			this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.bnCancel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.bnCancel.Location = new System.Drawing.Point(346, 72);
			this.bnCancel.Name = "bnCancel";
			this.bnCancel.Size = new System.Drawing.Size(80, 26);
			this.bnCancel.TabIndex = 7;
			this.bnCancel.Text = "Отменить";
			this.bnCancel.Click += new System.EventHandler(this.bnCancel_Click);
			// 
			// PermissionsEdit
			// 
			this.AcceptButton = this.bnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.CancelButton = this.bnCancel;
			this.ClientSize = new System.Drawing.Size(434, 103);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.bnCancel,
																		  this.bnOK,
																		  this.cmbParent,
																		  this.label3,
																		  this.tbInternalName,
																		  this.label2,
																		  this.label1,
																		  this.tbDescription});
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PermissionsEdit";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Разрешение";
			this.Load += new System.EventHandler(this.PermissionsEdit_Load);
			((System.ComponentModel.ISupportInitialize)(this.dvPermissionsList)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void PermissionsEdit_Load(object sender, System.EventArgs e)
		{
			if(this.bIsEdit)
			{
				this.tbDescription.Text = rw.Description;
				this.tbInternalName.Text = rw.InternalName;
				if(!rw.IsParentPermissionIDNull())
					this.cmbParent.SelectedValue = rw.ParentPermissionID;
			}
		}
		private bool validatePermissions()
		{
			if(this.tbDescription.Text.Length == 0)
			{
				AM_Controls.MsgBoxX.Show("Заполните ОПИСАНИЕ.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				this.tbDescription.Focus();
				return false;
			}
			if(this.tbInternalName.Text.Length == 0)
			{
				AM_Controls.MsgBoxX.Show("Заполните ВНУТРЕННЕЕ ИМЯ.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				this.tbInternalName.Focus();
				return false;
			}
			return true;
		}
		private void bnOK_Click(object sender, System.EventArgs e)
		{
			if(!this.validatePermissions())
			{
				return;
			}
			rw.Description = this.tbDescription.Text;
			rw.InternalName = this.tbInternalName.Text;
			if((int)this.cmbParent.SelectedValue >0)
				rw.ParentPermissionID = (int)this.cmbParent.SelectedValue;
			else
				rw.SetParentPermissionIDNull();
			rw.PermissionTypeID = 1;
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void bnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
