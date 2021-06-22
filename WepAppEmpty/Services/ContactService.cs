using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Tools;
using WepAppEmpty.Models;
using WepAppEmpty.Models.Mappers;

namespace WepAppEmpty.Services
{
    public class ContactService
    {

        private readonly Connection _connection;

        public ContactService(Connection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Contact> Get()
        {

            Command command = new Command("SELECT * FROM Contact", false);

            return _connection.ExecuteReader(command, record => record.ToContact());
 
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

        public Contact Get(int id)
        {
            Command command = new Command("SELECT * FROM Contact Where id = @id", false);
            command.AddParameter("Id", id);
            
            return _connection.ExecuteReader(command, record => record.ToContact()).SingleOrDefault();
        }

        public bool Create(Contact contact)
        {
            Command command = new Command("BFSP_AddContact", true);
            command.AddParameter("LastName", contact.LastName);
            command.AddParameter("FirstName", contact.FirstName);
            command.AddParameter("Email", contact.Email);
            command.AddParameter("CategoryId", contact.CategoryId);

            return _connection.ExecuteNonQuery(command) == 1;
        }

        public bool UpdateContact(Contact contact)
        {
            Command command = new Command("BFSP_UpdateContact", true);

            command.AddParameter("Id", contact.Id);
            command.AddParameter("LastName", contact.LastName);
            command.AddParameter("FirstName", contact.FirstName);
            command.AddParameter("Email", contact.Email);
            command.AddParameter("CategoryId", contact.CategoryId);

            return _connection.ExecuteNonQuery(command) == 1;

        }

        public bool DeleteContact(int id)
        {
            Command command = new Command("BFSP_DeleteContact", true);
            command.AddParameter("Id", id);

            return _connection.ExecuteNonQuery(command) == 1;
        }
    }
}
