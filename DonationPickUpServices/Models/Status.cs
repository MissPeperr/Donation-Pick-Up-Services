using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DonationPickUpServices.Models
{
    public class Status
    {
        [Required]
        [Key]
        public int StatusId { get; set; }

        [Required]
        public string Title { get; set; }
    }
}
