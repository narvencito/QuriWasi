using QuriWasi.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace QuriWasi.Application.RoomsType.Commands.UpdateRoomType
{
    public class UpdateRoomTypeCommandValidator : AbstractValidator<UpdateRoomTypeCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateRoomTypeCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.Type)
                .NotEmpty().WithMessage("EL tipo de la habitacion es requerido");
            RuleFor(v => v.Description)
                .NotEmpty().WithMessage("la Descripcion no puede ser vacio")
                .MaximumLength(200).WithMessage("La Descrpcion no debe exceder los 1000 caracteres");
            
        }

    }
}
