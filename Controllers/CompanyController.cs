using JWTTokenAPI.Data;
using JWTTokenAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace JWTTokenAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "SAdmin,Admin")]
    public class CompanyController : ControllerBase
    {
        
        //private readonly JWTTokenAPIContext _context;
        private readonly ICompService _compService;
        //private readonly ILogger<AuthenticationController> _logger;

       
        //public CompanyController(ICompService compService, JWTTokenAPIContext context, ILogger<AuthenticationController> logger)
        public CompanyController(ICompService compService)
        {

            //_context = context;
            _compService = compService;
            //_logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var (status, message) = await _compService.CompanyList();
            return Ok(message);
        }
    }
}
