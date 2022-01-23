using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contactform.Models
{
    internal class Adress
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string Streetname { get; set; }
        [Required]
        public int Postalcode { get; set; }
        [Required]
        public string County { get; set; }
        [Required]
        public string Country { get; set; }

        public virtual ICollection<Contact> Contact { get;}

    }
}
