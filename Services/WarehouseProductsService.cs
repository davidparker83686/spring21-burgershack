using System;
using spring21_burgershack.Models;
using spring21_burgershack.Repositories;
using static spring21_burgershack.Models.WarehouseProducts;

namespace spring21_burgershack.Services
{
  public class WarehouseProductsService
  {
    private readonly WarehouseProductsRepository _warehouseProductsRepository;

    public WarehouseProductsService(WarehousesRepository warehousesRepository, WarehouseProductsRepository warehouseProductsRepository)
    {
      _warehouseProductsRepository = warehouseProductsRepository;
    }

    public WarehouseProduct CreateWarehouseProduct(WarehouseProduct wp)
    {
      return _warehouseProductsRepository.Create(wp);
    }

    internal WarehouseProduct UpdateWarehouseProduct(WarehouseProduct update)
    {
      WarehouseProduct original = GetById(update.Id);
      original.ProductId = update.ProductId > 0 ? update.ProductId : original.ProductId;
      original.WarehouseId = update.WarehouseId > 0 ? update.WarehouseId : original.WarehouseId;
      if (_warehouseProductsRepository.Update(original))
      {
        return original;
      }
      throw new Exception("Something Went Wrong???");
    }

    private WarehouseProduct GetById(object id)
    {
      throw new NotImplementedException();
    }
  }
}