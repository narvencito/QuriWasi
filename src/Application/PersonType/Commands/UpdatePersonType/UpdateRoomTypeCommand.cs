using QuriWasi.Application.Common.Exceptions;
using QuriWasi.Application.Common.Interfaces;
using QuriWasi.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace QuriWasi.Application.PersonsType.Commands.UpdatePersonType
{
    public class UpdatePersonTypeCommand : IRequest
    {
        public int Id { get; set; }

        public string Type { get; set; }
        public string Description { get; set; }
    }

    public class UpdatePersonTypeCommandHandler : IRequestHandler<UpdatePersonTypeCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdatePersonTypeCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdatePersonTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.PersonType.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Room), request.Id);
            }

            entity.Type = request.Type;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
