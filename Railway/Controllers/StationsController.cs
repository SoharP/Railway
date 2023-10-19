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
    public class StationsController : Controller
    {
        private readonly RailwayContext _context;

        public StationsController(RailwayContext context)
        {
            _context = context;
        }

        // GET: Stations
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var railwayContext = _context.Station.Include(s => s.Train);
            return View(await railwayContext.ToListAsync());
        }

        // GET: Stations/Details/5
        
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Station == null)
            {
                return NotFound();
            }

            var station = await _context.Station
                .Include(s => s.Train)
                .FirstOrDefaultAsync(m => m.StationID == id);
            if (station == null)
            {
                return NotFound();
            }

            return View(station);
        }

        // GET: Stations/Create
        public IActionResult Create()
        {
            ViewData["TrainID"] = new SelectList(_context.Set<Train>(), "TrainID", "TrainID");
            return View();
        }

        // POST: Stations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StationID,PlatformNo,TimeOfArrival,TimeOfDeparture,TrainID")] Station station)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(station);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TrainID"] = new SelectList(_context.Set<Train>(), "TrainID", "TrainID", station.TrainID);
            return View(station);
        }

        // GET: Stations/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Station == null)
            {
                return NotFound();
            }

            var station = await _context.Station.FindAsync(id);
            if (station == null)
            {
                return NotFound();
            }
            ViewData["TrainID"] = new SelectList(_context.Set<Train>(), "TrainID", "TrainID", station.TrainID);
            return View(station);
        }

        // POST: Stations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("StationID,PlatformNo,TimeOfArrival,TimeOfDeparture,TrainID")] Station station)
        {
            if (id != station.StationID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(station);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StationExists(station.StationID))
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
            ViewData["TrainID"] = new SelectList(_context.Set<Train>(), "TrainID", "TrainID", station.TrainID);
            return View(station);
        }

        // GET: Stations/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Station == null)
            {
                return NotFound();
            }

            var station = await _context.Station
                .Include(s => s.Train)
                .FirstOrDefaultAsync(m => m.StationID == id);
            if (station == null)
            {
                return NotFound();
            }

            return View(station);
        }

        // POST: Stations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Station == null)
            {
                return Problem("Entity set 'RailwayContext.Station'  is null.");
            }
            var station = await _context.Station.FindAsync(id);
            if (station != null)
            {
                _context.Station.Remove(station);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StationExists(string id)
        {
          return (_context.Station?.Any(e => e.StationID == id)).GetValueOrDefault();
        }
    }
}
