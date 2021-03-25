using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Instagram.Entity.Context;
using Instagram.WebApi.Interfaces;
using Instagram.WebApi.Serializers;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Instagram.WebApi.Controllers
{
    [ApiController]
    [Route("token")]
    public class InstagramController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IWpOptionService _wpOptionService;

        public InstagramController(ITokenService tokenService, IWpOptionService wpOptionService)
        {
            _tokenService = tokenService;
            _wpOptionService = wpOptionService;
        }

        [HttpGet("renew")]
        public async Task<IActionResult> Renew([FromQuery] string token)
        {
            if (token is null)
            {
                return BadRequest("Missing required token field");
            }
            return Ok(await _tokenService.RenewToken(token));
            
        }

        [HttpGet("update")]
        public async Task<IActionResult> Update()
        {
            await _wpOptionService.UpdateInstagramtoken();
            return Ok();
        }

    }
}
