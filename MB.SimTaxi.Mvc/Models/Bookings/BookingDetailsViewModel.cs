using System.ComponentModel.DataAnnotations;

namespace MB.SimTaxi.Mvc.Models.Bookings
{
    public class BookingDetailsViewModel
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

        [Display(Name = "Driver Name")]
        public string DriverFullName { get; set; }

        [Display(Name = "Car Plate Number")]
        public string CarPlateNumber { get; set; }
    }
}
