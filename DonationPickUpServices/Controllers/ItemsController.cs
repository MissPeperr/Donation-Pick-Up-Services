using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DonationPickUpServices.Data;
using DonationPickUpServices.Models;
using Microsoft.AspNetCore.Identity;

namespace DonationPickUpServices.Controllers
{
    public class ItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        // Create variable to represent User Data
        private readonly UserManager<ApplicationUser> _userManager;

        // Create component to get current user from the _userManager variable
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: Items
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Items.Include(i => i.ApplicationUser).Include(i => i.Donation).Include(i => i.ItemType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Items/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                .Include(i => i.ApplicationUser)
                .Include(i => i.Donation)
                .Include(i => i.ItemType)
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // GET: Items/Create
        public IActionResult Create()
        {
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id");
            ViewData["DonationId"] = new SelectList(_context.Donations, "DonationId", "DonationId");
            ViewData["ItemTypeId"] = new SelectList(_context.ItemTypes, "ItemTypeId", "Title");
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemId,Title,Description,Weight,Quantity,ApplicationUserId,ItemTypeId,DonationId")] Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", item.ApplicationUserId);
            ViewData["DonationId"] = new SelectList(_context.Donations, "DonationId", "DonationId", item.DonationId);
            ViewData["ItemTypeId"] = new SelectList(_context.ItemTypes, "ItemTypeId", "Title", item.ItemTypeId);
            return View(item);
        }

        // GET: Items/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", item.ApplicationUserId);
            ViewData["DonationId"] = new SelectList(_context.Donations, "DonationId", "DonationId", item.DonationId);
            ViewData["ItemTypeId"] = new SelectList(_context.ItemTypes, "ItemTypeId", "Title", item.ItemTypeId);
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemId,Title,Description,Weight,Quantity,ApplicationUserId,ItemTypeId,DonationId")] Item item)
        {
            if (id != item.ItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.ItemId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", item.ApplicationUserId);
            ViewData["DonationId"] = new SelectList(_context.Donations, "DonationId", "DonationId", item.DonationId);
            ViewData["ItemTypeId"] = new SelectList(_context.ItemTypes, "ItemTypeId", "Title", item.ItemTypeId);
            return View(item);
        }

        // GET: Items/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                .Include(i => i.ApplicationUser)
                .Include(i => i.Donation)
                .Include(i => i.ItemType)
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Items.FindAsync(id);
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // write a method to create a donation & post the item
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateItemDonation(Item item)
        {
            var user = await GetCurrentUserAsync();

            // removing the UserId and DonationId from the ModelState so the ModelState is Valid
            ModelState.Remove("ApplicationUserId");
            ModelState.Remove("ApplicationUser");
            ModelState.Remove("DonationId");

            if (ModelState.IsValid)
            {
                Donation newDonation = new Donation
                {
                    ApplicationUserId = user.Id,
                    ApplicationUser = user,
                    StatusId = 1
                };
                _context.Add(newDonation);

                item.ApplicationUser = user;
                item.ApplicationUserId = user.Id;
                item.DonationId = newDonation.DonationId;
                _context.Add(item);

                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index", "Donations");
        }

        private bool ItemExists(int id)
        {
            return _context.Items.Any(e => e.ItemId == id);
        }
    }
}
