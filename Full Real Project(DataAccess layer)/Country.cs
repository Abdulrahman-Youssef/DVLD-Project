using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Full_Real_Project_DataAccess_layer_
{
    public class clsCountryData
    {
        //1
        public static bool GetCountryInfoByID(int id, ref string CountryName, ref string Code, ref string PhoneCode)
        {
            bool found = false;

            SqlConnection conn = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = "SELECT * FROM Countries WHERE CountryID = @CountryID";

            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@CountryID", id);


            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    found = true;

                    CountryName = (string)reader["countryName"];

                    if (reader["Code"] != DBNull.Value)
                        Code = (string)reader["Code"];
                    else
                        Code = "";


                    if (reader["phoneCode"] != DBNull.Value)
                        PhoneCode = (string)reader["PhoneCode"];
                    else
                        PhoneCode = "";
                }

                reader.Close();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }

            return found;
        }
        //2
        public static bool GetCountryInfoByName(string CountryName, ref int CountryID, ref string Code, ref string PhoneCode)
        {
            bool found = false;

            SqlConnection conn = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = "SELECT * FROM Countries WHERE CountryName = @countryname";


            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@countryname", CountryName);

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    found = true;

                    CountryID = (int)reader["CountryID"];

                    if (reader["Code"] != DBNull.Value)
                    {
                        Code = (string)reader["Code"];
                    }
                    else
                    {
                        Code = "";
                    }

                    if (reader["PhoneCode"] != DBNull.Value)
                    {
                        PhoneCode = (string)reader["PhoneCode"];
                    }
                    else
                    {
                        PhoneCode = "";
                    }


                }

                reader.Close();
            }
            catch (Exception x)
            {
                found = false;
            }
            finally
            {
                conn.Close();
            }

            return found;
        }
        //3
        public static int AddCountry(string CountryName, string Code, string PhoneCode)
        {
            int result = -1;

            SqlConnection conn = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = @"INSERT INTO Countries (CountryName , Code , PhoneCode)
                             VALUES (@CountryName , @Code , @PhoneCode)
                             SELECT SCOPE_IDENTITY()";


            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@CountryName", CountryName);

            if (Code != "")
                command.Parameters.AddWithValue("@Code", Code);
            else
                command.Parameters.AddWithValue("@Code", DBNull.Value);

            if (PhoneCode != "")
                command.Parameters.AddWithValue("@PhoneCode", PhoneCode);
            else
                command.Parameters.AddWithValue("PhoneCode", DBNull.Value);

            try
            {
                conn.Open();

                object IDNum = command.ExecuteScalar();

                if (IDNum != null && int.TryParse(IDNum.ToString(), out int insertedID))
                {
                    result = insertedID;
                }

            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {
                conn.Close();
            }

            return result;

        }
        //4
        public static int Update(int CountryID, string CountryName, string Code, string PhoneCode)
        {
            int EffectedRows = -1;
            SqlConnection conn = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);
            string query = @"UPDATE Countries SET
                             CountryName = @CountryName,
                             Code = @Code,
                             PhoneCode = @PhoneCode
                             WHERE CountryID = @CountryID";
            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@CountryID", CountryID);
            command.Parameters.AddWithValue("@CountryName", CountryName);
            command.Parameters.AddWithValue("@Code", Code);
            command.Parameters.AddWithValue("@PhoneCode", PhoneCode);
            try
            {
                conn.Open();
                EffectedRows = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                // he pass throw even if he pass a return 
                conn.Close();
            }

            return EffectedRows;
        }
        //5
        public static DataTable GetAllCountries()
        {
            DataTable result = new DataTable();
            SqlConnection conn = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = "SELECT * FROM Countries ORDER BY  CountryName";       
            SqlCommand command = new SqlCommand(query, conn);


            try
            {
                conn.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    result.Load(reader);

                }
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();

            }

            return result;
        }
        //6
        public static bool DeleteCountry(int ID)
        {
            int EffectedRows = -1;
            SqlConnection conn = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = "DELETE FROM Countries WHERE CountryID = @CountryID";

            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@CountryID", ID);

            try
            {
                conn.Open();

                EffectedRows = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

            }

            finally
            {
                conn.Close();
            }

            return EffectedRows > 0;

        }
        //7
        public static bool IsContryExist(string NameOFContry)
        {
            bool found = false;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);
            string query = "SELECT CountryID FROM Countries WHERE CountryName = @CountryName";

            SqlCommand Command = new SqlCommand(query, connection);

            Command.Parameters.AddWithValue("@CountryName", NameOFContry);

            try
            {
                connection.Open();
                SqlDataReader reader = Command.ExecuteReader();

                found = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return found;
        }
        //8
        public static bool IsCountryExist(string CountryName)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Countries WHERE CountryName = @CountryName";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CountryName", CountryName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }




    }
}
