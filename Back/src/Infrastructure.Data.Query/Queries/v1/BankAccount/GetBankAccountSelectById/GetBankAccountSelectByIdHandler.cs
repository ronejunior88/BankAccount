using AutoMapper;
using Domain.Dto.v1;
using Infrastructure.Data.Query.Interfaces.v1;
using Infrastructure.Data.Repository.Infrastructure.v1;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Data.Query.Queries.v1.BankAccount.GetBankAccountSelectById
{
    public class GetBankAccountSelectByIdHandler : IGetBankAccountSelectById, IRequestHandler<GetBankAccountSelectByIdRequest,GetBankAccountSelectByIdResponse>
    {
        private readonly string _connectionString;
        private BankAccountRepository _bankAccountRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public GetBankAccountSelectByIdHandler(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
            _connectionString = configuration.GetConnectionString("BankAccount");
            _bankAccountRepository = new BankAccountRepository(_connectionString);
        }
        public async Task<GetBankAccountSelectByIdResponse> Handle(GetBankAccountSelectByIdRequest request, CancellationToken cancellationToken)
        {
            var result = await GetBankAccountSelectByIdAsync(request.Id);
            return result;

        }

        public async Task<GetBankAccountSelectByIdResponse> GetBankAccountSelectByIdAsync(int Id)
        {
            var resposnse = await _bankAccountRepository.GetBankAccountSelectByIdAsync(Id);
            return _mapper.Map<GetBankAccountSelectByIdResponse>(resposnse);
        }  
    }
}
