using System.ComponentModel.DataAnnotations;

namespace MB.SimTaxi.Mvc.Models.Cars
{
    public class CarCreateEditViewModel
    {
        public int Id { get; set; }

        [StringLength(16, MinimumLength = 3)]
        [Required(ErrorMessage = "الحقل مطلوب يا كبير")]
        [Display(Name = "Plate Number")]
        public string PlateNumber { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public int DriverId { get; set; }
    }
}
