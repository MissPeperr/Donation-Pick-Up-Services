using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DonationPickUpServices.Models;
using DonationPickUpServices.Data;
using Microsoft.AspNetCore.Identity;

namespace DonationPickUpServices.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        // Create variable to represent User Data
        private readonly UserManager<ApplicationUser> _userManager;

        // Create component to get current user from the _userManager variable
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUserAsync();
            if(user == null)
            {
                return View("CustomerIndex");
            } else if(user.UserTypeId == 2)
            {
                return View();
            } else if(user.UserTypeId == 4)
            {
                return View("CustomerIndex");
            }
            return View("CustomerIndex");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
