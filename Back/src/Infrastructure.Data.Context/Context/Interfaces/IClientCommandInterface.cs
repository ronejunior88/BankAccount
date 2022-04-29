using BasicAccountOperations.Domain.Model;
using Infrastructure.Data.Context.Context.Command.v1;
using Infrastructure.Data.Context.Context.v1;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Context.Context.Interfaces
{
    public interface IClientCommandInterface
    {
        Task<int> InsertPerson(Person person);
    }
}
