namespace larpex_events.contracts.Contracts.Requests.Payment;

public class CreateTransactionRequest
{
    public Guid PaymentId { get; set; }
    public string Method { get; set; }
}