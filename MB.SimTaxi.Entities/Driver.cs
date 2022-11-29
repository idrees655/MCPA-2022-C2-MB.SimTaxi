using System.ComponentModel.DataAnnotations.Schema;

namespace MB.SimTaxi.Entities
{
    public class Driver
    {
        public Driver()
        {
            Cars = new List<Car>();
            Bookings = new List<Booking>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public List<Car> Cars { get; set; }

        public List<Booking> Bookings { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }
}
