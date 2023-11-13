using larpex_events.contracts.Contracts.DataTransferObjects;

namespace larpex_events.contracts.Contracts.Responses;

public class GetEventsResponse
{
    public List<EventDTO> Events { get; set; }
}
