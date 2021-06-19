using QuriWasi.Application.Common.Exceptions;
using QuriWasi.Application.Common.Interfaces;
using QuriWasi.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace QuriWasi.Application.PersonsType.Commands.DeletePersonType

{
    public class DeletePersonTypeCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeletePersonTypeCommandHandler : IRequestHandler<DeletePersonTypeCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeletePersonTypeCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeletePersonTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.PersonType
                .Where(l => l.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Room), request.Id);
            }
            entity.status = 0;
            _context.PersonType.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
