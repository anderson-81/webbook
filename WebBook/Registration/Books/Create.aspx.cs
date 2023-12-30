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
    public partial class Create : System.Web.UI.Page
    {
        private int id;
        private Crud crud = null;
        private Modal modal = null;
        private Convertion convertion = null;
        private Validation validation = null;

        public Create()
        {
            this.crud = Crud.getInstance();
            this.convertion = Convertion.getInstance();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Book";

            this.modal = Modal.getInstance(this);
            this.validation = Validation.getInstance(this);

            if (Request.IsAuthenticated)
            {
                if (!this.IsPostBack)
                {
                    Author author = crud.GetAuthorByID(Int32.Parse(Request.QueryString["id"]));
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
                        Response.RedirectPermanent("Authors/Search.aspx");
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
            this.txtISBN.Text = "";
            this.txtPages.Text = "";
            this.txtTitle.Text = "";
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                if (this.IsPostBack)
                {
                    if (Page.IsValid)
                    {
                        int result = crud.Insert_Book(this.txtTitle.Text, Int32.Parse(this.txtPages.Text), this.txtISBN.Text, Decimal.Parse(this.txtPrice.Text), Int32.Parse(this.txtAuthorID.Text), this.convertion.ConvertBase64ToByte(ref upPictBook));
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

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.RedirectPermanent("~/Registration/Books/Create.aspx?Id=" + this.id);
        }
    }
}