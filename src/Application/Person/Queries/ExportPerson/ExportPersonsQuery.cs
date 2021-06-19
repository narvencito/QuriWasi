using AutoMapper;
using AutoMapper.QueryableExtensions;
using QuriWasi.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace QuriWasi.Application.Persons.Queries.ExportPerson
{
    public class ExportPersonsQuery : IRequest<ExportPersonVm>
    {
        public int Id { get; set; }
    }

    public class ExportPersonHandler : IRequestHandler<ExportPersonsQuery, ExportPersonVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICsvFileBuilder _fileBuilder;

        public ExportPersonHandler(IApplicationDbContext context, IMapper mapper, ICsvFileBuilder fileBuilder)
        {
            _context = context;
            _mapper = mapper;
            _fileBuilder = fileBuilder;
        }

        public async Task<ExportPersonVm> Handle(ExportPersonsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var vm = new ExportPersonVm();

                var records = await _context.Person
                        .Where(t => t.Id == request.Id)
                        .ProjectTo<PersonItemRecord>(_mapper.ConfigurationProvider)
                        .ToListAsync(cancellationToken);

                //vm.Content = _fileBuilder.BuildPersonItemFile(records);
                //vm.ContentType = "text/csv";
                //vm.FileName = "Person.csv";

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
