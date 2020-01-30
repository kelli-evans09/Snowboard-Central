using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SnowboardCentral.Data;
using SnowboardCentral.Models;
using SnowboardCentral.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace SnowboardCentral.Controllers
{
    public class ResortsController : Controller
    {
        // Private field to store user manager
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly ApplicationDbContext _context;

        public ResortsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Resorts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Resorts.ToListAsync());
        }

        // GET: Resorts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resort = await _context.Resorts.Include(r => r.ResortReviews).ThenInclude(r => r.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (resort == null)
            {
                return NotFound();
            }

            return View(resort);
        }

        // GET: Resorts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Resorts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Address,PhoneNumber,WeekdayHours,WeekendHours,Description,Lodging,RentEquipment,Url,UrlImage,DailyCost")] Resort resort)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resort);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(resort);
        }

        // GET: Resorts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resort = await _context.Resorts.FindAsync(id);
            if (resort == null)
            {
                return NotFound();
            }
            return View(resort);
        }

        // POST: Resorts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address,PhoneNumber,WeekdayHours,WeekendHours,Description,Lodging,RentEquipment,Url,UrlImage,DailyCost")] Resort resort)
        {
            if (id != resort.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resort);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResortExists(resort.Id))
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
            return View(resort);
        }

        // GET: Resorts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resort = await _context.Resorts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (resort == null)
            {
                return NotFound();
            }

            return View(resort);
        }

        // POST: Resorts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resort = await _context.Resorts.FindAsync(id);
            _context.Resorts.Remove(resort);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResortExists(int id)
        {
            return _context.Resorts.Any(e => e.Id == id);
        }
    }
}
