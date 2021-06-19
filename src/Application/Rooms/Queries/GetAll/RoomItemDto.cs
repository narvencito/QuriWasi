using AutoMapper;
using QuriWasi.Application.Common.Mappings;
using QuriWasi.Domain.Entities;

namespace QuriWasi.Application.Rooms.Queries.GetAll
{
    public class RoomItemDto : IMapFrom<Room>
    {
        public int Id { get; set; }
        public string RoomCode { get; set; }
        public int RoomNumber { get; set; }
        public string NickName { get; set; }
        public string Description { get; set; }
        public RoomType RoomType { get; set; }
    }
}
