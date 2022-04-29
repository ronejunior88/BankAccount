using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasicAccountOperations.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Data.Context.Context.Command.v1;
using Infrastructure.Data.Context.Context.Interfaces;

namespace Api.Controllers.v1
{
    [Route("api/client")]
    [ApiController]
    public class ClientController : Controller
    {
        private readonly IClientCommandInterface _clientCommand;

        public ClientController(IClientCommandInterface clientCommand)
        {
            _clientCommand = clientCommand;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Person value)
        {
            var response = await _clientCommand.InsertPerson(value);
            return Ok(response);
        }
    }
}