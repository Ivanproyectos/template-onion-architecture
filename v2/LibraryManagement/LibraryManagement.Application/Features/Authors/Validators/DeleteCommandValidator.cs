using FluentValidation;
using LibraryManagement.Application.Features.Authors.Commands.DeleteAuthorCommand;

namespace LibraryManagement.Application.Features.Authors.Validators
{
    internal class DeleteCommandValidator : AbstractValidator<DeleteAuthorCommand>
    {
        public DeleteCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty().WithMessage("Id is required");
            RuleFor(c => c.Id).NotNull().WithMessage("Id is required");
            RuleFor(c => c.Id).GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
