using Full_Real_Project_DataAccess_layer_;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Full_Real_Project_Buisness_layer_
{
    public class clsDetainLicense
    {
        public int DetainID { get; set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public decimal FineFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsReleased { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? ReleasedByUserID { get; set; }
        public int? ReleaseApplicationID { get; set; }

        public clsDetainLicense()
        {
            this.DetainID = -1; 
            this.LicenseID = -1;
            this.DetainDate = DateTime.Now; 
            this.FineFees = 0;
            this.CreatedByUserID = -1;
            this.IsReleased = false;
            this.ReleaseDate = null;
            this.ReleasedByUserID =null ;
            this.ReleaseApplicationID = null;
        }
        private clsDetainLicense(int detainID, int licenseID, DateTime detainDate, decimal fineFees, int createdByUserID, bool isReleased, DateTime releaseDate, int releasedByUserID, int releaseApplicationID)
        {
            this.DetainID = detainID;
            this.LicenseID = licenseID;
            this.DetainDate = detainDate;
            this.FineFees = fineFees;
            this.CreatedByUserID = createdByUserID;
            this.IsReleased = isReleased;
            this.ReleaseDate = releaseDate;
            this.ReleasedByUserID = releasedByUserID;
            this.ReleaseApplicationID = releaseApplicationID;
        }
        private clsDetainLicense(int detainID, int licenseID, DateTime detainDate, decimal fineFees, int createdByUserID, bool isReleased)
        {
            this.DetainID = detainID;
            this.LicenseID = licenseID;
            this.DetainDate = detainDate;
            this.FineFees = fineFees;
            this.CreatedByUserID = createdByUserID;
        }
        public bool AddedNewDetianLicense()
        {
            this.DetainID = clsDetainLicensesDataAccess.AddedNewDetianLicense(this.LicenseID, this.DetainDate, this.FineFees, this.CreatedByUserID, this.IsReleased,
                                                                              this.ReleaseDate , this.ReleasedByUserID , this.ReleaseApplicationID);
            return this.DetainID > 0;
        }


        public static bool UpdateIsReleasedByLicenseID(int LicenseID ,bool IsReleased , DateTime ReleaseDate ,int ReleasedByUserID, int ReleaseApplicationID)
        {
            return clsDetainLicensesDataAccess.UpdateIsReleasedByLicenseID(LicenseID, IsReleased,ReleaseDate , ReleasedByUserID , ReleaseApplicationID);

        }

        public static bool CheckIfLicenseIsReleased(int LicenseID)
        {
            DataTable dt = clsDetainLicensesDataAccess.GetDetainedLincensesByLicense(LicenseID);
            
            foreach (DataRow dr in dt.Rows)
            {
              if( (Convert.ToBoolean(dr[0].ToString()) == false))
              {
                    return false;
              } 

            }

            return true;
       
        }


        public static clsDetainLicense GetDetaindLicenseBylicenseID(int LicenseID)
        {
            int DetainID = -1, licenseID = -1, CreatedByUserID = -1;
            decimal FineFees = 0;
            bool IsReleased = false;
            DateTime detainDate = DateTime.Now;
            if (clsDetainLicensesDataAccess.GetDetaindLicenseBylicenseID(LicenseID,ref DetainID , ref detainDate,ref FineFees,ref CreatedByUserID ,ref IsReleased))
            {
                return new clsDetainLicense(DetainID , LicenseID , detainDate , FineFees , CreatedByUserID , IsReleased);
            }

            return null;
        }


        public static DataTable GetAllDetainedLicenses()
        {
            return clsDetainLicensesDataAccess.GetAllDetainedLicenses();
        }




    }
}
