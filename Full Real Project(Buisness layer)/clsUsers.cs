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

        public enum enMode { Update = 0, AddNew = 1 }
        public enMode Mode = enMode.AddNew;
        //enActive Afctice { get; set; }

        private bool _AddedNewContact()
        {
            this.UserID = clsUsersDataAccess.AddedUser(this.PersonID, this.UserName, this.Password, this.Active);
            return this.UserID != -1;
        }

        private bool _UpdateContact()
        {
            int EffectedRows = clsUsersDataAccess.UpdateUserByUserID(this.UserID, this.UserName, this.Password, this.Active);
            return EffectedRows > 0;
        }

        //clsUsers Users { get; set; }

        public int UserID;

        public int PersonID;
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }

        public clsUsers()
        {
            this.UserName = "";
            this.Password = "";
            this.Active = false;
            this.UserID = -1;
            this.PersonID = -1;
            Mode = enMode.AddNew;
        }

        private clsUsers(int UserID, int PersonID, string UserName, string Password, bool IsActive)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.UserName = UserName;
            this.Password = Password;
            this.Active = IsActive;
            Mode = enMode.Update;
        }

        public static bool IsUserExistByPersonID(int PersonID)
        {
            return clsUsersDataAccess.IsUserExistByPersonID(PersonID);
        }

        public static DataTable GetAllUsers()
        {
            return clsUsersDataAccess.GetAllUsers();
        }


        //public static int LoginSearch(string UserName , string PassWord) 
        //{
        //    DataTable dt = clsUsersDataAccess.GetAllUsers(); 

        //   foreach (DataRow DR in dt.Rows)
        //    {
        //        if (DR[2].ToString() == UserName && DR["Password"].ToString() == PassWord)
        //        {
        //            return int.Parse(DR[0].ToString());

        //        }
        //    }

        //    return -1;
        //}


        public static clsUsers FindUserByUesrID(int UserID)
        {
            string UserName = "", Password = "";
            int PersonID = -1;
            bool IsActive = false;

            if (clsUsersDataAccess.FindUserByUserID(ref UserID, ref PersonID, ref UserName, ref Password, ref IsActive))
            {
                return new clsUsers(UserID, PersonID, UserName, Password, IsActive);
            }
            else
            {
                return null;
            }

        }

        public static bool DeleteUserByUserID(int UserID)
        {
            return 0 < clsUsersDataAccess.DeleteUserByUserID(UserID);
        }

        public static clsUsers LoginSearch(string UserName, string PassWord)
        {
            int UserID = 0, PersonID = -1;
            bool IsActive = false;
            if (clsUsersDataAccess.FindUserByUserNameAndPassword(ref UserID, ref PersonID, ref UserName, ref PassWord, ref IsActive))
            {
                return new clsUsers(UserID, PersonID, UserName, PassWord, IsActive);
            }
            return null;


        }

        public static bool UpdatePasswordByUserID (int UserID ,string Password)
        {
          return 0 < clsUsersDataAccess.updateUserPassword(UserID , Password);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddedNewContact())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateContact();

            }

            return true;
        }


        public static DataTable FilteredTable() 
        {
            DataTable Oringinal = clsUsers.GetAllUsers();

            DataTable Filtered = new DataTable();

            Filtered.Columns.Add(Oringinal.Columns[0].ColumnName);
            Filtered.Columns.Add(Oringinal.Columns[1].ColumnName);
            Filtered.Columns.Add("Full Name");
            Filtered.Columns.Add(Oringinal.Columns[2].ColumnName);
            Filtered.Columns.Add(Oringinal.Columns[4].ColumnName);
            
            foreach (DataRow DR in Oringinal.Rows)
            {
                string fullName = clsContact.Find(int.Parse(DR[1].ToString())).FullName;
                DataRow newRow = Filtered.NewRow();
                newRow[0] = DR[0];
                newRow[1] = DR[1];
                newRow[2] = fullName;
                newRow[3] = DR[2];
                newRow[4] = DR[4];
                //Filtered.Rows.Add(Oringinal.Rows[4]);

                Filtered.Rows.Add(newRow);
            }

            return Filtered;
        }

    }
}
