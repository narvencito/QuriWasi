using QuriWasi.Domain.Common;
using QuriWasi.Domain.Enums;
using QuriWasi.Domain.Events;
using System;
using System.Collections.Generic;

namespace QuriWasi.Domain.Entities
{
    public class Company : AuditableEntity, IHasDomainEvent
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string address { get; set; }
        public string WebSite { get; set; }
        public string Email { get; set; }
        public string CellPhone { get; set; }
        //public List<Room> Rooms{ get; set; }
        //public List<Person> Persons{ get; set; }
        //public List<Product> Products{ get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
