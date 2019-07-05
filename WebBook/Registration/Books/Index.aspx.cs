using LibCrud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibCrud.classes;
using System.Web.Script.Serialization;

namespace WebBook.Registration.Books
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Author> listBook = Crud.GetAuthorByName("");
            if (listBook == null)
            {
                this.ShowModal("Information", "No book registered.");
            }
            else
            {
                foreach(Author author in listBook)
                {
                    var jsonSerialiser = new JavaScriptSerializer();
                    var json = jsonSerialiser.Serialize(author);
                    Response.Write(json);
                }
            }
        }
        private void ShowModal(string title, string message)
        {
            Response.Write("<script   src='https://code.jquery.com/jquery-2.2.4.min.js'   integrity='sha256-BbhdlvQf/xTY9gja0Dq3HiwQF8LaCRTXxZKRutelT44='   crossorigin='anonymous'></script>     <link href='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css' rel='stylesheet' integrity='sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u' crossorigin='anonymous'>     <script src='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js' integrity='sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa' crossorigin='anonymous'></script><div id='modalMessage' class='modal fade' role='dialog'><div class='modal-dialog'><div class='modal-content'><div class='modal-header'><button type='button' class='close' data-dismiss='modal'>&times;</button><h4 class='modal-title' id='titleMsg'></h4></div><div class='modal-body'><p id='msgMsg'></p></div><div class='modal-footer'><button type='button' class='btn btn-default btn-primary' data-dismiss='modal'>Ok</button></div></div></div></div><script>$('#titleMsg').text('" + title + "');$('#msgMsg').text('" + message + "');$('#modalMessage').modal('show');</script>");
        }
    }
}