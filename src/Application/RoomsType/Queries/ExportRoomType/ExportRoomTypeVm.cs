namespace QuriWasi.Application.RoomsType.Queries.ExportRoomType
{
    public class ExportRoomTypeVm
    {
        public string FileName { get; set; }

        public string ContentType { get; set; }

        public byte[] Content { get; set; }
    }
}