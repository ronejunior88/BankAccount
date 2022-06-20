using Domain.Dto.v1;
using Domain.Entities.v1;
using Infrastructure.Data.Command.Context.Command.v1.TransferBank.TransferBankAccount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Data.Command.Context.Interfaces.v1.TransferBank
{
    public interface ITransferBankAccount
    {
        Task<TransferBankAccountResponse> InsertTransferBankAccountAsync(Transfer transfer);
    }
}
