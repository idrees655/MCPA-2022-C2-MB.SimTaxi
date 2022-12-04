using System.ComponentModel.DataAnnotations.Schema;

namespace MB.SimTaxi.Entities
{
    public class Car
    {
        public Car()
        {
            Bookings = new List<Booking>();
        }

        public int Id { get; set; }
        public string PlateNumber { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }


        public int? DriverId { get; set; }
        public Driver Driver { get; set; }

        public List<Booking> Bookings { get; set; }

        [NotMapped]
        public string CarFullName
        {
            get
            {
                return $"{Model} - {PlateNumber}";
            }
        }
    }
}
