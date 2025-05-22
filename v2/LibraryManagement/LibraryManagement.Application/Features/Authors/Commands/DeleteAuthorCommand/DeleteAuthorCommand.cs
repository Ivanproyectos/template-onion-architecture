using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Features.Authors.Commands.DeleteAuthorCommand
{
    public record struct DeleteAuthorCommand(int Id): IRequest<Unit> { }
}
