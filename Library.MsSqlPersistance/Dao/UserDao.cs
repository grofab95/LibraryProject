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
            return _context.Users.Include(y => y.AccountType).FirstOrDefault(x => x.UserId == id);
        }

        public User Register(User user, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new EmptyField("password");
            }
            if (_context.Users.Any(x => x.Email == user.Email))
            {
                throw new EmailAlreadyTaken(user.Email);
            }
            if (!string.IsNullOrWhiteSpace(user.Name) && !string.IsNullOrWhiteSpace(user.Surname))
            {
                if (_context.Users.Any(x =>
                    x.Name == user.Name &&
                    x.Surname == user.Surname))
                {
                    throw new UserAlreadyTaken(user.Name, user.Surname);
                }
            }
            byte[] passwordHash, passwordSalt;
            PasswordHash.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.AccountTypeId = 3;

            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        public void Update(User userParam, string password = null)
        {
            var user = _context.Users.Find(userParam.UserId);

            if (user == null)
            {
                throw new LibraryException("Użytkownik nie odnaleziony");
            }
            if (!string.IsNullOrWhiteSpace(userParam.Email) && userParam.Email != user.Email)
            {
                if (_context.Users.Any(x => x.Email == userParam.Email))
                {
                    throw new EmailAlreadyTaken(userParam.Email);
                }
                user.Email = userParam.Email;
            }
            if (!string.IsNullOrWhiteSpace(userParam.Name))
            {
                user.Surname = userParam.Name;
            }
            if (!string.IsNullOrWhiteSpace(userParam.Surname))
            {
                user.Surname = userParam.Surname;
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
