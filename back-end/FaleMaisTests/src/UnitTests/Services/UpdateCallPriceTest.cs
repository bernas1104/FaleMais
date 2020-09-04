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
  public class UpdateCallPriceTest {
    private readonly Mock<ICallsRepository> callsRepository;
    private readonly Mock<IMapper> mapper;
    private readonly ICallServices callServices;

    public UpdateCallPriceTest() {
      callsRepository = new Mock<ICallsRepository>();
      mapper = new Mock<IMapper>();

      callServices = new CallServices(callsRepository.Object, mapper.Object);
    }

    [Fact]
    public void Should_Be_Able_To_Update_The_Price_Of_A_Call() {
      var data = CallViewModelFaker.GenerateCallViewModel();

      var call = CallFaker.GenerateCall(data);
      call.PricePerMinute = 4.30m;

      var updatedCall = call;
      updatedCall.PricePerMinute = data.PricePerMinute;

      var updatedCallViewModel = data;
      updatedCallViewModel.PricePerMinute = updatedCall.PricePerMinute;

      callsRepository.Setup(x =>
        x.FindByFromToAreaCode(data.FromAreaCode, data.ToAreaCode)
      ).Returns(call);
      callsRepository.Setup(x => x.SaveChanges());
      mapper.Setup(x => x.Map<CallViewModel>(updatedCall))
        .Returns(updatedCallViewModel);

      var response = callServices.UpdateCallPrice(data);

      Assert.NotNull(response);
    }

    [Fact]
    public void Should_Not_Update_If_Call_Not_Exist() {
      var data = CallViewModelFaker.GenerateCallViewModel();

      callsRepository.Setup(x =>
        x.FindByFromToAreaCode(data.FromAreaCode, data.ToAreaCode)
      ).Returns((Call)null);

      Assert.Throws<FaleMaisException>(
        () => callServices.UpdateCallPrice(data)
      );
    }
  }
}
