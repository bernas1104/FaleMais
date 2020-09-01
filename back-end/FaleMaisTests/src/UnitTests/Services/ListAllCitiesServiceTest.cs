using System;
using System.Collections.Generic;
using AutoMapper;
using FaleMaisPersistence.Repositories.Interfaces;
using FaleMaisServices.Services;
using FaleMaisServices.Services.Interfaces;
using FaleMaisServices.ViewModels;
using FaleMaisTests.Bogus.Entities;
using FaleMaisTests.Bogus.ViewModels;
using Moq;
using Xunit;

namespace FaleMaisTests.UnitTests.Services {
  public class ListAllCitiesServiceTest {
    private readonly Mock<ICitiesRepository> citiesRepository;
    private readonly Mock<IMapper> mapper;
    private readonly ICityServices cityServices;

    public ListAllCitiesServiceTest() {
      citiesRepository = new Mock<ICitiesRepository>();
      mapper = new Mock<IMapper>();

      cityServices = new CityServices(citiesRepository.Object, mapper.Object);
    }

    [Fact]
    public void Should_Return_All_The_Registered_Cities() {
      var rnd = new Random();

      var cities = CityFaker.GenerateCities(rnd.Next(0, 11));

      var citiesViewModel = CityViewModelFaker.GenerateCitiesViewModel(cities);

      citiesRepository.Setup(x => x.FindAll()).Returns(cities);
      mapper.Setup(x => x.Map<IEnumerable<CityViewModel>>(cities))
        .Returns(citiesViewModel);

      var response = cityServices.ListAllCities();

      Assert.NotNull(response);
      Assert.IsType<List<CityViewModel>>(response);
    }
  }
}
