using QuriWasi.Application.Common.Mappings;
using QuriWasi.Domain.Entities;
using System.Collections.Generic;
using QuriWasi.Application.PersonsType.Queries.GetAll;

namespace QuriWasi.Application.Persons.Queries.GetAll
{
    public class PersonListDto : IMapFrom<Person>
    {
  
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public PersonTypeItemDto PersonType { get; set; }
    }
}
