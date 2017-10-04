using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPADSBO
{
    interface IPerson
    {
        string Name { get; set; }
        string Surname { get; set; }
        string Gender { get; set; }
        int Age { get; set; }
        string Phone { get; set; }
        string Email { get; set; }
       
     
    }
}
