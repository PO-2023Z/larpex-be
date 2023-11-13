using larpex_events.Contracts.DataTransferObjects;

namespace larpex_events.Contracts.Requests;

public class UpdateEventRequest
{
    public CreateEventDTO Event { get; set; }
    public EventSettingsDTO EventSettings { get; set; }
}
