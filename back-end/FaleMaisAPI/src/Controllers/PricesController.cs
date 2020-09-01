using System;
using System.Collections.Generic;
using FaleMaisServices.Services.Interfaces;
using FaleMaisServices.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FaleMaisAPI.Controllers {
  [ApiController]
  [Route("v1/[controller]")]
  [Produces("application/json")]
  public class PricesController : ControllerBase {
    [HttpPost]
    public ActionResult<PriceViewModel> Create(
      [FromServices] IPriceServices services,
      [FromBody] PriceViewModel data
    ) {
      data.Validate();

      if (data.Invalid)
        return BadRequest(data.Notifications);

      var price = services.CreatePrice(data);

      return Created(nameof(Create), price);
    }

    [HttpGet]
    [Route("{fromAreaCode:int}")]
    public ActionResult<IEnumerable<PriceViewModel>> GetPrices(
      [FromServices] IPriceServices services,
      [FromQuery(Name = "to-area-code")] byte toAreaCode,
      byte fromAreaCode
    ) {
      if (fromAreaCode < 0 || fromAreaCode > 100) {
        return BadRequest(new {
          StatusCode = 400,
          Message = "Area Code of origin city must be between 1 and 100",
        });
      }

      var prices = services.ListPricesFromTo(fromAreaCode, toAreaCode);

      return Ok(prices);
    }
  }
}
