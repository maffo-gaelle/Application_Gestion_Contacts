using Model.Client.Data;
using Model.Client.Mappers;
using Model.Client.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GR = Model.Global.Repositories;

namespace Model.Client.Services
{
    public class UserService : IAuthRepository
    {
        //private readonly GR.IAuthRepository _globalRepository;
        private readonly GR.IAuthRepository _authRepository;

        public UserService(GR.IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public bool EmailExists(string email)
        {
            return _authRepository.EmailExists(email);
        }

        public User Login(string email, string passwd)
        {
            return _authRepository.Login(email, passwd)?.ToClient();
        }

        public void Register(User entity)
        {
            _authRepository.Register(entity.ToGlobal());
        }

        public IEnumerable<User> Get()
        {
            return _authRepository.Get().Select(u => u.ToClient());
        }

        public IEnumerable<Contact> GetContactByUser(int id)
        {
            return _authRepository.GetContactByUser(id).Select(u => u.ToClient());
        }

        public IEnumerable<Contact> getContactsByCategoryAndUser(int userId, int categoryId)
        {
            return _authRepository.getContactsByCategoryAndUser(userId, categoryId).Select(u => u.ToClient());
        }
    }
}
