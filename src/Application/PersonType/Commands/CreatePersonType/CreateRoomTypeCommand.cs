using QuriWasi.Application.Common.Interfaces;
using QuriWasi.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace QuriWasi.Application.PersonsType.Commands.CreatePersonType

{
    public class CreatePersonTypeCommand : IRequest<int>
    {
        public string Type { get; set; }
    }

    public class CreatePersonTypeCommandHandler : IRequestHandler<CreatePersonTypeCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreatePersonTypeCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreatePersonTypeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = new PersonType();

                entity.Type = request.Type;

                _context.PersonType.Add(entity);

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
