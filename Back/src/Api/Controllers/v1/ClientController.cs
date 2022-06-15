using Domain.Entities.v1;
using Infrastructure.Data.Command.Context.Command.v1.Clients;
using Infrastructure.Data.Command.Interfaces.v1.Client;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Api.Controllers.v1
{
    [Route("api/clients")]
    [ApiController]
    public class ClientController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;

        public ClientController(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            _configuration = configuration;
        }

        [HttpGet("/Clients/{id}")]
        public async Task<IActionResult> GetClientById(int id)
        {
            var response = await _mediator.Send(new ClientRequest(id));
            return Ok(response);
        }
    }
}