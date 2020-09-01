using AutoMapper;
using FaleMaisDomain.Entities;
using FaleMaisServices.ViewModels;

namespace FaleMaisAPI.Configurations {
  public class AutoMapperConfiguration : Profile {
    public AutoMapperConfiguration() {
      CreateMap<CityViewModel, City>().ReverseMap();
      CreateMap<PriceViewModel, Price>().ReverseMap();
    }
  }
}
