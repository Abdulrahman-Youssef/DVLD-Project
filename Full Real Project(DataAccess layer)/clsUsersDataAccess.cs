using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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

        int AddedUser(string UserName, string PassoWord, int Acticve)
        {
            throw new NotImplementedException();
        }

        int UpdateUser()        
        {
            throw new NotImplementedException();
        }


        int DeleteUser() 
        {
            throw new NotImplementedException();
        }

        public static bool FindUser() 
        {
            

            return true;
        }

    }
}
