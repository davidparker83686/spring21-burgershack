using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using spring21_burgershack.Models;
using spring21_burgershack.Services;

namespace spring21_burgershack.Controllers
{
  [ApiController]
  [Route("[controller]")]
  // TODO[epic=Auth] Adds authguard to all routes on the whole controller

  public class AccountController : ControllerBase
  {
    private readonly AccountService _accountService;
    private readonly BurgersService _burgersService;
    private readonly DrinksService _drinksService;
    private readonly SidesService _sidesService;

    public AccountController(AccountService accountService, BurgersService burgersService, DrinksService drinksService, SidesService sidesService)
    {
      _accountService = accountService;
      _burgersService = burgersService;
      _drinksService = drinksService;
      _sidesService = sidesService;
    }

    [HttpGet]
    // [Authorize]
    public async Task<ActionResult<Account>> Get()
    {
      try
      {
        // TODO[epic=Auth] Replaces req.userinfo
        // IF YOU EVER NEED THE ACTIVE USERS INFO THIS IS HOW YOU DO IT (FROM AUTH0)

        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        Account currentUser = _accountService.GetOrCreateAccount(userInfo);
        return Ok(currentUser);
      }
      catch (Exception error)
      {
        return BadRequest(error.Message);
      }
    }

    [HttpGet("burgers")]
    [Authorize]
    public async Task<ActionResult<IEnumerable<Burger>>> GetMyBurgers()
    {
      // TODO[epic=Auth] Replaces req.userinfo
      // IF YOU EVER NEED THE ACTIVE USERS INFO THIS IS HOW YOU DO IT (FROM AUTH0)
      Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
      IEnumerable<Burger> burgers = _burgersService.GetByCreatorId(userInfo.Id);
      return Ok(burgers);

    }
    [HttpGet("drinks")]
    [Authorize]
    public async Task<ActionResult<IEnumerable<Drink>>> GetMyDrinks()
    {
      // TODO[epic=Auth] Replaces req.userinfo
      // IF YOU EVER NEED THE ACTIVE USERS INFO THIS IS HOW YOU DO IT (FROM AUTH0)
      Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
      IEnumerable<Drink> drinks = _drinksService.GetByCreatorId(userInfo.Id);
      return Ok(drinks);

    }
    [HttpGet("sides")]
    [Authorize]
    public async Task<ActionResult<IEnumerable<Side>>> GetMySides()
    {
      // TODO[epic=Auth] Replaces req.userinfo
      // IF YOU EVER NEED THE ACTIVE USERS INFO THIS IS HOW YOU DO IT (FROM AUTH0)
      Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
      IEnumerable<Side> sides = _sidesService.GetByCreatorId(userInfo.Id);
      return Ok(sides);
    }
  }
}