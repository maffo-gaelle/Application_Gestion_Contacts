using Model.Client.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Client.Repositories
{
    public interface IAuthRepository
    {
        User Login(string email, string passwd);

        IEnumerable<User> Get();
        void Register(User entity);
        bool EmailExists(string email);
    }
}
