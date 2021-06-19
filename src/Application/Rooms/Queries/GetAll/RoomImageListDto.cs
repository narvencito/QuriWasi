using QuriWasi.Application.Common.Mappings;
using QuriWasi.Domain.Entities;
using System.Collections.Generic;
using QuriWasi.Application.RoomsType.Queries.GetAll;

namespace QuriWasi.Application.Rooms.Queries.GetAll
{
    public class RoomImageListDto : IMapFrom<Room>
    {
        public RoomImageListDto()
        {
            Images = new List<Image>();
        }

        public int Id { get; set; }
        public string RoomCode { get; set; }
        public int RoomNumber { get; set; }
        public string NickName { get; set; }
        public string Description { get; set; }
        public List<Image> Images { get; set; }
    }
}
