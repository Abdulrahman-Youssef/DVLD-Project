using Full_Real_Project_DataAccess_layer_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Full_Real_Project_Buisness_layer_
{
    public class clsApplication
    {
        public enum enMode {AddNew = 0  ,  Updated = 1 }
        public enMode Mode;
        public enum enApplicationType
        {
            NewDrivingLicense = 1, RenewDrivingLicense = 2, ReplaceLostDrivingLicense = 3,
            ReplaceDamagedDrivingLicense = 4, ReleaseDetainedDrivingLicsense = 5, NewInternationalLicense = 6, RetakeTest = 7
        };
        public enum enApplicationStatus { New = 1, Cancelled = 2, Completed = 3 };

        public int ApplicationID { get; set; }
        public int ApplicationTypeID { get; set; }
        public int CreatedByUserID { get; set; }
        public int ApplicantPersonID { get; set; }
        public decimal PaidFees { get; set; }
        public DateTime LastStatusDate { get; set; }
        public DateTime ApplicationDate { get; set; }
        public enApplicationStatus ApplicationStatus { get; set; }

        clsContact ContactInfo;
        clsApplicationTypes ApplicationTypesInfo;
        public clsApplication()
        {
            this.ApplicationID = -1;
            this.ApplicationTypeID = -1;
            this.CreatedByUserID = -1;
            this.ApplicantPersonID = -1;
            this.PaidFees = -1;
            this.LastStatusDate = DateTime.Now;
            this.ApplicationDate = DateTime.Now;
            this.ApplicationStatus = 0;
            Mode = enMode.AddNew;
        }
        private clsApplication(int ApplicationID, int CreatedByUserID, decimal PaidFees, DateTime LastStatusDate, enApplicationStatus ApplicationStatus
                                            , int ApplicationTypeID, DateTime ApplicationDate, int ApplicantPersonID)
        {
            this.ApplicationID = ApplicationID;
            this.ApplicationTypeID = ApplicationTypeID;
            this.CreatedByUserID = CreatedByUserID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.PaidFees = PaidFees;
            this.LastStatusDate = LastStatusDate;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationStatus = ApplicationStatus;
            ContactInfo = clsContact.Find(ApplicantPersonID);
            ApplicationTypesInfo = clsApplicationTypes.GetApplicationTypesByApplicationTypeID(ApplicationTypeID);

            Mode = enMode.Updated;
        }

        private bool _AddedNewApplication()
        {
            int ApplicationID = 0, ApplicationTypeID = -1, CreatedByUserID = -1, ApplicationStatus = 1, ApplicantPersonID = -1;
            DateTime ApplicationDate = System.DateTime.Now, LastStatusDate = DateTime.Now;
            decimal PaidFees = 0;
            // cant put this with static 
            this.ApplicationID = clsApplicationDataAccessLayer.AddedNewApplication(this.CreatedByUserID, this.PaidFees, this.LastStatusDate, (int)this.ApplicationStatus,
                                                                                   this.ApplicationTypeID, this.ApplicationDate,   this.ApplicantPersonID);

            return this.ApplicationID >0;
        }

        private bool _UpdateApplicatoin()
        {
            return clsApplicationDataAccessLayer.UpdateApplication(this.ApplicationID, this.CreatedByUserID, this.PaidFees, this.LastStatusDate, (int)this.ApplicationStatus, this.ApplicationTypeID,
                                                    this.ApplicationDate, this.ApplicantPersonID);


        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddedNewApplication())
                    {
                        Mode = enMode.Updated;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Updated:
                    if (_UpdateApplicatoin())
                    {
                        return true;
                    }
                    else
                    {
                    return false;

                    }
            }

            return false;
        }





        public static DataTable GetAllApplications()
        {
            return clsApplicationDataAccessLayer.GetAllApplications();
        }

        public  bool AddedNewApplication ()
        {
              return _AddedNewApplication();
        }


        public static DataTable GetApplicationIDsByPersonID(int PersonID)
        {
            return clsApplicationDataAccessLayer.GetApplicationIDsByPersonIDCopletedNew (PersonID);
        }


        public  static clsApplication GetApplicationByApplicatoinID(int ApplicationID)
        {
            int ApplicationTypeID = -1, CreatedByUserID = -1, ApplicantPersonID = -1;
            byte ApplicationStatus = 0 ; 
            DateTime ApplicationDate = System.DateTime.Now, LastStatusDate = DateTime.Now;
            decimal PaidFees = 0;

            if (clsApplicationDataAccessLayer.GetApplication(ApplicationID, ref ApplicationTypeID, ref ApplicantPersonID, ref ApplicationStatus ,
                                                           ref CreatedByUserID, ref PaidFees, ref LastStatusDate, ref ApplicationDate))
            {
                return new clsApplication(ApplicationID, CreatedByUserID, PaidFees, LastStatusDate,(enApplicationStatus) ApplicationStatus, ApplicationTypeID, ApplicationDate, ApplicantPersonID);
            }
            return null;  
        }

        public static bool UpdateLocalDrivingLicenseIDStatusByApplicationID(int ApplicationID , int ApplicationStatus)
        {            
            return  0 < clsApplicationDataAccessLayer.UpdateLocalDrivingLicenseIDStatusByApplicationID(ApplicationID ,ApplicationStatus);
            
            
        }


        public static bool GetActiveApplicationIDForLicenseClass(int PersonID ,int ApplicationTypeID ,int LicenseClassType )
        {
           return 0 < clsApplicationDataAccessLayer.GetActiveApplicationIDForLicenseClass(PersonID, ApplicationTypeID,LicenseClassType);
        }







    }
}
