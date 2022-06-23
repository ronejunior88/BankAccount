using AutoMapper;
using Domain.Entities.v1;
using Infrastructure.Data.Command.Context.Interfaces.v1.Bank;
using Infrastructure.Data.Repository.Interfaces.v1;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Data.Command.Context.Command.v1.Bank.InsertBankAccount
{
    public class InsertBankAccountHandler : IInsertBankAccount, IRequestHandler<InsertBankAccountRequest, InsertBankAccountResponse>
    {      
        private IBankAccountRepository _bankAccountRepository;    
        private readonly IMapper _mapper;
        public InsertBankAccountHandler()
        { }
        public InsertBankAccountHandler(IMapper mapper, IBankAccountRepository bankAccountRepository)
        {
            _mapper = mapper;
            _bankAccountRepository = bankAccountRepository;
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
    }
}

