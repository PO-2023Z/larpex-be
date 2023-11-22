namespace external_payments.Models
{
    public class TransactionId
    {
        public Guid Id { get; set; }
        public int Amount { get; set;}

        public string UrlReturn { get; set;}

        public string UrlRedirect { get; set;}  
    }
}
