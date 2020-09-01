using AutoMapper;
using FaleMaisDomain.Entities;
using FaleMaisPersistence.Repositories.Interfaces;
using FaleMaisServices.Exceptions;
using FaleMaisServices.Services.Interfaces;
using FaleMaisServices.ViewModels;

namespace FaleMaisServices.Services {
  public class CityServices : ICityServices {
    private readonly ICitiesRepository citiesRepository;
    private readonly IMapper mapper;

    public CityServices(ICitiesRepository citiesRepository, IMapper mapper) {
      this.citiesRepository = citiesRepository;
      this.mapper = mapper;
    }

    public CityViewModel CreateCity(CityViewModel data) {
      var city = citiesRepository.FindByAreaCode(data.AreaCode);

      if (city != null)
        throw new FaleMaisException("City must have unique Area Code", 400);

      city = mapper.Map<City>(data);
      citiesRepository.Create(city);

      return data;
    }
  }
}
