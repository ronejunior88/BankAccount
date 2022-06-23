using AutoMapper;
using Dapper;
using Domain.Dto.v1;
using Domain.Entities.v1;
using Infrastructure.Data.Repository.Interfaces.v1;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repository.Infrastructure.v1
{
    public class BankAccountRepository : IBankAccountRepository
    {
        private readonly IConfiguration _configuration;
        public BankAccountRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public BankAccountRepository()
        { }


        public async Task<BankAccount> InsertBankAccountAsync(BankAccount bankAccount)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("BankAccount"));
            var query = "[dbo].[Insert_BankAccount]";
            var parameters = new { IdClient = bankAccount.IdClient, Balance = bankAccount.Balance, TypeAccount = bankAccount.TypeAccount };
            try
            {
                var result = await connection.QueryAsync<BankAccount>(query, parameters, commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir Conta: ", ex);
            }
            
        }
        public async Task<BankAccountDto> GetBankAccountSelectByIdAsync(int bankAccount)
        {

            using var connection = new SqlConnection(_configuration.GetConnectionString("BankAccount"));

            var query = "[dbo].[BankAccount_SelectById]";
            var parameters = new { Id = bankAccount };
            try
            {
                var result = await connection.QueryFirstOrDefaultAsync<BankAccountDto>(sql: query, param: parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao consultar Conta: ", ex);
            }
                       

        }
        public async Task UpdateBankAccountBalanceByTransferAsync(int bankAccount, decimal balance)
        {
            //_command.CommandText = "[dbo].[BankAccount_UpdateBalanceByTransfer] @Id, @Balance";
            using var connection = new SqlConnection(_configuration.GetConnectionString("BankAccount"));

            var query = "BankAccount_UpdateBalanceByTransfer";
            var parameters = new { Id = bankAccount, Balance = balance };
            await connection.QueryAsync(query, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
