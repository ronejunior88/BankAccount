using BasicAccountOperations.Domain.Model;
using Infrastructure.Data.Command.Interfaces.v1;
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

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Person value)
        {
            var response = await _clientCommand.InsertPerson(_bootstrapper, _configuration, value);
            return Ok(response);
        }

        [HttpGet("/id")]
        public async Task<IActionResult> Get(int value)
        {
            var response = await _clientCommand.GetClientById(_bootstrapper, _configuration, value);
            return Ok(response.Value);
        }
    }
}