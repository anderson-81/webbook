using LibCrud.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class AuthorBookFactory
{
    private AuthorBook AuthorBook
    {
        get;
        set;
    }

    public AuthorBookFactory(Author author, Book book)
    {
        this.AuthorBook = new AuthorBook()
        {
            Author = author,
            Book = book
        };
    }

    public AuthorBook GetAuthorBook()
    {
        return this.AuthorBook;
    }
}

