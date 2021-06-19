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

namespace QuriWasi.Application.Persons.Queries.GetAll
{
    public class GetPersonsQuery : IRequest<PersonVm>
    {
    }

    public class GetPersonsQueryHandler : IRequestHandler<GetPersonsQuery, PersonVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetPersonsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PersonVm> Handle(GetPersonsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return new PersonVm
                {

                    Lists = await _context.Person.Where(x => x.status == 1)
                        .AsNoTracking()
                        .ProjectTo<PersonListDto>(_mapper.ConfigurationProvider)
                        .OrderBy(t => t.LastName)
                        .ToListAsync(cancellationToken)
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
