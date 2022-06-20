using AutoMapper;
using Infrastructure.Data.Query.Interfaces.v1;
using Infrastructure.Data.Repository.Infrastructure.v1;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Data.Query.Queries.v1.Transfers.GetTransferById
{
    public class GetTransferByIdHandler : IGetTransferById, IRequestHandler<GetTransferByIdRequest,GetTransferByIdResponse>
    {
        private readonly string _connectionString;
        private TransferRepository _transferRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public GetTransferByIdHandler(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
            _connectionString = configuration.GetConnectionString("BankAccount");
            _transferRepository = new TransferRepository(_connectionString);
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
