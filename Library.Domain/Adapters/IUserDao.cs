using Library.Api.Entities;
using System.Collections.Generic;

namespace Library.Api.Adapters
{
    public interface IUserDao
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
        User GetById(int id);
        User Create(User user, string password);
        void Update(User user, string password = null);
        void Delete(int id);
    }
}
