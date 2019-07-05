using LibCrud;
using LibCrud.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBook.Registration.Books
{
    public partial class Details : System.Web.UI.Page
    {
        private static int id;
        private static string isbn;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Book";

            if (Request.IsAuthenticated)
            {
                if (!this.IsPostBack)
                {
                    AuthorBook authorBook = Crud.GetBookByISBN(Request.QueryString["ISBN"]);
                    if (authorBook != null)
                    {
                        id = authorBook.Author.Id;
                        this.lblArtisticName.Text = authorBook.Author.ArtisticName;
                   
                        /************************************************/

                        this.lblTitle.Text = authorBook.Book.Title;
                        isbn = authorBook.Book.Isbn;
                        this.lblISBN.Text = authorBook.Book.Isbn;
                        this.lblPage.Text = authorBook.Book.Page.ToString();
                        this.lblPrice.Text = authorBook.Book.Price.ToString();

                        var base64 = Convert.ToBase64String(authorBook.Book.Picture);
                        var imgSrc = String.Format("data:image/gif;base64,{0}", base64);
                        this.imgPictureBookDetail.ImageUrl = imgSrc;

                        this.hplnkRetDet.NavigateUrl = "../../Registration/Authors/Details.aspx?Id=" + id;
                        this.hplnkEditDet.NavigateUrl = "../../Registration/Books/Edit.aspx?ISBN=" + isbn;

                        /************************************************/
                    }
                    else
                    {
                        Response.Redirect("Authors/Search.aspx");
                    }
                }
            }
            else
            {
                Response.Redirect("~/Account/Login.aspx");
            }
        }

        private void ShowModal(string title, string message, int opc)
        {
            Response.Write("<script   src='https://code.jquery.com/jquery-2.2.4.min.js'   integrity='sha256-BbhdlvQf/xTY9gja0Dq3HiwQF8LaCRTXxZKRutelT44='   crossorigin='anonymous'></script>     <link href='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css' rel='stylesheet' integrity='sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u' crossorigin='anonymous'>     <script src='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js' integrity='sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa' crossorigin='anonymous'></script><div id='modalMessage' class='modal fade' role='dialog'><div class='modal-dialog'><div class='modal-content'><div class='modal-header'><button type='button' class='close' data-dismiss='modal'>&times;</button><h4 class='modal-title' id='titleMsg'></h4></div><div class='modal-body'><p id='msgMsg'></p></div><div class='modal-footer'><button type='button' class='btn btn-default btn-primary' data-dismiss='modal'>Ok</button></div></div></div></div><script>$('#titleMsg').text('" + title + "');$('#msgMsg').text('" + message + "');$('#modalMessage').modal('show');</script>");
        }
    }
}