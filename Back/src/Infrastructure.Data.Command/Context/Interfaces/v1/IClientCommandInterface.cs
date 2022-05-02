using BasicAccountOperations.Domain.Model;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Infrastructure.Data.Command.Interfaces.v1
{
    public interface IClientCommandInterface
    {
        Task<Person> InsertPerson(IBootstrapper bootstrapper,IConfiguration configuration, Person person);
    }
}
