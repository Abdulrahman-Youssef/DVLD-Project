using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Full_Real_Project_DataAccess_layer_
{
    public class clsApplicationDataAccessLayer
    {
       public static DataTable GetAllApplications()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = @"SELECT * FROM Applications";
            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();

                SqlDataReader read = cmd.ExecuteReader();

                if(read.Read())
                {
                    dt.Load(read);
                }
            }
            catch
            {

            } 
            finally
            {
                conn.Close();
            }

            return dt;
        }

       public static int AddedNewApplication(int CreatedByUserID ,decimal PaidFees ,DateTime LastStatusDate , int ApplicationStatus 
                                            ,int ApplicationTypeID ,DateTime ApplicationDate , int ApplicantPersonID)
        {
            SqlConnection sqlConnection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);
            string qeury = @"INSERT INTO Applications (CreatedByUserID ,PaidFees ,  LastStatusDate , ApplicationStatus ,
                                                     ApplicationTypeID ,ApplicationDate,ApplicantPersonID )
                                               VALUES (@CreatedByUserID ,@PaidFees , @LastStatusDate, @ApplicationStatus ,
                                                     @ApplicationTypeID ,@ApplicationDate,@ApplicantPersonID)
                                                         SELECT SCOPE_IDENTITY()";
            SqlCommand cmd = new SqlCommand(qeury, sqlConnection);

            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            cmd.Parameters.AddWithValue("@PaidFees", PaidFees);
            cmd.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            cmd.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            cmd.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            cmd.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            cmd.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);

            try
            {
                sqlConnection.Open();

                object result = cmd.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    sqlConnection.Close();
                    return insertedID;
                }
            }
            catch { }
            finally { sqlConnection.Close(); }

            return -1;


        }
    
    
    
        public static DataTable GetApplicationIDsByPersonIDCopletedNew(int PersonID)
        {
            DataTable dataTable = new DataTable();
            SqlConnection sqlConnection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);
            //string query = @"SELECT ApplicationID FROM Applications where ApplicantPersonID IN (" + string.Join("," , PersonID) +") ";
         
            string query = @"SELECT ApplicationID FROM Applications where ApplicantPersonID = @PersonID AND ApplicationStatus IN (1 ,3)";

            SqlCommand cmd = new SqlCommand(query, sqlConnection);

            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            try
            {
                sqlConnection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dataTable.Load(reader);

                }
            }
            catch { }
            finally { sqlConnection.Close(); }
            return dataTable;
        }

        public static bool GetApplication(int ApplicationID, ref int ApplicationTypeID,ref int ApplicantPersonID, ref int ApplicationStatus,ref int CreatedByUserID,
                    ref decimal PaidFees, ref DateTime LastStatusDate, ref DateTime ApplicationDate)
        {
            bool Found = false;
            SqlConnection sqlConnection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);
            string query = @"SELECT * FROM Applications WHERE ApplicationID = @ApplicationID";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@ApplicationID",  ApplicationID);

            try
            {
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Found = true; 
                    ApplicationTypeID = (int)reader["ApplicationTypeID"];
                    ApplicantPersonID = (int)reader["ApplicantPersonID"];
                    ApplicationStatus = (byte)reader["ApplicationStatus"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    PaidFees = (decimal)reader["PaidFees"];
                    LastStatusDate = (DateTime)reader["LastStatusDate"];
                    ApplicationDate = (DateTime)reader["ApplicationDate"];                    
                }


            }
            catch (Exception ex)
            {

            }
            finally { sqlConnection.Close(); }

            return Found;

        }


        public static int UpdateLocalDrivingLicenseIDStatusByApplicationID(int ApplicationID, int ApplicationStatus)
        {
            int EffectedRows = 0;
            SqlConnection conn = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);
            string query = @"UPDATE Applications set 
                                              ApplicationStatus =  @ApplicationStatus
                                              WHERE ApplicationID = @ApplicationID";

            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);

            try
            {
                conn.Open();
                EffectedRows = command.ExecuteNonQuery(); 
                
            }
            catch
            {

            }
            finally {  conn.Close(); }
            return EffectedRows;
        }






    }
}
