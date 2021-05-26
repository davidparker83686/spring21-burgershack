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
    public Burger Create(Burger newBurger)
    {
      string sql = @"
      INSERT INTO burgers
      (name,cost,quantity,modifications)
      VALUES
      ( @Name, @Cost, @Quantity, @Modifications);
      SELECT LAST_INSERT_ID();";

      newBurger.Id = _db.ExecuteScalar<int>(sql, newBurger);
      return newBurger;
    }
    // -----------------------------------------------------------------------------------------------------
    public Burger GetById(int id)
    {
      string sql = "SELECT * FROM burgers WHERE id =@id;";
      return _db.QueryFirstOrDefault<Burger>(sql, new { id });
    }
    // -----------------------------------------------------------------------------------------------------
    internal bool Update(Burger original)
    {
      string sql = @"
      UPDATE burgers
      SET
        name = @Name,
        cost = @Cost,
        quantity = @Quantity
        modifications=@Modifications
      WHERE id=@Id
      ";
      int affectedRows = _db.Execute(sql, original);
      return affectedRows == 1;
    }
  }

}