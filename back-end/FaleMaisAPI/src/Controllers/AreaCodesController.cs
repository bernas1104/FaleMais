using System.Collections.Generic;
using FaleMaisServices.Services.Interfaces;
using FaleMaisServices.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FaleMaisAPI.Controllers {
  [ApiController]
  [Route("v1/[controller]")]
  [Produces("application/json")]
  public class AreaCodesController : ControllerBase {
    [HttpGet]
    public ActionResult<IEnumerable<AreaCodeViewModel>> Index(
      [FromServices] IAreaCodeServices services
    ) {
      var cities = services.ListAllAreaCodes();

      return Ok(cities);
    }
  }
}
