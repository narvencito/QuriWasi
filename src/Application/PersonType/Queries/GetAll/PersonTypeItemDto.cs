using AutoMapper;
using QuriWasi.Application.Common.Mappings;
using QuriWasi.Domain.Entities;

namespace QuriWasi.Application.PersonsType.Queries.GetAll
{
    public class PersonTypeItemDto : IMapFrom<PersonType>
    {
        public int Id { get; set; }
        public string Type { get; set; }

    }
}
