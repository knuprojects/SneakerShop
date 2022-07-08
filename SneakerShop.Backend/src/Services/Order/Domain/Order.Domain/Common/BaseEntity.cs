using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Order.Domain.Common
{
    public abstract class BaseEntity
    {
        public int OrderId { get; set; }

        public List<BaseEvent> _domainEvents = new List<BaseEvent>();

        [NotMapped]
        public IReadOnlyCollection<BaseEvent> DomainEvents => _domainEvents;

        public void AddDomainEvent(BaseEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        public void RemoveDomainEvent(BaseEvent domainEvent)
        {
            _domainEvents.Remove(domainEvent);
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
    }
}
