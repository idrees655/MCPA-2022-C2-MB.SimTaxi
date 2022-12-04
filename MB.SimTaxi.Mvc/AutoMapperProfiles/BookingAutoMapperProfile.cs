using AutoMapper;
using MB.SimTaxi.Entities;
using MB.SimTaxi.Mvc.Models.Bookings;

namespace MB.SimTaxi.Mvc.AutoMapperProfiles
{
    public class BookingAutoMapperProfile : Profile
    {
        public BookingAutoMapperProfile()
        {
            CreateMap<Booking, BookingViewModel>();
        }
    }
}
