using LibraryManagement.Application.Features.Authors.Commands.CreateAuthorCommand;
using LibraryManagement.Application.Features.Authors.Commands.DeleteAuthorCommand;
using LibraryManagement.Application.Features.Authors.Commands.UpdateAuthorCommand;
using LibraryManagement.Application.Features.Authors.Queries.GetAllAuthorPagedQuery;
using LibraryManagement.Application.Features.Authors.Queries.GetAllAuthorQuery;
using LibraryManagement.Application.Features.Authors.Queries.GetAuthorByIdQuery;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.API.Controllers
{
    public class AuthorsController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllAuthorQuery getAllAuthorQuery)
        {
            return Ok(await Mediator.Send(getAllAuthorQuery));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var getAllAuthorQuery = new GetAuthorByIdQuery() { Id = id };
            return Ok(await Mediator.Send(getAllAuthorQuery));
        }

        [HttpGet("paged")]
        public async Task<IActionResult> GetAllPaged(
            [FromQuery] GetAllAuthorPagedQuery getAllAuthorQuery
        )
        {
            return Ok(await Mediator.Send(getAllAuthorQuery));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAuthorCommand createAuthorCommand)
        {
            return Ok(await Mediator.Send(createAuthorCommand));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            [FromRoute] int id,
            [FromBody] UpdateAuthorCommand updateAuthorCommand
        )
        {
            updateAuthorCommand.Id = id;
            await Mediator.Send(updateAuthorCommand);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deleteAuthorCommand = new DeleteAuthorCommand() { Id = id };
            await Mediator.Send(deleteAuthorCommand);

            return NoContent();
        }
    }
}
