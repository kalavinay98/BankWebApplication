namespace BankWebApplication.Data
{
    public class Account
    {
        public Guid AccountId { get; set; }

        // Foreign Key
        public int UserId { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public string AccountType { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation Property
        public UsersTable User { get; set; }
    }
}