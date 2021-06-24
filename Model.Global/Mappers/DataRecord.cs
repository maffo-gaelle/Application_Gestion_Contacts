using Model.Global.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Global.Mappers
{
    public static class DataRecord
    {
        internal static Contact ToContact(this IDataRecord record)
        {
            return new Contact()
            {
                Id = (int)record["ID"],
                FirstName = (string)record["FirstName"],
                LastName = (string)record["LastName"],
                Email = (string)record["Email"],
                CategoryId = (int)record["CategoryId"],
                UserId = (int)record["UserId"]
            };
        }

        internal static User ToUser(this IDataRecord record)
        {
            return new User()
            {
                Id = (int)record["Id"],
                LastName = (string)record["LastName"],
                FirstName = (string)record["FirstName"],
                Email = (string)record["Email"],
                //On ne renvoie jamais un mot de passe d'une base de données
                Passwd = null, 
                IsAdmin = (bool)record["IsAdmin"]
            };
        }

        internal static Category ToCategory(this IDataRecord record)
        {
            return new Category()
            {
                Id = (int)record["ID"],
                Name = (string)record["Name"],

            };
        }
    }
}
