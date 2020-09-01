using System;
using Bogus;
using FaleMaisDomain.Entities;
using FaleMaisServices.ViewModels;

namespace FaleMaisTests.Bogus.Entities {
  public static class CityFaker {
    public static City GenerateCity(CityViewModel info) {
      var city = new Faker<City>()
        .RuleFor(x => x.AreaCode, () => info.AreaCode)
        .RuleFor(x => x.Name, () => info.Name)
        .RuleFor(x => x.CreatedAt, () => DateTime.Now)
        .RuleFor(x => x.UpdatedAt, () => DateTime.Now)
        .RuleFor(x => x.DeletedAt, () => null);

      return city.Generate();
    }
  }
}
