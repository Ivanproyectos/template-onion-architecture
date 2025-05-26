using FluentValidation;
using LibraryManagement.Application.Features.Authors.Commands.CreateAuthorCommand;

namespace LibraryManagement.Application.Features.Authors.Validators
{
    internal class BookDtoValidator : AbstractValidator<CreateAuthorCommand.BookDto>
    {
        public BookDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required");
            RuleFor(x => x.PublicationYear).NotEmpty().WithMessage("Publication date is required");
        }
    }
}
