using System;
using System.Collections.Generic;

namespace ConsoleApp.BD;

public partial class PurchaseOrder
{
    public int PurchaseOrderId { get; set; }

    public int PartId { get; set; }

    public int Quantity { get; set; }

    public DateTime OrderDate { get; set; }

    public int DeliveryDueCarCount { get; set; }

    public virtual Part Part { get; set; } = null!;
}
