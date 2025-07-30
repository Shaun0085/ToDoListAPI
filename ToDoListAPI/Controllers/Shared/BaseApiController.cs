using Microsoft.AspNetCore.Mvc;
using FluentResults;

namespace ToDoListAPI.Controllers.Shared
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult HandleApiResponse<T>(Result<T> result)
        {
            if (result.IsFailed)
                return BadRequest(result.Errors);

            return Ok(result.Value);
        }
    }
}
