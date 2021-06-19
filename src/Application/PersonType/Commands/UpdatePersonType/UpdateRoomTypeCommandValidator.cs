using QuriWasi.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace QuriWasi.Application.PersonsType.Commands.UpdatePersonType
{
    public class UpdatePersonTypeCommandValidator : AbstractValidator<UpdatePersonTypeCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdatePersonTypeCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.Type)
                .NotEmpty().WithMessage("EL tipo de la habitacion es requerido");
            
        }

    }
}
