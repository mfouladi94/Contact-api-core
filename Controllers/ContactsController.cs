using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using test_web_api_core.Data;
using test_web_api_core.Models;

namespace test_web_api_core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        private readonly contactsApiDbcontext dbcontext;

        public ContactsController(contactsApiDbcontext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        [HttpGet]
        public IActionResult GetContacts()
        {


            return Ok(dbcontext.Contacts.ToList());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetContacts([FromRoute] Guid id)
        {
            var contact = dbcontext.Contacts.Find(id);

            if (contact == null)
            {
                return NotFound();

            }

            return Ok(contact);


        }
        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult GetContact([FromRoute] Guid id)
        {
            var contact = dbcontext.Contacts.Find(id);

            if (contact != null)
            {
                dbcontext.Remove(contact);
                dbcontext.SaveChanges();

                return Ok(contact);
            }

            
            return NotFound();

        }

        [HttpPost]
        public IActionResult AddContact(AddContactRequest addContactRequest)
        {
            var contact = new Contact()
            {
                Id = Guid.NewGuid(),
                Address = addContactRequest.Address,
                Name = addContactRequest.Name,
                Phone = addContactRequest.Phone,
            };
            
            dbcontext.Contacts.Add(contact);
            dbcontext.SaveChanges();

            return Ok(contact);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateContact([FromRoute] Guid id , UpdateContactRequestcs updateContactRequestcs)
        {
            var contact = dbcontext.Contacts.Find(id);

            if (contact != null)
            {
                
                contact.Address = updateContactRequestcs.Address;
                contact.Phone = updateContactRequestcs.Phone;
                contact.Name = updateContactRequestcs.Name;

                dbcontext.SaveChanges();

                return Ok(contact);
            }

            
            return NotFound();
        }
    }
}
