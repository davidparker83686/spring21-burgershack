using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using burgershack.Interfaces;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using spring21_burgershack.Models;
using spring21_burgershack.Services;
using static spring21_burgershack.Models.WarehouseProducts;

namespace spring21_burgershack.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class WarehousesController : ControllerBase
  {
    private readonly WarehousesService _warehousesService;

    public WarehousesController(WarehousesService warehousesService)
    {
      _warehousesService = warehousesService;
    }
    // -----------------------------------------------------------------------------------------------------
    [HttpPost]
    public ActionResult<Warehouse> Create([FromBody] Warehouse newWarehouse)
    {
      try
      {
        // newWarehouse.CreatorId = "fixthis later";
        Warehouse warehouses = _warehousesService.Create(newWarehouse);

        return Ok(warehouses);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    // -----------------------------------------------------------------------------------------------------
    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<Warehouse>> Delete(int id)
    {
      try
      {
        // TODO[epic=Auth] Get the user info to set the creatorID
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        // safety to make sure an account exists for that user before CREATE-ing stuff.
        _warehousesService.Delete(id, userInfo.Id);
        return Ok("Deleted");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    // -----------------------------------------------------------------------------------------------------
    [HttpGet]
    public ActionResult<IEnumerable<Warehouse>> Get()
    {
      try
      {
        IEnumerable<Warehouse> warehouses = _warehousesService.GetAll();
        return Ok(warehouses);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    // -----------------------------------------------------------------------------------------------------

    [HttpGet("{id}")]
    public ActionResult<Warehouse> GetById(int id)
    {
      try
      {
        Warehouse warehouses = _warehousesService.GetById(id);
        return Ok(warehouses);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // -----------------------------------------------------------------------------------------------------
    [HttpPut("{id}")]
    public ActionResult<Warehouse> Update(int id, [FromBody] Warehouse update)
    {
      try
      {
        update.Id = id;
        Warehouse updated = _warehousesService.Update(update);
        return Ok(updated);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}/products")]
    public ActionResult<List<WarehouseProductViewModel>> GetWarehouseProducts(int id)
    {
      try
      {
        List<WarehouseProductViewModel> products = _warehousesService.GetProducts(id);
        return Ok(products);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}