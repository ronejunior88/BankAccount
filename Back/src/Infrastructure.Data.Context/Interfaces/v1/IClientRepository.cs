using Domain.Dto.v1;
using Domain.Entities.v1;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repository.Interfaces.v1
{
    public interface IClientRepository
    {
        Task<ClientPersonDto> GetClientByIdAsync(int client);
    }
}
