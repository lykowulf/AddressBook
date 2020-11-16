using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AddressBook.Data;
using AddressBook.Models;

namespace AddressBook.Controllers
{
    public class AddressPersonsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AddressPersonsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AddressPersons
        public async Task<IActionResult> Index()
        {
            return View(await _context.AddressPerson.ToListAsync());
        }

        // GET: AddressPersons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addressPerson = await _context.AddressPerson
                .FirstOrDefaultAsync(m => m.Id == id);
            if (addressPerson == null)
            {
                return NotFound();
            }

            return View(addressPerson);
        }

        // GET: AddressPersons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AddressPersons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,ImagePath,ImageData,Email,AddressOne,AddressTwo,City,State,ZipCode,PhoneNumber,Created")] AddressPerson addressPerson)
        {
            if (ModelState.IsValid)
            {
                addressPerson.Created = DateTimeOffset.Now;
                _context.Add(addressPerson);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(addressPerson);
        }

        // GET: AddressPersons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addressPerson = await _context.AddressPerson.FindAsync(id);
            if (addressPerson == null)
            {
                return NotFound();
            }
            return View(addressPerson);
        }

        // POST: AddressPersons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,ImagePath,ImageData,Email,AddressOne,AddressTwo,City,State,ZipCode,PhoneNumber,Created")] AddressPerson addressPerson)
        {
            if (id != addressPerson.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(addressPerson);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddressPersonExists(addressPerson.Id))
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
            return View(addressPerson);
        }

        // GET: AddressPersons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addressPerson = await _context.AddressPerson
                .FirstOrDefaultAsync(m => m.Id == id);
            if (addressPerson == null)
            {
                return NotFound();
            }

            return View(addressPerson);
        }

        // POST: AddressPersons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var addressPerson = await _context.AddressPerson.FindAsync(id);
            _context.AddressPerson.Remove(addressPerson);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddressPersonExists(int id)
        {
            return _context.AddressPerson.Any(e => e.Id == id);
        }
    }
}
