using FaleMaisServices.ViewModels;

namespace FaleMaisServices.Services.Interfaces {
  public interface IPriceServices {
    public PriceViewModel CreatePrice(PriceViewModel data);
  }
}
