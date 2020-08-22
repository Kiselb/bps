using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

namespace BPS._Forms
{
	/// <summary>
	/// Summary description for coCreditsPoints.
	/// </summary>
	public class coCreditsPoints : System.ComponentModel.Component
	{
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.Data.SqlClient.SqlConnection sqlConnection1;
		private BPS._Forms.dsCreditsPoints dsCreditsPoints1;
		private System.Data.SqlClient.SqlDataAdapter dadCreditsPoints;
		private System.Data.SqlClient.SqlCommand cmdAddCreditPoint;
		private System.Data.SqlClient.SqlCommand cmdEditCreditPoint;
		private System.Data.SqlClient.SqlCommand cmdDelCreditPoint;
		private System.Data.SqlClient.SqlCommand cmdCalculatePointsPercents;
		private System.Data.SqlClient.SqlCommand cmdDelAllPoints;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public dsCreditsPoints DsCreditsPoints
		{
			get
			{
				return this.dsCreditsPoints1;
			}
		}

		public coCreditsPoints(System.ComponentModel.IContainer container)
		{
			///
			/// Required for Windows.Forms Class Composition Designer support
			///
			container.Add(this);
			InitializeComponent();
			this.sqlConnection1 = 
				this.dadCreditsPoints.SelectCommand.Connection = 
				this.cmdAddCreditPoint.Connection = 
				this.cmdEditCreditPoint.Connection = 
				this.cmdDelCreditPoint.Connection = 
				this.cmdDelAllPoints.Connection = 
				this.cmdCalculatePointsPercents.Connection = App.Connection;

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		public coCreditsPoints()
		{
			///
			/// Required for Windows.Forms Class Composition Designer support
			///
			InitializeComponent();
			this.sqlConnection1 = 
				this.dadCreditsPoints.SelectCommand.Connection = 
				this.cmdAddCreditPoint.Connection = 
				this.cmdEditCreditPoint.Connection = 
				this.cmdDelCreditPoint.Connection = 
				this.cmdDelAllPoints.Connection = 
				this.cmdCalculatePointsPercents.Connection = App.Connection;

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


		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.dadCreditsPoints = new System.Data.SqlClient.SqlDataAdapter();
			this.dsCreditsPoints1 = new BPS._Forms.dsCreditsPoints();
			this.cmdAddCreditPoint = new System.Data.SqlClient.SqlCommand();
			this.cmdEditCreditPoint = new System.Data.SqlClient.SqlCommand();
			this.cmdDelCreditPoint = new System.Data.SqlClient.SqlCommand();
			this.cmdCalculatePointsPercents = new System.Data.SqlClient.SqlCommand();
			this.cmdDelAllPoints = new System.Data.SqlClient.SqlCommand();
			((System.ComponentModel.ISupportInitialize)(this.dsCreditsPoints1)).BeginInit();
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "[CreditPointsList]";
			this.sqlSelectCommand1.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CreditID", System.Data.SqlDbType.Int, 4));
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = "workstation id=\"X-1-3\";packet size=4096;user id=sa;password=123;data source=\"B-1-" +
				"3-TEST\";persist security info=False;initial catalog=bp2";
			// 
			// dadCreditsPoints
			// 
			this.dadCreditsPoints.SelectCommand = this.sqlSelectCommand1;
			this.dadCreditsPoints.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									   new System.Data.Common.DataTableMapping("Table", "CreditsPoints", new System.Data.Common.DataColumnMapping[] {
																																																						new System.Data.Common.DataColumnMapping("PointID", "PointID"),
																																																						new System.Data.Common.DataColumnMapping("CreditID", "CreditID"),
																																																						new System.Data.Common.DataColumnMapping("PointDate", "PointDate"),
																																																						new System.Data.Common.DataColumnMapping("PointSum", "PointSum")})});
			// 
			// dsCreditsPoints1
			// 
			this.dsCreditsPoints1.DataSetName = "dsCreditsPoints";
			this.dsCreditsPoints1.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// cmdAddCreditPoint
			// 
			this.cmdAddCreditPoint.CommandText = "[CreditPointInsert]";
			this.cmdAddCreditPoint.CommandType = System.Data.CommandType.StoredProcedure;
			this.cmdAddCreditPoint.Connection = this.sqlConnection1;
			this.cmdAddCreditPoint.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.cmdAddCreditPoint.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CreditID", System.Data.SqlDbType.Int, 4));
			this.cmdAddCreditPoint.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PointDate", System.Data.SqlDbType.DateTime, 8));
			this.cmdAddCreditPoint.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PointSum", System.Data.SqlDbType.Float, 8));
			this.cmdAddCreditPoint.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NewCreditPointID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// cmdEditCreditPoint
			// 
			this.cmdEditCreditPoint.CommandText = "[CreditPointEdit]";
			this.cmdEditCreditPoint.CommandType = System.Data.CommandType.StoredProcedure;
			this.cmdEditCreditPoint.Connection = this.sqlConnection1;
			this.cmdEditCreditPoint.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.cmdEditCreditPoint.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CreditID", System.Data.SqlDbType.Int, 4));
			this.cmdEditCreditPoint.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PointDate", System.Data.SqlDbType.DateTime, 8));
			this.cmdEditCreditPoint.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PointSum", System.Data.SqlDbType.Float, 8));
			this.cmdEditCreditPoint.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PointID", System.Data.SqlDbType.Int, 4));
			// 
			// cmdDelCreditPoint
			// 
			this.cmdDelCreditPoint.CommandText = "[CreditPointDelete]";
			this.cmdDelCreditPoint.CommandType = System.Data.CommandType.StoredProcedure;
			this.cmdDelCreditPoint.Connection = this.sqlConnection1;
			this.cmdDelCreditPoint.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.cmdDelCreditPoint.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PointID", System.Data.SqlDbType.Int, 4));
			// 
			// cmdCalculatePointsPercents
			// 
			this.cmdCalculatePointsPercents.CommandText = "[CalculatePointsPercents]";
			this.cmdCalculatePointsPercents.CommandType = System.Data.CommandType.StoredProcedure;
			this.cmdCalculatePointsPercents.Connection = this.sqlConnection1;
			this.cmdCalculatePointsPercents.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.cmdCalculatePointsPercents.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CreditID", System.Data.SqlDbType.Int, 4));
			// 
			// cmdDelAllPoints
			// 
			this.cmdDelAllPoints.CommandText = "DELETE FROM CreditsPoints WHERE (CreditID = @CreditID)";
			this.cmdDelAllPoints.Connection = this.sqlConnection1;
			this.cmdDelAllPoints.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CreditID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CreditID", System.Data.DataRowVersion.Original, null));
			((System.ComponentModel.ISupportInitialize)(this.dsCreditsPoints1)).EndInit();

		}
		#endregion

