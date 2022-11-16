using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MB.SimTaxi.Entities;
using MB.SimTaxi.Mvc.Data;

namespace MB.SimTaxi.Mvc.Controllers
{
    public class PassengersController : Controller
    {
        #region Data and Constructors

        private readonly ApplicationDbContext _context;

        public PassengersController(ApplicationDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Actions

        public async Task<IActionResult> Index()
        {
            List<Passenger> passengers = await _context.Passengers.ToListAsync();
            return View(passengers);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passenger = await _context
                                        .Passengers
                                        .FirstOrDefaultAsync(m => m.Id == id);

            if (passenger == null)
            {
                return NotFound();
            }

            return View(passenger);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Passenger passenger)
        {
            if (ModelState.IsValid)
            {
                _context.Add(passenger);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(passenger);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passenger = await _context.Passengers.FindAsync(id);

            if (passenger == null)
            {
                return NotFound();
            }

            return View(passenger);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Passenger passenger)
        {
            if (id != passenger.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                _context.Update(passenger);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(passenger);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passenger = await _context
                                        .Passengers
                                        .FirstOrDefaultAsync(m => m.Id == id);

            if (passenger == null)
            {
                return NotFound();
            }

            return View(passenger);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var passenger = await _context.Passengers.FindAsync(id);

            if (passenger != null)
            {
                _context.Passengers.Remove(passenger);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Private Methods

        private bool PassengerExists(int id)
        {
            return _context.Passengers.Any(e => e.Id == id);
        } 

        #endregion
    }
}
