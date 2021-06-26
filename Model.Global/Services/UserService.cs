using Model.Global.Data;
using Model.Global.Mappers;
using Model.Global.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace Model.Global.Services
{
    public class UserService : IAuthRepository
    {
        private readonly Connection _connection;

        public UserService(Connection connection)
        {
            _connection = connection;
        }

        public bool EmailExists(string email)
        {
            Command command = new Command("Select Count(*) From [User] where Email = @Email;", false);
            command.AddParameter("Email", email);

            return (int)_connection.ExecuteScalar(command) == 1;
        }

        public User Login(string email, string passwd)
        {
            Command command = new Command("BFSP_AuthUser", true);
            command.AddParameter("Email", email);
            command.AddParameter("Passwd", passwd);

            return _connection.ExecuteReader(command, dr => dr.ToUser()).SingleOrDefault();
        }

        public void Register(User entity)
        {
            Command command = new Command("BFSP_RegisterUser", true);
            command.AddParameter("LastName", entity.LastName);
            command.AddParameter("FirstName", entity.FirstName);
            command.AddParameter("Email", entity.Email);
            command.AddParameter("Passwd", entity.Passwd);
            _connection.ExecuteNonQuery(command);
            entity.Passwd = null;
        }

        public IEnumerable<Contact> GetContactByUser(int id)
        {
            Command command = new Command("SELECT [Id], [LastName], [FirstName], [Email], [CategoryId], [UserId] FROM [Contact] WHERE [UserId] = @UserId;", false);
            command.AddParameter("UserId", id);

            return _connection.ExecuteReader(command, dr => dr.ToContact());
        }

        public User Get(int id)
        {
            Command command = new Command("SELECT [Id], [LastName], [FirstName], [Email], [Passwd], [IsAdmin] FROM [User] WHERE [Id] = @Id;", false);
            command.AddParameter("Id", id);
            return _connection.ExecuteReader(command, dr => dr.ToUser()).SingleOrDefault();
        }

        public IEnumerable<User> Get()
        {
            Command command = new Command("SELECT * FROM [User];", false);
          
            return _connection.ExecuteReader(command, dr => dr.ToUser());
        }

        public IEnumerable<Contact> getContactsByCategoryAndUser(int userId, int categoryId)
        {
            Command command = new Command("SELECT * From Contact WHERE UserId = @userId AND CategoryId = @categoryId", false);

            command.AddParameter("UserId", userId);
            command.AddParameter("CategoryId", categoryId);

            return _connection.ExecuteReader(command, dr => dr.ToContact());
        }
    }
}
