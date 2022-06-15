using Domain.Entities.v1;
using Infrastructure.Data.Command.Context.Command.v1.Clients;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Data.Command.Interfaces.v1.Client
{
    public interface IClient
    {
        Task<ClientResponse> GetClientByIdAsync(int client);
    }
}
