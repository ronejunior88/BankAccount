using AutoMapper;
using Infrastructure.Data.Query.Interfaces.v1;
using Infrastructure.Data.Repository.Interfaces.v1;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Data.Query.Queries.v1.Transfers.GetTransferByClientId
{
    public class GetTransferByClientIdHandler : IGetTransferByClientId, IRequestHandler<GetTransferByClientIdRequest, IEnumerable<GetTransferByClientIdResponse>>
    {     
        private ITransferRepository _transferRepository;     
        private readonly IMapper _mapper;
        public GetTransferByClientIdHandler(IMapper mapper, ITransferRepository transferRepository)
        {
            _mapper = mapper;
            _transferRepository = transferRepository;
        }
        public async Task<IEnumerable<GetTransferByClientIdResponse>> Handle(GetTransferByClientIdRequest transfer, CancellationToken cancellationToken)
        {
            var result = await GetTransferByClientIdAsync(transfer.Id);
            return result;
        }
        public async Task<IEnumerable<GetTransferByClientIdResponse>> GetTransferByClientIdAsync(int idClient)
        {
            var result = await _transferRepository.GetTransferByClientIdAsync(idClient);
            return _mapper.Map<IEnumerable<GetTransferByClientIdResponse>>(result);
        }     
    }
}
