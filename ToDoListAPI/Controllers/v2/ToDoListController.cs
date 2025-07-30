using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using ToDoListApplication.Interfaces;

namespace ToDoListAPI.Controllers.v2
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/todo")]
    public class ToDoListController : ControllerBase
    {
        private readonly IToDoListService _service;
        private readonly ILogger<ToDoListController> _logger;
        private readonly IConfiguration _configuration;

        public ToDoListController(IToDoListService service, ILogger<ToDoListController> logger, IConfiguration configuration)
        {
            _service = service;
            _logger = logger;
            _configuration = configuration;
        }

        // Dummy login to get Token
        [HttpPost("token")]
        [MapToApiVersion("2.0")]
        [AllowAnonymous]
        public IActionResult GetToken()
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        }

        [HttpGet]
        [MapToApiVersion("2.0")]
        [Authorize]
        public async Task<IActionResult> GetAllv2()
        {
            _logger.LogInformation("Controller. Fetching all to-do-list items using v2.");

            var todos = await _service.GetAllItem();

            _logger.LogInformation("Controller. Successfully fetched a total of {Count} items using v2.", todos.Count());

            return Ok(todos);
        }
    }
}
