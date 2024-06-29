using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Full_Real_Project_DataAccess_layer_
{
    public class clsLicenseClassesDataAccess
    {
        public static DataTable getClassCoulmn(string columnName)
        {
            DataTable dt = new DataTable();
            DataColumn dataColumn = new DataColumn();
            SqlConnection conn = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = "SELECT * from LicenseClasses"; 
      

            SqlCommand cmd = new SqlCommand(query, conn);

            // SQL parameters cannot be used to specify column names or table names directly.
            //cmd.Parameters.AddWithValue("@columnName", columnName);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                        dt.Load(reader);
                    //dataColumn = dt.Columns[columnName];
                    //foreach (DataRow row in dt.Rows)
                    //{
                    //    dataColumn.row
                    //}
                }

            }
            catch (Exception ex)
            {

            }
            finally { conn.Close(); }
            return dt;
        }

        public static bool GetCNAndCDAndCFByLicenseClassesID(int LicenseClassID , ref string ClassName , ref string ClassDescription  , ref decimal ClassFees)
        {
            bool Found = false;
            DataColumn dataColumn = new DataColumn();
            SqlConnection conn = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = "SELECT * from LicenseClasses WHERE LicenseClassID = @LicenseClassID";

            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
          
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Found = true;
                    ClassName = (string)reader["ClassName"];
                    ClassDescription = (string)reader["ClassDescription"];
                    ClassFees = (decimal)reader["ClassFees"];
                  
                }

            }
            catch (Exception ex)
            {

            }
            finally { conn.Close(); }
            return Found;
        }

    }
}
