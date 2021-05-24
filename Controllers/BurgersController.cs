﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using burgershack.Interfaces;
using burgershack.Models;
using burgershack.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace burgershack.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class BurgersController : ControllerBase, ICodeWorksRestfulController<Burger>
  {
    private readonly BurgersService _bugersService;

    public BurgersController(BurgersService bugersService)
    {
      _bugersService = bugersService;
    }

    public ActionResult<Burger> Create()
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

    public ActionResult<Burger> Delete()
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
    public ActionResult<IEnumerable<Burger>> Get()
    {
      try
      {
        IEnumerable<Burger> burgers = _bugersService.GetAll();
        return Ok(burgers);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    public ActionResult<Burger> GetOne()
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

    public ActionResult<Burger> Update()
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
