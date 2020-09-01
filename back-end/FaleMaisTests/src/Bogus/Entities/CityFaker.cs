using System;
using System.Collections.Generic;
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

    public static IEnumerable<City> GenerateCities(int quantity) {
      var city = new Faker<City>()
        .RuleFor(x => x.AreaCode, (f) => f.Random.Byte(1, 100))
        .RuleFor(x => x.Name, (f) => f.Address.City())
        .RuleFor(x => x.CreatedAt, () => DateTime.Now)
        .RuleFor(x => x.UpdatedAt, () => DateTime.Now)
        .RuleFor(x => x.DeletedAt, () => null);

      return city.Generate(quantity);
    }
  }
}
