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
       public int ApplicationID { get; set; }
        public int ApplicationTypeID { get; set; }
        public int CreatedByUserID { get; set; }
        public int ApplicantPersonID { get; set; }
        public decimal PaidFees { get; set; }
        public DateTime LastStatusDate { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int ApplicationStatus { get; set; }

        private int _AddedNewApplication()
        {
            int ApplicationID = 0, ApplicationTypeID = -1, CreatedByUserID = -1, ApplicationStatus = 1, ApplicantPersonID = -1;
            DateTime ApplicationDate = System.DateTime.Now, LastStatusDate = DateTime.Now;
            decimal PaidFees = 0;
            // cant put this with static 
            this.ApplicationID = clsApplicationDataAccessLayer.AddedNewApplication(this.CreatedByUserID, this.PaidFees, this.LastStatusDate, this.ApplicationStatus,
                                                                                   this.ApplicationTypeID, this.ApplicationDate,   this.ApplicantPersonID);

            return this.ApplicationID;

        }
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
        }

        private clsApplication(int ApplicationID, int CreatedByUserID, decimal PaidFees, DateTime LastStatusDate, int ApplicationStatus
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


        }

        public static DataTable GetAllApplications()
        {
            return clsApplicationDataAccessLayer.GetAllApplications();
        }

        public  bool AddedNewApplication ()
        {
              return 0 < _AddedNewApplication();
        }


        public static DataTable GetApplicationIDsByPersonID(int PersonID)
        {
            return clsApplicationDataAccessLayer.GetApplicationIDsByPersonIDCopletedNew (PersonID);
        }


        public  static clsApplication GetApplicationByApplicatoinID(int ApplicationID)
        {
            int ApplicationTypeID = -1, CreatedByUserID = -1, ApplicationStatus = 1, ApplicantPersonID = -1;
            DateTime ApplicationDate = System.DateTime.Now, LastStatusDate = DateTime.Now;
            decimal PaidFees = 0;

            if(clsApplicationDataAccessLayer.GetApplication( ApplicationID ,ref ApplicationTypeID, ref ApplicantPersonID ,ref ApplicationStatus,
                                                           ref CreatedByUserID ,ref PaidFees , ref LastStatusDate ,ref ApplicationDate))
            {
               return new clsApplication(ApplicationID,CreatedByUserID,PaidFees,LastStatusDate,ApplicationStatus,ApplicationTypeID,ApplicationDate,ApplicantPersonID);
            }
            return null;  
        }





        public static bool UpdateLocalDrivingLicenseIDStatusByApplicationID(int ApplicationID , int ApplicationStatus)
        {            
            return  0 < clsApplicationDataAccessLayer.UpdateLocalDrivingLicenseIDStatusByApplicationID(ApplicationID ,ApplicationStatus);
            
            
        }










    }
}
