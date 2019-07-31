using DziennikSportowca.Common.Models.User;
using System.Collections.Generic;

namespace DziennikSportowca.Interfaces.Services
{
    public interface IUserSrv
    {
        User Authenticate(string username, string password);

        IEnumerable<User> GetAll();

        User GetById(int id);

        User Create(User user, string password);

        void Update(User user, string password = null);

        void Delete(int id);
    }
}