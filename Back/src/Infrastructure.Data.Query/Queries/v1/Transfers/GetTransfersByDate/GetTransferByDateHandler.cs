using AutoMapper;
using Infrastructure.Data.Query.Interfaces.v1;
using Infrastructure.Data.Repository.Interfaces.v1;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Data.Query.Queries.v1.Transfers.GetTransfersByDate
{
    public class GetTransferByDateHandler : IGetTransfersByDate, IRequestHandler<GetTransferByDateRequest, IEnumerable<GetTransferByDateResponse>>
    {
        private ITransferRepository _transferRepository;
        private readonly IMapper _mapper;
        public GetTransferByDateHandler(IMapper mapper, ITransferRepository transferRepository)
        {
            _mapper = mapper;
            _transferRepository = transferRepository;
        }
        public Task<IEnumerable<GetTransferByDateResponse>> Handle(GetTransferByDateRequest request, CancellationToken cancellationToken)
        {
            return GetTransfersByDate(request.DateInicial, request.DateFinal);
        }

        public async Task<IEnumerable<GetTransferByDateResponse>> GetTransfersByDate(DateTime DateInicial, DateTime DateFinal)
        {
            try
            {
                var response = await _transferRepository.GetTransferAllAsync();
                return _mapper.Map<IEnumerable<GetTransferByDateResponse>>(response.Where(res => res.Date >= DateInicial && 
                                                                                                 res.Date <= DateFinal));
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao consultar Transferencias por Data", ex);
            }
        }
    }
}
