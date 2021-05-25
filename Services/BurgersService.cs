using System;
using System.Collections.Generic;
using spring21_burgershack.Models;
using spring21_burgershack.Repositories;

namespace spring21_burgershack.Services
{
  public class BurgersService
  {
    private readonly BurgersRepository _burgersRepository;

    public BurgersService(BurgersRepository burgersRepository)
    {
      _burgersRepository = burgersRepository;
    }
    // -----------------------------------------------------------------------------------------------------
    internal IEnumerable<Burger> GetAll()
    {
      return _burgersRepository.GetAll();
    }
    // -----------------------------------------------------------------------------------------------------
    internal IEnumerable<Burger> GetByCreatorId(string id)
    {
      throw new NotImplementedException();
    }
    // -----------------------------------------------------------------------------------------------------
    internal IEnumerable<Burger> GetById(int id)
    {
      Burger burger = _burgersRepository.GetById(id);
      if (burger == null)
      {
        throw new Exception("Invalid Burger Id");
      }
      return (IEnumerable<Burger>)burger;
    }
    // -----------------------------------------------------------------------------------------------------



    //ALL THE OTHER FUNCTION WILL GO HERE
  }
}