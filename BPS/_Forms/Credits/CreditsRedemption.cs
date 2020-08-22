using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace BPS._Forms
{
	/// <summary>
	/// Summary description for CreditsRedemption.
	/// </summary>
	public class CreditsRedemption : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label20;
		private AM_Controls.TextBoxV tbvCreditSum;
		private AM_Controls.TextBoxV tbvCreditChargeNormal;
		private AM_Controls.TextBoxV tbvCreditChargePenalty;
		private AM_Controls.TextBoxV tbvCreditLength;
		private System.Windows.Forms.TextBox tbCreditType;
		private AM_Controls.TextBoxV tbvSumPercentNormal;
		private AM_Controls.TextBoxV tbvSumPercentNormalDrop;
		private AM_Controls.TextBoxV tbvSumPercentNormalCurrent;
		private AM_Controls.TextBoxV tbvSumPercentNormalTotal;
		private AM_Controls.TextBoxV tbvSumPercentPenalty;
		private AM_Controls.TextBoxV tbvSumPercentPenaltyDrop;
		private AM_Controls.TextBoxV tbvSumPercentPenaltyCurrent;
		private AM_Controls.TextBoxV tbvSumPercentPenaltyTotal;
		private AM_Controls.TextBoxV tbvSumCreditDrop;
		private AM_Controls.TextBoxV tbvSumCreditRest;
		private AM_Controls.TextBoxV tbvSumRedemption;
		private AM_Controls.TextBoxV tbvSumIncome;
		private AM_Controls.TextBoxV tbvSumRest;
		private System.Windows.Forms.Button btnExecute;
		private System.Data.SqlClient.SqlConnection sqlConnection1;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;

		private int m_CreditID =0;
		private System.Windows.Forms.DateTimePicker dtpOperationDate;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.TextBox tbLastDatePercentNormal;
		private System.Windows.Forms.TextBox tbLastDatePercentNormalDrop;
		private System.Windows.Forms.TextBox tbLastDatePercentPenalty;
		private System.Windows.Forms.TextBox tbLastDatePercentPenaltyDrop;
		private System.Windows.Forms.TextBox tbLastDateCreditDrop;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Button btnRecalc;
		private bool m_DataIsActual	=false;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label lbCurrency00;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.Label lbCurrency01;
		private System.Windows.Forms.Label lbCurrency02;
		private System.Windows.Forms.Label lbCurrency03;
		private System.Windows.Forms.TextBox tbCreditDateStart;
		private System.Windows.Forms.TextBox tbCreditDateEnd;
		private System.Windows.Forms.TextBox tbLastCreditDate;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.DataGrid dgPointsInfo;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnPID;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnPointDate;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnPointSum;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnPointPercentSum;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnPointSumSink;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnPointSumSinkLastDate;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnPointPercentNormalDebt;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnPointPercentNormalSink;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnPointPercentNormalDue;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnPointPercentNormalDebtLastDate;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnPointPercentPenaltyDebt;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnPointPercentPenaltySink;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnPointPercentPenaltyDue;
		private System.Windows.Forms.DataGridTextBoxColumn ColumnPointPercentPenaltyDebtLastDate;
		private System.Data.SqlClient.SqlConnection sqlConnection2;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.TextBox tbRoundMode;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.Label label33;
		private AM_Controls.TextBoxV tbvSumCreditIncrease;
		private System.Windows.Forms.TextBox tbLastDateCreditIncrease;
		private System.Windows.Forms.Label label34;
		private BPS.BLL.Credits.DataSets.dsCreditsPointsInfoList dsCreditsPointsInfoList2;
		private System.Windows.Forms.TextBox tbNormalSinkMode;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.TextBox tbPenaltySinkMode;
		private System.Windows.Forms.TextBox tbCreditID;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.TextBox tbClientName;
		private System.Windows.Forms.Label label37;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CreditsRedemption()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			
			// Set Details Part invisible
			App.SetDataGridTableStyle( this.dataGridTableStyle1);
			this.SetClientSize( false); 

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(CreditsRedemption));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tbCreditType = new System.Windows.Forms.TextBox();
			this.tbvCreditSum = new AM_Controls.TextBoxV();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.tbvCreditChargeNormal = new AM_Controls.TextBoxV();
			this.tbvCreditChargePenalty = new AM_Controls.TextBoxV();
			this.tbvCreditLength = new AM_Controls.TextBoxV();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.tbCreditDateStart = new System.Windows.Forms.TextBox();
			this.tbCreditDateEnd = new System.Windows.Forms.TextBox();
			this.label27 = new System.Windows.Forms.Label();
			this.lbCurrency00 = new System.Windows.Forms.Label();
			this.label28 = new System.Windows.Forms.Label();
			this.label29 = new System.Windows.Forms.Label();
			this.tbRoundMode = new System.Windows.Forms.TextBox();
			this.label31 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.tbLastDatePercentNormal = new System.Windows.Forms.TextBox();
			this.tbvSumPercentNormal = new AM_Controls.TextBoxV();
			this.label8 = new System.Windows.Forms.Label();
			this.tbvSumPercentNormalDrop = new AM_Controls.TextBoxV();
			this.label9 = new System.Windows.Forms.Label();
			this.tbvSumPercentNormalCurrent = new AM_Controls.TextBoxV();
			this.label10 = new System.Windows.Forms.Label();
			this.tbvSumPercentNormalTotal = new AM_Controls.TextBoxV();
			this.label11 = new System.Windows.Forms.Label();
			this.tbLastDatePercentNormalDrop = new System.Windows.Forms.TextBox();
			this.label22 = new System.Windows.Forms.Label();
			this.label23 = new System.Windows.Forms.Label();
			this.tbNormalSinkMode = new System.Windows.Forms.TextBox();
			this.label32 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.tbvSumPercentPenalty = new AM_Controls.TextBoxV();
			this.label12 = new System.Windows.Forms.Label();
			this.tbvSumPercentPenaltyDrop = new AM_Controls.TextBoxV();
			this.label13 = new System.Windows.Forms.Label();
			this.tbvSumPercentPenaltyCurrent = new AM_Controls.TextBoxV();
			this.label14 = new System.Windows.Forms.Label();
			this.tbvSumPercentPenaltyTotal = new AM_Controls.TextBoxV();
			this.label15 = new System.Windows.Forms.Label();
			this.tbLastDatePercentPenalty = new System.Windows.Forms.TextBox();
			this.tbLastDatePercentPenaltyDrop = new System.Windows.Forms.TextBox();
			this.label24 = new System.Windows.Forms.Label();
			this.label25 = new System.Windows.Forms.Label();
			this.label35 = new System.Windows.Forms.Label();
			this.tbPenaltySinkMode = new System.Windows.Forms.TextBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.tbvSumCreditDrop = new AM_Controls.TextBoxV();
			this.label16 = new System.Windows.Forms.Label();
			this.tbvSumCreditRest = new AM_Controls.TextBoxV();
			this.label17 = new System.Windows.Forms.Label();
			this.tbLastDateCreditDrop = new System.Windows.Forms.TextBox();
			this.label26 = new System.Windows.Forms.Label();
			this.label33 = new System.Windows.Forms.Label();
			this.tbvSumCreditIncrease = new AM_Controls.TextBoxV();
			this.tbLastDateCreditIncrease = new System.Windows.Forms.TextBox();
			this.label34 = new System.Windows.Forms.Label();
			this.tbvSumRedemption = new AM_Controls.TextBoxV();
			this.label18 = new System.Windows.Forms.Label();
			this.tbvSumIncome = new AM_Controls.TextBoxV();
			this.label19 = new System.Windows.Forms.Label();
			this.tbvSumRest = new AM_Controls.TextBoxV();
			this.label20 = new System.Windows.Forms.Label();
			this.btnExecute = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.dtpOperationDate = new System.Windows.Forms.DateTimePicker();
			this.label21 = new System.Windows.Forms.Label();
			this.btnRecalc = new System.Windows.Forms.Button();
			this.lbCurrency01 = new System.Windows.Forms.Label();
			this.lbCurrency02 = new System.Windows.Forms.Label();
			this.lbCurrency03 = new System.Windows.Forms.Label();
			this.tbLastCreditDate = new System.Windows.Forms.TextBox();
			this.label30 = new System.Windows.Forms.Label();
			this.dgPointsInfo = new System.Windows.Forms.DataGrid();
			this.dsCreditsPointsInfoList2 = new BPS.BLL.Credits.DataSets.dsCreditsPointsInfoList();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.ColumnPID = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnPointDate = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnPointSum = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnPointPercentSum = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnPointSumSink = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnPointSumSinkLastDate = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnPointPercentNormalDebt = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnPointPercentNormalSink = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnPointPercentNormalDue = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnPointPercentNormalDebtLastDate = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnPointPercentPenaltyDebt = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnPointPercentPenaltySink = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnPointPercentPenaltyDue = new System.Windows.Forms.DataGridTextBoxColumn();
			this.ColumnPointPercentPenaltyDebtLastDate = new System.Windows.Forms.DataGridTextBoxColumn();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection2 = new System.Data.SqlClient.SqlConnection();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.tbCreditID = new System.Windows.Forms.TextBox();
			this.label36 = new System.Windows.Forms.Label();
			this.tbClientName = new System.Windows.Forms.TextBox();
			this.label37 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgPointsInfo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsCreditsPointsInfoList2)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.tbCreditType);
			this.groupBox1.Controls.Add(this.tbvCreditSum);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.tbvCreditChargeNormal);
			this.groupBox1.Controls.Add(this.tbvCreditChargePenalty);
			this.groupBox1.Controls.Add(this.tbvCreditLength);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.tbCreditDateStart);
			this.groupBox1.Controls.Add(this.tbCreditDateEnd);
			this.groupBox1.Controls.Add(this.label27);
			this.groupBox1.Controls.Add(this.lbCurrency00);
			this.groupBox1.Controls.Add(this.label28);
			this.groupBox1.Controls.Add(this.label29);
			this.groupBox1.Controls.Add(this.tbRoundMode);
			this.groupBox1.Controls.Add(this.label31);
			this.groupBox1.Controls.Add(this.tbCreditID);
			this.groupBox1.Controls.Add(this.label36);
			this.groupBox1.Controls.Add(this.tbClientName);
			this.groupBox1.Controls.Add(this.label37);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.groupBox1.Location = new System.Drawing.Point(4, 1);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(410, 157);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Инфо";
			// 
			// tbCreditType
			// 
			this.tbCreditType.BackColor = System.Drawing.Color.Ivory;
			this.tbCreditType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.tbCreditType.Location = new System.Drawing.Point(110, 40);
			this.tbCreditType.Name = "tbCreditType";
			this.tbCreditType.ReadOnly = true;
			this.tbCreditType.Size = new System.Drawing.Size(292, 20);
			this.tbCreditType.TabIndex = 3;
			this.tbCreditType.Text = "";
			// 
			// tbvCreditSum
			// 
			this.tbvCreditSum.AllowDrop = true;
			this.tbvCreditSum.BackColor = System.Drawing.Color.Ivory;
			this.tbvCreditSum.dValue = 0;
			this.tbvCreditSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.tbvCreditSum.IsPcnt = false;
			this.tbvCreditSum.Location = new System.Drawing.Point(110, 64);
			this.tbvCreditSum.MaxDecPos = 2;
			this.tbvCreditSum.MaxPos = 8;
			this.tbvCreditSum.Name = "tbvCreditSum";
			this.tbvCreditSum.Negative = System.Drawing.Color.Empty;
			this.tbvCreditSum.nValue = ((long)(0));
			this.tbvCreditSum.Positive = System.Drawing.Color.Empty;
			this.tbvCreditSum.ReadOnly = true;
			this.tbvCreditSum.TabIndex = 1;
			this.tbvCreditSum.Text = "0";
			this.tbvCreditSum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbvCreditSum.TextMode = false;
			this.tbvCreditSum.Zero = System.Drawing.Color.Empty;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label1.Location = new System.Drawing.Point(14, 64);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(93, 18);
			this.label1.TabIndex = 0;
			this.label1.Text = "Тело Кредита:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label2.Location = new System.Drawing.Point(14, 84);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(93, 18);
			this.label2.TabIndex = 0;
			this.label2.Text = "Ставка:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label3.Location = new System.Drawing.Point(14, 106);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(93, 18);
			this.label3.TabIndex = 0;
			this.label3.Text = "Ставка (Штраф):";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbvCreditChargeNormal
			// 
			this.tbvCreditChargeNormal.AllowDrop = true;
			this.tbvCreditChargeNormal.BackColor = System.Drawing.Color.Ivory;
			this.tbvCreditChargeNormal.dValue = 0;
			this.tbvCreditChargeNormal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.tbvCreditChargeNormal.IsPcnt = true;
			this.tbvCreditChargeNormal.Location = new System.Drawing.Point(110, 84);
			this.tbvCreditChargeNormal.MaxDecPos = 2;
			this.tbvCreditChargeNormal.MaxPos = 8;
			this.tbvCreditChargeNormal.Name = "tbvCreditChargeNormal";
			this.tbvCreditChargeNormal.Negative = System.Drawing.Color.Empty;
			this.tbvCreditChargeNormal.nValue = ((long)(0));
			this.tbvCreditChargeNormal.Positive = System.Drawing.Color.Empty;
			this.tbvCreditChargeNormal.ReadOnly = true;
			this.tbvCreditChargeNormal.TabIndex = 1;
			this.tbvCreditChargeNormal.Text = "0";
			this.tbvCreditChargeNormal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbvCreditChargeNormal.TextMode = false;
			this.tbvCreditChargeNormal.Zero = System.Drawing.Color.Empty;
			// 
			// tbvCreditChargePenalty
			// 
			this.tbvCreditChargePenalty.AllowDrop = true;
			this.tbvCreditChargePenalty.BackColor = System.Drawing.Color.Ivory;
			this.tbvCreditChargePenalty.dValue = 0;
			this.tbvCreditChargePenalty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.tbvCreditChargePenalty.IsPcnt = true;
			this.tbvCreditChargePenalty.Location = new System.Drawing.Point(110, 106);
			this.tbvCreditChargePenalty.MaxDecPos = 2;
			this.tbvCreditChargePenalty.MaxPos = 8;
			this.tbvCreditChargePenalty.Name = "tbvCreditChargePenalty";
			this.tbvCreditChargePenalty.Negative = System.Drawing.Color.Empty;
			this.tbvCreditChargePenalty.nValue = ((long)(0));
			this.tbvCreditChargePenalty.Positive = System.Drawing.Color.Empty;
			this.tbvCreditChargePenalty.ReadOnly = true;
			this.tbvCreditChargePenalty.TabIndex = 1;
			this.tbvCreditChargePenalty.Text = "0";
			this.tbvCreditChargePenalty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbvCreditChargePenalty.TextMode = false;
			this.tbvCreditChargePenalty.Zero = System.Drawing.Color.Empty;
			// 
			// tbvCreditLength
			// 
			this.tbvCreditLength.AllowDrop = true;
			this.tbvCreditLength.BackColor = System.Drawing.Color.Ivory;
			this.tbvCreditLength.dValue = 0;
			this.tbvCreditLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.tbvCreditLength.IsPcnt = false;
			this.tbvCreditLength.Location = new System.Drawing.Point(302, 106);
			this.tbvCreditLength.MaxDecPos = 0;
			this.tbvCreditLength.MaxPos = 8;
			this.tbvCreditLength.Name = "tbvCreditLength";
			this.tbvCreditLength.Negative = System.Drawing.Color.Empty;
			this.tbvCreditLength.nValue = ((long)(0));
			this.tbvCreditLength.Positive = System.Drawing.Color.Empty;
			this.tbvCreditLength.ReadOnly = true;
			this.tbvCreditLength.Size = new System.Drawing.Size(65, 20);
			this.tbvCreditLength.TabIndex = 1;
			this.tbvCreditLength.Text = "0";
			this.tbvCreditLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbvCreditLength.TextMode = false;
			this.tbvCreditLength.Zero = System.Drawing.Color.Empty;
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label4.Location = new System.Drawing.Point(250, 64);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(20, 18);
			this.label4.TabIndex = 0;
			this.label4.Text = "C:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label5.Location = new System.Drawing.Point(250, 84);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(28, 18);
			this.label5.TabIndex = 0;
			this.label5.Text = "По:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label6.Location = new System.Drawing.Point(250, 106);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(50, 18);
			this.label6.TabIndex = 0;
			this.label6.Text = "Сроком:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label7.Location = new System.Drawing.Point(14, 42);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(93, 18);
			this.label7.TabIndex = 0;
			this.label7.Text = "Тип Кредита:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbCreditDateStart
			// 
			this.tbCreditDateStart.BackColor = System.Drawing.Color.Ivory;
			this.tbCreditDateStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.tbCreditDateStart.Location = new System.Drawing.Point(302, 64);
			this.tbCreditDateStart.Name = "tbCreditDateStart";
			this.tbCreditDateStart.ReadOnly = true;
			this.tbCreditDateStart.TabIndex = 2;
			this.tbCreditDateStart.Text = "";
			this.tbCreditDateStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// tbCreditDateEnd
			// 
			this.tbCreditDateEnd.BackColor = System.Drawing.Color.Ivory;
			this.tbCreditDateEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.tbCreditDateEnd.Location = new System.Drawing.Point(302, 84);
			this.tbCreditDateEnd.Name = "tbCreditDateEnd";
			this.tbCreditDateEnd.ReadOnly = true;
			this.tbCreditDateEnd.TabIndex = 2;
			this.tbCreditDateEnd.Text = "";
			this.tbCreditDateEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label27
			// 
			this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label27.Location = new System.Drawing.Point(371, 85);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(31, 18);
			this.label27.TabIndex = 0;
			this.label27.Text = "дней";
			this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbCurrency00
			// 
			this.lbCurrency00.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.lbCurrency00.Location = new System.Drawing.Point(212, 64);
			this.lbCurrency00.Name = "lbCurrency00";
			this.lbCurrency00.Size = new System.Drawing.Size(30, 18);
			this.lbCurrency00.TabIndex = 0;
			this.lbCurrency00.Text = "?";
			this.lbCurrency00.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label28
			// 
			this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label28.Location = new System.Drawing.Point(212, 84);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(20, 18);
			this.label28.TabIndex = 0;
			this.label28.Text = "%";
			this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label29
			// 
			this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label29.Location = new System.Drawing.Point(212, 106);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(20, 18);
			this.label29.TabIndex = 0;
			this.label29.Text = "%";
			this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbRoundMode
			// 
			this.tbRoundMode.BackColor = System.Drawing.Color.Ivory;
			this.tbRoundMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.tbRoundMode.Location = new System.Drawing.Point(110, 130);
			this.tbRoundMode.Name = "tbRoundMode";
			this.tbRoundMode.ReadOnly = true;
			this.tbRoundMode.Size = new System.Drawing.Size(292, 20);
			this.tbRoundMode.TabIndex = 3;
			this.tbRoundMode.Text = "";
			// 
			// label31
			// 
			this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label31.Location = new System.Drawing.Point(14, 132);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(93, 18);
			this.label31.TabIndex = 0;
			this.label31.Text = "Округление:";
			this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.tbLastDatePercentNormal);
			this.groupBox2.Controls.Add(this.tbvSumPercentNormal);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.tbvSumPercentNormalDrop);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.tbvSumPercentNormalCurrent);
			this.groupBox2.Controls.Add(this.label10);
			this.groupBox2.Controls.Add(this.tbvSumPercentNormalTotal);
			this.groupBox2.Controls.Add(this.label11);
			this.groupBox2.Controls.Add(this.tbLastDatePercentNormalDrop);
			this.groupBox2.Controls.Add(this.label22);
			this.groupBox2.Controls.Add(this.label23);
			this.groupBox2.Controls.Add(this.tbNormalSinkMode);
			this.groupBox2.Controls.Add(this.label32);
			this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.groupBox2.Location = new System.Drawing.Point(4, 162);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(410, 110);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Проценты Нормальные";
			// 
			// tbLastDatePercentNormal
			// 
			this.tbLastDatePercentNormal.BackColor = System.Drawing.Color.Ivory;
			this.tbLastDatePercentNormal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.tbLastDatePercentNormal.Location = new System.Drawing.Point(302, 18);
			this.tbLastDatePercentNormal.Name = "tbLastDatePercentNormal";
			this.tbLastDatePercentNormal.ReadOnly = true;
			this.tbLastDatePercentNormal.TabIndex = 2;
			this.tbLastDatePercentNormal.Text = "";
			this.tbLastDatePercentNormal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// tbvSumPercentNormal
			// 
			this.tbvSumPercentNormal.AllowDrop = true;
			this.tbvSumPercentNormal.BackColor = System.Drawing.Color.Ivory;
			this.tbvSumPercentNormal.dValue = 0;
			this.tbvSumPercentNormal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.tbvSumPercentNormal.IsPcnt = false;
			this.tbvSumPercentNormal.Location = new System.Drawing.Point(100, 18);
			this.tbvSumPercentNormal.MaxDecPos = 2;
			this.tbvSumPercentNormal.MaxPos = 8;
			this.tbvSumPercentNormal.Name = "tbvSumPercentNormal";
			this.tbvSumPercentNormal.Negative = System.Drawing.Color.Empty;
			this.tbvSumPercentNormal.nValue = ((long)(0));
			this.tbvSumPercentNormal.Positive = System.Drawing.Color.Empty;
			this.tbvSumPercentNormal.ReadOnly = true;
			this.tbvSumPercentNormal.TabIndex = 1;
			this.tbvSumPercentNormal.Text = "0";
			this.tbvSumPercentNormal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbvSumPercentNormal.TextMode = false;
			this.tbvSumPercentNormal.Zero = System.Drawing.Color.Empty;
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label8.Location = new System.Drawing.Point(14, 18);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(78, 18);
			this.label8.TabIndex = 0;
			this.label8.Text = "Начислено:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbvSumPercentNormalDrop
			// 
			this.tbvSumPercentNormalDrop.AllowDrop = true;
			this.tbvSumPercentNormalDrop.BackColor = System.Drawing.Color.Ivory;
			this.tbvSumPercentNormalDrop.dValue = 0;
			this.tbvSumPercentNormalDrop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.tbvSumPercentNormalDrop.IsPcnt = false;
			this.tbvSumPercentNormalDrop.Location = new System.Drawing.Point(100, 39);
			this.tbvSumPercentNormalDrop.MaxDecPos = 2;
			this.tbvSumPercentNormalDrop.MaxPos = 8;
			this.tbvSumPercentNormalDrop.Name = "tbvSumPercentNormalDrop";
			this.tbvSumPercentNormalDrop.Negative = System.Drawing.Color.Empty;
			this.tbvSumPercentNormalDrop.nValue = ((long)(0));
			this.tbvSumPercentNormalDrop.Positive = System.Drawing.Color.Empty;
			this.tbvSumPercentNormalDrop.ReadOnly = true;
			this.tbvSumPercentNormalDrop.TabIndex = 1;
			this.tbvSumPercentNormalDrop.Text = "0";
			this.tbvSumPercentNormalDrop.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbvSumPercentNormalDrop.TextMode = false;
			this.tbvSumPercentNormalDrop.Zero = System.Drawing.Color.Empty;
			// 
			// label9
			// 
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label9.Location = new System.Drawing.Point(14, 39);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(78, 18);
			this.label9.TabIndex = 0;
			this.label9.Text = "Погашено:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbvSumPercentNormalCurrent
			// 
			this.tbvSumPercentNormalCurrent.AllowDrop = true;
			this.tbvSumPercentNormalCurrent.BackColor = System.Drawing.Color.Ivory;
			this.tbvSumPercentNormalCurrent.dValue = 0;
			this.tbvSumPercentNormalCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.tbvSumPercentNormalCurrent.IsPcnt = false;
			this.tbvSumPercentNormalCurrent.Location = new System.Drawing.Point(100, 60);
			this.tbvSumPercentNormalCurrent.MaxDecPos = 2;
			this.tbvSumPercentNormalCurrent.MaxPos = 8;
			this.tbvSumPercentNormalCurrent.Name = "tbvSumPercentNormalCurrent";
			this.tbvSumPercentNormalCurrent.Negative = System.Drawing.Color.Empty;
			this.tbvSumPercentNormalCurrent.nValue = ((long)(0));
			this.tbvSumPercentNormalCurrent.Positive = System.Drawing.Color.Empty;
			this.tbvSumPercentNormalCurrent.ReadOnly = true;
			this.tbvSumPercentNormalCurrent.TabIndex = 1;
			this.tbvSumPercentNormalCurrent.Text = "0";
			this.tbvSumPercentNormalCurrent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbvSumPercentNormalCurrent.TextMode = false;
			this.tbvSumPercentNormalCurrent.Zero = System.Drawing.Color.Empty;
			// 
			// label10
			// 
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label10.Location = new System.Drawing.Point(14, 61);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(78, 18);
			this.label10.TabIndex = 0;
			this.label10.Text = "Начислено(*):";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbvSumPercentNormalTotal
			// 
			this.tbvSumPercentNormalTotal.AllowDrop = true;
			this.tbvSumPercentNormalTotal.BackColor = System.Drawing.Color.Ivory;
			this.tbvSumPercentNormalTotal.dValue = 0;
			this.tbvSumPercentNormalTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.tbvSumPercentNormalTotal.IsPcnt = false;
			this.tbvSumPercentNormalTotal.Location = new System.Drawing.Point(100, 81);
			this.tbvSumPercentNormalTotal.MaxDecPos = 2;
			this.tbvSumPercentNormalTotal.MaxPos = 8;
			this.tbvSumPercentNormalTotal.Name = "tbvSumPercentNormalTotal";
			this.tbvSumPercentNormalTotal.Negative = System.Drawing.Color.Empty;
			this.tbvSumPercentNormalTotal.nValue = ((long)(0));
			this.tbvSumPercentNormalTotal.Positive = System.Drawing.Color.Empty;
			this.tbvSumPercentNormalTotal.ReadOnly = true;
			this.tbvSumPercentNormalTotal.TabIndex = 1;
			this.tbvSumPercentNormalTotal.Text = "0";
			this.tbvSumPercentNormalTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbvSumPercentNormalTotal.TextMode = false;
			this.tbvSumPercentNormalTotal.Zero = System.Drawing.Color.Empty;
			// 
			// label11
			// 
			this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label11.Location = new System.Drawing.Point(14, 83);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(83, 18);
			this.label11.TabIndex = 0;
			this.label11.Text = "К Погашению:";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label11.UseMnemonic = false;
			// 
			// tbLastDatePercentNormalDrop
			// 
			this.tbLastDatePercentNormalDrop.BackColor = System.Drawing.Color.Ivory;
			this.tbLastDatePercentNormalDrop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.tbLastDatePercentNormalDrop.Location = new System.Drawing.Point(302, 39);
			this.tbLastDatePercentNormalDrop.Name = "tbLastDatePercentNormalDrop";
			this.tbLastDatePercentNormalDrop.ReadOnly = true;
			this.tbLastDatePercentNormalDrop.TabIndex = 2;
			this.tbLastDatePercentNormalDrop.Text = "";
			this.tbLastDatePercentNormalDrop.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label22
			// 
			this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label22.Location = new System.Drawing.Point(204, 18);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(96, 18);
			this.label22.TabIndex = 0;
			this.label22.Text = "Последняя Дата:";
			this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label23
			// 
			this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label23.Location = new System.Drawing.Point(204, 39);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(96, 18);
			this.label23.TabIndex = 0;
			this.label23.Text = "Последняя Дата:";
			this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbNormalSinkMode
			// 
			this.tbNormalSinkMode.BackColor = System.Drawing.Color.Ivory;
			this.tbNormalSinkMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.tbNormalSinkMode.Location = new System.Drawing.Point(262, 81);
			this.tbNormalSinkMode.Name = "tbNormalSinkMode";
			this.tbNormalSinkMode.ReadOnly = true;
			this.tbNormalSinkMode.Size = new System.Drawing.Size(140, 20);
			this.tbNormalSinkMode.TabIndex = 2;
			this.tbNormalSinkMode.Text = "";
			this.tbNormalSinkMode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label32
			// 
			this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label32.Location = new System.Drawing.Point(204, 83);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(55, 18);
			this.label32.TabIndex = 0;
			this.label32.Text = "Гашение:";
			this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.tbvSumPercentPenalty);
			this.groupBox3.Controls.Add(this.label12);
			this.groupBox3.Controls.Add(this.tbvSumPercentPenaltyDrop);
			this.groupBox3.Controls.Add(this.label13);
			this.groupBox3.Controls.Add(this.tbvSumPercentPenaltyCurrent);
			this.groupBox3.Controls.Add(this.label14);
			this.groupBox3.Controls.Add(this.tbvSumPercentPenaltyTotal);
			this.groupBox3.Controls.Add(this.label15);
			this.groupBox3.Controls.Add(this.tbLastDatePercentPenalty);
			this.groupBox3.Controls.Add(this.tbLastDatePercentPenaltyDrop);
			this.groupBox3.Controls.Add(this.label24);
			this.groupBox3.Controls.Add(this.label25);
			this.groupBox3.Controls.Add(this.label35);
			this.groupBox3.Controls.Add(this.tbPenaltySinkMode);
			this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.groupBox3.Location = new System.Drawing.Point(4, 276);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(410, 110);
			this.groupBox3.TabIndex = 2;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Проценты Штрафные";
			// 
			// tbvSumPercentPenalty
			// 
			this.tbvSumPercentPenalty.AllowDrop = true;
			this.tbvSumPercentPenalty.BackColor = System.Drawing.Color.Ivory;
			this.tbvSumPercentPenalty.dValue = 0;
			this.tbvSumPercentPenalty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.tbvSumPercentPenalty.IsPcnt = false;
			this.tbvSumPercentPenalty.Location = new System.Drawing.Point(100, 18);
			this.tbvSumPercentPenalty.MaxDecPos = 2;
			this.tbvSumPercentPenalty.MaxPos = 8;
			this.tbvSumPercentPenalty.Name = "tbvSumPercentPenalty";
			this.tbvSumPercentPenalty.Negative = System.Drawing.Color.Empty;
			this.tbvSumPercentPenalty.nValue = ((long)(0));
			this.tbvSumPercentPenalty.Positive = System.Drawing.Color.Empty;
			this.tbvSumPercentPenalty.ReadOnly = true;
			this.tbvSumPercentPenalty.TabIndex = 1;
			this.tbvSumPercentPenalty.Text = "0";
			this.tbvSumPercentPenalty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbvSumPercentPenalty.TextMode = false;
			this.tbvSumPercentPenalty.Zero = System.Drawing.Color.Empty;
			// 
			// label12
			// 
			this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label12.Location = new System.Drawing.Point(14, 18);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(78, 18);
			this.label12.TabIndex = 0;
			this.label12.Text = "Начислено:";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbvSumPercentPenaltyDrop
			// 
			this.tbvSumPercentPenaltyDrop.AllowDrop = true;
			this.tbvSumPercentPenaltyDrop.BackColor = System.Drawing.Color.Ivory;
			this.tbvSumPercentPenaltyDrop.dValue = 0;
			this.tbvSumPercentPenaltyDrop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.tbvSumPercentPenaltyDrop.IsPcnt = false;
			this.tbvSumPercentPenaltyDrop.Location = new System.Drawing.Point(100, 39);
			this.tbvSumPercentPenaltyDrop.MaxDecPos = 2;
			this.tbvSumPercentPenaltyDrop.MaxPos = 8;
			this.tbvSumPercentPenaltyDrop.Name = "tbvSumPercentPenaltyDrop";
			this.tbvSumPercentPenaltyDrop.Negative = System.Drawing.Color.Empty;
			this.tbvSumPercentPenaltyDrop.nValue = ((long)(0));
			this.tbvSumPercentPenaltyDrop.Positive = System.Drawing.Color.Empty;
			this.tbvSumPercentPenaltyDrop.ReadOnly = true;
			this.tbvSumPercentPenaltyDrop.TabIndex = 1;
			this.tbvSumPercentPenaltyDrop.Text = "0";
			this.tbvSumPercentPenaltyDrop.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbvSumPercentPenaltyDrop.TextMode = false;
			this.tbvSumPercentPenaltyDrop.Zero = System.Drawing.Color.Empty;
			// 
			// label13
			// 
			this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label13.Location = new System.Drawing.Point(14, 39);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(78, 18);
			this.label13.TabIndex = 0;
			this.label13.Text = "Погашено:";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbvSumPercentPenaltyCurrent
			// 
			this.tbvSumPercentPenaltyCurrent.AllowDrop = true;
			this.tbvSumPercentPenaltyCurrent.BackColor = System.Drawing.Color.Ivory;
			this.tbvSumPercentPenaltyCurrent.dValue = 0;
			this.tbvSumPercentPenaltyCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.tbvSumPercentPenaltyCurrent.IsPcnt = false;
			this.tbvSumPercentPenaltyCurrent.Location = new System.Drawing.Point(100, 60);
			this.tbvSumPercentPenaltyCurrent.MaxDecPos = 2;
			this.tbvSumPercentPenaltyCurrent.MaxPos = 8;
			this.tbvSumPercentPenaltyCurrent.Name = "tbvSumPercentPenaltyCurrent";
			this.tbvSumPercentPenaltyCurrent.Negative = System.Drawing.Color.Empty;
			this.tbvSumPercentPenaltyCurrent.nValue = ((long)(0));
			this.tbvSumPercentPenaltyCurrent.Positive = System.Drawing.Color.Empty;
			this.tbvSumPercentPenaltyCurrent.ReadOnly = true;
			this.tbvSumPercentPenaltyCurrent.TabIndex = 1;
			this.tbvSumPercentPenaltyCurrent.Text = "0";
			this.tbvSumPercentPenaltyCurrent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbvSumPercentPenaltyCurrent.TextMode = false;
			this.tbvSumPercentPenaltyCurrent.Zero = System.Drawing.Color.Empty;
			// 
			// label14
			// 
			this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label14.Location = new System.Drawing.Point(14, 61);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(78, 18);
			this.label14.TabIndex = 0;
			this.label14.Text = "Начислено(*):";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbvSumPercentPenaltyTotal
			// 
			this.tbvSumPercentPenaltyTotal.AllowDrop = true;
			this.tbvSumPercentPenaltyTotal.BackColor = System.Drawing.Color.Ivory;
			this.tbvSumPercentPenaltyTotal.dValue = 0;
			this.tbvSumPercentPenaltyTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.tbvSumPercentPenaltyTotal.IsPcnt = false;
			this.tbvSumPercentPenaltyTotal.Location = new System.Drawing.Point(100, 81);
			this.tbvSumPercentPenaltyTotal.MaxDecPos = 2;
			this.tbvSumPercentPenaltyTotal.MaxPos = 8;
			this.tbvSumPercentPenaltyTotal.Name = "tbvSumPercentPenaltyTotal";
			this.tbvSumPercentPenaltyTotal.Negative = System.Drawing.Color.Empty;
			this.tbvSumPercentPenaltyTotal.nValue = ((long)(0));
			this.tbvSumPercentPenaltyTotal.Positive = System.Drawing.Color.Empty;
			this.tbvSumPercentPenaltyTotal.ReadOnly = true;
			this.tbvSumPercentPenaltyTotal.TabIndex = 1;
			this.tbvSumPercentPenaltyTotal.Text = "0";
			this.tbvSumPercentPenaltyTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbvSumPercentPenaltyTotal.TextMode = false;
			this.tbvSumPercentPenaltyTotal.Zero = System.Drawing.Color.Empty;
			// 
			// label15
			// 
			this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label15.Location = new System.Drawing.Point(14, 83);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(83, 18);
			this.label15.TabIndex = 0;
			this.label15.Text = "К Погашению:";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label15.UseMnemonic = false;
			// 
			// tbLastDatePercentPenalty
			// 
			this.tbLastDatePercentPenalty.BackColor = System.Drawing.Color.Ivory;
			this.tbLastDatePercentPenalty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.tbLastDatePercentPenalty.Location = new System.Drawing.Point(302, 18);
			this.tbLastDatePercentPenalty.Name = "tbLastDatePercentPenalty";
			this.tbLastDatePercentPenalty.ReadOnly = true;
			this.tbLastDatePercentPenalty.TabIndex = 2;
			this.tbLastDatePercentPenalty.Text = "";
			this.tbLastDatePercentPenalty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// tbLastDatePercentPenaltyDrop
			// 
			this.tbLastDatePercentPenaltyDrop.BackColor = System.Drawing.Color.Ivory;
			this.tbLastDatePercentPenaltyDrop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.tbLastDatePercentPenaltyDrop.Location = new System.Drawing.Point(302, 39);
			this.tbLastDatePercentPenaltyDrop.Name = "tbLastDatePercentPenaltyDrop";
			this.tbLastDatePercentPenaltyDrop.ReadOnly = true;
			this.tbLastDatePercentPenaltyDrop.TabIndex = 2;
			this.tbLastDatePercentPenaltyDrop.Text = "";
			this.tbLastDatePercentPenaltyDrop.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label24
			// 
			this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label24.Location = new System.Drawing.Point(204, 18);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(96, 18);
			this.label24.TabIndex = 0;
			this.label24.Text = "Последняя Дата:";
			this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label25
			// 
			this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label25.Location = new System.Drawing.Point(204, 39);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(96, 18);
			this.label25.TabIndex = 0;
			this.label25.Text = "Последняя Дата:";
			this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label35
			// 
			this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label35.Location = new System.Drawing.Point(204, 83);
			this.label35.Name = "label35";
			this.label35.Size = new System.Drawing.Size(55, 18);
			this.label35.TabIndex = 0;
			this.label35.Text = "Гашение:";
			this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbPenaltySinkMode
			// 
			this.tbPenaltySinkMode.BackColor = System.Drawing.Color.Ivory;
			this.tbPenaltySinkMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.tbPenaltySinkMode.Location = new System.Drawing.Point(262, 81);
			this.tbPenaltySinkMode.Name = "tbPenaltySinkMode";
			this.tbPenaltySinkMode.ReadOnly = true;
			this.tbPenaltySinkMode.Size = new System.Drawing.Size(140, 20);
			this.tbPenaltySinkMode.TabIndex = 2;
			this.tbPenaltySinkMode.Text = "";
			this.tbPenaltySinkMode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.tbvSumCreditDrop);
			this.groupBox4.Controls.Add(this.label16);
			this.groupBox4.Controls.Add(this.tbvSumCreditRest);
			this.groupBox4.Controls.Add(this.label17);
			this.groupBox4.Controls.Add(this.tbLastDateCreditDrop);
			this.groupBox4.Controls.Add(this.label26);
			this.groupBox4.Controls.Add(this.label33);
			this.groupBox4.Controls.Add(this.tbvSumCreditIncrease);
			this.groupBox4.Controls.Add(this.tbLastDateCreditIncrease);
			this.groupBox4.Controls.Add(this.label34);
			this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.groupBox4.Location = new System.Drawing.Point(4, 390);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(410, 90);
			this.groupBox4.TabIndex = 3;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Тело Кредита";
			// 
			// tbvSumCreditDrop
			// 
			this.tbvSumCreditDrop.AllowDrop = true;
			this.tbvSumCreditDrop.BackColor = System.Drawing.Color.Ivory;
			this.tbvSumCreditDrop.dValue = 0;
			this.tbvSumCreditDrop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.tbvSumCreditDrop.IsPcnt = false;
			this.tbvSumCreditDrop.Location = new System.Drawing.Point(93, 18);
			this.tbvSumCreditDrop.MaxDecPos = 2;
			this.tbvSumCreditDrop.MaxPos = 8;
			this.tbvSumCreditDrop.Name = "tbvSumCreditDrop";
			this.tbvSumCreditDrop.Negative = System.Drawing.Color.Empty;
			this.tbvSumCreditDrop.nValue = ((long)(0));
			this.tbvSumCreditDrop.Positive = System.Drawing.Color.Empty;
			this.tbvSumCreditDrop.TabIndex = 1;
			this.tbvSumCreditDrop.Text = "0";
			this.tbvSumCreditDrop.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbvSumCreditDrop.TextMode = false;
			this.tbvSumCreditDrop.Zero = System.Drawing.Color.Empty;
			// 
			// label16
			// 
			this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label16.Location = new System.Drawing.Point(14, 18);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(78, 18);
			this.label16.TabIndex = 0;
			this.label16.Text = "Погашено:";
			this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbvSumCreditRest
			// 
			this.tbvSumCreditRest.AllowDrop = true;
			this.tbvSumCreditRest.BackColor = System.Drawing.Color.Ivory;
			this.tbvSumCreditRest.dValue = 0;
			this.tbvSumCreditRest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.tbvSumCreditRest.IsPcnt = false;
			this.tbvSumCreditRest.Location = new System.Drawing.Point(93, 61);
			this.tbvSumCreditRest.MaxDecPos = 2;
			this.tbvSumCreditRest.MaxPos = 8;
			this.tbvSumCreditRest.Name = "tbvSumCreditRest";
			this.tbvSumCreditRest.Negative = System.Drawing.Color.Empty;
			this.tbvSumCreditRest.nValue = ((long)(0));
			this.tbvSumCreditRest.Positive = System.Drawing.Color.Empty;
			this.tbvSumCreditRest.TabIndex = 1;
			this.tbvSumCreditRest.Text = "0";
			this.tbvSumCreditRest.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbvSumCreditRest.TextMode = false;
			this.tbvSumCreditRest.Zero = System.Drawing.Color.Empty;
			// 
			// label17
			// 
			this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label17.Location = new System.Drawing.Point(14, 62);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(78, 18);
			this.label17.TabIndex = 0;
			this.label17.Text = "Остаток:";
			this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbLastDateCreditDrop
			// 
			this.tbLastDateCreditDrop.BackColor = System.Drawing.Color.Ivory;
			this.tbLastDateCreditDrop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.tbLastDateCreditDrop.Location = new System.Drawing.Point(302, 18);
			this.tbLastDateCreditDrop.Name = "tbLastDateCreditDrop";
			this.tbLastDateCreditDrop.ReadOnly = true;
			this.tbLastDateCreditDrop.TabIndex = 2;
			this.tbLastDateCreditDrop.Text = "";
			this.tbLastDateCreditDrop.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label26
			// 
			this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label26.Location = new System.Drawing.Point(204, 18);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(96, 18);
			this.label26.TabIndex = 0;
			this.label26.Text = "Последняя Дата:";
			this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label33
			// 
			this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label33.Location = new System.Drawing.Point(14, 40);
			this.label33.Name = "label33";
			this.label33.Size = new System.Drawing.Size(78, 18);
			this.label33.TabIndex = 0;
			this.label33.Text = "Увеличено:";
			this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbvSumCreditIncrease
			// 
			this.tbvSumCreditIncrease.AllowDrop = true;
			this.tbvSumCreditIncrease.BackColor = System.Drawing.Color.Ivory;
			this.tbvSumCreditIncrease.dValue = 0;
			this.tbvSumCreditIncrease.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.tbvSumCreditIncrease.IsPcnt = false;
			this.tbvSumCreditIncrease.Location = new System.Drawing.Point(93, 39);
			this.tbvSumCreditIncrease.MaxDecPos = 2;
			this.tbvSumCreditIncrease.MaxPos = 8;
			this.tbvSumCreditIncrease.Name = "tbvSumCreditIncrease";
			this.tbvSumCreditIncrease.Negative = System.Drawing.Color.Empty;
			this.tbvSumCreditIncrease.nValue = ((long)(0));
			this.tbvSumCreditIncrease.Positive = System.Drawing.Color.Empty;
			this.tbvSumCreditIncrease.TabIndex = 1;
			this.tbvSumCreditIncrease.Text = "0";
			this.tbvSumCreditIncrease.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbvSumCreditIncrease.TextMode = false;
			this.tbvSumCreditIncrease.Zero = System.Drawing.Color.Empty;
			// 
			// tbLastDateCreditIncrease
			// 
			this.tbLastDateCreditIncrease.BackColor = System.Drawing.Color.Ivory;
			this.tbLastDateCreditIncrease.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.tbLastDateCreditIncrease.Location = new System.Drawing.Point(302, 39);
			this.tbLastDateCreditIncrease.Name = "tbLastDateCreditIncrease";
			this.tbLastDateCreditIncrease.ReadOnly = true;
			this.tbLastDateCreditIncrease.TabIndex = 2;
			this.tbLastDateCreditIncrease.Text = "";
			this.tbLastDateCreditIncrease.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label34
			// 
			this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label34.Location = new System.Drawing.Point(204, 40);
			this.label34.Name = "label34";
			this.label34.Size = new System.Drawing.Size(96, 18);
			this.label34.TabIndex = 0;
			this.label34.Text = "Последняя Дата:";
			this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbvSumRedemption
			// 
			this.tbvSumRedemption.AllowDrop = true;
			this.tbvSumRedemption.BackColor = System.Drawing.Color.Ivory;
			this.tbvSumRedemption.dValue = 0;
			this.tbvSumRedemption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.tbvSumRedemption.IsPcnt = false;
			this.tbvSumRedemption.Location = new System.Drawing.Point(146, 538);
			this.tbvSumRedemption.MaxDecPos = 2;
			this.tbvSumRedemption.MaxPos = 8;
			this.tbvSumRedemption.Name = "tbvSumRedemption";
			this.tbvSumRedemption.Negative = System.Drawing.Color.Empty;
			this.tbvSumRedemption.nValue = ((long)(0));
			this.tbvSumRedemption.Positive = System.Drawing.Color.Empty;
			this.tbvSumRedemption.ReadOnly = true;
			this.tbvSumRedemption.TabIndex = 1;
			this.tbvSumRedemption.Text = "0";
			this.tbvSumRedemption.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbvSumRedemption.TextMode = false;
			this.tbvSumRedemption.Zero = System.Drawing.Color.Empty;
			// 
			// label18
			// 
			this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label18.Location = new System.Drawing.Point(20, 540);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(122, 18);
			this.label18.TabIndex = 0;
			this.label18.Text = "Итого к погашению:";
			this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbvSumIncome
			// 
			this.tbvSumIncome.AllowDrop = true;
			this.tbvSumIncome.dValue = 0;
			this.tbvSumIncome.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.tbvSumIncome.IsPcnt = false;
			this.tbvSumIncome.Location = new System.Drawing.Point(146, 560);
			this.tbvSumIncome.MaxDecPos = 2;
			this.tbvSumIncome.MaxPos = 8;
			this.tbvSumIncome.Name = "tbvSumIncome";
			this.tbvSumIncome.Negative = System.Drawing.Color.Empty;
			this.tbvSumIncome.nValue = ((long)(0));
			this.tbvSumIncome.Positive = System.Drawing.Color.Empty;
			this.tbvSumIncome.TabIndex = 5;
			this.tbvSumIncome.Text = "0";
			this.tbvSumIncome.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbvSumIncome.TextMode = false;
			this.tbvSumIncome.Zero = System.Drawing.Color.Empty;
			this.tbvSumIncome.TextChanged += new System.EventHandler(this.tbvSumIncome_TextChanged);
			// 
			// label19
			// 
			this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label19.Location = new System.Drawing.Point(20, 562);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(122, 18);
			this.label19.TabIndex = 4;
			this.label19.Text = "Вносимая сумма:";
			this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbvSumRest
			// 
			this.tbvSumRest.AllowDrop = true;
			this.tbvSumRest.BackColor = System.Drawing.Color.Ivory;
			this.tbvSumRest.dValue = 0;
			this.tbvSumRest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.tbvSumRest.IsPcnt = false;
			this.tbvSumRest.Location = new System.Drawing.Point(146, 582);
			this.tbvSumRest.MaxDecPos = 2;
			this.tbvSumRest.MaxPos = 8;
			this.tbvSumRest.Name = "tbvSumRest";
			this.tbvSumRest.Negative = System.Drawing.Color.Empty;
			this.tbvSumRest.nValue = ((long)(0));
			this.tbvSumRest.Positive = System.Drawing.Color.Empty;
			this.tbvSumRest.ReadOnly = true;
			this.tbvSumRest.TabIndex = 7;
			this.tbvSumRest.Text = "0";
			this.tbvSumRest.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbvSumRest.TextMode = false;
			this.tbvSumRest.Zero = System.Drawing.Color.Empty;
			// 
			// label20
			// 
			this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label20.Location = new System.Drawing.Point(20, 584);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(122, 18);
			this.label20.TabIndex = 6;
			this.label20.Text = "Разница:";
			this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnExecute
			// 
			this.btnExecute.ForeColor = System.Drawing.Color.Firebrick;
			this.btnExecute.Location = new System.Drawing.Point(339, 526);
			this.btnExecute.Name = "btnExecute";
			this.btnExecute.TabIndex = 8;
			this.btnExecute.Text = "Выполнить";
			this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(339, 578);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 8;
			this.btnCancel.Text = "Закрыть";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = ((string)(configurationAppSettings.GetValue("ConnectionString", typeof(string))));
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "[CreditRedemption]";
			this.sqlSelectCommand1.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CreditID", System.Data.SqlDbType.Int, 4));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RedemptionDate", System.Data.SqlDbType.DateTime, 8));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RedemptionSum", System.Data.SqlDbType.Float, 8));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Mode", System.Data.SqlDbType.Bit, 1));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RedemptionMode", System.Data.SqlDbType.Bit, 1));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OUTCreditStatusID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OUTClientID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OUTIsShortTerm", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OUTDirection", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OUTIsExtended", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OUTCreditSum", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OUTCreditSumCurrency", System.Data.SqlDbType.NVarChar, 3, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OUTCreditSumRedemption", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OUTServiceCharge", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OUTServiceChargeExtra", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OUTCreditStartDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OUTCreditEndDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OUTSumPercentNormalCurrent", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OUTSumPercentPenaltyCurrent", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OUTDropSumPercentNormalCurrent", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OUTDropSumPercentPenaltyCurrent", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OUTDueSumPercentNormalCurrent", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OUTDueSumPercentPenaltyCurrent", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OUTCreditOpLastDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OUTLastDateChargeNormal", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OUTLastDateChargePenalty", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OUTLastDateChargeNormalDrop", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OUTLastDateChargePenaltyDrop", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OUTLastDateCreditDrop", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OUTCreditTypeText", System.Data.SqlDbType.NVarChar, 128, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OUTRoundMode", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OUTPercentSinkMode", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OUTSumForDropPercentNormal", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OUTSumForDropPercentPenalty", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OUTCreditIncreaseSum", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OUTCreditIncreaseLastDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			// 
			// dtpOperationDate
			// 
			this.dtpOperationDate.CustomFormat = "dd-MMM-yy";
			this.dtpOperationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.dtpOperationDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpOperationDate.Location = new System.Drawing.Point(146, 512);
			this.dtpOperationDate.Name = "dtpOperationDate";
			this.dtpOperationDate.Size = new System.Drawing.Size(100, 20);
			this.dtpOperationDate.TabIndex = 2;
			this.dtpOperationDate.ValueChanged += new System.EventHandler(this.dtpOperationDate_ValueChanged);
			// 
			// label21
			// 
			this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label21.Location = new System.Drawing.Point(20, 514);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(122, 18);
			this.label21.TabIndex = 6;
			this.label21.Text = "Дата Операции:";
			this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnRecalc
			// 
			this.btnRecalc.Location = new System.Drawing.Point(339, 494);
			this.btnRecalc.Name = "btnRecalc";
			this.btnRecalc.TabIndex = 8;
			this.btnRecalc.Text = "Рассчитать";
			this.btnRecalc.Click += new System.EventHandler(this.btnRecalc_Click);
			// 
			// lbCurrency01
			// 
			this.lbCurrency01.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.lbCurrency01.Location = new System.Drawing.Point(248, 540);
			this.lbCurrency01.Name = "lbCurrency01";
			this.lbCurrency01.Size = new System.Drawing.Size(30, 18);
			this.lbCurrency01.TabIndex = 0;
			this.lbCurrency01.Text = "?";
			this.lbCurrency01.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbCurrency02
			// 
			this.lbCurrency02.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.lbCurrency02.Location = new System.Drawing.Point(248, 562);
			this.lbCurrency02.Name = "lbCurrency02";
			this.lbCurrency02.Size = new System.Drawing.Size(30, 18);
			this.lbCurrency02.TabIndex = 0;
			this.lbCurrency02.Text = "?";
			this.lbCurrency02.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbCurrency03
			// 
			this.lbCurrency03.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.lbCurrency03.Location = new System.Drawing.Point(248, 584);
			this.lbCurrency03.Name = "lbCurrency03";
			this.lbCurrency03.Size = new System.Drawing.Size(30, 18);
			this.lbCurrency03.TabIndex = 0;
			this.lbCurrency03.Text = "?";
			this.lbCurrency03.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbLastCreditDate
			// 
			this.tbLastCreditDate.BackColor = System.Drawing.Color.Ivory;
			this.tbLastCreditDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.tbLastCreditDate.Location = new System.Drawing.Point(146, 486);
			this.tbLastCreditDate.Name = "tbLastCreditDate";
			this.tbLastCreditDate.ReadOnly = true;
			this.tbLastCreditDate.TabIndex = 2;
			this.tbLastCreditDate.Text = "";
			this.tbLastCreditDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label30
			// 
			this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label30.Location = new System.Drawing.Point(20, 486);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(122, 20);
			this.label30.TabIndex = 0;
			this.label30.Text = "Последняя Операция:";
			this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dgPointsInfo
			// 
			this.dgPointsInfo.BackgroundColor = System.Drawing.Color.LightGray;
			this.dgPointsInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dgPointsInfo.CaptionText = "Сводка по периодам";
			this.dgPointsInfo.DataMember = "Table";
			this.dgPointsInfo.DataSource = this.dsCreditsPointsInfoList2;
			this.dgPointsInfo.FlatMode = true;
			this.dgPointsInfo.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgPointsInfo.Location = new System.Drawing.Point(420, 8);
			this.dgPointsInfo.Name = "dgPointsInfo";
			this.dgPointsInfo.ReadOnly = true;
			this.dgPointsInfo.Size = new System.Drawing.Size(520, 524);
			this.dgPointsInfo.TabIndex = 9;
			this.dgPointsInfo.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																									 this.dataGridTableStyle1});
			// 
			// dsCreditsPointsInfoList2
			// 
			this.dsCreditsPointsInfoList2.DataSetName = "dsCreditsPointsInfoList";
			this.dsCreditsPointsInfoList2.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.DataGrid = this.dgPointsInfo;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.ColumnPID,
																												  this.ColumnPointDate,
																												  this.ColumnPointSum,
																												  this.ColumnPointPercentSum,
																												  this.ColumnPointSumSink,
																												  this.ColumnPointSumSinkLastDate,
																												  this.ColumnPointPercentNormalDebt,
																												  this.ColumnPointPercentNormalSink,
																												  this.ColumnPointPercentNormalDue,
																												  this.ColumnPointPercentNormalDebtLastDate,
																												  this.ColumnPointPercentPenaltyDebt,
																												  this.ColumnPointPercentPenaltySink,
																												  this.ColumnPointPercentPenaltyDue,
																												  this.ColumnPointPercentPenaltyDebtLastDate});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "Table";
			// 
			// ColumnPID
			// 
			this.ColumnPID.Format = "";
			this.ColumnPID.FormatInfo = null;
			this.ColumnPID.HeaderText = "ID Точки";
			this.ColumnPID.MappingName = "PointID";
			this.ColumnPID.Width = 60;
			// 
			// ColumnPointDate
			// 
			this.ColumnPointDate.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.ColumnPointDate.Format = "dd-MMM-yy";
			this.ColumnPointDate.FormatInfo = null;
			this.ColumnPointDate.HeaderText = "Дата Точки";
			this.ColumnPointDate.MappingName = "PointDate";
			this.ColumnPointDate.NullText = "?";
			this.ColumnPointDate.Width = 75;
			// 
			// ColumnPointSum
			// 
			this.ColumnPointSum.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.ColumnPointSum.Format = "#,##0.00";
			this.ColumnPointSum.FormatInfo = null;
			this.ColumnPointSum.HeaderText = "Сумма";
			this.ColumnPointSum.MappingName = "PointSum";
			this.ColumnPointSum.NullText = "-";
			this.ColumnPointSum.Width = 75;
			// 
			// ColumnPointPercentSum
			// 
			this.ColumnPointPercentSum.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.ColumnPointPercentSum.Format = "#,##0.00";
			this.ColumnPointPercentSum.FormatInfo = null;
			this.ColumnPointPercentSum.HeaderText = "План %%";
			this.ColumnPointPercentSum.MappingName = "PointPercent";
			this.ColumnPointPercentSum.NullText = "-";
			this.ColumnPointPercentSum.Width = 75;
			// 
			// ColumnPointSumSink
			// 
			this.ColumnPointSumSink.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.ColumnPointSumSink.Format = "#,##0.00";
			this.ColumnPointSumSink.FormatInfo = null;
			this.ColumnPointSumSink.HeaderText = "Погашено";
			this.ColumnPointSumSink.MappingName = "PointSumSink";
			this.ColumnPointSumSink.NullText = "-";
			this.ColumnPointSumSink.Width = 75;
			// 
			// ColumnPointSumSinkLastDate
			// 
			this.ColumnPointSumSinkLastDate.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.ColumnPointSumSinkLastDate.Format = "dd-MMM-yy";
			this.ColumnPointSumSinkLastDate.FormatInfo = null;
			this.ColumnPointSumSinkLastDate.HeaderText = "Дата Погашения";
			this.ColumnPointSumSinkLastDate.MappingName = "PointSumSinkLastDate";
			this.ColumnPointSumSinkLastDate.NullText = "-";
			this.ColumnPointSumSinkLastDate.Width = 75;
			// 
			// ColumnPointPercentNormalDebt
			// 
			this.ColumnPointPercentNormalDebt.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.ColumnPointPercentNormalDebt.Format = "#,##0.00;;\"-\"";
			this.ColumnPointPercentNormalDebt.FormatInfo = null;
			this.ColumnPointPercentNormalDebt.HeaderText = "НН%%";
			this.ColumnPointPercentNormalDebt.MappingName = "PointPercentNormalDebt";
			this.ColumnPointPercentNormalDebt.NullText = "";
			this.ColumnPointPercentNormalDebt.Width = 75;
			// 
			// ColumnPointPercentNormalSink
			// 
			this.ColumnPointPercentNormalSink.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.ColumnPointPercentNormalSink.Format = "#,##0.00;;\"-\"";
			this.ColumnPointPercentNormalSink.FormatInfo = null;
			this.ColumnPointPercentNormalSink.HeaderText = "НП%%";
			this.ColumnPointPercentNormalSink.MappingName = "PointPercentNormalSink";
			this.ColumnPointPercentNormalSink.NullText = "";
			this.ColumnPointPercentNormalSink.Width = 75;
			// 
			// ColumnPointPercentNormalDue
			// 
			this.ColumnPointPercentNormalDue.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.ColumnPointPercentNormalDue.Format = "#,##0.00;;\"-\"";
			this.ColumnPointPercentNormalDue.FormatInfo = null;
			this.ColumnPointPercentNormalDue.HeaderText = "НТ%%";
			this.ColumnPointPercentNormalDue.MappingName = "PointPercentNormalDue";
			this.ColumnPointPercentNormalDue.NullText = "";
			this.ColumnPointPercentNormalDue.Width = 75;
			// 
			// ColumnPointPercentNormalDebtLastDate
			// 
			this.ColumnPointPercentNormalDebtLastDate.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.ColumnPointPercentNormalDebtLastDate.Format = "dd-MMM-yy";
			this.ColumnPointPercentNormalDebtLastDate.FormatInfo = null;
			this.ColumnPointPercentNormalDebtLastDate.HeaderText = "Дата Н%%";
			this.ColumnPointPercentNormalDebtLastDate.MappingName = "PointPercentNormalDebtLastDate";
			this.ColumnPointPercentNormalDebtLastDate.NullText = "-";
			this.ColumnPointPercentNormalDebtLastDate.Width = 75;
			// 
			// ColumnPointPercentPenaltyDebt
			// 
			this.ColumnPointPercentPenaltyDebt.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.ColumnPointPercentPenaltyDebt.Format = "#,##0.00;;\"-\"";
			this.ColumnPointPercentPenaltyDebt.FormatInfo = null;
			this.ColumnPointPercentPenaltyDebt.HeaderText = "ШН%%";
			this.ColumnPointPercentPenaltyDebt.MappingName = "PointPercentPenaltyDebt";
			this.ColumnPointPercentPenaltyDebt.NullText = "";
			this.ColumnPointPercentPenaltyDebt.Width = 75;
			// 
			// ColumnPointPercentPenaltySink
			// 
			this.ColumnPointPercentPenaltySink.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.ColumnPointPercentPenaltySink.Format = "#,##0.00;;\"-\"";
			this.ColumnPointPercentPenaltySink.FormatInfo = null;
			this.ColumnPointPercentPenaltySink.HeaderText = "ШП%%";
			this.ColumnPointPercentPenaltySink.MappingName = "PointPercentPenaltySink";
			this.ColumnPointPercentPenaltySink.NullText = "";
			this.ColumnPointPercentPenaltySink.Width = 75;
			// 
			// ColumnPointPercentPenaltyDue
			// 
			this.ColumnPointPercentPenaltyDue.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.ColumnPointPercentPenaltyDue.Format = "#,##0.00;;\"-\"";
			this.ColumnPointPercentPenaltyDue.FormatInfo = null;
			this.ColumnPointPercentPenaltyDue.HeaderText = "ШТ%%";
			this.ColumnPointPercentPenaltyDue.MappingName = "PointPercentPenaltyDue";
			this.ColumnPointPercentPenaltyDue.NullText = "";
			this.ColumnPointPercentPenaltyDue.Width = 75;
			// 
			// ColumnPointPercentPenaltyDebtLastDate
			// 
			this.ColumnPointPercentPenaltyDebtLastDate.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.ColumnPointPercentPenaltyDebtLastDate.Format = "dd-MMM-yy";
			this.ColumnPointPercentPenaltyDebtLastDate.FormatInfo = null;
			this.ColumnPointPercentPenaltyDebtLastDate.HeaderText = "Дата Ш%%";
			this.ColumnPointPercentPenaltyDebtLastDate.MappingName = "PointPercentPenaltyDebtLastDate";
			this.ColumnPointPercentPenaltyDebtLastDate.NullText = "-";
			this.ColumnPointPercentPenaltyDebtLastDate.Width = 75;
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "[CreditRedemptionPointsList]";
			this.sqlSelectCommand2.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectCommand2.Connection = this.sqlConnection2;
			this.sqlSelectCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CreditID", System.Data.SqlDbType.Int, 4));
			// 
			// sqlConnection2
			// 
			this.sqlConnection2.ConnectionString = ((string)(configurationAppSettings.GetValue("ConnectionString", typeof(string))));
			// 
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			// 
			// tbCreditID
			// 
			this.tbCreditID.BackColor = System.Drawing.Color.Ivory;
			this.tbCreditID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.tbCreditID.Location = new System.Drawing.Point(110, 19);
			this.tbCreditID.Name = "tbCreditID";
			this.tbCreditID.ReadOnly = true;
			this.tbCreditID.Size = new System.Drawing.Size(56, 20);
			this.tbCreditID.TabIndex = 3;
			this.tbCreditID.Text = "";
			// 
			// label36
			// 
			this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label36.Location = new System.Drawing.Point(14, 20);
			this.label36.Name = "label36";
			this.label36.Size = new System.Drawing.Size(93, 18);
			this.label36.TabIndex = 0;
			this.label36.Text = "ID Кредита:";
			this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label36.UseMnemonic = false;
			// 
			// tbClientName
			// 
			this.tbClientName.BackColor = System.Drawing.Color.Ivory;
			this.tbClientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.tbClientName.Location = new System.Drawing.Point(218, 19);
			this.tbClientName.Name = "tbClientName";
			this.tbClientName.ReadOnly = true;
			this.tbClientName.Size = new System.Drawing.Size(184, 20);
			this.tbClientName.TabIndex = 3;
			this.tbClientName.Text = "";
			// 
			// label37
			// 
			this.label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label37.Location = new System.Drawing.Point(170, 20);
			this.label37.Name = "label37";
			this.label37.Size = new System.Drawing.Size(46, 18);
			this.label37.TabIndex = 0;
			this.label37.Text = "Клиент:";
			this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label37.UseMnemonic = false;
			// 
			// CreditsRedemption
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(944, 607);
			this.Controls.Add(this.dgPointsInfo);
			this.Controls.Add(this.btnExecute);
			this.Controls.Add(this.tbvSumRest);
			this.Controls.Add(this.tbvSumIncome);
			this.Controls.Add(this.tbvSumRedemption);
			this.Controls.Add(this.tbLastCreditDate);
			this.Controls.Add(this.label20);
			this.Controls.Add(this.label19);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label18);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.dtpOperationDate);
			this.Controls.Add(this.label21);
			this.Controls.Add(this.btnRecalc);
			this.Controls.Add(this.lbCurrency01);
			this.Controls.Add(this.lbCurrency02);
			this.Controls.Add(this.lbCurrency03);
			this.Controls.Add(this.label30);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CreditsRedemption";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Погашение кредита";
			this.Load += new System.EventHandler(this.CreditsRedemption_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgPointsInfo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsCreditsPointsInfoList2)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void btnExecute_Click(object sender, System.EventArgs e)
		{
			if ( !this.m_DataIsActual) 
			{
				MessageBox.Show("Действие отменено: Данные не актуальны. Для перерасчёта данных о кредите нажмите 'Рассчитать'", "BP2",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			if ( this.tbvSumIncome.dValue <=0) 
			{
				MessageBox.Show("Действие отменено: Не задана вносимая сумма.", "BP2",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			try 
			{
				Cursor.Current = Cursors.WaitCursor;

				this.sqlDataAdapter1.SelectCommand.Parameters["@CreditID"].Value		=this.m_CreditID;
				this.sqlDataAdapter1.SelectCommand.Parameters["@RedemptionDate"].Value	=this.dtpOperationDate.Value;  //System.DateTime.Today;
				this.sqlDataAdapter1.SelectCommand.Parameters["@RedemptionSum"].Value	=Math.Round( this.tbvSumIncome.dValue, 2);
				this.sqlDataAdapter1.SelectCommand.Parameters["@Mode"].Value			=1;
				this.sqlDataAdapter1.SelectCommand.Parameters["@RedemptionMode"].Value	=1;
				
				if ( this.sqlDataAdapter1.SelectCommand.Connection.State ==System.Data.ConnectionState.Closed)
					this.sqlDataAdapter1.SelectCommand.Connection.Open();
				
				//this.sqlDataAdapter1.Fill( this.dsCreditsPointsInfoList1);
				this.sqlDataAdapter1.SelectCommand.ExecuteNonQuery();
				
				this.tbvSumIncome.dValue =0;
				this.tbvSumIncome_TextChanged(null, null);
			}
			catch(Exception ex)
			{
				MessageBox.Show( "Ошибка чтения данных о кредите: " +ex.Message, "BP2", MessageBoxButtons.OK, MessageBoxIcon.Error);  
			}				
			finally
			{
				if ( this.sqlDataAdapter1.SelectCommand.Connection.State ==System.Data.ConnectionState.Open)
					this.sqlDataAdapter1.SelectCommand.Connection.Close();
				Cursor.Current = Cursors.Default;
			}
		}
		
		private void SetClientSize( bool bMax)
		{
			if ( bMax)
				this.ClientSize =new Size(this.dgPointsInfo.Location.X +this.groupBox1.Location.X +this.dgPointsInfo.Width , this.ClientSize.Height);
			else
				this.ClientSize =new Size(this.groupBox1.Location.X +this.groupBox1.Location.X +this.groupBox1.Width, this.ClientSize.Height);
		}

		private void GetCreditInfo()
		{
			string strDateFormat ="dd-MMM-yy";

			try 
			{
				Cursor.Current = Cursors.WaitCursor;

				this.sqlDataAdapter1.SelectCommand.Parameters["@CreditID"].Value		=this.m_CreditID;
				this.sqlDataAdapter1.SelectCommand.Parameters["@RedemptionDate"].Value	=this.dtpOperationDate.Value;  //System.DateTime.Today;
				this.sqlDataAdapter1.SelectCommand.Parameters["@RedemptionSum"].Value	=0;
				this.sqlDataAdapter1.SelectCommand.Parameters["@Mode"].Value			=0;
				this.sqlDataAdapter1.SelectCommand.Parameters["@RedemptionMode"].Value	=0;
				
				if ( this.sqlDataAdapter1.SelectCommand.Connection.State ==System.Data.ConnectionState.Closed)
					this.sqlDataAdapter1.SelectCommand.Connection.Open();
				
				this.dsCreditsPointsInfoList2.Tables[0].Clear();
				this.sqlDataAdapter1.Fill( this.dsCreditsPointsInfoList2);
				//this.sqlDataAdapter1.SelectCommand.ExecuteNonQuery();
  
				if ((bool)this.sqlDataAdapter1.SelectCommand.Parameters["@OUTIsShortTerm"].Value) 
				{
					this.tbCreditType.Text =App.CreditsTypes.ShortTerm; //"Краткосрочный";
					this.SetClientSize( false);   
				}
				else 
				{
					if ((bool)this.sqlDataAdapter1.SelectCommand.Parameters["@OUTIsExtended"].Value)
						this.tbCreditType.Text =App.CreditsTypes.LongTermExtended; //"Долгосрочный с планом погашения";
					else
						this.tbCreditType.Text =App.CreditsTypes.LongTerm; //"Долгосрочный";
					this.SetClientSize( true);
				}
				this.tbvCreditChargeNormal.dValue	=(double)this.sqlDataAdapter1.SelectCommand.Parameters["@OUTServiceCharge"].Value;
				this.tbvCreditChargePenalty.dValue	=(double)this.sqlDataAdapter1.SelectCommand.Parameters["@OUTServiceChargeExtra"].Value;
				
				this.lbCurrency00.Text =
					this.lbCurrency01.Text =
					this.lbCurrency02.Text =
					this.lbCurrency03.Text =(string)this.sqlDataAdapter1.SelectCommand.Parameters["@OUTCreditSumCurrency"].Value;
				
				if (this.sqlDataAdapter1.SelectCommand.Parameters["@OUTCreditStartDate"].Value ==System.Convert.DBNull)
					this.tbCreditDateStart.Text	="?";
				else
					this.tbCreditDateStart.Text	=((System.DateTime)this.sqlDataAdapter1.SelectCommand.Parameters["@OUTCreditStartDate"].Value).ToString(strDateFormat); //;
				
				if (this.sqlDataAdapter1.SelectCommand.Parameters["@OUTCreditEndDate"].Value ==System.Convert.DBNull)
					this.tbCreditDateEnd.Text	="?";
				else
					this.tbCreditDateEnd.Text	=((System.DateTime)this.sqlDataAdapter1.SelectCommand.Parameters["@OUTCreditEndDate"].Value).ToString(strDateFormat); //; 
				
				if ((this.sqlDataAdapter1.SelectCommand.Parameters["@OUTCreditStartDate"].Value !=System.Convert.DBNull)
					&& (this.sqlDataAdapter1.SelectCommand.Parameters["@OUTCreditEndDate"].Value !=System.Convert.DBNull)) 
				{
					System.DateTime dtStart =(System.DateTime)this.sqlDataAdapter1.SelectCommand.Parameters["@OUTCreditStartDate"].Value;
					System.DateTime dtEnd	=(System.DateTime)this.sqlDataAdapter1.SelectCommand.Parameters["@OUTCreditEndDate"].Value;
					
					TimeSpan tsDays = dtEnd.Subtract(dtStart.Date);
					this.tbvCreditLength.nValue = tsDays.Days;
				}

				if ((bool)this.sqlDataAdapter1.SelectCommand.Parameters["@OUTRoundMode"].Value)
					this.tbRoundMode.Text =App.CreditsSettings.CreditPercentageRoundModeByPeriod;	//"за период";
				else
					this.tbRoundMode.Text =App.CreditsSettings.CreditPercentageRoundModeByDay;		//"за день";

				if ((bool)this.sqlDataAdapter1.SelectCommand.Parameters["@OUTPercentSinkMode"].Value) 
				{
					this.tbNormalSinkMode.Text =App.CreditsSettings.CreditPercentageSinkModeByPeriod;		//"при гашении";
					this.tbPenaltySinkMode.Text =App.CreditsSettings.CreditPercentageSinkModeByPeriod;		//"при гашении";
				}
				else
				{
					this.tbNormalSinkMode.Text =App.CreditsSettings.CreditPercentageSinkModeByOperation;	//"за отчётный период"
					this.tbPenaltySinkMode.Text =App.CreditsSettings.CreditPercentageSinkModeByOperation;	//"за отчётный период"
				}

				if (this.sqlDataAdapter1.SelectCommand.Parameters["@OUTCreditOpLastDate"].Value ==System.Convert.DBNull)
					this.tbLastCreditDate.Text	="?";
				else
					this.tbLastCreditDate.Text	=((System.DateTime)this.sqlDataAdapter1.SelectCommand.Parameters["@OUTCreditOpLastDate"].Value).ToString(strDateFormat); //; 

				this.tbvCreditSum.dValue				=(double)this.sqlDataAdapter1.SelectCommand.Parameters["@OUTCreditSum"].Value;
				this.tbvSumCreditDrop.dValue			=(double)this.sqlDataAdapter1.SelectCommand.Parameters["@OUTCreditSumRedemption"].Value;
				this.tbvSumCreditIncrease.dValue		=(double)this.sqlDataAdapter1.SelectCommand.Parameters["@OUTCreditIncreaseSum"].Value;
				this.tbvSumCreditRest.dValue			=this.tbvCreditSum.dValue -this.tbvSumCreditDrop.dValue +this.tbvSumCreditIncrease.dValue;
				//
				// Проценты нормальные
				this.tbvSumPercentNormal.dValue			=(double)this.sqlDataAdapter1.SelectCommand.Parameters["@OUTSumPercentNormalCurrent"].Value;
				this.tbvSumPercentNormalCurrent.dValue	=(double)this.sqlDataAdapter1.SelectCommand.Parameters["@OUTDueSumPercentNormalCurrent"].Value;
				this.tbvSumPercentNormalDrop.dValue		=(double)this.sqlDataAdapter1.SelectCommand.Parameters["@OUTDropSumPercentNormalCurrent"].Value;
				//this.tbvSumPercentNormalTotal.dValue	=this.tbvSumPercentNormal.dValue
				//	+this.tbvSumPercentNormalCurrent.dValue
				//	-this.tbvSumPercentNormalDrop.dValue; 
				this.tbvSumPercentNormalTotal.dValue	=(double)this.sqlDataAdapter1.SelectCommand.Parameters["@OUTSumForDropPercentNormal"].Value;
				
				// Проценты штрафные
				this.tbvSumPercentPenalty.dValue		=(double)this.sqlDataAdapter1.SelectCommand.Parameters["@OUTSumPercentPenaltyCurrent"].Value;
				this.tbvSumPercentPenaltyCurrent.dValue	=(double)this.sqlDataAdapter1.SelectCommand.Parameters["@OUTDueSumPercentPenaltyCurrent"].Value;
				this.tbvSumPercentPenaltyDrop.dValue	=(double)this.sqlDataAdapter1.SelectCommand.Parameters["@OUTDropSumPercentPenaltyCurrent"].Value;
				//this.tbvSumPercentPenaltyTotal.dValue	=this.tbvSumPercentPenalty.dValue
				//	+this.tbvSumPercentPenaltyCurrent.dValue
				//	-this.tbvSumPercentPenaltyDrop.dValue;
				this.tbvSumPercentPenaltyTotal.dValue	=(double)this.sqlDataAdapter1.SelectCommand.Parameters["@OUTSumForDropPercentPenalty"].Value;
					
				//
				this.tbvSumRedemption.dValue	=this.tbvSumCreditRest.dValue
					+this.tbvSumPercentNormalTotal.dValue
					+this.tbvSumPercentPenaltyTotal.dValue;

				this.tbvSumRest.dValue	=this.tbvSumRedemption.dValue -this.tbvSumIncome.dValue;

				// Последняя дата погашения тела кредита
				if (this.sqlDataAdapter1.SelectCommand.Parameters["@OUTLastDateCreditDrop"].Value == System.Convert.DBNull)
					this.tbLastDateCreditDrop.Text ="<НЕ ПОГАШАЛОСЬ>";
				else
					this.tbLastDateCreditDrop.Text 
						=((System.DateTime)this.sqlDataAdapter1.SelectCommand.Parameters["@OUTLastDateCreditDrop"].Value).ToString(strDateFormat); //ToShortDateString();
				// Последняя дата увеличения кредита					
				if (this.sqlDataAdapter1.SelectCommand.Parameters["@OUTCreditIncreaseLastDate"].Value == System.Convert.DBNull)
					this.tbLastDateCreditIncrease.Text ="<НЕ УВЕЛИЧИВАЛОСЬ>";
				else
					this.tbLastDateCreditIncrease.Text 
						=((System.DateTime)this.sqlDataAdapter1.SelectCommand.Parameters["@OUTCreditIncreaseLastDate"].Value).ToString(strDateFormat); //ToShortDateString();
				// Данные о нормальных %%
				if (this.sqlDataAdapter1.SelectCommand.Parameters["@OUTLastDateChargeNormal"].Value == System.Convert.DBNull)
					this.tbLastDatePercentNormal.Text ="<НЕ НАЧИСЛЯЛИСЬ>";
				else
					this.tbLastDatePercentNormal.Text 
						=((System.DateTime)this.sqlDataAdapter1.SelectCommand.Parameters["@OUTLastDateChargeNormal"].Value).ToString(strDateFormat); //ToShortDateString();

				if (this.sqlDataAdapter1.SelectCommand.Parameters["@OUTLastDateChargeNormalDrop"].Value == System.Convert.DBNull)
					this.tbLastDatePercentNormalDrop.Text ="<НЕ ПОГАШАЛИСЬ>";
				else
					this.tbLastDatePercentNormalDrop.Text 
						=((System.DateTime)this.sqlDataAdapter1.SelectCommand.Parameters["@OUTLastDateChargeNormalDrop"].Value).ToString(strDateFormat); //ToShortDateString();
				
				// Данные о штрафных %%
				if (this.sqlDataAdapter1.SelectCommand.Parameters["@OUTLastDateChargePenalty"].Value == System.Convert.DBNull)
					this.tbLastDatePercentPenalty.Text ="<НЕ НАЧИСЛЯЛИСЬ>";
				else
					this.tbLastDatePercentPenalty.Text 
						=((System.DateTime)this.sqlDataAdapter1.SelectCommand.Parameters["@OUTLastDateChargePenalty"].Value).ToString(strDateFormat); //ToShortDateString();

				if (this.sqlDataAdapter1.SelectCommand.Parameters["@OUTLastDateChargePenaltyDrop"].Value == System.Convert.DBNull)
					this.tbLastDatePercentPenaltyDrop.Text ="<НЕ ПОГАШАЛИСЬ>";
				else
					this.tbLastDatePercentPenaltyDrop.Text 
						=((System.DateTime)this.sqlDataAdapter1.SelectCommand.Parameters["@OUTLastDateChargePenaltyDrop"].Value).ToString(strDateFormat); //ToShortDateString();
				
				this.m_DataIsActual =true;

				//this.sqlDataAdapter2.SelectCommand.Parameters["@CreditID"].Value =this.m_CreditID;
				//this.sqlDataAdapter2.Fill( this.dsCreditsPointsInfoList1);  
			}
			catch(Exception ex)
			{
				MessageBox.Show( "Ошибка чтения данных о кредите: " +ex.Message, "BP2", MessageBoxButtons.OK, MessageBoxIcon.Error);  
			}				
			finally
			{
				if ( this.sqlDataAdapter1.SelectCommand.Connection.State ==System.Data.ConnectionState.Open)
					this.sqlDataAdapter1.SelectCommand.Connection.Close();
				Cursor.Current = Cursors.Default;
			}
		}

		private void tbvSumIncome_TextChanged(object sender, System.EventArgs e)
		{
			this.tbvSumRest.dValue =this.tbvSumRedemption.dValue -this.tbvSumIncome.dValue; 
		}

		private void dtpOperationDate_ValueChanged(object sender, System.EventArgs e)
		{
			this.m_DataIsActual =false;

			this.groupBox2.Enabled =
			this.groupBox3.Enabled =false; 
		}

		private void btnRecalc_Click(object sender, System.EventArgs e)
		{
			GetCreditInfo();
			this.groupBox2.Enabled =
			this.groupBox3.Enabled =true; 

		}

		private void CreditsRedemption_Load(object sender, System.EventArgs e)
		{
			//
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		public string ClientName 
		{
			set
			{
				this.tbClientName.Text =value;
			}
		}

		public int CreditID 
		{
			set 
			{ 
				this.m_CreditID =value;
				this.tbCreditID.Text =this.m_CreditID.ToString();
				GetCreditInfo();
			}
			get 
			{ 
				return this.m_CreditID; 
			} 
		}
	}
}
