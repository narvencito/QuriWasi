using AutoMapper;
using AutoMapper.QueryableExtensions;
using QuriWasi.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace QuriWasi.Application.PersonsType.Queries.ExportPersonType
{
    public class ExportPersonsTypeQuery : IRequest<ExportPersonTypeVm>
    {
        public int Id { get; set; }
    }

    public class ExportPersonTypeHandler : IRequestHandler<ExportPersonsTypeQuery, ExportPersonTypeVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICsvFileBuilder _fileBuilder;

        public ExportPersonTypeHandler(IApplicationDbContext context, IMapper mapper, ICsvFileBuilder fileBuilder)
        {
            _context = context;
            _mapper = mapper;
            _fileBuilder = fileBuilder;
        }

        public async Task<ExportPersonTypeVm> Handle(ExportPersonsTypeQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var vm = new ExportPersonTypeVm();

                var records = await _context.PersonType
                        .Where(t => t.Id == request.Id)
                        .ProjectTo<PersonTypeItemRecord>(_mapper.ConfigurationProvider)
                        .ToListAsync(cancellationToken);

                //vm.Content = _fileBuilder.BuildPersonTypeItemFile(records);
                //vm.ContentType = "text/csv";
                //vm.FileName = "Room.csv";

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
