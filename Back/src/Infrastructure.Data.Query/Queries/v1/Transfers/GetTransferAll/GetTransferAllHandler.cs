using AutoMapper;
using Infrastructure.Data.Query.Interfaces.v1;
using Infrastructure.Data.Repository.Infrastructure.v1;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Data.Query.Queries.v1.Transfers.GetTransferAll
{
    public class GetTransferAllHandler: IGetTransferAll, IRequestHandler<GetTransferAllRequest, IEnumerable<GetTransferAllResponse>>
    {
        private readonly string _connectionString;
        private TransferRepository _transferRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public GetTransferAllHandler(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
            _connectionString = configuration.GetConnectionString("BankAccount");
            _transferRepository = new TransferRepository(_connectionString);
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
