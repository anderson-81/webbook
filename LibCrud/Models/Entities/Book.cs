using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibCrud.classes
{
    public class Book
    {
        public int Id
        {
            get;
            set;
        }
        
        public string Title
        {
            get;
            set;
        }
        
        public int Page
        {
            get;
            set;
        }
        
        public string Isbn
        {
            get;
            set;
        }
        
        public decimal Price
        {
            get;
            set;
        }

        public byte[] Picture
        {
            get;
            set;
        }
    }
}
