using QuriWasi.Application.Common.Mappings;
using QuriWasi.Domain.Entities;
using System.Collections.Generic;
using QuriWasi.Application.RoomsType.Queries.GetAll;

namespace QuriWasi.Application.Rooms.Queries.GetAll
{
    public class RoomListDto : IMapFrom<Room>
    {
  
        public int Id { get; set; }
        public string RoomCode { get; set; }
        public int RoomNumber { get; set; }
        public string NickName { get; set; }
        public string Description { get; set; }
        public RoomTypeItemDto RoomType { get; set; }
    }
}
