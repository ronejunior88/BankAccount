using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.v1;
using Infrastructure.Data.Command.Context.Interfaces.v1.Bank;
using Infrastructure.Data.Command.Interfaces.v1;
using Infrastructure.Data.Context.Interfaces.v1;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Api.Controllers.v1
{
    [Route("api/bankaccount")]
    [ApiController]
    public class BankAccountController : Controller
    {
        private readonly IBankAccountCommanderInterface _IBankAccountCommanderInterface;
        private readonly IConfiguration _configuration;
        private readonly IBootstrapper _bootstrapper;

        public BankAccountController(IBootstrapper bootstrapper, IBankAccountCommanderInterface IBankAccountCommanderInterface, IConfiguration configuration)
        {
            _IBankAccountCommanderInterface = IBankAccountCommanderInterface;
            _configuration = configuration;
            _bootstrapper = bootstrapper;
        }

        [HttpPost]
        public async Task<IActionResult> PostBankAccount([FromBody]BankAccount value)
        {
            var response = await _IBankAccountCommanderInterface.InsertBankAccount(_bootstrapper, _configuration, value);
            return Ok(response);
        }

        [HttpGet("/idBank")]
        public async Task<IActionResult> GetBankAccountById(int value)
        {
            var response = await _IBankAccountCommanderInterface.GetBankAccount_SelectById(_bootstrapper, _configuration, value);
            return Ok(new JsonResult(response));
        }
    }
}