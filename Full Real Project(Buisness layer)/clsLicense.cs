using Full_Real_Project_DataAccess_layer_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Full_Real_Project_Buisness_layer_
{
    public class clsLicense
    {
        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID {get; set;}
        public int LicenseClass {get; set;}
        public DateTime IssueDate1 {get;set; }
        public DateTime ExpirationDate1 {get; set; }
        public string Notes {get; set; }
        public decimal PaidFees {get; set; }
        public bool IsActive {get; set; }
        public int IssueReason1 {get; set;}
        public int CreatedByUserID {get; set; }
        public clsLicense()
        {

        }

        private clsLicense(int LicenseID , int Application ,int DriverID , int LicenseClass , DateTime IssueDate ,DateTime ExpirationDate , string Notes ,decimal PaidFees ,bool IsActive ,int IsuueReason ,int createdByUserID)
        {
            this.LicenseID = LicenseID;
            this.ApplicationID = Application;
            this.DriverID = DriverID;
            this.LicenseClass = LicenseClass;
            this.IssueDate1 = IssueDate;
            this.ExpirationDate1 = ExpirationDate;
            this.Notes = Notes;
            this.PaidFees = PaidFees;
            this.IsActive = IsActive;
            this.IssueReason1 = IsuueReason;
            this.CreatedByUserID = createdByUserID;



        }

        public bool AddedNewLicense()
        {
            this.LicenseID = clsLicenseDataAccess.AddenNewLicense(this.ApplicationID , this.DriverID , this.LicenseClass , this.Notes, this.PaidFees, this.IsActive ,this.CreatedByUserID);
            return this.LicenseID > 0 ;
        }
        public static bool IsLicensefromClass3(int LicenseID)
        {
            return 3== clsLicenseDataAccess.GetLicenseByLicenseID(LicenseID);
        }



        public static clsLicense GetLicenseByLicenseID(int LicenseID)
        {
            int ApplicationID = -1, licenseClass = -1, DriverID = -1, IssueReason = 1, CreatedByUserID = -1;
            DateTime IssueDate = DateTime.MinValue, ExpirationDate = new DateTime();
            decimal PaidFees = 0;
            string Notes = string.Empty;
            bool IsActive = false;

            if (clsLicenseDataAccess.GetLicenseByLicenseID(LicenseID ,ref ApplicationID ,ref DriverID ,ref licenseClass ,ref IssueDate ,ref ExpirationDate ,
                                                                ref Notes ,ref PaidFees ,ref IsActive ,ref IssueReason ,ref CreatedByUserID))
            {
             return new clsLicense(LicenseID ,ApplicationID,DriverID , licenseClass ,IssueDate , ExpirationDate , Notes, PaidFees , IsActive , IssueReason , CreatedByUserID);
            }

            
            return null;

        }


        public static bool UpdatedIsActiveByLincenseID(int LincenseID, bool IsActive)
        {
            return clsLicenseDataAccess.UpdatedLicenseIsActiveByLincenseID(LincenseID,IsActive) > 0 ;
        }

        public static DataTable GetLicensesByDriverID(int DriverID)
        {
            return clsLicenseDataAccess.GetLicenseByDriverID(DriverID);
        }


        public static clsLicense GetLicenseByDriverID(int DriverID)
        {
            int ApplicationID = -1, licenseClass = -1, LicenseID = -1, IssueReason = 1, CreatedByUserID = -1;
            DateTime IssueDate = DateTime.MinValue, ExpirationDate = new DateTime();
            decimal PaidFees = 0;
            string Notes = string.Empty;
            bool IsActive = false;

            if (clsLicenseDataAccess.GetLicenseByDriverID(ref LicenseID, ref ApplicationID, DriverID, ref licenseClass, ref IssueDate, ref ExpirationDate,
                                                                ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID))
            {
                return new clsLicense(LicenseID, ApplicationID, DriverID, licenseClass, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID);
            }


            return null;

        }












    }
}
