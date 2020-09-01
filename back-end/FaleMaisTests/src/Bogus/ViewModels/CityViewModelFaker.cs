using System.Collections.Generic;
using Bogus;
using FaleMaisDomain.Entities;
using FaleMaisServices.ViewModels;

namespace FaleMaisTests.Bogus.ViewModels {
  public static class CityViewModelFaker {
    public static CityViewModel GenerateCityViewModel() {
      var cityViewModel = new Faker<CityViewModel>()
        .RuleFor(x => x.AreaCode, (f) => f.Random.Byte(1, 100))
        .RuleFor(x => x.Name, (f) => f.Address.City());

      return cityViewModel.Generate();
    }

    public static IEnumerable<CityViewModel> GenerateCitiesViewModel(
      IEnumerable<City> cities
    ) {
      IList<CityViewModel> citiesViewModel = new List<CityViewModel>();

      foreach(var city in cities) {
        var fakeCity = new Faker<CityViewModel>()
          .RuleFor(x => x.AreaCode, city.AreaCode)
          .RuleFor(x => x.Name, city.Name);

        citiesViewModel.Add(fakeCity.Generate());
      }

      return (IEnumerable<CityViewModel>)citiesViewModel;
    }
  }
}
