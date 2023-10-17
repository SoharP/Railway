using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Railway.Areas.Identity.Data;
using Railway.Models;

namespace Railway.Controllers
{
    public class RoutesController : Controller
    {
        private readonly RailwayContext _context;

        public RoutesController(RailwayContext context)
        {
            _context = context;
        }

        // GET: Routes
        public async Task<IActionResult> Index()
        {
              return _context.Routes != null ? 
                          View(await _context.Routes.ToListAsync()) :
                          Problem("Entity set 'RailwayContext.Routes'  is null.");
        }

        // GET: Routes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Routes == null)
            {
                return NotFound();
            }

            var routes = await _context.Routes
                .FirstOrDefaultAsync(m => m.RoutesID == id);
            if (routes == null)
            {
                return NotFound();
            }

            return View(routes);
        }

        // GET: Routes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Routes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoutesID,Price,TrainLine,LineStatus")] Routes routes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(routes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(routes);
        }

        // GET: Routes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Routes == null)
            {
                return NotFound();
            }

            var routes = await _context.Routes.FindAsync(id);
            if (routes == null)
            {
                return NotFound();
            }
            return View(routes);
        }

        // POST: Routes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoutesID,Price,TrainLine,LineStatus")] Routes routes)
        {
            if (id != routes.RoutesID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(routes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoutesExists(routes.RoutesID))
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
            return View(routes);
        }

        // GET: Routes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Routes == null)
            {
                return NotFound();
            }

            var routes = await _context.Routes
                .FirstOrDefaultAsync(m => m.RoutesID == id);
            if (routes == null)
            {
                return NotFound();
            }

            return View(routes);
        }

        // POST: Routes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Routes == null)
            {
                return Problem("Entity set 'RailwayContext.Routes'  is null.");
            }
            var routes = await _context.Routes.FindAsync(id);
            if (routes != null)
            {
                _context.Routes.Remove(routes);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoutesExists(int id)
        {
          return (_context.Routes?.Any(e => e.RoutesID == id)).GetValueOrDefault();
        }
    }
}
