using Model.Global.Data;
using System.Collections.Generic;

namespace Model.Global.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Get();
        Category Get(int id);
        bool Insert(Category category);
        bool Delete(int id);
        bool Update(int id, Category category);
    }
}