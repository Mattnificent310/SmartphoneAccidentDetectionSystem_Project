using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPADSBO
{
    class Contacts : Person
    {
        #region Fields
        private bool membership;
        private int level;
        private string dispName;



        #endregion

        #region Properties
        public bool Membership
        {
            get
            {
                return membership;
            }

            set
            {
                membership = value;
            }
        }

        public int Level
        {
            get
            {
                return level;
            }

            set
            {
                level = value;
            }
        }

        public string DispName
        {
            get
            {
                return dispName;
            }

            set
            {
                dispName = value;
            }
        }

        #endregion

        #region Constructor
        public Contacts(string id, string name, string surname, string gender, int age, string phone, string email,
            string address, string nickName, int level, bool status):base(id, name, surname, gender, age, phone, email, address)
        {
            this.Identifier = id;
            this.Name = name;
            this.Surname = surname;
            this.Gender = gender;
            this.Age = age;
            this.Phone = phone;
            this.Email = email;
            this.Address = address;
            this.DispName = nickName;
            this.Level = level;
            this.Membership = status;
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
