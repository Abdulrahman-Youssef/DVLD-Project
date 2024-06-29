using Full_Real_Project_DataAccess_layer_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Full_Real_Project_Buisness_layer_
{
    public class clsInternationalDrivingLicense
    {
        public  int InternationalLicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int IssuedUsingLocalLicenseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }

        public clsInternationalDrivingLicense()
        {

        }

        private clsInternationalDrivingLicense(int ApplicationID , int InternationalLicenseID , int IssuedUsingLocalLicenseID)
        {
            this.InternationalLicenseID = InternationalLicenseID;
            this.ApplicationID = ApplicationID;
            this.IssuedUsingLocalLicenseID = IssuedUsingLocalLicenseID;
        }
        public static bool CheckOninternationalLicenseByLocalDrivingLicense(int LocalDrivingLicense)
        {
            return clsInternationalDrivingLicenseDataAccess.CheckOninternationalLicenseByLocalDrivingLicense(LocalDrivingLicense);
        }

        public static clsInternationalDrivingLicense GetInternationalDrivingLicense(int LocalDrivingLicense)
        {
            int Application = 0, InternationalLicenseID = 0;
            if(clsInternationalDrivingLicenseDataAccess.GetInternationalLicnseByLocaldrivingLicense(LocalDrivingLicense , ref InternationalLicenseID ,ref Application ))
            {
                return new clsInternationalDrivingLicense(Application, InternationalLicenseID , LocalDrivingLicense);
            }
            return null;
        }

        public static DataTable GetAllInternationalDrivingLicense()
        {
            return clsInternationalDrivingLicenseDataAccess.GetAllInternationalDrivingLicense();
        }

        public bool AddedNewInternationalDrivingLicense()
        {
         
            this.InternationalLicenseID = clsInternationalDrivingLicenseDataAccess.AddedNewInternationalDrivingLicense(this.ApplicationID, this.DriverID, this.IssuedUsingLocalLicenseID, this.IssueDate,
                                                                                                                        this.ExpirationDate, this.IsActive, this.CreatedByUserID);
            return this.InternationalLicenseID > 0;
        }



















    }
}
