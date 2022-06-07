using Domain.Entities.v1;
using Infrastructure.Data.Command.Interfaces.v1.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Api.Controllers.v1
{
    [Route("api/clients")]
    [ApiController]
    public class ClientController : Controller
    {
        private readonly IClient _client;
        private readonly IConfiguration _configuration;

        public ClientController(IClient client, IConfiguration configuration)
        {
            _client = client;
            _configuration = configuration;
        }

        [HttpPost("/Clients")]
        public async Task<IActionResult> GetClient([FromBody]Person person)
        {
            await _client.InsertPersonAsync(person);
            return Ok();
        }

        [HttpGet("/Clients/{id}")]
        public async Task<IActionResult> GetClientById(int id)
        {
            var response = await _client.GetClientByIdAsync(id);
            return Ok(response.Value);
        }
    }
}