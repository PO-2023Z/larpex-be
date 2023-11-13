using larpex_events.Domain.Enums;

namespace larpex_events.Domain;

public class Payment
{
    public PaymentMethod Method { get; set; }
    public PaymentStatus Status { get; set; }
    public decimal Price { get; set; }
}
