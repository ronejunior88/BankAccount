using Domain.Entities.v1;
using MediatR;

namespace Infrastructure.Data.Command.Context.Command.v1.Persons.Insert_Person
{
    public class Insert_PersonRequest :Person, IRequest<Insert_PersonResponse>
    {   }
}
