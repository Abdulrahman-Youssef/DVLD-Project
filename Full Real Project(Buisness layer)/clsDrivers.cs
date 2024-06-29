using Full_Real_Project_DataAccess_layer_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Full_Real_Project_Buisness_layer_
{
    public class clsDrivers
    {

        public int DriverID {get; set;}
        public int UserID { get; set;}
        public int PersonID { get; set;}
        public DateTime CreatedDate {  get; set;}

        private clsDrivers(int DriverID , int UserID , int PersonID , DateTime CreateDate)
        {
            this.DriverID = DriverID;
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.CreatedDate = CreateDate;


        }
        public clsDrivers()
        {
            DriverID = -1;
            UserID = -1;
            PersonID = -1;
        }

        public static DataTable GetDrivers_View()
        {
            return clsDriversDataAccess.GetDrivers_View();
        }

        public bool AddedNewDriver()
        {
            this.DriverID = clsDriversDataAccess.AddedNewDriver(this.PersonID, this.UserID);
            return this.DriverID > 0; 
        }

        

        public static bool IsDriverExist(int PersonID)
        {
            return clsDriversDataAccess.IsDriverExist(PersonID);
        }

        public static clsDrivers getDriverIDByPersonID(int PersonID)
        {
            int DriverID = 0, UserID = 0;
            DateTime CreatedDate = DateTime.Now;
            if (clsDriversDataAccess.getDriverIDByPersonID(ref DriverID , PersonID ,ref UserID ,ref CreatedDate))
            {
                return new clsDrivers(DriverID , UserID , PersonID , CreatedDate );
            }
            return null; 
        }

    }
}
