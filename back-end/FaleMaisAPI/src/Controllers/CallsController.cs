using System;
using System.Collections.Generic;
using FaleMaisServices.Services.Interfaces;
using FaleMaisServices.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FaleMaisAPI.Controllers {
  [ApiController]
  [Route("v1/[controller]")]
  [Produces("application/json")]
  public class CallsController : ControllerBase {
    [HttpPatch]
    public ActionResult<CallViewModel> Update(
      [FromServices] ICallServices services,
      [FromBody] CallViewModel data
    ) {
      data.Validate();

      if (data.Invalid)
        return BadRequest(data.Notifications);

      var call = services.UpdateCallPrice(data);

      return Ok(call);
    }

    [HttpGet]
    public ActionResult<IEnumerable<CallViewModel>> GetPrice(
      [FromServices] ICallServices services,
      [FromQuery(Name = "from-area-code")] byte fromAreaCode,
      [FromQuery(Name = "to-area-code")] byte toAreaCode
    ) {
      if (fromAreaCode <= 0 || fromAreaCode >= 101) {
        return BadRequest(new {
          StatusCode = 400,
          Message = "Origin area code must be between 1 and 100"
        });
      }

      if (toAreaCode <= 0 || toAreaCode >= 101) {
        return BadRequest(new {
          StatusCode = 400,
          Message = "Destiny area code must be between 1 and 100"
        });
      }

      var call = services.GetCallPriceFromTo(fromAreaCode, toAreaCode);

      return Ok(call);
    }
  }
}
