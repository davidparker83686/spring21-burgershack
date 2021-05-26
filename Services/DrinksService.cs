using System;
using System.Collections.Generic;
using spring21_burgershack.Models;
using spring21_burgershack.Repositories;

namespace spring21_burgershack.Services
{
  public class DrinksService
  {
    private readonly DrinksRepository _drinksRepository;

    public DrinksService(DrinksRepository drinksRepository)
    {
      _drinksRepository = drinksRepository;
    }
    // -----------------------------------------------------------------------------------------------------
    internal IEnumerable<Drink> GetAll()
    {
      return _drinksRepository.GetAll();
    }
    // -----------------------------------------------------------------------------------------------------
    internal IEnumerable<Drink> GetByCreatorId(string id)
    {
      throw new NotImplementedException();
    }
    // -----------------------------------------------------------------------------------------------------
    internal Drink Create(Drink newDrink)
    {
      Drink drinks = _drinksRepository.Create(newDrink);
      return drinks;
    }
    // -----------------------------------------------------------------------------------------------------
    internal Drink GetById(int id)
    {
      Drink drink = _drinksRepository.GetById(id);
      if (drink == null)
      {
        throw new Exception("Invalid Drink Id");
      }
      return (Drink)drink;
    }

    // -----------------------------------------------------------------------------------------------------
    internal Drink Update(Drink update)
    {
      Drink original = GetById(update.Id);
      original.Name = update.Name.Length > 0 ? update.Name : original.Name;
      original.Cost = update.Cost > 0 ? update.Cost : original.Cost;
      original.Quantity = update.Quantity > 0 ? update.Quantity : original.Quantity;
      original.Modifications = update.Modifications.Length > 0 ? update.Modifications : original.Modifications;
      if (_drinksRepository.Update(original))
      {
        return original;
      }
      throw new Exception("Something Went Wrong???");
    }
  }

}
