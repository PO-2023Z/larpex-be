using larpex_events.contracts.Contracts.Responses;
using larpex_events.Services.Interface;
using larpex_payment_adapter.Domain;
using larpex_payment_adapter.Services.Interface;

namespace larpex_payment_adapter.Services.Implementation;

public class PaymentsAdapterService : IPaymentsAdapterService
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IEventsRepository _eventsRepository;
    
    public PaymentsAdapterService(IPaymentRepository paymentRepository, IEventsRepository eventsRepository)
    {
        _paymentRepository = paymentRepository;
        _eventsRepository = eventsRepository;
    }
    

    public InitPayResponse? InitPayment(Guid eventId)
    {
        // Check if event is correct
        var eventObject = _eventsRepository.Get(eventId);
        if (eventObject == null)
        {
            return null;
        }
        
        // Create new payment entry in the db
        var payment = new Payment
        {
            EventId = eventId
        };
        var id = _paymentRepository.Add(payment);
        
        
        return new InitPayResponse()
        {
            PaymentId = id,
            PaymentPrice = _eventsRepository.GetEventPrice(eventId)
        };
    }

    // 
    public string CreateTransaction(Guid paymentId, string userEmail, PaymentMethod method)
    {
        // Update the payment data in the db
        // (just assume that the paymentId is correct) (for now)
        var payment = new Payment()
        {
            Id = paymentId,
            UserEmail = userEmail,
            Method = method,
            Status = PaymentStatus.NotResolved
        };
        _paymentRepository.Update(payment);
        
        
        // register transaction with external-payments
        // get the transaction id used for redirect link
        throw new NotImplementedException();
    }

    public PaymentStatus CheckPaymentStatus(Guid paymentId)
    {
        return _paymentRepository.GetPaymentStatus(paymentId);
    }

    public void ConfirmPayment(Guid paymentId)
    {
        _paymentRepository.SetPaymentStatus(paymentId, PaymentStatus.Success);
        var eventId = _paymentRepository.GetEventId(paymentId);
        _eventsRepository.SetPaymentStatus(eventId, true);
    }
}