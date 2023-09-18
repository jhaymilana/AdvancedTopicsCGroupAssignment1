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
    public class PersonController : Controller
    {
        private readonly GroupAssignmentDbContext _context;

        public PersonController(GroupAssignmentDbContext context)
        {
            _context = context;
        }

        // GET: Person
        public async Task<IActionResult> Index()
        {
              return _context.Persons != null ? 
                          View(await _context.Persons.ToListAsync()) :
                          Problem("Entity set 'GroupAssignmentDbContext.Persons'  is null.");
        }

        // GET: Person/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Persons == null)
            {
                return NotFound();
            }

            var person = await _context.Persons
                .FirstOrDefaultAsync(m => m.Id == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // GET: Person/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,PhoneNumber")] Person person)
        {
            if (ModelState.IsValid)
            {
                _context.Add(person);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        // GET: Person/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Persons == null)
            {
                return NotFound();
            }

            var person = await _context.Persons.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        // POST: Person/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,PhoneNumber")] Person person)
        {
            if (id != person.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(person);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonExists(person.Id))
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
            return View(person);
        }

        // GET: Person/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Persons == null)
            {
                return NotFound();
            }

            var person = await _context.Persons
                .FirstOrDefaultAsync(m => m.Id == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // POST: Person/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Persons == null)
            {
                return Problem("Entity set 'GroupAssignmentDbContext.Persons'  is null.");
            }
            var person = await _context.Persons.FindAsync(id);
            if (person != null)
            {
                _context.Persons.Remove(person);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonExists(int id)
        {
          return (_context.Persons?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        // GET: /Person/AddAddress
        public async Task<IActionResult> AddAddress(int? id)
        {
            if (id == null || _context.Persons == null)
            {
                return NotFound();
            }

            Person? person = await _context.Persons.FirstOrDefaultAsync(m => m.Id == id);
            if (person == null)
            {
                return NotFound();
            }

            List<Address> addresses = await _context.Addresss.ToListAsync();

            ViewBag.Addresss = addresses;

            PersonAddress personAddress = new PersonAddress
            {
                PersonId = person.Id
            };

            return View("AddAddress", personAddress);
        }

        // POST: /Person/AddAddress
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAddress(PersonAddress personAddress)
        {
            if (ModelState.IsValid)
            {
                _context.PersonAddresses.Add(personAddress);
                await _context.SaveChangesAsync();

                return RedirectToAction("Details", new { id = personAddress.PersonId });
            }
            ViewBag.Addresses = await _context.Addresss.ToListAsync();
            return View("AddAddress", personAddress);
        }

        // GET: /Person/AddBusiness
        public async Task<IActionResult> AddBusiness(int? id)
        {
            if (id == null || _context.Persons == null)
            {
                return NotFound();
            }

            Person? person = await _context.Persons.FirstOrDefaultAsync(m => m.Id == id);
            if (person == null)
            {
                return NotFound();
            }

            List<Business> businesses = await _context.Businesss.ToListAsync();

            ViewBag.Businesses = businesses;

            PersonBusiness personBusiness = new PersonBusiness
            {
                PersonId = person.Id
            };

            return View("AddBusiness", personBusiness);
        }

        // POST: /Person/AddBusiness
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddBusiness(PersonBusiness personBusiness)
        {
            if (ModelState.IsValid)
            {
                _context.PersonBusinesss.Add(personBusiness);
                await _context.SaveChangesAsync();

                return RedirectToAction("Details", new { id = personBusiness.PersonId });
            }
            ViewBag.Businesses = await _context.Businesss.ToListAsync();
            return View("AddBusiness", personBusiness);
        }
    }
}
