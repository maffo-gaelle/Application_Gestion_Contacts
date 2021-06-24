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
    public class ContactService : IContactRepository
    {
        private readonly Connection _connection;

        public ContactService(Connection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Contact> Get()
        {
            Command command = new Command("SELECT [Id], [LastName], [FirstName], [Email], [CategoryId], [UserId] FROM [Contact];", false);
            return _connection.ExecuteReader(command, dr => dr.ToContact());
        }

        public IEnumerable<Contact> GetByCategory(int id)
        {
            Command command = new("SELECT [Id], [LastName], [FirstName], [Email], [CategoryId], [UserId] FROM [Contact] WHERE [CategoryId] = @CategoryId;", false);

            command.AddParameter("CategoryId", id);
            return _connection.ExecuteReader(command, dr => dr.ToContact());
        }

        public Contact Get(int id)
        {
            Command command = new Command("SELECT [Id], [LastName], [FirstName], [Email], [CategoryId], [UserId] FROM [Contact] WHERE [Id] = @Id;", false);
            command.AddParameter("Id", id);
            return _connection.ExecuteReader(command, dr => dr.ToContact()).SingleOrDefault();
        }

        public bool Insert(Contact contact)
        {
            Command command = new Command("BFSP_AddContact", true);
            command.AddParameter("LastName", contact.LastName);
            command.AddParameter("FirstName", contact.FirstName);
            command.AddParameter("Email", contact.Email);
            command.AddParameter("CategoryId", contact.CategoryId);
            command.AddParameter("UserId", contact.UserId);

            return _connection.ExecuteNonQuery(command) == 1;
        }

        public bool Update(int id, Contact contact)
        {
            Command command = new Command("BFSP_UpdateContact", true);
            command.AddParameter("Id", id);
            command.AddParameter("LastName", contact.LastName);
            command.AddParameter("FirstName", contact.FirstName);
            command.AddParameter("Email", contact.Email);
            command.AddParameter("CategoryId", contact.CategoryId);
            command.AddParameter("UserId", contact.UserId);

            return _connection.ExecuteNonQuery(command) == 1;
        }

        public bool Delete(int id)
        {
            Command command = new Command("BFSP_DeleteContact", true);
            command.AddParameter("Id", id);
            return _connection.ExecuteNonQuery(command) == 1;
        }

        public IEnumerable<Contact> GetPersonnalCategory()
        {
            Command command = new Command("SELECT * FROM Contact WHERE CategoryId = 1", false);

            return _connection.ExecuteReader(command, record => record.ToContact());
        }

        public IEnumerable<Contact> GetProfessionnalCategory()
        {
            Command command = new Command("SELECT * FROM Contact WHERE CategoryId = 2", false);

            return _connection.ExecuteReader(command, record => record.ToContact());
        }

        public IEnumerable<Contact> GetOthersCategory()
        {
            Command command = new Command("SELECT * FROM Contact WHERE CategoryId = 3", false);

            return _connection.ExecuteReader(command, record => record.ToContact());
        }
    }
}
