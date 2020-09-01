using FaleMaisServices.Services.Interfaces;
using FaleMaisServices.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FaleMaisAPI.Controllers {
  [ApiController]
  [Route("v1/[controller]")]
  [Produces("application/json")]
  public class PricesController : ControllerBase {
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
  }
}
