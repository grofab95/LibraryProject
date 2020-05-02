using Library.Domain.Entities;
using System.Collections.Generic;

namespace Library.Domain.Adapters
{
    public interface IUserDao
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
        User GetById(int id);
        User Register(User user, string password);
        void Update(User user);
        void Delete(int id);
    }
}
