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
    public class UpdatesController : Controller
    {
        private readonly RailwayContext _context;

        public UpdatesController(RailwayContext context)
        {
            _context = context;
        }

        // GET: Updates
        [Authorize]
        public async Task<IActionResult> Index()
        {
              return _context.Updates != null ? 
                          View(await _context.Updates.ToListAsync()) :
                          Problem("Entity set 'RailwayContext.Updates'  is null.");
        }

        // GET: Updates/Details/5
       
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Updates == null)
            {
                return NotFound();
            }

            var updates = await _context.Updates
                .FirstOrDefaultAsync(m => m.UpdatesID == id);
            if (updates == null)
            {
                return NotFound();
            }

            return View(updates);
        }

        // GET: Updates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Updates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UpdatesID,Time_Of_Arrival,Delay,Time_Of_Departutre,Platform_No,Login_ID,Station_Name")] Updates updates)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(updates);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(updates);
        }

        // GET: Updates/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Updates == null)
            {
                return NotFound();
            }

            var updates = await _context.Updates.FindAsync(id);
            if (updates == null)
            {
                return NotFound();
            }
            return View(updates);
        }

        // POST: Updates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UpdatesID,Time_Of_Arrival,Delay,Time_Of_Departutre,Platform_No,Login_ID,Station_Name")] Updates updates)
        {
            if (id != updates.UpdatesID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(updates);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UpdatesExists(updates.UpdatesID))
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
            return View(updates);
        }

        // GET: Updates/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Updates == null)
            {
                return NotFound();
            }

            var updates = await _context.Updates
                .FirstOrDefaultAsync(m => m.UpdatesID == id);
            if (updates == null)
            {
                return NotFound();
            }

            return View(updates);
        }

        // POST: Updates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Updates == null)
            {
                return Problem("Entity set 'RailwayContext.Updates'  is null.");
            }
            var updates = await _context.Updates.FindAsync(id);
            if (updates != null)
            {
                _context.Updates.Remove(updates);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UpdatesExists(string id)
        {
          return (_context.Updates?.Any(e => e.UpdatesID == id)).GetValueOrDefault();
        }
    }
}
