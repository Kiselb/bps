using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace BPS._Forms
{
	/// <summary>
	/// Summary description for CreditPointEdit.
	/// </summary>
	public class CreditPointEdit : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker dtPointDate;
		private AM_Controls.TextBoxV tbPointSum;
		private System.Windows.Forms.Button btnSave;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;	
		private BPS._Forms.dsCreditsPoints.CreditsPointsRow m_row;
		private bool m_bIsEdit;

		public CreditPointEdit(BPS._Forms.dsCreditsPoints.CreditsPointsRow rw, bool IsEdit)
		{
			//
			// Required for Windows Form Designer support
			//
			m_row = rw;
			m_bIsEdit = IsEdit;
			InitializeComponent();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(CreditPointEdit));
			this.dtPointDate = new System.Windows.Forms.DateTimePicker();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.tbPointSum = new AM_Controls.TextBoxV();
			this.SuspendLayout();
			// 
			// dtPointDate
			// 
			this.dtPointDate.Location = new System.Drawing.Point(78, 12);
			this.dtPointDate.Name = "dtPointDate";
			this.dtPointDate.Size = new System.Drawing.Size(132, 20);
			this.dtPointDate.TabIndex = 0;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.btnCancel.Location = new System.Drawing.Point(130, 74);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(80, 26);
			this.btnCancel.TabIndex = 19;
			this.btnCancel.Text = "Отменить";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnSave
			// 
			this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSave.Font = new System.Drawing.Font("Tahoma", 9.25F);
			this.btnSave.Location = new System.Drawing.Point(46, 74);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(80, 26);
			this.btnSave.TabIndex = 18;
			this.btnSave.Text = "Сохранить";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(42, 16);
			this.label1.TabIndex = 20;
			this.label1.Text = "Дата:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 44);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(42, 16);
			this.label2.TabIndex = 21;
			this.label2.Text = "Сумма:";
			// 
			// tbPointSum
			// 
			this.tbPointSum.AllowDrop = true;
			this.tbPointSum.dValue = 0;
			this.tbPointSum.IsPcnt = false;
			this.tbPointSum.Location = new System.Drawing.Point(78, 38);
			this.tbPointSum.MaxDecPos = 2;
			this.tbPointSum.MaxPos = 8;
			this.tbPointSum.Name = "tbPointSum";
			this.tbPointSum.nValue = ((long)(0));
			this.tbPointSum.Size = new System.Drawing.Size(132, 20);
			this.tbPointSum.TabIndex = 22;
			this.tbPointSum.Text = "";
			this.tbPointSum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbPointSum.TextMode = false;
			// 
			// CreditPointEdit
			// 
			this.AcceptButton = this.btnSave;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(218, 107);
			this.Controls.Add(this.tbPointSum);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.dtPointDate);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CreditPointEdit";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Параметры точки";
			this.Load += new System.EventHandler(this.CreditPointEdit_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			this.m_row.PointDate = this.dtPointDate.Value;
			this.m_row.PointSum = this.tbPointSum.dValue;
			DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		private void CreditPointEdit_Load(object sender, System.EventArgs e)
		{
			if(m_bIsEdit)
			{
				this.dtPointDate.Value = this.m_row.PointDate;
				this.tbPointSum.dValue = this.m_row.PointSum;
				this.Text += " [РЕДАКТИРОВАНИЕ]";
			}
			else
			{
				this.Text += " [НОВАЯ]";
			}
		}

	}
}
