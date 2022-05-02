using Infrastructure.Data.Command.Interfaces.v1;
using Infrastructure.Data.Context.Context.v1;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace Infrastructure.Data.Command.Infrastructure.Ioc
{
    public class Bootstrapper : IBootstrapper
    {
        private IConfiguration _configuration;
        private DbContext dbContext = new DbContext();
        public Bootstrapper(){ }

        public Bootstrapper(IConfiguration configuration)
        {
            _configuration =  configuration;
        }
        public void Inject()
        {
        }

        public SqlConnection OpenConnection()
        {
            string connect = _configuration.GetConnectionString("BankAccount");
            return dbContext.dbConnectionOpen(connect);
        }

        public void ClosedConnection() 
        {
            dbContext.dbConnectionClose();
        }

        public SqlCommand CreateCommand() 
        {
            return OpenConnection().CreateCommand();
        }
    }
}
