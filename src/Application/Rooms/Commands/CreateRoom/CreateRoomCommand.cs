using QuriWasi.Application.Common.Interfaces;
using QuriWasi.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace QuriWasi.Application.Rooms.Commands.CreateRoom

{
    public class CreateRoomCommand : IRequest<int>
    {
        public string RoomCode { get; set; }
        public int RoomNumber { get; set; }
        public string NickName { get; set; }
        public string Description { get; set; }
    }

    public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateRoomCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = new Room();

                entity.RoomCode = request.RoomCode;
                entity.RoomNumber = request.RoomNumber;
                entity.NickName = request.NickName;
                entity.Description = request.Description;

                _context.Room.Add(entity);

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
