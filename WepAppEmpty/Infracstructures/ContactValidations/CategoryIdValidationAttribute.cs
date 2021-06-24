using Model.Client.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WepAppEmpty.Infracstructures.ContactValidations
{
    public class CategoryIdValidationAttribute : ValidationAttribute
    {
        //ICategoryRepository categoryRepository = (ICategoryRepository)ValidationContext.GetService(typeof(ICategoryRepository));
        public override bool IsValid(Object value)
        {
            return (int)value != 0;
        }
    }
}
