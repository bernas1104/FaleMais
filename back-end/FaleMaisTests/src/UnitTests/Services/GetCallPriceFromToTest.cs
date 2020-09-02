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
  public class GetCallPriceFromToTest {
    private readonly Mock<ICallsRepository> callsRepository;
    private readonly Mock<IMapper> mapper;
    private readonly ICallServices callServices;

    public GetCallPriceFromToTest() {
      callsRepository = new Mock<ICallsRepository>();
      mapper = new Mock<IMapper>();

      callServices = new CallServices(callsRepository.Object, mapper.Object);
    }

    [Fact]
    public void Should_Return_A_Call_Price() {
      var call = CallFaker.GenerateCall();

      var callViewModel = CallViewModelFaker.GenerateCallViewModel(call);

      var fromAreaCode = call.FromAreaCode;
      var toAreaCode = call.ToAreaCode;

      callsRepository.Setup(x => x.FindByFromToAreaCode(fromAreaCode, toAreaCode))
        .Returns(call);
      mapper.Setup(x => x.Map<CallViewModel>(call)).Returns(callViewModel);

      var response = callServices.GetCallPriceFromTo(fromAreaCode, toAreaCode);

      Assert.NotNull(response);
    }

    [Fact]
    public void Should_Not_Return_A_Call_Price() {
      var call = CallFaker.GenerateCall();

      var fromAreaCode = call.FromAreaCode;
      var toAreaCode = call.ToAreaCode;

      callsRepository.Setup(x => x.FindByFromToAreaCode(fromAreaCode, toAreaCode))
        .Returns((Call)null);

      Assert.Throws<FaleMaisException>(
        () => callServices.GetCallPriceFromTo(fromAreaCode, toAreaCode)
      );
    }
  }
}
