using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Persistence.Model
{
    public class Order
    {
        [Key] public int OrderId { get; set; }
        [Required] public OrderStatus OS{ get; set; }
        [Required] public IList<Item> Items { get; set; }
        [Required, Range(1,255)] public int IQuantity { get; set; }
        [Required] public Location PickupLocation { get;set;}
    }
}