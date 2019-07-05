using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibCrud.classes
{
    public class Connection
    {
        public static SqlConnection Connect()
        {
            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\dbStore.mdf;Initial Catalog=dbStore;Integrated Security=True";
                conn.Open();
                return conn;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
