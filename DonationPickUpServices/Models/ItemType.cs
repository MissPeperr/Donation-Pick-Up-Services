using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DonationPickUpServices.Models
{
    public class ItemType
    {
        [Required]
        [Key]
        public int ItemTypeId { get; set; }

        [Required]
        public string Title { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
