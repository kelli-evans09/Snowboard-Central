using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SnowboardCentral.Data;
using SnowboardCentral.Models;
using Microsoft.AspNetCore.Identity;

namespace SnowboardCentral
{
    public class ResortReviewsController : Controller
    {
        // Private field to store user manager
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly ApplicationDbContext _context;

        public ResortReviewsController(ApplicationDbContext 
            context,UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        //Private method to get current user
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync
            (HttpContext.User);

        // GET: ResortReviews
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ResortReviews
                .Include(r => r.Resort)
                .Include(r => r.User)
                .OrderByDescending(r => r.Id);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ResortReviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resortReview = await _context.ResortReviews
                .Include(r => r.Resort)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (resortReview == null)
            {
                return NotFound();
            }

            return View(resortReview);
        }

        // GET: ResortReviews/Create
        public IActionResult Create()
        {
            ViewData["ResortId"] = new SelectList(_context.Resorts, "Id", "Id");
            return View();
        }

        // POST: ResortReviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ResortId,Rating,UserId,DetailReview")] ResortReview resortReview)
        {
            ModelState.Remove("UserId");
            ModelState.Remove("User");
            if (ModelState.IsValid)
            {
                var currentUser = await GetCurrentUserAsync();
                resortReview.UserId = currentUser.Id;
                _context.Add(resortReview);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ResortId"] = new SelectList(_context.Resorts, "Id", "Id", resortReview.ResortId);
            return View(resortReview);
        }

        // GET: ResortReviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resortReview = await _context.ResortReviews.FindAsync(id);
            if (resortReview == null)
            {
                return NotFound();
            }
            ViewData["ResortId"] = new SelectList(_context.Resorts, "Id", "Id", resortReview.ResortId);
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", resortReview.UserId);
            return View(resortReview);
        }

        // POST: ResortReviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ResortId,Rating,UserId,DetailReview")] ResortReview resortReview)
        {
            if (id != resortReview.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resortReview);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResortReviewExists(resortReview.Id))
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
            ViewData["ResortId"] = new SelectList(_context.Resorts, "Id", "Id", resortReview.ResortId);
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", resortReview.UserId);
            return View(resortReview);
        }

        // GET: ResortReviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resortReview = await _context.ResortReviews
                .Include(r => r.Resort)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (resortReview == null)
            {
                return NotFound();
            }

            return View(resortReview);
        }

        // POST: ResortReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resortReview = await _context.ResortReviews.FindAsync(id);
            _context.ResortReviews.Remove(resortReview);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResortReviewExists(int id)
        {
            return _context.ResortReviews.Any(e => e.Id == id);
        }
    }
}
