using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPADSBO
{
    class Driver : Person
    {
        #region Properties
        private bool driverStatus;
        private DateTime licenseExpiry;

        #endregion

        #region Properties
        public bool DriverStatus
        {
            get
            {
                return driverStatus;
            }

            set
            {
                driverStatus = value;
            }
        }

        public DateTime LicenseExpiry
        {
            get
            {
                return licenseExpiry;
            }

            set
            {
                licenseExpiry = value;
            }
        }

        #endregion

        #region Constructor
        public Driver(string id, string name, string surname, string gender, int age, string phone, string email, string address, bool status, DateTime expiry):base(id, name, surname, gender, age, phone, email, address)
        {
            this.Identifier = id;
            this.Name = name;
            this.Surname = surname;
            this.Gender = gender;
            this.Age = age;
            this.Phone = phone;
            this.Email = email;
            this.Address = address;
            this.DriverStatus = status;
            this.LicenseExpiry = expiry;
        }
        #endregion

        #region Method
        #endregion

        #region Poly
        public override bool Equals(object obj)
        {
            return obj == null || !(obj is Person) ? false : Identifier.Equals(((Person)obj).Identifier);
        }
        public override int GetHashCode()
        {
            return Identifier.GetHashCode();
        }
        public override string ToString()
        {
            return string.Format(Identifier, Name, Surname, Gender, Age, Phone, Email, Address);
        }
        #endregion
    }
}
