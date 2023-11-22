namespace larpex_events.contracts.Contracts.Responses;

public class InitPayResponse
{
    public Guid PaymentId { get; set; }
    public decimal PaymentPrice { get; set; }
}