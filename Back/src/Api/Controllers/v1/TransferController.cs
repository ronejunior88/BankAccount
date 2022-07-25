using Domain.Entities.v1;
using Infrastructure.Data.Command.Context.Command.v1.TransferBank.TransferBankAccount;
using Infrastructure.Data.Command.Context.Command.v1.TransferBank.UpdateTransferBankAccount;
using Infrastructure.Data.Query.Queries.v1.Transfers.GetTransferAll;
using Infrastructure.Data.Query.Queries.v1.Transfers.GetTransferByClientId;
using Infrastructure.Data.Query.Queries.v1.Transfers.GetTransferById;
using Infrastructure.Data.Query.Queries.v1.Transfers.GetTransfersByDate;
using Infrastructure.Data.Query.Queries.v1.Transfers.GetTransfersByDateAndClientId;
using MediatR;
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
        private readonly IConfiguration _configuration;
        private readonly IMediator _mediator;

        public TransferController(IConfiguration configuration,
                                  IMediator mediator)
        {
            _configuration = configuration;
            _mediator = mediator;
        }

        [HttpGet("/Transfers/{id}")]
        public async Task<IActionResult> GetTransfer(int id)
        {
            try
            {
                var response = await _mediator.Send(new GetTransferByIdRequest(id));
                return Ok(response);               
            }
            catch (Exception ex)
            {
                throw new Exception("Erro inesperado: ", ex);
            }
            
        }

        [HttpGet("/Transfers/{id}/client")]
        public async Task<IActionResult> GetTransferByClientId(int id)
        {
            var response = await _mediator.Send(new GetTransferByClientIdRequest(id));
            return Ok(response);
        }

        [HttpGet("/Transfers/all")]
        public async Task<IActionResult> GetTransferAll()
        {
            var response = await _mediator.Send(new GetTransferAllRequest());
            return Ok(response);
        }

        [HttpGet("/transfers/{dateInicial}/{dateFinal}/Date")]
        public async Task<IActionResult> GetTransfersByDate(DateTime dateInicial, DateTime dateFinal)
        {
            var response = await _mediator.Send(new GetTransferByDateRequest(dateInicial, dateFinal));
            return Ok(response);
        }

        [HttpGet("/transfers/{dateInicial}/{dateFinal}/{idClient}/Date")]
        public async Task<IActionResult> GetTransfersByDateAndIdClient(DateTime dateInicial, DateTime dateFinal, int idClient)
        {
            var response = await _mediator.Send(new GetTransfersByDateAndClientIdRequest(dateInicial, dateFinal, idClient));
            return Ok(response);
        }        

        [HttpPost("/Transfers/bankAccount")]
        public async Task<IActionResult> InsertTransferBankAccount([FromBody]Transfer transfer)
        {
            await _mediator.Send(new TransferBankAccountRequest(transfer));
            return Ok("Menssagem Enviada com Sucesso");         
        }


        [HttpPut("/Transfers/insert")]
        public async Task<ActionResult> InsertTransfer()
        {
            await _mediator.Send(new UpdateTransferBankAccountRequest());
            return Ok("Mensagens lidas com sucesso.");
        }
    }
}