using LibCrud;
using LibCrud.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebBook.Services;

namespace WebBook.Registration.Authors
{
    public partial class Details : System.Web.UI.Page
    {
        private int id;

        private Crud crud = null;
        private Modal modal = null;
        private Convertion convertion = null;

        public Details()
        {
            this.crud = Crud.getInstance();
            this.convertion = Convertion.getInstance();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Author";

            this.modal = Modal.getInstance(this);

            if (Request.IsAuthenticated)
            {
                try
                {
                    Author author = crud.GetAuthorByID(Int32.Parse(Request.QueryString["id"]));
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

                        this.imgPictureDetail.ImageUrl = this.convertion.ConvertByteToBase64(author.Picture);

                        this.hplnkEditDet.NavigateUrl = "~/Registration/Authors/Edit.aspx?Id=" + this.id;
                        this.hplnkCreateBook.NavigateUrl = "~/Registration/Books/Create.aspx?Id=" + this.id;

                        List<Book> books = crud.GetBookByAuthorID(Int32.Parse(Request.QueryString["id"]));

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
                        Response.RedirectPermanent("Index.aspx");
                    }
                }
                catch (Exception)
                {
                    Response.RedirectPermanent("Index.aspx");
                }
            }
            else
            {
                Response.RedirectPermanent("~/Account/Login.aspx");
            }
        }

        private void ShowModal(string p1, string p2)
        {
            this.modal.ShowModal(p1, p2);
        }

        private void FillGrid(int p_id)
        {
            List<Book> books = crud.GetBookByAuthorID(p_id);
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