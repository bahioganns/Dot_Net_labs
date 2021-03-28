using lab2.Domain;

namespace lab2.DataLayer.Contracts
{
    public interface IUserDataAccess
    {
        lab2.Domain.User Insert(lab2.Domain.User user);
        lab2.Domain.User GetById(int userId);
        lab2.Domain.User Update(lab2.Domain.User user);
    }
}
