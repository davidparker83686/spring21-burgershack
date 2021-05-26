using System.Collections.Generic;
using System.Data;
using Dapper;
using spring21_burgershack.Models;


namespace spring21_burgershack.Repositories
{
  public class DrinksRepository
  {

    private readonly IDbConnection _db;
    public DrinksRepository(IDbConnection db)
    {
      _db = db;
    }
    // -----------------------------------------------------------------------------------------------------
    public IEnumerable<Drink> GetAll()
    {
      string sql = "SELECT * FROM drinks";
      return _db.Query<Drink>(sql);
    }
    // -----------------------------------------------------------------------------------------------------
    public Drink Create(Drink newDrink)
    {
      string sql = @"
      INSERT INTO drinks
      (name,cost,quantity,modifications)
      VALUES
      ( @Name, @Cost, @Quantity, @Modifications);
      SELECT LAST_INSERT_ID();";

      newDrink.Id = _db.ExecuteScalar<int>(sql, newDrink);
      return newDrink;
    }
    // -----------------------------------------------------------------------------------------------------
    public Drink GetById(int id)
    {
      string sql = "SELECT * FROM drinks WHERE id =@id;";
      return _db.QueryFirstOrDefault<Drink>(sql, new { id });
    }
    // -----------------------------------------------------------------------------------------------------
    internal bool Update(Drink original)
    {
      string sql = @"
      UPDATE drinks
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