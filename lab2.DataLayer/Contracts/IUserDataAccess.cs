using lab2.Domain;
using lab2.Domain.Models;

namespace lab2.DataLayer.Contracts
{
    public interface IUserDataAccess
    {
        lab2.Domain.User Insert(UserUpdateModel user);
        lab2.Domain.User Get(UserIdentityModel id);
        lab2.Domain.User Update(UserIdentityModel id, UserUpdateModel user);
    }
}
