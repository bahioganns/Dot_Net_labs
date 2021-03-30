using lab2.Domain.Contracts;

namespace lab2.Domain.Models
{
    public class UserUpdateModel
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
