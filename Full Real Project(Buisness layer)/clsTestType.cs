using Full_Real_Project_DataAccess_layer_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Full_Real_Project_Buisness_layer_
{
    
    public class clsTestType
    {
        public int TestTypeID { get; set; }
        public string TestTypeTitle {  get; set; }
        public string TestTypeDescription { get; set; }
        public decimal TestTypeFees { get; set; }
        
        public clsTestType() 
        {
            this.TestTypeID = -1;
            this.TestTypeTitle = "";
            this.TestTypeDescription = "";
            this.TestTypeFees = 0;
        }

   private clsTestType(int TestTypeID , string TestTypeTitle , string TestTypeDescription ,decimal TestTypeFees)
           {
            this.TestTypeID         = TestTypeID;
            this.TestTypeTitle      = TestTypeTitle;
            this.TestTypeDescription= TestTypeDescription;
            this.TestTypeFees       = TestTypeFees;
           }
        public static DataTable GetAllTest()
        {
           return clsTestTypeDataAccessLayer.GetAllTsets();
        }

        public static bool UpdateFeestitleDescrtionByTestTypeID(int TestTypeID , string TestTypeTitle, string TestTypeDescription, decimal TestTypeFees)
        {

            return  0 < clsTestTypeDataAccessLayer.UpdateFeesAnd(TestTypeID , TestTypeFees , TestTypeTitle , TestTypeDescription);

        }

        public static clsTestType GetTestTypesByTestTypesID(int TestTypeID)
        {
            string TestTypeTitle = "" , TestTypeDescription = "";
             decimal TestTypeFees  =  0; 
            if(clsTestTypeDataAccessLayer.GetTestTypesByTestTypesID( TestTypeID , ref TestTypeFees, ref TestTypeTitle , ref TestTypeDescription))
            {
                return new clsTestType(TestTypeID, TestTypeTitle, TestTypeDescription, TestTypeFees);
            }
            return null; 
        }
        public static DataTable FiltredTable()
        {
         DataTable original = GetAllTest();

         DataTable filtered = new DataTable();

          filtered.Columns.Add(original.Columns[0].ColumnName);//TestID
          filtered.Columns.Add(original.Columns[1].ColumnName);//TestAppointmentID
          filtered.Columns.Add(original.Columns[2].ColumnName);//TestResult
          filtered.Columns.Add(original.Columns[4].ColumnName);//CreatedByUserID

          foreach (DataRow row in original.Rows)
          {
             int test = 0; 
             DataRow newRow = filtered.NewRow();

             newRow[0] = row[0];
             newRow[1] = row[1];
             newRow[2] = row[2];
             newRow[3] = row[3];

            filtered.Rows.Add(newRow);
          }

            return filtered;
        }


    }
}
