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
    public class GetRoomsQuery : IRequest<RoomVm>
    {
    }

    public class GetRoomsQueryHandler : IRequestHandler<GetRoomsQuery, RoomVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetRoomsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RoomVm> Handle(GetRoomsQuery request, CancellationToken cancellationToken)
        {
            return new RoomVm
            {
                
                Lists = await _context.Room.Where(x=> x.status == 1)
                    .AsNoTracking()
                    .ProjectTo<RoomListDto>(_mapper.ConfigurationProvider)
                    .OrderBy(t => t.RoomCode)
                    .ToListAsync(cancellationToken)
            };
        }
    }
}
