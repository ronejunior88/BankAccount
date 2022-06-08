using Domain.Dto.v1;
using Domain.Entities.v1;
using Infrastructure.Data.Command.Interfaces.v1.Client;
using Infrastructure.Data.Repository.Infrastructure.v1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Infrastructure.Data.Command.Context.Command.v1.Client
{
    public class ClientCommand : IClient
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;
        private ClientRepository _clientRepository;

        public ClientCommand(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("BankAccount");
            _clientRepository = new ClientRepository(_connectionString);
        }
        public ClientCommand()
        { }
        public async Task InsertPersonAsync(Person person)
        {         
            await _clientRepository.InsertPersonAsync(person);
        }

        public async Task<JsonResult> GetClientByIdAsync(int client)
        {
            var result = await _clientRepository.GetClientByIdAsync(client);
            return result;
        }        
    }
}
