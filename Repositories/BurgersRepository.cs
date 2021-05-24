using System.Collections.Generic;
using System.Data;
using burgershack.Interfaces;
using burgershack.Models;

namespace burgershack.Repositories
{
  public class BurgersRepository : IRepo<Burger>
  {

    private readonly IDbConnection _db;
    public BurgersRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Burger> GetAll()
    {
      string sql = "SELECT * FROM burgers";
      return _db.Query<Burger>(sql);
    }
    public Burger Create(Burger data)
    {
      throw new System.NotImplementedException();
    }

    public Burger GetById(int id)
    {
      throw new System.NotImplementedException();
    }

    public Burger Update(Burger data)
    {
      throw new System.NotImplementedException();
    }
  }

}