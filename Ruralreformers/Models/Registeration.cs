using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ruralreformers.Models
{
    public class Registeration
    {
        [Required]

        public string Name { get; set; }

        [Required]

        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]

        public string Place { get; set; }

        [Required]

        public string Occupation { get; set; }

        [Required]
        public string YourSelf { get; set; }

        [Required]
        public string WhyWantToJoin { get; set; }
    }
}
