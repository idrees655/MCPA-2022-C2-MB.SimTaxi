using AutoMapper;
using MB.SimTaxi.Entities;
using MB.SimTaxi.Mvc.Models.Passengers;

namespace MB.SimTaxi.Mvc.AutoMapperProfiles
{
    public class PassengerAutoMapperProfile : Profile
    {
        public PassengerAutoMapperProfile()
        {
            CreateMap<Passenger, PassengerViewModel>().ReverseMap();
            CreateMap<Passenger, PassengerInfoViewModel>();
        }
    }
}
