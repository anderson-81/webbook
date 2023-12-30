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
    public partial class Edit : System.Web.UI.Page
    {
        private static int id;
        private static string email;
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
            Page.Title = "Author";

            this.modal = Modal.getInstance(this);

            if (Request.IsAuthenticated)
            {
                if (!this.IsPostBack)
                {
                    this.GetAuthorForEdition();
                }
            }
            else
            {
                Response.RedirectPermanent("~/Account/Login.aspx");
            }
        }

        private void GetAuthorForEdition()
        {
            try
            {
                Author author = crud.GetAuthorByID(Int32.Parse(Request.QueryString["id"]));
                if (author != null)
                {
                    id = author.Id;
                    this.txtName.Text = author.Name;
                    this.txtEmail.Text = author.Email;
                    email = author.Email;
                    this.txtArtisticName.Text = author.ArtisticName;
                    txtBirthday.Value = author.Birthday.ToShortDateString();

                    if (author.Gender.ToString() == "M")
                    {
                        this.dpGender.SelectedIndex = 0;
                    }

                    if (author.Gender.ToString() == "F")
                    {
                        this.dpGender.SelectedIndex = 1;
                    }
                    this.txtBiography.Text = author.Biography;

                    this.imgPicture.ImageUrl = this.convertion.ConvertByteToBase64(author.Picture);

                    this.hplnkRetDet.NavigateUrl = "~/Registration/Authors/Details.aspx?Id=" + id;
                }
                else
                {
                    Response.RedirectPermanent("Index.aspx");
                }
            }
            catch (Exception)
            {
                Response.RedirectPermanent("Index.aspx");
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                if (this.IsPostBack)
                {
                    cvEmailreg.Enabled = this.txtEmail.Text != email;

                    if (Page.IsValid)
                    {
                        int result = crud.Edit_Author(id,
                             this.txtName.Text,
                             this.txtEmail.Text,
                             DateTime.Parse(txtBirthday.Value),
                             this.dpGender.SelectedValue[0],
                             this.txtArtisticName.Text,
                             this.txtBiography.Text,
                             (this.upPictureAuthor.HasFile ? this.convertion.ConvertBase64ToByte(ref upPictureAuthor) : null));
                        
                        if (result == 1)
                        {
                            this.GetAuthorForEdition();
                            ShowModal("Information", "Edited successfully.");

                            if (this.upPictureAuthor.HasFile)
                            {
                                this.imgPicture.ImageUrl = this.convertion.ConvertByteToBase64(upPictureAuthor.FileBytes);
                            }
                        }
                        else
                        {
                            ShowModal("Error", "Error in registry edition.");
                        }
                    }
                }
            }
            else
            {
                Response.Redirect("~/Account/Login.aspx");
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                if (validation.ValidateDeleteAuthor(id))
                {
                    if (this.IsPostBack)
                    {
                        int result = crud.Delete_Author(id);
                        if (result == 1)
                        {
                            ShowModal("Information", "Deleted successfully.");
                            Response.RedirectPermanent("Index.aspx");
                        }
                        else
                        {
                            ShowModal("Error", "Error in registry deletion.");
                        }
                    }
                }
                else
                {
                    ShowModal("Information", "This author has one or more books registered and cannot be deleted.");
                }
            }
            else
            {
                Response.Redirect("~/Account/Login.aspx");
            }
        }

        private void ShowModal(string p1, string p2)
        {
            this.modal.ShowModal(p1, p2);
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