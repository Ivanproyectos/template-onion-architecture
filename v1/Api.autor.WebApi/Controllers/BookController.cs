using Api.autor.Application.Features.Books.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Api.autor.WebApi.Controllers
{
    [Route("api/books")]
    public class BookController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateBookCommand request)
        {
            return Ok(await Mediator.Send(request));
        }
    }
}
