using System.Runtime;

namespace MB.SimTaxi.Entities
{
    public class Booking
    {
        public Booking()
        {
            Passengers = new List<Passenger>();
        }

        public int Id { get; set; }
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
        public DateTime PickupTime { get; set; }
        public double Price { get; set; }
        public bool IsPaid { get; set; }


        public int? DriverId { get; set; }
        public Driver Driver { get; set; }


        public int? CarId { get; set; }
        public Car Car { get; set; }

        public List<Passenger> Passengers { get; set; }
    }
}
