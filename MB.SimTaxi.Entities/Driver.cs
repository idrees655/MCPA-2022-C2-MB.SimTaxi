namespace MB.SimTaxi.Entities
{
    public class Driver
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<Car> Cars { get; set; }

        public List<Booking> Bookings { get; set; }
    }
}
