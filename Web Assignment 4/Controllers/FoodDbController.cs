using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web_Assignment_4.Models;

namespace Web_Assignment_4.Controllers
{
    public class FoodDbController : Controller
    {
        private readonly Assignment4Context _context;

        public FoodDbController(Assignment4Context context)
        {
            _context = context;
        }

        // GET: FoodEnforcements
        public async Task<IActionResult> Index()
        {
            var assignment4Context = _context.FoodEnforcements.Include(f => f.CityNavigation);
            return View(await assignment4Context.ToListAsync());
        }

        // GET: FoodEnforcements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodEnforcement = await _context.FoodEnforcements
                .Include(f => f.CityNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (foodEnforcement == null)
            {
                return NotFound();
            }

            return View(foodEnforcement);
        }

        // GET: FoodEnforcements/Create
        public IActionResult Create()
        {
            ViewData["City"] = new SelectList(_context.Cities, "City1", "City1");
            ViewData["States"] = new SelectList(_context.States, "StateCode", "State1");
            return View();
        }

        // POST: FoodEnforcements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Country,City,Address1,Address2,ProductDescription,ReportDate,Classification,RecallNumber,EventId,PostalCode,Status,CodeInfo")] FoodEnforcement foodEnforcement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(foodEnforcement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["City"] = new SelectList(_context.Cities, "City1", "City1", foodEnforcement.City);
            return View(foodEnforcement);
        }

        // GET: FoodEnforcements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodEnforcement = await _context.FoodEnforcements.FindAsync(id);
            if (foodEnforcement == null)
            {
                return NotFound();
            }
            ViewData["City"] = new SelectList(_context.Cities, "City1", "City1", foodEnforcement.City);
            return View(foodEnforcement);
        }

        // POST: FoodEnforcements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Country,City,Address1,Address2,ProductDescription,ReportDate,Classification,RecallNumber,EventId,PostalCode,Status,CodeInfo")] FoodEnforcement foodEnforcement)
        {
            if (id != foodEnforcement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(foodEnforcement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FoodEnforcementExists(foodEnforcement.Id))
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
            ViewData["City"] = new SelectList(_context.Cities, "City1", "City1", foodEnforcement.City);
            return View(foodEnforcement);
        }

        // GET: FoodEnforcements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodEnforcement = await _context.FoodEnforcements
                .Include(f => f.CityNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (foodEnforcement == null)
            {
                return NotFound();
            }

            return View(foodEnforcement);
        }

        // POST: FoodEnforcements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var foodEnforcement = await _context.FoodEnforcements.FindAsync(id);
            _context.FoodEnforcements.Remove(foodEnforcement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FoodEnforcementExists(int id)
        {
            return _context.FoodEnforcements.Any(e => e.Id == id);
        }


        public JsonResult GetCountries(string state)
        {
            var list = _context.Cities.Where(c => c.StateCode == state).ToList();

            return Json(list);
        }
    }
}
