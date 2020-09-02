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
  public class ListAllAreaCodesServiceTest {
    private readonly Mock<IAreaCodesRepository> citiesRepository;
    private readonly Mock<IMapper> mapper;
    private readonly IAreaCodeServices cityServices;

    public ListAllAreaCodesServiceTest() {
      citiesRepository = new Mock<IAreaCodesRepository>();
      mapper = new Mock<IMapper>();

      cityServices = new AreaCodeServices(citiesRepository.Object, mapper.Object);
    }

    [Fact]
    public void Should_Return_All_The_Registered_AreaCodes() {
      var rnd = new Random();

      var cities = AreaCodeFaker.GenerateAreaCodes(rnd.Next(0, 11));

      var citiesViewModel = AreaCodeViewModelFaker.GenerateAreaCodesViewModel(cities);

      citiesRepository.Setup(x => x.FindAll()).Returns(cities);
      mapper.Setup(x => x.Map<IEnumerable<AreaCodeViewModel>>(cities))
        .Returns(citiesViewModel);

      var response = cityServices.ListAllAreaCodes();

      Assert.NotNull(response);
      Assert.IsType<List<AreaCodeViewModel>>(response);
    }
  }
}
