using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibCrud.classes
{
    interface IPerson
    {
        int Id
        {
            get;
            set;
        }

        string Name
        {
            get;
            set;
        }

        string Email
        {
            get;
            set;
        }

        DateTime Birthday
        {
            get;
            set;
        }

        char Gender
        {
            get;
            set;
        }

        byte[] Picture
        {
            get;
            set;
        }
    }
}
