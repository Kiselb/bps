using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace BPS._Forms
{
	/// <summary>
	/// Summary description for FormatFieldPropsEdit.
	/// </summary>
	public class FormatFieldPropsEdit : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private DataRow m_row;
		private bool mbIsEdit = false;
		private System.Windows.Forms.TextBox tbFieldName;
		private System.Windows.Forms.TextBox tbHeader;
		private System.Windows.Forms.TextBox tbDelimiter;
		private System.Windows.Forms.ComboBox cmbAlign;
		private System.Windows.Forms.TextBox tbLength;
		private System.Windows.Forms.ComboBox cmbFieldType;
		private System.Windows.Forms.CheckBox cbCRLF;
		private System.Windows.Forms.CheckBox cbAutoLength;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox tbFiller;

		public DataRow FieldProperties
		{
			get
			{
				return this.m_row;
			}
		}
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormatFieldPropsEdit(DataRow row, bool IsEdit)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			this.m_row = row;
			this.mbIsEdit = IsEdit;
			this.cmbFieldType.Enabled = false;
			if(this.mbIsEdit)
			{
				if(this.m_row["type"].ToString().CompareTo("DBField") == 0)
				{
					this.cmbFieldType.SelectedIndex = 0;
					this.tbFieldName.ReadOnly = true;
				}
				else
				{
					this.cmbFieldType.SelectedIndex = 1;
					this.tbFieldName.ReadOnly = false;
					this.cbAutoLength.Checked = true;
				}
				this.tbFieldName.Text = this.m_row["name"].ToString();
				this.tbHeader.Text = this.m_row["header"].ToString();
				if(this.m_row["delimiter"].ToString().EndsWith("\n"))
				{
					this.cbCRLF.Checked = true;
					this.tbDelimiter.Text = this.m_row["delimiter"].ToString().TrimEnd("\r\n".ToCharArray());
				}
				else
				{
					this.tbDelimiter.Text = this.m_row["delimiter"].ToString();
				}
				if(this.m_row["length"] != DBNull.Value && System.Convert.ToInt32(this.m_row["length"]) == -1)
				{
					this.cbAutoLength.Checked = true;
				}
				else
				{
					this.tbLength.Text = this.m_row["length"].ToString();
				}
				this.cmbAlign.SelectedIndex = System.Convert.ToInt32(this.m_row["align"]);
				this.tbFiller.Text = m_row["filler"].ToString();
			}
			else
			{
				this.tbFieldName.ReadOnly = false;
				this.cmbFieldType.SelectedIndex = 1;
			}
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FormatFieldPropsEdit));
			this.label1 = new System.Windows.Forms.Label();
			this.tbFieldName = new System.Windows.Forms.TextBox();
			this.tbHeader = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tbDelimiter = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.cmbAlign = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.tbLength = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.cmbFieldType = new System.Windows.Forms.ComboBox();
			this.cbCRLF = new System.Windows.Forms.CheckBox();
			this.cbAutoLength = new System.Windows.Forms.CheckBox();
			this.label7 = new System.Windows.Forms.Label();
			this.tbFiller = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "Наименование:";
			// 
			// tbFieldName
			// 
			this.tbFieldName.Location = new System.Drawing.Point(100, 30);
			this.tbFieldName.Name = "tbFieldName";
			this.tbFieldName.ReadOnly = true;
			this.tbFieldName.Size = new System.Drawing.Size(244, 21);
			this.tbFieldName.TabIndex = 3;
			this.tbFieldName.Text = "";
			// 
			// tbHeader
			// 
			this.tbHeader.Location = new System.Drawing.Point(100, 52);
			this.tbHeader.Multiline = true;
			this.tbHeader.Name = "tbHeader";
			this.tbHeader.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbHeader.Size = new System.Drawing.Size(244, 42);
			this.tbHeader.TabIndex = 5;
			this.tbHeader.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(6, 58);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 16);
			this.label2.TabIndex = 4;
			this.label2.Text = "Заголовок:";
			// 
			// tbDelimiter
			// 
			this.tbDelimiter.Location = new System.Drawing.Point(100, 96);
			this.tbDelimiter.Name = "tbDelimiter";
			this.tbDelimiter.Size = new System.Drawing.Size(122, 21);
			this.tbDelimiter.TabIndex = 7;
			this.tbDelimiter.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(6, 98);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(88, 16);
			this.label3.TabIndex = 6;
			this.label3.Text = "Разделитель:";
			// 
			// btnSave
			// 
			this.btnSave.Font = new System.Drawing.Font("Tahoma", 9.25F);
			this.btnSave.Location = new System.Drawing.Point(182, 178);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(80, 26);
			this.btnSave.TabIndex = 13;
			this.btnSave.Text = "Сохранить";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Font = new System.Drawing.Font("Tahoma", 9.25F);
			this.btnCancel.Location = new System.Drawing.Point(264, 178);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(80, 26);
			this.btnCancel.TabIndex = 14;
			this.btnCancel.Text = "Отменить";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(6, 122);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(90, 16);
			this.label4.TabIndex = 9;
			this.label4.Text = "Выравнивание:";
			// 
			// cmbAlign
			// 
			this.cmbAlign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbAlign.Items.AddRange(new object[] {
														  "Центр",
														  "По левому краю",
														  "По правому краю"});
			this.cmbAlign.Location = new System.Drawing.Point(100, 120);
			this.cmbAlign.MaxDropDownItems = 3;
			this.cmbAlign.Name = "cmbAlign";
			this.cmbAlign.TabIndex = 10;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(6, 148);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(90, 16);
			this.label5.TabIndex = 11;
			this.label5.Text = "Длина:";
			// 
			// tbLength
			// 
			this.tbLength.Location = new System.Drawing.Point(100, 144);
			this.tbLength.Name = "tbLength";
			this.tbLength.Size = new System.Drawing.Size(122, 21);
			this.tbLength.TabIndex = 12;
			this.tbLength.Text = "";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(6, 10);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(88, 14);
			this.label6.TabIndex = 0;
			this.label6.Text = "Тип поля:";
			// 
			// cmbFieldType
			// 
			this.cmbFieldType.Items.AddRange(new object[] {
															  "Значимое поле",
															  "Вспомогательное поле"});
			this.cmbFieldType.Location = new System.Drawing.Point(100, 6);
			this.cmbFieldType.Name = "cmbFieldType";
			this.cmbFieldType.Size = new System.Drawing.Size(244, 21);
			this.cmbFieldType.TabIndex = 1;
			// 
			// cbCRLF
			// 
			this.cbCRLF.Location = new System.Drawing.Point(234, 98);
			this.cbCRLF.Name = "cbCRLF";
			this.cbCRLF.Size = new System.Drawing.Size(116, 16);
			this.cbCRLF.TabIndex = 8;
			this.cbCRLF.Text = "+ перевод строки";
			// 
			// cbAutoLength
			// 
			this.cbAutoLength.Location = new System.Drawing.Point(234, 144);
			this.cbAutoLength.Name = "cbAutoLength";
			this.cbAutoLength.Size = new System.Drawing.Size(116, 22);
			this.cbAutoLength.TabIndex = 15;
			this.cbAutoLength.Text = "по ширине текста";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(234, 122);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(72, 16);
			this.label7.TabIndex = 16;
			this.label7.Text = "Заполнение:";
			// 
			// tbFiller
			// 
			this.tbFiller.Location = new System.Drawing.Point(310, 120);
			this.tbFiller.MaxLength = 1;
			this.tbFiller.Name = "tbFiller";
			this.tbFiller.Size = new System.Drawing.Size(34, 21);
			this.tbFiller.TabIndex = 17;
			this.tbFiller.Text = "";
			// 
			// FormatFieldPropsEdit
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(350, 207);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.tbFiller,
																		  this.label7,
																		  this.cbAutoLength,
																		  this.cbCRLF,
																		  this.cmbFieldType,
																		  this.label6,
																		  this.tbLength,
																		  this.label5,
																		  this.cmbAlign,
																		  this.label4,
																		  this.btnCancel,
																		  this.btnSave,
																		  this.tbDelimiter,
																		  this.label3,
																		  this.tbHeader,
																		  this.label2,
																		  this.tbFieldName,
																		  this.label1});
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormatFieldPropsEdit";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Параметры поля";
			this.ResumeLayout(false);

		}
		#endregion

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			this.m_row["name"] = this.tbFieldName.Text;
			if(this.cmbFieldType.SelectedIndex == 0)
			{
				this.m_row["type"] = "DBField";
			}
			else
			{
				if(this.cmbFieldType.SelectedIndex == 1)
				{
					this.m_row["type"] = "ExtField";
				}
			}
			if(this.tbHeader.Text == null)
			{
				this.m_row["header"] = "";
			}
			else
			{
				this.m_row["header"] = this.tbHeader.Text;
			}
			if(this.tbDelimiter.Text == null)
			{
				this.m_row["delimiter"] = "";
			}
			else
			{
				this.m_row["delimiter"] = this.tbDelimiter.Text;
			}
			if(this.cbCRLF.Checked)
			{
				this.m_row["delimiter"] += "\r\n".ToString();
			}
			if(this.tbLength.Text == "")
			{
				this.m_row["length"] = 0;
			}
			else
			{
				try
				{
					this.m_row["length"] = System.Convert.ToInt32(this.tbLength.Text);
				}
				catch(System.FormatException)
				{
					this.m_row["length"] = 0;
					AM_Controls.MsgBoxX.Show("Поле 'длина' должно содержать только цифры");
					return;
				}
			}
			if(this.cbAutoLength.Checked)
			{
				m_row["length"] = -1;
			}
			this.m_row["align"] = this.cmbAlign.SelectedIndex;
			this.m_row["filler"] = this.tbFiller.Text;
			DialogResult = DialogResult.OK;
			Close();
		}
	}
}
