using larpex_payment_adapter.Domain;

namespace larpex_payment_adapter.Services.Interface;

public interface IPaymentRepository
{
    Guid Add(Payment payment);
    void Update(Payment payment);
    void SetPaymentStatus(Guid paymentId, PaymentStatus status);
    PaymentStatus GetPaymentStatus(Guid paymentId);
    Guid GetEventId(Guid paymentId);
}
