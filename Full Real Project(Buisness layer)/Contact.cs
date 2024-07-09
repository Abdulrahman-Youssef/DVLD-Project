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
        public int Id { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName {  get; set; }
        public string ThirdName { get; set; }       
        public string LastName { get; set; }
        public string FullName
        {
              get { return FirstName + " " + SecondName + " " + ThirdName + " " + LastName; }
        }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int Gendor {  get; set; }
        public DateTime DateOfBirth { get; set; }
        public int NationalityCountryID { get; set; }
        public string ImagePath { get; set; }

        public clsCountry CountryInfo;



        public clsContact()
        {
            Id = -1;
            FirstName = "";
            SecondName = "";
            ThirdName = "";
            LastName = "";
            Email = "";
            Phone = "";
            Address = "";
            Gendor = 0;
            DateOfBirth = DateTime.Now;
            NationalityCountryID = 50;
            ImagePath = "";
            Mode = enMode.AddNew;
        }


        private clsContact(int ID,string NationalNo, string FirstName,string SecondName , string ThirdName, string LastName, string Email,
            string Phone,string Address,int Gendor, DateTime DataOfBirth, int NationalityCountryID, string ImagePath)
        {
            this.Id = ID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            //this.FullName = FirstName + " " + SecondName + " " + ThirdName + " " + LastName; this cuz error 
            this.Email = Email;
            this.Phone = Phone;
            this.Address = Address;
            this.Gendor = Gendor;
            this.DateOfBirth = DataOfBirth;
            this.NationalityCountryID = NationalityCountryID;
            this.ImagePath = ImagePath;
            CountryInfo = clsCountry.Find(NationalityCountryID);
            Mode = enMode.Update;
        }




        private bool _AddedNewContact()
        {
            this.Id = clsContactsDataAccess.AddedNewContact(this.NationalNo ,this.FirstName,this.SecondName , this.ThirdName,  
            this.LastName, this.Email, this.Phone,this.Address,this.Gendor, this.DateOfBirth, this.NationalityCountryID, this.ImagePath);
            return (this.Id > 0);
        }


        private bool _UpdateContact()
        {
            int effectedRows = clsContactsDataAccess.UpdateContact(this.Id,this.NationalNo, this.FirstName,this.SecondName,this.ThirdName,
                this.LastName, this.Email, this.Phone,this.Address,this.Gendor, this.DateOfBirth, this.NationalityCountryID, this.ImagePath);
            return effectedRows > 0;
        }

        public static clsContact Find(int ID)
        {
            string NationalNo = "" , FirstName = "",SecondName="" , ThirdName="", LastName = "", Email = "", Phone = "", Address = ""
                ,ImagePath = "";
            int NationalityCountryID = 0 , Gendor = 0;
            DateTime DataOfBirth = DateTime.MinValue;

            if (clsContactsDataAccess.GetContactByID(ID,ref NationalNo, ref FirstName,ref SecondName,ref ThirdName, ref LastName, ref Email, 
                ref Phone,ref Address,ref Gendor, ref DataOfBirth, ref NationalityCountryID, ref ImagePath))

            {
                return new clsContact(ID, NationalNo, FirstName,SecondName, ThirdName, LastName, Email, Phone, Address,Gendor,
                    DataOfBirth, NationalityCountryID, ImagePath);
            }
            else
            {// ?? null or new clscontact 
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
        //?country
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
