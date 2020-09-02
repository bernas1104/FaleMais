using System;
using System.Collections.Generic;
using Bogus;
using FaleMaisDomain.Entities;
using FaleMaisServices.ViewModels;

namespace FaleMaisTests.Bogus.ViewModels {
  public static class CallViewModelFaker {
    public static CallViewModel GenerateCallViewModel() {
      var priceViewModel = new Faker<CallViewModel>()
        .RuleFor(x => x.FromAreaCode, (f) => f.Random.Byte(1, 100))
        .RuleFor(x => x.ToAreaCode, (f, u) => {
          byte value = f.Random.Byte(1, 100);

          while (value == u.FromAreaCode)
            value = f.Random.Byte(1, 100);

          return value;
        })
        .RuleFor(x => x.PricePerMinute, (f) => f.Random.Double() * 9);

      return priceViewModel.Generate();
    }

    public static CallViewModel GenerateCallViewModel(Call info) {
      var priceViewModel = new Faker<CallViewModel>()
        .RuleFor(x => x.FromAreaCode, () => info.FromAreaCode)
        .RuleFor(x => x.ToAreaCode, () => info.ToAreaCode)
        .RuleFor(x => x.PricePerMinute, () => info.PricePerMinute);

      return priceViewModel.Generate();
    }

    public static IEnumerable<CallViewModel> GenerateCallViewModels(
      byte fromAreaCode,
      IEnumerable<Call> prices
    ) {
      IList<CallViewModel> generated = new List<CallViewModel>();

      var priceViewModels = new Faker<CallViewModel>()
        .RuleFor(x => x.FromAreaCode, () => fromAreaCode)
        .RuleFor(x => x.PricePerMinute, (f) => f.Random.Double() * 10);

      foreach(var price in prices) {
        priceViewModels.RuleFor(x => x.ToAreaCode, () => price.ToAreaCode);
        generated.Add(priceViewModels.Generate());
      }

      return generated;
    }
  }
}
