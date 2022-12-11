using MB.SimTaxi.Utils.Enums;
using System.ComponentModel.DataAnnotations;

namespace MB.SimTaxi.Mvc.Models.Passengers
{
    public class PassengerInfoViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }

        public Gender Gender { get; set; }
    }
}
