using AutoMapper;
using Infrastructure.Data.Query.Interfaces.v1;
using Infrastructure.Data.Query.Queries.v1.BankAccount.GetBankAccountSelectById;
using Infrastructure.Data.Query.Queries.v1.Transfers.GetTransferById;
using Infrastructure.Data.Repository.Infrastructure.v1;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Data.Query.Queries.v1.Transfers.GetTransferByClientId
{
    public class GetTransferByClientIdHandler : IGetTransferByClientId, IRequestHandler<GetTransferByClientIdRequest, IEnumerable<GetTransferByClientIdResponse>>
    {
        private readonly string _connectionString;
        private TransferRepository _transferRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public GetTransferByClientIdHandler(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
            _connectionString = configuration.GetConnectionString("BankAccount");
            _transferRepository = new TransferRepository(_connectionString);
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
