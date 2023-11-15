using larpex_payment_adapter.Domain;
using larpex_payment_adapter.Services.Interface;

namespace larpex_payment_adapter.Persistence;

public class PaymentRepository : IPaymentRepository
{
    public Guid Add(Payment payment)
    {
        throw new NotImplementedException();
    }

    public void Update(Payment payment)
    {
        throw new NotImplementedException();
    }

    public void SetPaymentStatus(Guid paymentId, PaymentStatus status)
    {
        throw new NotImplementedException();
    }

    public PaymentStatus GetPaymentStatus(Guid paymentId)
    {
        throw new NotImplementedException();
    }

    public Guid GetEventId(Guid paymentId)
    {
        throw new NotImplementedException();
    }
}