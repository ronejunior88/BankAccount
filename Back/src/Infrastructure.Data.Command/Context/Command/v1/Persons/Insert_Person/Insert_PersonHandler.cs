using AutoMapper;
using Domain.Entities.v1;
using Infrastructure.Data.Command.Context.Interfaces.v1.Persons;
using Infrastructure.Data.Repository.Interfaces.v1;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Data.Command.Context.Command.v1.Persons.Insert_Person
{
    public class Insert_PersonHandler : IInsert_Person, IRequestHandler<Insert_PersonRequest, Insert_PersonResponse>
    {
        private readonly IMapper _mapper;
        private IPersonRepository _person;
        public Insert_PersonHandler(IMapper mapper, IPersonRepository person)
        {   
            _mapper = mapper;
            _person = person;
        }
        public Insert_PersonHandler()
        { }
        public async Task<Insert_PersonResponse> Handle(Insert_PersonRequest request, CancellationToken cancellationToken)
        {
           return await InsertPersonAsync(request);
        }
        public async Task<Insert_PersonResponse> InsertPersonAsync(Insert_PersonRequest person)
        {
            var result = await _person.InsertPersonAsync(_mapper.Map<Person>(person));
            return _mapper.Map<Insert_PersonResponse>(result);
        }
    }
}
