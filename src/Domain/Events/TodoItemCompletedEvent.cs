using QuriWasi.Domain.Common;
using QuriWasi.Domain.Entities;

namespace QuriWasi.Domain.Events
{
    public class TodoItemCompletedEvent : DomainEvent
    {
        public TodoItemCompletedEvent(TodoItem item)
        {
            Item = item;
        }

        public TodoItem Item { get; }
    }
}
