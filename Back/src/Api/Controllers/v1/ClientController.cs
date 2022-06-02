using Domain.Entities.v1;
using Infrastructure.Data.Command.Interfaces.v1.Client;
using Infrastructure.Data.Context.Interfaces.v1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Api.Controllers.v1
{
    [Route("api/clients")]
    [ApiController]
    public class ClientController : Controller
    {
        private readonly IClientCommandInterface _clientCommand;
        private readonly IConfiguration _configuration;
        private readonly IBootstrapper _bootstrapper;

        public ClientController(IBootstrapper bootstrapper, IClientCommandInterface clientCommand, IConfiguration configuration)
        {
            _clientCommand = clientCommand;
            _configuration = configuration;
            _bootstrapper = bootstrapper;
        }

        [HttpPost("/Clients")]
        public async Task<IActionResult> GetClient([FromBody]Person person)
        {
            var response = await _clientCommand.InsertPerson(_bootstrapper, _configuration, person);
            return Ok(response);
        }

        [HttpGet("/Clients/{id}")]
        public async Task<IActionResult> GetClientById(int id)
        {
            var response = await _clientCommand.GetClientById(_bootstrapper, _configuration, id);
            return Ok(response.Value);
        }
    }
}