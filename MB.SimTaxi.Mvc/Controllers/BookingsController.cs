using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MB.SimTaxi.Entities;
using MB.SimTaxi.Mvc.Data;

namespace MB.SimTaxi.Mvc.Controllers
{
    public class BookingsController : Controller
    {
        #region Data and Constructors

        private readonly ApplicationDbContext _context;

        public BookingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Actions

        public async Task<IActionResult> Index()
        {
            List<Booking> bookings = _context.Bookings
                                                .Include(b => b.Car)
                                                .Include(b => b.Driver)
                                                .ToList();

            return View(bookings);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Bookings == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings
                .Include(b => b.Car)
                .Include(b => b.Driver)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        public IActionResult Create()
        {
            ViewData["Passengers"] = new MultiSelectList(_context.Passengers, "Id", "FirstName");
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Model");
            ViewData["DriverId"] = new SelectList(_context.Drivers, "Id", "FirstName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Booking booking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Model", booking.CarId);
            ViewData["DriverId"] = new SelectList(_context.Drivers, "Id", "FirstName", booking.DriverId);

            return View(booking);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Bookings == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Model", booking.CarId);
            ViewData["DriverId"] = new SelectList(_context.Drivers, "Id", "FirstName", booking.DriverId);
            return View(booking);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Booking booking)
        {
            if (id != booking.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(booking.Id))
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
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Model", booking.CarId);
            ViewData["DriverId"] = new SelectList(_context.Drivers, "Id", "FirstName", booking.DriverId);
            return View(booking);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Bookings == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings
                .Include(b => b.Car)
                .Include(b => b.Driver)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Bookings == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Bookings'  is null.");
            }
            var booking = await _context.Bookings.FindAsync(id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Private Methods

        private bool BookingExists(int id)
        {
            return _context.Bookings.Any(e => e.Id == id);
        } 
        #endregion
    }
}
