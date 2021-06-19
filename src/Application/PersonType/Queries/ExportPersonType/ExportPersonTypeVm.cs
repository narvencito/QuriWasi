namespace QuriWasi.Application.PersonsType.Queries.ExportPersonType
{
    public class ExportPersonTypeVm
    {
        public string FileName { get; set; }

        public string ContentType { get; set; }

        public byte[] Content { get; set; }
    }
}