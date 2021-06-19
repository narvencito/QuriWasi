using QuriWasi.Application.Common.Interfaces;
using QuriWasi.Application.Common.Security;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace QuriWasi.Application.Rooms.Commands.PurgeRoom
{
    [Authorize(Roles = "Administrator")]
    [Authorize(Policy = "CanPurge")]
    public class PurgeRoomCommand : IRequest
    {
    }

    public class PurgeRoomCommandHandler : IRequestHandler<PurgeRoomCommand>
    {
        private readonly IApplicationDbContext _context;

        public PurgeRoomCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(PurgeRoomCommand request, CancellationToken cancellationToken)
        {
            _context.TodoLists.RemoveRange(_context.TodoLists);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
