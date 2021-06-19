using QuriWasi.Domain.Common;
using QuriWasi.Domain.Enums;
using QuriWasi.Domain.Events;
using System;
using System.Collections.Generic;

namespace QuriWasi.Domain.Entities
{
    public class Reservation : AuditableEntity, IHasDomainEvent
    {
        public int Id { get; set; }

        public DateTime DateIn { get; set; }
        public DateTime DateOut { get; set; }
        public int NumberAdult { get; set; }
        public int NumberChild { get; set; }
        //public Room Room { get; set; }
        //public RoomDetail RoomDetail { get; set; }
        //public ReservationStatus ReservationStatus { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
