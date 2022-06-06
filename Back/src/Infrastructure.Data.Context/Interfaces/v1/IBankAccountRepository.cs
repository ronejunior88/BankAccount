using Domain.Dto.v1;
using Domain.Entities.v1;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repository.Interfaces.v1
{
    public interface IBankAccountRepository
    {
        Task InsertBankAccount(BankAccount bankAccount);
        Task<BankAccountDto> GetBankAccountSelectById(int bankAccount);
        Task<bool> UpdateBankAccountBalanceByTransfer(int bankAccount, decimal balance);
    }
}
