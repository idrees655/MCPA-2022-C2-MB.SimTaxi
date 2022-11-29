using System.ComponentModel.DataAnnotations.Schema;

namespace MB.SimTaxi.Entities
{
    public class Passenger
    {
        public Passenger()
        {
            Bookings = new List<Booking>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        //public Gender Gender { get; set; }

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
