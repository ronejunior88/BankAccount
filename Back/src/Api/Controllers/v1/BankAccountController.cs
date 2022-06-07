using AutoMapper;
using Domain.Entities.v1;
using Infrastructure.Data.Command.Context.Interfaces.v1.Bank;
using Infrastructure.Data.Repository.Interfaces.v1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Api.Controllers.v1
{
    [Route("api/accounts")]
    [ApiController]
    public class BankAccountController : Controller
    {
        private readonly IBankAccount _bankAccount;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IBankAccountRepository _bankAccountRepository;
        
       

        public BankAccountController(IBankAccount bankAccount, IConfiguration configuration, IMapper mapper, IBankAccountRepository bankAccountRepository)
        {
            _bankAccount = bankAccount;
            _configuration = configuration;
            _mapper = mapper;
            _bankAccountRepository = bankAccountRepository;
        }

        [HttpPost("/bankAccounts")]
        public async Task<IActionResult> BankAccount([FromBody]BankAccount value)
        {
            await _bankAccount.InsertBankAccountAsync(value);
            return Ok();
        }

        [HttpGet("/bankAccounts/{id}")]
        public async Task<IActionResult> GetBankAccount(int id)
        {
            var response = await _bankAccount.GetBankAccountSelectByIdAsync(id);
            return Ok(new JsonResult(response).Value);
        }
    }
}