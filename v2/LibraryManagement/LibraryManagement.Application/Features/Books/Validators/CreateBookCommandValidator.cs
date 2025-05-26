using FluentValidation;
using LibraryManagement.Application.Features.Books.Commands.CreateBookCommand;

namespace LibraryManagement.Application.Features.Books.Validators
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().NotNull().WithMessage("Title is required.");
            RuleFor(x => x.PublicationYear)
                .NotEmpty()
                .NotNull()
                .WithMessage("Publication year is required.")
                .Must(x => x > 0)
                .WithMessage("Publication year must be greater than 0.");
        }
    }
}
