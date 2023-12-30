using LibCrud.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class BookFactory
{
    private Book Book
    {
        get;
        set;
    }

    public enum OPTION { TITLE, ISBN };

    public BookFactory()
    {
        this.Book = new Book();
    }

    public BookFactory(int id, string title, int page, string isbn, decimal price, byte[] picture)
    {
        this.Book = new Book()
        {
            Id = id,
            Title = title,
            Page = page,
            Isbn = isbn,
            Price = price,
            Picture = picture
        };
    }

    public BookFactory(int id)
    {
        this.Book = new Book()
        {
            Id = id,
        };
    }

    public BookFactory(OPTION opc, string param)
    {
        this.Book = (opc == OPTION.TITLE) ? new Book() { Title = param } : new Book() { Isbn = param };
    }

    public Book GetBook()
    {
        return this.Book;
    }
}
