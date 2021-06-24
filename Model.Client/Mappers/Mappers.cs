//using Model.Client.Data;
////using G = WepAppEmpty.Model.Global;
using G = Model.Global.Data;
using Model.Client.Data;
using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Client.Mappers
{
    internal static class Mappers
    {
        internal static G.User ToGlobal(this User entity)
        {
            return new G.User()
            {
                Id = entity.Id,
                LastName = entity.LastName,
                FirstName = entity.FirstName,
                Email = entity.Email,
                Passwd = entity.Passwd,
                IsAdmin = entity.IsAdmin
            };
        }

        internal static User ToClient(this G.User entity)
        {
            return new User(
                entity.Id, 
                entity.LastName, 
                entity.FirstName, 
                entity.Email, 
                entity.IsAdmin
           );
        }

        //Je transforme mon contact globla en contact client
        internal static Contact ToClient(this G.Contact contact)
        {
            return new Contact(
                contact.Id,
                contact.LastName,
                contact.FirstName,
                contact.Email,
                contact.CategoryId,
                contact.UserId
            );
        }

        //Je transforme mon contact global en client
        internal static G.Contact ToGlobal(this Contact contact)
        {
            return new G.Contact()
            {
                Id = contact.Id,
                LastName = contact.LastName,
                FirstName = contact.FirstName,
                Email = contact.Email,
                CategoryId = contact.CategoryId,
                UserId = contact.UserId
            };
        }

        //Je transforme ma catégorie global(G.Category) en category client(Category)
        internal static Category ToClient(this G.Category category)
        {
            return new Category(
                category.Id, 
                category.Name
            );
        }

        //Je transforme ma category client en global
        internal static G.Category ToGlobal(this Category category)
        {
            return new G.Category()
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}
