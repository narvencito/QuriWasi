using QuriWasi.Application.Common.Interfaces;
using QuriWasi.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace QuriWasi.Application.RoomsType.Commands.CreateRoomType

{
    public class CreateRoomTypeCommand : IRequest<int>
    {
        public string Type { get; set; }
        public string Description { get; set; }
    }

    public class CreateRoomTypeCommandHandler : IRequestHandler<CreateRoomTypeCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateRoomTypeCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateRoomTypeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = new RoomType();

                entity.Type = request.Type;
                entity.Description = request.Description;

                _context.RoomType.Add(entity);

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
