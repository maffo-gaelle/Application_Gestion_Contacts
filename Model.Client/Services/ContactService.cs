using Model.Client.Data;
using Model.Client.Mappers;
using Model.Client.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalIContactsRepository = Model.Global.Repositories.IContactRepository;
using GS = Model.Global.Services;
using GR = Model.Global.Repositories;

namespace Model.Client.Services
{
    public class ContactService : IContactRepository
    {
        //private readonly GlobalIContactsRepository _contactsRepository;
        private readonly GR.IContactRepository _contactRepository;
        public ContactService(GR.IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public IEnumerable<Contact> Get()
        {
            //ne pas utiliser si on n'a pas les même proprietés
            //return (IEnumerable<Contact>)_contactsRepository.Get();
            return _contactRepository.Get().Select(c => c.ToClient());
        }


        public IEnumerable<Contact> GetByCategory(int id)
        {
            return _contactRepository.GetByCategory(id).Select(c => c.ToClient());
        }

        public Contact Get(int id)
        {
            //Puisque get de contact renvoie un contact de global, je le transforme en toClient
            //La méthode get de global retoune un singleOrDefault donc si c'est default,
            ////Il retourne un contact null
            return _contactRepository.Get(id)?.ToClient();
        }

        public bool Insert(Contact contact)
        {
            //Insert reçoit un contact de client pourtant la méthode insert doit recevoir un contact de client
            //d'où la conversion contact.ToGlobal()
            return _contactRepository.Insert(contact.ToGlobal());
        }

        public bool Update(int id, Contact contact)
        {
            return _contactRepository.Update(id, contact.ToGlobal());
        }

        public bool Delete(int id)
        {
            return _contactRepository.Delete(id);
        }

        public IEnumerable<Contact> GetPersonnalCategory()
        {
            return _contactRepository.GetPersonnalCategory().Select(c => c.ToClient());
        }

        public IEnumerable<Contact> GetProfessionnalCategory()
        {
            return _contactRepository.GetProfessionnalCategory().Select(c => c.ToClient());
        }

        public IEnumerable<Contact> GetOthersCategory()
        {
            return _contactRepository.GetOthersCategory().Select(c => c.ToClient());
        }

    }
}
