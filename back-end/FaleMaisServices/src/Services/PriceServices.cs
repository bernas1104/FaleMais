using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FaleMaisDomain.Entities;
using FaleMaisPersistence.Repositories.Interfaces;
using FaleMaisServices.Exceptions;
using FaleMaisServices.Services.Interfaces;
using FaleMaisServices.ViewModels;

namespace FaleMaisServices.Services {
  public class PriceServices : IPriceServices {
    private readonly IPricesRepository pricesRepository;
    private readonly ICitiesRepository citiesRepository;
    private readonly IMapper mapper;

    public PriceServices(
      IPricesRepository pricesRepository,
      ICitiesRepository citiesRepository,
      IMapper mapper
      ) {
      this.pricesRepository = pricesRepository;
      this.citiesRepository = citiesRepository;
      this.mapper = mapper;
    }

    public PriceViewModel CreatePrice(PriceViewModel data) {
      var city = citiesRepository.FindByAreaCode(data.FromAreaCode);
      if (city == null)
        throw new FaleMaisException("Origin city for call not found", 404);

      city = citiesRepository.FindByAreaCode(data.ToAreaCode);
      if (city == null)
        throw new FaleMaisException("Destiny city for call not found", 404);

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
      IList<PriceViewModel> pricesViewModel;
      IList<Price> prices = new List<Price>();

      if (toAreaCode != 0) {
        var price = pricesRepository.FindByFromToAreaCode(fromAreaCode, toAreaCode);
        prices.Add(price);
      }

      if (toAreaCode == 0)
        prices = pricesRepository.FindByFromToAreaCodeWithCities(fromAreaCode).ToList();

      pricesViewModel = mapper.Map<IList<PriceViewModel>>(prices);

      return pricesViewModel;
    }
  }
}
