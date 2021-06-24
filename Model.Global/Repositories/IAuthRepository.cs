using Model.Global.Data;
using System.Collections.Generic;

namespace Model.Global.Repositories
{
    public interface IAuthRepository
    {
        bool EmailExists(string email);
        User Get(int id);
        IEnumerable<User> Get();
        IEnumerable<Contact> GetContactByUser(int id);
        User Login(string email, string passwd);
        void Register(User entity);
    }
}