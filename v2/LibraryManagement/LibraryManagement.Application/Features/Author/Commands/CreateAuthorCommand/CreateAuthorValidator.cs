using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Features.Author.Commands.CreateAuthorCommand
{
    public class CreateAuthorValidator: AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorValidator() { 
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Nationality).NotEmpty();
        }
    }
}
