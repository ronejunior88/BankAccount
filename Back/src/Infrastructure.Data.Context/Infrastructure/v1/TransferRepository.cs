using Dapper;
using Domain.Dto.v1;
using Domain.Entities.v1;
using Infrastructure.Data.Repository.Interfaces.v1;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repository.Infrastructure.v1
{
    public class TransferRepository : ITransferRepository
    {
        private readonly string _connectionString;
        public TransferRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public TransferRepository()
        { }
        public async Task<Transfer> GetTransferByIdAsync(int idTransfer)
        {
            using var connection = new SqlConnection(_connectionString);

            var sql = "[dbo].[Transfer_SelectById]";
            var parameters = new { Id = idTransfer };

            try
            {
                var response = await connection.QueryAsync<Transfer>(sql, parameters, commandType: CommandType.StoredProcedure);
                return response.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro:", ex);
            }
            
        }

        public async Task<IEnumerable<TransferBankAccountIdClientDto>> GetTransferByClientIdAsync(int idClient)
        {
            using var connection = new SqlConnection(_connectionString);

            var sql = "[dbo].[TransferClient_SelectById]";
            var parameters = new { Id = idClient };

            try
            {
                var list = await connection.QueryAsync<TransferBankAccountIdClientDto>(sql, parameters, commandType: CommandType.StoredProcedure);
                return list;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao consultar Transferencias por Id do Cliente", ex);
            }

        }

        public async Task<IEnumerable<TransferBankAccountAllDto>> GetTransferAllAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            
            var sql = "[dbo].[TransferAll_Select]";

            try
            {
                var list = await connection.QueryAsync<TransferBankAccountAllDto> (sql, commandType: CommandType.StoredProcedure);
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar todas as transferencias", ex);
            }
        }
        
        public async Task<Transfer> insertTransferAsync(Transfer transfer)
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = "[dbo].[Insert_Transfer]";
            var parameters = new { idBankAccount = transfer.IdBankAccount, valueTransfer = transfer.ValueTransfer ,TypeTransfer = transfer.TypeTransFer };

            try
            {
                var response = await connection.QueryAsync<Transfer>(sql, parameters, commandType: CommandType.StoredProcedure);
                return response.FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao inserir transferencia", ex);
            }
        }
    }
}
