using larpex_events.contracts.Contracts.DataTransferObjects;

namespace larpex_events.contracts.Contracts.Requests;

public class CreateEventRequest
{
    public CreateEventDTO Event { get; set; }
    public EventSettingsDTO EventSettings { get; set; }
}
