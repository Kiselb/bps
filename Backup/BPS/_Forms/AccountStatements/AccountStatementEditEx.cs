using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace BPS._Forms.AccountStatements
{
	/// <summary>
	/// Summary description for AccountStatementEditEx.
	/// </summary>
	public class AccountStatementEditEx : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.Panel pnlMainLeft;
		private System.Windows.Forms.Panel pnlMainRight;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Splitter splitter2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.TextBox textBox7;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Splitter splitter3;
		private System.Windows.Forms.Panel pnlMainCenter;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.TextBox textBox8;
		private System.Windows.Forms.TextBox textBox9;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.TextBox textBox10;
		private System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.TextBox textBox11;
		private System.Windows.Forms.TextBox textBox12;
		private System.Windows.Forms.TextBox textBox13;
		private System.Windows.Forms.ComboBox comboBox3;
		private System.Windows.Forms.TextBox textBox14;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.TextBox textBox15;
		private System.Windows.Forms.TextBox textBox16;
		private System.Windows.Forms.TextBox textBox17;
		private System.Windows.Forms.TextBox textBox18;
		private System.Windows.Forms.TextBox textBox19;
		private System.Windows.Forms.ComboBox comboBox4;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.DataGrid dataGrid2;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.DataGrid dataGrid3;
		private System.Windows.Forms.Button button5;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AccountStatementEditEx()
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
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.pnlMainLeft = new System.Windows.Forms.Panel();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.pnlMainRight = new System.Windows.Forms.Panel();
			this.splitter3 = new System.Windows.Forms.Splitter();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.splitter2 = new System.Windows.Forms.Splitter();
			this.pnlMainCenter = new System.Windows.Forms.Panel();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.panel3 = new System.Windows.Forms.Panel();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.textBox9 = new System.Windows.Forms.TextBox();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.textBox10 = new System.Windows.Forms.TextBox();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.textBox11 = new System.Windows.Forms.TextBox();
			this.textBox12 = new System.Windows.Forms.TextBox();
			this.textBox13 = new System.Windows.Forms.TextBox();
			this.comboBox3 = new System.Windows.Forms.ComboBox();
			this.textBox14 = new System.Windows.Forms.TextBox();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.textBox15 = new System.Windows.Forms.TextBox();
			this.textBox16 = new System.Windows.Forms.TextBox();
			this.textBox17 = new System.Windows.Forms.TextBox();
			this.textBox18 = new System.Windows.Forms.TextBox();
			this.textBox19 = new System.Windows.Forms.TextBox();
			this.comboBox4 = new System.Windows.Forms.ComboBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.dataGrid2 = new System.Windows.Forms.DataGrid();
			this.button4 = new System.Windows.Forms.Button();
			this.dataGrid3 = new System.Windows.Forms.DataGrid();
			this.button5 = new System.Windows.Forms.Button();
			this.pnlMainLeft.SuspendLayout();
			this.pnlMainRight.SuspendLayout();
			this.panel1.SuspendLayout();
			this.pnlMainCenter.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).BeginInit();
			this.SuspendLayout();
			// 
			// toolBar1
			// 
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.Location = new System.Drawing.Point(0, 0);
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(846, 42);
			this.toolBar1.TabIndex = 0;
			// 
			// pnlMainLeft
			// 
			this.pnlMainLeft.BackColor = System.Drawing.SystemColors.Control;
			this.pnlMainLeft.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlMainLeft.Controls.Add(this.textBox5);
			this.pnlMainLeft.Controls.Add(this.textBox2);
			this.pnlMainLeft.Controls.Add(this.textBox1);
			this.pnlMainLeft.Controls.Add(this.textBox3);
			this.pnlMainLeft.Controls.Add(this.textBox4);
			this.pnlMainLeft.Controls.Add(this.textBox6);
			this.pnlMainLeft.Controls.Add(this.textBox7);
			this.pnlMainLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.pnlMainLeft.Location = new System.Drawing.Point(0, 42);
			this.pnlMainLeft.Name = "pnlMainLeft";
			this.pnlMainLeft.Size = new System.Drawing.Size(188, 531);
			this.pnlMainLeft.TabIndex = 1;
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(88, 104);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(64, 20);
			this.textBox5.TabIndex = 2;
			this.textBox5.Text = "textBox5";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(8, 64);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(152, 20);
			this.textBox2.TabIndex = 1;
			this.textBox2.Text = "textBox2";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(8, 344);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(152, 136);
			this.textBox1.TabIndex = 0;
			this.textBox1.Text = "textBox1";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(8, 40);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(152, 20);
			this.textBox3.TabIndex = 1;
			this.textBox3.Text = "textBox2";
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(8, 16);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(152, 20);
			this.textBox4.TabIndex = 1;
			this.textBox4.Text = "textBox2";
			// 
			// textBox6
			// 
			this.textBox6.Location = new System.Drawing.Point(88, 128);
			this.textBox6.Name = "textBox6";
			this.textBox6.Size = new System.Drawing.Size(64, 20);
			this.textBox6.TabIndex = 2;
			this.textBox6.Text = "textBox5";
			// 
			// textBox7
			// 
			this.textBox7.Location = new System.Drawing.Point(88, 152);
			this.textBox7.Name = "textBox7";
			this.textBox7.Size = new System.Drawing.Size(64, 20);
			this.textBox7.TabIndex = 2;
			this.textBox7.Text = "textBox5";
			// 
			// pnlMainRight
			// 
			this.pnlMainRight.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlMainRight.Controls.Add(this.button5);
			this.pnlMainRight.Controls.Add(this.dataGrid3);
			this.pnlMainRight.Controls.Add(this.splitter3);
			this.pnlMainRight.Controls.Add(this.panel2);
			this.pnlMainRight.Controls.Add(this.panel1);
			this.pnlMainRight.Dock = System.Windows.Forms.DockStyle.Right;
			this.pnlMainRight.Location = new System.Drawing.Point(560, 42);
			this.pnlMainRight.Name = "pnlMainRight";
			this.pnlMainRight.Size = new System.Drawing.Size(286, 531);
			this.pnlMainRight.TabIndex = 2;
			// 
			// splitter3
			// 
			this.splitter3.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter3.Location = new System.Drawing.Point(0, 262);
			this.splitter3.Name = "splitter3";
			this.splitter3.Size = new System.Drawing.Size(282, 5);
			this.splitter3.TabIndex = 2;
			this.splitter3.TabStop = false;
			// 
			// panel2
			// 
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 514);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(282, 13);
			this.panel2.TabIndex = 1;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.button4);
			this.panel1.Controls.Add(this.dataGrid2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(282, 262);
			this.panel1.TabIndex = 0;
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(188, 42);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(5, 531);
			this.splitter1.TabIndex = 3;
			this.splitter1.TabStop = false;
			// 
			// splitter2
			// 
			this.splitter2.Dock = System.Windows.Forms.DockStyle.Right;
			this.splitter2.Location = new System.Drawing.Point(555, 42);
			this.splitter2.Name = "splitter2";
			this.splitter2.Size = new System.Drawing.Size(5, 531);
			this.splitter2.TabIndex = 4;
			this.splitter2.TabStop = false;
			// 
			// pnlMainCenter
			// 
			this.pnlMainCenter.Controls.Add(this.button1);
			this.pnlMainCenter.Controls.Add(this.comboBox4);
			this.pnlMainCenter.Controls.Add(this.textBox18);
			this.pnlMainCenter.Controls.Add(this.textBox17);
			this.pnlMainCenter.Controls.Add(this.textBox16);
			this.pnlMainCenter.Controls.Add(this.textBox15);
			this.pnlMainCenter.Controls.Add(this.dateTimePicker1);
			this.pnlMainCenter.Controls.Add(this.textBox14);
			this.pnlMainCenter.Controls.Add(this.comboBox3);
			this.pnlMainCenter.Controls.Add(this.panel3);
			this.pnlMainCenter.Controls.Add(this.dataGrid1);
			this.pnlMainCenter.Controls.Add(this.textBox19);
			this.pnlMainCenter.Controls.Add(this.button2);
			this.pnlMainCenter.Controls.Add(this.button3);
			this.pnlMainCenter.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlMainCenter.Location = new System.Drawing.Point(193, 42);
			this.pnlMainCenter.Name = "pnlMainCenter";
			this.pnlMainCenter.Size = new System.Drawing.Size(362, 531);
			this.pnlMainCenter.TabIndex = 5;
			// 
			// dataGrid1
			// 
			this.dataGrid1.DataMember = "";
			this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Top;
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(0, 0);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(362, 202);
			this.dataGrid1.TabIndex = 0;
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.SystemColors.Window;
			this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel3.Controls.Add(this.textBox10);
			this.panel3.Controls.Add(this.comboBox1);
			this.panel3.Controls.Add(this.textBox8);
			this.panel3.Controls.Add(this.textBox9);
			this.panel3.Controls.Add(this.comboBox2);
			this.panel3.Controls.Add(this.textBox11);
			this.panel3.Controls.Add(this.textBox12);
			this.panel3.Controls.Add(this.textBox13);
			this.panel3.Location = new System.Drawing.Point(8, 256);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(348, 176);
			this.panel3.TabIndex = 1;
			// 
			// textBox8
			// 
			this.textBox8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox8.Location = new System.Drawing.Point(52, 3);
			this.textBox8.Name = "textBox8";
			this.textBox8.Size = new System.Drawing.Size(130, 20);
			this.textBox8.TabIndex = 0;
			this.textBox8.Text = "ИНН";
			// 
			// textBox9
			// 
			this.textBox9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox9.Location = new System.Drawing.Point(210, 3);
			this.textBox9.Name = "textBox9";
			this.textBox9.Size = new System.Drawing.Size(130, 20);
			this.textBox9.TabIndex = 0;
			this.textBox9.Text = "КПП";
			// 
			// comboBox1
			// 
			this.comboBox1.Location = new System.Drawing.Point(52, 22);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(289, 21);
			this.comboBox1.TabIndex = 1;
			this.comboBox1.Text = "Организация";
			// 
			// textBox10
			// 
			this.textBox10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox10.Location = new System.Drawing.Point(52, 43);
			this.textBox10.Name = "textBox10";
			this.textBox10.Size = new System.Drawing.Size(288, 20);
			this.textBox10.TabIndex = 0;
			this.textBox10.Text = "Организация";
			// 
			// comboBox2
			// 
			this.comboBox2.Location = new System.Drawing.Point(52, 62);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(288, 21);
			this.comboBox2.TabIndex = 1;
			this.comboBox2.Text = "Р/С";
			// 
			// textBox11
			// 
			this.textBox11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox11.Location = new System.Drawing.Point(52, 83);
			this.textBox11.Multiline = true;
			this.textBox11.Name = "textBox11";
			this.textBox11.Size = new System.Drawing.Size(288, 48);
			this.textBox11.TabIndex = 0;
			this.textBox11.Text = "БАНК";
			// 
			// textBox12
			// 
			this.textBox12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox12.Location = new System.Drawing.Point(52, 130);
			this.textBox12.Name = "textBox12";
			this.textBox12.Size = new System.Drawing.Size(288, 20);
			this.textBox12.TabIndex = 0;
			this.textBox12.Text = "БИК";
			// 
			// textBox13
			// 
			this.textBox13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox13.Location = new System.Drawing.Point(52, 149);
			this.textBox13.Name = "textBox13";
			this.textBox13.Size = new System.Drawing.Size(288, 20);
			this.textBox13.TabIndex = 0;
			this.textBox13.Text = "К/С";
			// 
			// comboBox3
			// 
			this.comboBox3.Location = new System.Drawing.Point(64, 205);
			this.comboBox3.Name = "comboBox3";
			this.comboBox3.Size = new System.Drawing.Size(84, 21);
			this.comboBox3.TabIndex = 2;
			this.comboBox3.Text = "ТИП";
			// 
			// textBox14
			// 
			this.textBox14.Location = new System.Drawing.Point(148, 206);
			this.textBox14.Name = "textBox14";
			this.textBox14.Size = new System.Drawing.Size(110, 20);
			this.textBox14.TabIndex = 3;
			this.textBox14.Text = "textBox14";
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Location = new System.Drawing.Point(260, 206);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(96, 20);
			this.dateTimePicker1.TabIndex = 4;
			// 
			// textBox15
			// 
			this.textBox15.Location = new System.Drawing.Point(62, 434);
			this.textBox15.Multiline = true;
			this.textBox15.Name = "textBox15";
			this.textBox15.Size = new System.Drawing.Size(294, 48);
			this.textBox15.TabIndex = 5;
			this.textBox15.Text = "textBox15";
			// 
			// textBox16
			// 
			this.textBox16.Location = new System.Drawing.Point(62, 483);
			this.textBox16.Name = "textBox16";
			this.textBox16.Size = new System.Drawing.Size(294, 20);
			this.textBox16.TabIndex = 6;
			this.textBox16.Text = "textBox16";
			// 
			// textBox17
			// 
			this.textBox17.Location = new System.Drawing.Point(64, 229);
			this.textBox17.Name = "textBox17";
			this.textBox17.Size = new System.Drawing.Size(85, 20);
			this.textBox17.TabIndex = 7;
			this.textBox17.Text = "100 000 000,00";
			this.textBox17.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// textBox18
			// 
			this.textBox18.Location = new System.Drawing.Point(150, 229);
			this.textBox18.Name = "textBox18";
			this.textBox18.Size = new System.Drawing.Size(32, 20);
			this.textBox18.TabIndex = 8;
			this.textBox18.Text = "RUR";
			// 
			// textBox19
			// 
			this.textBox19.Location = new System.Drawing.Point(220, 229);
			this.textBox19.Name = "textBox19";
			this.textBox19.Size = new System.Drawing.Size(85, 20);
			this.textBox19.TabIndex = 7;
			this.textBox19.Text = "100 000 000,00";
			this.textBox19.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// comboBox4
			// 
			this.comboBox4.Location = new System.Drawing.Point(306, 228);
			this.comboBox4.Name = "comboBox4";
			this.comboBox4.Size = new System.Drawing.Size(50, 21);
			this.comboBox4.TabIndex = 9;
			this.comboBox4.Text = "20%";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(134, 508);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(60, 20);
			this.button1.TabIndex = 10;
			this.button1.Text = "button1";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(194, 508);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(60, 20);
			this.button2.TabIndex = 10;
			this.button2.Text = "button1";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(254, 508);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(60, 20);
			this.button3.TabIndex = 10;
			this.button3.Text = "button1";
			// 
			// dataGrid2
			// 
			this.dataGrid2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dataGrid2.DataMember = "";
			this.dataGrid2.Dock = System.Windows.Forms.DockStyle.Top;
			this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid2.Location = new System.Drawing.Point(0, 0);
			this.dataGrid2.Name = "dataGrid2";
			this.dataGrid2.Size = new System.Drawing.Size(282, 226);
			this.dataGrid2.TabIndex = 0;
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(10, 234);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(60, 20);
			this.button4.TabIndex = 11;
			this.button4.Text = "button1";
			// 
			// dataGrid3
			// 
			this.dataGrid3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dataGrid3.DataMember = "";
			this.dataGrid3.Dock = System.Windows.Forms.DockStyle.Top;
			this.dataGrid3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid3.Location = new System.Drawing.Point(0, 267);
			this.dataGrid3.Name = "dataGrid3";
			this.dataGrid3.Size = new System.Drawing.Size(282, 215);
			this.dataGrid3.TabIndex = 3;
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(6, 490);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(60, 20);
			this.button5.TabIndex = 12;
			this.button5.Text = "button1";
			// 
			// AccountStatementEditEx
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(846, 573);
			this.Controls.Add(this.pnlMainCenter);
			this.Controls.Add(this.splitter2);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.pnlMainRight);
			this.Controls.Add(this.pnlMainLeft);
			this.Controls.Add(this.toolBar1);
			this.Name = "AccountStatementEditEx";
			this.Text = "Банковская Выписка";
			this.pnlMainLeft.ResumeLayout(false);
			this.pnlMainRight.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.pnlMainCenter.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.panel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
	}
}
