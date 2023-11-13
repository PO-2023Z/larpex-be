using larpex_events.Domain;

namespace larpex_events.Repository;

public class EventsRepository : IEventsRepository
{
    //private readonly EventContext _eventContext;

    public EventsRepository()
    {
    }

    public void Add(Event eventObject)
    {
        throw new NotImplementedException();
    }

    public Event Get(Guid eventId)
    {
        throw new NotImplementedException();
    }

    public List<Event> GetAll()
    {
        throw new NotImplementedException();
    }

    public void Remove(Guid eventId)
    {
        throw new NotImplementedException();
    }

    public void Update(Event eventObject)
    {
        throw new NotImplementedException();
    }
}
