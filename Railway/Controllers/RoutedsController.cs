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
    public class RoutedsController : Controller
    {
        private readonly RailwayContext _context;

        public RoutedsController(RailwayContext context)
        {
            _context = context;
        }

        // GET: Routeds
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Routed.ToListAsync());
        }

        // GET: Routeds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var routed = await _context.Routed
                .FirstOrDefaultAsync(m => m.RoutedID == id);
            if (routed == null)
            {
                return NotFound();
            }

            return View(routed);
        }

        // GET: Routeds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Routeds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoutedID,Time_Of_Arrival,Time_Of_Departure")] Routed routed)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(routed);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(routed);
        }

        // GET: Routeds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var routed = await _context.Routed.FindAsync(id);
            if (routed == null)
            {
                return NotFound();
            }
            return View(routed);
        }

        // POST: Routeds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoutedID,Time_Of_Arrival,Time_Of_Departure")] Routed routed)
        {
            if (id != routed.RoutedID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(routed);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoutedExists(routed.RoutedID))
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
            return View(routed);
        }

        // GET: Routeds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var routed = await _context.Routed
                .FirstOrDefaultAsync(m => m.RoutedID == id);
            if (routed == null)
            {
                return NotFound();
            }

            return View(routed);
        }

        // POST: Routeds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var routed = await _context.Routed.FindAsync(id);
            if (routed != null)
            {
                _context.Routed.Remove(routed);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoutedExists(int id)
        {
            return _context.Routed.Any(e => e.RoutedID == id);
        }
    }
}
