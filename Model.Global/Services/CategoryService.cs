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
    public class CategoryService : ICategoryRepository
    {
        private readonly Connection _connection;

        public CategoryService(Connection connection)
        {
            _connection = connection;
        }
        public IEnumerable<Category> Get()
        {
            Command command = new Command("SELECT [Id], [Name] FROM [Category];", false);

            return _connection.ExecuteReader(command, dr => dr.ToCategory());
        }

        public Category Get(int id)
        {
            Command command = new Command("SELECT [Id], [Name] FROM [Category] WHERE [Id] = @Id;", false);
            command.AddParameter("Id", id);

            return _connection.ExecuteReader(command, dr => dr.ToCategory()).SingleOrDefault();
        }

        public bool Insert(Category category)
        {
            Command command = new Command("BFSP_AddCategory", true);
            command.AddParameter("Name", category.Name);

            return _connection.ExecuteNonQuery(command) == 1;
        }
    }
}
