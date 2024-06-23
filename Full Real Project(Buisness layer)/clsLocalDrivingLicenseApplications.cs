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
    public class clsLocalDrivingLicenseApplications
    {
        private int _AddNewLocalDrivingLicenseApplications()
        {
            return this.LocalDrivingLicenseApplicationsID = clsLocalDrivingLicenseApplicationsDataAccessLayer.AddedLocalDrivingLicenseApplications(this.ApplicationID , this.LicenseClassID);            
        }
        private clsLocalDrivingLicenseApplications(int LocalDrivingLicenseApplicationsID , int ApplicationID ,int  LicenseClassID)
        {

            this.LocalDrivingLicenseApplicationsID= LocalDrivingLicenseApplicationsID;
            this.ApplicationID = ApplicationID;
            this.LicenseClassID = LicenseClassID;
        }

        public clsLocalDrivingLicenseApplications() 
        {
            LocalDrivingLicenseApplicationsID = -1;
            this.LicenseClassID = -1;
            this.ApplicationID= -1;
        }
        public int LocalDrivingLicenseApplicationsID {  get; set; }
        public int ApplicationID { get; set; }
        public int LicenseClassID { get; set; }
        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            return clsLocalDrivingLicenseApplicationsDataAccessLayer.GetAllLocalDrivingLicenseApplications();
        }
        public static DataTable GetAllLocalDrivingLicenseApplications_view()
        {
            return clsLocalDrivingLicenseApplicationsDataAccessLayer.GetLocalDrivingLicenseApplications_View();
        }

        public bool AddNewLocalDrivingLicenseApplications()
        {
            return 0 < _AddNewLocalDrivingLicenseApplications(); 
        }

        public static DataTable  LicenseClassIDsByApplicationIDs(List<int> applicationIDs)
        {
            return clsLocalDrivingLicenseApplicationsDataAccessLayer.LicenseClassIDsByApplicationIDs(applicationIDs);
        }

    }
}
