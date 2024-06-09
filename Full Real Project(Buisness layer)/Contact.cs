using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Full_Real_Project_DataAccess_layer_;


namespace Full_Real_Project_Buisness_layer_
{
    public class clsContact
    {





        public enum enMode { Update = 0, AddNew = 1 }
        public enMode Mode = enMode.AddNew;
        private bool _AddedNewContact()
        {
            this.Id = clsContactsDataAccess.AddedNewContact(this.FirstName, this.LastName, this.Email, this.Phone,
                 this.Address, this.DateOfBirth, this.CountryId, this.ImagePath);
            return (this.Id > 0);
        }


        private bool _UpdateContact()
        {
            int effectedRows = clsContactsDataAccess.UpdateContact(this.Id, this.FirstName, this.LastName, this.Email, this.Phone,
                this.Address, this.DateOfBirth, this.CountryId, this.ImagePath);
            return effectedRows > 0;
        }


        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int CountryId { get; set; }
        public string ImagePath { get; set; }

        public clsContact()
        {
            Id = -1;
            FirstName = "";
            LastName = "";
            Email = "";
            Phone = "";
            Address = "";
            DateOfBirth = DateTime.Now;
            CountryId = 0;
            ImagePath = "";
        }

        private clsContact(int ID, string FirstName, string LastName, string Email, string Phone,
                           string Address, DateTime DataOfBirth, int CountryId, string ImagePath)
        {
            this.Id = ID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.Phone = Phone;
            this.Address = Address;
            this.DateOfBirth = DataOfBirth;
            this.CountryId = CountryId;
            this.ImagePath = ImagePath;

            Mode = enMode.Update;
        }


        public static clsContact Find(int ID)
        {
            string FirstName = "", LastName = "", Email = "", Phone = "", Address = "", ImagePath = "";
            int CountryId = 0;
            DateTime DataOfBirth = DateTime.MinValue;

            if (clsContactsDataAccess.GetContactByID(ID, ref FirstName, ref LastName, ref Email, ref Phone,
                                                     ref Address, ref DataOfBirth, ref CountryId, ref ImagePath))

            {
                return new clsContact(ID, FirstName, LastName, Email, Phone, Address, DataOfBirth, CountryId, ImagePath);
            }
            else
            {
                return null;
            }
        }


        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddedNewContact())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateContact();

            }

            return true;
        }


        public static bool deletContact(int ID)
        {
            return clsContactsDataAccess.Deletcontact(ID);
        }

        public static DataTable GetAllContacts()
        {
            return clsContactsDataAccess.GetAllCotnacts();
        }

        public static bool IsContactExist(int ID)
        {
            return clsContactsDataAccess.IsContactExist(ID);
        }

        public static bool IsContryExist(string CoutryName)
        {
            return clsCountryData.IsContryExist(CoutryName);
        }

        // to five the dgv the dataTable filtered
        public static DataTable FiltertedTable() { 
        DataTable original = GetAllContacts();
        
            DataTable filtered = new DataTable();

            filtered.Columns.Add(original.Columns[0].ColumnName);//ID
            filtered.Columns.Add(original.Columns[1].ColumnName);//nationaltyNo
            filtered.Columns.Add(original.Columns[2].ColumnName);//first
            filtered.Columns.Add(original.Columns[3].ColumnName);//second
            filtered.Columns.Add(original.Columns[4].ColumnName);//third
            filtered.Columns.Add(original.Columns[5].ColumnName);//last
            filtered.Columns.Add(original.Columns[7].ColumnName);//gendor
            filtered.Columns.Add(original.Columns[6].ColumnName);//dateofbirth
            filtered.Columns.Add(original.Columns[11].ColumnName);//nationallty
            filtered.Columns.Add(original.Columns[9].ColumnName);//phone
            filtered.Columns.Add(original.Columns[10].ColumnName);//emial
            




            foreach (DataRow row in original.Rows)
            {
                int test = 0; 
                DataRow newRow = filtered.NewRow();

                newRow[0] = row[0];
                newRow[1] = row[1];
                newRow[2] = row[2];
                newRow[3] = row[3];
                newRow[4] = row[4];
                newRow[5] = row[5];
                if( row[7].ToString() ==  "0" )
                {
                    newRow[6] = "male";
                }
                else
                {
                    newRow[6] = "felmale";
                }               
                newRow[7] = row[6];

                bool sucess = Int32.TryParse(row[11].ToString() ,out test);
                if(sucess)
                {
                    newRow[8] = clsCountry.Find(test).CountryName;
                }                                  
                newRow[9] = row[9];
                newRow[10] = row[10];

                filtered.Rows.Add(newRow);
            }

            return filtered;
        
        }



    }
}
