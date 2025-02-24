using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BankWebApplication.Data
{
    public class UsersTable : IdentityUser
    {
        [Required]
        public string FullName { get; set; } = string.Empty;

        [Required]
        public string Role { get; set; } = string.Empty;
    }
}