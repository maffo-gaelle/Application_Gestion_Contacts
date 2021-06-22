using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tools;
using WepAppEmpty.Models;
using WepAppEmpty.Models.Mappers;

namespace WepAppEmpty.Services
{
    public class UserService
    {
        private readonly Connection _connection;

        public UserService(Connection connection)
        {
            _connection = connection;
        }

        public IEnumerable<User> Get()
        {
            Command command = new Command("SELECT * FROM Utilisateur", false);

            return _connection.ExecuteReader(command, record => record.ToUser());
        }

        public User Get(int id)
        {
            Command command = new Command("SELECT * FROM Utilisateur Where id = @id", false);
            command.AddParameter("id", id);

            return _connection.ExecuteReader(command, record => record.ToUser()).SingleOrDefault();
        }

        public User Get(string email)
        {
            Command command = new Command("SELECT * FROM Utilisateur Where email = @email", false);
            command.AddParameter("Email", email);

            return _connection.ExecuteReader(command, record => record.ToUser()).FirstOrDefault();
        }

        public bool Create(User user)
        {
            Command command = new Command("BFSP_AddUser", true);
            command.AddParameter("LastName", user.LastName);
            command.AddParameter("FirstName", user.FirstName);
            command.AddParameter("Email", user.Email);
            command.AddParameter("BirthDate", user.BirthDate);
            command.AddParameter("Passwd", user.Passwd);

            return _connection.ExecuteNonQuery(command) == 1;
        }

        //public bool UpdateContact(Contact contact)
        //{
        //    Command command = new Command("BFSP_UpdateContact", true);

        //    command.AddParameter("Id", contact.Id);
        //    command.AddParameter("LastName", contact.LastName);
        //    command.AddParameter("FirstName", contact.FirstName);
        //    command.AddParameter("Email", contact.Email);
        //    command.AddParameter("CategoryId", contact.CategoryId);

        //    return _connection.ExecuteNonQuery(command) == 1;

        //}

        //public bool DeleteContact(int id)
        //{
        //    Command command = new Command("BFSP_DeleteContact", true);
        //    command.AddParameter("Id", id);

        //    return _connection.ExecuteNonQuery(command) == 1;
        //}
    }
}
