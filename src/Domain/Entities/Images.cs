using QuriWasi.Domain.Common;
using QuriWasi.Domain.Enums;
using QuriWasi.Domain.Events;
using System;
using System.Collections.Generic;

namespace QuriWasi.Domain.Entities
{
    public class Image : AuditableEntity, IHasDomainEvent
    {
        public int Id { get; set; }

        //public RoomDetail RoomDetail { get; set; }
        //public Product Product { get; set; }
        public string Url { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
