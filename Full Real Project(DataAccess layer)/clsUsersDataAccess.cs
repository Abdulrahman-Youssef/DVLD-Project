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
    public class clsUsersDataAccess
    {
        public static DataTable GetAllUsers()
        {
            //throw new NotImplementedException 
            DataTable allUsers = new DataTable(); 

            SqlConnection conn = new SqlConnection( clsDataAccessLayerSettings.ConnectionString);

            string Quiry = "SELECT * FROM Users";

            SqlCommand sqlCommand = new SqlCommand(Quiry , conn);

            try
            {
                conn.Open();
                
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.HasRows)
                {
                    allUsers.Load(reader);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
              return allUsers;
        }

        public static int AddedUser( int PersonID, string UserName, string PassoWord, bool Acticve)
        {
            // not confirmed
            SqlConnection conn = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string Qiury = @"INSERT INTO Users (PersonID , UserName , Password , IsActive)
                            VALUES( @PersonID , @UserName , @Password , @IsActive)
                            SELECT SCOPE_IDETITY()";

            SqlCommand command = new SqlCommand(Qiury , conn);

            command.Parameters.AddWithValue("@PeronID" , PersonID);
            command.Parameters.AddWithValue("@UserName",UserName);
            command.Parameters.AddWithValue("@Password", PassoWord);
            command.Parameters.AddWithValue("@IsActive" , Acticve);

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

        public static int UpdateUser(int UserID , string UserName ,string Password , bool IsActive)
        {  
            // not comfirmed
            int result = 0; 
            SqlConnection connection = new SqlConnection( clsDataAccessLayerSettings.ConnectionString);

            string Qiury = @"UPDATE Users set
                            UserName = @UserName,
                            Password = @Password,
                            IsActive = @IsActive
                            WHERE UserID = @UesrID";
            SqlCommand command = new SqlCommand(Qiury,connection);

            command.Parameters.AddWithValue("@UserID" , UserID);    
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password" , Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);

            try
            {
                 connection.Open();
                 result = command.ExecuteNonQuery();

            }
            catch 
            {
            
            }
            finally 
            {             
                connection.Close();
            }


            return result;
        }


        public static int DeleteUser(int UserID) 
        {
            // not comfirmed
            int result = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);
            string query = "DELETE FROM Users WHERE UserID =@UserID";

            SqlCommand cmd = new SqlCommand(query,connection);

            cmd.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();
                result = cmd.ExecuteNonQuery();
            }
            catch 
            {

            }
            finally
            {
                connection.Close();
            }
         return result;
        }

        public static bool FindUserByUserNameAndPassword(ref int UserID, ref int PersonID, ref string UserName, ref string Password, ref bool IsActive)
        {
            // not comfirmed
            bool Found = false;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = "SELECT * FROM Users WHERE UserName = @UserName AND Password = @Password";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Found = true;
                    UserID = (int)reader["UserID"];
                    PersonID = (int)reader["PersonID"];
                    IsActive = (bool)reader["IsActive"];
                }

            }
            catch 
            {
            
            }
            finally { connection.Close(); }
        return Found;
        }


        public static bool FindUserByUserID(ref int UserID, ref int PersonID, ref string UserName, ref string Password, ref bool IsActive)
        {
            // not comfirmed
            bool Found = false;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = "SELECT * FROM Users WHERE UserID = @UserID ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Found = true;
                    UserName = (string)reader["UserName"];
                    PersonID = (int)reader["PersonID"];
                    Password = (string)reader["Password"];
                    IsActive = (bool)reader["IsActive"];
                }

            }
            catch
            {
            
            }
            finally 
            {
                connection.Close();
            }
            return Found;
        }



        public static bool FindUserByPersonID(ref int UserID, ref int PersonID, ref string UserName, ref string Password, ref bool IsActive)
        {
            // not comfirmed
            bool Found = false;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = "SELECT * FROM Users WHERE PersonID = @PersonID ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Found = true;
                    UserName = (string)reader["UserName"];
                    UserID = (int)reader["UserID"];
                    Password = (string)reader["Password"];
                    IsActive = (bool)reader["IsActive"];
                }

            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }
            return Found;
        }

        public static bool IsUserExistByUserID(int UserID)
        {  // not comfirmed
            bool Found =false;

            SqlConnection conn = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = "SELECT UserID FROM Users WHERE UserID = @UserID";

            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@UserID" , UserID);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Found = reader.HasRows; 
                reader.Close();
            }
            catch 
            {

            } 
            finally
            {
                conn.Close();
            }

            return Found;
        }

        public static bool IsUserExistByPersonID(int PersonID)
        {  // not comfirmed
            bool Found = false;

            SqlConnection conn = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);

            string query = "SELECT UserID FROM Users WHERE PersonID = @PersonID";

            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Found = reader.HasRows;
                reader.Close();
            }
            catch
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
