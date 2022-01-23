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
    internal interface IUserEventService
    {
        void Create(string header, string description, int eventid, int userid, DateTime created, DateTime lastchanged);
        IEnumerable<UserEvent> GetAllEvents ();
    }
    internal class UserEventService : IUserEventService
    {
        private readonly SqlContext _context = new();
        public void Create(string header, string description, int eventid, int userid, DateTime created, DateTime lastchanged)
        {
            _context.UserEvents.Add(new UserEvent
            {
                Header = header,
                Description = description,
                EventId = eventid,
                UserId = userid,
                Created = DateTime.Now,
                LastChange = DateTime.Now,
            });
        }

        public IEnumerable<UserEvent> GetAllEvents()
        {
            return _context.UserEvents
                .Include(x => x.User)
                .Include(x => x.Status);
        }
    }
}
