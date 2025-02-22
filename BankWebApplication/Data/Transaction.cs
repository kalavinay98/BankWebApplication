namespace BankWebApplication.Data
{
    public class Transaction
    {
        public Guid TransactionId { get; set; }

        // Foreign Key
        public Guid FromAccountId { get; set; }
        public Guid? ToAccountId { get; set; }
        public decimal Amount { get; set; }
        public string TransactionType { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation Properties
        public Account FromAccount { get; set; }
        public Account ToAccount { get; set; }
    }
}