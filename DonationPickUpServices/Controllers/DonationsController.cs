﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DonationPickUpServices.Data;
using DonationPickUpServices.Models;
using Microsoft.AspNetCore.Identity;
using DonationPickUpServices.Models.ViewModels.DonationViewModels;

namespace DonationPickUpServices.Controllers
{
    public class DonationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DonationsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        // Create variable to represent User Data
        private readonly UserManager<ApplicationUser> _userManager;

        // Create component to get current user from the _userManager variable
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: Donations
        public async Task<IActionResult> Index()
        {
            DonationIndexViewModel viewModel = new DonationIndexViewModel();
            var user = await GetCurrentUserAsync();

            // if there is nobody logged in
            if(user == null)
            {
                return View("../Home/LoginError");
            }
            // if the user is an employee
            else if(user.UserTypeId == 2)
            {
                var allDonations = _context.Donations
                    .Include(d => d.Status)
                    .Include(d => d.Items)
                    .Include(d => d.ApplicationUser)
                    .ToList();

                viewModel.Donations = allDonations;
                return View(viewModel);
            }
            // if the user is a customer
            else if(user.UserTypeId == 4)
            {
                var allItems = _context.Items
                    .Include(i => i.ItemType)
                    .Include(i => i.Donation)
                    .Include(i => i.ApplicationUser)
                    .Where(i => i.ApplicationUserId == user.Id);

                List<Donation> allDonations = _context.Donations
                    .Include(d => d.Status)
                    .ToList();

                var donations = new HashSet<Donation>();
                foreach (var item in allItems)
                {
                    donations.Add(item.Donation);
                }
                viewModel.CustDonations = donations;

                return View(viewModel);
            }
            return View("../Home/LoginError");
        }

        // GET: Donations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donation = await _context.Donations
                .Include(d => d.Status)
                .Include(d => d.Items)
                .Include(d => d.ApplicationUser)
                .FirstOrDefaultAsync(m => m.DonationId == id);
            if (donation == null)
            {
                return NotFound(); 
            }

            return View(donation);
        }

        // GET: Donations/Create
        public IActionResult Create()
        {
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "Title");
            return View();
        }

        // POST: Donations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DonationId,DateCreated,DateCompleted,StatusId")] Donation donation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(donation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "Title", donation.StatusId);
            return View(donation);
        }

        // GET: Donations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donation = await _context.Donations.FindAsync(id);
            //var donation = await _context.Donations
            //    .Include(d => d.Status)
            //    .Include(d => d.Items)
            //    .Include(d => d.ApplicationUser)
            //    .FirstOrDefaultAsync(m => m.DonationId == id);
            if (donation == null)
            {
                return NotFound();
            }
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "Title", donation.StatusId);
            return View(donation);
        }

        // POST: Donations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DonationId,DateCreated,DateCompleted,StatusId")] Donation donation)
        {
            if (id != donation.DonationId)
            {
                return NotFound();
            }


            // removing the UserId and DonationId from the ModelState so the ModelState is Valid
            ModelState.Remove("ApplicationUserId");
            ModelState.Remove("ApplicationUser");
            ModelState.Remove("DateCompleted");
            ModelState.Remove("DateCreated");
            //ModelState.Remove("DonationId)


            var currentDonation = await _context.Donations.FindAsync(id);

            if (ModelState.IsValid)
            {
                try
                {
                    currentDonation.StatusId = donation.StatusId;
                    _context.Update(currentDonation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonationExists(donation.DonationId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", new { id = currentDonation.DonationId });
            }
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "Title", donation.StatusId);
            return View(currentDonation);
        }

        // GET: Donations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donation = await _context.Donations
                .Include(d => d.Status)
                .FirstOrDefaultAsync(m => m.DonationId == id);
            if (donation == null)
            {
                return NotFound();
            }

            return View(donation);
        }

        // POST: Donations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var donation = await _context.Donations.FindAsync(id);
            _context.Donations.Remove(donation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DonationExists(int id)
        {
            return _context.Donations.Any(e => e.DonationId == id);
        }

        //// Using this method caused an error FYI
        //[HttpPost, ActionName("Edit")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> UpdateStatus(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var donation = await _context.Donations.FirstOrDefaultAsync(d => d.DonationId == id);
        //    if (await TryUpdateModelAsync<Donation>(
        //        donation, "",
        //        d => d.StatusId))
        //    {
        //        try
        //        {
        //            donation.DateCompleted = DateTime.Now;
        //            _context.Update(donation);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!DonationExists(donation.DonationId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return View(donation);
        //    }
        //    ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "Title", donation.StatusId);
        //    return View(donation);
        //}

            public async Task<IActionResult> Cancel(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donation = await _context.Donations
                .Include(d => d.Status)
                .Include(d => d.Items)
                .FirstOrDefaultAsync(m => m.DonationId == id);
            if (donation == null)
            {
                return NotFound();
            }

            return View(donation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CancelConfirm(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donation = await _context.Donations
                .Include(d => d.Status)
                .FirstOrDefaultAsync(d => d.DonationId == id);
            donation.StatusId = 4;
            _context.Update(donation);

            if (donation == null)
            {
                return NotFound();
            }
            await _context.SaveChangesAsync();
            return View("CancelSuccess");
        }
    }
}
