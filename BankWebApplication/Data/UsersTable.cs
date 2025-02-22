using System.ComponentModel.DataAnnotations;

namespace BankWebApplication.Data
{
    public class UsersTable
    {
        [Key] // Ensures UserID is the Primary Key
        public int UserID { get; set; }

        [Required] // Ensures these fields are not null
        public string FullName { get; set; } = string.Empty;

        [Required, EmailAddress] // Email validation
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        [Required]
        public string Role { get; set; } = string.Empty;
    }
}
