using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Full_Real_Project_DataAccess_layer_
{
    public class clsTestAppointmentsDataAccess
    {
        public static int AddedNewTestAppointment(int TestTypeID , int LocalDrivingLicenseApplicationID , int CreatedByUserID , int? RetakeTestApplicationID,
                                                  DateTime AppointmentDate ,decimal PaidFees , bool IsLocked)
        {
            SqlConnection conn = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);
            string query = @"INSERT INTO TestAppointments (TestTypeID , RetakeTestApplicationID ,LocalDrivingLicenseApplicationID , CreatedByUserID , AppointmentDate , 
                                                            PaidFees , IsLocked) 
                                                            VALUES (@TestTypeID,@RetakeTestApplicationID,@LocalDrivingLicenseApplicationID,@CreatedByUserID,@AppointmentDate, 
                                                                    @PaidFees , @IsLocked) 
                                                                     SELECT SCOPE_IDENTITY()"; 
            SqlCommand cmd = new SqlCommand(query , conn) ;

            cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID); 
            if(RetakeTestApplicationID != null && RetakeTestApplicationID != -1)
            {
            cmd.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);

            }
            else
            {
                cmd.Parameters.AddWithValue("@RetakeTestApplicationID" ,System.DBNull.Value );
            }
            cmd.Parameters.AddWithValue("@AppointmentDate", AppointmentDate); 
            cmd.Parameters.AddWithValue("@PaidFees", PaidFees); 
            cmd.Parameters.AddWithValue("@IsLocked", IsLocked);
            try
            {
                conn.Open();
                object result = cmd.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
              
                    return insertedID;
                }

            }
            catch { }
            finally { conn.Close(); }

            return -1; 
        }



        public static bool UpdateIsLockedBy(int TestAppointmentID , bool IsLocked)
        {
            int effectedRow = 0;
            SqlConnection conn = new SqlConnection(clsDataAccessLayerSettings.ConnectionString);
            string query = @"UPDATE TestAppointments SET
                             IsLocked = @IsLocked
                             WHERE TestAppointmentID = @TestAppointmentID";
            SqlCommand command = new SqlCommand(query , conn) ;

            command.Parameters.AddWithValue("@IsLocked", IsLocked );
            command.Parameters.AddWithValue("@TestAppointmentID",TestAppointmentID);

            try
            {
                conn.Open();
                effectedRow = command.ExecuteNonQuery();

            }
            catch { }
            finally { conn.Close() ; }
            return effectedRow > 0;
        }

        public static DataTable GetTestAppointmentsByLDLAIDAndTestTypeID(int LocalDrivingLicenseApplicationID , int TestTypeID)
        {
            DataTable dt = new DataTable();

            SqlConnection conn = new SqlConnection(clsDataAccessLayerSettings.ConnectionString) ;
            string query = @"SELECT TestAppointmentID, AppointmentDate , PaidFees , IsLocked FROM TestAppointments WHERE
                            LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID AND TestTypeID  = @TestTypeID ";
            SqlCommand sqlCommand = new SqlCommand(query , conn) ;
            sqlCommand.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID" , LocalDrivingLicenseApplicationID);
            sqlCommand.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            try
            {
                conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if(reader.HasRows)
                {
                    dt.Load(reader);
                }

            }
            catch { }
            finally { conn.Close() ; }  
            return dt ;


        }


        public static bool GetTestAppointmentByLDLAID(ref int TestAppointmentID , int LocalDrivingLicenseApplicationID ,ref int TestTypeID ,ref DateTime AppointmentDate,ref decimal PaidFees ,
            ref int CreatedByUserID,ref bool IsLocked ,ref int RetakeTestApplicationID)
        {
            bool Found = false;

            SqlConnection conn = new SqlConnection (clsDataAccessLayerSettings.ConnectionString);
            string query = @"SELECT *  FROM TestAppointments WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID  AND IsLocked = 0";

            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader(); 
                if(reader.Read())
                {
                    Found = true;
                    TestAppointmentID = (int)reader["TestAppointmentID"];
                    TestTypeID = (int)reader["TestTypeID"];
                    AppointmentDate = (DateTime)reader["AppointmentDate"];
                    PaidFees = (decimal)reader["PaidFees"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsLocked = (bool)reader["IsLocked"];

                    if (null != (int?)reader["RetakeTestApplicationID"])
                    {
                        RetakeTestApplicationID = -1;
                    }
                    else
                    {
                        RetakeTestApplicationID = (int)reader["RetakeTestApplicationID"];
                    }

                }
                
            }
            catch (Exception ex) { }
            finally {conn.Close(); }
            return Found;
        }









    }
}
