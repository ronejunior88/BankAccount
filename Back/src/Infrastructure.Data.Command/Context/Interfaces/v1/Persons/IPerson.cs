using Infrastructure.Data.Command.Context.Command.v1.Persons;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Command.Context.Interfaces.v1.Persons
{
    public interface IPerson
    {
        Task<PersonResponse> InsertPersonAsync(PersonRequest person);
    }
}
