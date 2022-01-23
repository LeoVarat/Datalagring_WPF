using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contactform.Models
{
    internal class UserEvent
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Header { get; set; }
        [Required, StringLength(250)]
        public string Description { get; set; }
        [Required]
        public int EventId { get; set; }
        public EventStatus Status { get; set; }
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
        [Required]
        public DateTime Created { get; set; } 
        [Required]
        public DateTime LastChange { get; set; } 
    }
}
