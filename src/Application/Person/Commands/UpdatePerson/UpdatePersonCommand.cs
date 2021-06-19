using QuriWasi.Application.Common.Exceptions;
using QuriWasi.Application.Common.Interfaces;
using QuriWasi.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace QuriWasi.Application.Persons.Commands.UpdatePerson
{
    public class UpdatePersonCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int PersonTypeId { get; set; }
    }

    public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdatePersonCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Person.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Person), request.Id);
            }

            entity.Name = request.Name;
            entity.LastName = request.LastName;
            entity.Email = request.Email;
            entity.Age = request.Age;
            entity.Address = request.Address;
            entity.PersonTypeId = request.PersonTypeId;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
