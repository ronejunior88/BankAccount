using Dapper;
using Domain.Dto.v1;
using Domain.Entities.v1;
using Infrastructure.Data.Repository.Interfaces.v1;
using Microsoft.AspNetCore.Mvc;
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
    public class ClientRepository : IClientRepository
    {
        private readonly IConfiguration _configuration;
        public ClientRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public ClientRepository()
        { }

        public async Task<ClientPersonDto> GetClientByIdAsync(int client)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("BankAccount"));
            var sql = "[dbo].[Client_SelectById]";
            var parameters = new { Id = client };

            try
            {
                var response = await connection.QueryAsync<ClientPersonDto>(sql, parameters, commandType: CommandType.StoredProcedure);
                return response.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar Cliente: ", ex);
            }           
        }
    }
}
