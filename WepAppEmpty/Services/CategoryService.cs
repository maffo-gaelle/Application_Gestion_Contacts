using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tools;
using WepAppEmpty.Models;
using WepAppEmpty.Models.Mappers;

namespace WepAppEmpty.Services
{
    public class CategoryService
    {
        private readonly Connection _connection;

        public CategoryService(Connection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Category> Get()
        {
            Command command = new Command("SELECT * FROM category", false);

            return _connection.ExecuteReader(command, dr => dr.ToCategory());
        }
    }
}
