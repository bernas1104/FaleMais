using AutoMapper;
using FaleMaisDomain.Entities;
using FaleMaisServices.ViewModels;

namespace FaleMaisAPI.Configurations {
  public class AutoMapperConfiguration : Profile {
    public AutoMapperConfiguration() {
      CreateMap<AreaCodeViewModel, AreaCode>().ReverseMap();
      CreateMap<CallViewModel, Call>().ReverseMap();
    }
  }
}
