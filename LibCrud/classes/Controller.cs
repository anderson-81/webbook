using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibCrud.classes
{
    public class Controller
    {
        private SqlConnection conn;
        private Author author;
        private Book book;
        private SqlCommand cmd;

        #region Constructors
        public Controller()
        {
            this.conn = Connection.Connect();
        }

        public Controller(Author author)
        {
            this.conn = Connection.Connect();
            this.author = author;
        }

        public Controller(Book book)
        {
            this.conn = Connection.Connect();
            this.book = book;
        }

        public Controller(Author author, Book book)
        {
            this.conn = Connection.Connect();
            this.author = author;
            this.book = book;
        }
        #endregion

        #region TABLES

        #region AUTHOR
        private int GenerateIDPerson()
        {
            try
            {
                this.cmd.CommandText = "SELECT ISNULL(MAX(ID) + 1, 1) FROM PERSON;";
                return (int)this.cmd.ExecuteScalar();
            }
            catch (Exception)
            {
                return 0;
            }
        }

        private int InsertPerson(int id, string name, string email, DateTime birthday, char gender, byte[] picture)
        {
            try
            {
                this.cmd.CommandText = "INSERT INTO PERSON VALUES(@id, @name, @email, @birthday, @gender, @picture)";
                this.cmd.Parameters.Add("id", System.Data.SqlDbType.Int);
                this.cmd.Parameters["id"].Value = id;
                this.cmd.Parameters.Add("name", System.Data.SqlDbType.NVarChar);
                this.cmd.Parameters["name"].Value = name;
                this.cmd.Parameters.Add("email", System.Data.SqlDbType.NVarChar);
                this.cmd.Parameters["email"].Value = email;
                this.cmd.Parameters.Add("birthday", System.Data.SqlDbType.Date);
                this.cmd.Parameters["birthday"].Value = birthday;
                this.cmd.Parameters.Add("gender", System.Data.SqlDbType.Char);
                this.cmd.Parameters["gender"].Value = gender;
                this.cmd.Parameters.Add("picture", System.Data.SqlDbType.VarBinary);
                this.cmd.Parameters["picture"].Value = picture;
                this.cmd.ExecuteNonQuery();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        private int EditPerson(int id, string name, string email, DateTime birthday, char gender, byte[] picture)
        {
            try
            {
                if(picture != null)
                {
                    this.cmd.CommandText = "UPDATE PERSON SET NAME = @name, EMAIL = @email, BIRTHDAY = @birthday, GENDER = @gender, PICTURE = @picture WHERE ID = @id";
                    this.cmd.Parameters.Add("picture", System.Data.SqlDbType.VarBinary);
                    this.cmd.Parameters["picture"].Value = picture;
                }
                else
                {
                    this.cmd.CommandText = "UPDATE PERSON SET NAME = @name, EMAIL = @email, BIRTHDAY = @birthday, GENDER = @gender WHERE ID = @id";
                }
                
                this.cmd.Parameters.Add("id", System.Data.SqlDbType.Int);
                this.cmd.Parameters["id"].Value = id;
                this.cmd.Parameters.Add("name", System.Data.SqlDbType.NVarChar);
                this.cmd.Parameters["name"].Value = name;
                this.cmd.Parameters.Add("email", System.Data.SqlDbType.NVarChar);
                this.cmd.Parameters["email"].Value = email;
                this.cmd.Parameters.Add("birthday", System.Data.SqlDbType.Date);
                this.cmd.Parameters["birthday"].Value = birthday;
                this.cmd.Parameters.Add("gender", System.Data.SqlDbType.Char);
                this.cmd.Parameters["gender"].Value = gender;
                this.cmd.ExecuteNonQuery();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        private int DeletePerson()
        {
            try
            {
                this.cmd.CommandText = "DELETE FROM PERSON WHERE ID = @id";
                this.cmd.ExecuteNonQuery();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        private int InsertAuthor()
        {
            try
            {
                this.cmd.CommandText = "INSERT INTO AUTHOR VALUES(@id, @id, @artisticName, @biography)";
                this.cmd.Parameters.Add("artisticName", System.Data.SqlDbType.NVarChar);
                this.cmd.Parameters["artisticName"].Value = author.ArtisticName;
                this.cmd.Parameters.Add("biography", System.Data.SqlDbType.NVarChar);
                this.cmd.Parameters["biography"].Value = author.Biography;
                this.cmd.ExecuteNonQuery();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        private int EditAuthor()
        {
            try
            {
                this.cmd.CommandText = "UPDATE AUTHOR SET ARTISTICNAME = @artisticName, BIOGRAPHY = @biography WHERE ID = @id";
                this.cmd.Parameters.Add("artisticName", System.Data.SqlDbType.NVarChar);
                this.cmd.Parameters["artisticName"].Value = author.ArtisticName;
                this.cmd.Parameters.Add("biography", System.Data.SqlDbType.NVarChar);
                this.cmd.Parameters["biography"].Value = author.Biography;
                this.cmd.ExecuteNonQuery();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        private int DeleteAuthor()
        {
            try
            {
                this.cmd.CommandText = "DELETE FROM AUTHOR WHERE ID = @id";
                this.cmd.Parameters.Add("id", System.Data.SqlDbType.Int);
                this.cmd.Parameters["id"].Value = author.Id;
                this.cmd.ExecuteNonQuery();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }
        #endregion

        #region BOOK
        private int GenerateIDBook()
        {
            try
            {
                this.cmd.CommandText = "SELECT ISNULL(MAX(ID)+1, 1) FROM BOOK";
                return (int)this.cmd.ExecuteScalar();
            }
            catch (Exception)
            {
                return 0;
            }
        }

        private int InsertBook()
        {
            try
            {
                this.cmd.CommandText = "INSERT INTO BOOK VALUES(@id, @author_id, @title, @isbn, @page, @price, @picture)";
                this.cmd.Parameters.Add("id", System.Data.SqlDbType.Int);
                this.cmd.Parameters["id"].Value = book.Id;
                this.cmd.Parameters.Add("author_id", System.Data.SqlDbType.Int);
                this.cmd.Parameters["author_id"].Value = author.Id;
                this.cmd.Parameters.Add("title", System.Data.SqlDbType.NVarChar);
                this.cmd.Parameters["title"].Value = book.Title;
                this.cmd.Parameters.Add("page", System.Data.SqlDbType.Int);
                this.cmd.Parameters["page"].Value = book.Page;
                this.cmd.Parameters.Add("isbn", System.Data.SqlDbType.NVarChar);
                this.cmd.Parameters["isbn"].Value = book.Isbn;
                this.cmd.Parameters.Add("price", System.Data.SqlDbType.Decimal);
                this.cmd.Parameters["price"].Value = book.Price;
                this.cmd.Parameters.Add("picture", System.Data.SqlDbType.VarBinary);
                this.cmd.Parameters["picture"].Value = book.Picture;
                this.cmd.ExecuteNonQuery();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        private int EditBook()
        {
            try
            {
                if(this.book.Picture != null)
                {
                    this.cmd.CommandText = "UPDATE BOOK SET TITLE = @title, PAGES= @page, ISBN = @isbn, PRICE = @price, PICTURE = @picture WHERE ID = @id";
                    this.cmd.Parameters.Add("picture", System.Data.SqlDbType.VarBinary);
                    this.cmd.Parameters["picture"].Value = book.Picture;
                }
                else
                {
                    this.cmd.CommandText = "UPDATE BOOK SET TITLE = @title, PAGES= @page, ISBN = @isbn, PRICE = @price WHERE ID = @id";
                }
                
                this.cmd.Parameters.Add("id", System.Data.SqlDbType.Int);
                this.cmd.Parameters["id"].Value = book.Id;
                this.cmd.Parameters.Add("title", System.Data.SqlDbType.NVarChar);
                this.cmd.Parameters["title"].Value = book.Title;
                this.cmd.Parameters.Add("page", System.Data.SqlDbType.Int);
                this.cmd.Parameters["page"].Value = book.Page;
                this.cmd.Parameters.Add("isbn", System.Data.SqlDbType.NVarChar);
                this.cmd.Parameters["isbn"].Value = book.Isbn;
                this.cmd.Parameters.Add("price", System.Data.SqlDbType.Decimal);
                this.cmd.Parameters["price"].Value = book.Price;
                this.cmd.ExecuteNonQuery();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        private int DeleteBook()
        {
            try
            {
                this.cmd.CommandText = "DELETE FROM BOOK WHERE ID = @id";
                this.cmd.Parameters.Add("id", System.Data.SqlDbType.Int);
                this.cmd.Parameters["id"].Value = book.Id;
                this.cmd.ExecuteNonQuery();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }

        }
        #endregion

        #endregion

        #region Transactions

        #region Author
        public int Insert_Author()
        {
            this.cmd = new SqlCommand();
            this.cmd.Connection = this.conn;
            this.cmd.Transaction = this.conn.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
            SqlTransaction trans = this.cmd.Transaction;

            int id = this.GenerateIDPerson();

            if (id > 0)
            {
                this.author.Id = id;
                if (this.InsertPerson(this.author.Id, this.author.Name, this.author.Email, this.author.Birthday, this.author.Gender, this.author.Picture) == 1)
                {
                    if (this.InsertAuthor() == 1)
                    {
                        trans.Commit();
                        return 1;
                    }
                    else
                    {
                        trans.Rollback();
                        return -1;
                    }
                }
                else
                {
                    trans.Rollback();
                    return -1;
                }
            }
            return -1;
        }

        public int Edit_Author()
        {
            this.cmd = new SqlCommand();
            this.cmd.Connection = this.conn;
            this.cmd.Transaction = this.conn.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
            SqlTransaction trans = this.cmd.Transaction;

            if (this.EditPerson(this.author.Id, this.author.Name, this.author.Email, this.author.Birthday, this.author.Gender, this.author.Picture) == 1)
            {
                if (this.EditAuthor() == 1)
                {
                    trans.Commit();
                    return 1;
                }
                else
                {
                    trans.Rollback();
                    return -1;
                }
            }
            else
            {
                trans.Rollback();
                return -1;
            }
        }

        public int Delete_Author()
        {
            this.cmd = new SqlCommand();
            this.cmd.Connection = this.conn;
            this.cmd.Transaction = this.conn.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
            SqlTransaction trans = this.cmd.Transaction;

            if (this.DeleteAuthor() == 1)
            {
                if (this.DeletePerson() == 1)
                {
                    trans.Commit();
                    return 1;
                }
                else
                {
                    trans.Rollback();
                    return -1;
                }
            }
            else
            {
                trans.Rollback();
                return -1;
            }
        }
        #endregion

        #region Book
        public int Insert_Book()
        {
            this.cmd = new SqlCommand();
            this.cmd.Connection = this.conn;
            this.cmd.Transaction = this.conn.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
            SqlTransaction trans = this.cmd.Transaction;

            int id = this.GenerateIDBook();

            if (id > 0)
            {
                this.book.Id = id;
                if (this.InsertBook() == 1)
                {
                    trans.Commit();
                    return 1;
                }
                else
                {
                    trans.Rollback();
                    return -1;
                }
            }
            return -1;
        }

        public int Edit_Book()
        {
            this.cmd = new SqlCommand();
            this.cmd.Connection = this.conn;
            this.cmd.Transaction = this.conn.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
            SqlTransaction trans = this.cmd.Transaction;

            if (this.EditBook() == 1)
            {
                trans.Commit();
                return 1;
            }
            else
            {
                trans.Rollback();
                return -1;
            }
        }

        public int Delete_Book()
        {
            this.cmd = new SqlCommand();
            this.cmd.Connection = this.conn;
            this.cmd.Transaction = this.conn.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
            SqlTransaction trans = this.cmd.Transaction;

            if (this.DeleteBook() == 1)
            {
                trans.Commit();
                return 1;
            }
            else
            {
                trans.Rollback();
                return -1;
            }
        }
        #endregion

        #region QUERYS

        #region AUTHORS

        public Author GetAuthorByID()
        {
            try
            {
                this.cmd = new SqlCommand();
                this.cmd.Connection = this.conn;
                this.cmd.CommandText = "SELECT * FROM AUTHOR INNER JOIN PERSON ON PERSON.ID = AUTHOR.PERSON_ID WHERE AUTHOR.ID = @id";
                this.cmd.Parameters.Add("id", System.Data.SqlDbType.Int);
                this.cmd.Parameters["id"].Value = author.Id;
                SqlDataReader sqr = this.cmd.ExecuteReader();
                if (sqr.HasRows)
                {
                    Author _author = new Author();
                    sqr.Read();
                    _author.Id = sqr.GetInt32(0);
                    _author.ArtisticName = sqr.GetString(2);
                    _author.Biography = sqr.GetString(3);
                    _author.Name = sqr.GetString(5);
                    _author.Email = sqr.GetString(6);
                    _author.Birthday = sqr.GetDateTime(7);
                    _author.Gender = sqr.GetString(8)[0];
                    _author.Picture = (byte[])sqr[9];
                    return _author;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Author> GetAuthorByName()
        {
            try
            {
                this.cmd = new SqlCommand();
                this.cmd.Connection = this.conn;
                StringBuilder sql = new StringBuilder();
                sql.Append("SELECT * FROM AUTHOR INNER JOIN PERSON ON PERSON.ID = AUTHOR.PERSON_ID ");
                sql.Append("WHERE PERSON.NAME LIKE @name + '%' OR AUTHOR.ARTISTICNAME LIKE @name + '%'; ");
                this.cmd.CommandText = sql.ToString();
                this.cmd.Parameters.Add("name", System.Data.SqlDbType.NVarChar);
                this.cmd.Parameters["name"].Value = author.Name;
                SqlDataReader sqr = this.cmd.ExecuteReader();
                if (sqr.HasRows)
                {
                    List<Author> authors = new List<Author>();
                    while (sqr.Read())
                    {
                        Author _author = new Author();
                        _author.Id = sqr.GetInt32(0);
                        _author.ArtisticName = sqr.GetString(2);
                        _author.Biography = sqr.GetString(3);
                        _author.Name = sqr.GetString(5);
                        _author.Email = sqr.GetString(6);
                        _author.Birthday = sqr.GetDateTime(7);
                        _author.Gender = sqr.GetString(8)[0];
                        _author.Picture = (byte[])sqr[9];
                        authors.Add(_author);
                        _author = null;
                    }
                    return authors;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool CheckRegisteredEmail()
        {
            try
            {
                this.cmd = new SqlCommand();
                this.cmd.Connection = this.conn;
                StringBuilder sql = new StringBuilder();
                sql.Append("SELECT * FROM PERSON WHERE PERSON.EMAIL = @email");
                this.cmd.CommandText = sql.ToString();
                this.cmd.Parameters.Add("email", System.Data.SqlDbType.NVarChar);
                this.cmd.Parameters["email"].Value = author.Email;
                SqlDataReader sqr = this.cmd.ExecuteReader();
                if (sqr.HasRows)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion

        #region BOOKS

        public AuthorBook GetBookByISBN()
        {
            try
            {
                this.cmd = new SqlCommand();
                this.cmd.Connection = this.conn;
                StringBuilder sql = new StringBuilder();
                sql.Append("SELECT * FROM BOOK INNER JOIN AUTHOR ON BOOK.AUTHOR_ID = AUTHOR.ID ");
                sql.Append("INNER JOIN PERSON ON AUTHOR.PERSON_ID = PERSON.ID  ");
                sql.Append("WHERE ISBN = @isbn  ");
                this.cmd.CommandText = sql.ToString();
                this.cmd.Parameters.Add("isbn", System.Data.SqlDbType.NVarChar);
                this.cmd.Parameters["isbn"].Value = book.Isbn;
                SqlDataReader sqr = this.cmd.ExecuteReader();
                if (sqr.HasRows)
                {
                    AuthorBook authorBook = new AuthorBook();
                    sqr.Read();
                    Book _book = new Book();
                    _book.Id = sqr.GetInt32(0);
                    _book.Title = sqr.GetString(2);
                    _book.Isbn = sqr.GetString(3);
                    _book.Page = sqr.GetInt32(4);
                    _book.Price = sqr.GetDecimal(5);
                    _book.Picture = (byte[])sqr[6];

                    Author _author = new Author();
                    _author.Id = sqr.GetInt32(7);
                    _author.ArtisticName = sqr.GetString(9);
                    _author.Biography = sqr.GetString(10);
                    _author.Name = sqr.GetString(12);
                    _author.Email = sqr.GetString(13);
                    _author.Birthday = sqr.GetDateTime(14);
                    _author.Gender = sqr.GetString(15)[0];
                    _author.Picture = (byte[])sqr[16];

                    AuthorBook _authorBook = new AuthorBook();
                    _authorBook.Author = _author;
                    _authorBook.Book = _book;

                    return _authorBook;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<AuthorBook> GetBookByTitle()
        {
            try
            {
                this.cmd = new SqlCommand();
                this.cmd.Connection = this.conn;
                StringBuilder sql = new StringBuilder();
                sql.Append("SELECT * FROM BOOK INNER JOIN AUTHOR ON BOOK.AUTHOR_ID = AUTHOR.ID ");
                sql.Append("INNER JOIN PERSON ON AUTHOR.PERSON_ID = PERSON.ID  ");
                sql.Append("WHERE BOOK.TITLE LIKE @title + '%'; ");
                this.cmd.CommandText = sql.ToString();
                this.cmd.Parameters.Add("title", System.Data.SqlDbType.NVarChar);
                this.cmd.Parameters["title"].Value = book.Title;
                SqlDataReader sqr = this.cmd.ExecuteReader();
                if (sqr.HasRows)
                {
                    List<AuthorBook> authorBooks = new List<AuthorBook>();
                    while (sqr.Read())
                    {
                        Author _author = new Author();
                        _author.Id = sqr.GetInt32(6);
                        _author.ArtisticName = sqr.GetString(8);
                        _author.Biography = sqr.GetString(9);
                        _author.Name = sqr.GetString(11);
                        _author.Email = sqr.GetString(12);
                        _author.Birthday = sqr.GetDateTime(13);
                        _author.Gender = sqr.GetString(14)[0];

                        Book _book = new Book();
                        _book.Id = sqr.GetInt32(0);
                        _book.Title = sqr.GetString(2);
                        _book.Isbn = sqr.GetString(3);
                        _book.Page = sqr.GetInt32(4);
                        _book.Price = sqr.GetDecimal(5);

                        AuthorBook _authorBook = new AuthorBook();
                        _authorBook.Author = _author;
                        _authorBook.Book = _book;

                        authorBooks.Add(_authorBook);
                        _author = null;
                        _book = null;
                        _authorBook = null;
                    }
                    return authorBooks;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Book> GetBookByAuthorID()
        {
            try
            {
                this.cmd = new SqlCommand();
                this.cmd.Connection = this.conn;
                StringBuilder sql = new StringBuilder();
                sql.Append("SELECT * FROM BOOK INNER JOIN AUTHOR ON BOOK.AUTHOR_ID = AUTHOR.ID ");
                sql.Append("WHERE AUTHOR.ID = @id");
                this.cmd.CommandText = sql.ToString();
                this.cmd.Parameters.Add("id", System.Data.SqlDbType.Int);
                this.cmd.Parameters["id"].Value = author.Id;
                SqlDataReader sqr = this.cmd.ExecuteReader();
                if (sqr.HasRows)
                {
                    List<Book> books = new List<Book>();
                    while (sqr.Read())
                    {
                        Book _book = new Book();
                        _book.Id = sqr.GetInt32(0);
                        _book.Title = sqr.GetString(2);
                        _book.Isbn = sqr.GetString(3);
                        _book.Page = sqr.GetInt32(4);
                        _book.Price = sqr.GetDecimal(5);
                        books.Add(_book);
                        _book = null;
                    }
                    return books;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool CheckRegisteredISBN()
        {
            try
            {
                this.cmd = new SqlCommand();
                this.cmd.Connection = this.conn;
                StringBuilder sql = new StringBuilder();
                sql.Append("SELECT * FROM BOOK WHERE BOOK.ISBN = @isbn");
                this.cmd.CommandText = sql.ToString();
                this.cmd.Parameters.Add("isbn", System.Data.SqlDbType.NVarChar);
                this.cmd.Parameters["isbn"].Value = book.Isbn;
                SqlDataReader sqr = this.cmd.ExecuteReader();
                if (sqr.HasRows)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion

        #endregion

        #endregion

       
    }
}
