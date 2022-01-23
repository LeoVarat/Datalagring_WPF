using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contactform.Models
{
    [Index(nameof(Email), IsUnique = true)]
    internal class Contact
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string FirstName { get; set; }
        [Required, StringLength(50)]
        public string LastName { get; set; }
        [Required, StringLength(100)]
        public string Email { get; set; }
        [Required]
        public int AdressId { get; set; }
        public Adress Adress { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
