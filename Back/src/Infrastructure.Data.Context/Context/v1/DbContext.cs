using System;
using System.Collections.Generic;
using Microsoft;
using System.Data.SqlClient;
using System.Text;

namespace Infrastructure.Data.Context.Context.v1
{
    public class DbContext
    {
        public SqlConnection sqlcnn { get; private set; }
        public DbContext(){ }
      public SqlConnection dbConnectionOpen(string connectionString)
        {
            try
            {

                sqlcnn = new SqlConnection();
                sqlcnn.ConnectionString = connectionString;

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
    }   
}
