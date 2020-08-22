using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace BPS._Forms
{
	/// <summary>
	/// Summary description for SelectPurpose.
	/// </summary>
	public class SelectPurpose : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button bnOK;
		private System.Windows.Forms.Button bnCancel;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Data.SqlClient.SqlConnection sqlConnection1;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.Data.SqlClient.SqlDataAdapter daGetPurposeList;
		private BPS._Forms.dsLastPurposeList dsLastPurposeList1;
		private System.Data.DataView dvPurposeList;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private int m_AccountIDFrom =0;
		private int m_AccountIDTo	=0;
		private int m_ClientID	=0;
		private System.Windows.Forms.GroupBox gbSelectMode;
		private System.Windows.Forms.RadioButton rbtnLastDocx;
		private System.Windows.Forms.RadioButton rbtnLastWeeks;
		private AM_Controls.TextBoxV tbDepth;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.ComponentModel.Container components = null;

		public SelectPurpose()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			App.SetDataGridTableStyle(this.dataGridTableStyle1);
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			this.rbtnLastDocx.Checked	=false;
			this.rbtnLastWeeks.Checked	=true;
			this.tbDepth.nValue			=2; 
		}
		public int AccountIDFrom
		{
			set
			{
				this.m_AccountIDFrom =value;
			}
		}
		public int AccountIDTo
		{
			set
			{
				this.m_AccountIDTo =value;
			}
		}
		public int ClientID
		{
			set
			{
				this.m_ClientID =value;
			}
		}
		public string Purpose
		{
			get
			{
				BindingManagerBase bm = this.BindingContext[this.dvPurposeList];
				if ( bm.Position <0) return String.Empty;
				
				dsLastPurposeList.OrgsAccountsRow rw = (dsLastPurposeList.OrgsAccountsRow) ((DataRowView) bm.Current).Row;
				if(rw.IsPurposeNull()) return String.Empty;
				
				return rw.Purpose;
			}
		}
		public void LoadData() 
		{
			fillDs();
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
			System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
			this.panel1 = new System.Windows.Forms.Panel();
			this.gbSelectMode = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tbDepth = new AM_Controls.TextBoxV();
			this.rbtnLastDocx = new System.Windows.Forms.RadioButton();
			this.rbtnLastWeeks = new System.Windows.Forms.RadioButton();
			this.bnCancel = new System.Windows.Forms.Button();
			this.bnOK = new System.Windows.Forms.Button();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.dvPurposeList = new System.Data.DataView();
			this.dsLastPurposeList1 = new BPS._Forms.dsLastPurposeList();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.daGetPurposeList = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.panel1.SuspendLayout();
			this.gbSelectMode.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvPurposeList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsLastPurposeList1)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.gbSelectMode,
																				 this.bnCancel,
																				 this.bnOK});
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 199);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(466, 112);
			this.panel1.TabIndex = 0;
			// 
			// gbSelectMode
			// 
			this.gbSelectMode.Controls.AddRange(new System.Windows.Forms.Control[] {
																					   this.label1,
																					   this.tbDepth,
																					   this.rbtnLastDocx,
																					   this.rbtnLastWeeks});
			this.gbSelectMode.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.gbSelectMode.Location = new System.Drawing.Point(6, 3);
			this.gbSelectMode.Name = "gbSelectMode";
			this.gbSelectMode.Size = new System.Drawing.Size(452, 75);
			this.gbSelectMode.TabIndex = 3;
			this.gbSelectMode.TabStop = false;
			this.gbSelectMode.Text = "Критерий Выбора";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(229, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(154, 24);
			this.label1.TabIndex = 2;
			this.label1.Text = "Кол-во Документов/Недель:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbDepth
			// 
			this.tbDepth.dValue = 0;
			this.tbDepth.Enabled = false;
			this.tbDepth.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbDepth.IsPcnt = false;
			this.tbDepth.Location = new System.Drawing.Point(390, 20);
			this.tbDepth.MaxDecPos = 0;
			this.tbDepth.MaxPos = 8;
			this.tbDepth.Name = "tbDepth";
			this.tbDepth.nValue = ((long)(0));
			this.tbDepth.Size = new System.Drawing.Size(50, 21);
			this.tbDepth.TabIndex = 1;
			this.tbDepth.Text = "0";
			this.tbDepth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbDepth.TextMode = false;
			// 
			// rbtnLastDocx
			// 
			this.rbtnLastDocx.Enabled = false;
			this.rbtnLastDocx.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.rbtnLastDocx.Location = new System.Drawing.Point(26, 20);
			this.rbtnLastDocx.Name = "rbtnLastDocx";
			this.rbtnLastDocx.Size = new System.Drawing.Size(170, 24);
			this.rbtnLastDocx.TabIndex = 0;
			this.rbtnLastDocx.Text = "Из последних Документов";
			// 
			// rbtnLastWeeks
			// 
			this.rbtnLastWeeks.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.rbtnLastWeeks.Location = new System.Drawing.Point(26, 46);
			this.rbtnLastWeeks.Name = "rbtnLastWeeks";
			this.rbtnLastWeeks.Size = new System.Drawing.Size(170, 24);
			this.rbtnLastWeeks.TabIndex = 0;
			this.rbtnLastWeeks.Text = "За последние Недели";
			// 
			// bnCancel
			// 
			this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.bnCancel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.bnCancel.Location = new System.Drawing.Point(383, 87);
			this.bnCancel.Name = "bnCancel";
			this.bnCancel.Size = new System.Drawing.Size(80, 23);
			this.bnCancel.TabIndex = 1;
			this.bnCancel.Text = "Отменить";
			this.bnCancel.Click += new System.EventHandler(this.bnCancel_Click);
			// 
			// bnOK
			// 
			this.bnOK.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.bnOK.Location = new System.Drawing.Point(301, 87);
			this.bnOK.Name = "bnOK";
			this.bnOK.Size = new System.Drawing.Size(80, 23);
			this.bnOK.TabIndex = 0;
			this.bnOK.Text = "Выбрать";
			this.bnOK.Click += new System.EventHandler(this.bnOK_Click);
			// 
			// dataGrid1
			// 
			this.dataGrid1.CaptionVisible = false;
			this.dataGrid1.DataMember = "";
			this.dataGrid1.DataSource = this.dvPurposeList;
			this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.ReadOnly = true;
			this.dataGrid1.Size = new System.Drawing.Size(466, 199);
			this.dataGrid1.TabIndex = 1;
			this.dataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																								  this.dataGridTableStyle1});
			this.dataGrid1.DoubleClick += new System.EventHandler(this.dataGrid1_DoubleClick);
			// 
			// dvPurposeList
			// 
			this.dvPurposeList.Table = this.dsLastPurposeList1.OrgsAccounts;
			// 
			// dsLastPurposeList1
			// 
			this.dsLastPurposeList1.DataSetName = "dsLastPurposeList";
			this.dsLastPurposeList1.Locale = new System.Globalization.CultureInfo("ru-RU");
			this.dsLastPurposeList1.Namespace = "http://www.tempuri.org/dsLastPurposeList.xsd";
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.DataGrid = this.dataGrid1;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn1,
																												  this.dataGridTextBoxColumn3,
																												  this.dataGridTextBoxColumn2});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "OrgsAccounts";
			// 
			// dataGridTextBoxColumn1
			// 
			this.dataGridTextBoxColumn1.Format = "dd-MMM-yy";
			this.dataGridTextBoxColumn1.FormatInfo = null;
			this.dataGridTextBoxColumn1.HeaderText = "Дата П/П";
			this.dataGridTextBoxColumn1.MappingName = "PaymentOrderDate";
			this.dataGridTextBoxColumn1.NullText = "-";
			this.dataGridTextBoxColumn1.Width = 75;
			// 
			// dataGridTextBoxColumn3
			// 
			this.dataGridTextBoxColumn3.Format = "";
			this.dataGridTextBoxColumn3.FormatInfo = null;
			this.dataGridTextBoxColumn3.HeaderText = "№ П/П";
			this.dataGridTextBoxColumn3.MappingName = "PaymentNo";
			this.dataGridTextBoxColumn3.NullText = "-";
			this.dataGridTextBoxColumn3.Width = 75;
			// 
			// dataGridTextBoxColumn2
			// 
			this.dataGridTextBoxColumn2.Format = "";
			this.dataGridTextBoxColumn2.FormatInfo = null;
			this.dataGridTextBoxColumn2.HeaderText = "Основание";
			this.dataGridTextBoxColumn2.MappingName = "Purpose";
			this.dataGridTextBoxColumn2.NullText = "-";
			this.dataGridTextBoxColumn2.Width = 250;
			// 
			// daGetPurposeList
			// 
			this.daGetPurposeList.SelectCommand = this.sqlSelectCommand1;
			this.daGetPurposeList.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									   new System.Data.Common.DataTableMapping("Table", "OrgsAccounts", new System.Data.Common.DataColumnMapping[] {
																																																					   new System.Data.Common.DataColumnMapping("Purpose", "Purpose"),
																																																					   new System.Data.Common.DataColumnMapping("AccountStatementID", "AccountStatementID"),
																																																					   new System.Data.Common.DataColumnMapping("AccountID", "AccountID"),
																																																					   new System.Data.Common.DataColumnMapping("OrgID", "OrgID"),
																																																					   new System.Data.Common.DataColumnMapping("RAccount", "RAccount")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT DISTINCT Transactions.Purpose AS Purpose, PaymentsOrders.PaymentOrderDate, PaymentsOrders.PaymentNo FROM PaymentsOrders INNER JOIN Transactions ON PaymentsOrders.PaymentOrderID = Transactions.DocumentID WHERE (NOT (Transactions.Purpose IS NULL)) AND (Transactions.AccountIDFrom = @AccountIDFrom) AND (Transactions.AccountIDTo = @AccountIDTo) AND (Transactions.ClientID = @ClientID) AND (Transactions.Purpose <> N'') AND (PaymentsOrders.PaymentOrderDate >= @DateFrom) AND (PaymentsOrders.PaymentOrderDate <= @DateTill)";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ClientID", System.Data.SqlDbType.Int, 4, "ClientID"));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AccountIDFrom", System.Data.SqlDbType.Int, 4, "AccountIDFrom"));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AccountIDTo", System.Data.SqlDbType.Int, 4, "AccountIDTo"));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DateFrom", System.Data.SqlDbType.DateTime, 8, "PaymentOrderDate"));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DateTill", System.Data.SqlDbType.DateTime, 8, "PaymentOrderDate"));
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = ((string)(configurationAppSettings.GetValue("ConnectionString", typeof(string))));
			// 
			// SelectPurpose
			// 
			this.AcceptButton = this.bnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.CancelButton = this.bnCancel;
			this.ClientSize = new System.Drawing.Size(466, 311);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.dataGrid1,
																		  this.panel1});
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SelectPurpose";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Последние основания";
			this.panel1.ResumeLayout(false);
			this.gbSelectMode.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvPurposeList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsLastPurposeList1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
		private void fillDs()
		{
			this.daGetPurposeList.SelectCommand.Parameters["@ClientID"].Value	=this.m_ClientID;
			this.daGetPurposeList.SelectCommand.Parameters["@AccountIDFrom"].Value	=this.m_AccountIDFrom;
			this.daGetPurposeList.SelectCommand.Parameters["@AccountIDTo"].Value	=this.m_AccountIDTo;
			this.daGetPurposeList.SelectCommand.Parameters["@DateFrom"].Value = DateTime.Now.Date.AddDays(-14);
			this.daGetPurposeList.SelectCommand.Parameters["@DateTill"].Value = DateTime.Now.Date.AddDays(1);
			try
			{
				this.daGetPurposeList.Fill(this.dsLastPurposeList1.OrgsAccounts);
			}
			catch(Exception ex)
			{
				AM_Controls.MsgBoxX.Show(ex.Message);
			}
		}
		private void bnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void bnOK_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void dataGrid1_DoubleClick(object sender, System.EventArgs e)
		{
			this.bnOK.PerformClick();
		}
	}
}
