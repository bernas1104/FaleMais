using System;
using System.Collections.Generic;
using Bogus;
using FaleMaisDomain.Entities;
using FaleMaisServices.ViewModels;

namespace FaleMaisTests.Bogus.Entities {
  public static class PriceFaker {
    public static Price GeneratePrice() {
      var price = new Faker<Price>()
        .RuleFor(x => x.Id, () => Guid.NewGuid().ToString())
        .RuleFor(x => x.FromAreaCode, (f) => f.Random.Byte(1, 100))
        .RuleFor(x => x.ToAreaCode, (f, u) => {
          byte value = f.Random.Byte(1, 100);

          while (value == u.FromAreaCode)
            value = f.Random.Byte(1, 100);

          return value;
        })
        .RuleFor(x => x.PricePerMinute, (f) => f.Random.Double() * 10)
        .RuleFor(x => x.CreatedAt, () => DateTime.Now)
        .RuleFor(x => x.UpdatedAt, () => DateTime.Now)
        .RuleFor(x => x.DeletedAt, () => null);

      return price.Generate();
    }

    public static Price GeneratePrice(PriceViewModel info) {
      var price = new Faker<Price>()
        .RuleFor(x => x.Id, () => Guid.NewGuid().ToString())
        .RuleFor(x => x.FromAreaCode, () => info.FromAreaCode)
        .RuleFor(x => x.ToAreaCode, () => info.ToAreaCode)
        .RuleFor(x => x.PricePerMinute, () => info.PricePerMinute)
        .RuleFor(x => x.CreatedAt, () => DateTime.Now)
        .RuleFor(x => x.UpdatedAt, () => DateTime.Now)
        .RuleFor(x => x.DeletedAt, () => null);

      return price.Generate();
    }

    public static IEnumerable<Price> GeneratePrices(byte fromAreaCode, int quantity) {
      var prices = new Faker<Price>()
        .RuleFor(x => x.Id, () => Guid.NewGuid().ToString())
        .RuleFor(x => x.FromAreaCode, () => fromAreaCode)
        .RuleFor(x => x.ToAreaCode, (f, u) => {
          byte value = f.Random.Byte(1, 100);

          while (value == u.FromAreaCode)
            value = f.Random.Byte(1, 100);

          return value;
        })
        .RuleFor(x => x.PricePerMinute, (f) => f.Random.Double() * 10)
        .RuleFor(x => x.CreatedAt, () => DateTime.Now)
        .RuleFor(x => x.UpdatedAt, () => DateTime.Now)
        .RuleFor(x => x.DeletedAt, () => null);

      return prices.Generate(quantity);
    }
  }
}
