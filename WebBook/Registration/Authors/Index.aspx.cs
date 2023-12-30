using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibCrud.classes;
using LibCrud;
using WebBook.Services;

namespace WebBook.Registration.Authors
{
    public partial class Index : System.Web.UI.Page
    {
        private Crud crud = null;
        private Modal modal = null;

        public Index()
        {
            this.crud = Crud.getInstance();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Author";

            this.modal = Modal.getInstance(this);

            if(Request.IsAuthenticated)
            {
                if (!this.IsPostBack)
                {
                    List<Author> authors = crud.GetAuthorByName("");
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
                Response.RedirectPermanent("~/Account/Login.aspx");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if(Request.IsAuthenticated)
            {
                List<Author> authors = crud.GetAuthorByName(this.txtData.Text);
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
                Response.RedirectPermanent("~/Account/Login.aspx");
            }
        }

        private void ShowModal(string title, string message)
        {
            this.modal.ShowModal(title, message);
        }

        private void FillGrid()
        {
            if (Request.IsAuthenticated)
            {
                List<Author> authors = crud.GetAuthorByName(this.txtData.Text);
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
                Response.RedirectPermanent("~/Account/Login.aspx");
            }
        }

        protected void gridAuthors_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gridAuthors.PageIndex = e.NewPageIndex;
            this.FillGrid();
        }
    }
}