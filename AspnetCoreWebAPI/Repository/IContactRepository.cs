using AspnetCoreWebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetCoreWebAPI.Repository
{
    public interface IContactRepository
    {
        Task CreateContact(Contact item);
        Task<IEnumerable<Contact>> GetAllContacts();
        Task<Contact> GetContactById(int contactId);
        Task DeleteContact(int contactId);
        Task UpdateContact(Contact item);
    }
}
