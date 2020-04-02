using Library.Domain.Adapters;
using Library.Domain.Entities;
using Library.Exceptions;
using Library.Exceptions.AuthExceptions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Library.MsSqlPersistance.Dao
{
    public class UserDao : IUserDao
    {
        private LibraryContext _context;

        public UserDao(LibraryContext context)
        {
            _context = context;
        }

        public User Authenticate(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                throw new NotAllFieldWasRefiled();
            }

            var user = _context.Users.Include(y => y.AccountType).SingleOrDefault(x => x.Email == email)
                ?? throw new EmailNotExist(email);

            if (!PasswordHash.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                throw new WrongPassword();
            }

            return user;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.Include(y => y.AccountType);
        }

        public User GetById(int id)
        {
            return _context.Users.Include(y => y.AccountType).FirstOrDefault(x => x.Id == id);
        }

        public User Create(User user, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new EmptyField("password");
            }
            if (_context.Users.Any(x => x.Email == user.Email))
            {
                throw new EmailAlreadyTaken(user.Email);
            }
            if (!string.IsNullOrWhiteSpace(user.FirstName) && !string.IsNullOrWhiteSpace(user.LastName))
            {
                if (_context.Users.Any(x =>
                    x.FirstName == user.FirstName &&
                    x.LastName == user.LastName))
                {
                    throw new UserAlreadyTaken(user.FirstName, user.LastName);
                }
            }
            byte[] passwordHash, passwordSalt;
            PasswordHash.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            var accountType = _context.AccountTypes.First(x => x.Name == Domain.Enums.AccountTypeName.Admin);
            user.AccountType = accountType;

            _context.Users.Add(user);
            _context.SaveChanges();


            return user;
        }

        public void Update(User userParam, string password = null)
        {
            var user = _context.Users.Find(userParam.Id);

            if (user == null)
            {
                throw new LibraryException("User not found");
            }
            if (!string.IsNullOrWhiteSpace(userParam.Email) && userParam.Email != user.Email)
            {
                if (_context.Users.Any(x => x.Email == userParam.Email))
                {
                    throw new EmailAlreadyTaken(userParam.Email);
                }
                user.Email = userParam.Email;
            }
            if (!string.IsNullOrWhiteSpace(userParam.FirstName))
            {
                user.FirstName = userParam.FirstName;
            }
            if (!string.IsNullOrWhiteSpace(userParam.LastName))
            {
                user.LastName = userParam.LastName;
            }
            if (!string.IsNullOrWhiteSpace(password))
            {
                byte[] passwordHash, passwordSalt;
                PasswordHash.CreatePasswordHash(password, out passwordHash, out passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}
