using System;
using System.Data;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;
using AM_Controls;


namespace BPS.BLL.City
{
	/// <summary>
	/// Summary description for coCities.
	/// </summary>
	public class coCities : System.ComponentModel.Component
	{
		private BPS.BLL.City.DataSets.dsCities dsCities1;
		private System.Data.SqlClient.SqlDataAdapter sqldaCities;
		private System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
		private System.Data.SqlClient.SqlConnection sqlConnection1;
		private System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.Data.SqlClient.SqlCommand sqlUpdateCommand1;

		private int UpdatedRowID = 0;
		/// <summary>
		/// Required designer variable.
		/// </summary>

		public System.Data.SqlClient.SqlConnection Connection
		{
			set
			{
				this.sqldaCities.SelectCommand.Connection = 
					this.sqldaCities.InsertCommand.Connection = 
					this.sqldaCities.UpdateCommand.Connection = 
					this.sqldaCities.DeleteCommand.Connection = 
					this.sqlConnection1=
					value;
			}
			get 
			{
				return this.sqlConnection1;
			}
		}


		public coCities(System.Data.SqlClient.SqlConnection Conn)
		{
			InitializeComponent();
			this.Connection =  Conn;
		}

		public coCities()
		{
			InitializeComponent();
			this.Connection = App.Connection;
		}
		
		public BPS.BLL.City.DataSets.dsCities DataSet
		{
			get
			{
				return this.dsCities1;
			}
		}

		public int Fill()
		{
			this.dsCities1.Clear();
			return this.sqldaCities.Fill(this.dsCities1);
		}

		public bool Update()
		{
			try
			{
				this.sqldaCities.Update(this.dsCities1);
				return true;
			}
			catch(Exception ex)
			{
				AM_Controls.MsgBoxX.Show("Ошибка:\n" + ex.Message,"BPS",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				return false;
			}

		}

		public bool RejectChanges()
		{
			try
			{
				this.dsCities1.RejectChanges();
			}
			catch(Exception ex)
			{
				AM_Controls.MsgBoxX.Show(ex.Message, "BPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
			return true;
		}

		public int AddCity(string sCityName)
		{
			if (this.dsCities1.Cities.Select("CityName=\'"+sCityName+"\'").Length !=0 )
			{
				MsgBoxX.Show("Такой город уже существует в справочнике","BPS",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				return -1;
			}
			
			DataSets.dsCities.CitiesRow rw = this.dsCities1.Cities.NewCitiesRow();
			rw.CityName = sCityName;
			this.dsCities1.Cities.AddCitiesRow(rw);
			this.Update();
			return UpdatedRowID;
		}


		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
			this.dsCities1 = new BPS.BLL.City.DataSets.dsCities();
			this.sqldaCities = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
			((System.ComponentModel.ISupportInitialize)(this.dsCities1)).BeginInit();
			// 
			// dsCities1
			// 
			this.dsCities1.DataSetName = "dsCities";
			this.dsCities1.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// sqldaCities
			// 
			this.sqldaCities.DeleteCommand = this.sqlDeleteCommand1;
			this.sqldaCities.InsertCommand = this.sqlInsertCommand1;
			this.sqldaCities.SelectCommand = this.sqlSelectCommand1;
			this.sqldaCities.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																								  new System.Data.Common.DataTableMapping("Table", "Cities", new System.Data.Common.DataColumnMapping[] {
																																																			new System.Data.Common.DataColumnMapping("CityID", "CityID"),
																																																			new System.Data.Common.DataColumnMapping("CityName", "CityName")})});
			this.sqldaCities.UpdateCommand = this.sqlUpdateCommand1;
			this.sqldaCities.RowUpdated += new System.Data.SqlClient.SqlRowUpdatedEventHandler(this.sqldaCities_RowUpdated);
			// 
			// sqlDeleteCommand1
			// 
			this.sqlDeleteCommand1.CommandText = "DELETE FROM Cities WHERE (CityID = @Original_CityID) AND (CityName = @Original_Ci" +
				"tyName)";
			this.sqlDeleteCommand1.Connection = this.sqlConnection1;
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CityID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CityID", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CityName", System.Data.SqlDbType.NVarChar, 64, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CityName", System.Data.DataRowVersion.Original, null));
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = ((string)(configurationAppSettings.GetValue("ConnectionString", typeof(string))));
			// 
			// sqlInsertCommand1
			// 
			this.sqlInsertCommand1.CommandText = "INSERT INTO Cities(CityName) VALUES (@CityName); SELECT CityID, CityName FROM Cit" +
				"ies WHERE (CityID = @@IDENTITY)";
			this.sqlInsertCommand1.Connection = this.sqlConnection1;
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CityName", System.Data.SqlDbType.NVarChar, 64, "CityName"));
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT CityID, CityName FROM Cities";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlUpdateCommand1
			// 
			this.sqlUpdateCommand1.CommandText = "UPDATE Cities SET CityName = @CityName WHERE (CityID = @Original_CityID) AND (Cit" +
				"yName = @Original_CityName); SELECT CityID, CityName FROM Cities WHERE (CityID =" +
				" @CityID)";
			this.sqlUpdateCommand1.Connection = this.sqlConnection1;
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CityName", System.Data.SqlDbType.NVarChar, 64, "CityName"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CityID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CityID", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CityName", System.Data.SqlDbType.NVarChar, 64, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CityName", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CityID", System.Data.SqlDbType.Int, 4, "CityID"));
			((System.ComponentModel.ISupportInitialize)(this.dsCities1)).EndInit();

		}
		#endregion

		private void sqldaCities_RowUpdated(object sender, System.Data.SqlClient.SqlRowUpdatedEventArgs e)
		{
			if(e.StatementType == StatementType.Insert)
			{
				UpdatedRowID = (int)e.Row["CityID"];
			}
		}
	}
}
