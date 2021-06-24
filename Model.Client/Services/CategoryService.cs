using Model.Client.Data;
using Model.Client.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GR = Model.Global.Repositories;
using Model.Client.Mappers;

namespace Model.Client.Services
{
    public class CategoryService : ICategoryRepository
    {
        //private readonly GlobalICategoriesRepository _categoriesRepository;
        private readonly GR.ICategoryRepository _categoryRepository;

        public CategoryService(GR.ICategoryRepository categoryService)
        {
            _categoryRepository = categoryService;
        }

        public IEnumerable<Category> Get()
        {
            return _categoryRepository.Get().Select(c => c.ToClient());
        }



        public Category Get(int id)
        {
            return _categoryRepository.Get(id)?.ToClient();
        }

        public bool Insert(Category category)
        {
            return _categoryRepository.Insert(category.ToGlobal());
        }
    }
}
