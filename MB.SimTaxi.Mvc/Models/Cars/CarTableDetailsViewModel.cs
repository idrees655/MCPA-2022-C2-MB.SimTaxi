using System.ComponentModel.DataAnnotations;

namespace MB.SimTaxi.Mvc.Models.Cars
{
    public class CarTableDetailsViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Plate Number")]
        public string PlateNumber { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        [Display(Name = "First Name")]
        public string DriverFirstName { get; set; }

        [Display(Name = "Last Name")]
        public string DriverLastName { get; set; }

        public int DriverId { get; set; }
    }
}
