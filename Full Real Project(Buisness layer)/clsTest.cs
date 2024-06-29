using Full_Real_Project_DataAccess_layer_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace Full_Real_Project_Buisness_layer_
{
    public class clsTest
    {
        public int TestID { get; set; }
        public int TestAppointmentID { get; set; }
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }

        public clsTest()
        {
            this.TestID = -1;
            this.TestAppointmentID = -1;
            this.Notes = string.Empty;
            this.CreatedByUserID = -1;

        }

        private clsTest(int TestID , int TestAppointmentID, bool TestResult , string Notes , int CreatedByUserID)
        {
            this.TestID = TestID;
            this.TestAppointmentID = TestAppointmentID;
            this.Notes = Notes;
            this.CreatedByUserID = CreatedByUserID;
            this.TestResult = TestResult;
        }


        public bool AddedNewTest()
        {
            this.TestID = clsTestDataAccess.AddNewTest(this.TestAppointmentID ,this.TestResult , this.Notes , this.CreatedByUserID);
            return this.TestID > 0;
        }


        public static DataTable GetTestsResultsByTestAppointmentIDs(List<int> TestAppointmentIDs)
        {
            return clsTestDataAccess.GetTestsResultsByTestAppointmentIDs( TestAppointmentIDs );
        }


    }
}
