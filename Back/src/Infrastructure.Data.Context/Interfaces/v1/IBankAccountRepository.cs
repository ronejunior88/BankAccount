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
        Task InsertBankAccountAsync(BankAccount bankAccount);
        Task<BankAccountDto> GetBankAccountSelectByIdAsync(int bankAccount);
        Task UpdateBankAccountBalanceByTransferAsync(int bankAccount, decimal balance);
    }
}
