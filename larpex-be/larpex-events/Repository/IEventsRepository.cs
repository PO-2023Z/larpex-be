using larpex_events.Domain;

namespace larpex_events.Repository;

public interface IEventsRepository
{
    List<Event> GetAll();
    Event Get(Guid eventId);
    void Add(Event eventObject);
    void Remove(Guid eventId);
    void Update(Event eventObject);
}