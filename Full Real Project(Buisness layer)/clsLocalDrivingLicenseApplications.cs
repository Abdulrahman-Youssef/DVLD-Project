﻿using Full_Real_Project_DataAccess_layer_;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Full_Real_Project_Buisness_layer_
{
    public class clsLocalDrivingLicenseApplications : clsApplication
    {
        enum enMode { AddedNew = 0, Update = 1 }
        enMode Mode = enMode.AddedNew;
        public int LocalDrivingLicenseApplicationsID { get; set; }
        public int LicenseClassID { get; set; }

        //View 
        public string ClassName_View { get; set; }
        public int PassedTestCount_View { get; set; }
        public string FullName_View { get; set; }
        public DateTime ApplicationDate_View { get; set; }
        public int NationalNo_View { get; set; }
        public int Status_View { get; set; }
        public clsLicenseClasses LicenseClasseInfo;

        // this have to be the main constructor and the emtpy one , no more
        private clsLocalDrivingLicenseApplications(int LocalDrivingLicenseApplicationID, int ApplicationID, int ApplicantPersonID,
         DateTime ApplicationDate, int ApplicationTypeID,
          enApplicationStatus ApplicationStatus, DateTime LastStatusDate,
          decimal PaidFees, int CreatedByUserID, int LicenseClassID)

        {
                
            this.LocalDrivingLicenseApplicationsID = LocalDrivingLicenseApplicationID; ;
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = (int)ApplicationTypeID;
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.LicenseClassID = LicenseClassID;
            this.LicenseClasseInfo = clsLicenseClasses.GetCNAndCDAndCFByLicenseClassesID(LicenseClassID);
            Mode = enMode.Update;
        }

        private clsLocalDrivingLicenseApplications(int LocalDrivingLicenseApplicationsID, int ApplicationID, int LicenseClassID)
        {

            this.LocalDrivingLicenseApplicationsID = LocalDrivingLicenseApplicationsID;
            this.ApplicationID = ApplicationID;
            this.LicenseClassID = LicenseClassID;
            this.LicenseClasseInfo = clsLicenseClasses.GetCNAndCDAndCFByLicenseClassesID(LicenseClassID); 

            Mode = enMode.Update;
        }
        //View
        private clsLocalDrivingLicenseApplications(int LocalDrivingLicenseApplicationsID, string FullName, string ClassName, int PassedTestCount, int status_View ,int NationalNo_View ,DateTime ApplicationDate_View )
        {
            this.LocalDrivingLicenseApplicationsID = LocalDrivingLicenseApplicationsID;
            this.FullName_View = FullName;
            this.ClassName_View = ClassName;
            this.PassedTestCount_View = PassedTestCount;
            this.Status_View = status_View;
            this.ApplicationDate_View = ApplicationDate_View;
            this.NationalNo_View = NationalNo_View;
            Mode = enMode.Update;
        }
        public clsLocalDrivingLicenseApplications()
        {
            LocalDrivingLicenseApplicationsID = -1;
            this.LicenseClassID = -1;
            this.ApplicationID = -1;
            Mode = enMode.AddedNew;
        }

        private bool _AddNewLocalDrivingLicenseApplications()
        {
            this.LocalDrivingLicenseApplicationsID = clsLocalDrivingLicenseApplicationsDataAccessLayer.AddedLocalDrivingLicenseApplications(this.ApplicationID, this.LicenseClassID);
            return this.LocalDrivingLicenseApplicationsID > 0; 
        }
        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            return clsLocalDrivingLicenseApplicationsDataAccessLayer.GetAllLocalDrivingLicenseApplications();
        }
        public static DataTable GetAllLocalDrivingLicenseApplications_view()
        {
            return clsLocalDrivingLicenseApplicationsDataAccessLayer.GetLocalDrivingLicenseApplications_View();
        }

        public bool save()
        {
         base.Mode = (clsApplication.enMode)Mode;
            if(!base.Save())
                return false;

            switch (Mode)
            {
                case enMode.AddedNew:
                    if (_AddNewLocalDrivingLicenseApplications())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:

                    return false;
                    
            }
            return false;

        }
        public bool AddNewLocalDrivingLicenseApplications()
        {
            return  _AddNewLocalDrivingLicenseApplications();
        }

        public static DataTable LicenseClassIDsByApplicationIDs(List<int> applicationIDs)
        {
            return clsLocalDrivingLicenseApplicationsDataAccessLayer.LicenseClassIDsByApplicationIDs(applicationIDs);
        }

        public static clsLocalDrivingLicenseApplications GetLocalDrivingLicenseApplicationByLDLAID(int LocalDrivingLicenseApplicationID)
        {
            int LicenseClassID = 0, ApplicationID = 0;

            if (clsLocalDrivingLicenseApplicationsDataAccessLayer.GetLocalDrivingLicenseApplicationByLDLAID(LocalDrivingLicenseApplicationID, ref ApplicationID, ref LicenseClassID))
            {
                return new clsLocalDrivingLicenseApplications(LocalDrivingLicenseApplicationID, ApplicationID, LicenseClassID);
            }



            return null;
        }

        public static clsLocalDrivingLicenseApplications GetLocalDrivingLicenseApplicationsByLDLAID_View(int LocalDrivingLicenseApplicationID)
        {
            string ClassName = "", FullName = "";
            int PassedTestCount = 0 , Status_View = 0  , NationalNo_View = 0 ; DateTime ApplicationDate_View = DateTime.Now; 
            if (clsLocalDrivingLicenseApplicationsDataAccessLayer.GetLocalDrivingLicenseApplicationsByLDLAID_View(LocalDrivingLicenseApplicationID, ref ClassName, ref FullName, ref PassedTestCount,
                                                                                                                   ref ApplicationDate_View ,ref NationalNo_View ,ref Status_View ))
            {
             return new clsLocalDrivingLicenseApplications(LocalDrivingLicenseApplicationID, FullName, ClassName, PassedTestCount , Status_View, NationalNo_View, ApplicationDate_View); 
            }
            return null; 

        }


        public static byte GetPassedTestCount(int LocalDrivingLicenseApplication)
        {
            return clsTest.GetPassedTestCount(LocalDrivingLicenseApplication);
        }
        public  byte GetPassedTestCount()
        {
            return clsTest.GetPassedTestCount(this.LocalDrivingLicenseApplicationsID);
        }
        








    }
    
}
