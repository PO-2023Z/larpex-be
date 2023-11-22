using larpex_payment_adapter.Domain;
using larpex_payment_adapter.Services.Interface;

namespace larpex_payment_adapter.Persistence;

public class PaymentRepository : IPaymentRepository
{
    // TODO integrate with db
    public Guid Add(Payment payment)
    {
        return Guid.NewGuid();
        throw new NotImplementedException();
    }

    public void Update(Payment payment)
    {
        return;
        throw new NotImplementedException();
    }

    public void SetPaymentStatus(Guid paymentId, PaymentStatus status)
    {
        return;
        throw new NotImplementedException();
    }

    public PaymentStatus GetPaymentStatus(Guid paymentId)
    {
        var r = new Random();
        return (PaymentStatus)r.Next(0, 2);

        throw new NotImplementedException();
    }

    public Guid GetEventId(Guid paymentId)
    {
        return Guid.NewGuid();
        throw new NotImplementedException();
    }
}