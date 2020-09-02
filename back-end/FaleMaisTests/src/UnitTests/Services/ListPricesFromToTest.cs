using System;
using System.Collections.Generic;
using System.Linq;
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
  public class ListPricesFromToTest {
    private readonly Mock<IPricesRepository> pricesRepository;
    private readonly Mock<IMapper> mapper;
    private readonly IPriceServices priceServices;

    public ListPricesFromToTest() {
      pricesRepository = new Mock<IPricesRepository>();
      mapper = new Mock<IMapper>();

      priceServices = new PriceServices(pricesRepository.Object, mapper.Object);
    }

    [Fact]
    public void Should_Return_A_Single_Price() {
      var cityToCityPrice = PriceFaker.GeneratePrice();
      IEnumerable<Price> prices = new List<Price>() { cityToCityPrice };

      var priceViewModel = PriceViewModelFaker.GeneratePriceViewModel(cityToCityPrice);
      IEnumerable<PriceViewModel> pricesViewModel = new List<PriceViewModel>() { priceViewModel };

      var fromAreaCode = cityToCityPrice.FromAreaCode;
      var toAreaCode = cityToCityPrice.ToAreaCode;

      pricesRepository.Setup(x => x.FindByFromToAreaCode(fromAreaCode, toAreaCode))
        .Returns(cityToCityPrice);
      mapper.Setup(x => x.Map<IEnumerable<PriceViewModel>>(prices)).Returns(pricesViewModel);

      var response = priceServices.ListPricesFromTo(fromAreaCode, toAreaCode);
      var list = response.ToList();

      Assert.NotNull(response);
      Assert.IsType<List<PriceViewModel>>(response);
      Assert.Equal(1, list.Count);
    }

    [Fact]
    public void Should_Return_All_The_Prices_From_One_City_To_All_Related() {
      var rnd = new Random();
      var quantity = rnd.Next(2, 11);

      IEnumerable<Price> prices = PriceFaker.GeneratePrices(61, quantity);

      IEnumerable<PriceViewModel> priceViewModels =
        PriceViewModelFaker.GeneratePriceViewModels(61, prices);

      pricesRepository.Setup(x => x.FindByFromToAreaCodeWithCities(61))
        .Returns(prices);
      mapper.Setup(x => x.Map<IEnumerable<PriceViewModel>>(prices))
        .Returns(priceViewModels);

      var response = priceServices.ListPricesFromTo(61);

      Assert.NotNull(response);
      Assert.IsType<List<PriceViewModel>>(response);
      Assert.Equal(quantity, response.ToList().Count);
    }
  }
}
