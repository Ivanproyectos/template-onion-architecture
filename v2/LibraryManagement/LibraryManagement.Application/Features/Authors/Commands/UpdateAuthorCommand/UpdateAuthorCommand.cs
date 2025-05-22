

using MediatR;

namespace LibraryManagement.Application.Features.Authors.Commands.UpdateAuthorCommand
{
    public class UpdateAuthorCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }

    }
}
