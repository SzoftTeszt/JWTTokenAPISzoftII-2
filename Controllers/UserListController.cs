using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using JWTTokenAPI.Models;
using JWTTokenAPI.Services;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace JWTTokenAPI.Controllers
{
    [Route("api/userlist")]
    [ApiController]
    [Authorize(Roles = UserRoles.AdministratorOrSuperAdministrator)]
    //[Authorize]
    public class UserListController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthenticationController> _logger;
        public UserListController(IAuthService authService, ILogger<AuthenticationController> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var (status, message) = await _authService.UserList();
            return Ok(message);
        }
    }
}

