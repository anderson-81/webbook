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

namespace WebBook.Registration.Books
{
    public partial class Edit : System.Web.UI.Page
    {
        private static int id_author;
        private static int id_book;
        private static string isbn_book;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Book";

            if (Request.IsAuthenticated)
            {
                if (!this.IsPostBack)
                {
                    AuthorBook authorBook = Crud.GetBookByISBN(Request.QueryString["ISBN"].ToString());
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

                        var base64 = Convert.ToBase64String(authorBook.Book.Picture);
                        var imgSrc = String.Format("data:image/gif;base64,{0}", base64);
                        this.hpCurrImage.NavigateUrl = imgSrc;

                        this.hplnkRetDet.NavigateUrl = "../../Registration/Books/Details.aspx?ISBN=" + authorBook.Book.Isbn;
                    }
                    else
                    {
                        ShowModal("Information", "No author found with this id.");
                        Response.Redirect("Authors/Search.aspx");
                    }
                }
            }
            else
            {
                Response.Redirect("~/Account/Login.aspx");
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                if (this.IsPostBack)
                {
                    if (Page.IsValid)
                    {
                        byte[] picture = null;

                        if (this.upPictBook.HasFile)
                        {
                            picture = new byte[this.upPictBook.PostedFile.ContentLength];
                            this.upPictBook.PostedFile.InputStream.Read(picture, 0, this.upPictBook.PostedFile.ContentLength);
                        }


                        int result = Crud.Edit_Book(id_book, this.txtTitle.Text, Int32.Parse(this.txtPages.Text), this.txtISBN.Text, Decimal.Parse(this.txtPrice.Text), picture);
                        if (result == 1)
                        {
                            ShowModal("Information", "Book edited successfully.");
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
                Response.Redirect("~/Account/Login.aspx");
            }
        }

        protected void ValidateISBN(object source, ServerValidateEventArgs args)
        {
            if (this.txtISBN.Text != isbn_book)
            {
                this.cvISBN.ErrorMessage = "";

                if (args.Value.Length == 13)
                {
                    try
                    {
                        long.Parse(args.Value);

                        if (!Crud.CheckRegisteredISBN(this.txtISBN.Text))
                        {
                            args.IsValid = true;
                        }
                        else
                        {
                            this.cvISBN.ErrorMessage = "This ISBN is already registered.";
                            args.IsValid = false;
                        }
                    }
                    catch (Exception)
                    {
                        this.cvISBN.ErrorMessage = "Invalid ISBN. Only numbers.";
                        args.IsValid = false;
                    }
                }
                else
                {
                    this.cvISBN.ErrorMessage = "ISBN must have 13 digits.";
                    args.IsValid = false;
                }
            }
        }

        protected void ValidatePages(object source, ServerValidateEventArgs args)
        {
            cvPages.ErrorMessage = "";

            try
            {
                Int32.Parse(args.Value);

                if (Int32.Parse(args.Value) >= 1)
                {
                    args.IsValid = true;
                }
                else
                {
                    cvPages.ErrorMessage = "Number pages under of 1.";
                    args.IsValid = false;
                }
            }
            catch (Exception)
            {
                cvPages.ErrorMessage = "Invalid number pages.";
                args.IsValid = false;
            }
        }

        protected void ValidatePrice(object source, ServerValidateEventArgs args)
        {
            cvPrice.ErrorMessage = "";

            try
            {
                decimal.Parse(args.Value);

                if (decimal.Parse(args.Value) >= 0)
                {
                    args.IsValid = true;
                }
                else
                {
                    cvPrice.ErrorMessage = "Price under of 0.";
                    args.IsValid = false;
                }
            }
            catch (Exception)
            {
                cvPrice.ErrorMessage = "Invalid price.";
                args.IsValid = false;
            }
        }

        private void ShowModal(string title, string message)
        {
            Response.Write("<script   src='https://code.jquery.com/jquery-2.2.4.min.js'   integrity='sha256-BbhdlvQf/xTY9gja0Dq3HiwQF8LaCRTXxZKRutelT44='   crossorigin='anonymous'></script>     <link href='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css' rel='stylesheet' integrity='sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u' crossorigin='anonymous'>     <script src='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js' integrity='sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa' crossorigin='anonymous'></script><div id='modalMessage' class='modal fade' role='dialog'><div class='modal-dialog'><div class='modal-content'><div class='modal-header'><button type='button' class='close' data-dismiss='modal'>&times;</button><h4 class='modal-title' id='titleMsg'></h4></div><div class='modal-body'><p id='msgMsg'></p></div><div class='modal-footer'><button type='button' class='btn btn-default btn-primary' data-dismiss='modal'>Ok</button></div></div></div></div><script>$('#titleMsg').text('" + title + "');$('#msgMsg').text('" + message + "');$('#modalMessage').modal('show');</script>");
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
                    int result = Crud.Delete_Book(id_book);
                    if (result == 1)
                    {
                        ShowModal("Information", "Book deleted successfully.");
                        Response.Redirect("../../Registration/Authors/Details.aspx?Id=" + id_author);
                    }
                    else
                    {
                        ShowModal("Error", "Error deleting the book.");
                    }
                }
            }
            else
            {
                Response.Redirect("~/Account/Login.aspx");
            }
        }
    }
}