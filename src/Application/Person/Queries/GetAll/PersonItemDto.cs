using AutoMapper;
using QuriWasi.Application.Common.Mappings;
using QuriWasi.Domain.Entities;

namespace QuriWasi.Application.Persons.Queries.GetAll
{
    public class PersonItemDto : IMapFrom<Person>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public PersonType PersonType { get; set; }
    }
}
