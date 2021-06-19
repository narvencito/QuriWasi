using QuriWasi.Application.Common.Mappings;
using QuriWasi.Domain.Entities;

namespace QuriWasi.Application.PersonsType.Queries.ExportPersonType
{
    public class PersonTypeItemRecord : IMapFrom<PersonType>
    {
        public string Title { get; set; }

        public bool Done { get; set; }
    }
}
