using Model.Client.Data;
using Model.Client.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WepAppEmpty.Areas.Admin.Infracstructures.Validations
{
    public class CategoryExistValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string name = value as string;

            ICategoryRepository categoryRepository = (ICategoryRepository)validationContext.GetService(typeof(ICategoryRepository));
            Category category = categoryRepository.Get().Where(e => e.Name.ToLower() == name.ToLower()).FirstOrDefault();

            return (category == null) ? ValidationResult.Success : new ValidationResult("Cette catégorie a déjà été crée");
        }
    }
}
