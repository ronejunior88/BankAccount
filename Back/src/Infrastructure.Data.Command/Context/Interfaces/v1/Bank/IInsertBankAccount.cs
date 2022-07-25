using Domain.Entities.v1;
using Infrastructure.Data.Command.Context.Command.v1.Bank.InsertBankAccount;
using System.Threading.Tasks;

namespace Infrastructure.Data.Command.Context.Interfaces.v1.Bank
{
    public interface IInsertBankAccount
    {
        Task<InsertBankAccountResponse> InsertBankAccountAsync(BankAccount bankAccount);
    }
}
