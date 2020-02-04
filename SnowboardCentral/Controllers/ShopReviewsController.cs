using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SnowboardCentral.Data;
using SnowboardCentral.Models;

namespace SnowboardCentral.Controllers
{
    public class ShopReviewsController : Controller

    {

        // Private field to store user manager
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly ApplicationDbContext _context;

        public ShopReviewsController(ApplicationDbContext 
            context,UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        //Private method to get current user
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync
            (HttpContext.User);

        // GET: ShopReviews
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ShopReviews
                .Include(s => s.Shop)
                .Include(s => s.User)
                .OrderByDescending(s =>s.Id);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ShopReviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopReview = await _context.ShopReviews
                .Include(s => s.Shop)
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shopReview == null)
            {
                return NotFound();
            }

            return View(shopReview);
        }

        // GET: ShopReviews/Create
        public IActionResult Create()
        {
            ViewData["ShopId"] = new SelectList(_context.Shops, "Id", "Id");
            return View();
        }

        // POST: ShopReviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ShopId,Rating,UserId,DetailReview")] ShopReview shopReview)
        {
            ModelState.Remove("UserId");
            ModelState.Remove("User");
            if (ModelState.IsValid)
            {
                var currentUser = await GetCurrentUserAsync();
                shopReview.UserId = currentUser.Id;
                _context.Add(shopReview);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ShopId"] = new SelectList(_context.Shops, "Id", "Id", shopReview.ShopId);
            return View(shopReview);
        }

        // GET: ShopReviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopReview = await _context.ShopReviews.FindAsync(id);
            if (shopReview == null)
            {
                return NotFound();
            }
            ViewData["ShopId"] = new SelectList(_context.Shops, "Id", "Id", shopReview.ShopId);
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", shopReview.UserId);
            return View(shopReview);
        }

        // POST: ShopReviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ShopId,Rating,UserId,DetailReview")] ShopReview shopReview)
        {
            if (id != shopReview.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shopReview);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShopReviewExists(shopReview.Id))
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
            ViewData["ShopId"] = new SelectList(_context.Shops, "Id", "Id", shopReview.ShopId);
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", shopReview.UserId);
            return View(shopReview);
        }

        // GET: ShopReviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopReview = await _context.ShopReviews
                .Include(s => s.Shop)
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shopReview == null)
            {
                return NotFound();
            }

            return View(shopReview);
        }

        // POST: ShopReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shopReview = await _context.ShopReviews.FindAsync(id);
            _context.ShopReviews.Remove(shopReview);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShopReviewExists(int id)
        {
            return _context.ShopReviews.Any(e => e.Id == id);
        }
    }
}
