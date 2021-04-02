using Domain;
using Domain.Models;

namespace BLL.Contracts
{
    public interface IUserCreateService
    {
        void ValidateUser(UserUpdateModel user);
        User CreateUser(UserUpdateModel user);
    }

    public interface IUserGetService
    {
        User GetUser(UserIdentityModel userId);
    }

    public interface IUserUpdateService
    {
        User UpdateUser(UserIdentityModel userId, UserUpdateModel user);
    }

    public interface IUserDeleteService
    {
        void DeleteUser(UserIdentityModel userId);
    }
}
