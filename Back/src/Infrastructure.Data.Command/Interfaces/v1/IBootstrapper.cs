﻿using System.Data.SqlClient;

namespace Infrastructure.Data.Command.Interfaces.v1
{
    public interface IBootstrapper
    {
        public void Inject();
        public SqlConnection OpenConnection();
        public void ClosedConnection();
        public SqlCommand CreateCommand();
    }
}
