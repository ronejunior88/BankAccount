using Infrastructure.Data.Query.Queries.v1.Client.ClientSelectById;
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
            var response = await _mediator.Send(new ClientSelectByIdRequest(id));
            return Ok(response);
        }
    }
}