using System;
using AutoMapper;
using FaleMaisDomain.Entities;
using FaleMaisPersistence.Repositories.Interfaces;
using FaleMaisServices.Exceptions;
using FaleMaisServices.Services;
using FaleMaisServices.Services.Interfaces;
using FaleMaisServices.ViewModels;
using FaleMaisTests.Bogus.Entities;
using FaleMaisTests.Bogus.ViewModels;
using Moq;
using Xunit;

namespace FaleMaisTests.UnitTests.Services {
  public class CreatePriceServiceTest {
    private readonly Mock<IPricesRepository> pricesRepository;
    private readonly Mock<IMapper> mapper;
    private readonly IPriceServices priceServices;

    public CreatePriceServiceTest() {
      pricesRepository = new Mock<IPricesRepository>();
      mapper = new Mock<IMapper>();

      priceServices = new PriceServices(pricesRepository.Object, mapper.Object);
    }

    [Fact]
    public void Should_Create_Price_For_Call_From_City_To_City() {
      var data = PriceViewModelFaker.GeneratePriceViewModel();

      var newPrice = new Price {
        FromAreaCode = data.FromAreaCode,
        ToAreaCode = data.ToAreaCode,
        PricePerMinute = data.PricePerMinute,
      };

      var price = PriceFaker.GeneratePrice(data);

      var priceViewModel = data;
      priceViewModel.Id = price.Id;

      pricesRepository.Setup(
        x => x.FindByFromToAreaCode(data.FromAreaCode, data.ToAreaCode)
      ).Returns((Price)null);
      mapper.Setup(x => x.Map<Price>(data)).Returns(newPrice);
      pricesRepository.Setup(x => x.Create(newPrice)).Returns(price);
      mapper.Setup(x => x.Map<PriceViewModel>(price)).Returns(priceViewModel);

      var response = priceServices.CreatePrice(data);

      Assert.NotNull(response);
      Assert.IsType<PriceViewModel>(response);
      Assert.True(Guid.TryParse(response.Id, out Guid _));
    }

    [Fact]
    public void Should_Not_Create_Price_If_Call_From_City_To_City_Not_Unique() {
      var data = PriceViewModelFaker.GeneratePriceViewModel();
      var price = PriceFaker.GeneratePrice(data);

      pricesRepository.Setup(
        x => x.FindByFromToAreaCode(data.FromAreaCode, data.ToAreaCode)
      ).Returns(price);

      Assert.Throws<FaleMaisException>(() => priceServices.CreatePrice(data));
    }
  }
}
