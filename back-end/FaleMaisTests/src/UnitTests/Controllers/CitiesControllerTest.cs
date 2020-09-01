using FaleMaisAPI.Controllers;
using FaleMaisServices.Services.Interfaces;
using FaleMaisServices.ViewModels;
using FaleMaisTests.Bogus.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace FaleMaisTests.UnitTests.Controllers {
  public class CitiesControllerTest {
    private readonly Mock<ICityServices> cityServices;
    private readonly CitiesController citiesController;

    public CitiesControllerTest() {
      cityServices = new Mock<ICityServices>();
      citiesController = new CitiesController();
    }

    [Fact]
    public void Should_Return_201_Status_Code_If_City_Created() {
      var data = CityViewModelFaker.GenerateCityViewModel();

      cityServices.Setup(x => x.CreateCity(data)).Returns(data);

      var response = citiesController.Create(cityServices.Object, data);

      var actionResult = Assert.IsType<CreatedResult>(response.Result);
      var actionValue = Assert.IsType<CityViewModel>(actionResult.Value);

      Assert.NotNull(actionResult);
      Assert.Equal(StatusCodes.Status201Created, actionResult.StatusCode);
    }

    [Fact]
    public void Should_Return_400_Status_Code_If_Invalid_ViewModel() {
      var data = new CityViewModel();

      var response = citiesController.Create(cityServices.Object, data);

      var actionResult = Assert.IsType<BadRequestObjectResult>(response.Result);

      Assert.NotNull(actionResult);
      Assert.Equal(StatusCodes.Status400BadRequest, actionResult.StatusCode);
    }
  }
}
