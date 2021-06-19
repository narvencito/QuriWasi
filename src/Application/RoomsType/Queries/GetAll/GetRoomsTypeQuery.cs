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

namespace QuriWasi.Application.RoomsType.Queries.GetAll
{
    public class GetRoomsTypeQuery : IRequest<RoomTypeVm>
    {
    }

    public class GetRoomsQueryHandler : IRequestHandler<GetRoomsTypeQuery, RoomTypeVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetRoomsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RoomTypeVm> Handle(GetRoomsTypeQuery request, CancellationToken cancellationToken)
        {
            return new RoomTypeVm
            {
                
                Lists = await _context.RoomType.Where(x=> x.status == 1)
                    .AsNoTracking()
                    .ProjectTo<RoomTypeListDto>(_mapper.ConfigurationProvider)
                    .OrderBy(t => t.Type)
                    .ToListAsync(cancellationToken)
            };
        }
    }
}
