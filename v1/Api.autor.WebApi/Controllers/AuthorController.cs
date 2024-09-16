using Api.autor.Application.Features.Autor.Querys;
using Microsoft.AspNetCore.Mvc;

namespace Api.autor.WebApi.Controllers
{
    [Route("api/authors")]
    public class AuthorController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new GetAllAuthorsQuery()));
        }
    }
}
