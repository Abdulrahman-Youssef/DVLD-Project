using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Full_Real_Project_DataAccess_layer_
{
    public class clsDriversDataAccess
    {
        public static DataTable GetDrivers_View()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);
            string query = @"SELECT * FROM Drivers_View";
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.HasRows)
                {
                    dt.Load(reader);
                    return dt; 
                }

            }
            catch (Exception ex)
            {

            }
            finally { conn.Close(); }

            return null; 


        }

        public static int AddedNewDriver(int PerosonID , int UserID)
        {
            SqlConnection conn = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = @"INSERT INTO Drivers (PersonID , CreatedByUserID , CreatedDate)
                                          VALUES (@PersonID,@CreatedByUserID ,@CreatedDate)
                                           SELECT SCOPE_IDENTITY()";

            SqlCommand sqlCommand = new SqlCommand(query, conn);

            sqlCommand.Parameters.AddWithValue("PersonID", PerosonID );
            sqlCommand.Parameters.AddWithValue("@CreatedByUserID", UserID);
            sqlCommand.Parameters.AddWithValue("@CreatedDate", DateTime.Now);

            try
            {
                conn.Open(); 
                object reader = sqlCommand.ExecuteScalar();
                if(reader != null && int.TryParse(reader.ToString(), out int result))
                {
                    return result;
                }


            }
            catch { }
            finally { conn.Close(); }
            return -1; 
        }

        public static bool IsDriverExist(int PersonID)
        {
            bool Found = false;

            SqlConnection conn = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);
            string query = @"SELECT PersonID from Drivers WHERE PersonID = @PersonID ";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@PersonID" , PersonID );

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Found = reader.HasRows;
                return Found; 
            }
            catch { }
            finally { conn.Close(); }
            return Found;

        }

        public static bool getDriverIDByPersonID(ref int DriverID, int PersonID ,ref int CreatedByUserID ,ref DateTime CreatedDate)
        {
            bool Found = false;
            SqlConnection conn = new SqlConnection( clsDataAccessLayerSettings.ConnectionString);
            string query = @"SELECT * FROM Drivers WHERE PersonID = @PersonID ";
            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                conn.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Found = true; 
                DriverID = (int)reader["DriverID"];
                CreatedByUserID = (int)reader["CreatedByUserID"];
                CreatedDate = (DateTime)reader["CreatedDate"];

                }
            }
            catch { }
            finally { conn.Close(); }
            return Found;
        }


















    }
}
