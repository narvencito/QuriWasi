using QuriWasi.Application.Common.Exceptions;
using QuriWasi.Application.Common.Interfaces;
using QuriWasi.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace QuriWasi.Application.RoomsType.Commands.DeleteRoomType

{
    public class DeleteRoomTypeCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteRoomTypeCommandHandler : IRequestHandler<DeleteRoomTypeCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteRoomTypeCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteRoomTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.RoomType
                .Where(l => l.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Room), request.Id);
            }
            entity.status = 0;
            _context.RoomType.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
