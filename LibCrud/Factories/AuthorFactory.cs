using LibCrud.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class AuthorFactory
{
    public enum OPTION { NAME, EMAIL };

    private Author Author
    {
        get;
        set;
    }

    public AuthorFactory()
    {
        this.Author = new Author();
    }

    public AuthorFactory(int id, string name, string email, DateTime birthday, char gender, string artisticName, string biography, byte[] picture)
    {
        this.Author = new Author()
        {
            Id = id,
            Name = name,
            Email = email,
            Gender = gender,
            Birthday = birthday,
            ArtisticName = artisticName,
            Biography = biography,
            Picture = picture
        };
    }

    public AuthorFactory(int id)
    {
        this.Author = new Author()
        {
            Id = id,
        };
    }

    public AuthorFactory(OPTION opc, string param)
    {
        this.Author = (opc == OPTION.NAME) ? new Author() { Name = param } : new Author() { Email = param };
    }

    public Author GetAuthor()
    {
        return this.Author;
    }
}
