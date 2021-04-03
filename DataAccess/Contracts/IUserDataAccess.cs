using System.Collections.Generic;

using Domain;
using Domain.Models;

namespace DataAccess.Contracts
{
    public interface IUserDataAccess
    {
        Domain.User Insert(UserUpdateModel user);
        Domain.User Get(UserIdentityModel id);
        IEnumerable<Domain.User> GetAllUsers();
        Domain.User Update(UserIdentityModel id, UserUpdateModel user);
        void Delete(UserIdentityModel id);
    }
}
