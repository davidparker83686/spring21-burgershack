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
    internal Burger Create(Burger newBurger)
    {
      Burger burgers = _burgersRepository.Create(newBurger);
      return burgers;
    }
    // -----------------------------------------------------------------------------------------------------
    internal Burger GetById(int id)
    {
      Burger burger = _burgersRepository.GetById(id);
      if (burger == null)
      {
        throw new Exception("Invalid Burger Id");
      }
      return (Burger)burger;
    }

    internal void Delete(int apple, string id2)
    {
      Burger burger = GetById(apple);
      if (!_burgersRepository.Delete(apple))
      {
        throw new Exception("Something has gone terribly wrong");
      }
    }



    // -----------------------------------------------------------------------------------------------------
    internal Burger Update(Burger update)
    {
      Burger original = GetById(update.Id);
      original.Name = update.Name.Length > 0 ? update.Name : original.Name;
      original.Cost = update.Cost > 0 ? update.Cost : original.Cost;
      original.Quantity = update.Quantity > 0 ? update.Quantity : original.Quantity;
      original.Modifications = update.Modifications.Length > 0 ? update.Modifications : original.Modifications;
      if (_burgersRepository.Update(original))
      {
        return original;
      }
      throw new Exception("Something Went Wrong???");
    }
  }

}
