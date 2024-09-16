using Api.autor.Application.Features.Books.Commands;
using Api.autor.Domain.Interfaces.Repositories;
using FluentValidation;

namespace Api.autor.Application.Features.Books.Validators
{
    public class CreateBookCommandValidator: AbstractValidator<CreateBookCommand>
    {
        private readonly IAuthorRepository _authorRepository;
        public CreateBookCommandValidator(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("El título es requerido.")
                .MinimumLength(3).WithMessage("El título no puede ser menor a {MinLength} caracteres.")
                .MaximumLength(100).WithMessage("El título no puede ser mayor a {MaxLength} caracteres.");
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("La descripción es requerida.")
                .MaximumLength(500).WithMessage("La descripción no puede ser mayor a {MaxLength} caracteres.");
            RuleFor(x => x.IdAuthor)
                .NotEmpty().WithMessage("El autor es requerido.")
                .MustAsync(ExistsAuthor).WithMessage("El autor no existe.");

        }

        private async Task<bool> ExistsAuthor(int idAuthor, CancellationToken cancellationToken)
            => await _authorRepository.GetAuthorByIdAsync(idAuthor) != null;
    }
}
