using System;
using System.Collections.Generic;

namespace ConsoleApp.BD;

public partial class ServiceOrder
{
    public int OrderId { get; set; }

    public int CustomerId { get; set; }

    public string? CarDetails { get; set; }

    public int BrokenPartId { get; set; }

    public string Status { get; set; } = null!;

    public decimal Revenue { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Part BrokenPart { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;
}
