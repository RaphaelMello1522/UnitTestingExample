using Microsoft.AspNetCore.Mvc;
using UnitTestingExample.Models;
using UnitTestingExample.Repository.IRepository;

namespace UnitTestingExample.Controllers
{
    public class PersonController : Controller
    {
        private IPersonRepository personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }

        //// GET: Person
        //public async Task<IActionResult> Index()
        //{
        //    return _context.Persons != null ?
        //                View(await _context.Persons.ToListAsync()) :
        //                Problem("Entity set 'ApplicationDbContext.Persons'  is null.");
        //}

        //// GET: Person/Details/5
        //public async Task<IActionResult> Details(Guid? id)
        //{
        //    if (id == null || _context.Persons == null)
        //    {
        //        return NotFound();
        //    }

        //    var person = await _context.Persons
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (person == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(person);
        //}

        // GET: Person/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Person person)
        {
            if (ModelState.IsValid)
            {
                person.Id = Guid.NewGuid();
                await personRepository.AddPersonAsync(person);
            }
            return View(person);
        }

        // GET: Person/Edit/5
        //public async Task<IActionResult> Edit(Guid? id)
        //{
        //    if (id == null || _context.Persons == null)
        //    {
        //        return NotFound();
        //    }

        //    var person = await _context.Persons.FindAsync(id);
        //    if (person == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(person);
        //}

        //// POST: Person/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Age")] Person person)
        //{
        //    if (id != person.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(person);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!PersonExists(person.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(person);
        //}

        //// GET: Person/Delete/5
        //public async Task<IActionResult> Delete(Guid? id)
        //{
        //    if (id == null || _context.Persons == null)
        //    {
        //        return NotFound();
        //    }

        //    var person = await _context.Persons
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (person == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(person);
        //}

        //// POST: Person/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(Guid id)
        //{
        //    if (_context.Persons == null)
        //    {
        //        return Problem("Entity set 'ApplicationDbContext.Persons'  is null.");
        //    }
        //    var person = await _context.Persons.FindAsync(id);
        //    if (person != null)
        //    {
        //        _context.Persons.Remove(person);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool PersonExists(Guid id)
        //{
        //    return (_context.Persons?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
