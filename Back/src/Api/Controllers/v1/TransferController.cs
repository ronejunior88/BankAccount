using Domain.Dto.v1;
using Domain.Entities.v1;
using Infrastructure.Data.Command.Context.Interfaces.v1.Bank;
using Infrastructure.Data.Command.Context.Interfaces.v1.TransferBank;
using Infrastructure.Data.Context.Interfaces.v1;
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
        private readonly ITransferBankAccountInterface _ITransferBankAccount;
        private readonly IBankAccountCommanderInterface _IBankAccountCommanderInterface;
        private readonly IConfiguration _configuration;
        private readonly IBootstrapper _bootstrapper;

        public TransferController(IConfiguration configuration, IBootstrapper bootstrapper, 
                                  ITransferBankAccountInterface ITransferBankAccount, 
                                  IBankAccountCommanderInterface IBankAccountCommanderInterface)
        {
            _configuration = configuration;
            _bootstrapper = bootstrapper;
            _ITransferBankAccount = ITransferBankAccount;
            _IBankAccountCommanderInterface = IBankAccountCommanderInterface;
        }

        [HttpGet("/Transfers/{id}")]
        public async Task<IActionResult> GetTransfer(int id)
        {
            try
            {
                var response = await _ITransferBankAccount.GetTransferById(_bootstrapper, _configuration, id);
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
            var response = await _ITransferBankAccount.GetTransferByClientId(_bootstrapper, _configuration, id);
            return Ok(new JsonResult(response).Value);
        }

        [HttpGet("/Transfers/all")]
        public async Task<IActionResult> GetTransferAll()
        {
            var response = await _ITransferBankAccount.GetTransferAll(_bootstrapper, _configuration);
            return Ok(new JsonResult(response).Value);
        }

        [HttpPost("/Transfers/bankAccount")]
        public async Task<IActionResult> InsertTransferBankAccount([FromBody]Transfer transfer)
        {
            var bankAccount = await _IBankAccountCommanderInterface.GetBankAccount_SelectById(_bootstrapper, _configuration, transfer.IdBankAccount);

            if (bankAccount != null && bankAccount.Id > 0) 
            {
                 var response = await _ITransferBankAccount.InsertTransferBankAccount(_bootstrapper, _configuration, transfer);

                if(response != null)
                {
                    return Ok(new JsonResult(response).Value);
                }
                else 
                {
                    return BadRequest("Tipo de movimentação Invalido, informe: Saque, Deposito, Transferencia ou Saldo Indisponivel!");
                }
                        
            }
            else
            {
                return NotFound("Account Bank not found");
            }
            
        }

       
        [HttpPut("/Transfers/insert")]
        public async void InsertTransfer() 
        {
            await _ITransferBankAccount.UpdateTransferBankAccount(_bootstrapper, _configuration);
        }
    }
}