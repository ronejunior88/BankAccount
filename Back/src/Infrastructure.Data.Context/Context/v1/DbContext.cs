using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Infrastructure.Data.Context.Context.v1
{
    public class DbContext
    {
        public SqlConnection sqlcnn { get; private set; }

        public DbContext(){ }
        public DbContext(SqlConnection connection)
        {
            sqlcnn = connection;
        }

        public DbContext(string connectionString)
        {
            sqlcnn = new SqlConnection(connectionString);
        }

        public SqlConnection dbConnectionOpen()
        {
            try
            {
                sqlcnn = new SqlConnection();

                if (sqlcnn == null)
                    throw new Exception("No instance class");

                if (sqlcnn.State != System.Data.ConnectionState.Open)
                {
                    sqlcnn.Open();
                }

                return sqlcnn;
            }
            catch (Exception ex)
            {
                throw new Exception("Connection Open Error: ", ex);
            }
        }

        public void dbConnectionClose()
        {
            try
            {
                if (sqlcnn != null && sqlcnn.State == System.Data.ConnectionState.Open)
                {
                    sqlcnn.Close();
                    sqlcnn.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Connection Close Error: ", ex); ;
            }
        }

        public SqlCommand CreateCommand()
        {
            return dbConnectionOpen()
                .CreateCommand();
        }
    }   
}
