using System;
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
  public class DrinksController : ControllerBase
  {
    private readonly DrinksService _drinksService;

    public DrinksController(DrinksService drinksService)
    {
      _drinksService = drinksService;
    }
    // -----------------------------------------------------------------------------------------------------
    [HttpPost]
    public ActionResult<Drink> Create([FromBody] Drink newDrink)
    {
      try
      {
        // newDrink.CreatorId = "fixthis later";
        Drink burgers = _drinksService.Create(newDrink);

        return Ok(burgers);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    // -----------------------------------------------------------------------------------------------------
    [HttpDelete("{id}")]
    public ActionResult<Drink> Delete(int id)
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
    public ActionResult<IEnumerable<Drink>> Get()
    {
      try
      {
        IEnumerable<Drink> burgers = _drinksService.GetAll();
        return Ok(burgers);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    // -----------------------------------------------------------------------------------------------------

    [HttpGet("{id}")]
    public ActionResult<Drink> GetById(int id)
    {
      try
      {
        Drink burgers = _drinksService.GetById(id);
        return Ok(burgers);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // -----------------------------------------------------------------------------------------------------
    [HttpPut("{id}")]
    public ActionResult<Drink> Update(int id, [FromBody] Drink update)
    {
      try
      {
        update.Id = id;
        Drink updated = _drinksService.Update(update);
        return Ok(updated);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}