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

namespace QuriWasi.Application.PersonsType.Queries.GetAll
{
    public class GetPersonsTypeQuery : IRequest<PersonTypeVm>
    {
    }

    public class GetPersonsQueryHandler : IRequestHandler<GetPersonsTypeQuery, PersonTypeVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetPersonsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PersonTypeVm> Handle(GetPersonsTypeQuery request, CancellationToken cancellationToken)
        {
            return new PersonTypeVm
            {
                
                Lists = await _context.PersonType.Where(x=> x.status == 1)
                    .AsNoTracking()
                    .ProjectTo<PersonTypeListDto>(_mapper.ConfigurationProvider)
                    .OrderBy(t => t.Type)
                    .ToListAsync(cancellationToken)
            };
        }
    }
}
