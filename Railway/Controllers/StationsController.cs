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
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {

            ViewData["NameSortParam"] = String.IsNullOrEmpty(sortOrder) ? "nameDesc" : "";
            ViewData["DateSortParam"] = sortOrder == "date" ? "dateDesc" : "date";
            ViewData["CurrentFilter"] = searchString;

            var stations = from s in _context.Station select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                stations = stations.Where(s =>  s.Address.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "nameDesc":
                    stations = stations.OrderByDescending(s => s.Name);
                    break;
                case "name":
                    stations = stations.OrderBy(s => s.Address);
                    break;
                case "date_Desc":
                    stations = stations.OrderByDescending(s => s.Address);
                    break;
                default:
                    stations = stations.OrderBy(s => s.Name);
                    break;
            }

            var RailwayDBContext = _context.Station.Include(p => p.Address).Include(p => p.Suburb).Include(p => p.Name);
            return View(await stations.AsNoTracking().ToListAsync());
        }

        // GET: Stations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var station = await _context.Station
                .Include(s => s.City)
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
            ViewData["CityID"] = new SelectList(_context.Set<City>(), "CityID", "CityID");
            return View();
        }

        // POST: Stations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StationID,Name,Address,Suburb,CityID")] Station station)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(station);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityID"] = new SelectList(_context.Set<City>(), "CityID", "CityID", station.CityID);
            return View(station);
        }

        // GET: Stations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var station = await _context.Station.FindAsync(id);
            if (station == null)
            {
                return NotFound();
            }
            ViewData["CityID"] = new SelectList(_context.Set<City>(), "CityID", "CityID", station.CityID);
            return View(station);
        }

        // POST: Stations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StationID,Name,Address,Suburb,CityID")] Station station)
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
            ViewData["CityID"] = new SelectList(_context.Set<City>(), "CityID", "CityID", station.CityID);
            return View(station);
        }

        // GET: Stations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var station = await _context.Station
                .Include(s => s.City)
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
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var station = await _context.Station.FindAsync(id);
            if (station != null)
            {
                _context.Station.Remove(station);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StationExists(int id)
        {
            return _context.Station.Any(e => e.StationID == id);
        }
    }
}
