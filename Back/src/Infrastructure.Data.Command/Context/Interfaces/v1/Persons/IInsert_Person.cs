using Infrastructure.Data.Command.Context.Command.v1.Persons;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Command.Context.Interfaces.v1.Persons
{
    public interface IInsert_Person
    {
        Task<Insert_PersonResponse> InsertPersonAsync(Insert_PersonRequest person);
    }
}
