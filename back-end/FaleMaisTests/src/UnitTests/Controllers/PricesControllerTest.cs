using System;
using FaleMaisAPI.Controllers;
using FaleMaisServices.Services.Interfaces;
using FaleMaisServices.ViewModels;
using FaleMaisTests.Bogus.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace FaleMaisTests.UnitTests.Controllers {
  public class PricesControllerTest {
    private readonly Mock<IPriceServices> priceServices;
    private readonly PricesController pricesController;

    public PricesControllerTest() {
      priceServices = new Mock<IPriceServices>();
      pricesController = new PricesController();
    }

    [Fact]
    public void Should_Return_201_Status_Code_If_Call_Price_Created() {
      var data = PriceViewModelFaker.GeneratePriceViewModel();

      var priceViewModel = data;
      data.Id = Guid.NewGuid().ToString();

      priceServices.Setup(x => x.CreatePrice(data)).Returns(priceViewModel);

      var response = pricesController.Create(priceServices.Object, data);

      var actionResult = Assert.IsType<CreatedResult>(response.Result);
      var actionValue = Assert.IsType<PriceViewModel>(actionResult.Value);

      Assert.NotNull(actionResult);
      Assert.Equal(StatusCodes.Status201Created, actionResult.StatusCode);
      Assert.True(Guid.TryParse(actionValue.Id, out Guid _));
    }

    [Fact]
    public void Should_Return_400_Status_Code_If_Invalid_ViewModel() {
      var data = new PriceViewModel();

      var response = pricesController.Create(priceServices.Object, data);

      var actionResult = Assert.IsType<BadRequestObjectResult>(response.Result);

      Assert.NotNull(actionResult);
      Assert.Equal(StatusCodes.Status400BadRequest, actionResult.StatusCode);
    }
  }
}
