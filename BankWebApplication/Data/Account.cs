namespace BankWebApplication.Data
{
    public class Account
    {
        public Guid AccountId { get; set; }

        // Foreign Key
        public int UserId { get; set; }
        public string AccountNumber { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        public string AccountType { get; set; } = "Savings";
        public DateTime CreatedAt { get; set; } 

        // Navigation Property
        public UsersTable User { get; set; }

        public Account(Guid accountId, int userId, string accountNumber, decimal balance, string accountType, UsersTable user)
        {
            AccountId = accountId;
            UserId = userId;
            AccountNumber = accountNumber;
            Balance = balance;
            AccountType = accountType ?? throw new ArgumentNullException(nameof(accountType));
            CreatedAt = DateTime.Now;  // Automatically set the current time
            User = user ?? throw new ArgumentNullException(nameof(user));
        }
    }
}