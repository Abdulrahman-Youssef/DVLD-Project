using System;
using System.Data.SqlClient;
using System.Data;


namespace Full_Real_Project_DataAccess_layer_
{
    public class clsContactsDataAccess
    {
        public static bool GetContactByID(int ID,ref string NationalNo , ref string FirstName,ref string SecondName,ref string ThirdName , ref string LastName ,
            ref string Email, ref string Phone, ref string Address,ref int Gendor ,  ref DateTime DataOfBirth, ref int NationalityCountryID,
            ref string ImagePath)
        {
            bool Found = false;

            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = "SELECT * FROM People WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Found = true;
                    NationalNo = (string)reader["NationalNo"];
                    FirstName  = (string)reader["FirstName"];
                    LastName   = (string)reader["LastName"];
                    SecondName = (string)reader["SecondName"];
                    ThirdName  = (string)reader["ThirdName"];
                    Email      = (string)reader["Email"];
                    Phone      = (string)reader["Phone"];
                    Address    = (string)reader["Address"];
                    //error
                    //Gendor = (int)reader["Gendor"]; 
                    //no error ?????????????????? just how
                    Gendor = Convert.ToInt32(reader["Gendor"]);
                    DataOfBirth = (DateTime)reader["DateOFBirth"];

                    NationalityCountryID = Convert.ToInt32(reader["NationalityCountryID"]);
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


        // getContact by Nam
        public static bool GetContactByName(int ID, ref string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName,
            ref string Email, ref string Phone, ref string Address, ref int Gendor, ref DateTime DataOfBirth, ref int NationalityCountryID,
            ref string ImagePath)
        {
            bool Found = false;

            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = "SELECT * FROM People WHERE FirstName = @FirstName";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@FirstName", FirstName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Found = true;
                    ID = Convert.ToInt32(reader["PersonID"]);
                    NationalNo = (string)reader["NationalNo"];
                    FirstName = (string)reader["FirstName"];
                    LastName = (string)reader["LastName"];
                    SecondName = (string)reader["SecondName"];
                    ThirdName = (string)reader["ThirdName"];
                    Email = (string)reader["Email"];
                    Phone = (string)reader["Phone"];
                    Address = (string)reader["Address"];
                    //error
                    //Gendor = (int)reader["Gendor"]; 
                    //no error ?????????????????? just how
                    Gendor = Convert.ToInt32(reader["Gendor"]);
                    DataOfBirth = (DateTime)reader["DateOFBirth"];

                    NationalityCountryID = Convert.ToInt32(reader["NationalityCountryID"]);
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

        public static int AddedNewContact(string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName,
            string Email, string Phone, string Address,  int Gendor, DateTime DataOfBirth, int NationalityCountryID,string ImagePath)
        {


            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);


            string query = @"INSERT INTO People (NationalNo ,FirstName ,SecondName,ThirdName, LastName , Email, Phone,Address,Gendor
                            ,DateOfBirth,NationalityCountryID , ImagePath)
                               VALUES (@NationalNo,@FirstName,@SecondName,@ThirdName,@LastName,@Email,@Phone,@Address,@Gendor,
                            @DateOfBirth,@NationalityCountryID,@ImagePath)
                                    SELECT SCOPE_IDENTITY()";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName" , SecondName);
            command.Parameters.AddWithValue("@ThirdName",ThirdName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Gendor" , Gendor);
            command.Parameters.AddWithValue("@DateOfBirth", DataOfBirth);
            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            if (ImagePath != null || ImagePath != "")
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);



            try
            {

                connection.Open();
                object result = command.ExecuteScalar();
             
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


        public static int UpdateContact(int ID,string NationalNo, string FirstName,string SecondName,string ThirdName, string LastName, string Email, string Phone,
                   string Address,int Gendor, DateTime DataOfBirth, int NationalityCountryID, string ImagePath)
        {
            int Result = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = @"UPDATE People SET 
                                    NationalNo = @NationalNo,
                                    FirstName = @FirstName,
                                    SecondName= @SecondName,
                                    ThirdName = @ThirdName,
                                    LastName = @LastName,
                                    Phone = @Phone,
                                    Email = @Email,
                                    Address = @Address,
                                    Gendor  = @Gendor,
                                    DateOfBirth = @DataOfBirth,
                                    NationalityCountryID = @NationalityCountryID,
                                    ImagePath = @ImagePath
                                    WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", ID);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            command.Parameters.AddWithValue("@ThirdName", ThirdName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Gendor",Gendor);
            command.Parameters.AddWithValue("@DataOfBirth", DataOfBirth);
            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);

            if (ImagePath != null && ImagePath != "")
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

            string query = "DELETE FROM People WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", ID);

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

            string query = "SELECT * FROM People";

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

            string query = "select FirstName FROM People WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("PersonID", ID);

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
