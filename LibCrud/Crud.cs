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
        public static int Insert_Author(string name, string email, DateTime birthday, char gender, string artisctName, string biography, byte[] picture)
        {
            Author author = new Author();
            author.Name = name;
            author.Email = email;
            author.Birthday = birthday;
            author.Gender = gender;
            author.ArtisticName = artisctName;
            author.Biography = biography;
            author.Picture = picture;
            Controller ctr = new Controller(author);
            return ctr.Insert_Author();
        }

        public static int Edit_Author(int id, string name, string email, DateTime birthday, char gender, string artisctName, string biography, byte[] picture)
        {
            Author author = new Author();
            author.Id = id;
            author.Name = name;
            author.Email = email;
            author.Birthday = birthday;
            author.Gender = gender;
            author.ArtisticName = artisctName;
            author.Biography = biography;
            author.Picture = picture;
            Controller ctr = new Controller(author);
            return ctr.Edit_Author();
        }

        public static int Delete_Author(int id)
        {
            Author author = new Author();
            author.Id = id;
            Controller ctr = new Controller(author);
            return ctr.Delete_Author();
        }

        public static int Insert_Book(string title, int page, string isbn, decimal price, int author_id, byte[] picture)
        {
            Book book = new Book();
            book.Title = title;
            book.Page = page;
            book.Isbn = isbn;
            book.Price = price;
            book.Picture = picture;
            Author author = new Author();
            author.Id = author_id;
            Controller ctr = new Controller(author, book);
            return ctr.Insert_Book();
        }

        public static int Edit_Book(int id, string title, int page, string isbn, decimal price, byte[] picture)
        {
            Book book = new Book();
            book.Id = id;
            book.Title = title;
            book.Page = page;
            book.Isbn = isbn;
            book.Price = price;
            book.Picture = picture;
            Controller ctr = new Controller(book);
            return ctr.Edit_Book();
        }

        public static int Delete_Book(int id)
        {
            Book book = new Book();
            book.Id = id;
            Controller ctr = new Controller(book);
            return ctr.Delete_Book();
        }

        public static Author GetAuthorByID(int id)
        {
            Author author = new Author();
            author.Id = id;
            Controller ctr = new Controller(author);
            return ctr.GetAuthorByID();
        }
        public static List<Author> GetAuthorByName(string name)
        {
            Author author = new Author();
            author.Name = name;
            Controller ctr = new Controller(author);
            return ctr.GetAuthorByName();
        }

        public static List<Book> GetBookByAuthorID(int id)
        {
            Author author = new Author();
            author.Id = id;
            Controller ctr = new Controller(author);
            return ctr.GetBookByAuthorID();
        }


        public static AuthorBook GetBookByISBN(string isbn)
        {
            Book book = new Book();
            book.Isbn = isbn;
            Controller ctr = new Controller(book);
            return ctr.GetBookByISBN();
        }

        public static List<AuthorBook> GetBookByTitle(string title)
        {
            Book book = new Book();
            book.Title = title;
            Controller ctr = new Controller(book);
            return ctr.GetBookByTitle();
        }
        public static bool CheckRegisteredEmail(string email)
        {
            Author author = new Author();
            author.Email = email;
            Controller ctr = new Controller(author);
            return ctr.CheckRegisteredEmail();
        }
        public static bool CheckRegisteredISBN(string isbn)
        {
            Book book = new Book();
            book.Isbn = isbn;
            Controller ctr = new Controller(book);
            return ctr.CheckRegisteredISBN();
        }
    }
}
