using larpex_events.Contracts.DataTransferObjects;

namespace larpex_events.Contracts.Requests;

public class UpdateEventSettingsRequest
{
    public EventSettingsDTO EventSettings { get; set; }
}
