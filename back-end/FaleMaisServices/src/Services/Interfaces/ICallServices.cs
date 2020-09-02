using System.Collections.Generic;
using FaleMaisServices.ViewModels;

namespace FaleMaisServices.Services.Interfaces {
  public interface ICallServices {
    public CallViewModel UpdateCallPrice(CallViewModel data);
    public CallViewModel GetCallPriceFromTo(
      byte fromAreaCode, byte toAreaCode
    );
  }
}
