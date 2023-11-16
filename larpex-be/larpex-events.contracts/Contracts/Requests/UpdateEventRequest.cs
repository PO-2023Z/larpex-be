using larpex_events.contracts.Contracts.DataTransferObjects;

namespace larpex_events.contracts.Contracts.Requests;

public class UpdateEventRequest
{
    public CreateEventDTO Event { get; set; }
    public EventSettingsDTO EventSettings { get; set; }
}
