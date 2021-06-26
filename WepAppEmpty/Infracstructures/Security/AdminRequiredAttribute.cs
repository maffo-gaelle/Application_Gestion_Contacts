using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WepAppEmpty.Infracstructures.Security
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    //Toute les classe d'autorisation sont presque la même chose, ce qui change c'est la condition
    //Ceci sera geré avec l'area
    public class AdminRequiredAttribute : TypeFilterAttribute
    {
        public AdminRequiredAttribute(Type type) : base(type)
        {
        }
    }
}
