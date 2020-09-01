using System.Collections.Generic;
using FaleMaisServices.Services.Interfaces;
using FaleMaisServices.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FaleMaisAPI.Controllers {
  [ApiController]
  [Route("v1/[controller]")]
  [Produces("application/json")]
  public class CitiesController : ControllerBase {
    [HttpGet]
    public ActionResult<IEnumerable<CityViewModel>> Index(
      [FromServices] ICityServices services
    ) {
      var cities = services.ListAllCities();

      return Ok(cities);
    }

    [HttpPost]
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
