using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Full_Real_Project_DataAccess_layer_
{// data table name   ApplicationTypes
    public class clsApplicationTypesDataAccessLayer
    {
        public static DataTable GetAllApplications() 
        {
            DataTable dataTable = new DataTable();
            SqlConnection conn = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = @"SELECT * FROM ApplicationTypes";
            
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dataTable.Load(reader);
                }
            }
            catch 
            {

            }
            finally
            {
                conn.Close();
            }
                return dataTable;
        }

        public static bool GetApplicationTypesByApplicationTypeID(ref int ApplicationTypeID , ref decimal ApplicationFees , ref string ApplicationTypeTitle)
        {
            bool Found = false;
            SqlConnection conn = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);
            string query = @"SELECT * FROM ApplicationTypes WHERE ApplicationTypeID = @ApplicationTypeID";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader(); 

                if (reader.Read())
                {
                    Found = true;
                    ApplicationFees = (decimal)reader["ApplicationFees"];
                    ApplicationTypeTitle = (string)reader["ApplicationTypeTitle"];

                }


            }
            catch { }
            finally { conn.Close(); }
            return Found;
        }
        public static int UpdateFeesByApplicationIDAndApplicationTypeTitle(int applicationID , decimal ApplicationFees ,string ApplicationTypeTitle)
        {
            int Result = 0; 
            SqlConnection conn = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);
            string query = @"Update ApplicationTypes SET
                             ApplicationFees = @ApplicationFees,
                             ApplicationTypeTitle = @ApplicationTypeTitle
                              WHERE ApplicationTypeID = @ApplicationTypeID";
            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@ApplicationFees", ApplicationFees);
            command.Parameters.AddWithValue("@ApplicationTypeID", applicationID);
            command.Parameters.AddWithValue("@ApplicationTypeTitle", ApplicationTypeTitle);
            try
            {
                conn.Open();
                Result = command.ExecuteNonQuery();

            }
            catch { }
            finally { conn.Close(); }
            return Result;
        }
        
    }
}
