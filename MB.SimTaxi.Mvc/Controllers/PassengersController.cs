using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MB.SimTaxi.Entities;
using MB.SimTaxi.Mvc.Data;
using AutoMapper;
using MB.SimTaxi.Mvc.Models.Passengers;

namespace MB.SimTaxi.Mvc.Controllers
{
    public class PassengersController : Controller
    {
        #region Data and Constructors

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PassengersController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #endregion

        #region Actions

        public async Task<IActionResult> Index()
        {
            var passengers = await _context.Passengers.ToListAsync();

            var passengerVMs = _mapper.Map<List<PassengerViewModel>>(passengers);

            return View(passengerVMs);
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

            var passengerVM = _mapper.Map<PassengerViewModel>(passenger);

            return View(passengerVM);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PassengerViewModel passengerVM)
        {
            if (ModelState.IsValid)
            {
                var passenger = _mapper.Map<Passenger>(passengerVM);

                _context.Add(passenger);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(passengerVM);
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

            var passengerVM = _mapper.Map<PassengerViewModel>(passenger);

            return View(passengerVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PassengerViewModel passengerVM)
        {
            if (id != passengerVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var passenger = _mapper.Map<Passenger>(passengerVM);

                _context.Update(passenger);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(passengerVM);
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
