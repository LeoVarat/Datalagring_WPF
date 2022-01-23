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
    internal interface IUserService
    {
        bool Create(string username, int contactid);
        IEnumerable<User> GetAll();
    }
    internal class UserService : IUserService
    {
        private readonly SqlContext _context = new();

        public bool  Create(string username, int contactid)
        {
            var user = _context.Users.Where(x => x.UserName == username).FirstOrDefault();
            if (user == null)
            {
                _context.Users.Add(new User
                {
                    UserName = username,
                    ContactId = contactid
                });
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.Include(x => x.Contact);
        }
    }
}
