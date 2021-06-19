using AutoMapper;
using QuriWasi.Application.Common.Mappings;
using QuriWasi.Domain.Entities;

namespace QuriWasi.Application.RoomsType.Queries.GetAll
{
    public class RoomTypeItemDto : IMapFrom<RoomType>
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }

    }
}
