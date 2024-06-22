using System;
using System.Collections.Generic;

namespace WebApplication1.Data;

public partial class TbOrderItem
{
    public string? IdOrderItems { get; set; }

    public string? IdOrder { get; set; }

    public string? IdProduct { get; set; }

    public string? Quantity { get; set; }

    public double? UnitPrice { get; set; }

    public int? IdCupon { get; set; }

    public virtual TbOrder? IdOrderNavigation { get; set; }

    public virtual TbProduct? IdProductNavigation { get; set; }
}
