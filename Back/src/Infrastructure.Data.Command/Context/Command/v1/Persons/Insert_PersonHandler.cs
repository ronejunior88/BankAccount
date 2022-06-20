using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities.v1;
using Infrastructure.Data.Command.Context.Interfaces.v1.Persons;
using Infrastructure.Data.Repository.Infrastructure.v1;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Data.Command.Context.Command.v1.Persons
{
    public class Insert_PersonHandler : IInsert_Person, IRequestHandler<Insert_PersonRequest, Insert_PersonResponse>
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private PersonRepository _person;

        public Insert_PersonHandler(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
            _connectionString = configuration.GetConnectionString("BankAccount");
            _person = new PersonRepository(_connectionString);
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
