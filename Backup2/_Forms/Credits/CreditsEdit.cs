using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace BPS._Forms
{
	/// <summary>
	/// Summary description for CreditsEdit.
	/// </summary>
	public class CreditsEdit : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cmbDirection;
		private System.Data.DataView dvClients;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cmbClient;
		private AM_Controls.TextBoxV tbSum;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.DateTimePicker dtStartDate;
		private System.Windows.Forms.DateTimePicker dtEndDate;
		private AM_Controls.TextBoxV tbServiceCharge;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private AM_Controls.TextBoxV tbServiceChargeExtra;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox tbRemarks;
		private System.Windows.Forms.Button dtnSave;
		private System.Windows.Forms.Button btnCancel;
		private BPS.BLL.Clients.DataSets.dsClients dsClients1;
		private bool m_bIsEdit = false;
		private BPS.BLL.Credits.DataSets.dsCredits.CreditsRow m_row;
		private System.Windows.Forms.ComboBox cmbCurr;
		private System.Data.DataView dvCurr;
		private System.Windows.Forms.Label label9;
		private AM_Controls.TextBoxV tbPeriod;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnDel;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.Panel pnlCreditPoints;
		private BindingManagerBase bmClients;
		private System.Windows.Forms.DataGrid dgCreditPoints;
		private System.Data.DataView dvCreditPoints;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn tbPointID;
		private System.Windows.Forms.DataGridTextBoxColumn tbPointDate;
		private System.Windows.Forms.DataGridTextBoxColumn dtbPointSum;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.ComboBox cmbCreditType;
		private System.Data.SqlClient.SqlCommand sqlCmdAddNewCredit;
		private BPS._Forms.coCreditsPoints CreditsPoints;
		private System.Data.SqlClient.SqlConnection sqlConnection1;
		private System.Data.SqlClient.SqlCommand sqlCmdCreditPointsArrange;
		private bool m_CreditSaved = false;
		private System.Windows.Forms.CheckBox cbPaymentPlan;
		private int m_CurrentCreditID = -1;
		private System.Data.SqlClient.SqlCommand sqlCmdEditCredit;
		private System.Windows.Forms.DataGridTextBoxColumn PointPercent;
		private AM_Controls.TextBoxV tbDaysBetween;
		private System.Windows.Forms.Button btnArrangeCreditByDates;
		private System.Data.SqlClient.SqlCommand sqlCmdCreditPointsArrangeByDays;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rbByPeriods;
		private System.Windows.Forms.RadioButton rbByDays;
		private System.Windows.Forms.Label lblDaysPeriods;
		private bool m_ValuesChanged = false;
		private int m_WindowsWidth;
		private bool Looped = false;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox grpPercentSinkMode;
		private System.Windows.Forms.GroupBox grpRoundMode;
		private System.Windows.Forms.RadioButton rbtSinkByPeriod;
		private System.Windows.Forms.RadioButton rbtSinkByOperation;
		private System.Windows.Forms.RadioButton rbtRoundByPeriod;
		private System.Windows.Forms.RadioButton rbtRoundByDay;
		private bool IsLoaded = false;
		private bool bReadOnly = false;

		public bool CreditSaved
		{
			get
			{
				return m_CreditSaved;
			}
		}

		public BPS.BLL.Credits.DataSets.dsCredits.CreditsRow CreditsRow
		{
			get
			{
				return m_row;
			}
		}

		public bool ReadOnly
		{
			set
			{
				bReadOnly = value;
				if(value)
				{
					this.dtnSave.Enabled = 
						this.btnAdd.Enabled = 
						this.btnEdit.Enabled = 
						this.btnDel.Enabled = 
						this.cmbClient.Enabled = 
						this.cmbCreditType.Enabled = 
						this.cmbCurr.Enabled = 
						this.cmbDirection.Enabled = 
						this.dtStartDate.Enabled = 
						this.dtEndDate.Enabled =
						this.grpPercentSinkMode.Enabled = 
						this.grpRoundMode.Enabled =
						this.btnArrangeCreditByDates.Enabled = false;
					this.tbDaysBetween.ReadOnly = 
						this.tbPeriod.ReadOnly = 
						this.tbServiceCharge.ReadOnly = 
						this.tbServiceChargeExtra.ReadOnly = 
						this.tbSum.ReadOnly = true;
				}
			}
			get
			{
				return bReadOnly;
			}
		}

		public CreditsEdit(BPS.BLL.Clients.DataSets.dsClients dsCl, bool IsEdit, BPS.BLL.Credits.DataSets.dsCredits.CreditsRow row)
		{
			InitializeComponent();
			
			this.dsClients1 = dsCl;
			this.m_bIsEdit = IsEdit;
			if(IsEdit)
			{
				this.m_CreditSaved = true;
			}
			m_row = row;
			m_CurrentCreditID = m_row.CreditID;
			m_WindowsWidth = this.Width;
			this.sqlConnection1 = 
				this.sqlCmdAddNewCredit.Connection = 
				this.sqlCmdCreditPointsArrange.Connection = 
				this.sqlCmdEditCredit.Connection = 
				sqlCmdCreditPointsArrangeByDays.Connection = App.Connection;
			CreditsPoints = new BPS._Forms.coCreditsPoints();
			try
			{
				CreditsPoints.FillDS(m_row.CreditID);
			}
			catch(Exception ex)
			{
				AM_Controls.MsgBoxX.Show(ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			this.dvCreditPoints.Table = CreditsPoints.DsCreditsPoints.CreditsPoints;
			this.dgCreditPoints.DataSource = dvCreditPoints;
			App.SetDataGridTableStyle(this.dgCreditPoints.TableStyles[0]);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(CreditsEdit));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.cmbDirection = new System.Windows.Forms.ComboBox();
			this.cmbClient = new System.Windows.Forms.ComboBox();
			this.dvClients = new System.Data.DataView();
			this.label3 = new System.Windows.Forms.Label();
			this.tbSum = new AM_Controls.TextBoxV();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.dtStartDate = new System.Windows.Forms.DateTimePicker();
			this.dtEndDate = new System.Windows.Forms.DateTimePicker();
			this.tbServiceCharge = new AM_Controls.TextBoxV();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.tbServiceChargeExtra = new AM_Controls.TextBoxV();
			this.label8 = new System.Windows.Forms.Label();
			this.tbRemarks = new System.Windows.Forms.TextBox();
			this.dtnSave = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.cmbCurr = new System.Windows.Forms.ComboBox();
			this.dvCurr = new System.Data.DataView();
			this.label9 = new System.Windows.Forms.Label();
			this.tbPeriod = new AM_Controls.TextBoxV();
			this.label10 = new System.Windows.Forms.Label();
			this.dgCreditPoints = new System.Windows.Forms.DataGrid();
			this.dvCreditPoints = new System.Data.DataView();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.tbPointID = new System.Windows.Forms.DataGridTextBoxColumn();
			this.tbPointDate = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dtbPointSum = new System.Windows.Forms.DataGridTextBoxColumn();
			this.PointPercent = new System.Windows.Forms.DataGridTextBoxColumn();
			this.pnlCreditPoints = new System.Windows.Forms.Panel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.rbByDays = new System.Windows.Forms.RadioButton();
			this.rbByPeriods = new System.Windows.Forms.RadioButton();
			this.tbDaysBetween = new AM_Controls.TextBoxV();
			this.btnArrangeCreditByDates = new System.Windows.Forms.Button();
			this.lblDaysPeriods = new System.Windows.Forms.Label();
			this.btnEdit = new System.Windows.Forms.Button();
			this.btnDel = new System.Windows.Forms.Button();
			this.btnAdd = new System.Windows.Forms.Button();
			this.label15 = new System.Windows.Forms.Label();
			this.cmbCreditType = new System.Windows.Forms.ComboBox();
			this.sqlCmdAddNewCredit = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlCmdCreditPointsArrange = new System.Data.SqlClient.SqlCommand();
			this.cbPaymentPlan = new System.Windows.Forms.CheckBox();
			this.sqlCmdEditCredit = new System.Data.SqlClient.SqlCommand();
			this.sqlCmdCreditPointsArrangeByDays = new System.Data.SqlClient.SqlCommand();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.grpPercentSinkMode = new System.Windows.Forms.GroupBox();
			this.rbtSinkByPeriod = new System.Windows.Forms.RadioButton();
			this.rbtSinkByOperation = new System.Windows.Forms.RadioButton();
			this.grpRoundMode = new System.Windows.Forms.GroupBox();
			this.rbtRoundByPeriod = new System.Windows.Forms.RadioButton();
			this.rbtRoundByDay = new System.Windows.Forms.RadioButton();
			((System.ComponentModel.ISupportInitialize)(this.dvClients)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvCurr)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgCreditPoints)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dvCreditPoints)).BeginInit();
			this.pnlCreditPoints.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.grpPercentSinkMode.SuspendLayout();
			this.grpRoundMode.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label1.Location = new System.Drawing.Point(7, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(123, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Выдать/Получить:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label2.Location = new System.Drawing.Point(7, 60);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(123, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "Клиент:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cmbDirection
			// 
			this.cmbDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbDirection.Items.AddRange(new object[] {
															  "Выдать",
															  "Получить"});
			this.cmbDirection.Location = new System.Drawing.Point(133, 10);
			this.cmbDirection.Name = "cmbDirection";
			this.cmbDirection.Size = new System.Drawing.Size(154, 21);
			this.cmbDirection.TabIndex = 2;
			// 
			// cmbClient
			// 
			this.cmbClient.DataSource = this.dvClients;
			this.cmbClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbClient.Location = new System.Drawing.Point(133, 58);
			this.cmbClient.Name = "cmbClient";
			this.cmbClient.Size = new System.Drawing.Size(154, 21);
			this.cmbClient.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label3.Location = new System.Drawing.Point(7, 84);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(123, 16);
			this.label3.TabIndex = 4;
			this.label3.Text = "Сумма:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbSum
			// 
			this.tbSum.AllowDrop = true;
			this.tbSum.dValue = 0;
			this.tbSum.IsPcnt = false;
			this.tbSum.Location = new System.Drawing.Point(133, 82);
			this.tbSum.MaxDecPos = 2;
			this.tbSum.MaxPos = 8;
			this.tbSum.Name = "tbSum";
			this.tbSum.Negative = System.Drawing.Color.Empty;
			this.tbSum.nValue = ((long)(0));
			this.tbSum.Positive = System.Drawing.Color.Empty;
			this.tbSum.Size = new System.Drawing.Size(84, 21);
			this.tbSum.TabIndex = 5;
			this.tbSum.Text = "";
			this.tbSum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbSum.TextMode = false;
			this.tbSum.Zero = System.Drawing.Color.Empty;
			this.tbSum.TextChanged += new System.EventHandler(this.tbSum_TextChanged);
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label4.Location = new System.Drawing.Point(18, 24);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(88, 16);
			this.label4.TabIndex = 6;
			this.label4.Text = "Дата выдачи:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label5.Location = new System.Drawing.Point(18, 72);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(88, 16);
			this.label5.TabIndex = 7;
			this.label5.Text = "Дата возврата:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dtStartDate
			// 
			this.dtStartDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.dtStartDate.Location = new System.Drawing.Point(112, 22);
			this.dtStartDate.Name = "dtStartDate";
			this.dtStartDate.Size = new System.Drawing.Size(154, 21);
			this.dtStartDate.TabIndex = 8;
			this.dtStartDate.ValueChanged += new System.EventHandler(this.dtStartDate_ValueChanged);
			// 
			// dtEndDate
			// 
			this.dtEndDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.dtEndDate.Location = new System.Drawing.Point(112, 70);
			this.dtEndDate.Name = "dtEndDate";
			this.dtEndDate.Size = new System.Drawing.Size(154, 21);
			this.dtEndDate.TabIndex = 9;
			this.dtEndDate.ValueChanged += new System.EventHandler(this.dtEndDate_ValueChanged);
			// 
			// tbServiceCharge
			// 
			this.tbServiceCharge.AllowDrop = true;
			this.tbServiceCharge.dValue = 0;
			this.tbServiceCharge.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.tbServiceCharge.IsPcnt = true;
			this.tbServiceCharge.Location = new System.Drawing.Point(142, 25);
			this.tbServiceCharge.MaxDecPos = 2;
			this.tbServiceCharge.MaxPos = 8;
			this.tbServiceCharge.Name = "tbServiceCharge";
			this.tbServiceCharge.Negative = System.Drawing.Color.Empty;
			this.tbServiceCharge.nValue = ((long)(0));
			this.tbServiceCharge.Positive = System.Drawing.Color.Empty;
			this.tbServiceCharge.Size = new System.Drawing.Size(114, 21);
			this.tbServiceCharge.TabIndex = 11;
			this.tbServiceCharge.Text = "";
			this.tbServiceCharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbServiceCharge.TextMode = false;
			this.tbServiceCharge.Zero = System.Drawing.Color.Empty;
			this.tbServiceCharge.TextChanged += new System.EventHandler(this.tbServiceCharge_TextChanged);
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label6.Location = new System.Drawing.Point(18, 25);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(120, 16);
			this.label6.TabIndex = 10;
			this.label6.Text = "Процентная ставка:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label7.Location = new System.Drawing.Point(18, 49);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(120, 16);
			this.label7.TabIndex = 12;
			this.label7.Text = "Штрафная Ставка:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbServiceChargeExtra
			// 
			this.tbServiceChargeExtra.AllowDrop = true;
			this.tbServiceChargeExtra.dValue = 0;
			this.tbServiceChargeExtra.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.tbServiceChargeExtra.IsPcnt = true;
			this.tbServiceChargeExtra.Location = new System.Drawing.Point(142, 49);
			this.tbServiceChargeExtra.MaxDecPos = 2;
			this.tbServiceChargeExtra.MaxPos = 8;
			this.tbServiceChargeExtra.Name = "tbServiceChargeExtra";
			this.tbServiceChargeExtra.Negative = System.Drawing.Color.Empty;
			this.tbServiceChargeExtra.nValue = ((long)(0));
			this.tbServiceChargeExtra.Positive = System.Drawing.Color.Empty;
			this.tbServiceChargeExtra.Size = new System.Drawing.Size(114, 21);
			this.tbServiceChargeExtra.TabIndex = 13;
			this.tbServiceChargeExtra.Text = "";
			this.tbServiceChargeExtra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbServiceChargeExtra.TextMode = false;
			this.tbServiceChargeExtra.Zero = System.Drawing.Color.Empty;
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label8.Location = new System.Drawing.Point(8, 464);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(100, 16);
			this.label8.TabIndex = 14;
			this.label8.Text = "Примечание:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbRemarks
			// 
			this.tbRemarks.Location = new System.Drawing.Point(6, 482);
			this.tbRemarks.Multiline = true;
			this.tbRemarks.Name = "tbRemarks";
			this.tbRemarks.Size = new System.Drawing.Size(284, 54);
			this.tbRemarks.TabIndex = 15;
			this.tbRemarks.Text = "";
			// 
			// dtnSave
			// 
			this.dtnSave.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.dtnSave.Location = new System.Drawing.Point(115, 542);
			this.dtnSave.Name = "dtnSave";
			this.dtnSave.Size = new System.Drawing.Size(80, 22);
			this.dtnSave.TabIndex = 16;
			this.dtnSave.Text = "Сохранить";
			this.dtnSave.Click += new System.EventHandler(this.dtnSave_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.btnCancel.Location = new System.Drawing.Point(199, 542);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(80, 22);
			this.btnCancel.TabIndex = 17;
			this.btnCancel.Text = "Отменить";
			this.btnCancel.Click += new System.EventHandler(this.button1_Click);
			// 
			// cmbCurr
			// 
			this.cmbCurr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCurr.Location = new System.Drawing.Point(219, 82);
			this.cmbCurr.Name = "cmbCurr";
			this.cmbCurr.Size = new System.Drawing.Size(68, 21);
			this.cmbCurr.TabIndex = 18;
			// 
			// label9
			// 
			this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label9.Location = new System.Drawing.Point(18, 48);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(88, 16);
			this.label9.TabIndex = 19;
			this.label9.Text = "Сроком на:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbPeriod
			// 
			this.tbPeriod.AllowDrop = true;
			this.tbPeriod.dValue = 0;
			this.tbPeriod.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.tbPeriod.IsPcnt = false;
			this.tbPeriod.Location = new System.Drawing.Point(112, 46);
			this.tbPeriod.MaxDecPos = 2;
			this.tbPeriod.MaxPos = 8;
			this.tbPeriod.Name = "tbPeriod";
			this.tbPeriod.Negative = System.Drawing.Color.Empty;
			this.tbPeriod.nValue = ((long)(0));
			this.tbPeriod.Positive = System.Drawing.Color.Empty;
			this.tbPeriod.Size = new System.Drawing.Size(114, 21);
			this.tbPeriod.TabIndex = 20;
			this.tbPeriod.Text = "";
			this.tbPeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbPeriod.TextMode = false;
			this.tbPeriod.Zero = System.Drawing.Color.Empty;
			this.tbPeriod.Validating += new System.ComponentModel.CancelEventHandler(this.tbPeriod_Validating);
			// 
			// label10
			// 
			this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label10.Location = new System.Drawing.Point(228, 46);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(34, 18);
			this.label10.TabIndex = 21;
			this.label10.Text = "дней";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dgCreditPoints
			// 
			this.dgCreditPoints.CaptionText = "План погашения кредита";
			this.dgCreditPoints.DataMember = "";
			this.dgCreditPoints.DataSource = this.dvCreditPoints;
			this.dgCreditPoints.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgCreditPoints.Location = new System.Drawing.Point(6, 90);
			this.dgCreditPoints.Name = "dgCreditPoints";
			this.dgCreditPoints.Size = new System.Drawing.Size(326, 414);
			this.dgCreditPoints.TabIndex = 22;
			this.dgCreditPoints.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																									   this.dataGridTableStyle1});
			// 
			// dvCreditPoints
			// 
			this.dvCreditPoints.AllowDelete = false;
			this.dvCreditPoints.AllowEdit = false;
			this.dvCreditPoints.AllowNew = false;
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.DataGrid = this.dgCreditPoints;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.tbPointID,
																												  this.tbPointDate,
																												  this.dtbPointSum,
																												  this.PointPercent});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "CreditsPoints";
			// 
			// tbPointID
			// 
			this.tbPointID.Format = "";
			this.tbPointID.FormatInfo = null;
			this.tbPointID.HeaderText = "ID";
			this.tbPointID.MappingName = "PointID";
			this.tbPointID.NullText = "-";
			this.tbPointID.Width = 50;
			// 
			// tbPointDate
			// 
			this.tbPointDate.Format = "";
			this.tbPointDate.FormatInfo = null;
			this.tbPointDate.HeaderText = "Дата";
			this.tbPointDate.MappingName = "PointDate";
			this.tbPointDate.NullText = "-";
			this.tbPointDate.Width = 75;
			// 
			// dtbPointSum
			// 
			this.dtbPointSum.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.dtbPointSum.Format = "0.00";
			this.dtbPointSum.FormatInfo = null;
			this.dtbPointSum.HeaderText = "Сумма";
			this.dtbPointSum.MappingName = "PointSum";
			this.dtbPointSum.NullText = "-";
			this.dtbPointSum.Width = 75;
			// 
			// PointPercent
			// 
			this.PointPercent.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.PointPercent.Format = "0.00";
			this.PointPercent.FormatInfo = null;
			this.PointPercent.HeaderText = "%% по кредиту";
			this.PointPercent.MappingName = "PointPercent";
			this.PointPercent.NullText = "-";
			this.PointPercent.Width = 75;
			// 
			// pnlCreditPoints
			// 
			this.pnlCreditPoints.Controls.Add(this.groupBox1);
			this.pnlCreditPoints.Controls.Add(this.btnEdit);
			this.pnlCreditPoints.Controls.Add(this.btnDel);
			this.pnlCreditPoints.Controls.Add(this.btnAdd);
			this.pnlCreditPoints.Controls.Add(this.dgCreditPoints);
			this.pnlCreditPoints.Location = new System.Drawing.Point(296, 0);
			this.pnlCreditPoints.Name = "pnlCreditPoints";
			this.pnlCreditPoints.Size = new System.Drawing.Size(340, 546);
			this.pnlCreditPoints.TabIndex = 23;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.rbByDays);
			this.groupBox1.Controls.Add(this.rbByPeriods);
			this.groupBox1.Controls.Add(this.tbDaysBetween);
			this.groupBox1.Controls.Add(this.btnArrangeCreditByDates);
			this.groupBox1.Controls.Add(this.lblDaysPeriods);
			this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.groupBox1.Location = new System.Drawing.Point(6, 6);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(324, 78);
			this.groupBox1.TabIndex = 37;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Генерация плана погашения";
			// 
			// rbByDays
			// 
			this.rbByDays.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.rbByDays.Location = new System.Drawing.Point(14, 44);
			this.rbByDays.Name = "rbByDays";
			this.rbByDays.Size = new System.Drawing.Size(69, 20);
			this.rbByDays.TabIndex = 38;
			this.rbByDays.Text = "Дни";
			// 
			// rbByPeriods
			// 
			this.rbByPeriods.Checked = true;
			this.rbByPeriods.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.rbByPeriods.Location = new System.Drawing.Point(14, 20);
			this.rbByPeriods.Name = "rbByPeriods";
			this.rbByPeriods.Size = new System.Drawing.Size(71, 20);
			this.rbByPeriods.TabIndex = 37;
			this.rbByPeriods.TabStop = true;
			this.rbByPeriods.Text = "Периоды";
			// 
			// tbDaysBetween
			// 
			this.tbDaysBetween.AllowDrop = true;
			this.tbDaysBetween.dValue = 0;
			this.tbDaysBetween.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.tbDaysBetween.IsPcnt = false;
			this.tbDaysBetween.Location = new System.Drawing.Point(189, 44);
			this.tbDaysBetween.MaxDecPos = 0;
			this.tbDaysBetween.MaxPos = 8;
			this.tbDaysBetween.Name = "tbDaysBetween";
			this.tbDaysBetween.Negative = System.Drawing.Color.Empty;
			this.tbDaysBetween.nValue = ((long)(0));
			this.tbDaysBetween.Positive = System.Drawing.Color.Empty;
			this.tbDaysBetween.Size = new System.Drawing.Size(52, 21);
			this.tbDaysBetween.TabIndex = 34;
			this.tbDaysBetween.Text = "";
			this.tbDaysBetween.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbDaysBetween.TextMode = false;
			this.tbDaysBetween.Zero = System.Drawing.Color.Empty;
			// 
			// btnArrangeCreditByDates
			// 
			this.btnArrangeCreditByDates.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.btnArrangeCreditByDates.Location = new System.Drawing.Point(246, 44);
			this.btnArrangeCreditByDates.Name = "btnArrangeCreditByDates";
			this.btnArrangeCreditByDates.Size = new System.Drawing.Size(70, 22);
			this.btnArrangeCreditByDates.TabIndex = 36;
			this.btnArrangeCreditByDates.Text = "Выполнить";
			this.btnArrangeCreditByDates.Click += new System.EventHandler(this.btnArrangeCreditByDates_Click);
			// 
			// lblDaysPeriods
			// 
			this.lblDaysPeriods.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.lblDaysPeriods.Location = new System.Drawing.Point(110, 46);
			this.lblDaysPeriods.Name = "lblDaysPeriods";
			this.lblDaysPeriods.Size = new System.Drawing.Size(76, 18);
			this.lblDaysPeriods.TabIndex = 35;
			this.lblDaysPeriods.Text = "Количество:";
			this.lblDaysPeriods.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnEdit
			// 
			this.btnEdit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.btnEdit.Location = new System.Drawing.Point(130, 512);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(80, 22);
			this.btnEdit.TabIndex = 25;
			this.btnEdit.Text = "Изменить";
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// btnDel
			// 
			this.btnDel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.btnDel.Location = new System.Drawing.Point(214, 512);
			this.btnDel.Name = "btnDel";
			this.btnDel.Size = new System.Drawing.Size(80, 22);
			this.btnDel.TabIndex = 24;
			this.btnDel.Text = "Удалить";
			this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.btnAdd.Location = new System.Drawing.Point(46, 512);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(80, 22);
			this.btnAdd.TabIndex = 23;
			this.btnAdd.Text = "Добавить";
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// label15
			// 
			this.label15.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label15.Location = new System.Drawing.Point(7, 36);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(123, 16);
			this.label15.TabIndex = 25;
			this.label15.Text = "Тип кредита:";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cmbCreditType
			// 
			this.cmbCreditType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCreditType.Items.AddRange(new object[] {
															   "Краткосрочный",
															   "Долгосрочный",
															   "С планом погашения"});
			this.cmbCreditType.Location = new System.Drawing.Point(133, 34);
			this.cmbCreditType.Name = "cmbCreditType";
			this.cmbCreditType.Size = new System.Drawing.Size(154, 21);
			this.cmbCreditType.TabIndex = 26;
			this.cmbCreditType.SelectedIndexChanged += new System.EventHandler(this.cmbCreditType_SelectedIndexChanged);
			// 
			// sqlCmdAddNewCredit
			// 
			this.sqlCmdAddNewCredit.CommandText = "[CreditInsert]";
			this.sqlCmdAddNewCredit.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCmdAddNewCredit.Connection = this.sqlConnection1;
			this.sqlCmdAddNewCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdAddNewCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ClientID", System.Data.SqlDbType.Int, 4));
			this.sqlCmdAddNewCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CreditStatusID", System.Data.SqlDbType.Int, 4));
			this.sqlCmdAddNewCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsGranted", System.Data.SqlDbType.Bit, 1));
			this.sqlCmdAddNewCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@StartDate", System.Data.SqlDbType.DateTime, 8));
			this.sqlCmdAddNewCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@EndDate", System.Data.SqlDbType.DateTime, 8));
			this.sqlCmdAddNewCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CreditSum", System.Data.SqlDbType.Float, 8));
			this.sqlCmdAddNewCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CreditSumCurrency", System.Data.SqlDbType.NVarChar, 3));
			this.sqlCmdAddNewCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ServiceCharge", System.Data.SqlDbType.Float, 8));
			this.sqlCmdAddNewCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ServiceChargeExtra", System.Data.SqlDbType.Float, 8));
			this.sqlCmdAddNewCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Remarks", System.Data.SqlDbType.NVarChar, 256));
			this.sqlCmdAddNewCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsExtended", System.Data.SqlDbType.Bit, 1));
			this.sqlCmdAddNewCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsShortTerm", System.Data.SqlDbType.Bit, 1));
			this.sqlCmdAddNewCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PercentageRoundMode", System.Data.SqlDbType.Bit, 1));
			this.sqlCmdAddNewCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PercentageSinkMode", System.Data.SqlDbType.Bit, 1));
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = ((string)(configurationAppSettings.GetValue("ConnectionString", typeof(string))));
			// 
			// sqlCmdCreditPointsArrange
			// 
			this.sqlCmdCreditPointsArrange.CommandText = "[CreditsPointsArrange]";
			this.sqlCmdCreditPointsArrange.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCmdCreditPointsArrange.Connection = this.sqlConnection1;
			this.sqlCmdCreditPointsArrange.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdCreditPointsArrange.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NumParts", System.Data.SqlDbType.Int, 4));
			this.sqlCmdCreditPointsArrange.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CreditID", System.Data.SqlDbType.Int, 4));
			// 
			// cbPaymentPlan
			// 
			this.cbPaymentPlan.Appearance = System.Windows.Forms.Appearance.Button;
			this.cbPaymentPlan.Location = new System.Drawing.Point(11, 542);
			this.cbPaymentPlan.Name = "cbPaymentPlan";
			this.cbPaymentPlan.Size = new System.Drawing.Size(102, 22);
			this.cbPaymentPlan.TabIndex = 27;
			this.cbPaymentPlan.Text = "План погашения";
			this.cbPaymentPlan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cbPaymentPlan.CheckedChanged += new System.EventHandler(this.btnPaymentPlan_Click);
			// 
			// sqlCmdEditCredit
			// 
			this.sqlCmdEditCredit.CommandText = "[CreditEdit]";
			this.sqlCmdEditCredit.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCmdEditCredit.Connection = this.sqlConnection1;
			this.sqlCmdEditCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdEditCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CreditID", System.Data.SqlDbType.Int, 4));
			this.sqlCmdEditCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CreditStatusID", System.Data.SqlDbType.Int, 4));
			this.sqlCmdEditCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ClientID", System.Data.SqlDbType.Int, 4));
			this.sqlCmdEditCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsGranted", System.Data.SqlDbType.Bit, 1));
			this.sqlCmdEditCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@StartDate", System.Data.SqlDbType.DateTime, 8));
			this.sqlCmdEditCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@EndDate", System.Data.SqlDbType.DateTime, 8));
			this.sqlCmdEditCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CreditSum", System.Data.SqlDbType.Float, 8));
			this.sqlCmdEditCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ServiceCharge", System.Data.SqlDbType.Float, 8));
			this.sqlCmdEditCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ServiceChargeExtra", System.Data.SqlDbType.Float, 8));
			this.sqlCmdEditCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Remarks", System.Data.SqlDbType.NVarChar, 256));
			this.sqlCmdEditCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CreditSumCurrency", System.Data.SqlDbType.NVarChar, 3));
			this.sqlCmdEditCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsExtended", System.Data.SqlDbType.Bit, 1));
			this.sqlCmdEditCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsShortTerm", System.Data.SqlDbType.Bit, 1));
			this.sqlCmdEditCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PercentageRoundMode", System.Data.SqlDbType.Bit, 1));
			this.sqlCmdEditCredit.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PercentageSinkMode", System.Data.SqlDbType.Bit, 1));
			// 
			// sqlCmdCreditPointsArrangeByDays
			// 
			this.sqlCmdCreditPointsArrangeByDays.CommandText = "[CreditsPointsArrangeByDays]";
			this.sqlCmdCreditPointsArrangeByDays.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCmdCreditPointsArrangeByDays.Connection = this.sqlConnection1;
			this.sqlCmdCreditPointsArrangeByDays.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdCreditPointsArrangeByDays.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Period", System.Data.SqlDbType.Int, 4));
			this.sqlCmdCreditPointsArrangeByDays.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CreditID", System.Data.SqlDbType.Int, 4));
			// 
			// label11
			// 
			this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label11.Location = new System.Drawing.Point(258, 25);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(19, 18);
			this.label11.TabIndex = 21;
			this.label11.Text = "%";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label12
			// 
			this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label12.Location = new System.Drawing.Point(258, 49);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(19, 18);
			this.label12.TabIndex = 21;
			this.label12.Text = "%";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.tbServiceChargeExtra);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.tbServiceCharge);
			this.groupBox2.Controls.Add(this.label11);
			this.groupBox2.Controls.Add(this.label12);
			this.groupBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.groupBox2.Location = new System.Drawing.Point(6, 214);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(284, 78);
			this.groupBox2.TabIndex = 28;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Процентные Ставки";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.label5);
			this.groupBox3.Controls.Add(this.label4);
			this.groupBox3.Controls.Add(this.label10);
			this.groupBox3.Controls.Add(this.dtEndDate);
			this.groupBox3.Controls.Add(this.dtStartDate);
			this.groupBox3.Controls.Add(this.tbPeriod);
			this.groupBox3.Controls.Add(this.label9);
			this.groupBox3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.groupBox3.Location = new System.Drawing.Point(6, 108);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(284, 102);
			this.groupBox3.TabIndex = 29;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Даты и Сроки";
			// 
			// grpPercentSinkMode
			// 
			this.grpPercentSinkMode.Controls.Add(this.rbtSinkByPeriod);
			this.grpPercentSinkMode.Controls.Add(this.rbtSinkByOperation);
			this.grpPercentSinkMode.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.grpPercentSinkMode.Location = new System.Drawing.Point(6, 296);
			this.grpPercentSinkMode.Name = "grpPercentSinkMode";
			this.grpPercentSinkMode.Size = new System.Drawing.Size(284, 80);
			this.grpPercentSinkMode.TabIndex = 30;
			this.grpPercentSinkMode.TabStop = false;
			this.grpPercentSinkMode.Text = "Гашение Процентов";
			// 
			// rbtSinkByPeriod
			// 
			this.rbtSinkByPeriod.Checked = true;
			this.rbtSinkByPeriod.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.rbtSinkByPeriod.Location = new System.Drawing.Point(18, 23);
			this.rbtSinkByPeriod.Name = "rbtSinkByPeriod";
			this.rbtSinkByPeriod.Size = new System.Drawing.Size(256, 24);
			this.rbtSinkByPeriod.TabIndex = 0;
			this.rbtSinkByPeriod.TabStop = true;
			this.rbtSinkByPeriod.Text = "Только по отчётным периодам";
			// 
			// rbtSinkByOperation
			// 
			this.rbtSinkByOperation.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.rbtSinkByOperation.Location = new System.Drawing.Point(18, 51);
			this.rbtSinkByOperation.Name = "rbtSinkByOperation";
			this.rbtSinkByOperation.Size = new System.Drawing.Size(256, 24);
			this.rbtSinkByOperation.TabIndex = 0;
			this.rbtSinkByOperation.Text = "При каждой операции гашения";
			// 
			// grpRoundMode
			// 
			this.grpRoundMode.Controls.Add(this.rbtRoundByPeriod);
			this.grpRoundMode.Controls.Add(this.rbtRoundByDay);
			this.grpRoundMode.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.grpRoundMode.Location = new System.Drawing.Point(6, 380);
			this.grpRoundMode.Name = "grpRoundMode";
			this.grpRoundMode.Size = new System.Drawing.Size(284, 80);
			this.grpRoundMode.TabIndex = 31;
			this.grpRoundMode.TabStop = false;
			this.grpRoundMode.Text = "Округление при расчёте Процентов";
			// 
			// rbtRoundByPeriod
			// 
			this.rbtRoundByPeriod.Checked = true;
			this.rbtRoundByPeriod.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.rbtRoundByPeriod.Location = new System.Drawing.Point(18, 23);
			this.rbtRoundByPeriod.Name = "rbtRoundByPeriod";
			this.rbtRoundByPeriod.Size = new System.Drawing.Size(256, 24);
			this.rbtRoundByPeriod.TabIndex = 0;
			this.rbtRoundByPeriod.TabStop = true;
			this.rbtRoundByPeriod.Text = "Округлять за период";
			// 
			// rbtRoundByDay
			// 
			this.rbtRoundByDay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.rbtRoundByDay.Location = new System.Drawing.Point(18, 51);
			this.rbtRoundByDay.Name = "rbtRoundByDay";
			this.rbtRoundByDay.Size = new System.Drawing.Size(256, 24);
			this.rbtRoundByDay.TabIndex = 0;
			this.rbtRoundByDay.Text = "Округлять за день";
			// 
			// CreditsEdit
			// 
			this.AcceptButton = this.dtnSave;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(634, 569);
			this.Controls.Add(this.grpRoundMode);
			this.Controls.Add(this.grpPercentSinkMode);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.cbPaymentPlan);
			this.Controls.Add(this.cmbCreditType);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.pnlCreditPoints);
			this.Controls.Add(this.tbRemarks);
			this.Controls.Add(this.tbSum);
			this.Controls.Add(this.cmbCurr);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.dtnSave);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.cmbClient);
			this.Controls.Add(this.cmbDirection);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CreditsEdit";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Кредит";
			this.Load += new System.EventHandler(this.CreditsEdit_Load);
			((System.ComponentModel.ISupportInitialize)(this.dvClients)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvCurr)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgCreditPoints)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dvCreditPoints)).EndInit();
			this.pnlCreditPoints.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.grpPercentSinkMode.ResumeLayout(false);
			this.grpRoundMode.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region OnLoad CTor
		private void CreditsEdit_Load(object sender, System.EventArgs e)
		{
			this.cmbDirection.SelectedIndex = 0;
			
			this.dvClients.Table = this.dsClients1.Clients;
			this.dvClients.RowFilter = "ClientID <> 0";
			this.bmClients = this.BindingContext[dvClients];
			this.cmbClient.DisplayMember	= "ClientName";
			this.cmbClient.ValueMember		= "ClientID";
			
			this.dvCurr.Table = App.DsCurr.Currencies;
			
			this.cmbCurr.DataSource		= this.dvCurr;
			this.cmbCurr.DisplayMember	= 
			this.cmbCurr.ValueMember	= "CurrencyID";
			this.cmbCurr.SelectedValue	= App.MainCurrencyID;
			
			this.cbPaymentPlan.Enabled = false;
			this.cbPaymentPlan.Checked = false;
			
			this.cmbClient.SelectedIndex =-1;

			if (m_bIsEdit)
			{
				this.cmbClient.SelectedValue = m_row.ClientID;
				this.cmbDirection.SelectedIndex = m_row.IsGranted == true ? 0 : 1;
				
				this.tbRemarks.Text = m_row.Remarks;
				this.tbServiceCharge.dValue = m_row.ServiceCharge;
				this.tbServiceChargeExtra.dValue = m_row.ServiceChargeExtra;
				this.tbSum.dValue = m_row.CreditSum;
				
				this.cmbCurr.SelectedValue = m_row.CreditSumCurrency.ToString();
				
				this.dtStartDate.Value	= m_row.StartDate.Date;
				this.dtEndDate.Value	= m_row.EndDate.Date;
				if(m_row.IsExtended)
				{
					this.cmbCreditType.SelectedIndex = 2;
				}
				else
				{
					if(m_row.IsShortTerm)
					{
						this.cmbCreditType.SelectedIndex = 0;
					}
					else
					{
						this.cmbCreditType.SelectedIndex = 1;
					}
				}
				if ( this.m_row.PercentageRoundMode) //Round By Period
					this.rbtRoundByPeriod.Checked =true;
				else
					this.rbtRoundByDay.Checked =true;

				if ( this.m_row.PercentageSinkMode) //Sink by Period
					this.rbtSinkByPeriod.Checked =true;
				else
					this.rbtSinkByOperation.Checked =true;
			}
			SetFormWidth();
			this.m_ValuesChanged = false;
			IsLoaded = true;
		}
		#endregion

		#region Form Buttons
		private void dtnSave_Click(object sender, System.EventArgs e)
		{
			if(SetAndValidate())
			{
				DialogResult = DialogResult.OK;
				Close();
			}
			else
			{
				return;
			}
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			Close();
		}
		#endregion

		#region Form Apperance

		private void SetFormWidth()
		{
			if((this.cmbCreditType.SelectedIndex == 1 || this.cmbCreditType.SelectedIndex == 2) && m_CreditSaved && this.cbPaymentPlan.Checked)
			{
				this.pnlCreditPoints.Visible = true;
				//this.btnPaymentPlan.cap
				this.Width = m_WindowsWidth;
				if(this.cmbCreditType.SelectedIndex == 1)
				{
					this.dgCreditPoints.CaptionText = "План выплаты процентов по кредиту";
				}
				else
				{
					this.dgCreditPoints.CaptionText = "План погашения кредита";
				}
			}
			else
			{
				this.pnlCreditPoints.Visible = false;
				this.Width = this.pnlCreditPoints.Location.X + 3;
			}
		}
		
		private void SetAutoGeneratePanelEnabled()
		{
			if(this.cmbCreditType.SelectedIndex == 2)
			{
				this.groupBox1.Enabled = true;
			}
			else
			{
				this.groupBox1.Enabled = false;
			}
		}

		private void SetEditPointsButtonsEnabled()
		{
			if(this.cmbCreditType.SelectedIndex == 0 || bReadOnly)
			{
				this.btnAdd.Enabled = 
					this.btnDel.Enabled = 
					this.btnEdit.Enabled = false;
			}
			else
			{
				this.btnAdd.Enabled = 
					this.btnDel.Enabled = 
					this.btnEdit.Enabled = true;
			}
		}

		#endregion

		#region Credit Points Editor
		private void ArrangeCreditByPeriods()
		{
			if(m_ValuesChanged)
			{
				if(AM_Controls.MsgBoxX.Show("Сохранить изменения параметров кредита?", "BPS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					UpdateCreditParams();
					m_ValuesChanged = false;
				}
				else
				{
					return;
				}
			}
			try
			{
				sqlCmdCreditPointsArrange.Connection.Open();
				sqlCmdCreditPointsArrange.Parameters["@NumParts"].Value = this.tbDaysBetween.dValue;
				sqlCmdCreditPointsArrange.Parameters["@CreditID"].Value = m_CurrentCreditID;
				sqlCmdCreditPointsArrange.ExecuteNonQuery();
				CreditsPoints.FillDS(m_row.CreditID);
			}
			catch(Exception ex)
			{
				AM_Controls.MsgBoxX.Show(ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			finally
			{
				sqlCmdCreditPointsArrange.Connection.Close();
			}
		}

		private void btnArrangeCreditByDates_Click(object sender, System.EventArgs e)
		{
			if(this.tbDaysBetween.dValue <= 0)
			{
				if(this.rbByDays.Checked)
				{
					AM_Controls.MsgBoxX.Show("Количество дней должно быть больше 0", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				else
				{
					AM_Controls.MsgBoxX.Show("Количество частей должно быть больше 0", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				return;
			}
			if(this.rbByDays.Checked)
			{
				ArrangeCreditByDays();
			}
			else
			{
				if(this.rbByPeriods.Checked)
					ArrangeCreditByPeriods();
			}
		}

		private void ArrangeCreditByDays()
		{
			if(m_ValuesChanged)
			{
				if(AM_Controls.MsgBoxX.Show("Сохранить изменения параметров кредита?", "BPS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					UpdateCreditParams();
					m_ValuesChanged = false;
				}
				else
				{
					return;
				}
			}
			try
			{
				sqlCmdCreditPointsArrangeByDays.Connection.Open();
				sqlCmdCreditPointsArrangeByDays.Parameters["@Period"].Value = this.tbDaysBetween.dValue;
				sqlCmdCreditPointsArrangeByDays.Parameters["@CreditID"].Value = m_CurrentCreditID;
				sqlCmdCreditPointsArrangeByDays.ExecuteNonQuery();
				CreditsPoints.FillDS(m_row.CreditID);
			}
			catch(Exception ex)
			{
				AM_Controls.MsgBoxX.Show(ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			finally
			{
				sqlCmdCreditPointsArrangeByDays.Connection.Close();
			}		
		}

		private void btnPaymentPlan_Click(object sender, System.EventArgs e)
		{
			if(Looped)
			{
				Looped = false;
				return;
			}
			bool bAllOK = true;
			int id = -1;
			if(!m_CreditSaved)
			{
				if(AM_Controls.MsgBoxX.Show("Кредит первоначально должен быть сохранен.\nСохранить параметры кредита?", "BPS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					if(this.SetAndValidate())
					{
						this.sqlCmdAddNewCredit.Connection.Open();
						this.sqlCmdAddNewCredit.Parameters["@ClientID"].Value				= this.m_row.ClientID;
						this.sqlCmdAddNewCredit.Parameters["@CreditStatusID"].Value			= this.m_row.CreditStatusID;
						this.sqlCmdAddNewCredit.Parameters["@IsGranted"].Value				= this.m_row.IsGranted;
						this.sqlCmdAddNewCredit.Parameters["@StartDate"].Value				= this.m_row.StartDate;
						this.sqlCmdAddNewCredit.Parameters["@EndDate"].Value				= this.m_row.EndDate;
						this.sqlCmdAddNewCredit.Parameters["@CreditSum"].Value				= this.m_row.CreditSum;
						this.sqlCmdAddNewCredit.Parameters["@CreditSumCurrency"].Value		= this.m_row.CreditSumCurrency;
						this.sqlCmdAddNewCredit.Parameters["@ServiceCharge"].Value			= this.m_row.ServiceCharge;
						this.sqlCmdAddNewCredit.Parameters["@ServiceChargeExtra"].Value		= this.m_row.ServiceChargeExtra;
						this.sqlCmdAddNewCredit.Parameters["@Remarks"].Value				= this.m_row.Remarks;
						this.sqlCmdAddNewCredit.Parameters["@IsExtended"].Value				= this.m_row.IsExtended;
						this.sqlCmdAddNewCredit.Parameters["@IsShortTerm"].Value			= this.m_row.IsShortTerm;
						this.sqlCmdAddNewCredit.Parameters["@Remarks"].Value				= this.m_row.Remarks;
						this.sqlCmdAddNewCredit.Parameters["@PercentageRoundMode"].Value	= this.m_row.PercentageRoundMode;
						this.sqlCmdAddNewCredit.Parameters["@PercentageSinkMode"].Value		= this.m_row.PercentageSinkMode;
						try
						{
							id = System.Convert.ToInt32(sqlCmdAddNewCredit.ExecuteScalar());
						}
						catch(Exception ex)
						{
							AM_Controls.MsgBoxX.Show(ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Information);
							bAllOK = false;
						}
						finally
						{
							sqlCmdAddNewCredit.Connection.Close();
						}
						if(bAllOK)
						{
							this.m_row.CreditID		= m_CurrentCreditID = id;
							this.m_CreditSaved		= true;
							this.m_ValuesChanged	= false;
						}
						SetFormWidth();
						CreditsPoints.FillDS(m_row.CreditID);
						m_bIsEdit = true;
					}
					else
					{
						if(this.cbPaymentPlan.Checked)
						{
							Looped = true;
						}
						this.cbPaymentPlan.Checked = false;
						return;
					}
				}
				else
				{
					if(this.cbPaymentPlan.Checked)
					{
						Looped = true;
					}
					this.cbPaymentPlan.Checked = false;
					return;
				}
			}
			else
			{
				int CurrentCreditID = 0;
				if(m_ValuesChanged && this.cmbCreditType.SelectedIndex == 1)
				{
					if((m_row.IsExtended &&
						AM_Controls.MsgBoxX.Show("Кредит первоначально должен быть сохранен.\nЭто приведет к утрате прошлого плана погашения кредита.\nСохранить параметры кредита?", "BPS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
						||
						(m_row.IsShortTerm &&
						AM_Controls.MsgBoxX.Show("Кредит первоначально должен быть сохранен.\nСохранить параметры кредита?", "BPS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
						)
					{
						if(this.SetAndValidate())
						{
							this.sqlCmdEditCredit.Connection.Open();
							this.sqlCmdEditCredit.Parameters["@CreditID"].Value				= this.m_row.CreditID;
							this.sqlCmdEditCredit.Parameters["@ClientID"].Value				= this.m_row.ClientID;
							this.sqlCmdEditCredit.Parameters["@CreditStatusID"].Value		= this.m_row.CreditStatusID;
							this.sqlCmdEditCredit.Parameters["@IsGranted"].Value			= this.m_row.IsGranted;
							this.sqlCmdEditCredit.Parameters["@StartDate"].Value			= this.m_row.StartDate;
							this.sqlCmdEditCredit.Parameters["@EndDate"].Value				= this.m_row.EndDate;
							this.sqlCmdEditCredit.Parameters["@CreditSum"].Value			= this.m_row.CreditSum;
							this.sqlCmdEditCredit.Parameters["@CreditSumCurrency"].Value	= this.m_row.CreditSumCurrency;
							this.sqlCmdEditCredit.Parameters["@ServiceCharge"].Value		= this.m_row.ServiceCharge;
							this.sqlCmdEditCredit.Parameters["@ServiceChargeExtra"].Value	= this.m_row.ServiceChargeExtra;
							this.sqlCmdEditCredit.Parameters["@Remarks"].Value				= this.m_row.Remarks;
							this.sqlCmdEditCredit.Parameters["@IsExtended"].Value			= this.m_row.IsExtended;
							this.sqlCmdEditCredit.Parameters["@IsShortTerm"].Value			= this.m_row.IsShortTerm;
							this.sqlCmdEditCredit.Parameters["@PercentageRoundMode"].Value	= this.m_row.PercentageRoundMode;
							this.sqlCmdEditCredit.Parameters["@PercentageSinkMode"].Value	= this.m_row.PercentageSinkMode;
							try
							{
								CurrentCreditID = m_row.CreditID;
								sqlCmdEditCredit.ExecuteNonQuery();
								CreditsPoints.FillDS(m_row.CreditID);
								m_bIsEdit = true;
							}
							catch(Exception ex)
							{
								AM_Controls.MsgBoxX.Show(ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Information);
							}
							finally
							{
								sqlCmdEditCredit.Connection.Close();
							}
						}
					}
					else
					{
						if(this.cbPaymentPlan.Checked)
						{
							Looped = true;
						}
						this.cbPaymentPlan.Checked = false;
						return;
					}
				}
				SetFormWidth();
			}
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			if(m_ValuesChanged)
			{
				if(AM_Controls.MsgBoxX.Show("Сохранить изменения параметров кредита?", "BPS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					UpdateCreditParams();
					m_ValuesChanged = false;
				}
				else
				{
					return;
				}
			}
			bool bAllOK = true;
			dsCreditsPoints.CreditsPointsRow row = CreditsPoints.DsCreditsPoints.CreditsPoints.NewCreditsPointsRow();
			row.CreditID = m_row.CreditID;
			CreditPointEdit CreditPointEditForm = new CreditPointEdit(row, false);
			if(CreditPointEditForm.ShowDialog() == DialogResult.OK)
			{
				try
				{
					row.CreditID = CreditsPoints.AddCreditPoint(row.CreditID, row.PointDate.Date, (double)row.PointSum);
				}
				catch(Exception ex)
				{
					AM_Controls.MsgBoxX.Show(ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					bAllOK = false;
				}
				if(bAllOK)
				{
					CreditsPoints.FillDS(m_row.CreditID);
				}
			}
		}

		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			if(m_ValuesChanged)
			{
				if(AM_Controls.MsgBoxX.Show("Сохранить изменения параметров кредита?", "BPS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					UpdateCreditParams();
					m_ValuesChanged = false;
				}
				else
				{
					return;
				}
			}
			bool bAllOK = true;
			BindingManagerBase bm = this.BindingContext[dvCreditPoints];
			dsCreditsPoints.CreditsPointsRow row = (dsCreditsPoints.CreditsPointsRow)((DataRowView)bm.Current).Row;
			CreditPointEdit CreditPointEditForm = new CreditPointEdit(row, true);
			if(CreditPointEditForm.ShowDialog() == DialogResult.OK)
			{
				try
				{
					CreditsPoints.EditCreditPoint(row.PointID, row.CreditID, row.PointDate, row.PointSum);
				}
				catch(Exception ex)
				{
					AM_Controls.MsgBoxX.Show(ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					bAllOK = false;
				}
				if(!bAllOK)
				{
					row.RejectChanges();
				}
				else
				{
					CreditsPoints.FillDS(m_row.CreditID);
				}
			}
		}

		private void btnDel_Click(object sender, System.EventArgs e)
		{
			if(m_ValuesChanged)
			{
				if(AM_Controls.MsgBoxX.Show("Сохранить изменения параметров кредита?", "BPS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					UpdateCreditParams();
					m_ValuesChanged = false;
				}
				else
				{
					return;
				}
			}
			bool bAllOK = true;
			BindingManagerBase bm = this.BindingContext[dvCreditPoints];
			dsCreditsPoints.CreditsPointsRow row = (dsCreditsPoints.CreditsPointsRow)((DataRowView)bm.Current).Row;
			if(AM_Controls.MsgBoxX.Show("Вы действительно хотите удалить запись №" + row.PointID.ToString(), "BPS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				try
				{
					CreditsPoints.DelCreditPoint(row.PointID);
				}
				catch(Exception ex)
				{
					AM_Controls.MsgBoxX.Show(ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					bAllOK = false;
				}
				if(bAllOK)
				{
					CreditsPoints.FillDS(m_row.CreditID);
				}
			}
		}
		#endregion 

		#region Controls Events
		#region Credits Dates Synchronization
		private void tbPeriod_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			this.dtEndDate.Value = this.dtStartDate.Value.Date.AddDays(this.tbPeriod.nValue);		
		}

		private void dtStartDate_ValueChanged(object sender, System.EventArgs e)
		{
			TimeSpan diff = this.dtEndDate.Value.Date.Subtract(this.dtStartDate.Value.Date);
			this.tbPeriod.nValue = diff.Days;
			m_ValuesChanged = true;
		}

		private void dtEndDate_ValueChanged(object sender, System.EventArgs e)
		{
			TimeSpan diff = this.dtEndDate.Value.Date.Subtract(this.dtStartDate.Value.Date);
			this.tbPeriod.nValue = diff.Days;
			m_ValuesChanged = true;
		}
		#endregion
		private void tbSum_TextChanged(object sender, System.EventArgs e)
		{
			m_ValuesChanged = true;
		}

		private void tbServiceCharge_TextChanged(object sender, System.EventArgs e)
		{
			m_ValuesChanged = true;
		}

		private void cmbCreditType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_ValuesChanged = true;
			if(this.cmbCreditType.SelectedIndex == 0)
			{
				Looped = true;
				this.cbPaymentPlan.Checked = false;
			}
			if(m_bIsEdit && IsLoaded && this.cmbCreditType.SelectedIndex == 1 && !(!m_row.IsExtended && !m_row.IsShortTerm))
			{
				if(AM_Controls.MsgBoxX.Show("Будет сгенерирован план погашения процентов по кредиту.\nПродолжить?", "BPS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					UpdateCreditParams();
				}
				else
				{
					return;
				}
			}
			if(m_bIsEdit && IsLoaded && this.cmbCreditType.SelectedIndex == 2 && !m_row.IsShortTerm && !m_row.IsExtended)
			{
				if(AM_Controls.MsgBoxX.Show("План выплаты процентов по кредиту будет удален.\nПродолжить?", "BPS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					CreditsPoints.DelAllPoints(m_row.CreditID);
					UpdateCreditParams();
				}
				else
				{
					return;
				}
			}
			if(this.cmbCreditType.SelectedIndex == 1 || this.cmbCreditType.SelectedIndex == 2)
			{
				this.cbPaymentPlan.Enabled = true;
			}
			else
			{
				this.cbPaymentPlan.Checked = false;
				this.cbPaymentPlan.Enabled = false;
			}
			SetFormWidth();
			SetAutoGeneratePanelEnabled();
			SetEditPointsButtonsEnabled();
		}
		#endregion

		#region Validating and Saving Results
		private bool SetAndValidate()
		{
			//Дата Выдачи и Погашения
			DateTime dt1 = this.dtStartDate.Value.Date;
			dt1 = dt1.AddHours(-dt1.Hour);
			dt1 = dt1.AddMinutes(-dt1.Minute);
			dt1 = dt1.AddSeconds(-dt1.Second);
			dt1 = dt1.AddMilliseconds(-dt1.Millisecond);

			DateTime dt2 = this.dtEndDate.Value.Date;
			dt2 = dt2.AddHours(-dt2.Hour);
			dt2 = dt2.AddMinutes(-dt2.Minute);
			dt2 = dt2.AddSeconds(-dt2.Second);
			dt2 = dt2.AddMilliseconds(-dt2.Millisecond);
			
			if(dt2.CompareTo(dt1) <= 0)
			{
				MessageBox.Show("Сохранение отменено: Дата возврата должна быть больше даты выдачи.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
			m_row.StartDate = this.dtStartDate.Value.Date;
			m_row.EndDate	= this.dtEndDate.Value.Date;
			
			//Контрагент
			m_row.ClientID = System.Convert.ToInt32(this.cmbClient.SelectedValue);
			if ( m_row.ClientID <=0) 
			{
				MessageBox.Show("Сохранение отменено: Не указан контрагент.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
			
			m_row.ClientGroupID = ((BPS.BLL.Clients.DataSets.dsClients.ClientsRow)((DataRowView)bmClients.Current).Row).ClientGroupID;
			m_row.ClientName = this.cmbClient.Text;
			
			//Состояние
			if(!m_bIsEdit)
			{
				m_row.CreditStatusID = 1;
				m_row.CreditStatusName = "Подготовлен";
			}
			
			//Сумма
			if ( this.tbSum.dValue <=0)
			{
				MessageBox.Show("Сохранение отменено: Не указана сумма кредита.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
			m_row.CreditSum = this.tbSum.dValue;
			m_row.CreditSumCurrency = this.cmbCurr.SelectedValue.ToString();
			
			//Направление
			m_row.IsGranted = this.cmbDirection.SelectedIndex == 0 ? true : false;
			
			//Процентная ставка нормальная
			if(this.tbServiceCharge.dValue <= 0)
			{
				MessageBox.Show("Сохранение отменено: Не установлена Процентная ставка по кредиту.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
			m_row.ServiceCharge = this.tbServiceCharge.dValue;
			
			//Процентная ставка штрафная
			if(this.tbServiceChargeExtra.dValue <= 0)
			{
				MessageBox.Show("Сохранение отменено: Не установлена Штрафная Процентная ставка по кредиту.", "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
			m_row.ServiceChargeExtra = this.tbServiceChargeExtra.dValue;
			
			//Комментарий
			m_row.Remarks = this.tbRemarks.Text;
			
			//Тип Кредита
			switch(this.cmbCreditType.SelectedIndex)
			{
				case 0:
					m_row.IsExtended = false;
					m_row.IsShortTerm = true;
					break;
				case 1:
					m_row.IsExtended = false;
					m_row.IsShortTerm = false;
					break;
				case 2:
					m_row.IsExtended = true;
					m_row.IsShortTerm = false;
					this.cbPaymentPlan.Checked = true;
					break;
				default:
					m_row.IsExtended = false;
					m_row.IsShortTerm = false;
					break;
			}

			//Режим округления при расчёте процентов по кредиту
			this.m_row.PercentageRoundMode =( this.rbtRoundByPeriod.Checked) ?true :false;

			//Режим погашения процентов по кредиту
			this.m_row.PercentageSinkMode =( this.rbtSinkByPeriod.Checked) ?true :false;

			return true;
		}

		private bool UpdateCreditParams()
		{
			if(SetAndValidate())
			{
				sqlCmdEditCredit.Connection.Open();
				sqlCmdEditCredit.Parameters["@CreditID"].Value			= this.m_row.CreditID;
				sqlCmdEditCredit.Parameters["@ClientID"].Value			= this.m_row.ClientID;
				sqlCmdEditCredit.Parameters["@CreditStatusID"].Value	= this.m_row.CreditStatusID;
				sqlCmdEditCredit.Parameters["@IsGranted"].Value			= this.m_row.IsGranted;
				sqlCmdEditCredit.Parameters["@StartDate"].Value			= this.m_row.StartDate;
				sqlCmdEditCredit.Parameters["@EndDate"].Value			= this.m_row.EndDate;
				sqlCmdEditCredit.Parameters["@CreditSum"].Value			= this.m_row.CreditSum;
				sqlCmdEditCredit.Parameters["@CreditSumCurrency"].Value = this.m_row.CreditSumCurrency;
				sqlCmdEditCredit.Parameters["@ServiceCharge"].Value		= this.m_row.ServiceCharge;
				sqlCmdEditCredit.Parameters["@ServiceChargeExtra"].Value= this.m_row.ServiceChargeExtra;
				sqlCmdEditCredit.Parameters["@Remarks"].Value			= this.m_row.Remarks;
				sqlCmdEditCredit.Parameters["@IsExtended"].Value		= this.m_row.IsExtended;
				sqlCmdEditCredit.Parameters["@IsShortTerm"].Value		= this.m_row.IsShortTerm;
				sqlCmdEditCredit.Parameters["@PercentageRoundMode"].Value	= this.m_row.PercentageRoundMode;
				sqlCmdEditCredit.Parameters["@PercentageSinkMode"].Value	= this.m_row.PercentageSinkMode;
				try
				{
					sqlCmdEditCredit.ExecuteNonQuery();
				}
				catch(Exception ex)
				{
					MessageBox.Show("Сохранение отменено: " +ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return false;
				}
				finally
				{
					sqlCmdEditCredit.Connection.Close();
				}
				this.CreditsPoints.FillDS(m_row.CreditID);
				this.m_CreditSaved = true;
				this.m_ValuesChanged = false;
				return true;
			}
			else
			{
				return false;
			}
		}
		#endregion
	}
}
