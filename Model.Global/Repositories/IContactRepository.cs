using Model.Global.Data;
using System.Collections.Generic;

namespace Model.Global.Repositories
{
    public interface IContactRepository
    {
        bool Delete(int id);
        IEnumerable<Contact> Get();
        Contact Get(int id);
        IEnumerable<Contact> GetByCategory(int id);
        IEnumerable<Contact> GetOthersCategory();
        IEnumerable<Contact> GetPersonnalCategory();
        IEnumerable<Contact> GetProfessionnalCategory();
        bool Insert(Contact contact);
        bool Update(int id, Contact contact);
    }
}