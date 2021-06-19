using QuriWasi.Application.Common.Interfaces;
using QuriWasi.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace QuriWasi.Application.Persons.Commands.CreatePerson

{
    public class CreatePersonCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int PersonTypeId { get; set; }
    }

    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreatePersonCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = new Person();

                entity.Name = request.Name;
                entity.LastName = request.LastName;
                entity.Address = request.Address;
                entity.Email = request.Email;
                entity.Phone = request.Phone;
                entity.PersonTypeId = request.PersonTypeId;

                _context.Person.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            
        }
    }
}
