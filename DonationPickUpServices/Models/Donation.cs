using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DonationPickUpServices.Models
{
    public class Donation
    {
        [Required]
        [Key]
        public int DonationId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; }

        [DataType(DataType.Date)]
        [Display(Description = "Date Completed")]
        public DateTime? DateCompleted { get; set; }

        [Required]
        public int StatusId { get; set; }

        public Status Status { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        [Required]
        public ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
