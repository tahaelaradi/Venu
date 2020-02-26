using System.Collections.Generic;
using Venu.Identity.Domain;

namespace Venu.Identity.Services
{
    public interface IUserService
    {
        string Authenticate(string username, string password);
        IEnumerable<User> GetAll();
        User GetById(int id);
        User Create(User user, string password);
        void Update(User user, string password = null);
        void Delete(int id);
    }
}