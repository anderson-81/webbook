using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibCrud.classes
{
    public class Book
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        private int page;

        public int Page
        {
            get { return page; }
            set { page = value; }
        }
        private string isbn;

        public string Isbn
        {
            get { return isbn; }
            set { isbn = value; }
        }
        private decimal price;

        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        private byte[] picture;
        public byte[] Picture
        {
            get { return picture; }
            set { picture = value; }
        }
    }
}
