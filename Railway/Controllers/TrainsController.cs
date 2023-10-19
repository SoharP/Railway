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
    public class TrainsController : Controller
    {
        private readonly RailwayContext _context;

        public TrainsController(RailwayContext context)
        {
            _context = context;
        }

        // GET: Trains
        [Authorize]
        public async Task<IActionResult> Index()
        {
              return _context.Train != null ? 
                          View(await _context.Train.ToListAsync()) :
                          Problem("Entity set 'RailwayContext.Train'  is null.");
        }

        // GET: Trains/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Train == null)
            {
                return NotFound();
            }

            var train = await _context.Train
                .FirstOrDefaultAsync(m => m.TrainID == id);
            if (train == null)
            {
                return NotFound();
            }

            return View(train);
        }

        // GET: Trains/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trains/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrainID,Type,NumberofCarriages,MaxSpeed,MaxCapacity")] Train train)
        {
            if (ModelState.IsValid)
            {
                _context.Add(train);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(train);
        }

        // GET: Trains/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Train == null)
            {
                return NotFound();
            }

            var train = await _context.Train.FindAsync(id);
            if (train == null)
            {
                return NotFound();
            }
            return View(train);
        }

        // POST: Trains/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TrainID,Type,NumberofCarriages,MaxSpeed,MaxCapacity")] Train train)
        {
            if (id != train.TrainID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(train);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrainExists(train.TrainID))
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
            return View(train);
        }

        // GET: Trains/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Train == null)
            {
                return NotFound();
            }

            var train = await _context.Train
                .FirstOrDefaultAsync(m => m.TrainID == id);
            if (train == null)
            {
                return NotFound();
            }

            return View(train);
        }

        // POST: Trains/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Train == null)
            {
                return Problem("Entity set 'RailwayContext.Train'  is null.");
            }
            var train = await _context.Train.FindAsync(id);
            if (train != null)
            {
                _context.Train.Remove(train);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrainExists(int id)
        {
          return (_context.Train?.Any(e => e.TrainID == id)).GetValueOrDefault();
        }
    }
}
