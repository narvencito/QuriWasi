using QuriWasi.Domain.Common;
using QuriWasi.Domain.Enums;
using QuriWasi.Domain.Events;
using System;
using System.Collections.Generic;

namespace QuriWasi.Domain.Entities
{
    public class RoomDetail : AuditableEntity, IHasDomainEvent
    {
        public int Id { get; set; }
        public int NumberOccupants { get; set; }
        //public Service Services { get; set; }
        //public Image Images { get; set; }
        //public Room Room { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
