﻿using Domain.Dto.v1;
using Domain.Entities.v1;
using System.Threading.Tasks;

namespace Infrastructure.Data.Command.Context.Interfaces.v1.Bank
{
    public interface IBankAccount
    {
        Task InsertBankAccount(BankAccount bankAccount);
        Task<BankAccountDto> GetBankAccountSelectById(int bankAccount);
        Task<bool> UpdateBankAccountBalanceByTransfer(int bankAccount, decimal balance);
    }
}