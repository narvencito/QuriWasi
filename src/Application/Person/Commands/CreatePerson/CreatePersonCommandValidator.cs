using QuriWasi.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace QuriWasi.Application.Persons.Commands.CreatePerson
{
    public class CreatePersonCommandValidator : AbstractValidator<CreatePersonCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreatePersonCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("El Nombre es Requerido")
                .MaximumLength(200).WithMessage("El Codigo de Habitacion no debe exceder los 200 caracteres");
            RuleFor(v => v.LastName)
                .NotEmpty().WithMessage("EL Apellido es requerido")
                .MaximumLength(200).WithMessage("El apellidon no debe exceder los 200 caracteres");
            RuleFor(v => v.Age)
                .NotEmpty().WithMessage("La edad es requerido");
            RuleFor(v => v.Email)
                .MaximumLength(200).WithMessage("el Email no debe exceder los 200 caracteres");
            RuleFor(v => v.Address)
                .MaximumLength(200).WithMessage("el Email no debe exceder los 200 caracteres");
            RuleFor(v => v.Phone)
                .MaximumLength(14).WithMessage("El Telefono no debe exceder los 14 caracteres");
        }

    }
}
