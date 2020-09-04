using System.Collections.Generic;
using Bogus;
using FaleMaisDomain.Entities;
using FaleMaisServices.ViewModels;

namespace FaleMaisTests.Bogus.ViewModels {
  public static class AreaCodeViewModelFaker {
    public static AreaCodeViewModel GenerateCityViewModel() {
      var cityViewModel = new Faker<AreaCodeViewModel>()
        .RuleFor(x => x.Id, (f) => f.Random.Byte(1, 100))
        .RuleFor(x => x.Name, (f) => f.Address.City());

      return cityViewModel.Generate();
    }

    public static IEnumerable<AreaCodeViewModel> GenerateAreaCodesViewModel(
      IEnumerable<AreaCode> cities
    ) {
      IList<AreaCodeViewModel> citiesViewModel = new List<AreaCodeViewModel>();

      foreach(var city in cities) {
        var fakeCity = new Faker<AreaCodeViewModel>()
          .RuleFor(x => x.Id, city.Id)
          .RuleFor(x => x.Name, city.Name);

        citiesViewModel.Add(fakeCity.Generate());
      }

      return (IEnumerable<AreaCodeViewModel>)citiesViewModel;
    }
  }
}
