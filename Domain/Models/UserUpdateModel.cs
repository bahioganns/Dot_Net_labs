using Domain.Contracts;

namespace Domain.Models
{
    public class UserUpdateModel
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
