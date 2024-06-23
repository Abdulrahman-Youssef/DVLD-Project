using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Full_Real_Project_DataAccess_layer_
{
    public class clsTestTypeDataAccessLayer
    {// datatabe name TestTypes
        public static DataTable GetAllTsets()
        {
            DataTable tables = new DataTable();
            SqlConnection conn = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);
            string query = @"SELECT * FROM TestTypes";

            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();

                SqlDataReader tb = cmd.ExecuteReader(); 
                if(tb.HasRows)
                {
                    tables.Load(tb);
                }
            }
            catch 
            {

            }
            finally
            {
                conn.Close();
            }
            
            return tables;
        }

        public static int UpdateFeesAnd(int TestTypeID ,decimal TestTypeFees , string TestTypeTitle , string TestTypeDescription) 
        {
            int EffectedRows = 0;

            SqlConnection conn = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);
            string query = @"UPDATE TestTypes SET 
                             TestTypeDescription = @TestTypeDescription,
                             TestTypeTitle       = @TestTypeTitle,
                             TestTypeFees        = @TestTypeFees
                             WHERE TestTypeID    = @TestTypeID";

            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@TestTypeDescription", TestTypeDescription);
            command.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
            command.Parameters.AddWithValue("@TestTypeFees", TestTypeFees);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                conn.Open(); 

                EffectedRows = command.ExecuteNonQuery();   
                
            }
            catch
            {

            }
            finally
            {
                conn.Close();
            }
            return EffectedRows;
        }
        public static bool GetTestTypesByTestTypesID(int TestTypeID, ref decimal TestTypeFees,ref string TestTypeTitle,ref string TestTypeDescription)
        {
            bool Found = false;

            SqlConnection sqlConnection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = @"SELECT * FROM TestTypes WHERE TestTypeID = @TestTypeID";
            SqlCommand Command = new SqlCommand(query, sqlConnection);

          
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
          

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = Command.ExecuteReader();

                if(reader.Read())
                {
                    Found = true;
                    TestTypeFees = (decimal)reader["TestTypeFees"];
                    TestTypeTitle = (string)reader["TestTypeTitle"];
                    TestTypeDescription = (string)reader["TestTypeDescription"];
                }
            }
            catch { }
            finally { sqlConnection.Close(); }
            return Found;
        }


    }
}
