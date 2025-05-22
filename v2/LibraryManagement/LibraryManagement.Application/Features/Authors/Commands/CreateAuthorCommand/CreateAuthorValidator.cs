using FluentValidation;

namespace LibraryManagement.Application.Features.Authors.Commands.CreateAuthorCommand
{
    public class CreateAuthorValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Nationality).NotEmpty();
        }
    }
}
