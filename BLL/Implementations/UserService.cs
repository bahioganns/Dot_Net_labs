using System;
using System.Text.RegularExpressions;
using DataAccess.Contracts;
using Domain;
using Domain.Models;
using BLL.Contracts;

namespace BLL.Implementations
{
    public class UserService : IUserCreateService, IUserGetService, IUserUpdateService, IUserDeleteService
    {
        private IUserDataAccess UserDataAccess { get; }

        public UserService(IUserDataAccess userDataAccess)
        {
            this.UserDataAccess = userDataAccess;
        }

        public User CreateUser(UserUpdateModel user)
        {
            return this.UserDataAccess.Insert(user);
        }

        public User GetUser(UserIdentityModel userId)
        {
            return this.UserDataAccess.Get(userId);
        }

        public User UpdateUser(UserIdentityModel userId, UserUpdateModel user)
        {
            return this.UserDataAccess.Update(userId, user);
        }

        public void DeleteUser(UserIdentityModel userId)
        {
            this.UserDataAccess.Delete(userId);
        }

        public void ValidateUser(UserUpdateModel user)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if(!regex.Match(user.Email).Success)
            {
                throw new ArgumentException("Wrong email format");
            }
        }
    }
}

