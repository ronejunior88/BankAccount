using AutoMapper;
using Domain.Dto.v1;
using Domain.Entities.v1;
using Infrastructure.Data.Command.Interfaces.v1.Client;
using Infrastructure.Data.Repository.Infrastructure.v1;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Data.Command.Context.Command.v1.Clients
{
    public class ClientHandler : IClient, IRequestHandler<ClientRequest, ClientResponse>
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private ClientRepository _clientRepository;

        public ClientHandler(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
            _connectionString = configuration.GetConnectionString("BankAccount");
            _clientRepository = new ClientRepository(_connectionString);
        }
        public ClientHandler()
        { }

        public async Task<ClientResponse> Handle(ClientRequest request, CancellationToken cancellationToken)
        {
            var result = await GetClientByIdAsync(request.Id);
            return result;
        }

        public async Task<ClientResponse> GetClientByIdAsync(int client)
        {
            var result = await _clientRepository.GetClientByIdAsync(client);
            return _mapper.Map<ClientResponse>(result);
        }

        
    }
}
