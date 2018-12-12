using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DonationPickUpServices.Models
{
    public class UserType
    {
        [Required]
        public int UserTypeId { get; set; }

        [Required]
        public string Title { get; set; }
    }
}
