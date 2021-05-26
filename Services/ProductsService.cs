using System;
using System.Collections.Generic;
using spring21_burgershack.Models;
using spring21_burgershack.Repositories;

namespace spring21_burgershack.Services
{
  public class ProductsService
  {
    private readonly ProductsRepository _productsRepository;

    public ProductsService(ProductsRepository productsRepository)
    {
      _productsRepository = productsRepository;
    }
    // -----------------------------------------------------------------------------------------------------
    internal IEnumerable<Product> GetAll()
    {
      return _productsRepository.GetAll();
    }
    // -----------------------------------------------------------------------------------------------------
    internal IEnumerable<Product> GetByCreatorId(string id)
    {
      throw new NotImplementedException();
    }
    // -----------------------------------------------------------------------------------------------------
    internal Product Create(Product newProduct)
    {
      Product products = _productsRepository.Create(newProduct);
      return products;
    }
    // -----------------------------------------------------------------------------------------------------
    internal Product GetById(int id)
    {
      Product product = _productsRepository.GetById(id);
      if (product == null)
      {
        throw new Exception("Invalid Product Id");
      }
      return (Product)product;
    }

    // -----------------------------------------------------------------------------------------------------
    internal Product Update(Product update)
    {
      Product original = GetById(update.Id);
      // public DateTime CreatedAt { get; set; }
      //   public DateTime UpdatedAt { get; set; }
      original.Name = update.Name.Length > 0 ? update.Name : original.Name;
      original.Description = update.Description.Length > 0 ? update.Description : original.Description;
      original.Price = update.Price > 0 ? update.Price : original.Price;
      original.Sku = update.Sku.Length > 0 ? update.Sku : original.Sku;
      if (_productsRepository.Update(original))
      {
        return original;
      }
      throw new Exception("Something Went Wrong???");
    }

    internal void Delete(int apple, string id2)
    {
      Product product = GetById(apple);
      if (!_productsRepository.Delete(apple))
      {
        throw new Exception("Error please check if you created this");
      }
    }
  }


}