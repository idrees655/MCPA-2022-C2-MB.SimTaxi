using AutoMapper;
using MB.SimTaxi.Entities;
using MB.SimTaxi.Mvc.Models.Cars;

namespace MB.SimTaxi.Mvc.AutoMapperProfiles
{
    public class CarAutoMapperProfile : Profile
    {
        public CarAutoMapperProfile()
        {
            //CreateMap<Car, CarViewModel>();
            //CreateMap<CarViewModel, Car>();
            // OR
            //CreateMap<Car, CarViewModel>().ReverseMap();

            CreateMap<Car, CarTableDetailsViewModel>();
            CreateMap<CarCreateEditViewModel, Car>().ReverseMap();
        }
    }
}
