using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibCrud.classes
{
    public class AuthorBook
    {
        private Book book;

        public Book Book
        {
            get { return book; }
            set { book = value; }
        }
        private Author author;

        public Author Author
        {
            get { return author; }
            set { author = value; }
        }
    }
}
