using LibCrud.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibCrud
{
    public class Crud
    {
        private static Crud _instance = null;

        public static Crud getInstance()
        {
            if (_instance == null)
            {
                _instance = new Crud();
            }
            return _instance;
        }

        public int Insert_Author(string name, string email, DateTime birthday, char gender, string artisctName, string biography, byte[] picture)
        {
            return new Controller(new AuthorFactory(0, name, email, birthday, gender, artisctName, biography, picture).GetAuthor()).Insert_Author();
        }

        public int Edit_Author(int id, string name, string email, DateTime birthday, char gender, string artisctName, string biography, byte[] picture)
        {
            return new Controller(new AuthorFactory(id, name, email, birthday, gender, artisctName, biography, picture).GetAuthor()).Edit_Author();
        }

        public int Delete_Author(int id)
        {
            return new Controller(new AuthorFactory(id).GetAuthor()).Delete_Author();
        }

        public int Insert_Book(string title, int page, string isbn, decimal price, int author_id, byte[] picture)
        {
            return new Controller(new AuthorFactory(author_id).GetAuthor(), new BookFactory(0, title, page, isbn, price, picture).GetBook()).Insert_Book();
        }

        public int Edit_Book(int id, string title, int page, string isbn, decimal price, byte[] picture)
        {
            return new Controller(new BookFactory(id, title, page, isbn, price, picture).GetBook()).Edit_Book();
        }

        public int Delete_Book(int id)
        {
            return new Controller(new BookFactory(id).GetBook()).Delete_Book();
        }

        public Author GetAuthorByID(int id)
        {
            return new Controller(new AuthorFactory(id).GetAuthor()).GetAuthorByID();
        }
        public List<Author> GetAuthorByName(string name)
        {
            return new Controller(new AuthorFactory(AuthorFactory.OPTION.NAME, name).GetAuthor()).GetAuthorByName();
        }

        public List<Book> GetBookByAuthorID(int id)
        {
            return new Controller(new AuthorFactory(id).GetAuthor()).GetBookByAuthorID();
        }

        public AuthorBook GetBookByISBN(string isbn)
        {
            return new Controller(new BookFactory(BookFactory.OPTION.ISBN, isbn).GetBook()).GetBookByISBN();
        }

        public List<AuthorBook> GetBookByTitle(string title)
        {
            return new Controller(new BookFactory(BookFactory.OPTION.TITLE, title).GetBook()).GetBookByTitle();
        }

        public bool CheckIfEmailAreRegistered(string email)
        {
            return new Controller(new AuthorFactory(AuthorFactory.OPTION.EMAIL, email).GetAuthor()).CheckIfEmailAreRegistered();
        }

        public bool CheckIfISBNAreRegistered(string isbn)
        {
            return new Controller(new BookFactory(BookFactory.OPTION.ISBN, isbn).GetBook()).CheckIfISBNAreRegistered();
        }
    }
}
