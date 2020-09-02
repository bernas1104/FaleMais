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
  public class CallsControllerTest {
    private readonly Mock<ICallServices> callServices;
    private readonly CallsController callsController;

    public CallsControllerTest() {
      callServices = new Mock<ICallServices>();
      callsController = new CallsController();
    }

    [Fact]
    public void Should_Return_200_Status_Code_If_Call_Call_Updated() {
      var data = CallViewModelFaker.GenerateCallViewModel();

      var updated = data;
      updated.PricePerMinute = data.PricePerMinute - 0.50D;

      callServices.Setup(x => x.UpdateCallPrice(data)).Returns(updated);

      var response = callsController.Update(callServices.Object, data);

      var actionResult = Assert.IsType<OkObjectResult>(response.Result);
      var actionValue = Assert.IsType<CallViewModel>(actionResult.Value);

      Assert.NotNull(actionResult);
      Assert.Equal(StatusCodes.Status200OK, actionResult.StatusCode);
    }

    [Fact]
    public void Should_Return_200_Status_Code_If_Query_Values_Valid() {
      var rnd = new Random();

      var call = CallViewModelFaker.GenerateCallViewModel();

      byte fromAreaCode = (byte)rnd.Next(1, 101);
      byte toAreaCode = (byte)rnd.Next(1, 101);

      callServices.Setup(x => x.GetCallPriceFromTo(fromAreaCode, toAreaCode))
        .Returns(call);

      var response = callsController.GetPrice(
        callServices.Object,
        fromAreaCode,
        toAreaCode
      );

      var actionResult = Assert.IsType<OkObjectResult>(response.Result);
      var actionValue = Assert.IsType<CallViewModel>(actionResult.Value);

      Assert.NotNull(actionResult);
      Assert.Equal(StatusCodes.Status200OK, actionResult.StatusCode);
    }

    [Theory]
    [InlineData(0, 1)]
    [InlineData(101, 1)]
    [InlineData(1, 0)]
    [InlineData(1, 101)]
    public void Should_Return_400_Status_Code_If_Invalid_Query_Values(
      byte fromAreaCode,
      byte toAreaCode
    ) {
      var response = callsController.GetPrice(
        callServices.Object,
        fromAreaCode,
        toAreaCode
      );

      var actionResult = Assert.IsType<BadRequestObjectResult>(response.Result);

      Assert.NotNull(actionResult);
      Assert.Equal(StatusCodes.Status400BadRequest, actionResult.StatusCode);
    }

    [Fact]
    public void Should_Return_400_Status_Code_If_Invalid_ViewModel() {
      var data = new CallViewModel();

      var response = callsController.Update(callServices.Object, data);

      var actionResult = Assert.IsType<BadRequestObjectResult>(response.Result);

      Assert.NotNull(actionResult);
      Assert.Equal(StatusCodes.Status400BadRequest, actionResult.StatusCode);
    }
  }
}
