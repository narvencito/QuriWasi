namespace QuriWasi.Application.Persons.Queries.ExportPerson
{
    public class ExportPersonVm
    {
        public string FileName { get; set; }

        public string ContentType { get; set; }

        public byte[] Content { get; set; }
    }
}