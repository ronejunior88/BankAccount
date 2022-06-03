using Domain.Dto.v1;
using Domain.Entities.v1;
using Infrastructure.Data.Context.Interfaces.v1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Data.Command.Context.Interfaces.v1.TransferBank
{
    public interface ITransferBankAccount
    {
        Task<JsonResult> GetTransferById(IBootstrapper bootstrapper, IConfiguration configuration, int idTransfer);
        Task<List<TransferBankAccountIdClientDto>> GetTransferByClientId(IBootstrapper bootstrapper, IConfiguration configuration, int idClient);
        Task<List<TransferBankAccountAllDto>> GetTransferAll(IBootstrapper bootstrapper, IConfiguration configuration);
        Task<Transfer> InsertTransferBankAccount(IBootstrapper bootstrapper, IConfiguration configuration, Transfer transfer);
        Task<Transfer> UpdateTransferBankAccount(IBootstrapper bootstrapper, IConfiguration configuration);
    }
}
