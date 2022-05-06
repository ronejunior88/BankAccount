using Domain.Entities.v1;
using Infrastructure.Data.Command.Interfaces.v1.Client;
using Infrastructure.Data.Context.Interfaces.v1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Api.Controllers.v1
{
    [Route("api/client")]
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

        [HttpPost("/PostClient")]
        public async Task<IActionResult> PostClient([FromBody]Person value)
        {
            var response = await _clientCommand.InsertPerson(_bootstrapper, _configuration, value);
            return Ok(response);
        }

        [HttpGet("/GetClientById")]
        public async Task<IActionResult> GetClientById(int value)
        {
            var response = await _clientCommand.GetClientById(_bootstrapper, _configuration, value);
            return Ok(response.Value);
        }
    }
}