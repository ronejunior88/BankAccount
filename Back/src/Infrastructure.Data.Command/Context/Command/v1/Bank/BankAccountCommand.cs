using Domain.Entities.v1;
using Infrastructure.Data.Command.Context.Interfaces.v1.Bank;
using Infrastructure.Data.Context.Interfaces.v1;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Command.Context.Command.v1.Bank
{
    public class BankAccountCommand : IBankAccountCommanderInterface
    {
        public async Task<BankAccount> InsertBankAccount(IBootstrapper bootstrapper, IConfiguration configuration, BankAccount bankAccount)
        {
            using (SqlCommand _command = bootstrapper.CreateCommand())
            {
                _command.CommandText = "EXEC [dbo].[Insert_BankAccount] @IdClient, @Balance, @TypeAccount";
                _command.Parameters.Add("@IdClient", SqlDbType.Int).Value = bankAccount.IdClient;
                _command.Parameters.Add("@Balance", SqlDbType.Decimal).Value = bankAccount.Balance;
                _command.Parameters.Add("@TypeAccount", SqlDbType.VarChar).Value = bankAccount.TypeAccount;
                int Id;
                if (int.TryParse(_command.ExecuteScalar().ToString(), out Id))
                {
                    bankAccount.Id = Id;
                }
                return bankAccount;
            }
        }
    }
}
