using larpex_events.Contracts.DataTransferObjects;

namespace larpex_events.Contracts.Requests;

public class CreateEventRequest
{
    public CreateEventDTO Event { get; set; }
    public EventSettingsDTO EventSettings { get; set; }
}
