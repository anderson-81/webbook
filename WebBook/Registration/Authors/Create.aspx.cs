using LibCrud;
using LibCrud.classes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebBook.Services;

namespace WebBook.Registration.Authors
{
    
    public partial class Create : System.Web.UI.Page
    {
        private Crud crud = null;
        private Modal modal = null;
        private Convertion convertion = null;
        private Validation validation = null;

        public Create()
        {
            this.crud = Crud.getInstance();
            this.convertion = Convertion.getInstance();
            this.validation = Validation.getInstance(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Author";

            this.modal = Modal.getInstance(this);

            if (Request.IsAuthenticated)
            {
                if (!this.IsPostBack)
                {
                    this.Reset();
                }
            }
            else
            {
                Response.Redirect("~/Account/Login.aspx");
            }
        }

        private void Reset()
        {
            if (Request.IsAuthenticated)
            {
                this.txtArtisticName.Text = "";
                this.txtName.Text = "";
                this.txtEmail.Text = "";
                txtBirthday.Value = DateTime.Now.AddYears(-10).ToShortDateString();
                this.txtBiography.Text = "";
                this.dpGender.SelectedIndex = 0;
            }
            else
            {
                Response.Redirect("~/Account/Login.aspx");
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                if (this.IsPostBack)
                {
                    if (Page.IsValid)
                    {
                        int result = crud.Insert_Author(this.txtName.Text, this.txtEmail.Text, DateTime.Parse(txtBirthday.Value), this.dpGender.SelectedValue[0], this.txtArtisticName.Text, this.txtBiography.Text, this.convertion.ConvertBase64ToByte(ref this.upPictureAuthor));

                        if (result == 1)
                        {
                            this.modal.ShowModal("Information", "Registered successfully.");
                            this.Reset();
                        }
                        else
                        {
                            this.modal.ShowModal("Error", "Error registering author.");
                        }
                    }
                }
            }
            else
            {
                Response.RedirectPermanent("~/Account/Login.aspx");
            }
        }

        protected void ValidateBirthday(object source, ServerValidateEventArgs args)
        {
            this.validation.ValidateBirthday(source, args);
        }

        protected void ValidateEmailRegistered(object source, ServerValidateEventArgs args)
        {
            this.validation.ValidateEmailRegistered(source, args);
        }

        protected void ValidateGender(object source, ServerValidateEventArgs args)
        {
            this.validation.ValidateGender(source, args);
        }
    }
}