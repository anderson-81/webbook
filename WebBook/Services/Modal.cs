using LibCrud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace WebBook.Services
{
    public class Modal : System.Web.UI.Page
    {
        private static Modal _instance = null;
        private static Page page = null;
        
        public static Modal getInstance(Page p)
        {
            page = p;
             
            if (_instance == null)
            {
                _instance = new Modal();
            }
            return _instance;
        }

        public void ShowModal(string title, string message)
        {
            page.Response.Write("<script   src='https://code.jquery.com/jquery-2.2.4.min.js'   integrity='sha256-BbhdlvQf/xTY9gja0Dq3HiwQF8LaCRTXxZKRutelT44='   crossorigin='anonymous'></script>     <link href='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css' rel='stylesheet' integrity='sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u' crossorigin='anonymous'>     <script src='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js' integrity='sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa' crossorigin='anonymous'></script><div id='modalMessage' class='modal fade' role='dialog'><div class='modal-dialog'><div class='modal-content'><div class='modal-header'><button type='button' class='close' data-dismiss='modal'>&times;</button><h4 class='modal-title' id='titleMsg'></h4></div><div class='modal-body'><p id='msgMsg'></p></div><div class='modal-footer'><button type='button' class='btn btn-default btn-primary' data-dismiss='modal'>Ok</button></div></div></div></div><script>$('#titleMsg').text('" + title + "');$('#msgMsg').text('" + message + "');$('#modalMessage').modal('show');</script>");
        }
    }
}