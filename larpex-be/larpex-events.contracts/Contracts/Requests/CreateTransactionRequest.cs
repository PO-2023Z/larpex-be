﻿namespace larpex_events.contracts.Contracts.Requests;

public class CreateTransactionRequest
{
    public Guid PaymentId { get; set; }
    public string UserEmail { get; set; }
    public string Method { get; set; }
}