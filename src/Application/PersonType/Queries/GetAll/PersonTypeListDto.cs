using QuriWasi.Application.Common.Mappings;
using QuriWasi.Domain.Entities;
using System.Collections.Generic;

namespace QuriWasi.Application.PersonsType.Queries.GetAll
{
    public class PersonTypeListDto : IMapFrom<PersonType>
    {
  
        public int Id { get; set; }
        public string Type { get; set; }

    }
}