		public void FillDS(int CreditID)
		{
			this.dsCreditsPoints1.Clear();
			try
			{
				this.dadCreditsPoints.SelectCommand.Parameters["@CreditID"].Value = CreditID;
				this.dadCreditsPoints.Fill(this.dsCreditsPoints1);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public int AddCreditPoint(int CreditID, DateTime PointDate, double PointSum)
		{
			int NewCreditID = -1;
			System.Data.SqlClient.SqlCommand cmdGetCreditPointID = new System.Data.SqlClient.SqlCommand("SELECT @@IDENTITY", App.Connection);
			try
			{
				cmdAddCreditPoint.Connection.Open();
				cmdAddCreditPoint.Parameters["@CreditID"].Value = CreditID;
				cmdAddCreditPoint.Parameters["@PointDate"].Value = PointDate;
				cmdAddCreditPoint.Parameters["@PointSum"].Value = PointSum;
				cmdAddCreditPoint.ExecuteNonQuery();
				NewCreditID = (int)cmdAddCreditPoint.Parameters["@NewCreditPointID"].Value;
			}
			catch(Exception ex)
			{
				throw ex;
			}
			finally
			{
				cmdAddCreditPoint.Connection.Close();
			}
			return NewCreditID;
		}

		public bool EditCreditPoint(int PointID, int CreditID, DateTime PointDate, double PointSum)
		{
			try
			{
				cmdEditCreditPoint.Connection.Open();
				cmdEditCreditPoint.Parameters["@CreditID"].Value = CreditID;
				cmdEditCreditPoint.Parameters["@PointDate"].Value = PointDate;
				cmdEditCreditPoint.Parameters["@PointSum"].Value = PointSum;
				cmdEditCreditPoint.Parameters["@PointID"].Value = PointID;
				cmdEditCreditPoint.ExecuteNonQuery();
			}
			catch(Exception ex)
			{
				throw ex;
			}
			finally
			{
				cmdEditCreditPoint.Connection.Close();
			}
			return true;
		}

		public bool DelCreditPoint(int PointID)
		{
			try
			{
				cmdDelCreditPoint.Connection.Open();
				cmdDelCreditPoint.Parameters["@PointID"].Value = PointID;
				cmdDelCreditPoint.ExecuteNonQuery();
			}
			catch(Exception ex)
			{
				throw ex;
			}
			finally
			{
				cmdDelCreditPoint.Connection.Close();
			}
			return true;
		}

		public bool CalculatePointsPercents(int CreditID)
		{
			try
			{
				cmdCalculatePointsPercents.Connection.Open();
				cmdCalculatePointsPercents.Parameters["@CreditID"].Value = CreditID;
				cmdCalculatePointsPercents.ExecuteNonQuery();
			}
			catch(Exception ex)
			{
				throw ex;
			}
			finally
			{
				cmdCalculatePointsPercents.Connection.Close();
			}
			return true;			
		}

		public bool DelAllPoints(int CreditID)
		{
			try
			{
				cmdDelAllPoints.Connection.Open();
				cmdDelAllPoints.Parameters["@CreditID"].Value = CreditID;
				cmdDelAllPoints.ExecuteNonQuery();
			}
			catch(Exception ex)
			{
				throw ex;
			}
			finally
			{
				cmdDelAllPoints.Connection.Close();
			}
			return true;			
		}

	}
}
