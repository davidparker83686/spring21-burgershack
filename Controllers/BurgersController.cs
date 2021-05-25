﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using burgershack.Interfaces;
using Microsoft.AspNetCore.Mvc;
using spring21_burgershack.Models;
using spring21_burgershack.Services;

namespace spring21_burgershack.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class BurgersController : ControllerBase
  {
    private readonly BurgersService _bugersService;

    public BurgersController(BurgersService bugersService)
    {
      _bugersService = bugersService;
    }
    // -----------------------------------------------------------------------------------------------------
    [HttpPost]
    public ActionResult<Burger> Create([FromBody] Burger newBurger)
    {
      try
      {
        // newBurger.CreatorId = "fixthis later";
        Burger burgers = _bugersService.Create(newBurger);

        return Ok(burgers);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    // -----------------------------------------------------------------------------------------------------
    [HttpDelete("{id}")]
    public ActionResult<Burger> Delete(int id)
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
    // -----------------------------------------------------------------------------------------------------
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
    // -----------------------------------------------------------------------------------------------------

    [HttpGet("{id}")]
    public ActionResult<Burger> GetById(int id)
    {
      try
      {
        Burger burgers = _bugersService.GetById(id);
        return Ok(burgers);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // -----------------------------------------------------------------------------------------------------
    [HttpPut("{id}")]
    public ActionResult<Burger> Update(int id)
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