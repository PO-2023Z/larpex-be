using System.Runtime.InteropServices.JavaScript;

namespace larpex_payment_adapter.Domain;

public class Payment
{
    public Guid Id { get; set; }
    public Guid? EventId { get; set; }
    public string? UserEmail { get; set; }
    public PaymentMethod? Method { get; set; }
    public PaymentStatus? Status { get; set; }
    public DateTime? Date { get; } = DateTime.Now;
    public decimal? Amount { get; set; }
}