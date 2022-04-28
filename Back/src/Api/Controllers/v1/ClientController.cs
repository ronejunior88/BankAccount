using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1
{
    [Route("api/client")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        public async Task<string> GetClient()
        { 
            return  "";
        }
    }
}