using ContactApplication.Data;
using ContactApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace ContactApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : Controller
    {
        private ContactAPIDbContext _dbContext;

        public ContactController(ContactAPIDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetContact()
        {
            Ok(await _dbContext.Contacts.ToListAsync());
            return View();
        }
        [HttpDelete]
        [Route("{id: guid}")]

        public async Task<IActionResult> DeleteContactById([FromRoute] Guid id)
        {
            var contact = _dbContext.Contacts.FindAsync(id);
            if (contact == null)
            {
                return null;
            }
            return Ok(contact);
        }
            [HttpPost]
        public async Task<IActionResult> AddContact(ContactRequest Request)
        {
            var contact = new Contact()
            {
                Id = Guid.NewGuid(),
                Address = Request.Address,
                Email = Request.Email,
                FullName = Request.FullName,
                PhoneNumber = Request.PhoneNumber,
                CreatedDate = DateTime.Now,
            };
            await _dbContext.Contacts.AddAsync(contact);
            await _dbContext.SaveChangesAsync();
            return Ok(contact);

        }
        [HttpPut]
        [Route("{id: Guid}")]
        public async Task<IActionResult> UpdateContact([FromRoute] Guid id, UpdateContact updateContact)
        {
            var contact = await _dbContext.Contacts.FindAsync(id);

            if(contact != null)
            {
                contact.FullName = updateContact.FullName;
                contact.Address = updateContact.Address;
                contact.PhoneNumber = updateContact.PhoneNumber;
                contact.Email = updateContact.Email;
                contact.CreatedDate = DateTime.Now;
                await _dbContext.SaveChangesAsync();
                return Ok(contact);
            }
            return NotFound();
        }
        [HttpDelete]
        [Route("{id: guid}")]
        
        public async Task<IActionResult> DeleteContact([FromRoute] Guid id)
        {
            var contact = await _dbContext.Contacts.FindAsync(id);
            if(contact != null)
            {
               _dbContext.Contacts.Remove(contact);
                _dbContext.SaveChanges();
                return Ok(contact);
            }
            return NotFound();
        }
    }
}
