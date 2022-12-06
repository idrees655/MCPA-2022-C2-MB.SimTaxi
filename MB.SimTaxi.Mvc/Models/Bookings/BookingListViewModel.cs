using System.ComponentModel.DataAnnotations;

namespace MB.SimTaxi.Mvc.Models.Bookings
{
    public class BookingListViewModel
    {
        public int Id { get; set; }


        [Display(Name = "From Address")]
        public string FromAddress { get; set; }


        [Display(Name = "To Address")]
        public string ToAddress { get; set; }


        [Display(Name = "Pickup Time")]
        public DateTime PickupTime { get; set; }
        public double Price { get; set; }

        [Display(Name = "Paid")]
        public bool IsPaid { get; set; }
    }
}
