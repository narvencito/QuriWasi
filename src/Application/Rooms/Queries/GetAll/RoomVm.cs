using System.Collections.Generic;

namespace QuriWasi.Application.Rooms.Queries.GetAll
{
    public class RoomVm
    {

        public IList<RoomListDto> Lists { get; set; }
    }
    public class RoomImageVm
    {

        public IList<RoomImageListDto> Lists { get; set; }
    }
}
