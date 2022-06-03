using Infrastructure.Data.Context.Interfaces.v1;
using Domain.Entities.v1;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain.Dto.v1;

namespace Infrastructure.Data.Command.Context.Interfaces.v1.Bank
{
    public interface IBankAccount
    {
        Task<BankAccount> InsertBankAccount(IBootstrapper bootstrapper, IConfiguration configuration, BankAccount bankAccount);
        Task<BankAccountDto> GetBankAccountSelectById(IBootstrapper bootstrapper, IConfiguration configuration, int bankAccount);
        Task<bool> UpdateBankAccountBalanceByTransfer(IBootstrapper bootstrapper, IConfiguration configuration, int bankAccount, decimal balance);
    }
}
