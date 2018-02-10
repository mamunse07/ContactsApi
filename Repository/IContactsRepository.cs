using ContactsApi.Models;
using System.Collections.Generic;
 
namespace ContactsApi.Repository
{
    public interface IContactsRepository
    {
        void Add(Contacts item);
        IEnumerable<Contacts> GetAll();
        Contacts Find(int key);
        void Remove(int Id);
        void Update(Contacts item);
    }
}