using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        public static bool RememberUsernameAndPassword(string UserName, string Password)
        {
            try
            {
                string GetCurrentPath = System.IO.Directory.GetCurrentDirectory();

                string path = GetCurrentPath + "\\UserInfo.txt";

                if (UserName == "" && File.Exists(path))
                {
                    File.Delete(path);
                    return true;
                }

                string DataToSave = UserName + "#''#" + Password;

                using (StreamWriter writer = new StreamWriter(path))
                {
                    writer.WriteLine(DataToSave);
                    return true;
                }

            }
            catch
            {
                return false;
            }


        }


        public static bool GetSavedUser(ref string UserName, ref string Password)
        {
            try
            {
                string deriction = System.IO.Directory.GetCurrentDirectory();

                string path = deriction + "\\UserInfo.txt";

                if (File.Exists(path))
                {
                    using (StreamReader reader = new StreamReader(path))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] result = line.Split(new string[] { "#''#" }, StringSplitOptions.None);
                            UserName = result[0];
                            Password = result[1];
                            return true;
                        }
                    }
                }
                else
                {
                   
                    return false;
                }


            }
            catch 
            {
                return false;
            }

            return false;

        }






    }
}
