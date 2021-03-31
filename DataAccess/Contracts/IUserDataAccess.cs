using Domain;
using Domain.Models;

namespace DataLayer.Contracts
{
    public interface IUserDataAccess
    {
        Domain.User Insert(UserUpdateModel user);
        Domain.User Get(UserIdentityModel id);
        Domain.User Update(UserIdentityModel id, UserUpdateModel user);
        void Delete(UserIdentityModel id);
    }
}
