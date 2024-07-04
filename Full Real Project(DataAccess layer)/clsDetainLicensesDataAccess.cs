using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Full_Real_Project_DataAccess_layer_
{
    public class clsDetainLicensesDataAccess
    {

        public static int AddedNewDetianLicense(int LicenseID , DateTime DetainDate ,decimal FineFees ,int CreatedByUserID,bool IsReleased ,DateTime? ReleaseDate,
                                                int? ReleasedByUserID , int? ReleaseApplicationID )
        {
            SqlConnection sqlConnection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);
            string query = @"INSERT INTO DetainedLicenses (LicenseID, DetainDate, FineFees , CreatedByUserID, IsReleased, ReleaseDate, ReleasedByUserID,
                                                            ReleaseApplicationID) VALUES
                                                          (@LicenseID,@DetainDate,@FineFees,@CreatedByUserID,@IsReleased,@ReleaseDate,@ReleasedByUserID,
                                                           @ReleaseApplicationID)
                                                            SELECT SCOPE_IDENTITY()";

            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@DetainDate", DetainDate);
            command.Parameters.AddWithValue("@FineFees", FineFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsReleased", IsReleased);
            if (ReleaseDate != null)
             command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
            else
                command.Parameters.AddWithValue("@ReleaseDate", System.DBNull.Value);
            if (ReleaseApplicationID != null)
                command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
            else
                command.Parameters.AddWithValue("@ReleasedByUserID", System.DBNull.Value);
            if (ReleaseApplicationID != null)
                command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);
            else
                command.Parameters.AddWithValue("@ReleaseApplicationID", System.DBNull.Value);

            try
            {
                sqlConnection.Open();
                object obj = command.ExecuteScalar();
                if (obj != null && int.TryParse(obj.ToString(), out int insertedID))
                {
                    return insertedID;
                }

            }
            catch 
            {

            }
            finally { sqlConnection.Close(); }


            return -1;
        }


        public static bool UpdateIsReleasedByLicenseID(int LicenseID , bool IsReleased, DateTime ReleaseDate,int ReleasedByUserID, int ReleaseApplicationID)
        {
            int EffectedRow = 0;
            SqlConnection sqlConnection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);
            string query = @"Update DetainedLicenses set
                                 IsReleased = @IsReleased,
                                 ReleaseDate=@ReleaseDate,
                                 ReleasedByUserID =@ReleasedByUserID,
                                 ReleaseApplicationID=@ReleaseApplicationID
                             WHERE LicenseID = @LicenseID";

            SqlCommand command = new SqlCommand(query, sqlConnection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@IsReleased", IsReleased);
            command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
            command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
            command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);
            try
            {
                sqlConnection.Open();
                EffectedRow = command.ExecuteNonQuery();
            }
            catch { }
            finally { sqlConnection.Close(); }
            return EffectedRow > 0 ;
        }


        public static DataTable GetDetainedLincensesByLicense(int LicenseID)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);
            string query = @"SELECT IsReleased from DetainedLicenses WHERE LicenseID = @LicenseID";
            SqlCommand command = new SqlCommand(query,conn);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                   dt.Load(reader);
                }
            }
            catch { }
            finally {  conn.Close(); }
            return dt;
        }


        public static bool GetDetaindLicenseBylicenseID(int licenseID,ref int DetainedID,ref DateTime DetainDate,ref decimal FineFees,ref int CreatedByUserID,ref bool IsReleased)
        {
            bool Found = false;
            SqlConnection conn = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = @"SELECT * FROM DetainedLicenses DetainedLicenses WHERE LicenseID = @LicenseID  AND IsReleased = 0";

            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@LicenseID", licenseID);
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {

                    Found = true;
                    DetainedID = (int)reader["DetainID"];
                    DetainDate = (DateTime)reader["DetainDate"];
                    FineFees = (decimal)reader["FineFees"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsReleased = (bool)reader["IsReleased"];

                }
            }
            catch { }
            finally { conn.Close(); }
            return Found;  
        }




        public static DataTable GetAllDetainedLicenses()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);
            string query = @"SELECT * from DetainedLicenses";
            SqlCommand command = new SqlCommand(query, conn);

         

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
            }
            catch { }
            finally { conn.Close(); }
            return dt;
        }


    }
}
