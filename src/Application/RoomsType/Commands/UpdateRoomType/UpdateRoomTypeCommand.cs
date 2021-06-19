using QuriWasi.Application.Common.Exceptions;
using QuriWasi.Application.Common.Interfaces;
using QuriWasi.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace QuriWasi.Application.RoomsType.Commands.UpdateRoomType
{
    public class UpdateRoomTypeCommand : IRequest
    {
        public int Id { get; set; }

        public string Type { get; set; }
        public string Description { get; set; }
    }

    public class UpdateRoomTypeCommandHandler : IRequestHandler<UpdateRoomTypeCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateRoomTypeCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateRoomTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.RoomType.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Room), request.Id);
            }

            entity.Type = request.Type;
            entity.Description = request.Description;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
