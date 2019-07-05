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

namespace WebBook.Registration.Authors
{
    public partial class Edit : System.Web.UI.Page
    {
        private static int id;
        private static string email;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Author";

            if (Request.IsAuthenticated)
            {
                if (!this.IsPostBack)
                {
                    try
                    {
                        Author author = Crud.GetAuthorByID(Int32.Parse(Request.QueryString["id"]));
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

                            var base64 = Convert.ToBase64String(author.Picture);
                            var imgSrc = String.Format("data:image/gif;base64,{0}", base64);
                            this.hpCurrentImage.NavigateUrl = imgSrc;
                            this.hplnkRetDet.NavigateUrl = "~/Registration/Authors/Details.aspx?Id=" + id;
                        }
                        else
                        {
                            Response.Redirect("Index.aspx");
                        }
                    }
                    catch (Exception)
                    {
                        Response.Redirect("Index.aspx");
                    }
                }
            }
            else
            {
                Response.Redirect("~/Account/Login.aspx");
            }
        }

        protected void ValidateBirthday(object source, ServerValidateEventArgs args)
        {
            try
            {
                var ptbr = new CultureInfo("pt-BR");
                DateTime birthday = DateTime.Parse(args.Value, ptbr);
                if (birthday.AddYears(-10) <= DateTime.Now.AddYears(-10))
                {
                    args.IsValid = true;
                }
                else
                {
                    args.IsValid = false;
                }
            }
            catch (Exception)
            {
                args.IsValid = false;
            }
        }

        protected void ValidateEmailRegistered(object source, ServerValidateEventArgs args)
        {
            if (email != args.Value)
            {
                args.IsValid = !Crud.CheckRegisteredEmail(args.Value);
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void ValidateGender(object source, ServerValidateEventArgs args)
        {
            if ((args.Value == "M") || (args.Value == "F"))
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }

        protected bool ValidateDeleteAuthor()
        {
            List<Book> books = Crud.GetBookByAuthorID(id);
            if (books != null)
            {
                return false;
            }
            return true;
        }

        private void ShowModal(string title, string message, int opc)
        {
            Response.Write("<script   src='https://code.jquery.com/jquery-2.2.4.min.js'   integrity='sha256-BbhdlvQf/xTY9gja0Dq3HiwQF8LaCRTXxZKRutelT44='   crossorigin='anonymous'></script>     <link href='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css' rel='stylesheet' integrity='sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u' crossorigin='anonymous'>     <script src='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js' integrity='sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa' crossorigin='anonymous'></script><div id='modalMessage' class='modal fade' role='dialog'><div class='modal-dialog'><div class='modal-content'><div class='modal-header'><button type='button' class='close' data-dismiss='modal'>&times;</button><h4 class='modal-title' id='titleMsg'></h4></div><div class='modal-body'><p id='msgMsg'></p></div><div class='modal-footer'><button type='button' class='btn btn-default btn-primary' data-dismiss='modal'>Ok</button></div></div></div></div><script>$('#titleMsg').text('" + title + "');$('#msgMsg').text('" + message + "');$('#modalMessage').modal('show');</script>");
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

                        if (this.upPictureAuthor.HasFile)
                        {
                            picture = new byte[this.upPictureAuthor.PostedFile.ContentLength];
                            this.upPictureAuthor.PostedFile.InputStream.Read(picture, 0, this.upPictureAuthor.PostedFile.ContentLength);
                        }

                        int result = Crud.Edit_Author(id, this.txtName.Text, this.txtEmail.Text, DateTime.Parse(txtBirthday.Value), this.dpGender.SelectedValue[0], this.txtArtisticName.Text, this.txtBiography.Text, picture);

                        if (result == 1)
                        {
                            ShowModal("Information", "Edited successfully.", 0);
                        }
                        else
                        {
                            ShowModal("Error", "Error in registry edition.", 1);
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
                if (this.ValidateDeleteAuthor())
                {
                    if (this.IsPostBack)
                    {
                        int result = Crud.Delete_Author(id);
                        if (result == 1)
                        {
                            ShowModal("Information", "Deleted successfully.", 1);
                            Response.Redirect("Index.aspx");
                        }
                        else
                        {
                            ShowModal("Error", "Error in registry deletion.", 1);
                        }
                    }
                }
                else
                {
                    ShowModal("Information", "This author has one or more books registered and cannot be deleted.", 1);
                }
            }
            else
            {
                Response.Redirect("~/Account/Login.aspx");
            }
        }
    }
}