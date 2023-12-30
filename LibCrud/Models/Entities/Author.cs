using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibCrud.classes
{
    public class Author : IPerson
    {
        public int Id
        {
            get;
            set;
        }
        
        public string Name
        {
            get;
            set;
        }
        
        public string Email
        {
            get;
            set;
        }
        
        public DateTime Birthday
        {
            get;
            set;
        }
        
        public char Gender
        {
            get;
            set;
        }
        
        public string ArtisticName
        {
            get;
            set;
        }
        
        public string Biography
        {
            get;
            set;
        }

        public byte[] Picture
        {
            get;
            set;
        }

        public Author()
        {

        }
    }
}
