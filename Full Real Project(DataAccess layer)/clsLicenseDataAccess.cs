using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Full_Real_Project_DataAccess_layer_
{
    public class clsLicenseDataAccess
    {
        public static int AddenNewLicense(int ApplicationID , int DriverID ,int LicenseClass , string Notes , decimal PaidFees ,bool   IsActive , int CreatedByUserID)
        {
            SqlConnection conn = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);
            string query = @"INSERT INTO Licenses 
                 (ApplicationID , DriverID , LicenseClass , IssueDate , ExpirationDate ,Notes , PaidFees , IsActive , IssueReason , CreatedByUserID)
           VALUES(@ApplicationID,@DriverID,@LicenseClass,@IssueDate,@ExpirationDate,@Notes , @PaidFees , @IsActive , @IssueReason ,@CreatedByUserID)
                SELECT SCOPE_IDENTITY()";
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            cmd.Parameters.AddWithValue("@DriverID", DriverID);
            cmd.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            cmd.Parameters.AddWithValue("@IssueDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@ExpirationDate", DateTime.Now.AddYears(10));
            cmd.Parameters.AddWithValue("@IssueReason", 1);
            if(Notes != null && Notes != "")
            {
             cmd.Parameters.AddWithValue("@Notes", Notes);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Notes", System.DBNull.Value);
            }
            cmd.Parameters.AddWithValue("@PaidFees", PaidFees);
            cmd.Parameters.AddWithValue("@IsActive", IsActive);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                conn.Open();
                object result = cmd.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    conn.Close();
                    return insertedID;
                }


            }
            catch { }
            finally { conn.Close(); }

            
            return -1;
        }

        public static int GetLicenseByLicenseID(int LicenseID)
        {
            int licenseClassID = 0;
            SqlConnection conn = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = @"SELECT LicenseClass from Licenses WHERE LicenseID = @LicenseID ";
            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                   return licenseClassID = (int)reader["LicenseClass"];
                }
            }
            catch { }
            finally { conn.Close(); }

            return -1;
        }

        public static bool GetLicenseByLicenseID(int LicenseID,ref int ApplicationID ,ref int DriverID ,ref int LicenseClass,ref DateTime IssueDate , ref DateTime ExpirationDate1,
                                                    ref string Notes ,ref decimal PaidFees ,ref bool IsActive ,ref int IssueReason1 ,ref int CreatedByUserID)
        {
            bool Found = false;
            
            SqlConnection conn = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = @"SELECT * from Licenses WHERE LicenseID = @LicenseID ";
            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Found = true;
                    ApplicationID = (int)reader["ApplicationID"];
                    DriverID = (int)reader["DriverID"];
                    LicenseClass = (int)reader["LicenseClass"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate1 = (DateTime)reader["ExpirationDate"];
                    if (reader["Notes"] != System.DBNull.Value)
                    {
                        Notes = (string)reader["Notes"];
                    }
                    else
                    {
                        Notes = "";
                    }
                    PaidFees = (decimal)reader["PaidFees"];
                    IsActive = (bool)reader["IsActive"];
                    IssueReason1 = (byte)reader["IssueReason"];
                    CreatedByUserID = (int)reader["createdByUserID"];

                }
            }
            catch { }
            finally { conn.Close(); }

            return Found;
        }



        public static int UpdatedLicenseIsActiveByLincenseID(int LincenseID, bool IsActive)
        {
            int EffectedRow = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);
            string query = @"UPDATE Licenses SET 
                                             IsActive = @IsActive
                                        WHERE LicenseID = @LicenseID ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@LicenseID", LincenseID);
            try
            {
                connection.Open();

                EffectedRow = command.ExecuteNonQuery();


            }
            catch { }
            finally { connection.Close(); }
            return EffectedRow;
        }



        public static DataTable GetLicenseByDriverID(int DriverID)
        {
            DataTable dt = new DataTable(); 

            SqlConnection conn = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = @"SELECT * from Licenses WHERE DriverID = @DriverID";
            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@DriverID", DriverID);

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





        public static bool GetLicenseByDriverID(ref int LicenseID, ref int ApplicationID, int DriverID, ref int LicenseClass, ref DateTime IssueDate, ref DateTime ExpirationDate1,
                                                  ref string Notes, ref decimal PaidFees, ref bool IsActive, ref int IssueReason1, ref int CreatedByUserID)
        {
            bool Found = false;

            SqlConnection conn = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = @"SELECT * from Licenses WHERE DriverID = @DriverID ";
            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Found = true;
                    ApplicationID = (int)reader["ApplicationID"];
                    LicenseID = (int)reader["LicenseID"];
                    LicenseClass = (int)reader["LicenseClass"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate1 = (DateTime)reader["ExpirationDate"];
                    if (reader["Notes"] != System.DBNull.Value)
                    {
                        Notes = (string)reader["Notes"];
                    }
                    else
                    {
                        Notes = "";
                    }
                    PaidFees = (decimal)reader["PaidFees"];
                    IsActive = (bool)reader["IsActive"];
                    IssueReason1 = (byte)reader["IssueReason"];
                    CreatedByUserID = (int)reader["createdByUserID"];

                }
            }
            catch { }
            finally { conn.Close(); }

            return Found;
        }


        public static int UpdatedLicenseDetainedByLincenseID(int LincenseID, bool IsActive)
        {
            int EffectedRow = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);
            string query = @"UPDATE Licenses SET 
                                             IsActive = @IsActive
                                        WHERE LicenseID = @LicenseID ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@LicenseID", LincenseID);
            try
            {
                connection.Open();

                EffectedRow = command.ExecuteNonQuery();


            }
            catch { }
            finally { connection.Close(); }
            return EffectedRow;
        }



    }
}
