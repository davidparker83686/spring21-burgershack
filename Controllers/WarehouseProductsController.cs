
using System.Collections.Generic;
using spring21_burgershack.Models;
using spring21_burgershack.Services;
using Microsoft.AspNetCore.Mvc;
using static spring21_burgershack.Models.WarehouseProducts;

namespace spring21_burgershack.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class WarehouseProductsController : ControllerBase
  {
    private readonly WarehouseProductsService _warehouseProductsService;

    public WarehouseProductsController(WarehouseProductsService warehouseProductsService)
    {
      _warehouseProductsService = warehouseProductsService;
    }

    [HttpPost]
    public ActionResult<WarehouseProduct> CreateWarehouseProduct([FromBody] WarehouseProduct wp)
    {
      try
      {
        WarehouseProduct newProduct = _warehouseProductsService.CreateWarehouseProduct(wp);
        return Ok(newProduct);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPut("{id}")]
    public ActionResult<WarehouseProduct> UpdateWarehouseProduct([FromBody] WarehouseProduct wp)
    {
      try
      {
        WarehouseProduct update = _warehouseProductsService.UpdateWarehouseProduct(wp);
        return Ok(update);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }


  }
}