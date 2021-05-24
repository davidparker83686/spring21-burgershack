using burgershack.Enums;
using burgershack.Interfaces;

namespace spring21_burgershack.Models
{
  public class Side : IMenuItem
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Cost { get; set; }
    public int Quantity { get; set; }
    public string Modifications { get; set; }
    public ItemType ItemType
    {
      get => ItemType.Side;
    }
  }
}