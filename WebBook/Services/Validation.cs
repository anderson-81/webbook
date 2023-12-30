using LibCrud;
using LibCrud.classes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBook.Services
{
    public class Validation : System.Web.UI.Page
    {
        private static Validation _instance = null;
        private static Page page = null;
        
        public static Validation getInstance(Page p)
        {
            page = p;

            if (_instance == null)
            {
                _instance = new Validation();
            }
            return _instance;
        }


        #region Author
        public void ValidateBirthday(object source, ServerValidateEventArgs args)
        {
            if (page.Request.IsAuthenticated)
            {
                try
                {
                    var ptbr = new CultureInfo("en-US");
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
                page.Response.RedirectPermanent("~/Account/Login.aspx");
            }
        }

        public void ValidateEmailRegistered(object source, ServerValidateEventArgs args)
        {
            if (page.Request.IsAuthenticated)
            {
                args.IsValid = !Crud.getInstance().CheckIfEmailAreRegistered(args.Value);
            }
            else
            {
                page.Response.RedirectPermanent("~/Account/Login.aspx");
            }
        }

        public void ValidateGender(object source, ServerValidateEventArgs args)
        {
            if (page.Request.IsAuthenticated)
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
                page.Response.RedirectPermanent("~/Account/Login.aspx");
            }
        }

        public bool ValidateDeleteAuthor(int id)
        {
            List<Book> books = Crud.getInstance().GetBookByAuthorID(id);
            if (books != null)
            {
                return false;
            }
            return true;
        }

        #endregion

        #region Book
        public void ValidateISBN(object source, ServerValidateEventArgs args)
        {
            ((CustomValidator)source).ErrorMessage = "";

            if (args.Value.Length == 14)
            {
                try
                {
                    long.Parse(args.Value);

                    if (!Crud.getInstance().CheckIfISBNAreRegistered(args.Value))
                    {
                        args.IsValid = true;
                    }
                    else
                    {
                        ((CustomValidator)source).ErrorMessage = "This ISBN is already registered.";
                        args.IsValid = false;
                    }
                }
                catch (Exception)
                {
                    ((CustomValidator)source).ErrorMessage = "Invalid ISBN. Only numbers.";
                    args.IsValid = false;
                }
            }
            else
            {
                ((CustomValidator)source).ErrorMessage = "ISBN must have 14 digits.";
                args.IsValid = false;
            }
        }

        public void ValidatePages(object source, ServerValidateEventArgs args)
        {
            ((CustomValidator)source).ErrorMessage = "";

            try
            {
                Int32.Parse(args.Value);

                if (Int32.Parse(args.Value) >= 1)
                {
                    args.IsValid = true;
                }
                else
                {
                    ((CustomValidator)source).ErrorMessage = "Number pages under of 1.";
                    args.IsValid = false;
                }
            }
            catch (Exception)
            {
                ((CustomValidator)source).ErrorMessage = "Invalid number pages.";
                args.IsValid = false;
            }
        }

        public void ValidatePrice(object source, ServerValidateEventArgs args)
        {
            ((CustomValidator)source).ErrorMessage = "";

            try
            {
                decimal.Parse(args.Value);

                if (decimal.Parse(args.Value) >= 0)
                {
                    args.IsValid = true;
                }
                else
                {
                    ((CustomValidator)source).ErrorMessage = "Price under of 0.";
                    args.IsValid = false;
                }
            }
            catch (Exception)
            {
                ((CustomValidator)source).ErrorMessage = "Invalid price.";
                args.IsValid = false;
            }
        }
        #endregion
    }
}