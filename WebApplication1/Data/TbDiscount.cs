using System;
using System.Collections.Generic;

namespace WebApplication1.Data;

public partial class TbDiscount
{
    public int? IdCupon { get; set; }

    public string? CuponCode { get; set; }

    public decimal? DiscountPercent { get; set; }

    public DateTime? ValidFrom { get; set; }

    public DateTime? ValidUntil { get; set; }
}
