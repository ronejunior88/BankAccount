using Dapper;
using Domain.Dto.v1;
using Domain.Entities.v1;
using Infrastructure.Data.Repository.Interfaces.v1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repository.Infrastructure.v1
{
    public class PersonRepository : IPersonRepository
    {
        private readonly string _connectionString;
        public PersonRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public PersonRepository()
        { }

        public async Task<Person> InsertPersonAsync(Person person)
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = "[dbo].[Insert_Person]";
            var parameters = new { name = person.Name, LastName = person.LastName, Cpf = person.Cpf, CNPJ = person.Cnpj, telephone = person.Telephone, adress = person.Adress };

            try
            {
                var result = await connection.QueryAsync<Person>(sql, parameters, commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir Cliente: ", ex);
            }
        }
    }
}
