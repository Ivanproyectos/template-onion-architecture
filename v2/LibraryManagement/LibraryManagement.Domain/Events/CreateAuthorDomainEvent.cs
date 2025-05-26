using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace LibraryManagement.Domain.Events
{
    public class CreateAuthorDomainEvent : INotification
    {
        public int AuthorId { get; }

        public CreateAuthorDomainEvent(int authorId)
        {
            AuthorId = authorId;
        }
    }
}
