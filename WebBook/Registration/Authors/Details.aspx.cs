using LibCrud;
using LibCrud.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBook.Registration.Authors
{
    public partial class Details : System.Web.UI.Page
    {
        private int id;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Author";

            if (Request.IsAuthenticated)
            {
                try
                {
                    Author author = Crud.GetAuthorByID(Int32.Parse(Request.QueryString["id"]));
                    if (author != null)
                    {
                        this.id = author.Id;
                        this.lblNameDet.Text = author.Name;
                        this.lblEmailDet.Text = author.Email;
                        this.lblArtisticName.Text = author.ArtisticName;
                        this.lblBirthdayDet.Text = author.Birthday.ToShortDateString();

                        if (author.Gender.ToString() == "M")
                        {
                            this.lblGenderDet.Text = "Male";
                        }

                        if (author.Gender.ToString() == "F")
                        {
                            this.lblGenderDet.Text = "Female";
                        }
                        this.lblBiographyDet.Text = author.Biography;

                        var base64 = Convert.ToBase64String(author.Picture);
                        var imgSrc = String.Format("data:image/gif;base64,{0}", base64);
                        this.imgPictureDetail.ImageUrl = imgSrc;
                        this.hplnkEditDet.NavigateUrl = "~/Registration/Authors/Edit.aspx?Id=" + this.id;
                        this.hplnkCreateBook.NavigateUrl = "~/Registration/Books/Create.aspx?Id=" + this.id;

                        List<Book> books = Crud.GetBookByAuthorID(Int32.Parse(Request.QueryString["id"]));
                        
                        if (books != null)
                        {

                            divGridViewBooksAuthor.Visible = true;
                            this.gridViewBooksAuthor.Visible = true;
                            this.gridViewBooksAuthor.DataSource = books;
                            this.gridViewBooksAuthor.DataBind();
                        }
                        else
                        {
                            ShowModal("Information", "This author has no books.");
                        }
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
            else
            {
                Response.Redirect("~/Account/Login.aspx");
            }
        }

        private void ShowModal(string title, string message)
        {
            Response.Write("<script   src='https://code.jquery.com/jquery-2.2.4.min.js'   integrity='sha256-BbhdlvQf/xTY9gja0Dq3HiwQF8LaCRTXxZKRutelT44='   crossorigin='anonymous'></script>     <link href='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css' rel='stylesheet' integrity='sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u' crossorigin='anonymous'>     <script src='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js' integrity='sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa' crossorigin='anonymous'></script><div id='modalMessage' class='modal fade' role='dialog'><div class='modal-dialog'><div class='modal-content'><div class='modal-header'><button type='button' class='close' data-dismiss='modal'>&times;</button><h4 class='modal-title' id='titleMsg'></h4></div><div class='modal-body'><p id='msgMsg'></p></div><div class='modal-footer'><button type='button' class='btn btn-default btn-primary' data-dismiss='modal'>Ok</button></div></div></div></div><script>$('#titleMsg').text('" + title + "');$('#msgMsg').text('" + message + "');$('#modalMessage').modal('show');</script>");
        }

        private void FillGrid(int p_id)
        {
            List<Book> books = Crud.GetBookByAuthorID(p_id);
            this.gridViewBooksAuthor.DataSource = books;
            this.gridViewBooksAuthor.DataBind();
        }

        protected void gridViewBooksAuthor_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gridViewBooksAuthor.PageIndex = e.NewPageIndex;
            this.FillGrid(id);
        }
    }
}