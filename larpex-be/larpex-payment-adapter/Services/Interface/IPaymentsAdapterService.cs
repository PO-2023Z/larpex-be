using larpex_events.contracts.Contracts.Responses;
using larpex_payment_adapter.Domain;

namespace larpex_payment_adapter.Services.Interface;

public interface IPaymentsAdapterService
{
    InitPayResponse? InitPayment(Guid eventId);
    Task<CreateTransactionResponse> CreateTransaction(Guid paymentId, string userEmail, PaymentMethod method);
    void ConfirmPayment(Guid paymentId, PaymentStatus paymentStatus);
    PaymentStatusResponse CheckPaymentStatus(Guid paymentId);
}