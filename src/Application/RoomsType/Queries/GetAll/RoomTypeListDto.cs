using QuriWasi.Application.Common.Mappings;
using QuriWasi.Domain.Entities;
using System.Collections.Generic;

namespace QuriWasi.Application.RoomsType.Queries.GetAll
{
    public class RoomTypeListDto : IMapFrom<RoomType>
    {
  
        public int Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }

    }
}
