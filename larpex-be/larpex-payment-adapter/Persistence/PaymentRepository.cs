using larpex_db;
using larpex_payment_adapter.Domain;
using larpex_payment_adapter.Services.Interface;

namespace larpex_payment_adapter.Persistence;

public class PaymentRepository : IPaymentRepository
{
    private LarpexdbContext _context;

    public PaymentRepository(LarpexdbContext context)
    {
        _context = context;
    }

    public Guid Add(Payment payment)
    {
        var newPayment = new larpex_db.Models.Payment()
        {
            Eventid = payment.EventId,
            Paymentstate = PaymentStatus.NotResolved.ToString(),
        };

        _context.Payments.Add(newPayment);
        _context.SaveChanges();


        return newPayment.Paymentid;
    }

    public void Update(Payment payment)
    {
        var paymentToUpdate = _context.Payments.FirstOrDefault(p => p.Paymentid == payment.Id);

        paymentToUpdate!.UserEmail = payment.UserEmail ?? paymentToUpdate.UserEmail;
        paymentToUpdate.Paymentamount = payment.Amount ?? paymentToUpdate.Paymentamount;
        paymentToUpdate.Paymentdate = payment.Date ?? paymentToUpdate.Paymentdate;
        paymentToUpdate.Paymentstate = payment.Status.ToString() ?? paymentToUpdate.Paymentstate;
        paymentToUpdate.Paymenttype = payment.Method.ToString() ?? paymentToUpdate.Paymenttype;

        _context.Update(paymentToUpdate);

        _context.SaveChanges();

        return;
    }

    public void SetPaymentStatus(Guid paymentId, PaymentStatus status)
    {
        var paymentToUpdate = _context.Payments.FirstOrDefault(p => p.Paymentid == paymentId);

        paymentToUpdate!.Paymentstate = status.ToString();

        _context.Update(paymentToUpdate);

        _context.SaveChanges();

        return;
    }

    public PaymentStatus GetPaymentStatus(Guid paymentId)
    {
        var payment = _context.Payments.FirstOrDefault(p => p.Paymentid == paymentId);
        return (PaymentStatus)Enum.Parse(typeof(PaymentStatus), payment!.Paymentstate!);
    }

    public Guid GetEventId(Guid paymentId)
    {
        var payment = _context.Payments.FirstOrDefault(p => p.Paymentid == paymentId);
        return payment!.Eventid!.Value;
    }
}