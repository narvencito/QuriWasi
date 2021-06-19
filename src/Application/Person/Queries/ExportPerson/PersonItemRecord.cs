using QuriWasi.Application.Common.Mappings;
using QuriWasi.Domain.Entities;

namespace QuriWasi.Application.Persons.Queries.ExportPerson
{
    public class PersonItemRecord : IMapFrom<TodoItem>
    {
        public string Title { get; set; }

        public bool Done { get; set; }
    }
}
