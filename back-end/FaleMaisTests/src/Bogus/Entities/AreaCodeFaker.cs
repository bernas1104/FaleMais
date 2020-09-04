using System;
using System.Collections.Generic;
using Bogus;
using FaleMaisDomain.Entities;
using FaleMaisServices.ViewModels;

namespace FaleMaisTests.Bogus.Entities {
  public static class AreaCodeFaker {
    public static AreaCode GenerateAreaCode(AreaCodeViewModel info) {
      var city = new Faker<AreaCode>()
        .RuleFor(x => x.Id, () => info.Id)
        .RuleFor(x => x.Name, () => info.Name)
        .RuleFor(x => x.CreatedAt, () => DateTime.Now)
        .RuleFor(x => x.UpdatedAt, () => DateTime.Now)
        .RuleFor(x => x.DeletedAt, () => null);

      return city.Generate();
    }

    public static IEnumerable<AreaCode> GenerateAreaCodes(int quantity) {
      var city = new Faker<AreaCode>()
        .RuleFor(x => x.Id, (f) => f.Random.Byte(1, 100))
        .RuleFor(x => x.Name, (f) => f.Address.City())
        .RuleFor(x => x.CreatedAt, () => DateTime.Now)
        .RuleFor(x => x.UpdatedAt, () => DateTime.Now)
        .RuleFor(x => x.DeletedAt, () => null);

      return city.Generate(quantity);
    }
  }
}
