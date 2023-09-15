using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdvancedTopicsCGroupAssignment1.Data;
using AdvancedTopicsCGroupAssignment1.Models;

namespace AdvancedTopicsCGroupAssignment1.Controllers
{
    public class AddressesController : Controller
    {
        private readonly GroupAssignmentDbContext _context;

        public AddressesController(GroupAssignmentDbContext context)
        {
            _context = context;
        }

        // GET: Addresses
        public async Task<IActionResult> Index()
        {
            var groupAssignmentDbContext = _context.Addresss.Include(a => a.Business);
            return View(await groupAssignmentDbContext.ToListAsync());
        }

        // GET: Addresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Addresss == null)
            {
                return NotFound();
            }

            var address = await _context.Addresss
                .Include(a => a.Business)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        // GET: Addresses/Create
        public IActionResult Create()
        {
            ViewData["BusinessId"] = new SelectList(_context.Businesss, "Id", "EmailAddress");
            return View();
        }

        // POST: Addresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StreetName,StreetNumber,UnitNumber,PostalCode,BusinessId")] Address address)
        {
            if (ModelState.IsValid)
            {
                _context.Add(address);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BusinessId"] = new SelectList(_context.Businesss, "Id", "EmailAddress", address.BusinessId);
            return View(address);
        }

        // GET: Addresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Addresss == null)
            {
                return NotFound();
            }

            var address = await _context.Addresss.FindAsync(id);
            if (address == null)
            {
                return NotFound();
            }
            ViewData["BusinessId"] = new SelectList(_context.Businesss, "Id", "EmailAddress", address.BusinessId);
            return View(address);
        }

        // POST: Addresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StreetName,StreetNumber,UnitNumber,PostalCode,BusinessId")] Address address)
        {
            if (id != address.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(address);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddressExists(address.Id))
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
            ViewData["BusinessId"] = new SelectList(_context.Businesss, "Id", "EmailAddress", address.BusinessId);
            return View(address);
        }

        // GET: Addresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Addresss == null)
            {
                return NotFound();
            }

            var address = await _context.Addresss
                .Include(a => a.Business)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        // POST: Addresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Addresss == null)
            {
                return Problem("Entity set 'GroupAssignmentDbContext.Addresss'  is null.");
            }
            var address = await _context.Addresss.FindAsync(id);
            if (address != null)
            {
                _context.Addresss.Remove(address);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddressExists(int id)
        {
          return (_context.Addresss?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
