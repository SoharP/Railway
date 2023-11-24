using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Railway.Areas.Identity.Data;
using Railway.Models;

namespace Railway.Controllers
{
    public class WeekdaysController : Controller
    {
        private readonly RailwayContext _context;

        public WeekdaysController(RailwayContext context)
        {
            _context = context;
        }

        // GET: Weekdays
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Weekdays.ToListAsync());
        }

        // GET: Weekdays/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weekdays = await _context.Weekdays
                .FirstOrDefaultAsync(m => m.WeekdaysID == id);
            if (weekdays == null)
            {
                return NotFound();
            }

            return View(weekdays);
        }

        // GET: Weekdays/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Weekdays/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WeekdaysID,Date")] Weekdays weekdays)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(weekdays);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(weekdays);
        }

        // GET: Weekdays/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weekdays = await _context.Weekdays.FindAsync(id);
            if (weekdays == null)
            {
                return NotFound();
            }
            return View(weekdays);
        }

        // POST: Weekdays/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WeekdaysID,Date")] Weekdays weekdays)
        {
            if (id != weekdays.WeekdaysID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(weekdays);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WeekdaysExists(weekdays.WeekdaysID))
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
            return View(weekdays);
        }

        // GET: Weekdays/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weekdays = await _context.Weekdays
                .FirstOrDefaultAsync(m => m.WeekdaysID == id);
            if (weekdays == null)
            {
                return NotFound();
            }

            return View(weekdays);
        }

        // POST: Weekdays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var weekdays = await _context.Weekdays.FindAsync(id);
            if (weekdays != null)
            {
                _context.Weekdays.Remove(weekdays);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WeekdaysExists(int id)
        {
            return _context.Weekdays.Any(e => e.WeekdaysID == id);
        }
    }
}
