using Infrastructure.Data.Command.Context.Command.v1.Persons.Insert_Person;
using System.Threading.Tasks;

namespace Infrastructure.Data.Command.Context.Interfaces.v1.Persons
{
    public interface IInsert_Person
    {
        Task<Insert_PersonResponse> InsertPersonAsync(Insert_PersonRequest person);
    }
}
