using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DonationPickUpServices.Models
{
    public class Item
    {

        [Required]
        [Key]
        public int ItemId { get; set; }

        [Required]
        [Display(Name = "Being Donated:")]
        public string Title { get; set; }

        [Required]
        public string Description { get; set;}

        // this is in lbs
        [Required]
        [Display(Name ="Approximate Weight (lbs)")]
        public int Weight { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        [Required]
        public ApplicationUser ApplicationUser { get; set; }

        [Required]
        public int ItemTypeId { get; set; }

        // needs instance of model since it's a FK
        public ItemType ItemType { get; set; }

        [Required]
        public int DonationId { get; set; }

        public Donation Donation { get; set; }

    }
}
