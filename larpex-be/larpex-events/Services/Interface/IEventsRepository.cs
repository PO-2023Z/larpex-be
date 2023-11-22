using larpex_events.Domain;
using Event = larpex_events.Persistance.DTOs.Event;

namespace larpex_events.Services.Interface;

public interface IEventsRepository
{
    List<Event> GetAll();
    Event Get(Guid eventId);
    void Add(Event eventObject);
    void Remove(Guid eventId);
    void Update(Event eventObject);
}