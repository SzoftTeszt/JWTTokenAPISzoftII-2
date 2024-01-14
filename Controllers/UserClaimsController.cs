using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using JWTTokenAPI.Models;
using JWTTokenAPI.Services;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace JWTTokenAPI.Controllers
{ 
    [Route("api/userClaims")]
   [ApiController]
    [Authorize(Roles = "SAdmin")]
    //[Authorize]
    public class UserClaimsController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthenticationController> _logger;
        public UserClaimsController(IAuthService authService, ILogger<AuthenticationController> logger)
        {
            _authService = authService;
            _logger = logger;
        }

              
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {           

            var (status, message) = await _authService.UserClaim(id);
            return Ok(message);
        }

        [HttpPost]
        public async Task<IActionResult> Post(RolesModel id)
        {

            var (status, message) = await _authService.SetClaims(id);
            return Ok(message);
        }


    }
}

