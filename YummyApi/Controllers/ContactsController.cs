using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YummyApi.Context;
using YummyApi.Dtos.ContactDtos;
using YummyApi.Entities;

namespace YummyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ApiContext _context;

        public ContactsController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            return Ok(_context.Contacts.ToList());
        }

        [HttpGet("GetContact")]
        public IActionResult GetContact(int id)
        {
            return Ok(_context.Contacts.Find(id));
        }

        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {
            Contact contact = new Contact();
            contact.Phone = createContactDto.Phone;
            contact.Email = createContactDto.Email;
            contact.Adress = createContactDto.Adress;
            contact.MapLocation = createContactDto.MapLocation;
            contact.OpenHours = createContactDto.OpenHours;

            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return Ok("Contacts is added");
        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            Contact contact = new Contact();
            contact.ContactId = updateContactDto.ContactId;
            contact.Phone = updateContactDto.Phone;
            contact.Email = updateContactDto.Email;
            contact.Adress = updateContactDto.Adress;
            contact.MapLocation = updateContactDto.MapLocation;
            contact.OpenHours = updateContactDto.OpenHours;

            _context.Contacts.Update(contact);
            _context.SaveChanges();
            return Ok("Contact is updated.");
        }

        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var value = _context.Contacts.Find(id);
            _context.Contacts.Remove(value);
            _context.SaveChanges();
            return Ok("Contact is deleted");
        }

    }
}
