using Domain.Dto.v1;
using Domain.Entities.v1;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repository.Interfaces.v1
{
    public interface ITransferRepository
    {
        Task<Transfer> GetTransferByIdAsync(int idTransfer);
        Task<IEnumerable<TransferBankAccountIdClientDto>> GetTransferByClientIdAsync(int idClient);
        Task<IEnumerable<TransferBankAccountAllDto>> GetTransferAllAsync();
        Task<Transfer> insertTransferAsync(Transfer transfer);
    }
}
