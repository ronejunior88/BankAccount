using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data.Command.Context.Command.v1.Persons;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Api.Controllers.v1
{
    [Route("api/persons")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;

        public PersonController(IConfiguration configuration, IMediator mediator)
        {
            _mediator = mediator;
            _configuration = configuration;
        }

        [HttpPost("/Persons")]
        public async Task<ActionResult> GetClient([FromBody]PersonRequest person)
        {
            await _mediator.Send(person);
            return Ok("Pessoa Cadastrada com Suceeso! ");
        }

    }
}