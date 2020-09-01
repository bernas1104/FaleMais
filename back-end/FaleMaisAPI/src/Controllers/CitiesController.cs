using FaleMaisServices.Services.Interfaces;
using FaleMaisServices.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FaleMaisAPI.Controllers {
  [ApiController]
  [Route("v1/[controller]")]
  [Produces("application/json")]
  public class CitiesController : ControllerBase {
    public ActionResult<CityViewModel> Create(
      [FromServices] ICityServices services,
      [FromBody] CityViewModel data
    ) {
      data.Validate();

      if (data.Invalid)
        return BadRequest(data.Notifications);

      var city = services.CreateCity(data);

      return Created(nameof(Create), city);
    }
  }
}
