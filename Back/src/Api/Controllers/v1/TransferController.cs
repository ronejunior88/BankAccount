using Domain.Entities.v1;
using Infrastructure.Data.Command.Context.Interfaces.v1.Bank;
using Infrastructure.Data.Command.Context.Interfaces.v1.TransferBank;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace Api.Controllers.v1
{
    [Route("api/transferAccounts")]
    [ApiController]
    public class TransferController : Controller
    {
        private readonly ITransferBankAccount _transferBankAccount;
        private readonly IBankAccount _bankAccount;
        private readonly IConfiguration _configuration;

        public TransferController(IConfiguration configuration,
                                  ITransferBankAccount ITransferBankAccount,
                                  IBankAccount bankAccount)
        {
            _configuration = configuration;
            _transferBankAccount = ITransferBankAccount;
            _bankAccount = bankAccount;
        }

        [HttpGet("/Transfers/{id}")]
        public async Task<IActionResult> GetTransfer(int id)
        {
            try
            {
                var response = await _transferBankAccount.GetTransferByIdAsync(id);
                  return Ok(response.Value);               
            }
            catch (Exception ex)
            {
                throw new Exception("Erro inesperado: ", ex);
            }
            
        }

        [HttpGet("/Transfers/{id}/client")]
        public async Task<IActionResult> GetTransferByClientId(int id)
        {
            var response = await _transferBankAccount.GetTransferByClientIdAsync(id);
            return Ok(new JsonResult(response).Value);
        }

        [HttpGet("/Transfers/all")]
        public async Task<IActionResult> GetTransferAll()
        {
            var response = await _transferBankAccount.GetTransferAllAsync();
            return Ok(new JsonResult(response).Value);
        }

        [HttpPost("/Transfers/bankAccount")]
        public async Task<IActionResult> InsertTransferBankAccount([FromBody]Transfer transfer)
        {
            var bankAccount = await _bankAccount.GetBankAccountSelectByIdAsync(transfer.IdBankAccount);

            if (bankAccount != null && bankAccount.Id > 0) 
            {
                  await _transferBankAccount.InsertTransferBankAccountAsync(transfer);         
                   return Ok();        
            }
            else
            {
                return NotFound("Account Bank not found");
            }
            
        }

       
        [HttpPut("/Transfers/insert")]
        public void InsertTransfer() 
        {
             _transferBankAccount.UpdateTransferBankAccountAsync();
        }
    }
}