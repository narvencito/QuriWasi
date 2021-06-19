using QuriWasi.Domain.Common;
using QuriWasi.Domain.Entities;

namespace QuriWasi.Domain.Events
{
    public class TodoItemCreatedEvent : DomainEvent
    {
        public TodoItemCreatedEvent(TodoItem item)
        {
            Item = item;
        }

        public TodoItem Item { get; }
    }
}
