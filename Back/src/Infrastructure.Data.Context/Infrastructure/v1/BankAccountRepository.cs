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
        private readonly string _connectionString;
        public BankAccountRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public BankAccountRepository()
        { }


        public async Task InsertBankAccount(BankAccount bankAccount)
        {
            using var connection = new SqlConnection(_connectionString);
            var query = "[dbo].[Insert_BankAccount]";
            var parameters = new { IdClient = bankAccount.IdClient, Balance = bankAccount.Balance, TypeAccount = bankAccount.TypeAccount };
            try
            {
                await connection.QueryAsync(query, parameters, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir Conta: ", ex);
            }
            
        }
        public async Task<BankAccountDto> GetBankAccountSelectById(int bankAccount)
        {

            using var connection = new SqlConnection(_connectionString);

            var query = "[dbo].[BankAccount_SelectById]";
            var parameters = new { Id = bankAccount };
            try
            {
                var result = await connection.QueryAsync<BankAccountDto>(sql: query, param: parameters, commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao consultar Conta: ", ex);
            }
                       

        }
        public async Task<bool> UpdateBankAccountBalanceByTransfer(int bankAccount, decimal balance)
        {
            //_command.CommandText = "[dbo].[BankAccount_UpdateBalanceByTransfer] @Id, @Balance";
            using var connection = new SqlConnection(_connectionString);

            var query = "BankAccount_UpdateBalanceByTransfer";
            var parameters = new { Id = bankAccount, Balance = balance };
            var result = await connection.QueryAsync<bool>(query, parameters, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
    }
}
