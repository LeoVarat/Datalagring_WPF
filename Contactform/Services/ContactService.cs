using Contactform.Data;
using Contactform.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contactform.Services
{
    internal interface IContactService
    {
        bool Create(string firstname, string lastname, string email, int adressid);
        IEnumerable<Contact> GetAllContacts();
    }

    internal class ContactService : IContactService
    {
        private readonly SqlContext _context = new();
        public bool Create(string firstname, string lastname, string email, int adressid)
        {
            var contact = _context.Contacts.Where(x => x.Email == email).FirstOrDefault();
            if (contact == null)
            {
                _context.Contacts.Add(new Contact
                {
                    FirstName = firstname,
                    LastName = lastname,
                    Email = email,
                    AdressId = adressid
                });
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<Contact> GetAllContacts()
        {
            return _context.Contacts.Include(x => x.Adress);
        }


    }
}
