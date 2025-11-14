using System;
using System.Collections.Generic;

namespace ConsoleApp.DB;

public partial class Order
{
    public int OrderId { get; set; }

    public int UserId { get; set; }

    public int PointId { get; set; }

    public decimal TotalAmount { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual PickupPoint Point { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
