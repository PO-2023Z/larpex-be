using larpex_events.Domain;
using larpex_events.Services.Interface;

namespace larpex_events.Persistance;

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
        return new Event()
        {
            OwnerEmail = "test@wp.pl",
            Price = (decimal)21.37
        };

        throw new NotImplementedException();
    }

    public List<Event> GetAll()
    {
        return new List<Event>()
        {
            new Event()
            {
                OwnerEmail = "test@wp.pl"
            },
            new Event()
            {
                OwnerEmail = "jstar@wp.pl"
            }
        };

        throw new NotImplementedException();
    }

    public void Remove(Guid eventId)
    {
        return;
        throw new NotImplementedException();
    }

    public void Update(Event eventObject)
    {
        return;
        throw new NotImplementedException();
    }

    public decimal GetEventPrice(Guid eventId)
    {
        throw new NotImplementedException();
    }


    public void SetPaymentStatus(Guid eventId, bool paid)
    {
        return;
        throw new NotImplementedException();
    }
