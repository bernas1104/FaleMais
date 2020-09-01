using Bogus;
using FaleMaisServices.ViewModels;

namespace FaleMaisTests.Bogus.ViewModels {
  public static class CityViewModelFaker {
    public static CityViewModel GenerateCityViewModel() {
      var cityViewModel = new Faker<CityViewModel>()
        .RuleFor(x => x.AreaCode, (f) => f.Random.Byte(1, 100))
        .RuleFor(x => x.Name, (f) => f.Address.City());

      return cityViewModel.Generate();
    }
  }
}
