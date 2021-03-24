using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Instagram.WebApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Instagram.WebApi.Controllers
{
    [ApiController]
    [Route("api/token")]
    public class InstagramController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public InstagramController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        // GET: api/values
        [HttpGet("renew")]
        public async Task<IActionResult> Get([FromQuery] string token)
        {
            return Ok(await _tokenService.RenewToken(token));
        }

    }
}
