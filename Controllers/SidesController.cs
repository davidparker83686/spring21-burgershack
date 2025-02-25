using System;
using System.Collections.Generic;
using burgershack.Interfaces;

using Microsoft.AspNetCore.Mvc;
using spring21_burgershack.Models;
using spring21_burgershack.Services;

namespace spring21_burgershack.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class SidesController : ControllerBase, ICodeWorksRestfulController<Side>
  {
    private readonly SidesService _sidesService;

    public SidesController(SidesService sidesService)
    {
      _sidesService = sidesService;
    }

    public ActionResult<Side> Create()
    {
      try
      {
        throw new NotImplementedException();
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    public ActionResult<Side> Delete()
    {
      try
      {
        throw new NotImplementedException();
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet]
    public ActionResult<IEnumerable<Side>> Get()
    {
      try
      {
        IEnumerable<Side> burgers = _sidesService.GetAll();
        return Ok(burgers);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    public ActionResult<Side> GetById()
    {
      throw new NotImplementedException();
    }



    public ActionResult<Side> Update()
    {
      try
      {
        throw new NotImplementedException();
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}
