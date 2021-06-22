using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WepAppEmpty.Models.Mappers
{
    public static class DataRecord
    {
        public static Contact ToContact(this IDataRecord record)
        {
            return new Contact()
            {
                Id = (int)record["ID"],
                FirstName = (string)record["FirstName"],
                LastName = (string)record["LastName"],
                Email = (string)record["Email"],
                CategoryId = (int)record["CategoryId"]
            };
        }

        public static User ToUser(this IDataRecord record)
        {
            return new User()
            {
                id = (int)record["ID"],
                FirstName = (string)record["FirstName"],
                LastName = (string)record["LastName"],
                Email = (string)record["Email"],
                //BirthDate = (DbNull)record["BirthDate"],
                Passwd = (string)record["Passwd"]
            };
        }

        public static Category ToCategory(this IDataRecord record)
        {
            return new Category()
            {
                Id = (int)record["ID"],
                Name = (string)record["Name"],
                
            };
        }
    }
}
