using System.Collections.Generic;
using FaleMaisServices.ViewModels;

namespace FaleMaisServices.Services.Interfaces {
  public interface ICityServices {
    public IEnumerable<CityViewModel> ListAllCities();
    public CityViewModel CreateCity(CityViewModel data);
  }
}
