using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibCrud.classes
{
    public class AuthorBook
    {
        public Book Book
        {
            get;
            set;
        }
        
        public Author Author
        {
            get;
            set;
        }
    }
}
