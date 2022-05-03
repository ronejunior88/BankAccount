using Infrastructure.Data.Context.Interfaces.v1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Command.Context.Interfaces.v1.Transfer
{
    public interface ITransferBankAccountInterface
    {
        Task<JsonResult> GetTransferById(IBootstrapper bootstrapper, IConfiguration configuration, int idTransfer);
        Task<JsonResult> GetTransferByClientId(IBootstrapper bootstrapper, IConfiguration configuration, int idClient);
        Task<JsonResult> GetTransferAll(IBootstrapper bootstrapper, IConfiguration configuration);

    }
}
