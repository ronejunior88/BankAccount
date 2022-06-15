using Domain.Entities.v1;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.Command.Context.Command.v1.Persons
{
    public class PersonRequest :Person, IRequest<PersonResponse>
    {
        
    }
}
