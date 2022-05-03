using Domain.Entities.v1;
using Domain.Dto.v1;
using Infrastructure.Data.Command.Context.Interfaces.v1.Bank;
using Infrastructure.Data.Context.Interfaces.v1;
using Microsoft.AspNetCore.Mvc;
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
                _command.Connection.Close();
                return bankAccount;
            }
        }

        public async Task<JsonResult> GetBankAccount_SelectById(IBootstrapper bootstrapper, IConfiguration configuration, int bankAccount)
        {
            BankAccountDto bkDto;

            using (SqlCommand _command = bootstrapper.CreateCommand())
            {
                _command.CommandText = "EXEC [dbo].[BankAccount_SelectById] @Id";
                _command.Parameters.Add("@Id", SqlDbType.Int).Value = bankAccount;

                using (SqlDataReader reader = _command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        bkDto = new BankAccountDto(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetDecimal(3), reader.GetString(4));
                        return new JsonResult(bkDto);
                    }
                }
                _command.Connection.Close();
                return null;
            }
        }

        public async Task<bool> UpdateBankAccount_BalanceByTransfer(IBootstrapper bootstrapper, IConfiguration configuration, int bankAccount, decimal balance)
        {
            bool retorno = false;

            using (SqlCommand _command = bootstrapper.CreateCommand())
            {
                _command.CommandText = "[dbo].[BankAccount_UpdateBalanceByTransfer] @Id, @Balance";
                _command.Parameters.Add("@Id", SqlDbType.Int).Value = bankAccount;
                _command.Parameters.Add("@Balance", SqlDbType.Int).Value = bankAccount;
                retorno = _command.ExecuteNonQuery() > 0;
                _command.Connection.Close();
            }
             return retorno;
        }
    }
}
