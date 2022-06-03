using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Dto.v1;
using Domain.Entities.v1;
using Infrastructure.Data.Command.Context.Interfaces.v1.Bank;
using Infrastructure.Data.Command.Interfaces.v1;
using Infrastructure.Data.Context.Interfaces.v1;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Api.Controllers.v1
{
    [Route("api/accounts")]
    [ApiController]
    public class BankAccountController : Controller
    {
        private readonly IBankAccount _bankAccount;
        private readonly IConfiguration _configuration;
        private readonly IBootstrapper _bootstrapper;
        private readonly IMapper _mapper;

        public BankAccountController(IBootstrapper bootstrapper, IBankAccount bankAccount, IConfiguration configuration, IMapper mapper)
        {
            _bankAccount = bankAccount;
            _configuration = configuration;
            _bootstrapper = bootstrapper;
            _mapper = mapper;
        }

        [HttpPost("/bankAccounts")]
        public async Task<IActionResult> BankAccount([FromBody]BankAccount value)
        {
            var response = await _bankAccount.InsertBankAccount(_bootstrapper, _configuration, value);
            return Ok(response);
        }

        [HttpGet("/bankAccounts/{id}")]
        public async Task<IActionResult> GetBankAccount(int id)
        {
            var response = await _bankAccount.GetBankAccountSelectById(_bootstrapper, _configuration,id);
            return Ok(new JsonResult(response).Value);
        }
    }
}