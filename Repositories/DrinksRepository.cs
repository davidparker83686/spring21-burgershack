using System.Collections.Generic;
using burgershack.Interfaces;
using spring21_burgershack.Models;

namespace burgershack.Repositories
{
  public class DrinksRepository : IRepo<Drink>
  {

    public IEnumerable<Drink> GetAll()
    {
      throw new System.NotImplementedException();
    }
    public Drink Create(Drink data)
    {
      throw new System.NotImplementedException();
    }

    public Drink GetById(int id)
    {
      throw new System.NotImplementedException();
    }

    public Drink Update(Drink data)
    {
      throw new System.NotImplementedException();
    }
  }

}