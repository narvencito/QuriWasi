namespace QuriWasi.Application.Rooms.Queries.ExportRoom
{
    public class ExportRoomVm
    {
        public string FileName { get; set; }

        public string ContentType { get; set; }

        public byte[] Content { get; set; }
    }
}