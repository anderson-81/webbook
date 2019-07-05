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
    
    public partial class Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Author";

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

        protected void ValidateBirthday(object source, ServerValidateEventArgs args)
        {
            if (Request.IsAuthenticated)
            {
                try
                {
                    var ptbr = new CultureInfo("pt-BR");
                    DateTime birthday = DateTime.Parse(args.Value, ptbr);
                    if (birthday <= DateTime.Now.AddYears(-10))
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
            else
            {
                Response.Redirect("~/Account/Login.aspx");
            }
        }

        protected void ValidateEmailRegistered(object source, ServerValidateEventArgs args)
        {
            if (Request.IsAuthenticated)
            {
                args.IsValid = !Crud.CheckRegisteredEmail(args.Value);
            }
            else
            {
                Response.Redirect("~/Account/Login.aspx");
            }
        }

        protected void ValidateGender(object source, ServerValidateEventArgs args)
        {
            if (Request.IsAuthenticated)
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
            else
            {
                Response.Redirect("~/Account/Login.aspx");
            }
        }

        private void ShowModal(string title, string message)
        {
            if (Request.IsAuthenticated)
            {
                Response.Write("<script   src='https://code.jquery.com/jquery-2.2.4.min.js'   integrity='sha256-BbhdlvQf/xTY9gja0Dq3HiwQF8LaCRTXxZKRutelT44='   crossorigin='anonymous'></script>     <link href='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css' rel='stylesheet' integrity='sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u' crossorigin='anonymous'>     <script src='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js' integrity='sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa' crossorigin='anonymous'></script><div id='modalMessage' class='modal fade' role='dialog'><div class='modal-dialog'><div class='modal-content'><div class='modal-header'><button type='button' class='close' data-dismiss='modal'>&times;</button><h4 class='modal-title' id='titleMsg'></h4></div><div class='modal-body'><p id='msgMsg'></p></div><div class='modal-footer'><button type='button' class='btn btn-default btn-primary' data-dismiss='modal'>Ok</button></div></div></div></div><script>$('#titleMsg').text('" + title + "');$('#msgMsg').text('" + message + "');$('#modalMessage').modal('show');</script>");
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
                        byte[] picture = null;

                        picture = new byte[this.upPictureAuthor.PostedFile.ContentLength];
                        this.upPictureAuthor.PostedFile.InputStream.Read(picture, 0, this.upPictureAuthor.PostedFile.ContentLength);

                        int result = Crud.Insert_Author(this.txtName.Text, this.txtEmail.Text, DateTime.Parse(txtBirthday.Value), this.dpGender.SelectedValue[0], this.txtArtisticName.Text, this.txtBiography.Text, picture);

                        if (result == 1)
                        {
                            ShowModal("Information", "Registered successfully.");
                            this.Reset();
                        }
                        else
                        {
                            ShowModal("Error", "Error registering author.");
                        }
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