using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Full_Real_Project_DataAccess_layer_
{
    public class clsLocalDrivingLicenseApplicationsDataAccessLayer
    {
        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);
            string query = @"SELECT * FROM LocalDrivingLicenseApplications";
            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dt.Load(reader);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
        
        public static DataTable GetLocalDrivingLicenseApplications_View()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);
            string query = @"SELECT * FROM LocalDrivingLicenseApplications_View";
            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.HasRows)
                {
                    dt.Load(reader);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        public static bool GetLocalDrivingLicenseApplicationsByLDLAID_View(int LocalDrivingLicenseApplicationID , ref string ClassName , ref string FullName , ref int  PassedTestCount 
                                                                            ,ref DateTime ApplicationDate_View , ref int NationalNo_View,ref  int Status_View )
        {
            
           bool Found = false;
            SqlConnection conn = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);
            string query = @"SELECT * FROM LocalDrivingLicenseApplications_View WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Found = true;

                    ClassName = (string)reader["ClassName"];
                    FullName = (string)reader["FullName"];
                    PassedTestCount = (int)reader["PassedTestCount"];
                    ApplicationDate_View = (DateTime)reader["ApplicationDate"];
                    NationalNo_View = (int)reader["NationalNo"];
                    Status_View = (int)reader["Status"];

                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return Found;
        }


        public static int AddedLocalDrivingLicenseApplications(int ApplicationID , int LicenseClassID)
        {
            SqlConnection conn = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = @"INSERT INTO LocalDrivingLicenseApplications (ApplicationID , LicenseClassID)
                                                                 VALUES (@ApplicationID ,@LicenseClassID)
                                                                       SELECT SCOPE_IDENTITY()";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                conn.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    conn.Close();
                    return insertedID;
                }
            }
            catch
            {

            }
            finally
            {
                conn.Close();
            }
            return -1; 
        }

        public static DataTable LicenseClassIDsByApplicationIDs(List<int> ApplicationIDs)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);
            string query = @"SELECT LicenseClassID FROM LocalDrivingLicenseApplications where ApplicationID IN(" + string.Join(",", ApplicationIDs) + ")";

            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.HasRows)
                {
                    dt.Load(reader);
                }
            }
            catch
            {

            }
            finally { conn.Close(); }
           
            return dt; 
        }


        public static bool GetLocalDrivingLicenseApplicationByLDLAID(int LocalDrivingLicenseApplicationID, ref int ApplicationID, ref int LicenseClassID )
        {
            bool Found = false;
            SqlConnection conn = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);
            string query = @"SELECT * FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
      

            try
            {
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                 Found = true; 
                 ApplicationID = (int)reader["ApplicationID"];
                 LicenseClassID = (int)reader["LicenseClassID"];
                }
                

            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return Found;


        }

      










    }
}
