using ContactsApi.Models;
using ContactsApi.Repository;
using Microsoft.AspNetCore.Mvc;
 
using System.Collections.Generic;
using ContactsApi.Contexts;
 
namespace ContactsApi.Controllers
{
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        public IContactsRepository ContactsRepo { get; set; }
 
        public ContactsController()
        {
            ContactsRepo = new ContactsRepository(new ContactsContext());
        }
        
        [HttpGet]
        public IEnumerable<Contacts> GetAll()
        {
            return ContactsRepo.GetAll();
        }
 
        [HttpGet("{id}", Name = "GetContacts")]
        public IActionResult GetById(int id)
        {
            var item = ContactsRepo.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
 
        [HttpPost]
        public IActionResult Create([FromBody] Contacts item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            ContactsRepo.Add(item);
            return CreatedAtRoute("GetContacts", new { Controller = "Contacts", id = item.MobilePhone }, item);
        }
 
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Contacts item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            var contactObj = ContactsRepo.Find(id);
            if (contactObj == null)
            {
                return NotFound();
            }
            ContactsRepo.Update(item);
            return new NoContentResult();
        }
 
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ContactsRepo.Remove(id);
        }
    }
}