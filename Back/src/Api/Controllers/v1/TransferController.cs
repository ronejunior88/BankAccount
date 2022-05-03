using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data.Command.Context.Interfaces.v1.Transfer;
using Infrastructure.Data.Context.Interfaces.v1;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Api.Controllers.v1
{
    [Route("api/transferaccount")]
    [ApiController]
    public class TransferController : Controller
    {
        private readonly ITransferBankAccountInterface _ITransferBankAccount;
        private readonly IConfiguration _configuration;
        private readonly IBootstrapper _bootstrapper;

        public TransferController(IConfiguration configuration, IBootstrapper bootstrapper, ITransferBankAccountInterface ITransferBankAccount)
        {
            _configuration = configuration;
            _bootstrapper = bootstrapper;
            _ITransferBankAccount = ITransferBankAccount;
        }

        [HttpGet("/idTransfer")]
        public async Task<IActionResult> GetTransferById(int value)
        {
            var response = await _ITransferBankAccount.GetTransferById(_bootstrapper, _configuration, value);
            return Ok(response.Value);
        }

        [HttpGet("/idClientTransfer")]
        public async Task<IActionResult> GetTransferByClientId(int value)
        {
            var response = await _ITransferBankAccount.GetTransferByClientId(_bootstrapper, _configuration, value);
            return Ok(response.Value);
        }

        [HttpGet]
        public async Task<IActionResult> GetTransferAll()
        {
            var response = await _ITransferBankAccount.GetTransferAll(_bootstrapper, _configuration);
            return Ok(response.Value);
        }
    }
}