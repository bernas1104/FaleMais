using System.Collections.Generic;
using FaleMaisServices.ViewModels;

namespace FaleMaisServices.Services.Interfaces {
  public interface IAreaCodeServices {
    public IEnumerable<AreaCodeViewModel> ListAllAreaCodes();
  }
}
