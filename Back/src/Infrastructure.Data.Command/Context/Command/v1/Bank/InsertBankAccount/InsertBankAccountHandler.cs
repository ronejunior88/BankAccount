using AutoMapper;
using Domain.Dto.v1;
using Domain.Entities.v1;
using Infrastructure.Data.Command.Context.Interfaces.v1.Bank;
using Infrastructure.Data.Repository.Infrastructure.v1;
using MediatR;
using Microsoft.Extensions.Configuration;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Data.Command.Context.Command.v1.Bank.InsertBankAccount
{
    public class InsertBankAccountHandler : IInsertBankAccount, IRequestHandler<InsertBankAccountRequest, InsertBankAccountResponse>
    {
        private readonly string _connectionString;
        private BankAccountRepository _bankAccountRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public InsertBankAccountHandler()
        { }


        public InsertBankAccountHandler(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
            _connectionString = configuration.GetConnectionString("BankAccount");
            _bankAccountRepository = new BankAccountRepository(_connectionString);
        }

        public async Task<InsertBankAccountResponse> Handle(InsertBankAccountRequest request, CancellationToken cancellationToken)
        {
            return await InsertBankAccountAsync(_mapper.Map<BankAccount>(request));
        }
        public async Task<InsertBankAccountResponse> InsertBankAccountAsync(BankAccount bankAccount)
        {      
            var response = await _bankAccountRepository.InsertBankAccountAsync(bankAccount);
            return _mapper.Map<InsertBankAccountResponse>(response);
        }           

        //public async Task UpdateBankAccountBalanceByTransferAsync(int bankAccount, decimal balance)
        //{
        //    await _bankAccountRepository.UpdateBankAccountBalanceByTransferAsync(bankAccount, balance);
        //}
    }
}

