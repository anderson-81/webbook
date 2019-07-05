using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibCrud.classes;
using LibCrud;

namespace WebBook.Registration.Authors
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Author";

            if(Request.IsAuthenticated)
            {
                if (!this.IsPostBack)
                {
                    List<Author> authors = Crud.GetAuthorByName("");
                    if (authors != null)
                    {
                        this.gridAuthors.DataSource = authors;
                        this.gridAuthors.DataBind();
                    }
                    else
                    {
                        ShowModal("Information", "No registered author.");
                    }
                }
            }
            else
            {
                Response.Redirect("~/Account/Login.aspx");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if(Request.IsAuthenticated)
            {
                List<Author> authors = Crud.GetAuthorByName(this.txtData.Text);
                if (authors != null)
                {
                    this.gridAuthors.DataSource = authors;
                    this.gridAuthors.DataBind();
                }
                else
                {
                    ShowModal("Information", "No results were found with this name.");
                    this.txtData.Text = "";
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

        private void FillGrid()
        {
            if (Request.IsAuthenticated)
            {
                List<Author> authors = Crud.GetAuthorByName(this.txtData.Text);
                if (authors != null)
                {
                    this.gridAuthors.DataSource = authors;
                    this.gridAuthors.DataBind();
                }
                else
                {
                    ShowModal("Information", "No results were found with this name.");
                    this.txtData.Text = "";
                }
            }
            else
            {
                Response.Redirect("~/Account/Login.aspx");
            }
        }

        protected void gridAuthors_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gridAuthors.PageIndex = e.NewPageIndex;
            this.FillGrid();
        }
    }
}