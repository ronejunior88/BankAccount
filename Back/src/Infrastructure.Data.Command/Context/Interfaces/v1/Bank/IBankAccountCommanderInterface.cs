using Infrastructure.Data.Context.Interfaces.v1;
using Domain.Entities.v1;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain.Dto.v1;

namespace Infrastructure.Data.Command.Context.Interfaces.v1.Bank
{
    public interface IBankAccountCommanderInterface
    {
        Task<BankAccount> InsertBankAccount(IBootstrapper bootstrapper, IConfiguration configuration, BankAccount bankAccount);
        Task<BankAccountDto> GetBankAccount_SelectById(IBootstrapper bootstrapper, IConfiguration configuration, int bankAccount);
        Task<bool> UpdateBankAccount_BalanceByTransfer(IBootstrapper bootstrapper, IConfiguration configuration, int bankAccount, decimal balance);
    }
}
