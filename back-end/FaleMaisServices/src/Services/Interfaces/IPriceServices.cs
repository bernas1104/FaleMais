using System.Collections.Generic;
using FaleMaisServices.ViewModels;

namespace FaleMaisServices.Services.Interfaces {
  public interface IPriceServices {
    public PriceViewModel CreatePrice(PriceViewModel data);
    public IEnumerable<PriceViewModel> ListPricesFromTo(
      byte fromAreaCode, byte toAreaCode = 0
    );
  }
}
