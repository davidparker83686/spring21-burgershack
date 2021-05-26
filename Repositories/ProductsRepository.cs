using System.Collections.Generic;
using System.Data;
using Dapper;
using spring21_burgershack.Models;

namespace spring21_burgershack.Repositories
{
  public class ProductsRepository
  {

    private readonly IDbConnection _db;
    public ProductsRepository(IDbConnection db)
    {
      _db = db;
    }
    // -----------------------------------------------------------------------------------------------------
    public IEnumerable<Product> GetAll()
    {
      string sql = "SELECT * FROM products";
      return _db.Query<Product>(sql);
    }
    // -----------------------------------------------------------------------------------------------------
    public Product Create(Product newProduct)
    {
      string sql = @"
      INSERT INTO products
      (name,description,sku,price)
      VALUES
      ( @Name, @Description, @Sku, @Price);
      SELECT LAST_INSERT_ID();";

      newProduct.Id = _db.ExecuteScalar<int>(sql, newProduct);
      return newProduct;
    }
    // -----------------------------------------------------------------------------------------------------
    public Product GetById(int id)
    {
      string sql = "SELECT * FROM products WHERE id =@id;";
      return _db.QueryFirstOrDefault<Product>(sql, new { id });
    }
    // -----------------------------------------------------------------------------------------------------
    internal bool Update(Product original)
    {
      string sql = @"
      UPDATE products
      SET
        name = @Name,
        description = @Description,
        sku = @Sku,
        price = @Price
      WHERE id=@Id
      ";
      int affectedRows = _db.Execute(sql, original);
      return affectedRows == 1;
    }

    internal bool Delete(object id)
    {
      string sql = "DELETE FROM products WHERE id = @id LIMIT 1";
      int affectedRows = _db.Execute(sql, new { id });
      return affectedRows == 1;
    }
  }

}