using QuriWasi.Domain.Common;
using QuriWasi.Domain.Enums;
using QuriWasi.Domain.Events;
using System;
using System.Collections.Generic;

namespace QuriWasi.Domain.Entities
{
    public class Product : AuditableEntity, IHasDomainEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int amount { get; set; }
        public decimal Price { get; set; }
        //public Category Category { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
