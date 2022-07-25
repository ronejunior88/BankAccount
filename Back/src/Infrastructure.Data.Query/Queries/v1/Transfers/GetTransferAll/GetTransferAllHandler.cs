using AutoMapper;
using Infrastructure.Data.Query.Interfaces.v1;
using Infrastructure.Data.Repository.Interfaces.v1;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Data.Query.Queries.v1.Transfers.GetTransferAll
{
    public class GetTransferAllHandler: IGetTransferAll, IRequestHandler<GetTransferAllRequest, IEnumerable<GetTransferAllResponse>>
    {
        private ITransferRepository _transferRepository;     
        private readonly IMapper _mapper;
        public GetTransferAllHandler(IMapper mapper, ITransferRepository transferRepository)
        {
            _mapper = mapper;
            _transferRepository = transferRepository;
        }
        public async Task<IEnumerable<GetTransferAllResponse>> Handle(GetTransferAllRequest request, CancellationToken cancellationToken)
        {
            return await GetTransferAllAsync();
        }
        public async Task<IEnumerable<GetTransferAllResponse>> GetTransferAllAsync()
        {
            var result = await _transferRepository.GetTransferAllAsync();
            return _mapper.Map<IEnumerable<GetTransferAllResponse>>(result);
        }       
    }
}
