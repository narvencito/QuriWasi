using QuriWasi.Application.Common.Interfaces;
using QuriWasi.Application.Common.Security;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace QuriWasi.Application.PersonsType.Commands.PurgePersonType
{
    [Authorize(Roles = "Administrator")]
    [Authorize(Policy = "CanPurge")]
    public class PurgePersonTypeCommand : IRequest
    {
    }

    public class PurgePersonTypeCommandHandler : IRequestHandler<PurgePersonTypeCommand>
    {
        private readonly IApplicationDbContext _context;

        public PurgePersonTypeCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(PurgePersonTypeCommand request, CancellationToken cancellationToken)
        {
            _context.PersonType.RemoveRange(_context.PersonType);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
