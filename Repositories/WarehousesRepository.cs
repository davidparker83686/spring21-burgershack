using System.Collections.Generic;
using System.Data;
using Dapper;
using spring21_burgershack.Models;

namespace spring21_burgershack.Repositories
{
  public class WarehousesRepository
  {

    private readonly IDbConnection _db;
    public WarehousesRepository(IDbConnection db)
    {
      _db = db;
    }
    // -----------------------------------------------------------------------------------------------------
    public IEnumerable<Warehouse> GetAll()
    {
      string sql = "SELECT * FROM warehouses";
      return _db.Query<Warehouse>(sql);
    }
    // -----------------------------------------------------------------------------------------------------
    public Warehouse Create(Warehouse newWarehouse)
    {
      string sql = @"
      INSERT INTO warehouses
      (location)
      VALUES
      ( @Location);
      SELECT LAST_INSERT_ID();";

      newWarehouse.Id = _db.ExecuteScalar<int>(sql, newWarehouse);
      return newWarehouse;
    }
    // -----------------------------------------------------------------------------------------------------
    public Warehouse GetById(int id)
    {
      string sql = "SELECT * FROM warehouses WHERE id =@id;";
      return _db.QueryFirstOrDefault<Warehouse>(sql, new { id });
    }
    // -----------------------------------------------------------------------------------------------------
    internal bool Update(Warehouse original)
    {
      string sql = @"
      UPDATE warehouses
      SET
        location= @Location
      WHERE id=@Id
      ";
      int affectedRows = _db.Execute(sql, original);
      return affectedRows == 1;
    }

    internal bool Delete(object id)
    {
      string sql = "DELETE FROM warehouses WHERE id = @id LIMIT 1";
      int affectedRows = _db.Execute(sql, new { id });
      return affectedRows == 1;
    }
  }

}