using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibCrud;
using System.Globalization;
using System.Text;
using LibCrud.classes;
using WebBook.Services;

namespace WebBook.Registration.Books
{
    public partial class Edit : System.Web.UI.Page
    {
        private static int id_author;
        private static int id_book;
        private static string isbn_book;

        private Crud crud = null;
        private Modal modal = null;
        private Validation validation = null;
        private Convertion convertion = null;

        public Edit()
        {
            this.crud = Crud.getInstance();
            this.validation = Validation.getInstance(this);
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
                    AuthorBook authorBook = crud.GetBookByISBN(Request.QueryString["ISBN"].ToString());
                    if (authorBook != null)
                    {
                        id_author = authorBook.Author.Id;
                        this.txtAuthorID.Text = authorBook.Author.Id.ToString();
                        this.txtArtisticName.Text = authorBook.Author.ArtisticName;

                        id_book = authorBook.Book.Id;
                        this.txtTitle.Text = authorBook.Book.Title;
                        this.txtISBN.Text = authorBook.Book.Isbn;
                        isbn_book = authorBook.Book.Isbn;
                        this.txtPages.Text = authorBook.Book.Page.ToString();
                        this.txtPrice.Text = authorBook.Book.Price.ToString();

                        this.imgPicture.ImageUrl = this.convertion.ConvertByteToBase64(authorBook.Book.Picture); ;

                        this.hplnkRetDet.NavigateUrl = "../../Registration/Books/Details.aspx?ISBN=" + authorBook.Book.Isbn;
                    }
                    else
                    {
                        ShowModal("Information", "No author found with this id.");
                        Response.RedirectPermanent("../../Registration/Authors/Index.aspx");
                    }
                }
            }
            else
            {
                Response.RedirectPermanent("~/Account/Login.aspx");
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                if (this.IsPostBack)
                {
                    cvISBN.Enabled = false;

                    if (Page.IsValid)
                    {
                        int result = crud.Edit_Book(id_book, this.txtTitle.Text, Int32.Parse(this.txtPages.Text), isbn_book, Decimal.Parse(this.txtPrice.Text), (this.upPictBook.HasFile ? this.convertion.ConvertBase64ToByte(ref  this.upPictBook) : null));

                        if (result == 1)
                        {
                            ShowModal("Information", "Book edited successfully.");

                            if (this.upPictBook.HasFile)
                            {
                                this.imgPicture.ImageUrl = this.convertion.ConvertByteToBase64(upPictBook.FileBytes);
                            }
                        }
                        else
                        {
                            ShowModal("Error", "Error editing the book.");
                        }
                    }
                }
            }
            else
            {
                Response.RedirectPermanent("~/Account/Login.aspx");
            }
        }

        private void ShowModal(string title, string message)
        {
            this.modal.ShowModal(title, message);
        }

        protected void txtPages_TextChanged(object sender, EventArgs e)
        {
            try
            {
                UInt32.Parse(this.txtPages.Text);
            }
            catch (Exception)
            {
                this.txtPages.Text = "";
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                if (this.IsPostBack)
                {
                    int result = crud.Delete_Book(id_book);
                    if (result == 1)
                    {
                        Response.RedirectPermanent("../../Registration/Authors/Details.aspx?Id=" + id_author);
                        ShowModal("Information", "Book deleted successfully.");
                    }
                    else
                    {
                        ShowModal("Error", "Error deleting the book.");
                    }
                }
            }
            else
            {
                Response.RedirectPermanent("~/Account/Login.aspx");
            }
        }

        #region Validators
        protected void ValidateISBN(object source, ServerValidateEventArgs args)
        {
            this.validation.ValidateISBN(source, args);
        }

        protected void ValidatePages(object source, ServerValidateEventArgs args)
        {
            this.validation.ValidatePages(source, args);
        }

        protected void ValidatePrice(object source, ServerValidateEventArgs args)
        {
            this.validation.ValidatePrice(source, args);
        }
        #endregion
    }
}