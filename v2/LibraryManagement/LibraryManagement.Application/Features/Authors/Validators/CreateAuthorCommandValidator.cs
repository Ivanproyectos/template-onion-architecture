using FluentValidation;
using LibraryManagement.Application.Features.Authors.Commands.CreateAuthorCommand;

namespace LibraryManagement.Application.Features.Authors.Validators
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required")
                .MinimumLength(2)
                .WithMessage("Name must be at least 2 characters long")
                .MaximumLength(100)
                .WithMessage("Name must be at most 100 characters long");

            RuleFor(x => x.Nationality).NotEmpty().WithMessage("Nationality is required");
            RuleFor(x => x.Books).NotEmpty().WithMessage("At least one book is required");

            RuleForEach(x => x.Books).SetValidator(new BookDtoValidator());
        }
    }
}
