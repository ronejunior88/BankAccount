using Domain.Dto.v1;
using Domain.Entities.v1;
using Infrastructure.Data.Command.Context.Command.v1.Client;
using Infrastructure.Data.Command.Context.Interfaces.v1.Bank;
using Infrastructure.Data.Repository.Infrastructure.v1;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Infrastructure.Data.Command.Context.Command.v1.Bank
{
    public class BankAccountCommand : IBankAccount
    {
        private readonly string _connectionString;
        private BankAccountRepository _bankAccountRepository;
        private readonly IConfiguration _configuration;
        public BankAccountCommand()
        { }

        public BankAccountCommand(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("BankAccount");
        }

        public async Task InsertBankAccountAsync(BankAccount bankAccount)
        {
            _bankAccountRepository = new BankAccountRepository(_connectionString);
            await _bankAccountRepository.InsertBankAccountAsync(bankAccount);
        }
        
        public async Task<BankAccountDto> GetBankAccountSelectByIdAsync(int bankAccount)
        {
            _bankAccountRepository = new BankAccountRepository(_connectionString);
            var bkDto = await _bankAccountRepository.GetBankAccountSelectByIdAsync(bankAccount);
            return bkDto;
        }

       

        public async Task UpdateBankAccountBalanceByTransferAsync(int bankAccount, decimal balance)
        {
            _bankAccountRepository = new BankAccountRepository(_connectionString);
            await _bankAccountRepository.UpdateBankAccountBalanceByTransferAsync(bankAccount, balance);
        }
    }
}

