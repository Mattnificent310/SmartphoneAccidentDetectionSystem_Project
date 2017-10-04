using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPADSBO
{
    class Person : IPerson
    {
        private string identifier;
        private string name;
        private string surname;
        private string gender;
        private int age;
        private string phone;
        private string email;
        private string address;
        public string Identifier
        {
            get
            {
                return identifier;
            }

            set
            {
                identifier = (value ?? string.Empty).Trim();
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = (value ?? string.Empty).Trim();
            }
        }

        public string Surname
        {
            get
            {
                return surname;
            }

            set
            {
                surname = (value ?? string.Empty).Trim();
            }
        }

        public string Gender
        {
            get
            {
                return gender;
            }

            set
            {
                gender = (value ?? string.Empty).Trim();
            }
        }

        public int Age
        {
            get
            {
                return age;
            }

            set
            {
                age = value == 0 ? 18 : value;
            }
        }

        public string Phone
        {
            get
            {
                return phone;
            }

            set
            {
                phone = (value ?? string.Empty).Trim();
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = (value ?? string.Empty).Trim();
            }
        }

        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = (value ?? string.Empty).Trim();
            }
        }

        private Person()
        {

        }
        public Person(string id, string name, string surname, string gender, int age, string phone, string emal, string address)
        {
            this.Identifier = id;
            this.Name = name;
            this.Surname = surname;
            this.Gender = gender;
            this.Age = age;
            this.Phone = phone;
            this.Email = emal;
            this.Address = address;
        }
    }
}
