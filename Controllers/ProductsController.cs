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

namespace spring21_burgershack.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProductsController : ControllerBase
  {
    private readonly ProductsService _productsService;

    public ProductsController(ProductsService productsService)
    {
      _productsService = productsService;
    }
    // -----------------------------------------------------------------------------------------------------
    [HttpPost]
    public ActionResult<Product> Create([FromBody] Product newProduct)
    {
      try
      {
        // newProduct.CreatorId = "fixthis later";
        Product products = _productsService.Create(newProduct);

        return Ok(products);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    // -----------------------------------------------------------------------------------------------------
    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<Product>> Delete(int id)
    {
      try
      {
        // TODO[epic=Auth] Get the user info to set the creatorID
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        // safety to make sure an account exists for that user before CREATE-ing stuff.
        _productsService.Delete(id, userInfo.Id);
        return Ok("Deleted");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    // -----------------------------------------------------------------------------------------------------
    [HttpGet]
    public ActionResult<IEnumerable<Product>> Get()
    {
      try
      {
        IEnumerable<Product> products = _productsService.GetAll();
        return Ok(products);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    // -----------------------------------------------------------------------------------------------------

    [HttpGet("{id}")]
    public ActionResult<Product> GetById(int id)
    {
      try
      {
        Product products = _productsService.GetById(id);
        return Ok(products);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // -----------------------------------------------------------------------------------------------------
    [HttpPut("{id}")]
    public ActionResult<Product> Update(int id, [FromBody] Product update)
    {
      try
      {
        update.Id = id;
        Product updated = _productsService.Update(update);
        return Ok(updated);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}