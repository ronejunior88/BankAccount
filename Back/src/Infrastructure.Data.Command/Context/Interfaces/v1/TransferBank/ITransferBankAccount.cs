using Domain.Dto.v1;
using Domain.Entities.v1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Data.Command.Context.Interfaces.v1.TransferBank
{
    public interface ITransferBankAccount
    {
        Task<JsonResult> GetTransferByIdAsync(int idTransfer);
        Task<IEnumerable<TransferBankAccountIdClientDto>> GetTransferByClientIdAsync(int idClient);
        Task<IEnumerable<TransferBankAccountAllDto>> GetTransferAllAsync();
        Task InsertTransferBankAccountAsync(Transfer transfer);
        Task UpdateTransferBankAccountAsync();
    }
}
