using System;
using Bogus;
using FaleMaisServices.ViewModels;

namespace FaleMaisTests.Bogus.ViewModels {
  public static class PriceViewModelFaker {
    public static PriceViewModel GeneratePriceViewModel() {
      var priceViewModel = new Faker<PriceViewModel>()
        .RuleFor(x => x.Id, () => Guid.NewGuid().ToString())
        .RuleFor(x => x.FromAreaCode, (f) => f.Random.Byte(1, 100))
        .RuleFor(x => x.ToAreaCode, (f, u) => {
          byte value = f.Random.Byte(1, 100);

          while (value == u.FromAreaCode)
            value = f.Random.Byte(1, 100);

          return value;
        })
        .RuleFor(x => x.PricePerMinute, (f) => f.Random.Double() * 10);

      return priceViewModel.Generate();
    }
  }
}
