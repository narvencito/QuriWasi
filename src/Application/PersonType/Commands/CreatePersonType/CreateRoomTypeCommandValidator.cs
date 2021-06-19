using QuriWasi.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace QuriWasi.Application.PersonsType.Commands.CreatePersonType
{
    public class CreatePersonTypeCommandValidator : AbstractValidator<CreatePersonTypeCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreatePersonTypeCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.Type)
                .NotEmpty().WithMessage("El tipo Habitación es Requerido")
                .MaximumLength(200).WithMessage("El tipo de Habitación no debe exceder los 200 caracteres");
    
        }

    }
}
