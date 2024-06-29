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
    public class clsInternationalDrivingLicenseDataAccess
    {
        // its temp function just to find out if he had internationaldriving license already or no
        public static bool CheckOninternationalLicenseByLocalDrivingLicense(int LocalDrivingLicenseApplicationID)
        {
            bool Found = false;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);
            string query = @"SELECT * FROM InternationalLicenses WHERE IssuedUsingLocalLicenseID = @IssuedUsingLocalLicenseID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", LocalDrivingLicenseApplicationID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return Found = true;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return Found;
        }

        public static bool GetInternationalLicnseByLocaldrivingLicense(int LocalDrivingLicenseApplicationID , ref int ApplicationID  , ref int InternationalLicenseID)
        {

            
                bool Found = false;
                SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);
                string query = @"SELECT * FROM InternationalLicenses WHERE IssuedUsingLocalLicenseID = @IssuedUsingLocalLicenseID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", LocalDrivingLicenseApplicationID);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                      Found = true;
                      ApplicationID = (int)reader["ApplicationID"];
                      InternationalLicenseID = (int)reader["InternationalLicenseID"];
                    }
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    connection.Close();
                }
                return Found;

            
        }

        public static DataTable GetAllInternationalDrivingLicense()
        {
            DataTable table = new DataTable();
            SqlConnection connection = new SqlConnection( clsDataAccessLayerSettings.ConnectionString);
            string query = @"SELECT * FROM InternationalLicenses"; 
            SqlCommand cmd = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.HasRows)
                {
                  table.Load(reader);
                    return table;
                }
            }
            catch {  }
            finally
            {
                connection.Close();
            }
            return table;
        }

        public static int AddedNewInternationalDrivingLicense(int ApplicationID, int DriverID, int IssuedUsingLocalLicenseID, DateTime IssueDate, DateTime ExpirationDate,
                                                                bool IsActive, int CreatedByUserID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);
            string query = @"INSERT INTO InternationalLicenses (ApplicationID , DriverID , IssuedUsingLocalLicenseID , IssueDate , ExpirationDate , IsActive , CreatedByUserID )
                                                        VALUES (@ApplicationID,@DriverID,@IssuedUsingLocalLicenseID , @IssueDate ,@ExpirationDate ,@IsActive ,@CreatedByUserID )
                                                                SELECT SCOPE_IDENTITY()";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString() , out int insertedID))
                {
                    return insertedID; 
                }
            }
            catch { }
            finally { connection.Close(); }
            return -1;

        }



    }
}
