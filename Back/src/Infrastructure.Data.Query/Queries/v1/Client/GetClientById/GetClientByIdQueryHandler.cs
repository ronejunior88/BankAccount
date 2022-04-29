using AutoMapper;
using Infrastructure.Data.Query.Interfaces.v1;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Data.Query.Queries.v1.Client.GetClientById
{
    public class GetClientByIdQueryHandler : IRequestHandler<GetClientByIdQuery, GetClientByIdProcedureResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGetClientByIdProcedure _getClientByIdProcedure;

        public GetClientByIdQueryHandler(
            IMediator mediator,
            IMapper mapper,
            IGetClientByIdProcedure getClientByIdProcedure)
        {
            _mapper = mapper;
            _getClientByIdProcedure = getClientByIdProcedure;
        }
        public Task<GetClientByIdProcedureResponse> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
