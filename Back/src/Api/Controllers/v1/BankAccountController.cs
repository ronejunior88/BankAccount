using AutoMapper;
using Domain.Entities.v1;
using Infrastructure.Data.Command.Context.Interfaces.v1.Bank;
using Infrastructure.Data.Query.Queries.v1.BankAccount.GetBankAccountSelectById;
using Infrastructure.Data.Repository.Interfaces.v1;
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

        //[HttpPost("/bankAccounts")]
        //public async Task<IActionResult> BankAccount([FromBody]BankAccount value)
        //{
        //    await _bankAccount.InsertBankAccountAsync(value);
        //    return Ok();
        //}

        [HttpGet("/bankAccounts/{id}")]
        public async Task<IActionResult> GetBankAccount(int id)
        {
            var response = await _mediator.Send(new GetBankAccountSelectByIdRequest(id));
            return Ok(new JsonResult(response).Value);
        }
    }
}