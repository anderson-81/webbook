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
    public partial class Create : System.Web.UI.Page
    {
        private int id;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Book";

            if (Request.IsAuthenticated)
            {
                if (!this.IsPostBack)
                {
                    Author author = Crud.GetAuthorByID(Int32.Parse(Request.QueryString["id"]));
                    if (author != null)
                    {
                        this.txtAuthorID.Text = author.Id.ToString();
                        this.id = author.Id;
                        this.txtArtisticName.Text = author.ArtisticName;
                        this.hpRetCreateBook.NavigateUrl = "~/Registration/Authors/Details.aspx?Id=" + id;
                        this.Reset();
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

        protected void Reset()
        {
            this.txtTitle.Text = "";
            this.txtISBN.Text = "";
            this.txtPages.Text = "";
            this.txtPrice.Text = "";
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                if (this.IsPostBack)
                {
                    if (Page.IsValid)
                    {
                        byte[] picture = new byte[this.upPictBook.PostedFile.ContentLength];
                        this.upPictBook.PostedFile.InputStream.Read(picture, 0, this.upPictBook.PostedFile.ContentLength);

                        int result = Crud.Insert_Book(this.txtTitle.Text, Int32.Parse(this.txtPages.Text), this.txtISBN.Text, Decimal.Parse(this.txtPrice.Text), Int32.Parse(this.txtAuthorID.Text), picture);
                        if (result == 1)
                        {
                            ShowModal("Information", "Registered successfully.");
                            this.Reset();
                        }
                        else
                        {
                            ShowModal("Error", "Error registering book.");
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


        protected void btnReset_Click(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                this.Reset();
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
    }
}