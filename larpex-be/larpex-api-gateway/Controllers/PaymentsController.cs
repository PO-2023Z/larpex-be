using larpex_auth;
using larpex_events.contracts.Contracts.Requests;
using larpex_events.contracts.Contracts.Responses;
using larpex_payment_adapter.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using PaymentMethod = larpex_payment_adapter.Domain.PaymentMethod;
using PaymentStatus = larpex_payment_adapter.Domain.PaymentStatus;

namespace larpex_api_gateway.Controllers;

[ApiController]
[Route("[controller]")]
public class PaymentsController : ControllerBase
{
    private readonly IPaymentsAdapterService _paymentsAdapterService;

    public PaymentsController(IPaymentsAdapterService paymentsAdapterService)
    {
        _paymentsAdapterService = paymentsAdapterService;
    }
    
    
    [HttpPost("init/")]
    public async Task<ActionResult<InitPayResponse>> InitPayment(Guid eventId)
    {
        
        var resp = _paymentsAdapterService.InitPayment(eventId);
        if (resp == null) return NotFound();
        return resp;
    }
    
    [HttpPost("create-transaction/")]
    public async Task<string> CreateTransaction(CreateTransactionRequest request)
    {
        Enum.TryParse(request.Method, out PaymentMethod method);
        var email = TokenGenerator.GetEmail(request.UserToken);
        return _paymentsAdapterService.CreateTransaction(request.PaymentId, email, method);
    }
    
    [HttpPost("confirm/{paymentId:guid}")]
    public async Task ConfirmPayment(Guid paymentId)
    {
        _paymentsAdapterService.ConfirmPayment(paymentId);
    }

    [HttpGet("{paymentId:guid}")]
    public async Task<PaymentStatus> CheckPaymentStatus(Guid paymentId)
    {
        return _paymentsAdapterService.CheckPaymentStatus(paymentId);
    }
}