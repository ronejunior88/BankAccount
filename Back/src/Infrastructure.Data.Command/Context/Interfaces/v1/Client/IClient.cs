using Infrastructure.Data.Context.Interfaces.v1;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities.v1;

namespace Infrastructure.Data.Command.Interfaces.v1.Client
{
    public interface IClient
    {
        Task<Person> InsertPerson(IBootstrapper bootstrapper,IConfiguration configuration, Person person);

        Task<JsonResult> GetClientById(IBootstrapper bootstrapper, IConfiguration configuration, int client);
    }
}
