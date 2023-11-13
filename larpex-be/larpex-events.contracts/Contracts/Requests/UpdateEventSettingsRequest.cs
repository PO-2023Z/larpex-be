using larpex_events.contracts.Contracts.DataTransferObjects;

namespace larpex_events.contracts.Contracts.Requests;

public class UpdateEventSettingsRequest
{
    public EventSettingsDTO EventSettings { get; set; }
}
