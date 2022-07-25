﻿using Infrastructure.Data.Query.Queries.v1.Client.ClientSelectById;
using System.Threading.Tasks;

namespace Infrastructure.Data.Query.Interfaces.v1
{
    public interface IClientSelectById
    {
        Task<ClientSelectByIdResponse> GetClientByIdAsync(int client);
    }
}
