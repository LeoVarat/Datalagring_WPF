using Contactform.Data;
using Contactform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contactform.Services
{
    internal interface IEventStatusService
    {
        bool Create(string name);
        IEnumerable<EventStatus> GetEventStatuses();
    }
    internal class EventStatusService : IEventStatusService
    {
        private readonly SqlContext _context = new();
        public bool Create(string name)
        {
            var eventstatus = _context.EventStatuses.Where(x => x.Name == name).FirstOrDefault();
            if (eventstatus == null)
            {
                _context.EventStatuses.Add(new EventStatus
                {
                    Name = name,
                });
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<EventStatus> GetEventStatuses()
        {
            return _context.EventStatuses;
        }
    }
}
