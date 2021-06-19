using QuriWasi.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace QuriWasi.Application.Rooms.Commands.UpdateRoom
{
    public class UpdateRoomCommandValidator : AbstractValidator<UpdateRoomCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateRoomCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.RoomCode)
                .NotEmpty().WithMessage("El Codigo de Habitacion es Requerido")
                .MaximumLength(200).WithMessage("El Codigo de Habitacion no debe exceder los 200 caracteres");
            RuleFor(v => v.RoomNumber)
                .NotEmpty().WithMessage("EL numero de la habitacion es requerido");
            RuleFor(v => v.Description)
                .NotEmpty().WithMessage("la Descripcion no puede ser vacio")
                .MaximumLength(1000).WithMessage("La Descrpcion no debe exceder los 1000 caracteres");
            RuleFor(v => v.NickName)
                .MaximumLength(200).WithMessage("El Alias de Habitacion no debe exceder los 200 caracteres");
        }
    }
}
