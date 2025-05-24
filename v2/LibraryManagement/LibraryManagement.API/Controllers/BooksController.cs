using LibraryManagement.Application.Features.Books.Commands.CreateBookCommand;
using LibraryManagement.Application.Features.Books.Commands.UpdateBookCommand;
using LibraryManagement.Application.Features.Books.Queries.GetAllBookQuery;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.API.Controllers
{
    public class BooksController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllBookQuery getAllBookQuery)
        {
            return Ok(await Mediator.Send(getAllBookQuery));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBookCommand createBookCommand)
        {
            return Ok(await Mediator.Send(createBookCommand));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateBookCommand updateBookCommand)
        {
            updateBookCommand.Id = id;
            await Mediator.Send(updateBookCommand);
            return NoContent();
        }
    }
}
