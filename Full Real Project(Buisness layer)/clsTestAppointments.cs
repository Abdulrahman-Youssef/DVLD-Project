using Full_Real_Project_DataAccess_layer_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Full_Real_Project_Buisness_layer_
{
    public class clsTestAppointments
    {
        public int TestAppointmentID { get; set; }
        public int TestTypeID { get; set; }
        public int LocalDrivingLicenseApplicationID { get; set; }
        public int CreatedByUserID { get; set; }
        public int? RetakeTestApplicationID { get; set; }
        public bool IsLocked { get; set; }
        public DateTime AppointmentDate { get; set; }
        public decimal PaidFees { get; set; }

        public clsTestAppointments()
        {
            this.TestAppointmentID = -1;
            this.TestTypeID = -1;
            this.LocalDrivingLicenseApplicationID = -1;
            this.CreatedByUserID = -1;
            this.RetakeTestApplicationID = -1;
            this.IsLocked = false;
            this.AppointmentDate = DateTime.Now;
            this.PaidFees = -1;
        }

        private clsTestAppointments(int TestAppointmentID ,int TestTypeID ,int LocalDrivingLicenseApplicationID , int  CreatedByUserID ,
                                    int RetakeTestApplicationID ,bool IsLocked , DateTime AppointmentDate ,decimal PaidFees)
        {
            this.TestAppointmentID= TestAppointmentID;
            this.TestTypeID= TestTypeID;
            this.LocalDrivingLicenseApplicationID= LocalDrivingLicenseApplicationID;
            this.CreatedByUserID= CreatedByUserID;
            this.RetakeTestApplicationID= RetakeTestApplicationID;
            this.IsLocked = IsLocked;
            this.AppointmentDate = AppointmentDate;
            this.PaidFees= PaidFees;


        }
        private bool _AddNewTestAppointments()
        {
            this.TestAppointmentID = clsTestAppointmentsDataAccess.AddedNewTestAppointment(this.TestTypeID, this.LocalDrivingLicenseApplicationID, this.CreatedByUserID,
                                                                                   this.RetakeTestApplicationID, this.AppointmentDate, this.PaidFees, this.IsLocked);
            return this.TestAppointmentID > 0;
        }

        public bool AddNewTestAppointments()
        {
            return _AddNewTestAppointments();
        }


        public static bool UpdateIsLockedByTestAppointmentID(int TestAppointmentID, bool IsLocked)
        {
            return clsTestAppointmentsDataAccess.UpdateIsLockedBy(TestAppointmentID , IsLocked);
        }

        public static DataTable GetTestAppointmentsByLDLAIDAndTEStTypeID(int LocalDrivingLicenseApplicationID , int TestTypeID)
        {
            return clsTestAppointmentsDataAccess.GetTestAppointmentsByLDLAIDAndTestTypeID(LocalDrivingLicenseApplicationID , TestTypeID);
        }

        public static clsTestAppointments GetTestAppointmentByLDLAID(int LocalDrivingLicenseApplicationID)
        {
            int TestAppointmentID = -1 , RetakeTestApplicationID = - 1 , CreatedByUserID  = -1 , TestTypeID = -1 ;
            DateTime AppointmentDate = DateTime.Now;
            decimal PaidFees = 0 ; 
            bool IsLocked = false ;
            if (clsTestAppointmentsDataAccess.GetTestAppointmentByLDLAID(ref TestAppointmentID,LocalDrivingLicenseApplicationID,ref TestTypeID ,ref AppointmentDate ,ref PaidFees , ref CreatedByUserID ,ref IsLocked,ref  RetakeTestApplicationID))
            {
                return new clsTestAppointments(TestAppointmentID, TestTypeID, LocalDrivingLicenseApplicationID, CreatedByUserID,
                                     RetakeTestApplicationID, IsLocked, AppointmentDate, PaidFees);
            }
            return null;
        }

    }
}
