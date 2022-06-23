using AutoMapper;
using Infrastructure.Data.Query.Interfaces.v1;
using Infrastructure.Data.Repository.Interfaces.v1;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Data.Query.Queries.v1.Transfers.GetTransferById
{
    public class GetTransferByIdHandler : IGetTransferById, IRequestHandler<GetTransferByIdRequest,GetTransferByIdResponse>
    {     
        private ITransferRepository _transferRepository;       
        private readonly IMapper _mapper;

        public GetTransferByIdHandler(IMapper mapper, ITransferRepository transferRepository)
        {
            _mapper = mapper;
            _transferRepository = transferRepository;
        }

        public async Task<GetTransferByIdResponse> Handle(GetTransferByIdRequest request, CancellationToken cancellationToken)
        {
            var result = await GetTransferByIdAsync(request.Id);
            return result;
        }

        public async Task<GetTransferByIdResponse> GetTransferByIdAsync(int idTransfer)
        {
            var result = await _transferRepository.GetTransferByIdAsync(idTransfer);
            return _mapper.Map<GetTransferByIdResponse>(result);
        }
    }
}
