using LibCrud;
using LibCrud.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebBook.Services;

namespace WebBook.Registration.Books
{
    public partial class Details : System.Web.UI.Page
    {
        private static int id;
        private static string isbn;

        private Crud crud = null;
        private Modal modal = null;
        private Convertion convertion = null;

        public Details()
        {
            this.crud = Crud.getInstance();
            this.convertion = Convertion.getInstance();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Book";

            this.modal = Modal.getInstance(this);

            if (Request.IsAuthenticated)
            {
                if (!this.IsPostBack)
                {
                    AuthorBook authorBook = crud.GetBookByISBN(Request.QueryString["ISBN"]);
                    if (authorBook != null)
                    {
                        id = authorBook.Author.Id;
                        this.lblArtisticName.Text = authorBook.Author.ArtisticName;
                   
                        /************************************************/

                        this.lblTitle.Text = authorBook.Book.Title;
                        isbn = authorBook.Book.Isbn;
                        this.lblISBN.Text = authorBook.Book.Isbn;
                        this.lblPage.Text = authorBook.Book.Page.ToString();
                        this.lblPrice.Text = authorBook.Book.Price.ToString();

                        this.imgPictureBookDetail.ImageUrl = this.convertion.ConvertByteToBase64(authorBook.Book.Picture);

                        this.hplnkRetDet.NavigateUrl = "../../Registration/Authors/Details.aspx?Id=" + id;
                        this.hplnkEditDet.NavigateUrl = "../../Registration/Books/Edit.aspx?ISBN=" + isbn;

                        /************************************************/
                    }
                    else
                    {
                        Response.RedirectPermanent("Authors/Index.aspx");
                    }
                }
            }
            else
            {
                Response.RedirectPermanent("~/Account/Login.aspx");
            }
        }

        private void ShowModal(string title, string message, int opc)
        {
            this.modal.ShowModal(title, message);
        }
    }
}