using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibCrud.classes
{
    public class Author : IPerson
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        private DateTime birthday;

        public DateTime Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }
        private char gender;

        public char Gender
        {
            get { return gender; }
            set { gender = value; }
        }
        private string artisticName;

        public string ArtisticName
        {
            get { return artisticName; }
            set { artisticName = value; }
        }
        private string biography;

        public string Biography
        {
            get { return biography; }
            set { biography = value; }
        }

        private byte[] picture;
                public byte[] Picture
        {
            get { return picture; }
            set { picture = value; }
        }
    }
}
