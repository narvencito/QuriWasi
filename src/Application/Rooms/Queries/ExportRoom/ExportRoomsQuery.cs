using AutoMapper;
using AutoMapper.QueryableExtensions;
using QuriWasi.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace QuriWasi.Application.Rooms.Queries.ExportRoom
{
    public class ExportRoomsQuery : IRequest<ExportRoomVm>
    {
        public int Id { get; set; }
    }

    public class ExportRoomHandler : IRequestHandler<ExportRoomsQuery, ExportRoomVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICsvFileBuilder _fileBuilder;

        public ExportRoomHandler(IApplicationDbContext context, IMapper mapper, ICsvFileBuilder fileBuilder)
        {
            _context = context;
            _mapper = mapper;
            _fileBuilder = fileBuilder;
        }

        public async Task<ExportRoomVm> Handle(ExportRoomsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var vm = new ExportRoomVm();

                var records = await _context.Room
                        .Where(t => t.Id == request.Id)
                        .ProjectTo<RoomItemRecord>(_mapper.ConfigurationProvider)
                        .ToListAsync(cancellationToken);

                vm.Content = _fileBuilder.BuildRoomItemFile(records);
                vm.ContentType = "text/csv";
                vm.FileName = "Room.csv";

                return await Task.FromResult(vm);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            
        }
    }
}
