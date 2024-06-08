using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Full_Real_Project_DataAccess_layer_
{
    public class clsContactsDataAccess
    {
        public static bool GetContactByID(int ID, ref string FirstName, ref string LastName, ref string Email, ref string Phone
        , ref string Address, ref DateTime DataOfBirth, ref int CountryId, ref string ImagePath)
        {
            bool Found = false;

            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = "SELECT * FROM Contacts WHERE ContactID = @ContactID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ContactID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Found = true;
                    FirstName = (string)reader["FirstName"];
                    LastName = (string)reader["LastName"];
                    Email = (string)reader["Email"];
                    Phone = (string)reader["Phone"];
                    Address = (string)reader["Address"];
                    DataOfBirth = (DateTime)reader["DateOFBirth"];
                    CountryId = (int)reader["CountryID"];
                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)reader["ImagePath"];
                    }
                    else
                    {
                        ImagePath = "";
                    }


                }
                else
                {
                    Found = false;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("error : " + ex.ToString());
                Found = false;
            }
            finally
            {
                connection.Close();
            }

            return Found;
        }



        public static int AddedNewContact(string FirstName, string LastName, string Email, string Phone,
               string Address, DateTime DataOfBirth, int CountryId, string ImagePath)
        {


            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);


            string query = @"INSERT INTO Contacts (FirstName , LastName , Email, Phone,Address,DateOfBirth,CountryId , ImagePath)
                               VALUES (@FirstName,@LastName,@Email,@Phone,@Address,@DateOfBirth,@CountryId,@ImagePath)
                                    SELECT SCOPE_IDENTITY()";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@DateOfBirth", DataOfBirth);
            command.Parameters.AddWithValue("@CountryId", CountryId);
            if (ImagePath != null)
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);



            try
            {

                connection.Open();
                object result = command.ExecuteScalar();
                connection.Close();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    connection.Close();
                    return insertedID;
                }



            }

            catch (Exception ex)
            {
                return -1;
            }



            return -1;
        }


        public static int UpdateContact(int ID, string FirstName, string LastName, string Email, string Phone,
                   string Address, DateTime DataOfBirth, int CountryId, string ImagePath)
        {
            int Result = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = @"UPDATE Contacts SET 
                                    FirstName = @FirstName,
                                    LastName = @LastName,
                                    Phone = @Phone,
                                    Email = @Email,
                                    Address = @Address,
                                    DateOfBirth = @DataOfBirth,
                                    CountryId = @CountryId,
                                    ImagePath = @ImagePath
                                    WHERE ContactID = @ContactID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ContactID", ID);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@DataOfBirth", DataOfBirth);
            command.Parameters.AddWithValue("@CountryId", CountryId);

            if (ImagePath != null)
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);


            try
            {
                connection.Open();
                Result = command.ExecuteNonQuery();

                connection.Close();


            }
            catch (Exception ex)
            {

            }

            return Result;

        }


        public static bool Deletcontact(int ID)
        {
            int EffectRows = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = "DELETE FROM Contacts WHERE ContactID = @contactID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@contactID", ID);

            try
            {
                connection.Open();
                EffectRows = command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {

            }
            return EffectRows > 0;

        }


        public static DataTable GetAllCotnacts()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = "SELECT * FROM Contacts";

            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }


            return dt;
        }

        public static bool IsContactExist(int ID)
        {
            bool found = false;

            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = "select FirstName FROM Contacts WHERE ContactID = @ContactID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("ContactID", ID);

            try
            {
                connection.Open();

                SqlDataReader Reader = command.ExecuteReader();

                found = Reader.HasRows;
                Reader.Close();
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






    }
}
