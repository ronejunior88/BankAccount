using Domain.Entities.v1;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Infrastructure.Data.Command.Interfaces.v1.Client
{
    public interface IClient
    {
        Task InsertPersonAsync(Person person);

        Task<JsonResult> GetClientByIdAsync(int client);
    }
}
