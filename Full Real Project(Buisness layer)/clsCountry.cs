using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Full_Real_Project_DataAccess_layer_; 

namespace Full_Real_Project_Buisness_layer_
{
    public class clsCountry
    {
        public enum enMode { update = 0, AddNew = 1 };
        public enMode Mode = enMode.AddNew;







        public int ID { get; set; }
        public string CountryName { get; set; }
        public string Code { get; set; }
        public string PhoneCode { get; set; }
        public clsCountry()
        {
            ID = -1;
            CountryName = "";

            Mode = enMode.AddNew;
        }
        private clsCountry(int ID, string CountryName, string Code, string PhoneCode)
        {
            this.ID = ID;
            this.CountryName = CountryName;
            this.Code = Code;
            this.PhoneCode = PhoneCode;

            Mode = enMode.update;
        }

        private bool _AddNewCountry()
        {
            this.ID = clsCountryData.AddCountry(this.CountryName, this.Code, this.PhoneCode);
            return this.ID > 0;
        }

        private bool _update()
        {
            int EffectedRows = clsCountryData.Update(this.ID, this.CountryName, this.Code, this.PhoneCode);
            return EffectedRows > 0;
        }



        public static clsCountry Find(int ID)
        {

            string CountryName = "", Code = "", PhoneCode = "";

            if (clsCountryData.GetCountryInfoByID(ID, ref CountryName, ref Code, ref PhoneCode))

                return new clsCountry(ID, CountryName, Code, PhoneCode);
            else
                return null;



        }

        public static clsCountry Find(string CountryName)
        {
            int ID = 0;
            string Code = "", PhoneCode = "";

            if (clsCountryData.GetCountryInfoByName(CountryName, ref ID, ref Code, ref PhoneCode))
                return new clsCountry(ID, CountryName, Code, PhoneCode);
            else
                return null;
        }


        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewCountry())
                    {
                        Mode = enMode.update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.update:
                    return _update();

            }
            return true;
        }

        public static bool DeleteCountry(int ID)
        {

            return clsCountryData.DeleteCountry(ID);

        }

        public static DataTable GetAllContries()
        {
            return clsCountryData.GetAllCountries();
        }


        public static bool IsCountryExist(int ID)
        {
            return clsCountry.IsCountryExist(ID);
        }

        public static bool IsCountryExist(string CountryName)
        {
            return clsCountry.IsCountryExist(CountryName);
        }







    }
}
