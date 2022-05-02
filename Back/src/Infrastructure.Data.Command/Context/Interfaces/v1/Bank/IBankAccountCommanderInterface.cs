using Infrastructure.Data.Context.Interfaces.v1;
using Domain.Entities.v1;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.Data.Command.Context.Interfaces.v1.Bank
{
    public interface IBankAccountCommanderInterface
    {
        Task<BankAccount> InsertBankAccount(IBootstrapper bootstrapper, IConfiguration configuration, BankAccount bankAccount);
        Task<JsonResult> GetBankAccount_SelectById(IBootstrapper bootstrapper, IConfiguration configuration, int bankAccount);
    }
}
