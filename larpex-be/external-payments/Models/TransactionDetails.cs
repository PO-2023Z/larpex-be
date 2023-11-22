namespace external_payments.Models
{
    public class TransactionDetails
    {
        public Guid InternalPaymentId { get; set;}

        public string Email { get; set;}

        public int Amount { get; set;}

        public PaymentMethod PaymentMethod { get; set;}

        public string UrlReturn { get; set;}

        public string UrlRedirect { get; set;}
    }
}
