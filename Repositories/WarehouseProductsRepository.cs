using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using static spring21_burgershack.Models.WarehouseProducts;

namespace spring21_burgershack.Repositories
{
  public class WarehouseProductsRepository
  {
    private readonly IDbConnection _db;

    public WarehouseProductsRepository(IDbConnection db)
    {
      _db = db;
    }

    public WarehouseProduct Create(WarehouseProduct wp)
    {
      string sql = @"INSERT INTO 
            warehouse_products(warehouseId, productId)
            VALUES (@WarehouseId, @ProductId);
            SELECT LAST_INSERT_ID();
            ";

      wp.Id = _db.ExecuteScalar<int>(sql, wp);
      return wp;
    }

    internal List<WarehouseProductViewModel> GetProductByWarehouseId(int warehouseId)
    {
      string sql = @"
                SELECT
                p.*,
                w.location,
                wp.id as warehouseProductId,
                wp.productId as productId,
                wp.warehouseId as warehouseId
                FROM
                warehouse_products wp
                JOIN warehouses w ON w.id = wp.warehouseId
                JOIN products p ON p.id = wp.productId
                WHERE
                wp.warehouseId = @warehouseId;
            ";
      return _db.Query<WarehouseProductViewModel>(sql, new { warehouseId }).ToList();
    }

    internal bool Update(WarehouseProduct original)
    {
      string sql = @"
      UPDATE warehouse_products
      SET
        warehouseId = @WarehouseId,
        productId = @ProductId)
        WHERE id = @Id
            ";
      int affectedRows = _db.Execute(sql, original);
      return affectedRows == 1;

      throw new NotImplementedException();
    }
  }
}