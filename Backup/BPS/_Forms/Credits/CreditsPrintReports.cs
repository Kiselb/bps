using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace BPS._Forms
{
	/// <summary>
	/// Summary description for CreditsPrintReports.
	/// </summary>
	public class CreditsPrintReports : System.Windows.Forms.Form
	{
		private System.Windows.Forms.CheckBox cbCreditInfo;
		private System.Windows.Forms.CheckBox cbCreditOperationsList;
		private System.Windows.Forms.CheckBox cbCreditPointsInfo;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox cbCreditGroupsList;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		public bool bNeedCreditInfo
		{
			get
			{
				return cbCreditInfo.Checked;
			}
		}

		public bool bNeedCreditPointsInfo
		{
			get
			{
				return cbCreditPointsInfo.Checked;
			}
		}

		public bool bNeedCreditOperationsList
		{
			get
			{
				return cbCreditOperationsList.Checked;
			}
		}

		public bool bNeedCreditOperationsGroups
		{
			get
			{
				return this.cbCreditGroupsList.Checked;
			}
		}

		public CreditsPrintReports()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(CreditsPrintReports));
			this.cbCreditInfo = new System.Windows.Forms.CheckBox();
			this.cbCreditOperationsList = new System.Windows.Forms.CheckBox();
			this.cbCreditPointsInfo = new System.Windows.Forms.CheckBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cbCreditGroupsList = new System.Windows.Forms.CheckBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// cbCreditInfo
			// 
			this.cbCreditInfo.Checked = true;
			this.cbCreditInfo.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbCreditInfo.Enabled = false;
			this.cbCreditInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.cbCreditInfo.Location = new System.Drawing.Point(26, 26);
			this.cbCreditInfo.Name = "cbCreditInfo";
			this.cbCreditInfo.Size = new System.Drawing.Size(156, 24);
			this.cbCreditInfo.TabIndex = 0;
			this.cbCreditInfo.Text = "Сводку по Кредиту";
			// 
			// cbCreditOperationsList
			// 
			this.cbCreditOperationsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.cbCreditOperationsList.Location = new System.Drawing.Point(26, 92);
			this.cbCreditOperationsList.Name = "cbCreditOperationsList";
			this.cbCreditOperationsList.Size = new System.Drawing.Size(156, 24);
			this.cbCreditOperationsList.TabIndex = 0;
			this.cbCreditOperationsList.Text = "Список Операций";
			// 
			// cbCreditPointsInfo
			// 
			this.cbCreditPointsInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.cbCreditPointsInfo.Location = new System.Drawing.Point(26, 58);
			this.cbCreditPointsInfo.Name = "cbCreditPointsInfo";
			this.cbCreditPointsInfo.Size = new System.Drawing.Size(156, 24);
			this.cbCreditPointsInfo.TabIndex = 0;
			this.cbCreditPointsInfo.Text = "Сводку по Периодам";
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(44, 189);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "ОК";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(124, 189);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "Отменить";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.cbCreditInfo);
			this.groupBox1.Controls.Add(this.cbCreditPointsInfo);
			this.groupBox1.Controls.Add(this.cbCreditOperationsList);
			this.groupBox1.Controls.Add(this.cbCreditGroupsList);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.groupBox1.Location = new System.Drawing.Point(4, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(238, 168);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Включить в Отчёт";
			// 
			// cbCreditGroupsList
			// 
			this.cbCreditGroupsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.cbCreditGroupsList.Location = new System.Drawing.Point(26, 126);
			this.cbCreditGroupsList.Name = "cbCreditGroupsList";
			this.cbCreditGroupsList.Size = new System.Drawing.Size(156, 24);
			this.cbCreditGroupsList.TabIndex = 0;
			this.cbCreditGroupsList.Text = "Журнал Операций";
			// 
			// CreditsPrintReports
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(248, 221);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btnCancel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CreditsPrintReports";
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Печать Отчёта";
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}
	}
}
