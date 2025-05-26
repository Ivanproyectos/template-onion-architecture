using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using LibraryManagement.Application.Features.Books.Commands.UpdateBookCommand;

namespace LibraryManagement.Application.Features.Books.Validators
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty().WithMessage("Id is required");
            RuleFor(x => x.Title).NotEmpty().NotNull().WithMessage("Title is required.");
            RuleFor(x => x.PublicationYear)
                .NotEmpty()
                .NotNull()
                .WithMessage("Publication year is required.")
                .Must(x => x > 0)
                .WithMessage("Publication year must be greater than 0.");
            RuleFor(c => c.AuthorId).NotEmpty().WithMessage("Author is required.");
        }
    }
}
