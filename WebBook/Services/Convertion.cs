using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace WebBook.Services
{
    public class Convertion
    {
        private static Convertion _instance = null;

        public static Convertion getInstance()
        {
            if (_instance == null)
            {
                _instance = new Convertion();
            }
            return _instance;
        }

        // Set
        public byte[] ConvertBase64ToByte(ref FileUpload fileUpload)
        {
            byte[] picture = new byte[fileUpload.PostedFile.ContentLength];
            fileUpload.PostedFile.InputStream.Read(picture, 0, fileUpload.PostedFile.ContentLength);
            return picture;
        }

        // Get
        public string ConvertByteToBase64(byte[] picture)
        {
            return String.Format("data:image/gif;base64,{0}", Convert.ToBase64String(picture));
        }
    }
}