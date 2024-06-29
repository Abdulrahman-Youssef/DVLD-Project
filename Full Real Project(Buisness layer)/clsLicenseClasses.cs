using Full_Real_Project_DataAccess_layer_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Full_Real_Project_Buisness_layer_
{
    public class clsLicenseClasses
    {
        public int LicenseClassID {  get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public decimal ClassFees { get; set; }
        public int  MinimumAllowedAge { get; set; }
        public int DefaultValidityLength { get; set;  }
        
        public clsLicenseClasses()
        {
            this.LicenseClassID = -1;
            this.ClassName = "";
            this.ClassDescription = "";
            this.ClassFees = 0;
        }
         
        private clsLicenseClasses(int LicenseClassID , string ClassName  ,string ClassDescription , decimal ClassFees)
        {
            this.LicenseClassID = LicenseClassID ;
            this.ClassName = ClassName ;
            this.ClassDescription = ClassDescription ;
            this.ClassFees = ClassFees ;
        }

        public static DataTable getClassCoulmn(string columnName)
        {
          return  clsLicenseClassesDataAccess.getClassCoulmn(columnName);
        }

        public static clsLicenseClasses GetCNAndCDAndCFByLicenseClassesID(int LicenseClassID)
        { 
            decimal ClassFees = 0;
            string ClassName = "", ClassDescription = ""; 
            if(clsLicenseClassesDataAccess.GetCNAndCDAndCFByLicenseClassesID(LicenseClassID , ref ClassName ,ref ClassDescription ,ref ClassFees))
            {
                return new clsLicenseClasses(LicenseClassID, ClassName, ClassDescription, ClassFees);
            }
            return null; 
        }









    }
}
