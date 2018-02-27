using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspnetCoreWebAPI.Model;
using AspnetCoreWebAPI.Contexts;
using Microsoft.EntityFrameworkCore;

namespace AspnetCoreWebAPI.Repository
{
    public class ContactRepository : IContactRepository
    {
        ContactContext _context;
        public ContactRepository(ContactContext context)
        {
            _context = context;
        }

        public async Task CreateContact(Contact item)
        {
            await _context.Contact.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteContact(int contactId)
        {
            var itemToRemove = await _context.Contact.SingleOrDefaultAsync(r => r.ContactId == contactId);
            if (itemToRemove != null)
            {
                _context.Contact.Remove(itemToRemove);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Contact>> GetAllContacts()
        {
            return await _context.Contact.ToListAsync();
        }

        public async Task<Contact> GetContactById(int contactId)
        {
            return await _context.Contact.SingleOrDefaultAsync(r => r.ContactId == contactId);
        }

        public async Task UpdateContact(Contact item)
        {
            var itemToUpdate = await _context.Contact.SingleOrDefaultAsync(r => r.ContactId == item.ContactId);
            if (itemToUpdate != null)
            {
                itemToUpdate.FirstName = item.FirstName;
                itemToUpdate.LastName = item.LastName;             
                itemToUpdate.Address = item.Address;
                itemToUpdate.Phone = item.Phone;
                itemToUpdate.Email = item.Email;            
                itemToUpdate.DateOfBirth = item.DateOfBirth;
                itemToUpdate.IsActive = item.IsActive;
                await _context.SaveChangesAsync();
            }
        }
    }
}
