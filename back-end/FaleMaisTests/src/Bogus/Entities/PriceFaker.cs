using System;
using Bogus;
using FaleMaisDomain.Entities;
using FaleMaisServices.ViewModels;

namespace FaleMaisTests.Bogus.Entities {
  public static class PriceFaker {
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
  }
}
