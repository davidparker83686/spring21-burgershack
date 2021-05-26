using System;
using System.Collections.Generic;
using spring21_burgershack.Models;
using spring21_burgershack.Repositories;

namespace spring21_burgershack.Services
{
  public class WarehousesService
  {
    private readonly WarehousesRepository _warehousesRepository;

    public WarehousesService(WarehousesRepository warehousesRepository)
    {
      _warehousesRepository = warehousesRepository;
    }
    // -----------------------------------------------------------------------------------------------------
    internal IEnumerable<Warehouse> GetAll()
    {
      return _warehousesRepository.GetAll();
    }
    // -----------------------------------------------------------------------------------------------------
    internal IEnumerable<Warehouse> GetByCreatorId(string id)
    {
      throw new NotImplementedException();
    }
    // -----------------------------------------------------------------------------------------------------
    internal Warehouse Create(Warehouse newWarehouse)
    {
      Warehouse warehouses = _warehousesRepository.Create(newWarehouse);
      return warehouses;
    }
    // -----------------------------------------------------------------------------------------------------
    internal Warehouse GetById(int id)
    {
      Warehouse warehouse = _warehousesRepository.GetById(id);
      if (warehouse == null)
      {
        throw new Exception("Invalid Warehouse Id");
      }
      return (Warehouse)warehouse;
    }

    internal void Delete(int apple, string id2)
    {
      Warehouse warehouse = GetById(apple);
      if (!_warehousesRepository.Delete(apple))
      {
        throw new Exception("Something has gone terribly wrong");
      }
    }



    // -----------------------------------------------------------------------------------------------------
    internal Warehouse Update(Warehouse update)
    {
      Warehouse original = GetById(update.Id);
      original.Location = update.Location.Length > 0 ? update.Location : original.Location;
      if (_warehousesRepository.Update(original))
      {
        return original;
      }
      throw new Exception("Something Went Wrong???");
    }







    internal List<WarehouseProducts.WarehouseProductViewModel> GetProducts(int id)
    {
      throw new NotImplementedException();
    }
  }

}
