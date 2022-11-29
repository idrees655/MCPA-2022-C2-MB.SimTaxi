using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace MB.SimTaxi.Mvc.Models.Cars
{
    public class CarCreateEditViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Plate Number")]
        public string PlateNumber { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int DriverId { get; set; }

        public SelectList SelectListDriver { get; set; }        
    }
}
