using Full_Real_Project_DataAccess_layer_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Full_Real_Project_Buisness_layer_
{
    public class clsApplicationTypes
    {
        public int ApplicationTypesID {  get; set; }
        public string ApplicationTypeTitel { get; set; }
        public decimal ApplicationFees { get; set; }

       public clsApplicationTypes()
        {
            this.ApplicationTypesID = 0;
            this.ApplicationTypeTitel = "";
            this.ApplicationFees = 0;
        }

        private clsApplicationTypes(int ApplicationTypeID , decimal ApplicationFees , string ApplicationTypeTitel)
        {
            this.ApplicationTypesID = ApplicationTypeID;
            this.ApplicationTypeTitel = ApplicationTypeTitel;
            this.ApplicationFees = ApplicationFees;
        }
      public static DataTable GetAllApplicationTypes()
      {
            return clsApplicationTypesDataAccessLayer.GetAllApplications(); 
      }

      public static bool UpdateFeesByApplicationIDAndApplicationTypeTitle(int applicationTypeID ,decimal ApplicationFees , string ApplicationTypeTitel)
      {
           return 0 < clsApplicationTypesDataAccessLayer.UpdateFeesByApplicationIDAndApplicationTypeTitle(applicationTypeID,ApplicationFees , ApplicationTypeTitel);
      }
        public static clsApplicationTypes GetApplicationTypesByApplicationType(int ApplicationTypeID)
        {
            string ApplicationTypeTitel = "";  decimal ApplicationFees = 0;

            if(clsApplicationTypesDataAccessLayer.GetApplicationTypesByApplicationTypeID(ref ApplicationTypeID, ref ApplicationFees,ref ApplicationTypeTitel))
            {
               return new clsApplicationTypes(ApplicationTypeID , ApplicationFees , ApplicationTypeTitel);
            }

            return null;         
        }
    }
}
