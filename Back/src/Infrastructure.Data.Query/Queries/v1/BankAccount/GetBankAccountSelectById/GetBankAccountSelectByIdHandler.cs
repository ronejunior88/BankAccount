using AutoMapper;
using Domain.Dto.v1;
using Infrastructure.Data.Query.Interfaces.v1;
using Infrastructure.Data.Repository.Infrastructure.v1;
using Infrastructure.Data.Repository.Interfaces.v1;
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
        private IBankAccountRepository _bankAccountRepository;
        private readonly IMapper _mapper;
        public GetBankAccountSelectByIdHandler(IMapper mapper, IBankAccountRepository bankAccountRepository)
        {
            _mapper = mapper;
            _bankAccountRepository = bankAccountRepository;
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
