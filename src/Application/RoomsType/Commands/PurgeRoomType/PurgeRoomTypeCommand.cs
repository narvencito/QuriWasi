using QuriWasi.Application.Common.Interfaces;
using QuriWasi.Application.Common.Security;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace QuriWasi.Application.RoomsType.Commands.PurgeRoomType
{
    [Authorize(Roles = "Administrator")]
    [Authorize(Policy = "CanPurge")]
    public class PurgeRoomTypeCommand : IRequest
    {
    }

    public class PurgeRoomTypeCommandHandler : IRequestHandler<PurgeRoomTypeCommand>
    {
        private readonly IApplicationDbContext _context;

        public PurgeRoomTypeCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(PurgeRoomTypeCommand request, CancellationToken cancellationToken)
        {
            _context.RoomType.RemoveRange(_context.RoomType);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
