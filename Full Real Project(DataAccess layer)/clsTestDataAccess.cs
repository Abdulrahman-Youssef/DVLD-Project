using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Full_Real_Project_DataAccess_layer_
{
    public class clsTestDataAccess
    {
        public static int AddNewTest(int TestAppointmentID , bool TestResult , string Notes , int CreatedByUserID)
        {
            SqlConnection conn = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = @"INSERT INTO Tests (TestAppointmentID , TestResult , Notes , CreatedByUserID)
                                    VALUES ( @TestAppointmentID , @TestResult , @Notes ,@CreatedByUserID)
                                              SELECT SCOPE_IDENTITY()";
            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestResult", TestResult);
            if(Notes != null && Notes != "" )
            { 
                command.Parameters.AddWithValue("@Notes", Notes); 
            }
            else
            {
                command.Parameters.AddWithValue("@Notes", System.DBNull.Value); 
            }
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


            try
            {
                conn.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                 
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

        public static DataTable GetTestsResultsByTestAppointmentIDs(List<int> TestAppointmentIDs)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = @"SELECT TestResult FROM Tests  WHERE TestAppointmentID IN( " + string.Join(",", TestAppointmentIDs) + ")";

            SqlCommand command = new SqlCommand(query , connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                    return dt;
                }

            }
            catch
            {

            }
            finally { connection.Close(); }
            return null;
        }

    }
}
