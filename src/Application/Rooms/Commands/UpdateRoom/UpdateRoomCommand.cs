using QuriWasi.Application.Common.Exceptions;
using QuriWasi.Application.Common.Interfaces;
using QuriWasi.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace QuriWasi.Application.Rooms.Commands.UpdateRoom
{
    public class UpdateRoomCommand : IRequest
    {
        public int Id { get; set; }

        public string RoomCode { get; set; }
        public int RoomNumber { get; set; }
        public string NickName { get; set; }
        public string Description { get; set; }
    }

    public class UpdateRoomCommandHandler : IRequestHandler<UpdateRoomCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateRoomCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Room.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Room), request.Id);
            }

            entity.RoomCode = request.RoomCode;
            entity.RoomNumber = request.RoomNumber;
            entity.NickName = request.NickName;
            entity.Description = request.Description;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
