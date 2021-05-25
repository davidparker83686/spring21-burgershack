using System.Collections.Generic;
using System.Data;
using Dapper;
using spring21_burgershack.Models;

namespace spring21_burgershack.Repositories
{
  public class BurgersRepository
  {

    private readonly IDbConnection _db;
    public BurgersRepository(IDbConnection db)
    {
      _db = db;
    }
    // -----------------------------------------------------------------------------------------------------
    public IEnumerable<Burger> GetAll()
    {
      string sql = "SELECT * FROM burgers";
      return _db.Query<Burger>(sql);
    }
    // -----------------------------------------------------------------------------------------------------
    public Burger Create(Burger data)
    {
      throw new System.NotImplementedException();
    }
    // -----------------------------------------------------------------------------------------------------
    public Burger GetById(int id)
    {
      string sql = "SELECT * FROM burgers WHERE id ==@Id;";
      return _db.Query<Burger>(sql)
    }
    // -----------------------------------------------------------------------------------------------------
    public Burger Update(Burger data)
    {
      throw new System.NotImplementedException();
    }
  }

}