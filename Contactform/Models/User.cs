using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contactform.Models
{
    [Index(nameof(UserName), IsUnique = true)]
    internal class User
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string UserName { get; set; }
        [Required]
        public int ContactId { get; set; }
        public Contact Contact { get; set; }
    }
}
