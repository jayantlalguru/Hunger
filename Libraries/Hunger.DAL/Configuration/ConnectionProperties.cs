using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunger.DAL.Configuration
{
    public abstract class ConnectionProperties
    {
        private int connectionTimeOut;
        private object set;

        internal int ConnectionTimeOut
        {
            get
            {
                if (!String.IsNullOrEmpty(ConfigurationManager.AppSettings["ConnectionTimeOut"]))
                {
                    connectionTimeOut = Convert.ToInt32(ConfigurationManager.AppSettings["ConnectionTimeOut"]);
                }
                else
                {
                    connectionTimeOut = 300;
                }
                return connectionTimeOut;
            }
        }

        internal IDbConnection Connection
        {
            get
            {
                return new SqlConnection(ConfigurationManager.ConnectionStrings["HungerDataConnection"].ConnectionString);
            }
        }

        internal void OpenConnection(IDbConnection dbConnection)
        {
            if (dbConnection.State == ConnectionState.Closed) { dbConnection.Open(); }
        }

        internal void CloseConnection(IDbConnection dbConnection)
        {
            if (dbConnection.State == ConnectionState.Open) { dbConnection.Close(); }
        }
    }
}
