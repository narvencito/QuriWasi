using QuriWasi.Domain.Common;
using QuriWasi.Domain.Enums;
using QuriWasi.Domain.Events;
using System;
using System.Collections.Generic;

namespace QuriWasi.Domain.Entities
{
    public class RoomType : AuditableEntity, IHasDomainEvent
    {
        public int Id { get; set; }

        public string Type { get; set; }
        public string Description { get; set; }
        public Room Room { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
