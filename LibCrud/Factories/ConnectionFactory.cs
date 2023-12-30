using LibCrud;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ConnectionFactory
{
    #region Attributes and Enums
    private static volatile SqlConnection _conn = null;
    private static ConnectionFactory _instance = null;
    #endregion

    #region Singleton and Connection Initialization
    public static ConnectionFactory getInstance()
    {
        if (_instance == null)
        {
            _instance = new ConnectionFactory();
        }
        return _instance;
    }

    private ConnectionFactory()
    {
        try
        {
            _conn = new SqlConnection();
            _conn.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\dbWebBook.mdf;Integrated Security=True;Connect Timeout=30";
        }
        catch (Exception)
        {
            Environment.Exit(0);
        }
    }
    #endregion

    #region GetConnection
    public SqlConnection getConnection()
    {
        try
        {
            if (ConnectionFactory._conn.State == System.Data.ConnectionState.Closed)
            {
                ConnectionFactory._conn.Open();
            }
            return ConnectionFactory._conn;
        }
        catch (Exception)
        {
            return null;
        }
    }
    #endregion
}

