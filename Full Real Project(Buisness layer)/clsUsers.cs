using Full_Real_Project_DataAccess_layer_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Full_Real_Project_Buisness_layer_
{

    public class clsUsers
    {
        // here i want some method only be accessble one there is uerser how do it cuz of that some methodes will be static ans some will not

        enum enActive { Active = 0  , inActive =1  }
         enActive Afctice { get; set; }

        clsUsers Users { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }


        public static DataTable GetAllUsers()
        {
            return clsUsersDataAccess.GetAllUsers();
        }
        public static int LoginSearch(string UserName , string PassWord) 
        {
            DataTable dt = clsUsersDataAccess.GetAllUsers(); 
            
           foreach (DataRow DR in dt.Rows)
            {
                if (DR[2].ToString() == UserName && DR["Password"].ToString() == PassWord)
                {
                    return int.Parse(DR[0].ToString());
                    
                }
            }

            return -1; 
        }


    }
}
