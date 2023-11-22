namespace larpex_events.contracts.Contracts.Requests;

public class TransactionDetailsRequest
{
    public Guid PaymentId { get; set; }
    public string Email { get; set; }
    public int Amount { get; set; }
    public string Method { get; set; }
    public string UrlReturn { get; set; } // Url to our api for confirming the payment
    public string UrlRedirect { get; set; } // Url to the frontend for redirecting the user after payment
}