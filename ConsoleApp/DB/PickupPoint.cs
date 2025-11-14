using System;
using System.Collections.Generic;

namespace ConsoleApp.DB;

public partial class PickupPoint
{
    public int PointId { get; set; }

    public string Addres { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
