using LibraryManagement.Application.Interfaces.Services;
using LibraryManagement.Domain.Events;
using LibraryManagement.Domain.Interfaces.Repositories;
using MediatR;

namespace LibraryManagement.Application.Features.Authors.Commands.CreateAuthorCommand
{
    internal class CreateAuthorEventHandler : INotificationHandler<CreateAuthorDomainEvent>
    {
        private readonly IEmailService _emailService;
        private readonly IAuthorRepository _authorRepository;

        public CreateAuthorEventHandler(
            IEmailService emailService,
            IAuthorRepository authorRepository
        )
        {
            _emailService = emailService;
            _authorRepository = authorRepository;
        }

        public async Task Handle(
            CreateAuthorDomainEvent notification,
            CancellationToken cancellationToken
        )
        {
            var author = await _authorRepository.GetAsync(notification.AuthorId);

            // logica antes de enviar un correo
            await _emailService.SendEmailAsync("", "", "");
        }
    }
}
