using LibraryManagement.Application.Features.Author.Commands.CreateAuthorCommand;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.API.Controllers
{
    public class AuthorsController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateAuthorCommand createAuthorCommand)
        {
            return Ok(await Mediator.Send(createAuthorCommand));
        }
    }
}
