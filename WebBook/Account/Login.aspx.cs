using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using WebBook.Models;
using WebBook.Services;

namespace WebBook.Account
{
    public partial class Login : Page
    {
        private Modal modal = null;

        public Login()
        {
            this.modal = Modal.getInstance(Page);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            UserName.Text = "Administrator";
            Password.Text = "#Administrator01";

            Page.Title = "Login";

            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            #region Register
            /*
            var manager = new UserManager();
            var user = new ApplicationUser() { UserName = "Administrator" };
            IdentityResult result = manager.Create(user, "#Administrator01");
            if (result.Succeeded)
            {
                IdentityHelper.SignIn(manager, user, isPersistent: false);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else
            {
                Console.WriteLine(result.Errors.FirstOrDefault());
            }
            */
            #endregion

            if (IsValid)
            {
                var manager = new UserManager();
                ApplicationUser user = manager.Find(UserName.Text, Password.Text);
                if (user != null)
                {
                    IdentityHelper.SignIn(manager, user, false);

                    this.ShowModal("Information", "Successfully logged in.");

                    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);

                    
                }
                else
                {
                    this.ShowModal("Information", "Invalid username or password.");
                }
            }
        }

        private void ShowModal(string title, string message)
        {
            // this.modal.ShowModal(title, message);

            SiteMaster.ShowModal(title, message, this);
        }
    }
}