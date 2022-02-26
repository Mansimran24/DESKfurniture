using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DESKfurniture.Data;
using DESKfurniture.Models;

namespace DESKfurniture.Controllers
{
    public class DesksController : Controller
    {
        private readonly DESKfurnitureContext _context;

        public DesksController(DESKfurnitureContext context)
        {
            _context = context;
        }

        // GET: Desks
        public async Task<IActionResult> Index(string DeskUsage, string searchstring)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> UsageQuery = from m in _context.Desk
                                            orderby m.Usage
                                            select m.Usage;

            var Desk = from m in _context.Desk
                         select m;

            if (!String.IsNullOrEmpty(searchstring))
            {
                Desk = Desk.Where(s => s.Shop.Contains(searchstring));
            }
            if(!string.IsNullOrEmpty(DeskUsage))
            {
                Desk = Desk.Where(x => x.Usage == DeskUsage);
            }
            var DeskUsageVM = new DeskUsageViewModel
            {
                Usage = new SelectList(await UsageQuery.Distinct().ToListAsync()),
                Desk = await Desk.ToListAsync()
            };
            return View(DeskUsageVM);
        }

        // GET: Desks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var desk = await _context.Desk
                .FirstOrDefaultAsync(m => m.Id == id);
            if (desk == null)
            {
                return NotFound();
            }

            return View(desk);
        }

        // GET: Desks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Desks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Shop,Usage,Material,Price")] Desk desk)
        {
            if (ModelState.IsValid)
            {
                _context.Add(desk);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(desk);
        }

        // GET: Desks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var desk = await _context.Desk.FindAsync(id);
            if (desk == null)
            {
                return NotFound();
            }
            return View(desk);
        }

        // POST: Desks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Shop,Usage,Material,Price")] Desk desk)
        {
            if (id != desk.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(desk);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeskExists(desk.Id))
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
            return View(desk);
        }

        // GET: Desks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var desk = await _context.Desk
                .FirstOrDefaultAsync(m => m.Id == id);
            if (desk == null)
            {
                return NotFound();
            }

            return View(desk);
        }

        // POST: Desks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var desk = await _context.Desk.FindAsync(id);
            _context.Desk.Remove(desk);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        

        private bool DeskExists(int id)
        {
            return _context.Desk.Any(e => e.Id == id);
        }
    }
}
