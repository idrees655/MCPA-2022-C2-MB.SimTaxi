﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MB.SimTaxi.Entities;
using MB.SimTaxi.Mvc.Data;
using AutoMapper;
using MB.SimTaxi.Mvc.Models.Bookings;
using Microsoft.AspNetCore.Authorization;

namespace MB.SimTaxi.Mvc.Controllers
{
    [Authorize]
    public class BookingsController : Controller
    {
        #region Data and Constructors

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BookingsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #endregion

        #region Actions

        public async Task<IActionResult> Index()
        {
            var bookings = await _context.Bookings
                                    .Include(b => b.Car)
                                    .Include(b => b.Driver)
                                    .ToListAsync();

            var bookingVMs = _mapper.Map<List<BookingListViewModel>>(bookings);

            return View(bookingVMs);
        }

        public IActionResult Details(int? id)
        {
            if (id == null || _context.Bookings == null)
            {
                return NotFound();
            }

            var booking = _context.Bookings
                                    .Include(b => b.Car)
                                    .Include(b => b.Driver)
                                    .Include(b => b.Passengers)
                                    .Where(booking => booking.Id == id)
                                    .SingleOrDefault();

            if (booking == null)
            {
                return NotFound();
            }

            var bookingVM = _mapper.Map<BookingDetailsViewModel>(booking);

            return View(bookingVM);
        }

        public IActionResult Create()
        {
            var bookingVM = new BookingViewModel();

            bookingVM.SelectListDrivers = new SelectList(_context.Drivers, "Id", "FullName");
            bookingVM.SelectListCars = new SelectList(_context.Cars, "Id", "FullName");
            bookingVM.MultiSelectPassengers = new MultiSelectList(_context.Passengers, "Id", "FullName");

            return View(bookingVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookingViewModel bookingVM)
        {
            if (ModelState.IsValid)
            {
                var booking = _mapper.Map<Booking>(bookingVM);

                booking.BookedByEmail = User.Identity.Name;

                await AddPassengersToBooking(bookingVM, booking);

                _context.Add(booking);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
                //return RedirectToAction("Index","Home");
            }

            bookingVM.SelectListCars = new SelectList(_context.Cars, "Id", "FullName", bookingVM.CarId);
            bookingVM.SelectListDrivers = new SelectList(_context.Drivers, "Id", "FullName", bookingVM.DriverId);
            bookingVM.MultiSelectPassengers = new MultiSelectList(_context.Passengers, "Id", "FullName", bookingVM.PassengerIds);

            return View(bookingVM);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Bookings == null)
            {
                return NotFound();
            }

            var booking = await _context
                                    .Bookings
                                    .Include(b => b.Car)
                                    .Include(b => b.Driver)
                                    .Include(b => b.Passengers)
                                    .Where(b => b.Id == id)
                                    .SingleOrDefaultAsync();

            if (booking == null)
            {
                return NotFound();
            }

            var bookingVM = _mapper.Map<BookingViewModel>(booking);

            bookingVM.SelectListCars = new SelectList(_context.Cars, "Id", "FullName", bookingVM.CarId);
            bookingVM.SelectListDrivers = new SelectList(_context.Drivers, "Id", "FullName", bookingVM.DriverId);
            bookingVM.MultiSelectPassengers = new MultiSelectList(_context.Passengers, "Id", "FullName", bookingVM.PassengerIds);

            bookingVM.PassengerIds = booking.Passengers.Select(p => p.Id).ToList();

            return View(bookingVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BookingViewModel bookingVM)
        {
            if (id != bookingVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var booking = _mapper.Map<Booking>(bookingVM);

                    _context.Update(booking);
                    await _context.SaveChangesAsync();

                    await UpdateBookingPassengers(bookingVM.PassengerIds, bookingVM.Id);

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(bookingVM.Id))
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

            bookingVM.SelectListCars = new SelectList(_context.Cars, "Id", "FullName", bookingVM.CarId);
            bookingVM.SelectListDrivers = new SelectList(_context.Drivers, "Id", "FullName", bookingVM.DriverId);
            bookingVM.MultiSelectPassengers = new MultiSelectList(_context.Passengers, "Id", "FullName", bookingVM.PassengerIds);

            return View(bookingVM);
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
           return _context.Bookings.Any(booking => booking.Id == id); // 17 == 17: true
        }

        private async Task AddPassengersToBooking(BookingViewModel bookingVM, Booking booking)
        {
            // Get passengers from DB using the passengerIds (List<int>)
            var passengersFromDB = await _context
                                        .Passengers
                                        .Where(passenger => bookingVM.PassengerIds.Contains(passenger.Id)) // id: 1,2
                                        .ToListAsync(); // Thre result is: Sameer,Natasha

            // Add passengers(List<Passenger>) to booking
            booking.Passengers.AddRange(passengersFromDB);
        }

        private async Task UpdateBookingPassengers(List<int> passengerIds, int bookingId)
        {
            // Load booking including passengers
            var booking = await _context.Bookings
                                        .Include(b => b.Passengers)
                                        .Where(booking => booking.Id == bookingId)
                                        .SingleAsync();

            // Clear passengers
            booking.Passengers.Clear();

            // Get passengers from DB using the passengerIds (List<int>)
            var passengersFromDB = await _context
                                        .Passengers
                                        .Where(passenger => passengerIds.Contains(passenger.Id)) // id: 1,2
                                        .ToListAsync(); // Thre result is: Sameer,Natasha

            // Add passengers(List<Passenger>) to booking
            booking.Passengers.AddRange(passengersFromDB);
        }

        #endregion
    }
}
