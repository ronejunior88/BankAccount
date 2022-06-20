using Infrastructure.Data.Command.Context.Command.v1.Bank.InsertBankAccount;
using Infrastructure.Data.Query.Queries.v1.BankAccount.GetBankAccountSelectById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Api.Controllers.v1
{
    [Route("api/accounts")]
    [ApiController]
    public class BankAccountController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;

        public BankAccountController(IConfiguration configuration, IMediator mediator)
        {
           
            _configuration = configuration;
            _mediator = mediator;
        }

        [HttpPost("/bankAccounts")]
        public async Task<IActionResult> BankAccount([FromBody]InsertBankAccountRequest value)
        {
            await _mediator.Send(value);
            return Ok("Conta cadastrada com sucesso.");
        }

        [HttpGet("/bankAccounts/{id}")]
        public async Task<IActionResult> GetBankAccount(int id)
        {
            var response = await _mediator.Send(new GetBankAccountSelectByIdRequest(id));
            return Ok(new JsonResult(response).Value);
        }
    }
}