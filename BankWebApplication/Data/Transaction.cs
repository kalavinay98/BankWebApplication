using System.ComponentModel.DataAnnotations;

namespace BankWebApplication.Data
{
    public class Transaction
    {
        public Guid TransactionId { get; set; }

        // Foreign Keys
        public Guid FromAccountId { get; set; }
        public Guid? ToAccountId { get; set; }

        [Required]  // Ensures Amount is set
        public decimal Amount { get; set; }

        [Required]  // Ensures TransactionType is set
        public string TransactionType { get; set; } = string.Empty;

        [Required]  // Ensures Status is set
        public string Status { get; set; } = string.Empty;

        [Required]  // Ensures CreatedAt is set
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation Properties
        [Required]  // Ensures FromAccount is always set
        public required Account FromAccount { get; set; }

        public Account? ToAccount { get; set; } // Nullable ToAccount as it can be null

        // Constructor
        public Transaction(Guid fromAccountId, decimal amount, string transactionType, string status, Account fromAccount, Account? toAccount = null)
        {
            FromAccountId = fromAccountId;
            Amount = amount;
            TransactionType = transactionType ?? throw new ArgumentNullException(nameof(transactionType));
            Status = status ?? throw new ArgumentNullException(nameof(status));
            CreatedAt = DateTime.Now;  // Automatically set the current time
            FromAccount = fromAccount ?? throw new ArgumentNullException(nameof(fromAccount));
            ToAccount = toAccount;  // Allowing ToAccount to be null

            // Assign ToAccountId only if ToAccount is not null
            ToAccountId = ToAccount?.AccountId;
        }
    }
}
