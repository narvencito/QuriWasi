using QuriWasi.Domain.Common;
using QuriWasi.Domain.Enums;
using QuriWasi.Domain.Events;
using System;
using System.Collections.Generic;

namespace QuriWasi.Domain.Entities
{
    public class Room : AuditableEntity, IHasDomainEvent
    {
        public int Id { get; set; }
        public string RoomCode { get; set; }
        public int RoomNumber { get; set; }
        public string NickName { get; set; }
        public string Description { get; set; }

        public int RoomTypeId { get; set; }
        public RoomType RoomType { get; private set; }
        public ICollection<Image> Images { get; set; }
        //public Product Product  { get; set; }
        //public RoomDetail RoomDetail  { get; set; }


        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
