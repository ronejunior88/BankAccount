using BasicAccountOperations.Domain.Model;
using Infrastructure.Data.Context.Interfaces.v1;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.Data.Command.Interfaces.v1
{
    public interface IClientCommandInterface
    {
        Task<Person> InsertPerson(IBootstrapper bootstrapper,IConfiguration configuration, Person person);

        Task<JsonResult> GetClientById(IBootstrapper bootstrapper, IConfiguration configuration, int client);
    }
}
