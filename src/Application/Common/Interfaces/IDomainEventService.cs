using QuriWasi.Domain.Common;
using System.Threading.Tasks;

namespace QuriWasi.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}
