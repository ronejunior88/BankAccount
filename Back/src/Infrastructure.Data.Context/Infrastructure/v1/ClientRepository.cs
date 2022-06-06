using Dapper;
using Domain.Dto.v1;
using Domain.Entities.v1;
using Infrastructure.Data.Repository.Interfaces.v1;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repository.Infrastructure.v1
{
    public class ClientRepository : IClientRepository
    {
        private readonly string _connectionString;
        public ClientRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public ClientRepository()
        { }
        public async Task InsertPerson(Person person)
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = "[dbo].[Insert_Person]";
            var parameters = new { name = person.Name, LastName = person.LastName, Cpf = person.Cpf, CNPJ = person.Cnpj, telephone = person.Telephone, adress = person.Adress };

            try
            {
                await connection.QueryAsync(sql, parameters, commandType: CommandType.StoredProcedure); 
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir Cliente: ", ex);
            }
        }

        public async Task<JsonResult> GetClientById(int client)
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = "[dbo].[Client_SelectById]";
            var parameters = new { Id = client };

            try
            {
                var response = await connection.QueryAsync<ClientPersonDto>(sql, parameters, commandType: CommandType.StoredProcedure);
                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar Cliente: ", ex);
            }           
        }
    }
}
