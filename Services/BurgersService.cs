using System;
using System.Collections.Generic;

using burgershack.Repositories;
using spring21_burgershack.Models;

namespace burgershack.Services
{
  public class BurgersService
  {
    private readonly BurgersRepository _burgersRepository;

    public BurgersService(BurgersRepository burgersRepository)
    {
      _burgersRepository = burgersRepository;
    }
    internal IEnumerable<Burger> GetAll()
    {
      return _burgersRepository.GetAll();
    }

    internal IEnumerable<Burger> GetByCreatorId(string id)
    {
      throw new NotImplementedException();
    }




    //ALL THE OTHER FUNCTION WILL GO HERE
  }
}