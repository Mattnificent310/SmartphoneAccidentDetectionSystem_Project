using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPADSBO
{
    class Responder : Person
    {
        #region Fields
        private bool responderStatus;
        private int responderExperience;
        #endregion


        #region Properties
        public bool ResponderStatus
        {
            get
            {
                return responderStatus;
            }

            set
            {
                responderStatus = value;
            }
        }

        public int ResponderExperience
        {
            get
            {
                return responderExperience;
            }

            set
            {
                responderExperience = value;
            }
        }

        #endregion

        #region Constructor
        public Responder(string id, string name, string surname, string gender, int age, string phone, string email, 
            string address, bool status, int respExp):base(id, name, surname, gender, age, phone, email, address)
        {
            this.Identifier = id;
            this.Name = name;
            this.Surname = surname;
            this.Gender = gender;
            this.Age = age;
            this.Phone = phone;
            this.Email = email;
            this.Address = address;
            this.ResponderStatus = status;
            this.ResponderExperience = respExp;
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
