using FluentValidation;
using LibraryManagement.Application.Features.Authors.Commands.UpdateAuthorCommand;

namespace LibraryManagement.Application.Features.Authors.Validators
{
    public class UpdateAuthorValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorValidator()
        {
            RuleFor(c => c.Id).NotEmpty().WithMessage("Id is required");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Nationality).NotEmpty().WithMessage("Nationality is required");
        }
    }
}
