using AutoMapper;
using MB.SimTaxi.Entities;
using MB.SimTaxi.Mvc.Models.Drivers;

namespace MB.SimTaxi.Mvc.AutoMapperProfiles
{
    public class DriverAutoMapperProfile : Profile
    {
        public DriverAutoMapperProfile()
        {
            CreateMap<Driver, DriverViewModel>().ReverseMap();
        }
    }
}
