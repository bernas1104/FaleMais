using System;
using System.Collections.Generic;
using FaleMaisAPI.Controllers;
using FaleMaisServices.Services.Interfaces;
using FaleMaisServices.ViewModels;
using FaleMaisTests.Bogus.Entities;
using FaleMaisTests.Bogus.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace FaleMaisTests.UnitTests.Controllers {
  public class AreaCodesControllerTest {
    private readonly Mock<IAreaCodeServices> areaCodeServices;
    private readonly AreaCodesController areaCodesController;

    public AreaCodesControllerTest() {
      areaCodeServices = new Mock<IAreaCodeServices>();
      areaCodesController = new AreaCodesController();
    }

    [Fact]
    public void Should_Return_200_Status_Code_When_Listing_All_Cities() {
      var rnd = new Random();

      var areaCodes = AreaCodeFaker.GenerateAreaCodes(rnd.Next(1, 11));

      var areaCodesViewModel = AreaCodeViewModelFaker.GenerateAreaCodesViewModel(areaCodes);

      areaCodeServices.Setup(x => x.ListAllAreaCodes()).Returns(areaCodesViewModel);

      var response = areaCodesController.Index(areaCodeServices.Object);

      var actionResult = Assert.IsType<OkObjectResult>(response.Result);
      var actionValue = Assert.IsType<List<AreaCodeViewModel>>(actionResult.Value);

      Assert.NotNull(actionResult);
      Assert.Equal(StatusCodes.Status200OK, actionResult.StatusCode);
    }
  }
}
