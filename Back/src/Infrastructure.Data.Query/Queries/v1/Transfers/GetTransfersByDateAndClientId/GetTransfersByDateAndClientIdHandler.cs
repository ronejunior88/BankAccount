using AutoMapper;
using Infrastructure.Data.Query.Interfaces.v1;
using Infrastructure.Data.Repository.Interfaces.v1;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Data.Query.Queries.v1.Transfers.GetTransfersByDateAndClientId
{
    public class GetTransfersByDateAndClientIdHandler: IGetTransfersByDateAndClientId, IRequestHandler<GetTransfersByDateAndClientIdRequest, IEnumerable<GetTransfersByDateAndClientIdResponse>>
    {
        private ITransferRepository _transferRepository;
        private readonly IMapper _mapper;
        public GetTransfersByDateAndClientIdHandler(IMapper mapper, ITransferRepository transferRepository)
        {
            _mapper = mapper;
            _transferRepository = transferRepository;
        }
        public async Task<IEnumerable<GetTransfersByDateAndClientIdResponse>> Handle(GetTransfersByDateAndClientIdRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _transferRepository.GetTransferAllAsync();
                return _mapper.Map<IEnumerable<GetTransfersByDateAndClientIdResponse>>(response.Where(res => (res.Date >= request.DateInicial &&
                                                                                               res.Date <= request.DateFinal)
                                                                                                && res.Client_Id == request.IdClient)
                                                                                                .OrderBy(x => x.Date));
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao consultar Transferencias por Data e Cliente", ex);
            }
        }
    }
}
