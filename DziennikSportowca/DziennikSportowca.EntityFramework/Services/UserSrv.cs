using AutoMapper;
using DziennikSportowca.Common.Exceptions;
using DziennikSportowca.Common.Models.User;
using DziennikSportowca.EntityFramework.Data;
using DziennikSportowca.EntityFramework.Data.Models;
using DziennikSportowca.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DziennikSportowca.EntityFramework.Services
{
    public class UserSrv : BaseSrv, IUserSrv
    {
        public UserSrv(ApplicationDbContext dbContext, IMapper mapper): base(dbContext, mapper)
        {
        }

        public User Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = _dbContext.tUsers.SingleOrDefault(x => x.Username == username);

            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            // authentication successful
            return _mapper.Map<User>(user);
        }

        public IEnumerable<User> GetAll()
        {
            return _mapper.Map<IEnumerable<User>>(_dbContext.tUsers);
        }

        public User GetById(int id)
        {
            return _mapper.Map<User>(_dbContext.tUsers.Find(id));
        }

        public User Create(User user, string password)
        {
            // validation
            if (string.IsNullOrWhiteSpace(password))
                throw new AppException("Password is required");

            if (_dbContext.tUsers.Any(x => x.Username == user.Username))
                throw new AppException("Username \"" + user.Username + "\" is already taken");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            tUser dbUser = new tUser();
            MapEntityToDb(user, dbUser);

            _dbContext.tUsers.Add(dbUser);
            _dbContext.SaveChanges();

            return user;
        }

        public void Update(User userParam, string password = null)
        {
            var user = _dbContext.tUsers.Find(userParam.Id);

            if (user == null)
                throw new AppException("User not found");

            if (userParam.Username != user.Username)
            {
                // username has changed so check if the new username is already taken
                if (_dbContext.tUsers.Any(x => x.Username == userParam.Username))
                    throw new AppException("Username " + userParam.Username + " is already taken");
            }

            // update user properties
            user.FirstName = userParam.FirstName;
            user.LastName = userParam.LastName;
            user.Username = userParam.Username;

            // update password if it was entered
            if (!string.IsNullOrWhiteSpace(password))
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(password, out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            _dbContext.tUsers.Update(user);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = _dbContext.tUsers.Find(id);
            if (user != null)
            {
                _dbContext.tUsers.Remove(user);
                _dbContext.SaveChanges();
            }
        }

        // private helper methods

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }

        private void MapEntityToDb(User domain, tUser db)
        {
            db.FirstName = domain.FirstName;
            db.Id = domain.Id;
            db.LastName = domain.LastName;
            db.PasswordHash = domain.PasswordHash;
            db.PasswordSalt = domain.PasswordSalt;
            db.Username = domain.Username;
        }
    }
}
