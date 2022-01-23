using Contactform.Data;
using Contactform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contactform.Services
{
    internal interface IAdressService
    {
        void Create(string streetname, int postalcode, string county, string country);
        IEnumerable<Adress> GetAdresses();

    }
    internal class AdressService : IAdressService
    {
        private readonly SqlContext _context = new();
        public void Create(string streetname, int postalcode, string county, string country)
        {
            _context.Adresses.Add(new Adress
            {
                Streetname = streetname,
                Postalcode = postalcode,
                County = county,
                Country = country
            });
            _context.SaveChanges();
        }

        public IEnumerable<Adress> GetAdresses()
        {
            return _context.Adresses;
        }
    }
}
