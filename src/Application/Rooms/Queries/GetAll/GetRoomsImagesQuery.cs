using AutoMapper;
using AutoMapper.QueryableExtensions;
using QuriWasi.Application.Common.Interfaces;
using QuriWasi.Application.Common.Security;
using QuriWasi.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace QuriWasi.Application.Rooms.Queries.GetAll
{
    public class GetRoomsImagesQuery : IRequest<RoomImageVm>
    {
    }

    public class GetRoomsImagesQueryHandler : IRequestHandler<GetRoomsImagesQuery, RoomImageVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetRoomsImagesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RoomImageVm> Handle(GetRoomsImagesQuery request, CancellationToken cancellationToken)
        {
            return new RoomImageVm
            {
                
                Lists = await _context.Room.Where(x=> x.status == 1)
                    .AsNoTracking()
                    .ProjectTo<RoomImageListDto>(_mapper.ConfigurationProvider)
                    .OrderBy(t => t.RoomCode)
                    .ToListAsync(cancellationToken)
            };
        }
    }
}
