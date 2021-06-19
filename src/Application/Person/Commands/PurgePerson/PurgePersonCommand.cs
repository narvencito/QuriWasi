using QuriWasi.Application.Common.Interfaces;
using QuriWasi.Application.Common.Security;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace QuriWasi.Application.Persons.Commands.PurgePerson
{
    [Authorize(Roles = "Administrator")]
    [Authorize(Policy = "CanPurge")]
    public class PurgePersonCommand : IRequest
    {
    }

    public class PurgePersonCommandHandler : IRequestHandler<PurgePersonCommand>
    {
        private readonly IApplicationDbContext _context;

        public PurgePersonCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(PurgePersonCommand request, CancellationToken cancellationToken)
        {
            _context.TodoLists.RemoveRange(_context.TodoLists);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
