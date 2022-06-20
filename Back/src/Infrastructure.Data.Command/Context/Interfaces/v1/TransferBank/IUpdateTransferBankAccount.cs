using Infrastructure.Data.Command.Context.Command.v1.TransferBank.UpdateTransferBankAccount;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Command.Context.Interfaces.v1.TransferBank
{
    public interface IUpdateTransferBankAccount
    {
        Task<UpdateTransferBankAccountResponse> UpdateTransferBankAccountAsync();
    }
}
