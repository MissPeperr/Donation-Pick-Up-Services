using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DonationPickUpServices.Models
{
    public class ApplicationUser : IdentityUser

    {

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        [Display(Name = "Zipcode")]
        public string ZipCode { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string UserPhoneNumber { get; set; }

        [Required]
        public int UserTypeId { get; set; }

        // must include this since it's a FK
        public UserType UserType { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
