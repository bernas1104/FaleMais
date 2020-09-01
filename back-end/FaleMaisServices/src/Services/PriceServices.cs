using System.Collections.Generic;
using AutoMapper;
using FaleMaisDomain.Entities;
using FaleMaisPersistence.Repositories.Interfaces;
using FaleMaisServices.Exceptions;
using FaleMaisServices.Services.Interfaces;
using FaleMaisServices.ViewModels;

namespace FaleMaisServices.Services {
  public class PriceServices : IPriceServices {
    private readonly IPricesRepository pricesRepository;
    private readonly IMapper mapper;

    public PriceServices(IPricesRepository pricesRepository, IMapper mapper) {
      this.pricesRepository = pricesRepository;
      this.mapper = mapper;
    }

    public PriceViewModel CreatePrice(PriceViewModel data) {
      var price = pricesRepository.FindByFromToAreaCode(
        data.FromAreaCode, data.ToAreaCode
      );
      if (price != null)
        throw new FaleMaisException("Call Price from City to City must be unique", 400);

      price = mapper.Map<Price>(data);
      price = pricesRepository.Create(price);

      return mapper.Map<PriceViewModel>(price);
    }

    public IEnumerable<PriceViewModel> ListPricesFromTo(
      byte fromAreaCode,
      byte toAreaCode = 0
    ) {
      IEnumerable<PriceViewModel> pricesViewModel;

      if (toAreaCode != 0) {
        var price = pricesRepository.FindByFromToAreaCode(fromAreaCode, toAreaCode);

        IEnumerable<Price> prices = new List<Price>(){ price };
        pricesViewModel = mapper.Map<IEnumerable<PriceViewModel>>(prices);
      } else {
        var prices = pricesRepository.FindByFromToAreaCodeWithCities(fromAreaCode);
        pricesViewModel = mapper.Map<IEnumerable<PriceViewModel>>(prices);
      }

      return pricesViewModel;
    }
  }
}
