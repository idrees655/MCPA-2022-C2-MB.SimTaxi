using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace MB.SimTaxi.Mvc.Models.Bookings
{
    public class BookingViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "From Address")]
        public string FromAddress { get; set; }


        [Required]
        [Display(Name = "To Address")]
        public string ToAddress { get; set; }


        [Required]
        [Display(Name = "Pickup Time")]
        public DateTime PickupTime { get; set; }

        [Required]
        public double Price { get; set; }

        [Display(Name = "Paid")]
        public bool IsPaid { get; set; }


        [Required]
        public int DriverId { get; set; }

        [Required]
        public int CarId { get; set; }

        [Required]
        public List<int> PassengerIds { get; set; }



        [ValidateNever]
        public SelectList SelectListDrivers { get; set; }
        [ValidateNever]
        public SelectList SelectListCars { get; set; }
        [ValidateNever]
        public MultiSelectList MultiSelectPassengers { get; set; }
    }
}
