using System.Text.Json.Serialization;
using MediatR;

namespace LibraryManagement.Application.Features.Authors.Commands.UpdateAuthorCommand
{
    public class UpdateAuthorCommand : IRequest<Unit>
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }
    }
}
