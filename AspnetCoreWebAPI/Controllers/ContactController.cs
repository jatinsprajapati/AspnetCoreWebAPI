using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspnetCoreWebAPI.Repository;
using AspnetCoreWebAPI.Model;

namespace AspnetCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ContactController : Controller
    {
        public IContactRepository ContactRepo { get; set; }
        public ContactController(IContactRepository _repo)
        {
            ContactRepo = _repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllContacts()
        {
            var contactList = await ContactRepo.GetAllContacts();
            return Ok(contactList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById(string id)
        {
            var item = await ContactRepo.GetContactById(Convert.ToInt32(id));
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact([FromBody] Contact item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            await ContactRepo.CreateContact(item);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact(string id, [FromBody] Contact item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            var contactObj = await ContactRepo.GetContactById(Convert.ToInt32(id));
            if (contactObj == null)
            {
                return NotFound();
            }
            await ContactRepo.UpdateContact(item);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(string id)
        {
            await ContactRepo.DeleteContact(Convert.ToInt32(id));
            return NoContent();
        }
    }
}
