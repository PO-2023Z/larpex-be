namespace larpex_events.contracts.Contracts.Requests;

public class InitPaymentRequest
{
    public string Email { get; set; }
    public Guid EventId { get; set; }
}