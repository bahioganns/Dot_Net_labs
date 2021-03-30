using lab2.Domain.Contracts;

namespace lab2.Domain.Models
{
    public class UserIdentityModel : IUserIdentity
    {
        public int Id { get; }

        public UserIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}
