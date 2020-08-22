using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace BPS._Forms
{
	/// <summary>
	/// Summary description for PaymentOrdersExport.
	/// </summary>
	public class PaymentOrdersExport : System.Windows.Forms.Form
	{
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Data.SqlClient.SqlConnection sqlConnection1;
		private System.ComponentModel.IContainer components = null;

		public PaymentOrdersExport()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(PaymentOrdersExport));
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.panel2 = new System.Windows.Forms.Panel();
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// dataGrid1
			// 
			this.dataGrid1.CaptionText = "Выписки";
			this.dataGrid1.DataMember = "";
			this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(706, 301);
			this.dataGrid1.TabIndex = 6;
			// 
			// panel2
			// 
			this.panel2.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.button3,
																				 this.button2,
																				 this.groupBox1,
																				 this.label2,
																				 this.textBox1,
																				 this.button1});
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 301);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(706, 78);
			this.panel2.TabIndex = 7;
			// 
			// button3
			// 
			this.button3.Font = new System.Drawing.Font("Tahoma", 9.25F);
			this.button3.Location = new System.Drawing.Point(616, 46);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(80, 26);
			this.button3.TabIndex = 8;
			this.button3.Text = "Отменить";
			// 
			// button2
			// 
			this.button2.Font = new System.Drawing.Font("Tahoma", 9.25F);
			this.button2.Location = new System.Drawing.Point(524, 46);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(80, 26);
			this.button2.TabIndex = 7;
			this.button2.Text = "Сохранить";
			// 
			// groupBox1
			// 
			this.groupBox1.Location = new System.Drawing.Point(-18, 34);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(738, 6);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 10);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Файл заявок:";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(96, 8);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(282, 21);
			this.textBox1.TabIndex = 4;
			this.textBox1.Text = "";
			// 
			// button1
			// 
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Font = new System.Drawing.Font("Tahoma", 9.25F);
			this.button1.Location = new System.Drawing.Point(394, 7);
			this.button1.Name = "button1";
			this.button1.TabIndex = 5;
			this.button1.Text = "Обзор";
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = "data source=B-1-3-TEST;initial catalog=bp2;persist security info=False;user id=sa" +
				";workstation id=X-1-1;packet size=4096";
			// 
			// PaymentOrdersExport
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(706, 379);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.dataGrid1,
																		  this.panel2});
			this.Font = new System.Drawing.Font("Tahoma", 8.25F);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "PaymentOrdersExport";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Экспорт выписок";
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void fillDsClientRequest()
		{
//			try
//			{
//				this.dsClientsRequests1.Clear(); 
//				//this.daUseProc.SelectCommand.Parameters["@NotUseRequestDateFrom"].Value = ! this.cPeriod._cbDateFrom;
//				this.daUseProc.SelectCommand.Parameters["@DateFrom"].Value = this.cPeriod._DateFrom.Date;
//				//this.daUseProc.SelectCommand.Parameters["@NotUseRequestDateTill"].Value = ! this.cPeriod._cbDateTill;
//				this.daUseProc.SelectCommand.Parameters["@DateTo"].Value = this.cPeriod._DateTill.Date.AddDays(1);
//				this.daUseProc.Fill(this.dsClientsRequests1.ClientsRequests);
//				if(this.dvClientRequest.Count>0)
//					this.dataGridV1.CurrentRowIndex = 0;
//			}
//			catch(Exception ex)
//			{
//				AM_Controls.MsgBoxX.Show(ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
//			}
		}


	}
}
