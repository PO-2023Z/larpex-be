using larpex_events.Contracts.DataTransferObjects;

namespace larpex_events.Contracts.Responses;

public class GetEventsResponse
{
    public List<EventDTO> Events { get; set; }
}
