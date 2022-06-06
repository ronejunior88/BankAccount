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
        Task<JsonResult> GetTransferById(int idTransfer);
        Task<List<TransferBankAccountIdClientDto>> GetTransferByClientId(int idClient);
        Task<List<TransferBankAccountAllDto>> GetTransferAll();
        Task<Transfer> InsertTransferBankAccount(Transfer transfer);
        Task<Transfer> UpdateTransferBankAccount();
    }
}
