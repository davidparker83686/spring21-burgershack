using System.Collections.Generic;

namespace burgershack.Interfaces
{
  public interface IRepo<T>
  {
    IEnumerable<T> GetAll();
    T Create(T data);
    T GetById(int id);
    T Update(T data);
  }
}