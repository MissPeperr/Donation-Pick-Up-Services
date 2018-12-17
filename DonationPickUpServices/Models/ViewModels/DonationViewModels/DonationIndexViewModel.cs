using System.Collections.Generic;
using DonationPickUpServices.Models;
using DonationPickUpServices.Data;

namespace DonationPickUpServices.Models.ViewModels.DonationViewModels
{
    public class DonationIndexViewModel
    {
        public Donation Donation { get; set; }
        public List<Donation> Donations { get; set; }

        public Item Item { get; set; }
        public List<Item> Items { get; set; }

        public ApplicationUser AppUser { get; set; }

    }
}