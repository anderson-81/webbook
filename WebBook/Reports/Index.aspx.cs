using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBook.Reports
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Report";

            if (Request.IsAuthenticated)
            {
                if (!IsPostBack)
                {
                    this.ReportViewer1.LocalReport.ReportEmbeddedResource = "WebBook.Reports.ReportAuthorBook.rdlc";
                    this.ReportViewer1.LocalReport.ReportPath = "Reports/ReportAuthorBook.rdlc";

                    var rdsAuthor = new ReportDataSource("DSAuthorBook", GetAuthorBook());
                    this.ReportViewer1.LocalReport.DataSources.Add(rdsAuthor);

                    ReportViewer1.AsyncRendering = false;

                    ReportViewer1.SizeToReportContent = true;

                    ReportViewer1.ZoomMode = ZoomMode.FullPage;

                    this.ReportViewer1.LocalReport.Refresh();
                }
            }
            else
            {
                Response.Redirect("~/Account/Login.aspx");
            }
        }

        private SqlDataReader GetAuthorBook()
        {
            if (Request.IsAuthenticated)
            {
                string sql = "SELECT * FROM PERSON INNER JOIN AUTHOR ON PERSON.ID = AUTHOR.PERSON_ID INNER JOIN BOOK ON AUTHOR.ID = BOOK.AUTHOR_ID";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = LibCrud.classes.Connection.Connect();
                cmd.CommandText = sql;
                SqlDataReader sqr = cmd.ExecuteReader();
                return sqr;
            }
            else
            {
                Response.Redirect("~/Account/Login.aspx");
                return null;
            }
        }
    }
}