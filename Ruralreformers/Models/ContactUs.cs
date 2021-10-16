using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ruralreformers.Models
{
    public class ContactUs
    {
        public string ToEmail { get; set; }

        [Required]
        public string FromEmail { get; set; }

        [Required]
        public string Message { get; set; }
    }
}
