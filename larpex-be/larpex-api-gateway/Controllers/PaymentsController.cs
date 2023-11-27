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
    public async Task<ActionResult<string>> CreateTransaction(CreateTransactionRequest request)
    {
        string token = HttpContext.Request.Headers["Authorization"];
        if (string.IsNullOrWhiteSpace(token) || !token.StartsWith("Bearer "))
        {
            return Unauthorized("Invalid token");
        }
        var email = TokenGenerator.GetEmail(token.Substring("Bearer ".Length));

        Enum.TryParse(request.Method, out PaymentMethod method);
        return await _paymentsAdapterService.CreateTransaction(request.PaymentId, email, method);
    }

    [HttpPost("confirm/{paymentId:guid}")]
    public async Task ConfirmPayment(Guid paymentId, [FromQuery] string success)
    {
        PaymentStatus paymentStatus = PaymentStatus.Failure;
        if (success == "true")
        {
            paymentStatus = PaymentStatus.Success;
        }
        _paymentsAdapterService.ConfirmPayment(paymentId, paymentStatus);
    }

    [HttpGet("{paymentId:guid}")]
    public async Task<string> CheckPaymentStatus(Guid paymentId)
    {
        return _paymentsAdapterService.CheckPaymentStatus(paymentId).ToString();
    }
}