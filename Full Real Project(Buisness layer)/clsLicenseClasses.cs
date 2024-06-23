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
        public static DataTable getClassCoulmn(string columnName)
        {
          return  clsLicenseClassesDataAccess.getClassCoulmn(columnName);
        }
    }
}
