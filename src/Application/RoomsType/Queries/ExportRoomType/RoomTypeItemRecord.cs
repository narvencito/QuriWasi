using QuriWasi.Application.Common.Mappings;
using QuriWasi.Domain.Entities;

namespace QuriWasi.Application.RoomsType.Queries.ExportRoomType
{
    public class RoomTypeItemRecord : IMapFrom<RoomType>
    {
        public string Title { get; set; }

        public bool Done { get; set; }
    }
}
