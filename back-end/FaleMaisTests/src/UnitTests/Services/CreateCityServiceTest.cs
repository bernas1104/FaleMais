using System;
using AutoMapper;
using FaleMaisDomain.Entities;
using FaleMaisPersistence.Repositories.Interfaces;
using FaleMaisServices.Services;
using FaleMaisServices.Services.Interfaces;
using FaleMaisServices.ViewModels;
using FaleMaisTests.Bogus.Entities;
using FaleMaisTests.Bogus.ViewModels;
using Moq;
using Xunit;

namespace FaleMaisTests.UnitTests.Services {
  public class CreateCityServiceTest {
    private readonly Mock<ICitiesRepository> citiesRepository;
    private readonly Mock<IMapper> mapper;
    private readonly ICityServices cityServices;

    public CreateCityServiceTest() {
      citiesRepository = new Mock<ICitiesRepository>();
      mapper = new Mock<IMapper>();

      cityServices = new CityServices(citiesRepository.Object, mapper.Object);
    }

    [Fact]
    public void Should_Create_New_City() {
      var data = CityViewModelFaker.GenerateCityViewModel();

      var city = new City {
        AreaCode = data.AreaCode,
        Name = data.Name,
      };

      var newCity = CityFaker.GenerateCity(data);

      citiesRepository.Setup(x => x.FindByAreaCode(data.AreaCode))
        .Returns((City)null);
      mapper.Setup(x => x.Map<City>(data)).Returns(city);
      citiesRepository.Setup(x => x.Create(city)).Returns(newCity);

      var response = cityServices.CreateCity(data);

      Assert.NotNull(response);
      Assert.IsType<CityViewModel>(response);
    }

    [Fact]
    public void Should_Not_Create_City_If_Area_Code_Not_Unique() {
      var data = CityViewModelFaker.GenerateCityViewModel();
      var city = CityFaker.GenerateCity(data);

      citiesRepository.Setup(x => x.FindByAreaCode(data.AreaCode))
        .Returns(city);

      Assert.Throws<Exception>(() => cityServices.CreateCity(data));
    }
  }
}
