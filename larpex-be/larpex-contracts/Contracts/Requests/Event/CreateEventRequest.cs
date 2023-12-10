using larpex_events.contracts.Contracts.DataTransferObjects.Event;

namespace larpex_events.contracts.Contracts.Requests.Event;

public class CreateEventRequest
{
    public CreateEventDTO Event { get; set; }
    public EventSettingsDTO EventSettings { get; set; }
}
