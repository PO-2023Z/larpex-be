using System.Net.Http.Json;
using larpex_events.contracts.Contracts.Requests;
using larpex_events.contracts.Contracts.Responses;
using larpex_events.Services.Interface;
using larpex_payment_adapter.Domain;
using larpex_payment_adapter.Services.Interface;

 namespace larpex_payment_adapter.Services.Implementation;

public class PaymentsAdapterService : IPaymentsAdapterService
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IEventsRepository _eventsRepository;
    private readonly HttpClient _httpClient;

    public PaymentsAdapterService(IPaymentRepository paymentRepository, IEventsRepository eventsRepository,
        HttpClient httpClient)
    {
        _paymentRepository = paymentRepository;
        _eventsRepository = eventsRepository;
        _httpClient = httpClient;
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
            PaymentPrice = _eventsRepository.Get(eventId).Price
        };
    }
    
    public async Task<CreateTransactionResponse> CreateTransaction(Guid paymentId, string userEmail, PaymentMethod method)

    {
        // Update the payment data in the db
        // (just assume that the paymentId is correct) (for now)
        var eventId = _paymentRepository.GetEventId(paymentId);
        var event_ = _eventsRepository.Get(eventId);

        var payment = new Payment()
        {
            Id = paymentId,
            UserEmail = userEmail,
            Method = method,
            Status = PaymentStatus.NotResolved,
            Amount = event_.Price,
        };
         _paymentRepository.Update(payment);


        var redirectUrl = $"https://localhost:7096/payment-finalization/{paymentId}";
        var apiUrl = $"https://larpex-api-gateway.azurewebsites.net/payments/confirm/{paymentId}";
        // var apiUrl = $"https://localhost:44347/payments/confirm/{paymentId}";


        var transactionDetails = new TransactionDetailsRequest()
        {
            PaymentId = paymentId,
            Email = userEmail,
            Amount = (int) (event_.Price * 100),
            Method = method.ToString(),
            UrlReturn = apiUrl,
            UrlRedirect = redirectUrl
        };

        var result = await _httpClient.PostAsJsonAsync("Payments/registerTransaction", transactionDetails);
        var transactionId = result.Content.ReadAsStringAsync().Result ?? throw new Exception("Error while creating transaction");


        return new CreateTransactionResponse()
        {
            RedirectUrl = "https://larpex-external-payments.azurewebsites.net/Payment?paymentId=" + transactionId
        };
    }

    public PaymentStatusResponse CheckPaymentStatus(Guid paymentId)
    {
        return new PaymentStatusResponse()
        {
            Status = _paymentRepository.GetPaymentStatus(paymentId).ToString()
        };
    }

    public void ConfirmPayment(Guid paymentId, PaymentStatus paymentStatus)
    {
        _paymentRepository.SetPaymentStatus(paymentId, paymentStatus);
        var eventId = _paymentRepository.GetEventId(paymentId);
        _eventsRepository.SetPaymentStatus(eventId, true);
    }
}