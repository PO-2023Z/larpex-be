using larpex_events.contracts.Contracts.Requests;
using larpex_events.contracts.Contracts.Responses;
using larpex_events.Domain.Enums;
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
    
    
    [HttpPost()]
    public async Task<ActionResult<InitPayResponse>> InitPayment(InitPaymentRequest request)
    {
        
        var resp = _paymentsAdapterService.InitPayment(request.EventId);
        if (resp == null) return NotFound();
        return resp;
    }
    
    [HttpPost("create-transaction/")]
    public async Task<string> CreateTransaction(CreateTransactionRequest request)
    {
        Enum.TryParse(request.Method, out PaymentMethod method);
        return _paymentsAdapterService.CreateTransaction(request.PaymentId, request.UserEmail, method);
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