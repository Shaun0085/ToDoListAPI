using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using ToDoListApplication.Interfaces;
using MediatR;
using ToDoListApplication.Features.ToDo.Commands;
using ToDoListAPI.Controllers.Shared;
using ToDoListApplication.Features.ToDo.Queries;

namespace ToDoListAPI.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/todos")]
    public class ToDoListController : BaseController
    {
        private readonly IToDoListService _service;
        private readonly IConfiguration _configuration;
        private readonly IMediator _mediator;

        public ToDoListController(IToDoListService service, IConfiguration configuration, IMediator mediator)
        {
            _service = service;
            _configuration = configuration;
            _mediator = mediator;
        }

        [HttpPost("token")]
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
        public async Task<IActionResult> GetAll()
            => HandleApiResponse(await _mediator.Send(new GetAllToDoQuery()));

        [HttpGet("{ItemId}")]
        public async Task<IActionResult> GetById(Guid ItemId)
            => HandleApiResponse(await _mediator.Send(new GetToDoByIdQuery(ItemId)));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateToDoCommand request)
            => HandleApiResponse(await _mediator.Send(request));

        [HttpPatch("{ItemId}")]
        public async Task<IActionResult> Update([FromBody] UpdateToDoCommand request)
            => HandleApiResponse(await _mediator.Send(request));

        [HttpDelete("{ItemId}")]
        public async Task<IActionResult> Delete(Guid ItemId)
            => HandleApiResponse(await _mediator.Send(new DeleteToDoCommand(ItemId)));
    }
}
