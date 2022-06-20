using Domain.Entities.v1;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.Command.Context.Command.v1.Persons.Insert_Person
{
    public class Insert_PersonRequest :Person, IRequest<Insert_PersonResponse>
    {
        
    }
}
