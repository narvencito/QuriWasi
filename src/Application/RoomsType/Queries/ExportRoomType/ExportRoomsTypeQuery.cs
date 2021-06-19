using AutoMapper;
using AutoMapper.QueryableExtensions;
using QuriWasi.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace QuriWasi.Application.RoomsType.Queries.ExportRoomType
{
    public class ExportRoomsTypeQuery : IRequest<ExportRoomTypeVm>
    {
        public int Id { get; set; }
    }

    public class ExportRoomTypeHandler : IRequestHandler<ExportRoomsTypeQuery, ExportRoomTypeVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICsvFileBuilder _fileBuilder;

        public ExportRoomTypeHandler(IApplicationDbContext context, IMapper mapper, ICsvFileBuilder fileBuilder)
        {
            _context = context;
            _mapper = mapper;
            _fileBuilder = fileBuilder;
        }

        public async Task<ExportRoomTypeVm> Handle(ExportRoomsTypeQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var vm = new ExportRoomTypeVm();

                var records = await _context.RoomType
                        .Where(t => t.Id == request.Id)
                        .ProjectTo<RoomTypeItemRecord>(_mapper.ConfigurationProvider)
                        .ToListAsync(cancellationToken);

                vm.Content = _fileBuilder.BuildRoomTypeItemFile(records);
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
