using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Full_Real_Project_Buisness_layer_;
namespace Full_Real_Project
{
    public class clsGlobal
    {
        public static clsUsers User { get; set; }
       

        public static bool isDriverIsxist(int LocalDrivingLicenseID)
        {

            return clsDrivers.IsDriverExist(clsApplication.GetApplicationByApplicatoinID(clsLocalDrivingLicenseApplications.GetLocalDrivingLicenseApplicationByLDLAID(LocalDrivingLicenseID).ApplicationID).ApplicantPersonID);
        }
    }
}
