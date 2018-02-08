using System.Collections.Generic;
using System.Linq;
using ContactsApi.Models;
using ContactsApi.Contexts;
 
namespace ContactsApi.Repository
{
    public class ContactsRepository : IContactsRepository
    {
        ContactsContext _context;
        public ContactsRepository(ContactsContext context)
        {
            _context = context;
        }        
 
        public void Add(Contacts item)
        {
            _context.Contacts.Add(item);
            _context.SaveChanges();
        }

        /*
        public void Add(Contacts item)
        {
            ContactsList.Add(item);
        }
         */
 
		public IEnumerable<Contacts> GetAll()
        {
            return _context.Contacts.ToList();
        }
        /* 
        public IEnumerable<Contacts> GetAll()
        {
            return ContactsList;
        }
        */

        //static List<Contacts> ContactsList = new List<Contacts>();
 
        
 
        public Contacts Find(string key)
        {
            return _context.Contacts.Where(e => e.MobilePhone.Equals(key)).SingleOrDefault();
        }

        /*
        public Contacts Find(string key)
        {
            return ContactsList
                .Where(e => e.MobilePhone.Equals(key))
                .SingleOrDefault();
        }
         */

        
        
        public void Remove(string Id)
        {
            var itemToRemove = _context.Contacts.SingleOrDefault(r => r.MobilePhone == Id);
            if (itemToRemove != null)
                _context.Contacts.Remove(itemToRemove);
                _context.SaveChanges();            
        }
        /*public void Remove(string Id)
        {
            var itemToRemove = ContactsList.SingleOrDefault(r => r.MobilePhone == Id);
            if (itemToRemove != null)
                ContactsList.Remove(itemToRemove);            
        } */
 
        public void Update(Contacts item)
        {
            var itemToUpdate = _context.Contacts.SingleOrDefault(r => r.MobilePhone == item.MobilePhone);
            if (itemToUpdate != null)
            {
                _context.Update(itemToUpdate);
                /*itemToUpdate.FirstName = item.FirstName;
                itemToUpdate.LastName = item.LastName;
                itemToUpdate.IsFamilyMember = item.IsFamilyMember;
                itemToUpdate.Company = item.Company;
                itemToUpdate.JobTitle = item.JobTitle;
                itemToUpdate.Email = item.Email;
                itemToUpdate.MobilePhone = item.MobilePhone;
                itemToUpdate.DateOfBirth = item.DateOfBirth;
                itemToUpdate.AnniversaryDate = item.AnniversaryDate; */
            }
        }
        /*public void Update(Contacts item)
        {
            var itemToUpdate = ContactsList.SingleOrDefault(r => r.MobilePhone == item.MobilePhone);
            if (itemToUpdate != null)
            {
                itemToUpdate.FirstName = item.FirstName;
                itemToUpdate.LastName = item.LastName;
                itemToUpdate.IsFamilyMember = item.IsFamilyMember;
                itemToUpdate.Company = item.Company;
                itemToUpdate.JobTitle = item.JobTitle;
                itemToUpdate.Email = item.Email;
                itemToUpdate.MobilePhone = item.MobilePhone;
                itemToUpdate.DateOfBirth = item.DateOfBirth;
                itemToUpdate.AnniversaryDate = item.AnniversaryDate;
            }
        } */
    }
}