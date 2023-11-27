using larpex_events.contracts.Contracts.DataTransferObjects;

namespace larpex_events.contracts.Contracts.Requests;

public class UpdateEventRequest
{
    public UpdateEventDTO Event { get; set; }
    public EventSettingsDTO EventSettings { get; set; }
}
