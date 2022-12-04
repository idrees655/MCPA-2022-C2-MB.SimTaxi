using Microsoft.AspNetCore.Mvc.Rendering;

namespace MB.SimTaxi.Mvc.Models.Bookings
{
    public class BookingViewModel
    {
        public int Id { get; set; }
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
        public DateTime PickupTime { get; set; }
        public double Price { get; set; }
        public bool IsPaid { get; set; }

        public string DriverFullName { get; set; }
        public string CarPlateNumber { get; set; }


        public SelectList SelectListDrivers { get; set; }
        public int DriverId { get; set; }

        public SelectList SelectListCars { get; set; }
        public int CarId { get; set; }
        
        
        public MultiSelectList MultiSelectPassengers { get; set; }
        public List<int> PassengerIds { get; set; }
    }
}
