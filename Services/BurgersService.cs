using System;
using System.Collections.Generic;
using burgershack.Models;
using burgershack.Repositories;

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




    //ALL THE OTHER FUNCTION WILL GO HERE
  }
}